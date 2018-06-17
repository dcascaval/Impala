using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Impala
{
    public class ParCurveCP : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public ParCurveCP()
          : base("Curve Closest Point (Parallel)", "parCurveCP",
              "Closest Point on a curve to a sample, within a tolerance.",
              "Impala", "Physical")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Point to sample from", GH_ParamAccess.tree);
            pManager.AddCurveParameter("Curve", "C", "Curve to test", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Tolerance", "D", "Maximum testing distance", GH_ParamAccess.tree, Double.MaxValue);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Closest point on curve", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Parameter", "t", "Parameter on curve", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Projected", "X", "Was the point moved?", GH_ParamAccess.tree);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Structure<GH_Curve> curveTree;
            GH_Structure<GH_Point> pointTree;
            GH_Structure<GH_Number> tolTree;

            if (!DA.GetDataTree(0, out pointTree)) return;
            if (!DA.GetDataTree(1, out curveTree)) return;
            if (!DA.GetDataTree(2, out tolTree)) return;

            if (curveTree.IsEmpty || pointTree.IsEmpty) 
            {
                return;
            }

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
            GH_Structure<GH_Boolean> projectTree = new GH_Structure<GH_Boolean>();

            int maxLen = Math.Max(pointTree.PathCount, Math.Max(curveTree.PathCount, tolTree.PathCount));

            //This is where our parallelism comes in handy! 
            Parallel.For(0, maxLen, (i) =>
            {
                //We replicate GH's 'last item' logic when item list lengths don't match up.
                int ctidx = Math.Min(i, curveTree.PathCount - 1);
                int ptidx = Math.Min(i, pointTree.PathCount - 1);
                int ttidx = Math.Min(i, tolTree.PathCount - 1);

                var curveBranch = curveTree[curveTree.get_Path(ctidx)];
                var pointBranch = pointTree[pointTree.get_Path(ptidx)];
                var tolBranch = tolTree[tolTree.get_Path(ttidx)];

                GH_Path path = new GH_Path();
                if (i < pList.Count)
                {
                    path = new GH_Path(pList[i]);
                }
                else
                {
                    path = new GH_Path(pList[pList.Count -1]);
                    path = path.Increment(path.Length - 1, (i - pList.Count) + 1);
                }

                if (!(curveBranch.Count == 0 || pointBranch.Count == 0))
                {

                    int len = Math.Max(curveBranch.Count, Math.Max(pointBranch.Count, tolBranch.Count));
                    GH_Point[] foundResults = new GH_Point[len];
                    GH_Number[] foundParams = new GH_Number[len];
                    GH_Boolean[] projected = new GH_Boolean[len];

                    Parallel.For(0, len, (j) =>
                     {
                         int cidx = Math.Min(j, curveBranch.Count - 1);
                         int pidx = Math.Min(j, pointBranch.Count - 1);
                         int tidx = Math.Min(j, tolBranch.Count - 1);

                         Curve crv = curveBranch[cidx].Value;
                         Point3d pt = pointBranch[pidx].Value;
                         double tol = tolBranch[tidx].Value;
                         //This is the only part of this code that deals with geometry
                         bool param = crv.ClosestPoint(pt, out double curveParam, tol);

                         if (param)
                         {
                             //Actually, this too, but that's it
                             Point3d closePoint = crv.PointAt(curveParam);
                             foundParams[j] = new GH_Number(curveParam);
                             foundResults[j] = new GH_Point(closePoint);
                             projected[j] = new GH_Boolean(true);
                         }
                         else
                         {
                             foundParams[j] = null;
                             foundResults[j] = null;
                             projected[j] = new GH_Boolean(false);
                         }
                     });

                    // As opposed to allocating a nested array, we just access the data structure.
                    // This might result in significant contention with a high number of short branches,
                    // but profiling indicates that the cost of the added copy exceeds contention for branches
                    // of around five items or larger.
                    lock (resultTree)
                    {
                        resultTree.AppendRange(foundResults, path);
                    }
                    lock (paramTree)
                    {
                        paramTree.AppendRange(foundParams, path);
                    }
                    lock (projectTree)
                    {
                        projectTree.AppendRange(projected, path);
                    }
                }
                else
                {
                    //We maintain empty paths in the tree.
                    lock (resultTree)
                    {
                        resultTree.EnsurePath(path);
                    }
                    lock (paramTree)
                    {
                        paramTree.EnsurePath(path);
                    }
                    lock (projectTree)
                    {
                        projectTree.EnsurePath(path);
                    }
                }
            });

            DA.SetDataTree(0, resultTree);
            DA.SetDataTree(1, paramTree);
            DA.SetDataTree(2, projectTree);
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
            get { return new Guid("36712bfc-7336-491e-9e4c-e3a1455bb856"); }
        }
    }
}