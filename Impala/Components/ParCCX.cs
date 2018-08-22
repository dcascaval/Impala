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
    public class ParCCX : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParCurveCP class.
        /// </summary>
        public ParCCX()
          : base("ParCurveCurveIntersect", "ParCCX",
              "Test whether a pair of curves intersect.",
              "Impala", "Physical")
        {
            var error = new Error<(GH_Curve, GH_Curve)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Curve, GH_Curve)>(error);
        }

        public ErrorChecker<(GH_Curve, GH_Curve)> CheckError;
        static Func<(GH_Curve, GH_Curve), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve A", "A", "First curve", GH_ParamAccess.tree);
            pManager.AddCurveParameter("Curve B", "B", "Second curve", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Intersection points", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Params A", "tA", "Parameters on first curve", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Params B", "tB", "Parameters on second curve", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Intersection", "X", "Do the curves intersect?", GH_ParamAccess.tree);
            
        }

        public static (GH_Point[], GH_Number[], GH_Number[],GH_Boolean[]) CCX(GH_Curve gha, GH_Curve ghb)
        {
            Curve a = gha.Value;
            Curve b = ghb.Value;

            var tt = DocumentTolerance(); //Grasshopper does it this way. Why? Don't know. Compatibility.
            var ix = Intersection.CurveCurve(a, b, tt, 5.0*tt);
            if (ix.Count == 0)
            {
                return (new GH_Point[0], new GH_Number[0], new GH_Number[0], Array(new GH_Boolean(false)));
            }
            else
            {
                var ptx = new List<GH_Point>();
                var pA = new List<GH_Number>();
                var pB = new List<GH_Number>();
                foreach (var ixx in ix)
                {
                    ptx.Add(new GH_Point(0.5 * (ixx.PointA + ixx.PointB)));
                    pA.Add(new GH_Number(ixx.ParameterA));
                    pB.Add(new GH_Number(ixx.ParameterB));
                    if (ixx.IsOverlap)
                    {
                        ptx.Add(new GH_Point(0.5 * (ixx.PointA2 + ixx.PointB2)));
                        pA.Add(new GH_Number(ixx.OverlapA.T1));
                        pB.Add(new GH_Number(ixx.OverlapB.T1));
                    }
                }


                return (ptx.ToArray(), pA.ToArray(), pB.ToArray(), Array(new GH_Boolean(true)));
            }
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Curve> curveA)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Curve> curveB)) return;

            var (pts, parA, parB, ix) = ZipGraft2x4(curveA, curveB, CCX, CheckError);

            DA.SetDataTree(0, pts);
            DA.SetDataTree(1, parA);
            DA.SetDataTree(2, parB);
            DA.SetDataTree(3, ix);
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
            get { return new Guid("A9302B5A-E6B7-426D-A732-14F2AB066271"); }
        }
    }
}