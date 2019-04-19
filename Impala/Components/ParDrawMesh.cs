using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;

using static Impala.Generated;
using static Impala.Errors;
using static Impala.Utilities;

namespace Impala
{
  /// <summary>
  /// Solve Curve | Curve intersection
  /// </summary>
  public class ParDrawMesh : GH_Component
  {
    /// <summary>
    /// Initializes a new instance of the ParCCX Component.
    /// </summary>
    public ParDrawMesh()
      : base("ParDrawMesh", "ParDrawMesh",
          "",
          "Impala", "Test")
    {
      var error = new Error<(GH_Curve, GH_Integer, List<GH_Number>, List<GH_Number>)>(NullCheck, NullHandle, this);
      CheckError = new ErrorChecker<(GH_Curve, GH_Integer, List<GH_Number>, List<GH_Number>)>(error);
    }

    private ErrorChecker<(GH_Curve, GH_Integer, List<GH_Number>, List<GH_Number>)> CheckError;
    private static Func<(GH_Curve, GH_Integer, List<GH_Number>, List<GH_Number>), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null);

    /// <summary>
    /// Registers all the input parameters for this component.
    /// </summary>
    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
      pManager.AddPointParameter("Camera", "P", "Point to orient towards.", GH_ParamAccess.item);
      pManager.AddCurveParameter("Curves", "C", "Curves to add thickness.", GH_ParamAccess.tree);
      pManager.AddNumberParameter("Parameters", "t", "Parameters to define thicknesses.", GH_ParamAccess.tree);
      pManager.AddNumberParameter("Thicknesses", "T", "Thicknesses matching specified parameters.", GH_ParamAccess.tree);
      pManager.AddIntegerParameter("Subdivisions", "N", "Minimum subdivision segments per curve.", GH_ParamAccess.tree, 0);
    }

    /// <summary>
    /// Registers all the output parameters for this component.
    /// </summary>
    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
      pManager.AddMeshParameter("Result", "D", "Drawn Meshes", GH_ParamAccess.tree);
    }


    (List<double>,List<double>) CreateParameterPartition(int subdivisions, List<double> parameters, List<double> thicknesses, double max_param)
    {
      if (parameters.Count() >= subdivisions) return (parameters,thicknesses); // The easy case.

      var newParameters = new List<double>();
      var newThicknesses = new List<double>();
      for (int i = 1; i < parameters.Count(); i++)
      {
        var dParam = Math.Abs(parameters[i] - parameters[i - 1]);
        var dThick = Math.Abs(thicknesses[i] - thicknesses[i - 1]);
        var weight = dParam / max_param;
        var samples = (int) (weight * subdivisions);
        for (int k = 0; k < samples; k++)
        {
          double interp_weight = k / ((double) samples + 1);
          double parameter = parameters[i] + (interp_weight * dParam);
          double thickness = thicknesses[i] + (interp_weight * dThick);
          newParameters.Add(parameter);
          newThicknesses.Add(thickness);
        }
      }

      return (newParameters, newThicknesses);
    }


    (Point3d, Point3d) OffsetByThickness(Curve curve, double parameter, double thickness, Point3d camera)
    {
      Point3d point = curve.PointAt(parameter);
      Vector3d tangent = curve.TangentAt(parameter) * thickness; // Scale vector before rotating
      Transform ltfx = Transform.Rotation( Math.PI / 2, camera - point, point);
      Transform rtfx = Transform.Rotation(-Math.PI / 2, camera - point, point);

      Vector3d v1 = new Vector3d(tangent);
      Vector3d v2 = new Vector3d(tangent);
      v1.Transform(ltfx);
      v2.Transform(rtfx);

      return (point + v1, point + v2);
    }

    GH_Mesh CreateMeshFromPartition(GH_Curve gh_curve, GH_Point gh_camera, List<double> parameters, List<double> thicknesses)
    {
      Point3d camera = gh_camera.Value;
      Curve curve = gh_curve.Value;

      Mesh mesh = new Mesh();
      var (sp1, sp2) = OffsetByThickness(curve, parameters[0], thicknesses[0], camera);
      mesh.Vertices.Add(sp1);
      mesh.Vertices.Add(sp2);

      for (int i = 1; i < parameters.Count(); i++)
      {
        var (p1, p2) = OffsetByThickness(curve, parameters[i], thicknesses[i], camera);
        mesh.Vertices.Add(p1);
        mesh.Vertices.Add(p2);

        int v = i * 2; // Vertex index.
        mesh.Faces.AddFace(v - 2, v - 1, v + 1, v);
      }

      return new GH_Mesh(mesh);
    }

    GH_Point cameraPoint = null;

    GH_Mesh DrawMesh(GH_Curve curve, GH_Integer subdivisions, List<GH_Number> parameters, List<GH_Number> thicknesses)
    {

      var pars = new List<double>();
      var thks = new List<double>();
      var count = Math.Min(parameters.Count(), thicknesses.Count()); // Truncate

      for (int i = 0; i < count; i++)
      {
        pars.Add(parameters[i].Value);
        thks.Add(thicknesses[i].Value);
      }

      var (pars2, thks2) = CreateParameterPartition(subdivisions.Value, pars, thks, curve.Value.Domain.T1);
      return CreateMeshFromPartition(curve, cameraPoint, pars2, thks2);
    }


    /// <summary>
    /// Experimental runthrough of some parallel line-weighting techniques.
    /// Whether we want to generate a mesh or a list of meshes is up for debate. 
    /// There are currently some weirdnesses with how the vector rotations are being calculated.
    /// </summary>
    protected override void SolveInstance(IGH_DataAccess DA)
    {
      if (!DA.GetData(0, ref cameraPoint)) return;
      if (!DA.GetDataTree(1, out GH_Structure<GH_Curve> curveTree)) return;
      if (!DA.GetDataTree(2, out GH_Structure<GH_Number> paramTree)) return;
      if (!DA.GetDataTree(3, out GH_Structure<GH_Number> thickTree)) return;
      if (!DA.GetDataTree(4, out GH_Structure<GH_Integer> subdvTree)) return;

      if (cameraPoint == null || cameraPoint.Value == Point3d.Unset) return;

      //Todo: validate list lengths.

      // Algorithm: 
      // 
      // First, create a parameter partition for the curve:
      // - If there are more parameters provided than subdivs, we just use those
      // - Otherwise we create a uniform parameterization using N betweeen the subdivision amounts. 
      //    - This weights the number of samples attributed to each interval by its size.
      // 
      // Next, iterate along the partition and create normals in the planes
      // 
      // Add the offset vertices and newly constructed faces to a new mesh structure. 
      // Finish off the mesh structure.
      var result = Zip2Red2x1(curveTree, subdvTree, paramTree, thickTree, DrawMesh, CheckError);
      DA.SetDataTree(0, result);
    }

    /// <summary>
    /// Provides an Icon for the component.
    /// </summary>
    protected override System.Drawing.Bitmap Icon
    {
      get
      {
        return null;
      }
    }

    /// <summary>
    /// Gets the unique ID for this component. Do not change this ID after release.
    /// </summary>
    public override Guid ComponentGuid
    {
      get { return new Guid("A43C7799-594B-4A0C-96AA-2F447E5A7F7E"); }
    }
  }
}