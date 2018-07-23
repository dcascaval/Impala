using System;
using Grasshopper.Kernel.Types;

namespace Impala.MathComponents
{
    public class QuickAdd : QuickMath<GH_Number,GH_Number>
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
        public override Type InputType => Type.Number;
        public override Type OutputType => Type.Number;

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;//Impala.Properties.Resources.qadd;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("62D8A3D4-475E-45C9-8B3F-786D3737865C"); }
        }
    }




    public class VectorAdd : QuickMath<GH_Vector,GH_Vector>
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
        public override Type InputType => Type.Vector;
        public override Type OutputType => Type.Vector;

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;//Impala.Properties.Resources.qadd;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("4DB2AB81-D9A5-4A6C-B177-3CACADF2A535"); }
        }
    }
}