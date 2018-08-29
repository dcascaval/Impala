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
    /// <summary>
    /// Raycast around a circular arc with additional samples at important mesh areas
    /// </summary>
    public class ParIso2D : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParIsoVist2D Component.
        /// </summary>
        public ParIso2D()
          : base("ParIsoVist2D", "ParIso2D",
              "Shoot a ring of rays at a set of obstacles.",
              "Impala", "Intersection")
        {
            var error = new Error<(GH_Point,GH_Plane,GH_Integer,GH_Number,GH_Interval,List<GH_Mesh>)>(NullCheck, NullHandle, this);
            var sampleError = new Error<(GH_Point, GH_Plane, GH_Integer, GH_Number, GH_Interval, List<GH_Mesh>)>(CheckSamples, SampleHandle, this);
            var radError = new Error<(GH_Point, GH_Plane, GH_Integer, GH_Number, GH_Interval, List<GH_Mesh>)>(CheckRadius, RadiusHandle, this);
            CheckError = new ErrorChecker<(GH_Point,GH_Plane,GH_Integer,GH_Number,GH_Interval,List<GH_Mesh>)>(error,sampleError,radError);
        }

        private static ErrorChecker<(GH_Point,GH_Plane,GH_Integer,GH_Number,GH_Interval,List<GH_Mesh>)> CheckError; //don't need to null-check the redux
        private static Func<(GH_Point,GH_Plane,GH_Integer,GH_Number,GH_Interval,List<GH_Mesh>), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null && a.Item4 != null && a.Item5 != null);

        private static bool CheckSamples ((GH_Point, GH_Plane, GH_Integer, GH_Number, GH_Interval, List<GH_Mesh>) a)
        {
            return a.Item3.Value >= 1;
        }

        private static bool CheckRadius((GH_Point, GH_Plane, GH_Integer, GH_Number, GH_Interval, List<GH_Mesh>) a)
        {
            return a.Item4.Value > DocumentTolerance();
        }

        private static Action<GH_Component> SampleHandle = c => c.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Need at least 1 sample");
        private static Action<GH_Component> RadiusHandle = c => c.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Radius cannot be negative.");
         

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Source point for isovist sample", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Number", "N", "Number of samples", GH_ParamAccess.tree, 10);
            pManager.AddNumberParameter("Radius", "R", "Radius of isovist sampling", GH_ParamAccess.tree, 100);
            pManager.AddMeshParameter("Obstacles", "O", "Obstacles in sampling", GH_ParamAccess.tree);
            pManager.AddPlaneParameter("Plane", "P", "Sampling plane. XY is used by default.", GH_ParamAccess.tree, Plane.WorldXY);
            pManager.AddIntervalParameter("Interval", "I", "Sampling interval, starting at X axis moving CCW", GH_ParamAccess.tree, new Interval(0, Math.PI * 2));
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "X", "Isovist intersections", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Index", "I", "Index of obstacle hit", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Hit", "H", "Boolean indicating hit or miss", GH_ParamAccess.tree);
        }

        private static IEnumerable<Point3d> ToPoints(Polyline p)
        {
            return p;
        }

        private static bool InParameterInterval(double min, double max, double test)
        {
            return test > min && test < max;
        }

        /// <summary>
        /// Solve Method for IsoVist 2D - Raycast around a circular arc with additional samples at important mesh areas
        /// </summary>
        public static (GH_Point[], GH_Integer[], GH_Boolean[]) SolveIso2D(GH_Point gSamplePt, GH_Plane gPlane, GH_Integer gSampleNum, 
                                                                          GH_Number gRadius, GH_Interval gInterval, List<GH_Mesh> gObstacles)
        {
            var meshes = gObstacles.Select(ob => ob.Value).ToArray();
            var sampleCenter = gSamplePt.Value;
            var plane = gPlane.Value;
            plane.Translate(sampleCenter - plane.Origin);
            var radius = gRadius.Value;
            var sintv = gInterval.Value;
            double samples = gSampleNum.Value;

            var circ = new Circle(plane, radius);
            var ixpts = meshes.SelectMany(m => {
                var ix = Intersection.MeshPlane(m, plane);
                if (ix == null || ix.Length == 0) return new Point3d[0];
                return ix.SelectMany(ToPoints);
                });
            var smpt = IRange(0, gSampleNum.Value).Select(i =>
             {
                 Vector3d baseVec = new Vector3d(plane.XAxis);
                 baseVec.Rotate(sintv.T0 + (sintv.Length) * i / samples, plane.ZAxis);
                 var pt = sampleCenter + baseVec;
                 var getTest = circ.ClosestParameter(pt, out double t);
                 return (pt, t);
             }).ToList();
            var min = smpt[0].t;
            var max = smpt[smpt.Count - 1].t;

            smpt.AddRange(ixpts.Select(pt =>
            {
                var getTest = circ.ClosestParameter(pt, out double test);
                return (pt, test);
            }).Where(pair => InParameterInterval(min, max, pair.test)));
            
            var sortVecs = smpt.Select(pair => 
            { 
                var amp = pair.pt - sampleCenter;
                amp.Unitize();
                return new Ray3d(sampleCenter, amp);
            }).ToArray();

            var resTuple = new (GH_Point, GH_Integer, GH_Boolean, double)[sortVecs.Length];

            Parallel.For(0, sortVecs.Length, j =>
            {
                var jRay = sortVecs[j];

                double bestIx = -1.0;
                int bestIdx = -1;
                for(int k = 0; k < meshes.Length; k++)
                {
                    var ix = Intersection.MeshRay(meshes[k], jRay);
                    if (ix < 0.0) continue;
                    else if (bestIx < 0.0 || ix < bestIx)
                    {
                        bestIx = ix;
                        bestIdx = k;
                    }
                }
                if (bestIx < 0.0) //failure, use radius
                {
                    var resPt = jRay.Position + jRay.Direction * radius;
                    circ.ClosestParameter(resPt, out double t);
                    resTuple[j] = (new GH_Point(resPt), new GH_Integer(-1), new GH_Boolean(false), t);
                }
                else
                {
                    //Cap radius
                    var pt2 = jRay.PointAt(bestIx);
                    if (pt2.DistanceTo(sampleCenter) > radius) pt2 = jRay.Position + jRay.Direction * radius;
                    circ.ClosestParameter(pt2, out double t);
                    resTuple[j] = (new GH_Point(pt2), new GH_Integer(bestIdx), new GH_Boolean(true), t);
                }
            });

            var sortRes = resTuple.OrderBy(p => p.Item4);
            var ptResults = sortRes.Select(p => p.Item1).ToArray();
            var iResults = sortRes.Select(p => p.Item2).ToArray();
            var ixResults = sortRes.Select(p => p.Item3).ToArray();
            return (ptResults, iResults, ixResults);
        }

        /// <summary>
        /// Loop through data structure
        /// </summary>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Integer> numTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Number> radTree)) return;
            if (!DA.GetDataTree(3, out GH_Structure<GH_Mesh> obstacleTree)) return;
            if (!DA.GetDataTree(4, out GH_Structure<GH_Plane> planeTree)) return;
            if (!DA.GetDataTree(5, out GH_Structure<GH_Interval> rangeTree)) return;

            var (pt, idx, ix) = Zip5Red1xGraft3(pointTree, planeTree, numTree, radTree, rangeTree, obstacleTree, SolveIso2D, CheckError);

            DA.SetDataList(0, pt);
            DA.SetDataList(1, idx);
            DA.SetDataList(2, ix);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Impala.Properties.Resources.__0003_Iso2D;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("6BA96C66-AAF9-4483-A1AF-522BF4D0612C"); }
        }
    }
}