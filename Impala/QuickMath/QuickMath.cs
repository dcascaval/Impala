using System;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Data;

using static Impala.Generic;
using static Impala.Errors;

namespace Impala
{
    public abstract class QuickMath<T,Q> : GH_Component
        where T : IGH_Goo
        where Q : IGH_Goo
    {
        public Error<(T,T)> NullError;
        public ErrorChecker<(T, T)> CheckError;

        public enum Type
        {
            Vector, Number, Boolean
        }

        /// <summary>
        /// Initializes the default handlers for a QuickMath component
        /// </summary>
        public QuickMath(string n, string nn,string d,string c,string sc)
          : base(n,nn,d,"Maths","Quick")
        {
            NullError  = new Error<(T, T)>(NullCheck, NullHandle, this);
            CheckError = new ErrorChecker<(T, T)>(NullError);
        }

        public abstract Type InputType { get; }
        public abstract Type OutputType { get; }
        public abstract Func<T, T, Q> Operation { get; }
        public static Func<(T, T), bool> NullCheck = (a) => a.Item1 != null && a.Item2 != null;



        /// <summary>
        /// Registers all the input parameters for this component. This contains a conditional in order to call the correct
        /// method on pManager to induce Grasshopper to give us the correct type. Currently only GH_Number and GH_Vector 
        /// are supported.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            switch (InputType) {
                case Type.Number: 
                    pManager.AddNumberParameter("A", "A", "Number", GH_ParamAccess.tree);
                    pManager.AddNumberParameter("B", "B", "Number", GH_ParamAccess.tree);
                    break;
                case Type.Vector:
                    pManager.AddVectorParameter("A", "A", "Vector or Point", GH_ParamAccess.tree);
                    pManager.AddVectorParameter("B", "B", "Vector or Point", GH_ParamAccess.tree);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Registers all the output parameters for this component. This contains a conditional in order to call the correct
        /// method on pManager to induce Grasshopper to give us the correct type. Currently only GH_Number and GH_Vector 
        /// are supported.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            switch (OutputType) {
                case Type.Number:
                    pManager.AddNumberParameter("R", "R", "Result of Number operation", GH_ParamAccess.tree);
                    break;
                case Type.Vector:
                    pManager.AddVectorParameter("R", "R", "Result of Vector operation", GH_ParamAccess.tree);
                    break;
                case Type.Boolean:
                    pManager.AddBooleanParameter("R", "R", "Result of Boolean operation", GH_ParamAccess.tree);
                    break;
                default:
                    break;
            }
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetDataTree(0, out GH_Structure<T> a1)) return;
            if (!DA.GetDataTree(1, out GH_Structure<T> b1)) return;

            var result = ZipMaxParallel1D(a1, b1, Operation, CheckError, 100000, 10000);
            DA.SetDataTree(0, result);
        }
    }
}