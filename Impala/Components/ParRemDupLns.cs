using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using static Impala.Errors;
using static Impala.Generated;
using static Impala.Utilities;

namespace Impala
{


    public struct LineAndInt
    {
        public Line Line { get; }
        public bool IsFlipped { get; } // Keep track of whether we want to un-flip it.

        public LineAndInt(GH_Line line)
        {
            Line l = line.Value;
            bool flip = l.FromX > l.ToX;
            if (flip)
            {
                l = new Line(l.To, l.From);
            }

            Line = l;
            IsFlipped = flip;
        }

        public GH_Line ToLine()
        {
            return IsFlipped ? new GH_Line(new Line(Line.To, Line.From)) : new GH_Line(Line);
        }
    }

    // Optimised, Parallel LineAndInt Comparer.
    public class LineComparer : IEqualityComparer<LineAndInt>
    {
        private double tolerance;
        private double dLength;

        public LineComparer(double tolerance)
        {
            this.tolerance = tolerance;
            this.dLength = -Math.Log10(tolerance * 2 * Math.Sqrt(3));
            this.tolerance = this.tolerance - this.tolerance + this.tolerance;
        }

        public bool Equals(LineAndInt l1,LineAndInt l2)
        {
            double t = this.tolerance;
            Point3d p1 = l1.Line.From;
            Point3d p2 = l2.Line.From;

            Point3d p3 = l1.Line.To;
            Point3d p4 = l2.Line.To;

            bool b1 = Math.Abs(p1.X - p2.X) < t;
            bool b2 = Math.Abs(p1.Y - p2.Y) < t;
            bool b3 = Math.Abs(p1.Z - p2.Z) < t;
            bool b4 = Math.Abs(p3.X - p4.X) < t;
            bool b5 = Math.Abs(p3.Y - p4.Y) < t;
            bool b6 = Math.Abs(p3.Z - p4.Z) < t;

            bool b7 = b1 && b2 && b3;
            bool b8 = b4 && b5 && b6;
            bool b9 = b7 && b8;
            return b9;
        }

        // Hashcode must always be same when equal (can also be same when !=)
        public int GetHashCode(LineAndInt line)
        {
            return (int) (line.Line.Length * Math.Pow(10,this.dLength)); 
        } 
    }


    /// <summary>
    /// Remove all duplicate lines a set. But quickly!
    /// </summary>
    public class ParRemoveDupLns : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParRemoveDupLns component
        /// </summary>
        public ParRemoveDupLns()
          : base("ParRemDupLns", "ParRemDupLns",
              "Remove duplicate lines.",
              "Impala", "Physical")
        {

        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("Lines", "L", "Lines to remove duplicates from. Each branch is de-duplicated individually.", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Tolerance", "T", "Tolerance within which to remove duplicates", GH_ParamAccess.item, 0.01);
            pManager.AddIntegerParameter("Granularity", "G", "Size of tasked parallel partition. Only affects computation speed.", GH_ParamAccess.item, 1000);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddLineParameter("Lines", "L", "Non-Duplicate Lines", GH_ParamAccess.tree);
        }



        /// <summary>
        /// Loop through data structure. 
        /// </summary>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            int granularity = 0;
            double tolerance = 0.0;
            if (!DA.GetDataTree(0, out GH_Structure<GH_Line> lineTree)) return;
            if (!DA.GetData(1, ref tolerance)) return;
            if (!DA.GetData(2, ref granularity)) return;

            if (granularity <= 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Cannot operate with negative or zero granularity.");
                return;
            }

            if (tolerance < Rhino.RhinoMath.ZeroTolerance)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Cannot operate with subzero tolerance.");
            }

            if (granularity < 100)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Remark, "Granularity very small. Performance may suffer.");
            }


            // Parallelism strategy follows from a few key observations: 
            // a) We can flip all lines so that x1 <= x2. 
            // b) Single-value comparisons are cheap, and good parallel sorts exist for *really* big input sizes. (Further profiling here)
            // c) Two lines that are duplicates will round to either the same integer or one adjacent, minimizing communication time. 
            //    (Actually, we multiply a bunch to distribute the hash values over a wider range, but the principle is there.)
            
            // Therefore: 
            // We pre-process the lines before performing the several floating-point comparisons necessary to actually deduplicate them. 
            // Additionally, we incur less data-structure overhead this way than we would using a hash-set / dictionary containing the
            // entire working set of lines, because of better locality in the problem space.

            var resultTree = new GH_Structure<GH_Line>();
            var debugTree = new GH_Structure<GH_String>();

            for (int i = 0; i < lineTree.Branches.Count; i++)
            {
                resultTree.EnsurePath(lineTree.Paths[i]);
                debugTree.EnsurePath(lineTree.Paths[i]);
            }


            Parallel.For(0, lineTree.Branches.Count, i =>
             {
                 var branch = lineTree.Branches[i];
                 // Preprocess lines.
                 var ppx_lines = branch.Select(l => new LineAndInt(l)).OrderBy(l => l.Line.Length).ToArray();

                 var partitions = (branch.Count / granularity) + 1;
                 var differential = tolerance * 2 * Math.Sqrt(3);

                 HashSet<LineAndInt>[] results = new HashSet<LineAndInt>[partitions];
                 (int,int)[] bounds = new (int,int)[partitions];

                 // Alternatively, perform the partitioning sequence sequentially. Depends if it bottlenecks.
                 Parallel.For(0, partitions, j =>
                 {
                     int minIdx = j * granularity;    
                     int maxIdx = Min(branch.Count, minIdx + granularity);

                     bool eliminateInterval = false;

                     
                     // Forward shift minimum index.
                     if (j > 0)
                     {
                         int tempIdx = minIdx - 1;
                         int upperBound = Min(maxIdx, branch.Count - 1);

                         int k = tempIdx;
                         for (; k < upperBound; k++) // Stop, if necessary.
                         {
                             if (ppx_lines[k+1].Line.Length - ppx_lines[k].Line.Length > differential)
                             {
                                 minIdx = k + 1;
                                 break;
                             }
                         } 

                         if (k == upperBound)
                         {
                             minIdx = upperBound;
                             eliminateInterval = true;
                         }
                     } 
                     
                     // Increment Maximum Index to workable gap
                     if (j < partitions - 1 && !eliminateInterval) // Not for the last partition, or for when min == max.
                     {
                         int tempIdx = maxIdx - 1;
                         int upperBound = branch.Count - 1;

                         int k = tempIdx;
                         for (; k < upperBound; k++) // Stop, if necessary.
                         {
                             if (ppx_lines[k + 1].Line.Length - ppx_lines[k].Line.Length > differential)
                             {
                                 maxIdx = k + 1;
                                 break;
                             }
                         }

                         if (k == upperBound) // We looped through everything and increased the max IDX.
                         {
                             maxIdx = branch.Count;
                         }

                     }

                     bounds[j] = (minIdx, maxIdx);
                     
                     var dumpset = new HashSet<LineAndInt>(new LineComparer(tolerance));

                     if (!eliminateInterval) // Extra borderline cases in last partition.
                     {
                         for (int k = minIdx; k < maxIdx; k++)
                         {
                             dumpset.Add(ppx_lines[k]);
                         }
                     }

                     results[j] = dumpset; // This mostly deduplicates. Let's see how it works.
                 });


                 for (int j = 0; j < partitions; j++)
                 {
                     resultTree.AppendRange(results[j].Select(l => l.ToLine()), lineTree.Paths[i]);
                     //debugTree.AppendRange(results[j].Select(_ => new GH_String($"{j}, {bounds[j]}")),lineTree.Paths[i]);
                 }

             });


            DA.SetDataTree(0, resultTree);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null; 
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("2E582DF4-8985-4DC0-935A-2763912B4054"); }
        }
    }


    /// <summary>
    /// Remove all duplicate lines a set. But slowly!
    /// </summary>
    public class SeqRemoveDupLns : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ParRemoveDupLns component
        /// </summary>
        public SeqRemoveDupLns()
          : base("SeqRemDupLns", "SeqRemDupLns",
              "Remove duplicate lines.",
              "Impala", "Test")
        {

        }

        // For sequential benching only
        class SeqLineEqComp : IEqualityComparer<Line>
        {
            private double tol;

            public SeqLineEqComp(double tolerance)
            {
                tol = tolerance;
            }

            public bool Equals(Line l1, Line l2)
            {
                return ((OrthoClose(l1.From, l2.From, tol) &&
                         OrthoClose(l1.To, l2.To, tol)) ||
                        (OrthoClose(l1.To, l2.From, tol) &&
                         OrthoClose(l1.From, l2.To, tol)));
            }

            public int GetHashCode(Line line)
            {
                return 0;
            }

            public static bool OrthoClose(Point3d Point1, Point3d Point2, double t)
            {
                return (Math.Abs(Point1.X - Point2.X) < t && Math.Abs(Point1.Y - Point2.Y) < t && Math.Abs(Point1.Z - Point2.Z) < t); 
            }
        }


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("Lines", "L", "Lines to remove duplicates from. Each branch is de-duplicated individually.", GH_ParamAccess.list);
            pManager.AddNumberParameter("Tolerance", "T", "Tolerance within which to remove duplicates", GH_ParamAccess.item, 0.01);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddLineParameter("Lines", "L", "Non-Duplicate Lines", GH_ParamAccess.tree);
        }

        /// <summary>
        /// Loop through data structure. 
        /// </summary>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            double tolerance = 0.0;
            var lineList = new List<Line>();
            if (!DA.GetDataList(0, lineList)) return;
            if (!DA.GetData(1, ref tolerance)) return;
         
                
            DA.SetDataList(0, lineList.Distinct(new SeqLineEqComp(tolerance)).ToList());
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("F3515037-970A-49FB-BCE9-DA0EC9E0859F"); }
        }
    }


}