using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using static Impala.Generic;

namespace Impala.MathComponents
{
    public class QuickAdd : QuickMath<GH_Number>
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
                return Impala.Properties.Resources.qadd;
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

    public class VectorAdd : QuickMath<GH_Vector>
    {
        /// <summary>
        /// Initializes a new instance of the QuickSubtract class.
        /// </summary>
        public VectorAdd()
           : base("VecAdd", "vAdd",
              "Add two points or vectors.",
              "Impala", "Math")
        {
        }

        public override Func<GH_Vector, GH_Vector, GH_Vector> Operation { get { return (a, b) => new GH_Vector(a.Value + b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Impala.Properties.Resources.qadd;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("D77EC2FD-DAE9-48CB-A3EB-09B5283844B9"); }
        }
    }
}