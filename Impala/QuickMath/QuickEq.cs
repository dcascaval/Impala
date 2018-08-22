using System;

using Grasshopper.Kernel.Types;

namespace Impala
{
    public class QuickEq : QuickMath<GH_Number,GH_Boolean>
    {
        /// <summary>
        /// Initializes a new instance of the QuickEq class.
        /// </summary>
        public QuickEq()
          : base("QuickEq", "qEq",
              "Checks two numbers for equality",
              "Category", "Subcategory")
        {
        }

        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Boolean;
        public override Func<GH_Number, GH_Number, GH_Boolean> Operation { get { return (a, b) => new GH_Boolean(a.Value == b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.equal;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("813e0daf-77fe-4262-934a-7803d48326be"); }
        }
    }
}