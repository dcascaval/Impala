using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using static Impala.Generic;

namespace Impala.MathComponents
{
    public class QuickSubtract : QuickMath<GH_Number>
    {
        /// <summary>
        /// Initializes a new instance of the QuickSubtract class.
        /// </summary>
        public QuickSubtract()
           : base("QuickSubtract", "qSub",
              "Subtract two numbers or integers.",
              "Impala", "Math")
        {
        }

        public override Func<GH_Number, GH_Number, GH_Number> Operation { get { return (a, b) => new GH_Number(a.Value - b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Impala.Properties.Resources.qsub;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("d0c9a197-c4f2-4c10-bc36-f4241ca2d82b"); }
        }
    }

    public class VectorSubtract : QuickMath<GH_Vector>
    {
        /// <summary>
        /// Initializes a new instance of the QuickSubtract class.
        /// </summary>
        public VectorSubtract()
           : base("VecSubtract", "vSub",
              "Subtract two points or vectors.",
              "Impala", "Math")
        {
        }

        public override Func<GH_Vector, GH_Vector, GH_Vector> Operation { get { return (a, b) => new GH_Vector(a.Value - b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Impala.Properties.Resources.qsub;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("F2DACEBC-8B1B-4E3E-B36F-CB35FF52E08C"); }
        }
    }
}