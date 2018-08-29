using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino.Geometry;

using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

namespace Impala
{
    public static class Utilities
    {
        public static int Max(params int[] nums)
        {
            return nums.Max();
        }

        public static int Min(params int[] nums)
        {
            return nums.Min();
        }

        public static IEnumerable<int> IRange(int start, int end)
        {
            return Enumerable.Range(start, end - start);
        }

        public static IEnumerable<Q> SelEach<T, Q>(this IEnumerable<T> collection, Func<T, int, Q> action)
        {
            int i = 0;
            var result = new List<Q>();
            foreach (var item in collection)
            {
                result.Add(action(item, i));
                i++;
            }
            return result;
        }

        public static T[] Array<T>(params T[] items)
        {
            return items;
        }

        public static double[] PtToArray(GH_Point ghpt)
        {
            return PtToArray(ghpt.Value);
        }

        public static double[] PtToArray(Point3d pt)
        {
            return new double[] { pt.X, pt.Y, pt.Z };
        }

        public static Point3d PtFromArray(double[] array)
        {
            return new Point3d(array[0], array[1], array[2]);
        }

        #region PathTools
        /// <summary>
        /// Creates the list of target paths for the looping logic. 
        /// </summary>
        /// <param name="structures"> Input structures to analyze </param>
        /// <returns>The paths of the structure that serve as the base of the output</returns>
        public static List<GH_Path> GetPathList(params IGH_Structure[] structures)
        {
            var lenList = (from structure in structures select structure.get_Path(structure.LongestPathIndex()).Length).ToList();
            List<GH_Path> PathList = new List<GH_Path>();

            int maxLen = 0;
            for (int i = 0; i < structures.Length; i++)
            {
                if (lenList[i] > maxLen)
                {
                    maxLen = lenList[i];
                    PathList.Clear();
                    PathList.AddRange(structures[i].Paths);
                }
            }
            return PathList;
        }

        /// <summary>
        /// Fetches a path from the path list, and creates it if there is no existing path at this index.
        /// </summary>
        /// <param name="paths"> List of paths generated from GetPathList </param>
        /// <param name="i"> Desired path index </param>
        /// <returns> Path at that index </returns>
        public static GH_Path GetPath(List<GH_Path> paths, int i)
        {
            GH_Path path = new GH_Path();
            if (i < paths.Count)
            {
                path = new GH_Path(paths[i]);
            }
            else
            {
                path = paths[paths.Count - 1].Increment(path.Length - 1, (i - paths.Count) + 1);
            }
            return path;
        }

        /// <summary>
        /// Partition a tree structure intersection into segments of branch ranges based on granularity. (Binary parallel)
        /// </summary>
        public static (int, int)[] GetPartitions<T, Q>(GH_Structure<T> a, GH_Structure<Q> b, int granularity)
            where T : IGH_Goo
            where Q : IGH_Goo
        {
            var parts = Max(a.DataCount, b.DataCount) / granularity;
            if (parts < 2) return new (int, int)[] { (0, Max(a.Branches.Count - 1, b.Branches.Count - 1)) };

            var PathLengths = new List<int>();
            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            for (int i = 0; i < maxbranch; i++)
            {
                PathLengths.Add(Math.Max(a[Math.Min(a.Branches.Count - 1, i)].Count,
                                         b[Math.Min(b.Branches.Count - 1, i)].Count));
            }
            var partitions = new List<(int, int)>();

            var prevIdx = 0;
            var tempGran = 0;
            for (int i = 0; i < PathLengths.Count; i++)
            {
                tempGran += PathLengths[i];
                if (tempGran > granularity)
                {
                    partitions.Add((prevIdx, i));
                    prevIdx = i + 1;
                    tempGran = 0;
                }
            }
            var lastIdx = partitions[partitions.Count - 1].Item2;
            if (lastIdx < maxbranch - 1)
            {
                partitions.Add((lastIdx + 1, maxbranch - 1));
            }

            return partitions.ToArray();
        }

        /// <summary>
        /// Fetch partitions of a single tree with a specified granularity (for unary parallel operators)
        /// </summary>
        public static (int, int)[] GetPartitions1D<T>(GH_Structure<T> a, int granularity)
            where T : IGH_Goo
        {
            var PathLengths = a.Branches.Select(br => br.Count).ToList();
            var partitions = new List<(int, int)>();
            var parts = a.DataCount / granularity;
            if (parts < 2) return new (int, int)[] { (0, a.Branches.Count - 1) };

            var prevIdx = 0;
            var tempGran = 0;
            for (int i = 0; i < PathLengths.Count; i++)
            {
                tempGran += PathLengths[i];
                if (tempGran > granularity)
                {
                    partitions.Add((prevIdx, i));
                    prevIdx = i + 1;
                    tempGran = 0;
                }
            }
            var lastIdx = partitions[partitions.Count - 1].Item2;
            var maxbranch = a.Branches.Count;
            if (lastIdx < maxbranch - 1)
            {
                partitions.Add((lastIdx + 1, maxbranch - 1));
            }

            return partitions.ToArray();
        }


        #endregion
    }
}
