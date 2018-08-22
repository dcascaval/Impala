using System;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;


namespace Impala
{
    public class QuickLT : QuickMath<GH_Number,GH_Boolean>
    {
        /// <summary>
        /// Initializes a new instance of the QuickLT class.
        /// </summary>
        public QuickLT()
          : base("QuickLT", "qLT",
              "Tests two numbers within a tolerance",
              "Category", "Subcategory")
        {
        }


        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Boolean;
        public override Func<GH_Number, GH_Number, GH_Boolean> Operation { get { return (a, b) => new GH_Boolean((b.Value - a.Value) > 1e-8); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.ALT;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("1aca0001-55f0-4b5d-9b00-20377ae691fc"); }
        }
    }
}