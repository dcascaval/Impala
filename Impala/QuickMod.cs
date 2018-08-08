using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;

using static Impala.Generic;
using static Impala.Errors;


namespace Impala
{
    public class QuickMod : QuickMath<GH_Number,GH_Number>
    {
        /// <summary>
        /// Initializes a new instance of the QuickMod class.
        /// </summary>
        public QuickMod()
          : base("QuickMod", "qMod",
              "Modulus of two numbers",
              "Category", "Subcategory")
        {
        }


        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Number;
        public override Func<GH_Number, GH_Number, GH_Number> Operation { get { return (a, b) => new GH_Number(a.Value % b.Value); } }

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
            get { return new Guid("59a599fd-98a6-4094-b89e-c5e9ac36c5f5"); }
        }
    }
}