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
    //Todo: Multiple-curve version
    public class ParPointInCurve : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParCurveCP class.
        /// </summary>
        public ParPointInCurve()
          : base("ParPointInCurve", "ParPtinCrv",
              "Test whether a point is inside a closed curve.",
              "Impala", "Physical")
        {
            var error = new Error<(GH_Curve, GH_Point, GH_Plane, GH_Boolean)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Curve, GH_Point, GH_Plane, GH_Boolean)>(error);
        }

        public ErrorChecker<(GH_Curve, GH_Point, GH_Plane, GH_Boolean)> CheckError;
        static Func<(GH_Curve, GH_Point, GH_Plane, GH_Boolean), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null && a.Item4 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "B", "Curves to test inclusion.", GH_ParamAccess.tree);
            pManager.AddPointParameter("Points", "P", "Points to test", GH_ParamAccess.tree);
            pManager.AddPlaneParameter("Plane", "P", "Plane to test in", GH_ParamAccess.tree, Plane.WorldXY);
            pManager.AddBooleanParameter("Strict", "S", "If true, inclusion is strict.", GH_ParamAccess.tree, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Included", "I", "Point contained in Curve", GH_ParamAccess.tree);
        }

        public static GH_Boolean PointInCurve(GH_Curve c, GH_Point p, GH_Plane pl, GH_Boolean s)
        {
            Curve curve = c.Value;
            Point3d pt = p.Value;
            Plane plane = pl.Value;
            bool strict = s.Value;

            if (!curve.IsClosed) return new GH_Boolean(false);
            var cont = curve.Contains(pt, plane, DocumentTolerance());
            var targ = strict ? cont == PointContainment.Inside : cont != PointContainment.Outside;
            return new GH_Boolean(targ);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Curve> curveTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Plane> planeTree)) return;
            if (!DA.GetDataTree(3, out GH_Structure<GH_Boolean> strictTree)) return;

            var result = Zip4x1(curveTree, pointTree, planeTree, strictTree, PointInCurve, CheckError);

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
            get { return new Guid("BA6FF177-A0F7-4D82-B494-95386EB44846"); }
        }
    }
}