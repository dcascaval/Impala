using System;
using System.Collections.Generic;
using System.Linq;

using Rhino.Geometry;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;

using static Impala.Generic;
using static Impala.Errors;


namespace Impala
{
    public class QuickAvg : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the QuickAvg class.
        /// </summary>
        public QuickAvg()
          : base("QuickAvg", "qAvg",
              "Averages a list of numbers.",
              "Maths", "Quick")
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.secondary;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("A", "A", "Numbers to average", GH_ParamAccess.tree);
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
            var result = ParallelReduceStructure(a1, a => new GH_Number(a.Select(x => x.Value).Sum()/a.Count()),
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
                return Properties.Resources.parabolic;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("a0b815af-ce77-4571-9f69-ea2aec9f4028"); }
        }
    }

    public class VecAvg : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the QuickAvg class.
        /// </summary>
        public VecAvg()
          : base("VectorAvg", "vAvg",
              "Averages a list of vectors of points.",
              "Maths", "Quick")
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.quarternary;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("A", "A", "Vectors to average", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddVectorParameter("R", "R", "Result", GH_ParamAccess.tree);
        }

        private GH_Vector SumList(List<GH_Vector> input)
        {
            var sumVecs = input.Select(a => a.Value).Aggregate((a, b) => a + b);
            return new GH_Vector(new Vector3d(sumVecs.X / input.Count,sumVecs.Y/input.Count, sumVecs.Z/input.Count));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Vector> a1)) return;
            var result = ParallelReduceStructure(a1, SumList,
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
                return Properties.Resources.parabolic;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("63A499B9-2A73-489A-8161-C519896B2EA2"); }
        }
    }
}