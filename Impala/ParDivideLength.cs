using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Impala
{
    public class ParDivideLength : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public ParDivideLength()
          : base("ParDivideLength", "parDivLen",
              "Divide a curve into segments with a preset length.",
              "Impala", "Physical")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "C", "Curve to divide", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Length", "L", "Length of segments", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Division Points", GH_ParamAccess.tree);
            pManager.AddVectorParameter("Tangents", "T", "Tangents at divisions", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Parameters", "t", "Parameters at divisions", GH_ParamAccess.tree);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Structure<GH_Curve> curveTree;
            GH_Structure<GH_Number> lenTree;

            if (!DA.GetDataTree(0, out curveTree)) return;
            if (!DA.GetDataTree(1, out lenTree)) return;

            List<GH_Path> pList = new List<GH_Path>(); //Our base output path list
            int cdim = curveTree.get_Path(curveTree.LongestPathIndex()).Length;
            int ldim = lenTree.get_Path(lenTree.LongestPathIndex()).Length;
            if (cdim >= ldim) pList.AddRange(curveTree.Paths);
            else pList.AddRange(lenTree.Paths);
            //todo: longest tree logic check? two trees same dim. diff len
            //check curvecp as well

            GH_Structure<GH_Point> resultTree = new GH_Structure<GH_Point>();
            GH_Structure<GH_Vector> tanTree = new GH_Structure<GH_Vector>();
            GH_Structure<GH_Number> paramTree = new GH_Structure<GH_Number>();

            int maxLen = Math.Max(curveTree.PathCount, lenTree.PathCount);
            //benchmark performance

            Parallel.For(0, maxLen, i =>
            {
                int ctidx = Math.Min(i, curveTree.PathCount - 1);
                int ltidx = Math.Min(i, lenTree.PathCount - 1);

                var curveBranch = curveTree[curveTree.get_Path(ctidx)];
                var lenBranch = lenTree[lenTree.get_Path(ltidx)];

                GH_Path path = new GH_Path();
                if (i < pList.Count)
                {
                    path = new GH_Path(pList[i]);
                }
                else
                {
                    path = new GH_Path(pList[pList.Count - 1]);
                    path = path.Increment(path.Length - 1, (i - pList.Count) + 1);
                }

                int len = Math.Max(curveBranch.Count, lenBranch.Count);

                CurveDivider[] dividedCurves = new CurveDivider[len];
                if (!(curveBranch.Count == 0 || lenBranch.Count == 0))
                {
                    Parallel.For(0, len, j => {
                        int cidx = Math.Min(j, curveBranch.Count - 1);
                        int lidx = Math.Min(j, lenBranch.Count - 1);
  
                        if (ErrorCheck(curveBranch[cidx], lenBranch[lidx]))
                        {
                            CurveDivider crvDiv = new CurveDivider(curveBranch[cidx].Value, lenBranch[lidx].Value);
                            crvDiv.Divide();
                            dividedCurves[j] = crvDiv;
                        }
                    }); //end inner parallel loop

                    lock (resultTree)
                    {
                        for (int j = 0; j < dividedCurves.Count(); j++)
                        {
                            if (dividedCurves[j] != null)
                            {
                                GH_Path targetPath = path.AppendElement(j);
                                resultTree.AppendRange(dividedCurves[j].pointArray, targetPath);
                            }
                        }
                    }
                    lock (tanTree)
                    {
                        for (int j = 0; j < dividedCurves.Count(); j++)
                        {
                            if (dividedCurves[j] != null)
                            {
                                GH_Path targetPath = path.AppendElement(j);
                                tanTree.AppendRange(dividedCurves[j].vectorArray, targetPath);
                            }
                        }
                    }
                    lock (paramTree)
                    {
                        for (int j = 0; j < dividedCurves.Count(); j++)
                        {
                            if (dividedCurves[j] != null)
                            {
                                GH_Path targetPath = path.AppendElement(j);
                                paramTree.AppendRange(dividedCurves[j].paramArray, targetPath);
                            }
                        }
                    }
                } 
                else //Empty Case
                {
                    lock (resultTree)
                    {
                        resultTree.EnsurePath(path.AppendElement(0));
                    }
                    lock (tanTree)
                    {
                        tanTree.EnsurePath(path.AppendElement(0));
                    }
                    lock (paramTree)
                    {
                        paramTree.EnsurePath(path.AppendElement(0));
                    }
                }
            });

            DA.SetDataTree(0, resultTree);
            DA.SetDataTree(1, tanTree);
            DA.SetDataTree(2, paramTree);
        }

        bool ErrorCheck(GH_Curve curve, GH_Number length)
        {
            if (curve == null || length == null)
            {
                return false;
            }
            bool flag = true;
            /*if (!curve.Value.IsValid)
            {
                double val = curve.Value.GetLength();
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid Curve.");
                flag = false;
            }*/
            if (!(length.Value > 0) || length.Value <= Rhino.RhinoMath.ZeroTolerance)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid Division Length.");
                flag = false;
            }
            return flag;
        }

        public class CurveDivider
        {
            private Curve crv;
            private double divLen;
            private int divisions;

            public GH_Point[] pointArray;
            public GH_Vector[] vectorArray;
            public GH_Number[] paramArray;

            public CurveDivider(Curve crv, double divLen)
            {
                this.crv = crv.DuplicateCurve();
                this.divLen = divLen;
                double curveLen = crv.GetLength();
                divisions = Convert.ToInt32(Math.Ceiling(curveLen / divLen)) + 1;

                pointArray = new GH_Point[divisions];
                vectorArray = new GH_Vector[divisions];
                paramArray = new GH_Number[divisions];
            }

            public void Divide()
            {
                double[] parArray = new double[divisions + 5];
                Point3d[] tempPts = new Point3d[divisions + 10];

                if (divisions > 1)
                {
                    parArray = crv.DivideByLength(divLen, true, out tempPts);
                    for(int i = 0; i < tempPts.Count(); i++)
                    {
                        if (tempPts[i] != null) {
                            pointArray[i] = new GH_Point(tempPts[i]);
                        }
                        else
                        {
                            pointArray[i] = null;
                        }
                    }
                    if (parArray != null)
                    {
                        for (int i = 0; i < parArray.Count(); i++)
                        {
                            paramArray[i] = new GH_Number(parArray[i]);
                            vectorArray[i] = new GH_Vector(crv.TangentAt(parArray[i]));
                        }
                    }
                }
                else
                {
                    pointArray = new GH_Point[]{ new GH_Point(crv.PointAtStart) };
                    paramArray = new GH_Number[]{ new GH_Number(0.0) };
                    vectorArray = new GH_Vector[]{ new GH_Vector(crv.TangentAtStart) };
                }
            }
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
            get { return new Guid("17245910-2f8b-4172-be42-686f34fbe74a"); }
        }
    }
}