using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;

using static Impala.Generated;
using static Impala.Errors;
using static Impala.Utilities;

namespace Impala
{
    public class ParMeshRay : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParCurveCP class.
        /// </summary>
        public ParMeshRay()
          : base("ParMeshRayIntersect", "ParMeshRay",
              "Shoot a ray at a mesh.",
              "Impala", "Intersection")
        {
            var error = new Error<(GH_Mesh, GH_Point, GH_Vector)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Mesh, GH_Point, GH_Vector)>(error);
        }

        public ErrorChecker<(GH_Mesh, GH_Point, GH_Vector)> CheckError;
        static Func<(GH_Mesh, GH_Point, GH_Vector), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "Mesh to intersect", GH_ParamAccess.tree);
            pManager.AddPointParameter("Point", "P", "Ray start point", GH_ParamAccess.tree);
            pManager.AddVectorParameter("Direction", "D", "Ray direction", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "X", "First intersection point", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Index", "I", "Face index of intersection", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Hit", "H", "Boolean indicating hit or miss", GH_ParamAccess.tree);
        }

        public static (GH_Point, GH_Integer, GH_Boolean) MeshRayIX(GH_Mesh gmsh, GH_Point gpt, GH_Vector gdir)
        {
            Mesh m = gmsh.Value;
            Ray3d ray = new Ray3d(gpt.Value, gdir.Value);
            var ix = Intersection.MeshRay(m, ray, out int[] faceIndices);
            if (ix < 0.0) return (null, null, new GH_Boolean(false));
            var pt = new GH_Point(ray.PointAt(ix));
            return (pt, new GH_Integer(faceIndices[0]), new GH_Boolean(true));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Mesh> meshTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Point> startTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Vector> dirTree)) return;

            var (ptx, idx, ix) = Zip3x3(meshTree, startTree, dirTree, MeshRayIX, CheckError);

            DA.SetDataTree(0, ptx);
            DA.SetDataTree(1, idx);
            DA.SetDataTree(2, ix);
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
            get { return new Guid("63C08602-F218-4C12-92B3-0573E91C7BC4"); }
        }
    }
}