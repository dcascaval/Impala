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

            List<CurveDivider> DivisionSetup = new List<CurveDivider>();
            List<GH_Path> NullDivisions = new List<GH_Path>();

            for(int i = 0; i < maxLen; i++)
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

                if (!(curveBranch.Count == 0 || lenBranch.Count == 0))
                {
                    for (int j = 0; j < len; j++)
                    {
                        int cidx = Math.Min(j, curveBranch.Count - 1);
                        int lidx = Math.Min(j, lenBranch.Count - 1);

                        if (ErrorCheck(curveBranch[cidx], lenBranch[lidx]))
                        {
                            DivisionSetup.Add(new CurveDivider(curveBranch[cidx].Value, lenBranch[lidx].Value, path.AppendElement(j)));
                        }
                        else
                        {
                            NullDivisions.Add(path.AppendElement(j));
                        }
                    }
                } 
                else //Empty Case
                {
                    for (int j = 0; j < Math.Max(1,len); j++)
                    {
                        NullDivisions.Add(path.AppendElement(j));
                    }
                }
                   
            }
            //todo: profile this segment -^ relative to the heavy comp below on larger solns.

            //Zoom Zoom
            Parallel.For(0, DivisionSetup.Count, i => {
                DivisionSetup[i].Divide();
            });

            //Optimise this - is it possible to get these parallelised as well?
            foreach (CurveDivider division in DivisionSetup)
            {
                division.AssignTrees(resultTree, tanTree, paramTree);
            }

            foreach(GH_Path nullPath in NullDivisions)
            {
                resultTree.EnsurePath(nullPath);
                tanTree.EnsurePath(nullPath);
                paramTree.EnsurePath(nullPath);
            }


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
            if (!curve.IsValid || curve.Value.GetLength() < Rhino.RhinoMath.ZeroTolerance)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid Curve.");
                flag = false;
            }
            if (!(length.Value > 0) || length.Value <= Rhino.RhinoMath.ZeroTolerance)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid Division Length.");
                //Not thread safe?
                flag = false;
            }
            return flag;
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

    public class CurveDivider
    {
        private Curve crv;
        private double divLen;
        private int divisions;
        
        private Point3d start;
        private Vector3d startTangent;

        public GH_Point[] pointArray;
        public GH_Vector[] vectorArray;
        public GH_Number[] paramArray;
        public GH_Path targetPath;

        public CurveDivider(Curve crv, double divLen, GH_Path targetPath)
        {
            this.crv = (Curve)crv.Duplicate();
            this.divLen = divLen;
            this.start = crv.PointAtStart;
            this.startTangent = crv.TangentAtStart;
            double curveLen = crv.GetLength();
            divisions = Convert.ToInt32(Math.Floor(curveLen / divLen)) + 1;

            pointArray = new GH_Point[divisions];
            vectorArray = new GH_Vector[divisions];
            paramArray = new GH_Number[divisions];
            this.targetPath = targetPath;
        }

        public void Divide()
        {
            double[] parArray;// = new double[divisions];
            Point3d[] tempPts;// = new Point3d[divisions];

            if (divisions > 1)
            {
                parArray = crv.DivideByLength(divLen, true, out tempPts);
                if (tempPts != null)
                {
                    for (int i = 0; i < tempPts.Count(); i++)
                    {
                        if (tempPts[i] != null)
                        {
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
                    pointArray = null;
                    paramArray = null;
                    vectorArray = null;
                }
            }
            else
            {
                pointArray = new GH_Point[] { new GH_Point(start) };
                paramArray = new GH_Number[] { new GH_Number(0.0) };
                vectorArray = new GH_Vector[] { new GH_Vector(startTangent)};
            }
        }

        public void AssignTrees(GH_Structure<GH_Point> results, GH_Structure<GH_Vector> tangents, GH_Structure<GH_Number> parameters)
        {
            if (pointArray != null)
            {
                results.AppendRange(pointArray, targetPath);
            }
            else
            {
                results.EnsurePath(targetPath);
            }

            if (paramArray != null)
            {
                parameters.AppendRange(paramArray, targetPath);
            }
            else
            {
                parameters.EnsurePath(targetPath);
            }
            if (vectorArray != null)
            {
                tangents.AppendRange(vectorArray, targetPath);
            }
            else
            {
                tangents.EnsurePath(targetPath);
            }

        }
    }

}