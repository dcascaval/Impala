using System;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;


namespace Impala.MathComponents
{
    public class QuickDivide : QuickMath<GH_Number>
    {
        public Error<(GH_Number, GH_Number)> ZeroError;

        /// <summary>
        /// Initializes a new instance of the QuickDivide class.
        /// </summary>
        public QuickDivide()
          : base("QuickDivide", "qDiv",
              "Divides two numbers or integers.",
              "Impala", "Math")
        {
            ZeroError = new Error<(GH_Number,GH_Number)>(ZeroCheck, ZeroHandle, this);
            CheckError.AddError(ZeroError);
        }

        public override Func<GH_Number, GH_Number, GH_Number> Operation { get { return (a, b) => new GH_Number(a.Value / b.Value); } }

        public static Func<(GH_Number, GH_Number), bool> ZeroCheck = (a) => Math.Abs(a.Item2.Value) > 0;
        public static Action<GH_Component> ZeroHandle = comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Division by Zero!");

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Impala.Properties.Resources.qdiv;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("727d172e-13f9-4ed9-b2fa-da4d10cec169"); }
        }
    }

}