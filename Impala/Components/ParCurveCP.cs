using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Errors;
using static Impala.Generated;

namespace Impala
{
    public class ParCurveCP : GH_Component
    {

        /// <summary>
        /// Initializes a new instance of the Parallel Curve CP class.
        /// </summary>
        public ParCurveCP()
          : base("Curve Closest Point", "ParCurveCP",
              "Closest Point on a curve to a sample, within a tolerance.",
              "Impala", "Physical")
        {
            var error = new Error<(GH_Point, GH_Curve, GH_Number)>(NullCheck,NullHandle,this);
            CheckError = new ErrorChecker<(GH_Point, GH_Curve, GH_Number)>(error);
        }

        static ErrorChecker<(GH_Point, GH_Curve, GH_Number)> CheckError;
        static Func<(GH_Point, GH_Curve, GH_Number), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Point to sample from", GH_ParamAccess.tree);
            pManager.AddCurveParameter("Curve", "C", "Curve to test", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Tolerance", "D", "Maximum testing distance", GH_ParamAccess.tree, Double.MaxValue);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Closest point on curve", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Parameter", "t", "Parameter on curve", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Projected", "X", "Was the point moved?", GH_ParamAccess.tree);
        }

        static (GH_Point,GH_Number,GH_Boolean) CurveCP(GH_Point p, GH_Curve c, GH_Number t)
        {
            Point3d pt = p.Value;
            Curve crv = c.Value;
            double tol = t.Value;

            bool param = crv.ClosestPoint(pt, out double curveParam, tol);
            if (param)
            {
                Point3d closePoint = crv.PointAt(curveParam);
                return (new GH_Point(closePoint), new GH_Number(curveParam), new GH_Boolean(true));
            }
            else
            {
                return (null, null, new GH_Boolean(false));
            }
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Curve> curveTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Number> tolTree)) return;

            var (points, parameters, projects) = Zip3x3(pointTree, curveTree, tolTree, CurveCP, CheckError);

            DA.SetDataTree(0, points);
            DA.SetDataTree(1, parameters);
            DA.SetDataTree(2, projects);
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
                return Impala.Properties.Resources.__0011_CurveCP;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("36712bfc-7336-491e-9e4c-e3a1455bb856"); }
        }
    }
 
}