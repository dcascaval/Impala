using GH_IO.Serialization;
using Grasshopper;
using Grasshopper.GUI.Canvas.TagArtists;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Undo;
using Grasshopper.Kernel.Undo.Actions;
using Rhino.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Impala
{

  // We will, in fact, have to learn _exactly_ how Grasshopper does what it's doing in order to provide our own parameter implementation
  // that maintains the pre-allocated, sorted invariants we're looking for. Additionally, we should look at what happens when something
  // comes _in_ to the component, and if there's any way we can define a separate interface. Our ImpalaComponent doesn't have to replicate 
  // the entire GH_Component interface - in fact, it's probably a good idea to keep it a lot simpler, which we can do because we remove
  // our restriction on having things be: 
  //  a) at a high-level data structure (ILists)
  //  b) generic and auto-casty
  //  c) particularly amenable to intermixing items, lists, trees, etc. in anything other than broadcast semantics
  // 
  // All of this comes in because we want to change the fundamental data structure backing behind the param, and adjust 
  // the logic of how it merges in order to take advantage of precomputing the allocated space needed.  
  // So off we go.
  // 
  // Things that still need to be accomplished:
  // - PersistentParam<T>
  // - GeometricParam<T>
  abstract class ImpalaParam<T> : GH_ActiveObject, IGH_Param, IGH_ParamWithPostProcess where T : class, IGH_Goo
  {
    public bool SetTree(ImpalaStructure<T> tree) { return false; }
    private List<IGH_Param> m_sources;

    private readonly List<IGH_Param> m_recipients;
    private bool m_optional;

    private GH_ParamKind m_kind;
    private GH_ParamAccess m_access;
    private GH_DataMapping m_mapping;

    private bool m_reverse;
    private bool m_simplify;
    protected ImpalaStructure<T> Data;

    private readonly Type static_type;
    private TimeSpan m_proc_span;
    private BoundingBox m_clippingBox;
    public virtual IList<IGH_Param> Sources => m_sources;
    public virtual int SourceCount => m_sources.Count;
    public virtual IList<IGH_Param> Recipients => m_recipients;
    public virtual bool HasProxySources => m_sources.Any(p => p is IGH_ProxyParameter);

    /// <summary>
    ///  Gets the number of proxy sources for this parameter.
    ///  Proxy sources are used during file IO, when actual sources might not be available yet. 
    ///  Once an IO operation has been completed there should be no more proxy sources.
    ///  </summary>
    /// <returns>The number of proxy sources associated with this parameter.</returns>
    public virtual int ProxySourceCount => m_sources.Count(p => p is IGH_ProxyParameter);

    public virtual Type Type => typeof(T);

    public virtual GH_ParamKind Kind
    {
      get
      {
        if (m_kind != GH_ParamKind.unknown || Attributes == null)
          return m_kind;
 
        if (Attributes is GH_LinkedParamAttributes)
        {
          if (!Attributes.IsTopLevel && Attributes.GetTopLevel.DocObject is IGH_Component comp && !comp.InConstructor)
          {
            if (comp.Params.IsInputParam(this)) m_kind = GH_ParamKind.input;
            else if (comp.Params.IsOutputParam(this)) m_kind = GH_ParamKind.output;
          }
          return m_kind;
        }

        if (Attributes.IsTopLevel) m_kind = GH_ParamKind.floating;
        return m_kind;
      }
    }


    public virtual GH_ParamAccess Access { get; set; }
    public bool Optional { get; set; }

    //  Todo: Figure out how to implement IGH_StateTag ?? (Or find an implementation)
    //  A state tag is a visual feedback icon that represents specific internal settings. (flat graft etc.)
    //  new GH_Param<T>().StateTags();  <-- We can spoof one of these with the same states.
    public virtual GH_StateTagList StateTags => new GH_StateTagList();

    public GH_ParamWireDisplay WireDisplay { get; set; }

    public GH_DataMapping DataMapping
    {
      get => m_mapping;
      set
      {
        if (m_mapping != value)
        {
          m_mapping = value;
          OnObjectChanged(GH_ObjectEventType.DataMapping);
        }
      }
    }

    public bool Reverse { get; set; }
    public bool Simplify { get; set; }
    public override string InstanceDescription => "";
    public override bool IsDataProvider => Kind == GH_ParamKind.floating || Kind == GH_ParamKind.output;
    public virtual GH_ParamData DataType => SourceCount == 0 ? GH_ParamData.@void : GH_ParamData.remote;

    public int VolatileDataCount => Data.DataCount;
    public IGH_Structure VolatileData => Data;
    public override TimeSpan ProcessorTime => m_proc_span;

    // We do not support prinicpal parameters.
    public GH_PrincipalState IsPrincipal => GH_PrincipalState.CannotBePrincipal;

    public virtual string TypeName
    {
      get
      {
        foreach(var it in Data) { if (it is T item) return item.TypeName; }
        T t = default;
        return t == null ? "Data" : t.TypeName;
      }
    }

    protected ImpalaParam(IGH_InstanceDescription tag)
      : base(tag)
    {
      m_sources = new List<IGH_Param>();
      m_recipients = new List<IGH_Param>();
      m_optional = false;
      m_kind = GH_ParamKind.unknown;
      m_access = GH_ParamAccess.item;
      m_mapping = GH_DataMapping.None;
      m_reverse = false;
      m_simplify = false;
      WireDisplay = GH_ParamWireDisplay.@default;

      Data = null;

      static_type = typeof(T);
      m_proc_span = TimeSpan.Zero;
      m_clippingBox = BoundingBox.Empty;
    }

    protected ImpalaParam(IGH_InstanceDescription tag, GH_ParamAccess access)
      : base(tag)
    {
      m_sources = new List<IGH_Param>();
      m_recipients = new List<IGH_Param>();
      m_optional = false;
      m_kind = GH_ParamKind.unknown;
      m_access = GH_ParamAccess.item;
      m_mapping = GH_DataMapping.None;
      m_reverse = false;
      m_simplify = false;
      WireDisplay = GH_ParamWireDisplay.@default;

      Data = null;  

      static_type = typeof(T);
      m_proc_span = TimeSpan.Zero;
      m_clippingBox = BoundingBox.Empty;
      m_access = access;
    }

    protected ImpalaParam(string name, string nickname, string description, string category, string subcategory, GH_ParamAccess access)
      : this(new GH_InstanceDescription(name, nickname, description, category, subcategory), access)
    {
    }

    public override void CreateAttributes()
    {
      m_attributes = new GH_FloatingParamAttributes(this);
    }

    /// <summary>
    ///  Append a new Source parameter to the end of the Sources list. 
    ///  Sources provide this parameter with data at runtime.
    ///  </summary>
    /// <param name="source">Source to append.</param>
    public virtual void AddSource(IGH_Param source)
    {
      AddSource(source, int.MaxValue);
    }

    public virtual void AddSource(IGH_Param source, int index)
    {
      if (source != null && this != source && !Sources.Contains(source))
      {
        index = Math.Max(index, 0);
        index = Math.Min(index, SourceCount);
        if (index == SourceCount)
        {
          Sources.Add(source);
        }
        else
        {
          Sources.Insert(index, source);
        }
        if (!source.Recipients.Contains(this))
        {
          source.Recipients.Add(this);
        }
        OnObjectChanged(GH_ObjectEventType.Sources);
        ExpireSolution(recompute: false);
      }
    }


    /// <summary>
    ///  Remove the specified source from this parameter.
    ///  </summary>
    /// <param name="source">Source to remove.</param>
    public virtual void RemoveSource(IGH_Param source)
    {
      if (source != null && m_sources.Contains(source))
      {
        Sources.Remove(source);
        source.Recipients.Remove(this);
        OnObjectChanged(GH_ObjectEventType.Sources);
        ExpireSolution(recompute: false);
      }
    }

    public virtual void RemoveSource(Guid source_id)
    {
      m_sources.DoEach(s => { if (s.InstanceGuid == source_id) RemoveSource(s); });
    }

    /// <summary>
    ///  Remove all sources from this parameter.
    ///  </summary>
    public virtual void RemoveAllSources()
    {
      if (Sources.Count != 0)
      {
        foreach (var param in Sources)
        {
          param.Recipients.Remove(this);
        }
        m_sources.Clear();
        OnObjectChanged(GH_ObjectEventType.Sources);
        ExpireSolution(false);
      }
    }


    public virtual void ReplaceSource(IGH_Param old_source, IGH_Param new_source)
    {
      int idx = m_sources.IndexOf(old_source);
      if (idx >= 0)
      {
        old_source.Recipients.Remove(this);
        if (!new_source.Recipients.Contains(this))
        {
          new_source.Recipients.Add(this);
        }
        if (m_sources.Contains(new_source))
        {
          m_sources.RemoveAt(idx);
        }
        else
        {
          m_sources[idx] = new_source;
        }
        OnObjectChanged(GH_ObjectEventType.Sources);
        ExpireSolution(recompute: false);
      }
    }


    /// <summary>
    ///  Replace an existing source with a new one. If the old_source 
    ///  does not exist in this parameter, nothing happens.
    ///  </summary>
    /// <param name="old_source_id">Source to replace.</param>
    /// <param name="new_source">Source to replace with.</param>
    public virtual void ReplaceSource(Guid old_source_id, IGH_Param new_source)
    {
      m_sources.DoEach(p => {
        if ((p is GH_ProxyParameter prox && prox.ProxyGuid == old_source_id) || p.InstanceGuid == old_source_id)
          ReplaceSource(p, new_source);
      });
    }

    // Todo: check the hashcode of IGH_Param
    public override bool DependsOn(IGH_ActiveObject potential_source)
    {
      if (SourceCount == 0) return false; 

      var AttHash = potential_source.Attributes.GetTopLevel;
      return m_sources.Any(p => p.Attributes.GetTopLevel == AttHash);
    }

    public virtual bool RelinkProxySources(GH_Document document)
    {
      bool result = true;
      bool expire = false;

      for (int i = 0; i < SourceCount; i++)
      {
        var Param = Sources[i];
        if (!(Param is IGH_ProxyParameter)) continue;

        var prox_param = (IGH_ProxyParameter)Param;
        var rep_param = document.FindParameter(prox_param.ProxyGuid);
        if (rep_param == null)
        {
          result = false;
          continue;
        }

        Sources[i] = rep_param;
        if (!rep_param.Recipients.Contains(this)) rep_param.Recipients.Add(this);
      }

      if (expire) ExpireSolution(recompute: false);
      return result;
    }

    /// <summary>
    ///  Convert all proper source parameters into proxy sources.
    ///  </summary>
    public virtual void CreateProxySources()
    {
      for (int i = 0; i < Sources.Count; i++)
      {
        if (!(Sources[i] is GH_ProxyParameter))
        {
          Sources[i].Recipients.Remove(this);
          Sources[i] = new GH_ProxyParameter(Sources[i].InstanceGuid);
          Sources[i].Attributes.Pivot = new PointF(Attributes.InputGrip.X - 100f, Attributes.InputGrip.Y);
        }
      }
      ExpireSolution(false);
    }

    public virtual void ClearProxySources()
    {
      m_sources = m_sources.FindAll(p => !(p is IGH_ProxyParameter));
    }

    public override void IsolateObject()
    {
      RemoveAllSources();
      m_recipients.DoEach(p => p.RemoveSource(this));
    }


    /// <summary>
    ///  Remove all post-process effects. Note to implementors, 
    ///  you <i>must</i> call the base method if you override this function.
    ///  </summary>
    public virtual void RemoveEffects()
    {
      Simplify = false;
      Reverse = false;
      DataMapping = GH_DataMapping.None;
    }

    // We don't support doing this to an ImpalaParam.
    public bool AddVolatileData(GH_Path path, int index, object data)
    {
      return false;
    }

    // This either
    public bool AddVolatileData(GH_Path path, int index, T data)
    {
      return false;
    }

    // This either
    public bool AddVolatileDataList(GH_Path path, IEnumerable list)
    {
      return false;
    }

    // Ya nope
    public bool AddVolatileDataList(GH_Path path, List<T> list)
    {
      return false;
    }

    // Probably not even this TBH
    public bool AddVolatileDataTree(IGH_Structure tree)
    {
      return false;
    }

    // This tho. Maybe.
    public bool AddVolatileDataTree(GH_Structure<T> tree)
    {
      // Hahaha no
      return false;
    }

    // The famous GH Casting algorithm.
    // Too bad.

    public override void ClearData()
    {
      base.ClearData();
      Data = null; // Cleared, boi
      m_clippingBox = BoundingBox.Empty;
    }

    // Todo: Remove extraneous calls from this.
    public sealed override void CollectData()
    {
      m_proc_span = TimeSpan.Zero;
      if (Locked)
      {
        Phase = GH_SolutionPhase.Collected;
        return;
      }

      switch (Phase)
      {
        case GH_SolutionPhase.Collecting:
          base.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, $"Cyclical data stream detected, parameter {NickName} is recursive.");
          Phase = GH_SolutionPhase.Failed;
          break;

        case GH_SolutionPhase.Blank:
        case GH_SolutionPhase.Failed:
          {
            // Already had stuff
            if (!VolatileData.IsEmpty)
            {
              PostProcessData(); // Todo get rid of this mechanism
              Phase = GH_SolutionPhase.Collected;
              break;
            }
            
            // Currently getting stuff
            Phase = GH_SolutionPhase.Collecting;
            switch (Kind)
            {
              case GH_ParamKind.output:
                if (m_attributes.GetTopLevel.DocObject is IGH_ActiveObject parent)
                {
                    parent.CollectData();
                    parent.ComputeData();
                    Phase = GH_SolutionPhase.Collected;
                }
                break;
                
              case GH_ParamKind.floating:
              case GH_ParamKind.input:
                if (SourceCount > 0) CollectVolatileData_FromSources();
                PostProcessData(); // Todo get rid of this mechanism
                Phase = GH_SolutionPhase.Collected;
                break;

              case GH_ParamKind.unknown:
                Phase = GH_SolutionPhase.Failed;
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Parameter failed to collect data");
                return;
            }

            // Didn't find anything (Failure cases).
            if (VolatileData.IsEmpty && !Optional)
            {
              switch (Kind)
              {
                case GH_ParamKind.output:
                  Phase = GH_SolutionPhase.Collected;
                  return;

                default:
                  AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, $"Parameter {NickName} failed to collect data");
                  break;
              }
              Phase = GH_SolutionPhase.Failed;
            }
            else
              Phase = GH_SolutionPhase.Collected;
            
            break;
          }

        default:
          break;
      }
    }

    // To do stuff efficiently, we're going to need the flatten/graft/reverse state in the component itself, 
    // so that we can create a tree that meets the properties already.
    public void PostProcessData() { }

    public sealed override void ComputeData()
    {
      Phase = GH_SolutionPhase.Computed;
      m_clippingBox = BoundingBox.Empty;
    }

    protected override void ExpireDownStreamObjects()
    {
      Recipients.DoEach(r => { if (r.Phase != GH_SolutionPhase.Blank) r.ExpireSolution(false); });
      if (Attributes != null && Kind == GH_ParamKind.input) { 
        if (Attributes.GetTopLevel.DocObject is IGH_ActiveObject owner && owner != this)
        {
          owner.ExpireSolution(false);
        }
      }
    }

    protected T Cast_Object(object data)
    {
      if (data == null) return null;
      if (data is T simple) return simple;

      if (data is GH_ObjectWrapper obj)
      {
        if (typeof(T).Equals(GH_TypeLib.t_gh_objwrapper)) return (T)data;
        if (obj.Value == null) return null;
        data = obj.Value; // Unwrap
      }

      T result = default;
      if (result != null && result.CastFrom(data)) return result;
      if (data is IGH_Goo goo && goo.CastTo(out result)) return result;
      return null;
    }

    // This is the big boy right here.
    protected virtual void CollectVolatileData_FromSources()
    {
      if (GH_Document.IsEscapeKeyDown())
      {
        OnPingDocument()?.RequestAbortSolution();
        ClearData();
        return;
      }
    }


    // Do not currently support Principal Component mechanic.
    public bool SetPrincipal(bool set, bool recordUndo, bool recompute)
    {
      return false;
    }

    // UI Stuff, and lots of it.

    /// <summary>
    ///  Override this function if you want to add specific items to the object context menu
    ///  Default items already included in the menu toolstrip are:
    ///  1. Name
    ///  2. Preview
    ///  3. Warnings
    ///  4. Errors
    ///  </summary>
    public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
    {
      Menu_AppendWireDisplay(menu);
      Menu_AppendDisconnectWires(menu);
      Menu_AppendReverseParameter(menu);
      Menu_AppendFlattenParameter(menu);
      Menu_AppendGraftParameter(menu);
      Menu_AppendSimplifyParameter(menu);
      Menu_AppendSeparator(menu);
    }

    protected void Menu_AppendWireDisplay(ToolStripDropDown menu)
    {
      switch (Kind)
      {
        case GH_ParamKind.floating:
        case GH_ParamKind.input:
          if (Attributes == null || Attributes.HasInputGrip)
          {
            var baseItem = Menu_AppendItem(menu, "Wire Display", null);
            var item4 = Menu_AppendItem(baseItem.DropDown, "Default", Menu_WireDisplayDefaultClicked, enabled: true, WireDisplay == GH_ParamWireDisplay.@default);
            var item3 = Menu_AppendItem(baseItem.DropDown, "Faint", Menu_WireDisplayFaintClicked, enabled: true, WireDisplay == GH_ParamWireDisplay.faint);
            var item2 = Menu_AppendItem(baseItem.DropDown, "Hidden", Menu_WireDisplayHiddenClicked, enabled: true, WireDisplay == GH_ParamWireDisplay.hidden);
            item4.ToolTipText = "All incoming wires are drawn using the default Grasshopper style";
            item3.ToolTipText = "All incoming wires are drawn as faint lines";
            item2.ToolTipText = "All incoming wires are not drawn unless selected";
          }
          break;
      }
      return;
    }

    private void Menu_WireDisplayDefaultClicked(object sender, EventArgs e)
    {
      if (WireDisplay != 0)
      {
        var action = new GH_WireDisplayAction(this);
        RecordUndoEvent("Wire Display", action);
        WireDisplay = GH_ParamWireDisplay.@default;
        Instances.RedrawCanvas();
      }
    }

    private void Menu_WireDisplayFaintClicked(object sender, EventArgs e)
    {
      if (WireDisplay != GH_ParamWireDisplay.faint)
      {
        var action = new GH_WireDisplayAction(this);
        RecordUndoEvent("Wire Display", action);
        WireDisplay = GH_ParamWireDisplay.faint;
        Instances.RedrawCanvas();
      }
    }

    private void Menu_WireDisplayHiddenClicked(object sender, EventArgs e)
    {
      if (WireDisplay != GH_ParamWireDisplay.hidden)
      {
        var action = new GH_WireDisplayAction(this);
        RecordUndoEvent("Wire Display", action);
        WireDisplay = GH_ParamWireDisplay.hidden;
        Instances.RedrawCanvas();
      }
    }

    protected void Menu_AppendDisconnectWires(ToolStripDropDown menu)
    {
      int inCount = Sources.Count;
      int outCount = Recipients.Count;
      if (inCount + outCount == 0) return;

      var baseItem = Menu_AppendItem(menu, "Disconnect");
      Menu_AppendSeparator(menu);
      if (inCount > 0)
      {
        if (Kind == GH_ParamKind.floating)
        {
          var titleItem2 = Menu_AppendItem(baseItem.DropDown, "Input:");
          titleItem2.Enabled = false;
          titleItem2.TextAlign = ContentAlignment.MiddleCenter;
          titleItem2.Font = GH_FontServer.NewFont(titleItem2.Font, FontStyle.Italic);
        }
        Menu_AppendDisconnectSources(baseItem.DropDown);
        Menu_AppendDisconnectSelectedSources(baseItem.DropDown);
        Menu_AppendDisconnectSource(baseItem.DropDown);
      }
      if (outCount > 0)
      {
        if (Kind == GH_ParamKind.floating)
        {
          Menu_AppendSeparator(baseItem.DropDown);
          var titleItem = Menu_AppendItem(baseItem.DropDown, "Output:");
          titleItem.Enabled = false;
          titleItem.TextAlign = ContentAlignment.MiddleCenter;
          titleItem.Font = GH_FontServer.NewFont(titleItem.Font, FontStyle.Italic);
        }
        Menu_AppendDisconnectRecipients(baseItem.DropDown);
        Menu_AppendDisconnectSelectedRecipients(baseItem.DropDown);
        Menu_AppendDisconnectRecipient(baseItem.DropDown);
      }
    }

    private void Menu_AppendDisconnectSources(ToolStripDropDown menu)
    {
      if (Sources.Count > 1)
      {
        Menu_AppendItem(menu, "Disconnect All", Menu_DisconnectSourcesClicked, SourceCount > 0);
      }
    }

    private void Menu_DisconnectSourcesClicked(object sender, EventArgs e)
    {
      OnPingDocument().UndoUtil.RecordWireEvent("Disconnect Sources", this);
      RemoveAllSources();
      ExpireSolution(recompute: true);
    }

    private void Menu_AppendDisconnectSelectedSources(ToolStripDropDown menu)
    {
      if (Sources.Count(s => s.Attributes != null && s.Attributes.Selected) != 0)
      {
        Menu_AppendItem(menu, "Disconnect Selected", Menu_DisconnectSelectedSourcesClicked);
      }
    }

    private void Menu_DisconnectSelectedSourcesClicked(object sender, EventArgs e)
    {
      OnPingDocument().UndoUtil.RecordWireEvent("Disconnect Sources", this);
      Sources.DoEach(s => { if (s.Attributes != null && s.Attributes.Selected) RemoveSource(s); });
      ExpireSolution(true);
    }

    private void Menu_AppendDisconnectSource(ToolStripDropDown menu)
    {

      foreach (var source in m_sources)
      {
        var item = Menu_AppendItem(menu, source.Attributes.PathName, Menu_DisconnectSourceClicked, source.Icon_24x24, true, false);
        item.Tag = source;
        item.MouseEnter += Menu_DisconnectSourceMouseEnter;
        item.MouseLeave += Menu_DisconnectSourceMouseLeave;
      }
      
    }

    private void Menu_DisconnectSourceMouseEnter(object sender, EventArgs e)
    {
      if (sender is ToolStripMenuItem item && item.Tag != null)
      {
        var source = (IGH_Param)item.Tag;
        var artist = new GH_TagArtist_WirePainter(source, this, Color.DarkRed, 5);
        Instances.ActiveCanvas.AddTagArtist(artist);
        Instances.InvalidateCanvas();
      }
    }

    private void Menu_DisconnectSourceMouseLeave(object sender, EventArgs e)
    {
      Instances.ActiveCanvas.RemoveTagArtist(GH_TagArtist_WirePainter.WirePainter_ID);
      Instances.InvalidateCanvas();
    }

    private void Menu_DisconnectSourceClicked(object sender, EventArgs e)
    {
      Instances.ActiveCanvas.RemoveTagArtist(GH_TagArtist_WirePainter.WirePainter_ID);
      var item = (ToolStripMenuItem)sender;
      foreach(var source in m_sources)
      {
        if (source == item.Tag)
        {
          OnPingDocument().UndoUtil.RecordWireEvent("Disconnect Source", this);
          RemoveSource(source);
          ExpireSolution(true);
          return;
        }
      }
    }

    private void Menu_AppendDisconnectRecipients(ToolStripDropDown menu)
    {
      if (Recipients.Count > 1)
      {
        Menu_AppendItem(menu, "Disconnect All", Menu_DisconnectRecipientsClicked, Recipients.Count > 0);
      }
    }

    private void Menu_DisconnectRecipientsClicked(object sender, EventArgs e)
    {
      var undoRecord = new GH_UndoRecord("Disconnect Recipients");
      Recipients.DoEach(r => { undoRecord.AddAction(new GH_WireAction(r)); r.RemoveSource(this); });
      OnPingDocument().UndoServer.PushUndoRecord(undoRecord);
      ExpireSolution(true);
    }

    private void Menu_AppendDisconnectSelectedRecipients(ToolStripDropDown menu)
    {
      if (Recipients.Count(r => r.Attributes != null && r.Attributes.Selected) != 0)
      {
        Menu_AppendItem(menu, "Disconnect Selected", Menu_DisconnectSelectedRecipientsClicked);
      }
    }

    private void Menu_DisconnectSelectedRecipientsClicked(object sender, EventArgs e)
    {
      var undoRecord = new GH_UndoRecord("Disconnect Recipients");
      Recipients.DoEach(r =>
      {
        if (r.Attributes != null && r.Attributes.Selected)
        {
          undoRecord.AddAction(new GH_WireAction(r));
          r.RemoveSource(this);
        }
      });
      OnPingDocument().UndoServer.PushUndoRecord(undoRecord);
      ExpireSolution(true);
    }

    private void Menu_AppendDisconnectRecipient(ToolStripDropDown menu)
    {
      foreach (var recipient in Recipients)
      {
        var item = Menu_AppendItem(menu, recipient.Attributes.PathName, Menu_DisconnectRecipientClicked, recipient.Icon_24x24, true, false);
        item.Tag = recipient;
        item.MouseEnter += Menu_DisconnectRecipientMouseEnter;
        item.MouseLeave += Menu_DisconnectRecipientMouseLeave;
      }
    }

    private void Menu_DisconnectRecipientMouseEnter(object sender, EventArgs e)
    {
      if (sender is ToolStripMenuItem item && item.Tag != null)
      {
        var recipient = item.Tag;
        var artist = new GH_TagArtist_WirePainter(this, (IGH_Param) recipient, Color.DarkRed, 5);
        Instances.ActiveCanvas.AddTagArtist(artist);
        Instances.InvalidateCanvas();
      }
    }

    private void Menu_DisconnectRecipientMouseLeave(object sender, EventArgs e)
    {
      Instances.ActiveCanvas.RemoveTagArtist(GH_TagArtist_WirePainter.WirePainter_ID);
      Instances.InvalidateCanvas();
    }

    private void Menu_DisconnectRecipientClicked(object sender, EventArgs e)
    {
      Instances.ActiveCanvas.RemoveTagArtist(GH_TagArtist_WirePainter.WirePainter_ID);
      var item = (ToolStripMenuItem)sender;
      foreach (var recip in Recipients)
      {
        if (recip == item.Tag)
        {
          OnPingDocument().UndoUtil.RecordWireEvent("Disconnect Recipient", recip);
          recip.RemoveSource(this);
          ExpireSolution(true);
          return;
        }
      }
    }

    protected void Menu_AppendFlattenParameter(ToolStripDropDown menu)
    {
      var item = Menu_AppendItem(menu, "Flatten", Menu_FlattenParamItemClicked, enabled: true, DataMapping == GH_DataMapping.Flatten);
      item.ToolTipText = "Flatten all data in this parameter into a single list";
    }

    private void Menu_FlattenParamItemClicked(object sender, EventArgs e)
    {
      TriggerAutoSave(GH_AutoSaveTrigger.data_modification_event);
      var doc = OnPingDocument();
      if (doc != null)
      {
        var undoAction = new GH_DataModificationAction(this);
        doc.UndoUtil.RecordEvent("Flatten", undoAction);
      }
      DataMapping = DataMapping == GH_DataMapping.Flatten ? GH_DataMapping.None : GH_DataMapping.Flatten;
      if (Kind == GH_ParamKind.output) ExpireOwner();  
      ExpireSolution(true);
    }

    protected void Menu_AppendGraftParameter(ToolStripDropDown menu)
    {
      var item = Menu_AppendItem(menu, "Graft", Menu_GraftParamItemClicked, enabled: true, DataMapping == GH_DataMapping.Graft);
      item.ToolTipText = "Graft all data in this parameter";
    }

    private void Menu_GraftParamItemClicked(object sender, EventArgs e)
    {
      TriggerAutoSave(GH_AutoSaveTrigger.data_modification_event);
      var doc = OnPingDocument();
      if (doc != null)
      {
        var undoAction = new GH_DataModificationAction(this);
        doc.UndoUtil.RecordEvent("Graft", undoAction);
      }

      DataMapping = DataMapping == GH_DataMapping.Graft ? GH_DataMapping.None : GH_DataMapping.Graft;
      if (Kind == GH_ParamKind.output) ExpireOwner();
      ExpireSolution(true);
    }

    protected void Menu_AppendReverseParameter(ToolStripDropDown menu)
    {
      var item = Menu_AppendItem(menu, "Reverse", Menu_ReverseParamItemClicked, enabled: true, Reverse);
      item.ToolTipText = "Reverse the order of all lists in this parameter";
    }

    private void Menu_ReverseParamItemClicked(object sender, EventArgs e)
    {
      TriggerAutoSave(GH_AutoSaveTrigger.data_modification_event);
      var doc = OnPingDocument();
      if (doc != null)
      {
        var undoAction = new GH_DataModificationAction(this);
        doc.UndoUtil.RecordEvent("Reverse", undoAction);
      }
      Reverse = !Reverse;
      if (Kind == GH_ParamKind.output) ExpireOwner();
      ExpireSolution(true);
    }

    protected void Menu_AppendSimplifyParameter(ToolStripDropDown menu)
    {
      var item = Menu_AppendItem(menu, "Simplify", Menu_SimplifyParamItemClicked, enabled: true, Simplify);
      item.ToolTipText = "Simplify the data in this parameter by removing all redundant path elements";
    }

    private void Menu_SimplifyParamItemClicked(object sender, EventArgs e)
    {
      TriggerAutoSave(GH_AutoSaveTrigger.data_modification_event);
      var doc = OnPingDocument();
      if (doc != null)
      {
        var undoAction = new GH_DataModificationAction(this);
        doc.UndoUtil.RecordEvent("Simplify", undoAction);
      }
      Simplify = !Simplify;
      if (Kind == GH_ParamKind.output) ExpireOwner();
      ExpireSolution(true);
    }

    public void ExpireOwner()
    {
      if (Attributes != null && Attributes.GetTopLevel.DocObject is IGH_ActiveObject parent && parent != this) parent.ExpireSolution(false);
    }

    /// <summary>
    ///  This function can be used to iterate over all items in the Volatile data tree 
    ///  and collect the union clipping box of all non-null items that implement 
    ///  Preview.IGH_PreviewData. This function requires a lot of TypeOf and DirectCasting, 
    ///  so if you're worried about performance you should consider doing this yourself.
    ///  </summary>
    /// <returns>The clipping box for all valid items.</returns>
    protected BoundingBox Preview_ComputeClippingBox()
    {
      if (m_clippingBox.IsValid) return m_clippingBox;
      m_clippingBox = BoundingBox.Empty;
      if (Data == null) return m_clippingBox;
      Data.DoEach(it => { if (it is IGH_PreviewData prev && prev.ClippingBox.IsValid) m_clippingBox.Union(prev.ClippingBox); });
      return m_clippingBox;
    }

    protected void Preview_DrawWires(IGH_PreviewArgs args)
    {
      if (Data != null && !Locked)
      {
        var mat = Attributes.GetTopLevel.Selected ? args.WireColour_Selected : args.WireColour;
        var e = new GH_PreviewWireArgs(args.Viewport, args.Display, mat, args.DefaultCurveThickness); 
        Data.DoEach(it => { if (it is IGH_PreviewData prev) prev.DrawViewportWires(e); });
      }
    }

    /// <summary>
    ///  This function can be used to iterate over all items in the Volatile data tree 
    ///  and call DrawViewportWires on each item that implements Preview.IGH_PreviewData. 
    ///  This function requires a lot of TypeOf and DirectCasting, 
    ///  so if you're worried about performance you should consider doing this yourself.
    ///  </summary>
    protected void Preview_DrawMeshes(IGH_PreviewArgs args)
    {
      if (Data != null && !Locked)
      {
        var mat = Attributes.GetTopLevel.Selected ? args.ShadeMaterial_Selected : args.ShadeMaterial;
        var e = new GH_PreviewMeshArgs(args.Viewport, args.Display, mat, args.MeshingParameters);
        Data.DoEach(it => { if (it is IGH_PreviewData prev) prev.DrawViewportMeshes(e); });
      }
    }


    // Todo: 
    // There probably won't be too much to do in the way of this sort of thing. 
    // We can save a bit of the reading and writing, because we don't deal so much with 
    // things like ParamAccess and DataMapping. Well, maybe we do. Not really too sure.
    public override bool Write(GH_IWriter writer)
    {
      bool rc = base.Write(writer);
      switch (Access)
      {
        case GH_ParamAccess.list:
          writer.SetInt32("Access", 1);
          break;
        case GH_ParamAccess.tree:
          writer.SetInt32("Access", 2);
          break;
      }
      switch (DataMapping)
      {
        case GH_DataMapping.Flatten:
          writer.SetInt32("Mapping", 1);
          break;
        case GH_DataMapping.Graft:
          writer.SetInt32("Mapping", 2);
          break;
      }
      if (Reverse)
      {
        writer.SetBoolean("ReverseData", item_value: true);
      }
      if (Simplify)
      {
        writer.SetBoolean("SimplifyData", item_value: true);
      }
      writer.SetBoolean("Optional", Optional);
      switch (WireDisplay)
      {
        case GH_ParamWireDisplay.faint:
          writer.SetInt32("WireDisplay", 1);
          break;
        case GH_ParamWireDisplay.hidden:
          writer.SetInt32("WireDisplay", 2);
          break;
      }
      writer.SetInt32("SourceCount", SourceCount);
      int num = SourceCount - 1;
      for (int i = 0; i <= num; i++)
      {
        writer.SetGuid("Source", i, Sources[i].InstanceGuid);
      }
      return rc;
    }

    public override bool Read(GH_IReader reader)
    {
      bool rc = base.Read(reader);
      m_access = GH_ParamAccess.item;
      m_mapping = GH_DataMapping.None;
      WireDisplay = GH_ParamWireDisplay.@default;
      m_reverse = false;
      m_simplify = false;
      if (reader.ItemExists("Flat"))
      {
        if (reader.GetBoolean("Flat"))
        {
          m_mapping = GH_DataMapping.Flatten;
        }
      }
      else
      {
        int map_int = 0;
        if (reader.TryGetInt32("Mapping", ref map_int))
        {
          switch (map_int)
          {
            case 1:
              m_mapping = GH_DataMapping.Flatten;
              break;
            case 2:
              m_mapping = GH_DataMapping.Graft;
              break;
          }
        }
      }
      reader.TryGetBoolean("ReverseData", ref m_reverse);
      reader.TryGetBoolean("SimplifyData", ref m_simplify);
      reader.TryGetBoolean("Optional", ref m_optional);
      int wire_display = 0;
      if (reader.TryGetInt32("WireDisplay", ref wire_display))
      {
        switch (wire_display)
        {
          case 1:
            WireDisplay = GH_ParamWireDisplay.faint;
            break;
          case 2:
            WireDisplay = GH_ParamWireDisplay.hidden;
            break;
        }
      }
      if (reader.ItemExists("Access"))
      {
        switch (reader.GetInt32("Access"))
        {
          case 1:
            m_access = GH_ParamAccess.list;
            break;
          case 2:
            m_access = GH_ParamAccess.tree;
            break;
          default:
            reader.AddMessage(string.Format("Unknown Parameter Access flag: {0}. Value set to default.", reader.GetInt32("Access")), GH_Message_Type.error);
            break;
        }
      }
      else if (reader.ItemExists("List") && reader.GetBoolean("List"))
      {
        m_access = GH_ParamAccess.list;
      }
      RemoveAllSources();
      int sourceCount = reader.GetInt32("SourceCount");
      int num = sourceCount - 1;
      for (int i = 0; i <= num; i++)
      {
        var sourceId = reader.GetGuid("Source", i);
        var proxySource = new GH_ProxyParameter(sourceId);
        proxySource.Attributes.Pivot = new PointF(0f, 0f);
        AddSource(proxySource);
      }
      return rc;
    }
  }
}
