using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Errors;
using static Impala.Generic;

namespace Impala
{
    public class ParCurveCP : GH_Component
    {

        /// <summary>
        /// Initializes a new instance of the Parallel Curve CP class.
        /// </summary>
        public ParCurveCP()
          : base("Curve Closest Point", "parCurveCP",
              "Closest Point on a curve to a sample, within a tolerance.",
              "Impala", "Physical")
        {
            var error = new Error<(GH_Point, GH_Curve, GH_Number)>(NullCheck,NullHandle,this);
            CheckError = new ErrorChecker<(GH_Point, GH_Curve, GH_Number)>(error);
        }

        static ErrorChecker<(GH_Point, GH_Curve, GH_Number)> CheckError;
        static Func<(GH_Point, GH_Curve, GH_Number), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null);

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Point to sample from", GH_ParamAccess.tree);
            pManager.AddCurveParameter("Curve", "C", "Curve to test", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Tolerance", "D", "Maximum testing distance", GH_ParamAccess.tree, Double.MaxValue);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Closest point on curve", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Parameter", "t", "Parameter on curve", GH_ParamAccess.tree);
            pManager.AddBooleanParameter("Projected", "X", "Was the point moved?", GH_ParamAccess.tree);
        }

        static (GH_Point,GH_Number,GH_Boolean) CurveCP(GH_Point p, GH_Curve c, GH_Number t)
        {
            Point3d pt = p.Value;
            Curve crv = c.Value;
            double tol = t.Value;

            bool param = crv.ClosestPoint(pt, out double curveParam, tol);
            if (param)
            {
                Point3d closePoint = crv.PointAt(curveParam);
                return (new GH_Point(closePoint), new GH_Number(curveParam), new GH_Boolean(true));
            }
            else
            {
                return (null, null, new GH_Boolean(false));
            }
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Point> pointTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Curve> curveTree)) return;
            if (!DA.GetDataTree(2, out GH_Structure<GH_Number> tolTree)) return;

            var (points, parameters, projects) = ZipMaxTree3x3(pointTree, curveTree, tolTree, CurveCP, CheckError);

            DA.SetDataTree(0, points);
            DA.SetDataTree(1, parameters);
            DA.SetDataTree(2, projects);
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
                return Impala.Properties.Resources.parccp;
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

    /* Generic NxM version
    public class ParCurveCPGeneric : GH_Component
    {
        //public override GH_Exposure Exposure => GH_Exposure.hidden;
        private ErrorChecker<IGH_Goo[]> CheckError;
            
        /// <summary>
        /// Initializes a new instance of the Parallel Curve CP class.
        /// </summary>
        public ParCurveCPGeneric()
          : base("pCCPGen", "parCurveCPGeneric",
              "Closest Point on a curve to a sample, within a tolerance.",
              "Impala", "Physical")
        {
            var error = new Error<IGH_Goo[]>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<IGH_Goo[]>(error);
        }

        private bool NullCheck(IGH_Goo[] inputs)
        {
            var flag = true;
            for(int i = 0; i < inputs.Length; i++)
            {
                flag &= inputs[i] != null;
            }
            return flag;
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Point", "P", "Point to sample from", GH_ParamAccess.tree);
            pManager.AddGenericParameter("Curve", "C", "Curve to test", GH_ParamAccess.tree);
            pManager.AddGenericParameter("Tolerance", "D", "Maximum testing distance", GH_ParamAccess.tree);
            this.Params.Input[2].Optional = true;
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

        private static IGH_Goo[] _nullReturn = { null, null, new GH_Boolean(false) };
        private object errlock = new Object();
        private int errnum = 0;

        IGH_Goo[] CurveCP(IGH_Goo[] values)
        {
            GH_Point gpt = values[0] as GH_Point;
            GH_Curve gcrv = values[1] as GH_Curve;
            GH_Number gnum = values[2] as GH_Number;


            if (gpt == null || gcrv == null || gnum == null)
            {
                lock (errlock)
                {
                    errnum++;
                }
                return _nullReturn;
            }

            Point3d pt = gpt.Value;
            Curve crv = gcrv.Value;
            double tol = gnum.Value;

            bool param = crv.ClosestPoint(pt, out double curveParam, tol);
            if (param)
            {
                Point3d closePoint = crv.PointAt(curveParam);
                return new IGH_Goo[]{ new GH_Point(closePoint), new GH_Number(curveParam), new GH_Boolean(true) };
            }
            else
            {
                return _nullReturn;
            }
        }


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            errnum = 0; 
            if (!DA.GetDataTree(0, out GH_Structure<IGH_Goo> points)) return;
            if (!DA.GetDataTree(1, out GH_Structure<IGH_Goo> curves)) return;
            if (!DA.GetDataTree(2, out GH_Structure<IGH_Goo> tols)) return;

            if (tols.DataCount == 0)
            {
                tols = new GH_Structure<IGH_Goo>();
                tols.Append(new GH_Number(double.MaxValue));
            }

            //Cast in
            GH_Structure<IGH_Goo>[] inputs = new GH_Structure<IGH_Goo>[] { points,curves,tols };
            //Operate
            GH_Structure<IGH_Goo>[] results = ZipMaxN(inputs, CurveCP, CheckError, 3);

            if (errnum > 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Failed to convert input types. Emitting null.");
                return;
            }

            //Cast out
            DA.SetDataTree(0,results[0]);
            DA.SetDataTree(1,results[1]);
            DA.SetDataTree(2,results[2]);
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
                //return Impala.Properties.Resources.parccp;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("5AEA824F-3B81-490B-B9C4-F2BDB1B4B451"); }
        }
    }
    */
 
}