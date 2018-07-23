using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;

using static Impala.Generic;
using static Impala.Errors;
using Rhino.Geometry;

namespace Impala.MathComponents
{
    public abstract class QuickMath<T> : GH_Component
        where T : IGH_Goo
    {
        public Error<(T,T)> NullError;
        public ErrorChecker<(T, T)> CheckError;

        /// <summary>
        /// Initializes the default handlers for a QuickMath component
        /// </summary>
        public QuickMath(string n, string nn,string d,string c,string sc)
          : base(n,nn,d,c,sc)
        {
            NullError  = new Error<(T, T)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(T, T)>(NullError);
        }

        public abstract Func<T, T, T> Operation { get; }
        public static Func<(T, T), bool> NullCheck = (a) => a.Item1 != null && a.Item2 != null;
        
 

        /// <summary>
        /// Registers all the input parameters for this component. This contains a conditional in order to call the correct
        /// method on pManager to induce Grasshopper to give us the correct type. Currently only GH_Number and GH_Vector 
        /// are supported.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            if (typeof(T) == typeof(GH_Number)){
                pManager.AddNumberParameter("A", "A", "Number", GH_ParamAccess.tree);
                pManager.AddNumberParameter("B", "B", "Number", GH_ParamAccess.tree);
            }
            else if (typeof(T) == typeof(GH_Vector))
            {
                pManager.AddVectorParameter("A", "A", "Vector or Point", GH_ParamAccess.tree);
                pManager.AddVectorParameter("B", "B", "Vector or Point", GH_ParamAccess.tree);
            }
        }

        /// <summary>
        /// Registers all the output parameters for this component. This contains a conditional in order to call the correct
        /// method on pManager to induce Grasshopper to give us the correct type. Currently only GH_Number and GH_Vector 
        /// are supported.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            if (typeof(T) == typeof(GH_Number))
            {
                pManager.AddNumberParameter("R", "R", "Result of operation", GH_ParamAccess.tree);
            }
            else if (typeof(T) == typeof(GH_Vector))
            {
                pManager.AddVectorParameter("R", "R", "Result of operation", GH_ParamAccess.tree);
            }
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<T> a1)) return;
            if (!DA.GetDataTree(1, out GH_Structure<T> b1)) return;

            var result = ZipMaxManual(a1, b1, Operation, CheckError);
            DA.SetDataTree(0, result);
        }
    }
}