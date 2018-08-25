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

namespace Impala
{
    public class ParMeshInc : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParMeshCP class.
        /// </summary>
        public ParMeshInc()
          : base("ParMeshInc", "ParMeshInc",
              "Test whether a point is inside a closed mesh.",
              "Impala", "Containment")
        {
            var error = new Error<(GH_Mesh, GH_Point, GH_Boolean)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Mesh, GH_Point, GH_Boolean)>(error);
        }

        public ErrorChecker<(GH_Mesh, GH_Point, GH_Boolean)> CheckError;
        static Func<(GH_Mesh, GH_Point, GH_Boolean), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "B", "Meshes to project to.", GH_ParamAccess.tree);
            pManager.AddPointParameter("Points", "P", "Points to test from.", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Strict", "S", "If true, inclusion is strict.", GH_ParamAccess.tree, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Included", "I", "Point contained in Mesh", GH_ParamAccess.tree);
        }

        public static GH_Boolean PointInMesh(GH_Mesh m, GH_Point p, GH_Boolean s)
        {         
            Mesh mesh = m.Value;
            Point3d pt = p.Value;
            bool strict = s.Value;
            if (!mesh.IsClosed) return new GH_Boolean(false);
            return new GH_Boolean(mesh.IsPointInside(pt, 1e-8, strict));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Mesh> meshTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Boolean> strictTree)) return;

            var result = Zip3x1(meshTree, pointTree, strictTree, PointInMesh, CheckError);

            DA.SetDataTree(0, result);
            return;
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("B07929A6-3576-4098-B574-B81B5CD5435D"); }
        }
    }

    public class ParMMeshInc : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParMeshCP class.
        /// </summary>
        public ParMMeshInc()
          : base("ParMMeshInc", "ParMMeshInc",
              "Test whether a point is inside multiple closed meshes.",
              "Impala", "Containment")
        {
            var error = new Error<(GH_Point, GH_Boolean, List<GH_Mesh>)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Point, GH_Boolean, List<GH_Mesh>)>(error);
        }

        public ErrorChecker<(GH_Point, GH_Boolean, List<GH_Mesh>)> CheckError;
        static Func<(GH_Point, GH_Boolean, List<GH_Mesh>), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "B", "Meshes to project to.", GH_ParamAccess.tree);
            pManager.AddPointParameter("Points", "P", "Points to test from.", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Strict", "S", "If true, inclusion is strict.", GH_ParamAccess.tree, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Included", "R", "Point contained in meshes", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Index", "I", "Index of first mesh that contains point", GH_ParamAccess.tree);
        }

        public static (GH_Boolean,GH_Integer) PointInMesh(GH_Point p, GH_Boolean s, List<GH_Mesh> gmsh)
        {
            var mshs = gmsh.Where(g => g != null).Select(g => g.Value).ToArray();
            Point3d pt = p.Value;
            bool strict = s.Value;

            for (int i = 0; i < mshs.Length; i++)
            {
                Mesh mesh = mshs[i];
                if (!mesh.IsClosed) continue;
                if (mesh.IsPointInside(pt, 1e-8, strict))
                {
                    return (new GH_Boolean(true), new GH_Integer(i));
                }
            }
            return (new GH_Boolean(false), new GH_Integer(-1));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Mesh> meshTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Boolean> strictTree)) return;

            var (ix,idx) = Zip2Red1x2(pointTree, strictTree, meshTree, PointInMesh, CheckError);

            DA.SetDataTree(0, ix);
            DA.SetDataTree(0, idx);
            return;
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("1E4E898A-6BC5-42C4-AB9D-22EC47B118A8"); }
        }
    }
}