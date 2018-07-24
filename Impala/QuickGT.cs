using System;
using Grasshopper.Kernel.Types;

namespace Impala.MathComponents
{
    public class QuickGT : QuickMath<GH_Number,GH_Boolean>
    {
        /// <summary>
        /// Initializes a new instance of the QuickGT class.
        /// </summary>
        public QuickGT()
          : base("QuickGT", "qGT",
              "Test two numbers within a tolerance",
              "Category", "Subcategory")
        {
        }

        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Boolean;
        public override Func<GH_Number, GH_Number, GH_Boolean> Operation { get { return (a, b) => new GH_Boolean((a.Value - b.Value) > 1e-8); } }

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
            get { return new Guid("e1581d1b-948e-4149-aacf-67a238b9a5f4"); }
        }
    }
}