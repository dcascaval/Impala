using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;

using static Impala.Generated;
using static Impala.Errors;

namespace Impala
{
    /// <summary>
    /// Finds the closest point on a brep to a sample point.
    /// </summary>
    public class ParBrepCP : GH_Component
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

        private ErrorChecker<(GH_Point, GH_Brep, GH_Number)> CheckError;
        private static Func<(GH_Point, GH_Brep, GH_Number), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);


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
            Brep brep = m.Value;
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
            return;
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
    }
}