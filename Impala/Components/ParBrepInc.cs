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
    public class ParBrepInc : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParBrepCP class.
        /// </summary>
        public ParBrepInc()
          : base("ParBrepInc", "ParBrepInc",
              "Test whether a point is inside a closed brep.",
              "Impala", "Containment")
        {
            var error = new Error<(GH_Brep, GH_Point, GH_Boolean)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Brep, GH_Point, GH_Boolean)>(error);
        }

        public ErrorChecker<(GH_Brep, GH_Point, GH_Boolean)> CheckError;
        static Func<(GH_Brep, GH_Point, GH_Boolean), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddBrepParameter("Brep", "B", "Breps to project to.", GH_ParamAccess.tree);
            pManager.AddPointParameter("Points", "P", "Points to test from.", GH_ParamAccess.tree);     
            pManager.AddBooleanParameter("Strict", "S", "If true, inclusion is strict.", GH_ParamAccess.tree, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Included", "I", "Point contained in Brep", GH_ParamAccess.tree);
        }

        public static GH_Boolean PointInBrep(GH_Brep b, GH_Point p, GH_Boolean s)
        {
            Point3d pt = p.Value;
            Brep brep = b.Value;
            bool strict = s.Value;
            if (!brep.IsManifold) return new GH_Boolean(false);
            return new GH_Boolean(brep.IsPointInside(pt, DocumentTolerance(), strict));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Brep> brepTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Boolean> strictTree)) return;

            var result = Zip3x1(brepTree, pointTree, strictTree, PointInBrep, CheckError);

            DA.SetDataTree(0, result);
            return;
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
            get { return new Guid("768A46D4-7470-4DAD-B428-43C74E0368BD"); }
        }
    }

    public class ParBrepsInc : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParBrepsInc class.
        /// </summary>
        public ParBrepsInc()
          : base("ParMBrepInc", "ParMBrepInc",
              "Test whether a point is inside a closed brep.",
              "Impala", "Containment")
        {
            var error = new Error<(GH_Point, GH_Boolean, List<GH_Brep>)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(GH_Point, GH_Boolean, List<GH_Brep>)>(error);
        }

        public ErrorChecker<(GH_Point, GH_Boolean, List<GH_Brep>)> CheckError;
        static Func<(GH_Point, GH_Boolean, List<GH_Brep>), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddBrepParameter("Brep", "B", "Breps to project to.", GH_ParamAccess.tree);
            pManager.AddPointParameter("Points", "P", "Points to test from.", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Strict", "S", "If true, inclusion is strict.", GH_ParamAccess.tree, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Included", "R", "Point contained in Brep", GH_ParamAccess.tree);
            pManager.AddIntegerParameter("Index", "I", "Index of first brep that contains point", GH_ParamAccess.tree);
        }

        public static (GH_Boolean,GH_Integer) PointInBrep(GH_Point p, GH_Boolean s, List<GH_Brep> gbrp)
        {
            Point3d pt = p.Value;
            var brepx = gbrp.Where(g => g != null).Select(g => g.Value).ToArray();

            for (int i = 0; i < brepx.Length; i++)
            {
                Brep brep = brepx[i];
                bool strict = s.Value;
                if (!brep.IsManifold) continue;
                if (brep.IsPointInside(pt, DocumentTolerance(), strict)) return (new GH_Boolean(true), new GH_Integer(i));
            }
            return (new GH_Boolean(false), new GH_Integer(-1));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Brep> brepTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Boolean> strictTree)) return;

            var (ix,idx) = Zip2Red1x2(pointTree, strictTree, brepTree, PointInBrep, CheckError);

            DA.SetDataTree(0, ix);
            DA.SetDataTree(1, idx);
            return;
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
            get { return new Guid("B336756A-C98A-4271-840B-5F566B3483B1"); }
        }
    }
}