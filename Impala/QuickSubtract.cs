using System;
using Grasshopper.Kernel.Types;

namespace Impala.MathComponents
{
    public class QuickSubtract : QuickMath<GH_Number,GH_Number>
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

        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Number;
        public override Func<GH_Number, GH_Number, GH_Number> Operation { get { return (a, b) => new GH_Number(a.Value - b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null; //Impala.Properties.Resources.qsub;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("75702834-D65E-4206-96EF-858E1C8B370A"); }
        }
    }

    public class VectorSubtract : QuickMath<GH_Vector,GH_Vector>
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


        public override Type InputType => Type.Vector;
        public override Type OutputType => Type.Vector;
        public override Func<GH_Vector, GH_Vector, GH_Vector> Operation { get { return (a, b) => new GH_Vector(a.Value - b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null; //Impala.Properties.Resources.qsub;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get {
                return new Guid("BE21A124-4EEF-4F51-8E91-86F88B8ACA0B");
            }
        }
    }
}