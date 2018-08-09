using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Generic;

namespace Impala
{
    public static class ImpalaTest
    {
        public static List<GH_Point> GetRandomGHPoints(int n, double rng)
        {
            return GetRandomPoints(n, rng).Select(pt => new GH_Point(pt)).ToList();
        }

        public static List<Point3d> GetRandomPoints(int n, double rng)
        {
            var gen = new Random();
            return Enumerable.Range(0, n)
                .Select(_ => new Point3d(gen.NextDouble() * rng,
                                         gen.NextDouble() * rng,
                                         gen.NextDouble() * rng))
                .ToList();
        }

        public static GH_Mesh GetRandomGHMesh(int numFaces)
        {
            return new GH_Mesh(GetRandomMesh(numFaces));
        }

        public static Mesh GetRandomMesh(int numFaces)
        {
            var pts = GetRandomPoints(numFaces * 3, MeshRange);
            var mesh = new Mesh();
            mesh.Vertices.AddVertices(pts);
            Enumerable.Range(0, numFaces).DoEach(i => mesh.Faces.AddFace(i * 3, i * 3 + 1, i * 3 + 2));
            return mesh;
        }

        public static int MeshFaceCount = 200;
        public static double PointRange = 10.0;
        public static double MeshRange = 5.0;

        public static (GH_Structure<GH_Point>, GH_Structure<GH_Mesh>, GH_Structure<GH_Number>) Get3xTestTrees(int pbranch, int pcount, int mbranch, int mct)
        {
            var ptree = new GH_Structure<GH_Point>();
            var mTree = new GH_Structure<GH_Mesh>();
            var numTree = new GH_Structure<GH_Number>();
            for (int i = 0; i < pbranch; i++)
            {
                ptree.AppendRange(GetRandomGHPoints(pcount, PointRange), new GH_Path(i));
            }
            for (int i = 0; i < mbranch; i++)
            {
                var mshs = Enumerable.Range(0, mct).Select(_ => GetRandomGHMesh(MeshFaceCount));
                mTree.AppendRange(mshs, new GH_Path(i));
            }

            numTree.Append(new GH_Number(double.MaxValue));

            return (ptree, mTree, numTree);
        }

        public static (ProfResult,ProfResult) Zip3xTests(int pb, int pc, int mb, int mc)
        {
            var (a, b, c) = Get3xTestTrees(pb,pc,mb,mc);
            var timer = Stopwatch.StartNew();
            var t1 = ZipMaxTree3x3(a, b, c, ParMeshCP.MeshCP, new ParMeshCP().CheckError);
            var r1 = new ProfResult((int) timer.ElapsedMilliseconds, t1.Item1.DataCount);
            timer = Stopwatch.StartNew();
            var t2 = ZipMaxTree3xN(a, b, c, ParMeshCPAuto.MeshCPAuto, new ParMeshCPAuto().CheckError, 3);
            var r2 = new ProfResult((int)timer.ElapsedMilliseconds, t2[0].DataCount);
            return (r1, r2);
        }

        public static (ProfResult,ProfResult) FlatCasterTest(int num)
        {
            var mesh = GetRandomGHMesh(MeshFaceCount);
            var points = GetRandomGHPoints(num,5.0);
            var inputs = points.Select(pt => (pt, mesh, new GH_Number(double.MaxValue))).ToArray();

            var timer = Stopwatch.StartNew();
            var t1 = inputs.Select(x => ParMeshCP.MeshCP(x.pt,x.mesh,x.Item3)).ToList();
            var r1 = new ProfResult((int)timer.ElapsedMilliseconds, t1.Count);

            timer = Stopwatch.StartNew();
            var t2 = inputs.Select(x => ParMeshCPAuto.MeshCPAuto(x.pt, x.mesh, x.Item3)).ToList();
            var r2 = new ProfResult((int)timer.ElapsedMilliseconds, t2.Count);

            return (r1, r2);
        }

    }

    public struct ProfResult
    {
        public int ms;
        public int count;

        public ProfResult(int milliseconds, int count)
        {
            this.ms = milliseconds;
            this.count = count;
        }

    }

    public class ImpalaTester : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ImpalaTest class.
        /// </summary>
        public ImpalaTester()
          : base("ImpalaTester", "ipTest",
              "Description",
              "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Recompute", "R", "Rerun the tests", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output", "O", "Results from test run", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Runtime", "T", "Runtime in ms from each run", GH_ParamAccess.list);
            pManager.AddIntegerParameter("DataCount", "C", "Iterations computed",GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            var(t1,t2) = ImpalaTest.Zip3xTests(1,12000,10,1);
            //var (t1, t2) = ImpalaTest.FlatCasterTest(120000);
            DA.SetData(0, new GH_String($"Run."));
            DA.SetDataList(1, new List<GH_Integer>() { new GH_Integer(t1.ms), new GH_Integer(t2.ms)});
            DA.SetDataList(2, new List<GH_Integer>() { new GH_Integer(t1.count), new GH_Integer(t2.count) });
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
            get { return new Guid("928bc4f2-2616-4200-92ac-47ca89101f6f"); }
        }
    }
}