using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using KdTree;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;
using KdTree.Math;

using static Impala.Generic;
using static Impala.Generated;
using static Impala.Errors;
using static Impala.Utilities;

namespace Impala
{
    public class ParPointCP : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParPointCP class.
        /// </summary>
        public ParPointCP()
          : base("ParPointCP", "ParPointCP",
              "Find the k closest points in a set to a sample point",
              "Impala", "Physical")
        {
        }


        public ErrorChecker<(GH_Point, GH_Integer, GH_Integer)> CheckError;
        static Func<(GH_Point, GH_Integer, GH_Integer), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null);

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Points to search from", GH_ParamAccess.tree);
            pManager.AddPointParameter("Cloud", "C", "Cloud of points to search", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Number", "K", "Number of closest points to fetch", GH_ParamAccess.tree, 1);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Closest point in the cloud", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Indices", "I", "Cloud index of point", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Compute the closest point and index from the tree using our constructed index.
        /// </summary>
        (GH_Point[],GH_Integer[]) FindClosePt(GH_Point gpt, GH_Integer gcount, GH_Integer gidx)
        {
            var cloud = pointCloudList[gidx.Value];

            KdTreeNode<double, int>[] results = cloud.GetNearestNeighbours(PtToArray(gpt), gcount.Value);
            var indexList = (from node in results select new GH_Integer(node.Value)).ToArray();
            var pointList = (from node in results select new GH_Point(PtFromArray(node.Point))).ToArray();

            return (pointList, indexList);
        }

        private List<KdTree<double, int>> pointCloudList;

        /// <summary>
        /// Solve by caching a pointcloudlist and creating a tree of indices to look up from the passed closure.
        /// This allows us to use Impala's framework while maintaining the cache benefits of creating each KDTree only once.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Point> sampleTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Point> cloudTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Integer> kTree)) return;

            var idxTree = GraftList(IRange(0, cloudTree.Branches.Count).Select(i => new GH_Integer(i)));
            //Cache the pointclouds
            var ptlists = cloudTree.Branches.Select(pts => pts.Where(pt => pt != null).Select(pt => pt.Value).ToList()).ToList();
            var cloudList = new List<KdTree<double, int>>();
            for (int i = 0; i < ptlists.Count; i++)
            {
                var sublist = ptlists[i];
                var cloud = new KdTree<double, int>(3, new DoubleMath());
                sublist.DoEach((pt, j) => cloud.Add(PtToArray(pt), j));
                cloudList.Add(cloud);
            }
            pointCloudList = cloudList;


            var nullerror = new Error<(GH_Point, GH_Integer, GH_Integer)>(NullCheck, NullHandle, this);
            Func<(GH_Point, GH_Integer, GH_Integer), bool> kCheck = a => (pointCloudList[a.Item3.Value].Count >= a.Item2.Value);
            Action<GH_Component> kHandle = comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Points out of range");
            var kerror = new Error<(GH_Point, GH_Integer, GH_Integer)>(kCheck, kHandle, this);
            var CheckError = new ErrorChecker<(GH_Point, GH_Integer, GH_Integer)>(nullerror, kerror);

            var (respt, residx) = Zip3xGraft2(sampleTree, kTree, idxTree, FindClosePt, CheckError);

            DA.SetDataTree(0, respt);
            DA.SetDataTree(1, residx);
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
            get { return new Guid("58c9439f-bd59-4169-973a-c07398b022a1"); }
        }
    }
}