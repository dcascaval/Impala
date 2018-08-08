using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;

using static Impala.Generic;
using static Impala.Errors;

namespace Impala
{
    public class QuickNeg : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the QuickNeg class.
        /// </summary>
        public QuickNeg()
          : base("QuickNeg", "qNeg",
              "Negative of a number",
              "Maths", "Quick")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("A", "A", "Number to negate", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("R", "R", "Result", GH_ParamAccess.tree);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Number> a1)) return;
            var result = MapStructureParallel(a1, a => new GH_Number(-a.Value),
                                                       new ErrorChecker<GH_Number>(new Error<GH_Number>(a => a != null, NullHandle, this)), 10000);
            DA.SetDataTree(0, result);
        }

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
            get { return new Guid("dac80d01-13fe-489b-bcb4-b236779c0581"); }
        }
    }
}