using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Generic;
using static Impala.Generated;
using static Impala.Errors;

namespace Impala
{
    public class ParShatter : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParDivideLength class.
        /// </summary>
        public ParShatter()
          : base("ParShatter", "parShatter",
              "Shatter the curve along selected parameters.",
              "Impala", "Physical")
        {
            var nerror = new Error<(GH_Curve, List<GH_Number>)>(NullCheck, NullHandle, this);
            var cerror = new Error<(GH_Curve, List<GH_Number>)>(CurveValidCheck, CurveValidHandle, this);
            CheckError = new ErrorChecker<(GH_Curve, List<GH_Number>)>(nerror, cerror);
        }

        static ErrorChecker<(GH_Curve, List<GH_Number>)> CheckError;
        static Func<(GH_Curve, List<GH_Number>), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null);
        static Func<(GH_Curve,List<GH_Number>), bool> CurveValidCheck => x => x.Item1.Value.IsValid && x.Item1.Value.GetLength() > Rhino.RhinoMath.ZeroTolerance;
        static Action<GH_Component> CurveValidHandle => comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid Curve.");

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "C", "Curve to shatter", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Paramters", "P", "Parameters to split at", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("Shattered", "S", "Shattered remains", GH_ParamAccess.tree);        
        }

        /// <summary>
        /// Divide a curve into segments of a set length.
        /// </summary>
        GH_Curve[] ShatterCurve(GH_Curve gcrv, List<GH_Number> gnum)
        {
            var crv = (Curve)gcrv.Value.Duplicate();
            var divs = gnum.Where(g => g != null).Select(g => g.Value).OrderBy(k => k).ToArray();
            var result = new Curve[divs.Length - 1];
            Parallel.For(0, divs.Length - 1, i => result[i] = crv.Trim(divs[i], divs[i + 1]));
            return result.Select(r => new GH_Curve(r)).ToArray();
        }

      
        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            if (!DA.GetDataTree(0, out GH_Structure<GH_Curve> curveTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Number> lenTree)) return;

            var result = Zip1Red1xGraft1(curveTree, lenTree, ShatterCurve, CheckError);

            DA.SetDataTree(0, result);
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
                return Impala.Properties.Resources.__0006_Shatter;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>s
        public override Guid ComponentGuid
        {
            get { return new Guid("49FA7AC5-A4CD-452F-BA4B-4F2EBE1C1077"); }
        }

    }

}