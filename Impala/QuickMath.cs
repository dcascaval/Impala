using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;

using static Impala.Generic;
using Rhino.Geometry;

namespace Impala
{
    public abstract class QuickMath : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the QuickMultiply class.
        /// </summary>
        public QuickMath(string n, string nn,string d,string c,string sc)
          : base(n,nn,d,c,sc)
        {
        }

        public abstract Func<GH_Number, GH_Number, GH_Number> Operation { get; }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("A", "A", "Number", GH_ParamAccess.tree);
            pManager.AddNumberParameter("B", "B", "Number", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("R", "R", "Result of operation", GH_ParamAccess.tree);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<GH_Number> a1)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Number> b1)) return;

            var result = ZipMaxManual(a1, b1, Operation);
            DA.SetDataTree(0, result);
        }
    }
}