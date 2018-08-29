using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;

using static Impala.Utilities;
using static Impala.Generated;
using static Impala.Errors;

namespace Impala
{
    /// <summary>
    /// Finds the closest point on a brep to a sample point.
    /// WARNING: This component can crash Rhino! 
    /// </summary>
    class ParBrepCP : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParBrepCP Component.
        /// </summary>
        public ParBrepCP()
          : base("ParBrepCP", "ParBrepCP",
              "Closest point on a brep to a sample point",
              "Impala", "Physical")
        {
            var error = new Error<(GH_Point, GH_Brep, GH_Number)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Point, GH_Brep, GH_Number)>(error);
        }

        private static ErrorChecker<(GH_Point, GH_Brep, GH_Number)> CheckError;
        private static Func<(GH_Point, GH_Brep, GH_Number), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);
        public override GH_Exposure Exposure => GH_Exposure.hidden;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Points to test from", GH_ParamAccess.tree);
            pManager.AddBrepParameter("Brep", "B", "Breps to project to", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Threshold", "T", "Maximum allowed point distance", GH_ParamAccess.tree, double.MaxValue);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Closest Point on Brep", GH_ParamAccess.tree);
            pManager.AddVectorParameter("Normal", "N", "Normal on closest face or tangent of closest edge", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Distance", "D", "Distance to closest point", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Projected", "X", "Was the point in threshold?", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Solve method for Brep CP
        /// </summary>
        public static (GH_Point, GH_Vector, GH_Number, GH_Boolean) BrepCP(GH_Point p, GH_Brep m, GH_Number t)
        {
            Point3d pt = p.Value;
            Brep brep = m.Value.DuplicateBrep();
            double tol = t.Value;

            var tryproject = brep.ClosestPoint(pt, out Point3d breppt, out ComponentIndex ci, out double sp, out double tp, tol, out Vector3d normal);
            if (tryproject)
            {
                return (new GH_Point(breppt), new GH_Vector(normal), new GH_Number(breppt.DistanceTo(pt)), new GH_Boolean(true));
            }
            else
            {
                return (null, null, null, new GH_Boolean(false));
            }
        }

        private static int RunTimes = 0;
        /// <summary>
        /// Loop through data structure.
        /// </summary>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Brep> BrepTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Number> tolTree)) return;

            var (points, vectors, distances, projects) = Zip3x4(pointTree, BrepTree, tolTree, BrepCP, CheckError);

            DA.SetDataTree(0, points);
            DA.SetDataTree(1, vectors);
            DA.SetDataTree(2, distances);
            DA.SetDataTree(3, projects);      
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Impala.Properties.Resources.__0021_BrepCP;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("48E7C724-DE9E-423F-8B46-D92F9914B4A0"); }
        }

        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>) Zip3x4Seq<T, Q, R, A, B, C, D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T, Q, R, (A, B, C, D)> action, ErrorChecker<(T, Q, R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();

            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);

            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths, i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }

            for(int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths, i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C, D)[] temp = new(A, B, C, D)[maxlen];
                    for (int j = 0; j < maxlen; j++)
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : default;
                    }
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            }

            return (result1, result2, result3, result4);
        }
    }
}