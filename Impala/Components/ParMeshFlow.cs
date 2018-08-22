using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Impala
{
    public class ParMeshFlow : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParMeshFlow class.
        /// </summary>
        public ParMeshFlow()
          : base("ParMeshFlow", "parMeshFlow",
              "Find flow lines along a mesh according to a gravitational vector",
              "Impala", "Physical")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component. Uses list-only parallelism, on the assumption that
        /// the majority of uses will involve many points to a small number of meshes. 
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Start Points", "P", "Flow start points", GH_ParamAccess.list);
            pManager.AddMeshParameter("Mesh", "M", "Mesh to flow along", GH_ParamAccess.list);
            pManager.AddNumberParameter("Tolerance", "T", "Sampling distance", GH_ParamAccess.list, 0.1);
            pManager.AddIntegerParameter("Maximum Steps", "S", "Maximum number of sampling calculations", GH_ParamAccess.list, 100);
            pManager.AddVectorParameter("Direction", "X", "Flow direction.", GH_ParamAccess.list,-Vector3d.ZAxis);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("Curves", "C", "Simulated flow curves", GH_ParamAccess.list);
            pManager.AddNumberParameter("Lengths", "L", "Lengths of flow curves", GH_ParamAccess.list);
            pManager.AddIntegerParameter("Steps", "S", "Number of steps used", GH_ParamAccess.list);
        }

        /// <summary>
        /// This method works on list-inputs and uses a special-case caching optimisation. As a result the looping logic is explicitly defined.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var ptList = new List<GH_Point>();
            var meshList = new List<GH_Mesh>();
            var tolList = new List<GH_Number>();
            var stepList = new List<GH_Integer>();
            var flowDirList = new List<GH_Vector>();

            if (!DA.GetDataList("Start Points", ptList)) return;
            if (!DA.GetDataList("Mesh", meshList)) return;
            if (!DA.GetDataList("Tolerance", tolList)) return;
            if (!DA.GetDataList("Maximum Steps", stepList)) return;
            if (!DA.GetDataList("Direction", flowDirList)) return;

            int len = Math.Max(Math.Max(Math.Max(ptList.Count, meshList.Count), Math.Max(tolList.Count, stepList.Count)),flowDirList.Count);

            GH_Curve[] polyFlows = new GH_Curve[len];
            GH_Number[] polyLength = new GH_Number[len];
            GH_Integer[] polySteps = new GH_Integer[len];
            Mesh[,] tMeshCache = new Mesh[meshList.Count,flowDirList.Count];

            if (ptList.Count == 0 || meshList.Count == 0 || tolList.Count == 0 || flowDirList.Count == 0 || stepList.Count == 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Empty List! Skipping branch.");
                DA.SetDataList("Curves", polyFlows); //Add empty nulls to preserve structure
                DA.SetDataList("Lengths", polyLength);
                DA.SetDataList("Steps", polySteps);
                return;
            }
            //Todo: Add special case for Many Pts -> 1 Mesh. This allows us to reuse the mesh transform w/o cache.

            if (ptList.Count > 1 && meshList.Count == 1 && tolList.Count == 1 && flowDirList.Count == 1 && stepList.Count <= ptList.Count)
            {
                if (MeshTolVecErrorCheck(meshList[0], tolList[0], flowDirList[0]))
                {
                    Vector3d flowDir = flowDirList[0].Value;
                    Mesh mesh = meshList[0].Value;
                    double tol = tolList[0].Value;

                    Transform xform = GetReorientation(flowDir);
                    xform.TryGetInverse(out Transform inverseXform);
                    Mesh tMesh = mesh.DuplicateMesh();
                    tMesh.Transform(xform);

                    Parallel.For(0, ptList.Count, i =>
                    {
                        int sidx = Math.Min(i, stepList.Count - 1);
                        if (PointStepErrorCheck(ptList[i], stepList[sidx]))
                        {
                            Point3d pt = ptList[i].Value; //make accessible to steplist?
                            pt.Transform(xform);
                            int steps = stepList[sidx].Value;

                            var polyList = MeshFlow(pt, tMesh, tol, steps);
                            var poly = new PolylineCurve(polyList);
                            poly.Transform(inverseXform); //why is this not
                            polyFlows[i] = new GH_Curve(poly);
                            polyLength[i] = new GH_Number(poly.GetLength());
                            polySteps[i] = new GH_Integer(polyList.Count);
                        }
                    });
                }
                ///Do special case optimisation here -- no copies!
            }
            else
            {
                Parallel.For(0, len, i =>
                {
                    //Boilerplate indexing and error check
                    int pidx = Math.Min(i, ptList.Count - 1);
                    int midx = Math.Min(i, meshList.Count - 1);
                    int tidx = Math.Min(i, tolList.Count - 1);
                    int sidx = Math.Min(i, stepList.Count - 1);
                    int fidx = Math.Min(i, flowDirList.Count - 1);

                    if (FullErrorCheck(ptList[pidx], meshList[midx], tolList[tidx], stepList[sidx], flowDirList[fidx]))
                    {
                        Point3d pt = ptList[pidx].Value;
                        Mesh mesh = meshList[midx].Value;
                        double tol = tolList[tidx].Value;
                        int steps = stepList[sidx].Value;
                        Vector3d flowDir = flowDirList[fidx].Value;

                        Transform xform = GetReorientation(flowDir);
                        xform.TryGetInverse(out Transform inverseXform); //rotations are always invertible

                        Mesh tMesh = new Mesh();
                        bool tryGetMesh = false;
                        lock (tMeshCache) {  //see if we haven't already done this one
                            if (tMeshCache[midx, fidx] != null)
                            {
                                tMesh = tMeshCache[midx, fidx];
                                tryGetMesh = true;
                            }
                         }
                        if (!tryGetMesh) 
                        {
                            tMesh = mesh.DuplicateMesh();
                            tMesh.Transform(xform);
                            lock (tMeshCache) //looks like we haven't, let's put it in
                            {
                                tMeshCache[midx, fidx] = tMesh;
                            }
                        }

                        Point3d tPt = new Point3d(pt);
                        tPt.Transform(xform);

                        List<Point3d> polyList = MeshFlow(tPt, tMesh, tol, steps);
                        PolylineCurve poly = new PolylineCurve(polyList);
                        poly.Transform(inverseXform);
                        polyFlows[i] = new GH_Curve(poly);
                        polyLength[i] = new GH_Number(poly.GetLength());
                        polySteps[i] = new GH_Integer(polyList.Count);
                    }
                });
            }

            //Finish up solveInstance by actually outputting geometry!
            DA.SetDataList("Curves", polyFlows);
            DA.SetDataList("Lengths", polyLength);
            DA.SetDataList("Steps", polySteps);
        }

        //Todo: add velocity and acceleration to this method - accel controls how much it can continue going up. Keep track of current orientation vec.
        List<Point3d> MeshFlow(Point3d pt, Mesh mesh, double tol, int steps)
        {
            List<Point3d> flowList = new List<Point3d>();
            Plane flowPlane = new Plane(pt, Vector3d.ZAxis);

            while (flowList.Count < steps)
            {
                mesh.ClosestPoint(flowPlane.Origin, out Point3d mPoint, out Vector3d pVec, Double.MaxValue);
                flowPlane = new Plane(mPoint, pVec);

                if (flowList.Count > 1)
                {
                    if (mPoint.DistanceTo(flowList[flowList.Count - 1]) < tol / 100.0) break; //too close. no movement.
                    if (mPoint.Z > flowList[flowList.Count - 1].Z + tol / 10.0) break; //going up! no movement.
                    if (mPoint.DistanceTo(flowList[flowList.Count - 1]) > tol * 2) break; //overshot like crazy!
                }

                flowList.Add(mPoint);
                double angle = Vector3d.VectorAngle(flowPlane.XAxis, -Vector3d.ZAxis, flowPlane);
                flowPlane.Rotate(angle, flowPlane.ZAxis);
                flowPlane.Translate(flowPlane.XAxis * tol);
            }

            return flowList;
        }

        //Get the transformation by rotating the entire thing around the origin. Location doesn't matter since we'll be reorienting.
        Transform GetReorientation(Vector3d dest)
        {
            if (dest.EpsilonEquals(-Vector3d.ZAxis, 1e-6))
            {
                return Transform.Identity;
            }
            else {
                return Transform.Rotation(dest, -Vector3d.ZAxis, Point3d.Origin);
            }
        }

        /** Error Checking Area - Provide as many informative runtime messages as possible. */
        bool FullErrorCheck(GH_Point pt, GH_Mesh msh, GH_Number tol, GH_Integer step, GH_Vector vec)
        {
            bool flag = true;
            flag = flag && MeshTolVecErrorCheck(msh, tol, vec);
            flag = flag && PointStepErrorCheck(pt, step);
            return flag;
        }

        bool MeshTolVecErrorCheck(GH_Mesh msh, GH_Number tol, GH_Vector vec)
        {
            bool flag = true;
            if (msh == null || tol == null || vec == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Null Input! Skipping branch.");
                return false;
            }
            if (!msh.Value.IsValid || !(msh.Value.Vertices.Count > 2))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid mesh! Skipping branch.");
                flag = false;
            }
            if (tol.Value < Rhino.RhinoMath.ZeroTolerance)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Tolerance too small! Skipping branch.");
                flag = false;
            }
            if (vec.Value.IsZero)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Cannot flow with zero-length vector! Skipping branch.");
                flag = false;
            }
            return flag;
        }

  
        bool PointStepErrorCheck(GH_Point pt, GH_Integer step)
        {
            bool flag = true; 
            if (pt == null || step == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Null Input! Skipping branch.");
                return false;
            }
            if (step.Value < 2)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Too few steps! Skipping branch.");
                flag = false;
            }
            return flag;
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
            get { return new Guid("149ecaeb-f1db-4d5d-9de2-911ab76e2557"); }
        }
    }
}
 