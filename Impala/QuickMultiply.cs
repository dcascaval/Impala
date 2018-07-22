using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using static Impala.Generic;

namespace Impala.MathComponents
{
    public class QuickMultiply : QuickMath<GH_Number>
    {

        public QuickMultiply()
          : base("QuickMultiply", "qMult",
              "Multiplies two numbers or integers together.",
              "Impala", "Math")
        {
        }

        public override Func<GH_Number, GH_Number, GH_Number> Operation { get { return (a, b) => new GH_Number(a.Value * b.Value); } }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Impala.Properties.Resources.qmult;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("ebbb8d13-2296-4840-ac31-3d5ae4bf9c06"); }
        }
    }

}