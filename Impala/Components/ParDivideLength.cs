using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Generic;
using static Impala.Generated;
using static Impala.Errors;

namespace Impala
{
    public class ParDivideLength : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParDivideLength class.
        /// </summary>
        public ParDivideLength()
          : base("ParDivideLength", "parDivLen",
              "Divide a curve into segments with a preset length.",
              "Impala", "Physical")
        {
            var nerror = new Error<(GH_Curve, GH_Number, GH_Point, GH_Vector)>(NullCheck, NullHandle, this);
            var terror = new Error<(GH_Curve, GH_Number, GH_Point, GH_Vector)>(TolValidCheck, TolValidHandle, this);
            CheckError = new ErrorChecker<(GH_Curve, GH_Number, GH_Point, GH_Vector)>(nerror,terror);
        }

        static ErrorChecker<(GH_Curve, GH_Number, GH_Point, GH_Vector)> CheckError;
        static Func<(GH_Curve, GH_Number, GH_Point, GH_Vector), bool> NullCheck = a => (a.Item1 != null && a.Item2 != null && a.Item3 != null && a.Item4 != null);

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "C", "Curve to divide", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Length", "L", "Length of segments", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Division Points", GH_ParamAccess.tree);
            pManager.AddVectorParameter("Tangents", "T", "Tangents at divisions", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Parameters", "t", "Parameters at divisions", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Divide a curve into segments of a set length.
        /// </summary>
        (GH_Point[],GH_Vector[],GH_Number[]) DivCurve(GH_Curve gcrv, GH_Number gnum, GH_Point start, GH_Vector stan)
        {
            var crv = (Curve)gcrv.Value.Duplicate();
            var divLen = gnum.Value;
            double curveLen = crv.GetLength();
            var divisions = Convert.ToInt32(Math.Floor(curveLen / divLen)) + 1;

            var pointArray = new GH_Point[divisions];
            var vectorArray = new GH_Vector[divisions];
            var paramArray = new GH_Number[divisions];

            if (divisions > 1)
            {
                double[] parArray = crv.DivideByLength(divLen, true, out Point3d[] tempPts);
                if (tempPts != null)
                {
                    for (int i = 0; i < tempPts.Count(); i++)
                    {
                        pointArray[i] = tempPts[i] != null ? new GH_Point(tempPts[i]) : null;                      
                    }
                    if (parArray != null) //shouldn't be necessary, but there's race conditions around here.
                    {
                        //Todo: we should really have a recompute here. 
                        for (int i = 0; i < parArray.Count(); i++)
                        {
                            paramArray[i] = new GH_Number(parArray[i]);
                            vectorArray[i] = new GH_Vector(crv.TangentAt(parArray[i]));
                        }
                    }
                }
                else
                {
                    return (new GH_Point[] { null }, new GH_Vector[] { null }, new GH_Number[] { null });
                }
            }
            else
            {
                pointArray = new GH_Point[] { start };
                vectorArray = new GH_Vector[] { stan };
                paramArray = new GH_Number[] { new GH_Number(0.0) };
            }
            return (pointArray, vectorArray, paramArray);  
        }

        static Func<GH_Curve, bool> CurveValidCheck => x => x.Value.IsValid && x.Value.GetLength() > Rhino.RhinoMath.ZeroTolerance;
        static Func<(GH_Curve, GH_Number, GH_Point, GH_Vector), bool> TolValidCheck => x => x.Item2.Value > Rhino.RhinoMath.ZeroTolerance;
        static Action<GH_Component> CurveValidHandle => comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid Curve.");
        static Action<GH_Component> TolValidHandle => comp => comp.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid Division Length.");
        static Func<GH_Curve, bool> CurveNull => c => c != null;
        
        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            
            if (!DA.GetDataTree(0, out GH_Structure<GH_Curve> curveTree)) return;
            if (!DA.GetDataTree(1, out GH_Structure<GH_Number> lenTree)) return;

            //Check the curve errors sequentially to avoid race condition
            var crvnull = new Error<GH_Curve>(CurveNull, NullHandle, this);
            var crvvalid = new Error<GH_Curve>(CurveValidCheck, CurveValidHandle, this);
            var curveValidError = new ErrorChecker<GH_Curve>(crvnull, crvvalid);

            //These must be done with a sequential mapping, as there exists a race condition within the native
            //OpenNURBS methods for handling curves w/r/t extracting values at parameters.
            var startpts = MapStructure(curveTree, c => new GH_Point(c.Value.PointAtStart), curveValidError);
            var starttans = MapStructure(curveTree, c => new GH_Vector(c.Value.TangentAtStart), curveValidError);

            //Curve errors are pre-checked and already nulled out here
            var (points, tangents, divparams) = Zip4xGraft3(curveTree, lenTree, startpts, starttans, DivCurve, CheckError);

            DA.SetDataTree(0, points);
            DA.SetDataTree(1, tangents);
            DA.SetDataTree(2, divparams);
            return;
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
                return Impala.Properties.Resources.__0007_DivLen;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("FAA9B0F6-2478-42B1-A19E-B2D9E3879C55"); }
        }

    }

}