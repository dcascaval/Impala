using System;
using Grasshopper.Kernel.Types;

namespace Impala
{
    public class QuickMultiply : QuickMath<GH_Number,GH_Number>
    {

        public QuickMultiply()
          : base("QuickMultiply", "qMult",
              "Multiplies two numbers or integers together.",
              "Maths", "Quick")
        {
        }


        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Number;
        public override Func<GH_Number, GH_Number, GH_Number> Operation { get { return (a, b) => new GH_Number(a.Value * b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;//Impala.Properties.Resources.qmult;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("C89AFC63-DF42-42B2-B071-F30D4E7BC1E1"); }
        }
    }

}