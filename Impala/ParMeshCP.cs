using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;

namespace Impala
{
    public class ParMeshCP : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParMeshCP class.
        /// </summary>
        public ParMeshCP()
          : base("ParMeshCP", "ParMeshCP",
              "Closest point on a mesh to a sample point",
              "Impala", "Physical")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Points to test from", GH_ParamAccess.tree);
            pManager.AddMeshParameter("Mesh", "M", "Meshes to project to", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Threshold", "T", "Maximum allowed point distance (as Item)", GH_ParamAccess.tree, Double.MaxValue);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Closest Points on mesh", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Face Index", "I", "Index of closest face", GH_ParamAccess.tree);
            pManager.AddGenericParameter("Mesh Parameter", "P", "Mesh Face parameter at closest point", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Projected", "X", "Was the point in threshold?", GH_ParamAccess.tree);
           
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Structure<GH_Mesh> MeshTree;
            GH_Structure<GH_Point> pointTree;
            GH_Structure<GH_Number> tolTree;

            if (!DA.GetDataTree(0, out pointTree)) return;
            if (!DA.GetDataTree(1, out MeshTree)) return;
            if (!DA.GetDataTree(2, out tolTree)) return;

            if (MeshTree.IsEmpty || pointTree.IsEmpty)
            {
                return;
            }


            // Find structure with highest dimensionality. This preserves path structure.
            List<GH_Path> pList = new List<GH_Path>(); //Our base output path list
            int pdim = pointTree.get_Path(pointTree.LongestPathIndex()).Length;
            int cdim = MeshTree.get_Path(MeshTree.LongestPathIndex()).Length;
            int tdim = tolTree.get_Path(tolTree.LongestPathIndex()).Length;
            if (pdim >= cdim && pdim >= tdim) pList.AddRange(pointTree.Paths);
            else if (cdim >= pdim && cdim >= tdim) pList.AddRange(MeshTree.Paths);
            else pList.AddRange(tolTree.Paths);


            var resultTree = new GH_Structure<GH_Point>();
            var indexTree = new GH_Structure<GH_Integer>();
            var projectTree = new GH_Structure<GH_Boolean>();

            int maxLen = Math.Max(pointTree.PathCount, Math.Max(MeshTree.PathCount, tolTree.PathCount));

            //This is where our parallelism comes in handy! 
            Parallel.For(0, maxLen, (i) =>
            {
                //We replicate GH's 'last item' logic when item list lengths don't match up.
                int ctidx = Math.Min(i, MeshTree.PathCount - 1);
                int ptidx = Math.Min(i, pointTree.PathCount - 1);
                int ttidx = Math.Min(i, tolTree.PathCount - 1);

                var MeshBranch = MeshTree[MeshTree.get_Path(ctidx)];
                var pointBranch = pointTree[pointTree.get_Path(ptidx)];
                var tolBranch = tolTree[tolTree.get_Path(ttidx)];

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

                if (!(MeshBranch.Count == 0 || pointBranch.Count == 0))
                {

                    int len = Math.Max(MeshBranch.Count, Math.Max(pointBranch.Count, tolBranch.Count));
                    GH_Point[] foundResults = new GH_Point[len];
                    GH_Integer[] foundFaces = new GH_Integer[len];
                    GH_Boolean[] projected = new GH_Boolean[len];

                    Parallel.For(0, len, (j) =>
                    {
                        int cidx = Math.Min(j, MeshBranch.Count - 1);
                        int pidx = Math.Min(j, pointBranch.Count - 1);
                        int tidx = Math.Min(j, tolBranch.Count - 1);

                        Mesh msh = MeshBranch[cidx].Value;
                        Point3d pt = pointBranch[pidx].Value;
                        double tol = tolBranch[tidx].Value;

                        if (tol >= Rhino.RhinoMath.ZeroTolerance)
                        {
                            //This is the only part of this code that deals with geometry
                            int index = msh.ClosestPoint(pt, out Point3d onMesh, tol);

                            if (index != -1)
                            {
                                //Actually, this too, but that's it
                                foundFaces[j] = new GH_Integer(index);
                                foundResults[j] = new GH_Point(onMesh);
                                projected[j] = new GH_Boolean(true);
                            }
                            else
                            {
                                foundFaces[j] = null;
                                foundResults[j] = null;
                                projected[j] = new GH_Boolean(false);
                            }
                        }
                        else
                        {
                            foundFaces[j] = null;
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
                    lock (indexTree)
                    {
                        indexTree.AppendRange(foundFaces, path);
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
                    lock (indexTree)
                    {
                        indexTree.EnsurePath(path);
                    }
                    lock (projectTree)
                    {
                        projectTree.EnsurePath(path);
                    }
                }
            });

            DA.SetDataTree(0, resultTree);
            DA.SetDataTree(1, indexTree);
            //DA.SetDataTree(2, paramTree);
            DA.SetDataTree(3, projectTree);
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
            get { return new Guid("fbfc1bea-e875-4996-973c-cb94865796d6"); }
        }
    }
}