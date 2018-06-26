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

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Points to search from", GH_ParamAccess.tree);
            pManager.AddPointParameter("Cloud", "C", "Cloud of points to search", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Number", "K", "Number of closest points to fetch", GH_ParamAccess.tree, 1);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Closest point in the cloud", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Indices", "I", "Cloud index of point", GH_ParamAccess.tree);
        }


        List<GH_Path> ExtractPathList (List<GH_Structure<IGH_Goo>> structList)
        {
            List<GH_Path> pList = new List<GH_Path>();
            int longestPathLen = 0;
            foreach (GH_Structure<IGH_Goo> str in structList)
            {
                if (str.get_Path(str.LongestPathIndex()).Length > longestPathLen)
                {
                    pList = str.Paths as List<GH_Path>;
                }
            }
            return pList;
        }

        private IGH_Goo GooConvert(IGH_Goo obj)
        {
            return obj;
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Structure<GH_Point> sampleTree;
            GH_Structure<GH_Point> cloudTree;
            GH_Structure<GH_Integer> kTree;

            if (!DA.GetDataTree(0, out sampleTree)) return;
            if (!DA.GetDataTree(1, out cloudTree)) return;
            if (!DA.GetDataTree(2, out kTree)) return;

            /* ExtractPathList(new List<GH_Structure<IGH_Goo>> { sampleTree.DuplicateCast(GooConvert),
                                                                                    cloudTree.DuplicateCast(GooConvert),
                                                                                    kTree.DuplicateCast(GooConvert) });*/

            List<GH_Path> pList = new List<GH_Path>(); //Our base output path list
            int sdim = sampleTree.get_Path(sampleTree.LongestPathIndex()).Length;
            int cdim = cloudTree.get_Path(cloudTree.LongestPathIndex()).Length;
            int kdim = kTree.get_Path(kTree.LongestPathIndex()).Length;
            if (sdim >= cdim && sdim >= kdim) pList.AddRange(sampleTree.Paths);
            else if (cdim >= sdim && cdim >= kdim) pList.AddRange(cloudTree.Paths);
            else pList.AddRange(kTree.Paths); 
            

            GH_Structure<GH_Point> resultTree = new GH_Structure<GH_Point>();
            GH_Structure<GH_Integer> idxTree = new GH_Structure<GH_Integer>();

            int maxLen = Math.Max(sampleTree.PathCount,Math.Max(cloudTree.PathCount,kTree.PathCount));

            KdTree<double, int> lastCloudTree = new KdTree<double, int>(3, new DoubleMath()); //Precalc this, it'll be reused.
            var lastCloud = cloudTree[cloudTree.get_Path(cloudTree.PathCount - 1)];
            for (int j = 0; j < lastCloud.Count; j++)
            {
                lastCloudTree.Add(PtToArray(lastCloud[j]), j);
            }

            Parallel.For(0, maxLen, i =>
            {
                //We replicate GH's 'last item' logic when item list lengths don't match up.
                int stidx = Math.Min(i, sampleTree.PathCount - 1);
                int ctidx = Math.Min(i, cloudTree.PathCount - 1);
                int ktidx = Math.Min(i, kTree.PathCount - 1);

                var sampleBranch = sampleTree[sampleTree.get_Path(stidx)];
                var cloudBranch = cloudTree[cloudTree.get_Path(ctidx)];
                var kBranch = kTree[kTree.get_Path(ktidx)];

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

                int len = Math.Max(sampleBranch.Count, kBranch.Count);
                if (sampleBranch.Count != 0 && kBranch.Count != 0)
                {
                    KdTree<double, int> tree;
                    if (ctidx == cloudTree.PathCount - 1)
                    {
                        tree = lastCloudTree;
                    }
                    else
                    {
                        tree = new KdTree<double, int>(3, new DoubleMath());
                        for (int j = 0; j < cloudBranch.Count; j++)
                        {
                            tree.Add(PtToArray(cloudBranch[j]), j);
                        }
                    }

                    List<GH_Integer>[] indexList = new List<GH_Integer>[len];
                    List<GH_Point>[] pointList = new List<GH_Point>[len];

                    Parallel.For(0, len, j =>
                    {
                        int pidx = Math.Min(j, sampleBranch.Count - 1);
                        int kidx = Math.Min(j, kBranch.Count - 1);
                        if (ErrorCheck(sampleBranch[pidx], kBranch[kidx], cloudBranch.Count))
                        {
                            KdTreeNode<double, int>[] results = tree.GetNearestNeighbours(PtToArray(sampleBranch[pidx]), kBranch[kidx].Value);
                            indexList[j] = (from node in results select new GH_Integer(node.Value)).ToList();
                            pointList[j] = (from idx in indexList[j] select new GH_Point(cloudBranch[idx.Value])).ToList();
                        }
                        else
                        {
                            indexList[j] = null;
                            pointList[j] = null;
                        }
                    });

                    lock (resultTree)  //overly contentious?
                    {
                        for (int j = 0; j < len; j++)
                        {
                            if (pointList[j] != null)
                            {
                                resultTree.AppendRange(pointList[j], path.AppendElement(j));
                            }
                            else
                            {
                                resultTree.EnsurePath(path.AppendElement(j));
                            }
                        }
                    }
                    lock (idxTree)
                    {
                        for (int j = 0; j < len; j++) {
                            if (indexList[j] != null)
                            {
                                idxTree.AppendRange(indexList[j], path.AppendElement(j));
                            }
                            else
                            {
                                idxTree.EnsurePath(path.AppendElement(j));
                            }
                        }
                    }

                }
                else
                {
                    lock (resultTree)
                    {
                        for (int j = 0; j < len; j++)
                            resultTree.EnsurePath(path.AppendElement(j));
                    }
                    lock (idxTree)
                    {
                        for (int j = 0; j < len; j++)
                            idxTree.EnsurePath(path.AppendElement(j));
                    }
                }

            });


            DA.SetDataTree(0, resultTree);
            DA.SetDataTree(1, idxTree);
        }

        bool ErrorCheck(GH_Point point, GH_Integer index, int count)
        {
            if (point == null || index == null)
            {
                return false;
            }
            if (index.Value < 0 || index.Value > count)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Points out of range");
                return false;
            }
            return true;
        }

        double[] PtToArray(GH_Point ghpt)
        {
            Point3d pt = ghpt.Value;
            return new double[] { pt.X, pt.Y, pt.Z };
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