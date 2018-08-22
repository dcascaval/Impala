using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Generated;
using static Impala.Errors;

namespace Impala
{
    public class ParClosestCurveCP : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParClosestCurveCP class.
        /// </summary>
        public ParClosestCurveCP()
          : base("ParClosestCurveCP", "parCCCP",
              "Finds the closest point on a curve in a set of curves.",
              "Impala", "Physical")
        {
            var error = new Error<(GH_Point, GH_Number, List<GH_Curve>)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Point, GH_Number, List<GH_Curve>)>(error);
        }

        public ErrorChecker<(GH_Point, GH_Number, List<GH_Curve>)> CheckError;
        static Func<(GH_Point, GH_Number, List<GH_Curve>), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3.Count > 0);

        

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Point to sample from", GH_ParamAccess.tree);
            pManager.AddCurveParameter("Curves", "C", "Set of curves to search", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Threshold", "T", "Maximum distance to search", GH_ParamAccess.tree, Double.MaxValue);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Points on curve closest to the base point.", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Parameters", "t", "Parameter on closest curve domain of closest point.", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Index", "I", "Index of Closest Curve", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Distance", "D", "Distance", GH_ParamAccess.tree);
        }

        static (GH_Point, GH_Number, GH_Integer, GH_Number) CCCP(GH_Point ghpt, GH_Number ghtol, List<GH_Curve> curves)
        {
            Point3d pt = ghpt.Value;
            double tol = ghtol.Value;

            bool found = false;
            double bestDistance = Double.MaxValue;
            double bestParameter = 0;
            int bestCurveIndex = 0;
            Point3d bestPoint = new Point3d();

            //Look through curveLists sequentially - this is k operations, and is likely to be faster
            //than a parallel alternative for any reasonable amount of K relative to N points.
            for (int k = 0; k < curves.Count; k++)
            {
                if (curves[k] == null) continue;
                var crv = curves[k].Value;
                bool project = crv.ClosestPoint(pt, out double curveParam, tol);
                if (project)
                {
                    Point3d projectedPt = crv.PointAt(curveParam);
                    double distance = pt.DistanceTo(projectedPt);
                    if (distance < bestDistance)
                    {
                        found = true;
                        bestDistance = distance;
                        bestParameter = curveParam;
                        bestCurveIndex = k;
                        bestPoint = projectedPt;
                    }
                }
            }

            if (found)
            {
                return (new GH_Point(bestPoint), new GH_Number(bestParameter), new GH_Integer(bestCurveIndex), new GH_Number(bestDistance));
            }
            else
            {
                return (null, null, null, null);
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

            if (curveTree.IsEmpty || pointTree.IsEmpty)
            {
                return;
            }

            var (points,parameters,idx,dist) =  Zip2Red1x4(pointTree, tolTree, curveTree, CCCP, CheckError);
            DA.SetDataTree(0, points);
            DA.SetDataTree(1, parameters);
            DA.SetDataTree(2, idx);
            DA.SetDataTree(3, dist);
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
            get { return new Guid("a0ebb81a-b29b-452f-9863-856a0a0d1120"); }
        }
    }
}