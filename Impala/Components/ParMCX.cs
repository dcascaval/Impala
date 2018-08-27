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
    public class ParMCX : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParMCX class.
        /// </summary>
        public ParMCX()
          : base("ParMeshCurveIntersect", "ParMCX",
              "Test whether a mesh and a curve intersect.",
              "Impala", "Intersection")
        {
            var error = new Error<(GH_Mesh, GH_Curve)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Mesh, GH_Curve)>(error);
        }

        public ErrorChecker<(GH_Mesh, GH_Curve)> CheckError;
        static Func<(GH_Mesh, GH_Curve), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "Mesh to intersect", GH_ParamAccess.tree);
            pManager.AddCurveParameter("Curve", "C", "Curve to intersect with", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Intersection points", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Faces", "F", "Face Index for each intersection", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Intersection", "X", "Do the curves intersect?", GH_ParamAccess.tree);
        }

        public static (GH_Point[], GH_Integer[], GH_Boolean[]) MCX(GH_Mesh ghmesh, GH_Curve ghcurve)
        {
            Mesh m = ghmesh.Value;
            Curve c = ghcurve.Value;
            var failResult = (new GH_Point[0], new GH_Integer[0], Array(new GH_Boolean(false)));

            var tt = DocumentTolerance();
            PolylineCurve plx;
            if (!c.TryGetPolyline(out Polyline p))
                plx = c.ToPolyline(c.SpanCount, 100, DocumentAngleTolerance(), tt, 0, tt, 0, 0, true);          
            else
                plx = new PolylineCurve(p);
            
            var ix = Intersection.MeshPolyline(m, plx, out int[] faceidxs);
            if (ix.Length == 0) return failResult;

            var pts = ix.Select(par => new GH_Point(par)).ToArray();
            var idx = faceidxs.Select(x => new GH_Integer(x)).ToArray();
            return (pts, idx, Array(new GH_Boolean(true)));         
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Mesh> meshTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Curve> curveTree)) return;

            var (pts,idx,ix) = Zip2xGraft3(meshTree, curveTree, MCX, CheckError);

            DA.SetDataTree(0, pts);
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
                return Impala.Properties.Resources.__0018_MeshCurve;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("64524F88-19CF-4FFB-9B7F-E96E192258A4"); }
        }
    }
}