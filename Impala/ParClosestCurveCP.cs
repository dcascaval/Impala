using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Generic;
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

            return;
            // Find structure with highest dimensionality. This preserves path structure.
            List<GH_Path> pList = new List<GH_Path>(); //Our base output path list
            int pdim = pointTree.get_Path(pointTree.LongestPathIndex()).Length;
            int cdim = curveTree.get_Path(curveTree.LongestPathIndex()).Length;
            int tdim = tolTree.get_Path(tolTree.LongestPathIndex()).Length;
            if (pdim >= cdim && pdim >= tdim) pList.AddRange(pointTree.Paths);
            else if (cdim >= pdim && cdim >= tdim) pList.AddRange(curveTree.Paths);
            else pList.AddRange(tolTree.Paths);

            GH_Structure<GH_Point> resultTree = new GH_Structure<GH_Point>();
            GH_Structure<GH_Number> paramTree = new GH_Structure<GH_Number>();
            GH_Structure<GH_Integer> indexTree = new GH_Structure<GH_Integer>(); 
            GH_Structure<GH_Number> distanceTree = new GH_Structure<GH_Number>();

            int maxLen = Math.Max(pointTree.PathCount, Math.Max(curveTree.PathCount, tolTree.PathCount));

            Parallel.For(0, maxLen, i =>
            {
                //We replicate GH's 'last item' logic when item list lengths don't match up.
                int ctidx = Math.Min(i, curveTree.PathCount - 1);
                int ptidx = Math.Min(i, pointTree.PathCount - 1);
                int ttidx = Math.Min(i, tolTree.PathCount - 1);

                var curveBranch = curveTree[curveTree.get_Path(ctidx)];
                var pointBranch = pointTree[pointTree.get_Path(ptidx)];
                var tolBranch = tolTree[tolTree.get_Path(ttidx)];

                //Calculate appropriate preserved path.
                GH_Path path = new GH_Path();
                if (i < pList.Count)
                {
                    path = new GH_Path(pList[i]);
                }
                else
                {
                    path = new GH_Path(pList[pList.Count - 1]);
                    path = path.Increment(path.Length - 1, (i - pList.Count) + 1);
                }

                if (!(curveBranch.Count == 0 || pointBranch.Count == 0))
                {

                    int len = Math.Max(tolBranch.Count, pointBranch.Count);
                    GH_Point[] ptList = new GH_Point[len];
                    GH_Number[] paramList = new GH_Number[len];
                    GH_Integer[] idxList = new GH_Integer[len];
                    GH_Number[] distList = new GH_Number[len];

                    Parallel.For(0, len, j =>
                    {
                        int pidx = Math.Min(j, pointBranch.Count - 1);
                        int tidx = Math.Min(j, tolBranch.Count - 1);

                        Point3d pt = pointBranch[pidx].Value;
                        double tol = tolBranch[tidx].Value;

                        bool found = false;
                        double bestDistance = Double.MaxValue;
                        double bestParameter = 0;
                        int bestCurveIndex = 0;
                        Point3d bestPoint = new Point3d();

                        //Look through curveLists sequentially - this is k operations, and is likely to be faster
                        //than a parallel alternative for any reasonable amount of K relative to N points.
                        for (int k = 0; k < curveBranch.Count; k++)
                        {
                            Curve crv = curveBranch[k].Value;
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
                            ptList[j] = new GH_Point(bestPoint);
                            paramList[j] = new GH_Number(bestParameter);
                            idxList[j] = new GH_Integer(bestCurveIndex);
                            distList[j] = new GH_Number(bestDistance);
                        }
                        else
                        {
                            ptList[j] = null;
                            paramList[j] = null;
                            idxList[j] = null;
                            distList[j] = null;
                        }
                    });

                    lock (resultTree)
                    {
                        resultTree.AppendRange(ptList, path);
                    }
                    lock (paramTree)
                    {
                        paramTree.AppendRange(paramList, path);
                    }
                    lock (indexTree)
                    {
                        indexTree.AppendRange(idxList, path);
                    }
                    lock (distanceTree)
                    {
                        distanceTree.AppendRange(distList, path);
                    }
                }
                else
                {
                    lock (resultTree)
                    {
                        resultTree.EnsurePath(path);
                    }
                    lock (paramTree)
                    {
                        paramTree.EnsurePath(path);
                    }
                    lock (indexTree)
                    {
                        indexTree.EnsurePath(path);
                    }
                    lock (distanceTree)
                    {
                        distanceTree.EnsurePath(path);
                    }
                }
            });

            DA.SetDataTree(0, resultTree);
            DA.SetDataTree(1, paramTree);
            DA.SetDataTree(2, indexTree);
            DA.SetDataList(3, distanceTree);

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