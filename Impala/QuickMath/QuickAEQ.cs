using System;

using Grasshopper.Kernel.Types;

namespace Impala
{
    public class QuickAEQ : QuickMath<GH_Number, GH_Boolean>
    {
        /// <summary>
        /// Initializes a new instance of the QuickEq class.
        /// </summary>
        public QuickAEQ()
          : base("QuickAEQ", "qAEQ",
              "Checks two numbers for equality in tolerance",
              "Category", "Subcategory")
        {
        }

        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Boolean;
        public override Func<GH_Number, GH_Number, GH_Boolean> Operation { get { return (a, b) => new GH_Boolean(Math.Abs(a.Value - b.Value) < 1e-6); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.AEQ;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("477cb528-b934-4b03-9236-d8905407a68a"); }
        }
    }
}

