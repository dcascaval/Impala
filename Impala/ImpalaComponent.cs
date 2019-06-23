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

    //Conversion Function is going to require runtime types. It'll have to happen in the Get() func.
    public ImpalaStructure<T> MakeImpalaStructure<T>(IGH_Structure tree) where T : IGH_Goo
    {
      if (tree is ImpalaStructure<T>) return (ImpalaStructure<T>)tree;

      // Todo: Do this
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
  abstract class ImpalaComponent : GH_Component
  {
    public ImpalaComponent(string name, string nickname, string description, string category, string subcategory)
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


  // A small test component to verify that everything, you know, still works.
  class ImpalaStructureTester : ImpalaComponent
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
