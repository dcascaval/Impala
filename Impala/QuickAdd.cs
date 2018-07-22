using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using static Impala.Generic;

namespace Impala
{
    public class QuickAdd : QuickMath
    {
        /// <summary>
        /// Initializes a new instance of the QuickAdd class.
        /// </summary>
        public QuickAdd()
          : base("QuickAdd", "qAdd",
              "Adds two numbers or integers together.",
              "Impala", "Math")
        {
        }

        public override Func<GH_Number, GH_Number, GH_Number> Operation { get { return (a, b) => new GH_Number(a.Value + b.Value); } }

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
            get { return new Guid("f3795cf2-4791-4eca-a2c0-1b49ffb5fb90"); }
        }
    }
}