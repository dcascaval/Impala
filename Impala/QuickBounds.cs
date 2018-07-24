using System;
using System.Collections.Generic;
using System.Linq;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;
using Rhino.Geometry;

using static Impala.MathComponents.Generic;
using static Impala.MathComponents.Errors;

namespace Impala.MathComponents
{
    public class QuickBounds : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the QuickBounds class.
        /// </summary>
        public QuickBounds()
          : base("QuickBounds", "qBounds",
              "Gets 1D bounds for a list of numbers",
              "Maths", "Quick")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("A", "A", "Numbers to bound", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddIntervalParameter("R", "R", "Result", GH_ParamAccess.tree);
        }

        private GH_Interval BoundList(List<GH_Number> input)
        {
            double min = Double.MaxValue;
            double max = Double.MinValue;
            for (int i = 0; i < input.Count; i++)
            {
                var val = input[i].Value;
                if (val > max) max = val;
                if (val < min) min = val;
            }
            return new GH_Interval(new Interval(min, max));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Number> a1)) return;
            var result = ReduceStructure(a1,BoundList,
                                            new ErrorChecker<List<GH_Number>>(new Error<List<GH_Number>>(EmptyCheck, EmptyHandle, this),
                                                                              new Error<List<GH_Number>>(CheckListNull, NullHandle, this)), 2000);
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
            get { return new Guid("ba31388b-5fb0-4859-8f44-60d5a8570b41"); }
        }
    }

    public class VectorBounds : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the QuickBounds class.
        /// </summary>
        public VectorBounds()
          : base("VectorBounds", "vBounds",
              "Gets 2D bounds for a list of Points or Vectors",
              "Maths", "Quick")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("A", "A", "Vectors to bound", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddIntervalParameter("R", "R", "Result", GH_ParamAccess.tree);
        }

        private GH_Interval2D BoundList(List<GH_Vector> input)
        {
            double minx = Double.MaxValue;
            double maxx = Double.MinValue;
            double miny = Double.MaxValue;
            double maxy = Double.MinValue;

            for (int i = 0; i < input.Count; i++)
            {
                var val = input[i].Value;
                if (val.X > maxx) maxx = val.X;
                if (val.X < minx) minx = val.X;
                if (val.Y > maxy) maxy = val.Y;
                if (val.Y < miny) miny = val.Y;
            }
            return new GH_Interval2D(new UVInterval(new Interval(minx,maxx),new Interval(miny,maxy)));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Vector> a1)) return;
            var result = ReduceStructure(a1, BoundList,
                                            new ErrorChecker<List<GH_Vector>>(new Error<List<GH_Vector>>(EmptyCheck, EmptyHandle, this),
                                                                              new Error<List<GH_Vector>>(CheckListNull, NullHandle, this)), 2000);
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
            get { return new Guid("0592814E-582B-42BE-85DF-E54ECA85B8FF"); }
        }
    }
}