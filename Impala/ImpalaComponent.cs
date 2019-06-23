using GH_IO;
using GH_IO.Serialization;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using Rhino;
using Rhino.DocObjects;
using Rhino.Geometry;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Impala
{
  public static class InstanceUtils
  {
    public static T CreateInstance<T>(params object[] args)
    {
      var type = typeof(T);
      var instance = type.Assembly.CreateInstance(
          type.FullName, false,
          BindingFlags.Instance | BindingFlags.NonPublic,
          null, args, null, null);
      return (T)instance;
    }
  }

  // This thing is completely local. We don't need to worry about it going anywhere -- 
  // We have control over it, and we don't actually need to implement IGH_DataAccess.
  // We should, however, find the methods we need.
  public class ImpalaAccess
  {
    private readonly GH_Component component;
    private readonly GH_Document document;
    private int InputCount => component.Params.Input.Count;
    private int OutputCount => component.Params.Output.Count;
    private IGH_Structure[] InputData;
    private IGH_Structure[] OutputData;
    private bool[] OutputAssigned;

    private IGH_Param Input(int index)
    {
      return component.Params.Input[index];
    }
    private IGH_Param Output(int index)
    {
      return component.Params.Output[index];
    }

    public int Iteration { get; set; } = 0;

    public ImpalaAccess(GH_Component parent)
    {
      component = parent ?? throw new ArgumentNullException();
      document = parent.OnPingDocument();
      InputData = component.Params.Input.Select(p => p.VolatileData).ToArray();
      OutputData = component.Params.Output.Select(p => p.VolatileData).ToArray();
      // Todo - this constructor isn't quite done.
    }

    //Conversion Function is going to require runtime types.It'll have to happen in the Get() func.
    public ImpalaStructure<T> MakeImpalaStructure<T>(IGH_Structure tree) where T : IGH_Goo
    {
      if (tree is ImpalaStructure<T>) return (ImpalaStructure<T>)tree;

      // Do this
      return null;
    }


    public void AbortComponentSolution() { }

    // Dummy method.
    public bool BlitData<Q>(int paramIndex, GH_Structure<Q> tree, bool overwrite) where Q : IGH_Goo
    {
      return true;
    }

    public void DisableGapLogic()
    {
      throw new NotImplementedException();
    }

    public void DisableGapLogic(int paramIndex)
    {
      throw new NotImplementedException();
    }


    // All this really needs to do is be able to get/set VolatileData from params.
    public bool GetTree<T>(int index, out ImpalaStructure<T> tree) where T : IGH_Goo
    {
      if (index < 0 || index >= InputCount) throw new IndexOutOfRangeException();
      if (Input(index).Type != typeof(T))
      {
        tree = null; return false;
      }

      tree = MakeImpalaStructure<T>(InputData[index]);
      return tree != null;
    }


    public int ParameterTargetIndex(int paramIndex)
    {
      throw new NotImplementedException();
    }

    public GH_Path ParameterTargetPath(int paramIndex)
    {
      throw new NotImplementedException();
    }

    public bool SetDataTree<T>(int index, ImpalaStructure<T> tree) where T : class, IGH_Goo
    {
      if (index < 0 || index >= OutputCount) throw new IndexOutOfRangeException();
      var param = (ImpalaParam<T>)Output(index);
      if (param == null) return false;
      return param.SetTree(tree);
    }

    public int Util_CountNonNullRefs<T>(List<T> L)
    {
      throw new NotImplementedException();
    }

    public int Util_CountNullRefs<T>(List<T> L)
    {
      throw new NotImplementedException();
    }

    public bool Util_EnsureNonNullCount<T>(List<T> L, int N)
    {
      throw new NotImplementedException();
    }

    public int Util_FirstNonNullItem<T>(List<T> L)
    {
      throw new NotImplementedException();
    }

    public List<T> Util_RemoveNullRefs<T>(List<T> L)
    {
      throw new NotImplementedException();
    }
  }


  // We can sort of do it by selectively overriding the methods we need in GH_Component.
  abstract class ImpalaSubComponent : GH_Component
  {
    public ImpalaSubComponent(string name, string nickname, string description, string category, string subcategory)
    : base(name, nickname, description, category, subcategory)
    {
    }

    // Don't use the old ways.
    protected override void SolveInstance(IGH_DataAccess DA) { throw new NotImplementedException(); }
    // User this instead!
    public abstract void SolveInstance(ImpalaAccess DA);

    private bool TryWith(Action action, string message)
    {
      try
      {
        action();
        return true;
      }
      catch (Exception ex)
      {
        AddRuntimeMessage(GH_RuntimeMessageLevel.Error, message + ": " + ex.Message);
        return false;
      }
    }

    private IGH_PreviewObject CanView(IGH_Param param)
    {
      var preview_obj = (IGH_PreviewObject)param;
      if (preview_obj != null && !preview_obj.Hidden && preview_obj.IsPreviewCapable) return preview_obj;
      return null;
    }

    private TimeSpan _time = TimeSpan.Zero;
    public override TimeSpan ProcessorTime => _time;

    private BoundingBox _bbox = BoundingBox.Empty;
    public override BoundingBox ClippingBox
    {
      get
      {
        if (_bbox.IsValid) return _bbox;
        _bbox = BoundingBox.Empty;
        foreach (var param in Params)
        {
          var preview_obj = CanView(param);
          if (param.SourceCount <= 0 && preview_obj != null)
          {
            _bbox.Union(preview_obj.ClippingBox);
          }
        }
        return _bbox;
      }
    }



    public override void ComputeData()
    {
      if (Locked)
      {
        Phase = GH_SolutionPhase.Computed;
        Params.DoEach(p => p.Phase = GH_SolutionPhase.Computed);
        return;
      }

      switch (Phase)
      {
        case GH_SolutionPhase.Blank:
        case GH_SolutionPhase.Computed:
        case GH_SolutionPhase.Failed:
          return;

        case GH_SolutionPhase.Collecting:
          base.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Recursive Data Stream!");
          return;
      }

      // This gives the standard before/after control. 
      // We can look into NOT doing this, actually.
      Phase = GH_SolutionPhase.Computing;
      var timer = new System.Diagnostics.Stopwatch();
      timer.Start();
      Params.Output.DoEach(p => p.Phase = GH_SolutionPhase.Computed);
      if (TryWith(BeforeSolveInstance, "Before Solution Exception"))
      {



        // Check that everything has its shit together. 
        var hasData = Params.All(p => p.Optional || !p.VolatileData.IsEmpty);
        if (!hasData)
        {
          Phase = GH_SolutionPhase.Computed;
          TryWith(AfterSolveInstance, "After Solution Exception");
          return;
        }

        var it = new ImpalaAccess(this);

        try
        {
          SolveInstance(it);
          Phase = GH_SolutionPhase.Computed;
        }
        catch (Exception ex)
        {
          AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Solution Exception: " + ex.Message);
        }

        timer.Stop();
        _time = timer.Elapsed;
        _bbox = BoundingBox.Empty;
        if (Phase == GH_SolutionPhase.Computed) Params.DoEach(p => (p as IGH_ParamWithPostProcess)?.PostProcessData());
      }
      TryWith(AfterSolveInstance, "After Solution Exception");
    }
  }



  // ImpalaStructure for basic conversion operations. We should allow this to be made in/out of GH_Structure <T>
  public class ImpalaStructure<T> : IGH_Structure, IEnumerable<T>, GH_ISerializable where T : IGH_Goo
  {
    int numBranches;
    int[] sizePerBranch;

    GH_Path[] paths;
    int[][] data;
    int totalSize;

    // We'll try to keep path info consistent. We fully one-shot the allocation here
    // in order to save us a whole load of time when it comes to the .Add() methods.
    public ImpalaStructure(int numBranches, int[] sizePerBranch, GH_Path[] paths)
    {

      // We save everything here.
      this.numBranches = numBranches;
      this.sizePerBranch = sizePerBranch;
      this.paths = paths;
      this.data = new int[numBranches][];

      int total = 0;
      for (int i = 0; i < numBranches; i++)
      {
        int size = sizePerBranch[i];
        total += size;
        data[i] = new int[size];
      }

      totalSize = total;
    }

    // Standard data structure operations
    public bool IsEmpty => totalSize == 0;
    public int PathCount => numBranches;
    public int DataCount => totalSize;
    public IList<GH_Path> Paths => paths;

    public string TopologyDescription
    {
      get
      {
        if (totalSize == 0) return "empty data";
        return $"Data with {numBranches} branches";
        //@TODO: add the rest of the string in a builder. (sizeperbranch info).
      }
    }

    public IGH_StructureEnumerator AllData(bool skipNulls)
    {
      throw new NotImplementedException();
    }

    // What this
    public string DataDescription(bool includeIndices, bool includePaths)
    {
      throw new NotImplementedException();
    }

    // Also, what this
    public void ExpandPath(GH_Path path, int element, GH_ExpandMode mode)
    {
      throw new NotImplementedException();
    }


    // Warning: not efficient.
    public IList get_Branch(GH_Path path)
    {
      // We don't key by path.
      // We Introduce: A Level Of Indirection.
      // branch -> table -> index -> data[index]
      return null;
    }

    public IList get_Branch(int index)
    {
      return data[index];
    }

    public GH_Path get_Path(int index)
    {
      return paths[index];
    }

    public int LongestPathIndex()
    {
      GH_Path maxPath = null;
      int max = 0;
      for (int i = 0; i < numBranches; i++)
      {
        if (maxPath == null || maxPath.Length < paths[i].Length)
        {
          maxPath = paths[i];
          max = i;
        }
      }

      return max; // The actual index, not the path itself.
    }

    public bool PathExists(GH_Path path)
    {
      foreach (var gpath in paths)
      {
        if (gpath.IsCoincident(path)) return true;
      }
      return false;
    }

    public void PathIndex(GH_Path path, ref int idx0, ref int idx1)
    {
      throw new NotImplementedException();
    }

    public int ShortestPathIndex()
    {
      GH_Path minPath = null;
      int min = 0;
      for (int i = 0; i < numBranches; i++)
      {
        if (minPath == null || minPath.Length > paths[i].Length)
        {
          minPath = paths[i];
          min = i;
        }
      }

      return min; // The actual index, not the path itself.
    }




    // We have to implement these, since we're passing our thing to the output parameter.
    // And people want to do operations with that! Hahahahahah wellp. 
    // This is, I suppose, why we write our own ParamServers. But that's in the weeds.

    public void Flatten(GH_Path path = null) { }
    public void Simplify(GH_SimplificationMode mode) { }
    public void Graft(bool clearSingleNulls) { }
    public void Graft(GH_Path path, bool clearSingleNulls) { }
    public void Graft(GH_GraftMode mode) { }
    public void Graft(GH_GraftMode mode, GH_Path path) { }



    // METHODS THAT WE DON'T WANT TO IMPLEMENT BECAUSE IT DOESN'T MAKE SENSE

    // You don't wanna clear this.
    public void Clear() { }

    // You don't wanna clear this.
    public void ClearData() { }

    // Capacity has been ensured. Pray we do not ensure it further.
    public void EnsureCapacity(int capacity) => throw new NotImplementedException();

    // If you didn't want it, don't allocate it.
    public void TrimExcess() { }

    // If you didn't want it, don't put it there.
    public void RemovePath(GH_Path path) { }

    // Really.
    public void ReplacePath(GH_Path find, GH_Path replace) { }

    // Yo, what up with this? Serializers? 
    public IList<IList> StructureProxy => throw new NotImplementedException();



    // GH_ISerializable Implementation
    public bool Read(GH_IReader reader)
    {
      throw new NotImplementedException();
    }

    public bool Write(GH_IWriter writer)
    {
      throw new NotImplementedException();
    }




    // IEnumerable implementation 
    IEnumerator IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
      throw new NotImplementedException();
    }

  }

  // We will, in fact, have to learn _exactly_ how Grasshopper does what it's doing in order to provide our own parameter implementation
  // that maintains the pre-allocated, sorted invariants we're looking for. Additionally, we should look at what happens when something
  // comes _in_ to the component, and if there's any way we can define a separate interface. Our ImpalaComponent doesn't have to replicate 
  // the entire GH_Component interface - in fact, it's probably a good idea to keep it a lot simpler, which we can do because we remove
  // our restriction on having things be: 
  //  a) at a high-level data structure (ILists)
  //  b) generic and auto-casty
  //  c) particularly amenable to intermixing items, lists, trees, etc.
  // 
  // All of this comes in because we want to change the fundamental data structure backing behind the param. 
  // So off we go.
  //abstract class ImpalaParam<T> : GH_ActiveObject, IGH_Param, IGH_ParamWithPostProcess where T : class, IGH_Goo
  //{
  //  protected ImpalaParam(IGH_InstanceDescription Tag) : base(Tag)
  //  {
  //  }

  //  protected ImpalaParam(string sName, string sAbbreviation, string sDescription, string sCategory, string sSubCategory) : base(sName, sAbbreviation, sDescription, sCategory, sSubCategory)
  //  {
  //  }

  //  public abstract GH_ParamKind Kind { get; }
  //  public abstract GH_ParamData DataType { get; }
  //  public abstract Type Type { get; }
  //  public abstract string TypeName { get; }
  //  public abstract GH_StateTagList StateTags { get; }
  //  public abstract GH_ParamWireDisplay WireDisplay { get; set; }
  //  public abstract bool Optional { get; set; }
  //  public abstract GH_DataMapping DataMapping { get; set; }
  //  public abstract GH_ParamAccess Access { get; set; }
  //  public abstract bool Reverse { get; set; }
  //  public abstract bool Simplify { get; set; }


  //  public abstract IList<IGH_Param> Sources { get; }
  //  public abstract int SourceCount { get; }
  //  public abstract bool HasProxySources { get; }
  //  public abstract int ProxySourceCount { get; }
  //  public abstract IList<IGH_Param> Recipients { get; }
  //  public abstract int VolatileDataCount { get; }
  //  public abstract IGH_Structure VolatileData { get; }

  //  public abstract void AddSource(IGH_Param source);
  //  public abstract void AddSource(IGH_Param source, int index);

  //  public bool AddVolatileData(GH_Path path, int index, object data) { return false; } // Just don't do it
  //  public bool AddVolatileDataList(GH_Path path, IEnumerable list)   { return false; } // Or this either 
  //  public bool AddVolatileDataTree(IGH_Structure tree)               { return false; } // Or, really, this.

  //  public abstract void ClearProxySources(); 
  //  public abstract void CreateProxySources();
  //  public abstract bool RelinkProxySources(GH_Document document);
  //  public abstract void RemoveAllSources();
  //  public abstract void RemoveEffects();
  //  public abstract void RemoveSource(IGH_Param source);
  //  public abstract void RemoveSource(Guid source_id);
  //  public abstract void ReplaceSource(IGH_Param old_source, IGH_Param new_source);
  //  public abstract void ReplaceSource(Guid old_source_id, IGH_Param new_source);

  //  public void PostProcessData()
  //  {
  //    // Flatten, Graft, Yadda Yadda
  //  }


  //}


  class ImpalaStructureTester : ImpalaSubComponent
  {
    public ImpalaStructureTester(string name, string nickname, string description, string category, string subcategory)
        : base(name, nickname, description, category, subcategory)
    {
      // Off we gooooo
    }

    // Definitely still want to register input & output params
    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
      throw new NotImplementedException();
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
      throw new NotImplementedException();
    }

    public override Guid ComponentGuid => throw new NotImplementedException();

    public override void SolveInstance(ImpalaAccess DA)
    {
      int[] branches = { 1, 2, 3, 4, 5 };
      var paths = branches.Select(b => new GH_Path(b - 1)).ToArray();
      var result = new ImpalaStructure<GH_Integer>(5, branches, paths);
      DA.SetDataTree(0, result);

    }
  }
}
