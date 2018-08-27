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
using static Impala.Generic;
using static Impala.Utilities;

namespace Impala
{
    public class ParVisualCenter : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Visual Center class.
        /// </summary>
        public ParVisualCenter()
          : base("ParVisualCenter", "ParVisCen",
              "Find the visual center of a closed curve.",
              "Impala", "Extensions")
        {
            var error = new Error<GH_Curve>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<GH_Curve>(error);
        }

        public ErrorChecker<GH_Curve> CheckError;
        static Func<GH_Curve, bool> NullCheck = a => a != null;


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "C", "Curve to center", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Center point", GH_ParamAccess.tree);
        }

        //Curve must be closed
        public static GH_Point VisCen(GH_Curve ghcurve)
        {
            var c = ghcurve.Value;
            var tt = DocumentTolerance();

            Polyline plx;
            if (!c.TryGetPolyline(out plx))
                c.ToPolyline(100, 1, DocumentAngleTolerance(), tt, 0, tt, 0, 0, true).TryGetPolyline(out plx);

            (Point3d, double)[] results = new (Point3d, double)[plx.Count];
            Parallel.For(0, plx.Count, i =>
            {
                double dst = double.MaxValue;
                Point3d bPt = Point3d.Unset;
                for (int j = 0; j < plx.Count; j++)
                {
                    if (i == j) continue;
                    Point3d testPt = 0.5 * (plx[i] + plx[j]);
                    if (c.Contains(testPt) != PointContainment.Inside) continue;
                    if (!c.ClosestPoint(testPt, out double t)) continue;

                    var dx = testPt.DistanceTo(c.PointAt(t));
                    if (dx < dst)
                    {
                        dst = dx;
                        bPt = testPt;
                    }
                }
                results[i] = (bPt, dst);
            });

            Point3d bestPt = Point3d.Unset;
            double dist = double.MaxValue;
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].Item2 < dist)
                {
                    dist = results[i].Item2;
                    bestPt = results[i].Item1;                
                }
            }
            return new GH_Point(bestPt);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Curve> curveTree)) return;

            var pts = Zip1x1(curveTree, VisCen, CheckError);

            DA.SetDataTree(0, pts);
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
                return Impala.Properties.Resources.__0005_VisCen;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("F148114E-45E8-4097-85F4-B7D6CC751355"); }
        }
    }
}