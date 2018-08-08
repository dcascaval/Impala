using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

namespace Impala
{

    /// <summary>
    /// Collection of static generic methods that operate on GH_Structures and 
    /// provide built-in looping and parallel functionality.
    /// </summary>
    public static class Generic
    {
        /// <summary>
        /// Creates the list of target paths for the looping logic. 
        /// </summary>
        /// <param name="structures"> Input structures to analyze </param>
        /// <returns>The paths of the structure that serve as the base of the output</returns>
        static List<GH_Path> GetPathList(params IGH_Structure[] structures)
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
        static private GH_Path GetPath(List<GH_Path> paths, int i)
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
        /// Super-Generic N x M, Dual-Parallel zip.
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="action"></param>
        /// <param name="error"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static GH_Structure<IGH_Goo>[] ZipMaxN(GH_Structure<IGH_Goo>[] inputs, Func<IGH_Goo[],IGH_Goo[]> action, ErrorChecker<IGH_Goo[]> error, int output)
        {
            var opLen = Enumerable.Range(0, output);
            GH_Structure<IGH_Goo>[] results = opLen.Select(_ => new GH_Structure<IGH_Goo>()).ToArray();
            var maxbranch = inputs.Select(i => i.Branches.Count).Max();
            var prePaths = GetPathList(inputs);
            var paths = Enumerable.Range(0, maxbranch).Select(i => GetPath(prePaths, i)).ToArray();

            for (int i = 0; i < maxbranch; i++) // Reverse this ?
            {
                for (int k = 0; k < output; k++)
                {
                    results[k].EnsurePath(paths[i]);
                }
            }

            Parallel.For(0, maxbranch, i =>
            {
                var path = paths[i];
                var branches = inputs.Select(inp => inp.Branches[Math.Min(i, inp.Branches.Count - 1)]);
                var branchlens = branches.Select(br => br.Count);
                if (branchlens.Min() > 0)
                {
                    var maxlen = branchlens.Max();
                    var resultbranches = opLen.Select(_ => new IGH_Goo[maxlen]).ToArray();
                    Parallel.For(0, maxlen, j =>
                    {
                        var args = (from br in branches select br[Math.Min(j, br.Count - 1)]).ToArray();
                        IGH_Goo[] calc = error.Validate(args) ? action(args) : opLen.Select(_ => default(IGH_Goo)).ToArray();
                        for (int k = 0; k < calc.Length; k++)   // K branches of J length each
                        {
                            resultbranches[k][j] = calc[k];
                        }
                    });
                    for (int k = 0; k < resultbranches.Length; k++)
                    {
                        results[k].AppendRange(resultbranches[k], path);
                    }
                }
            });

            return results;
        }

        /// <summary>
        /// Applies GH's default tree matching logic when applying an action that takes in two datatrees and outputs one.
        /// </summary>
        public static GH_Structure<R> ZipMaxManual<T, Q, R>(GH_Structure<T> a, GH_Structure<Q> b, Func<T, Q, R> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo
            where Q : IGH_Goo
            where R : IGH_Goo
        {
            var result = new GH_Structure<R>();
            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var paths = GetPathList(a, b);

            for (int i = 0; i < maxbranch; i++)
            {
                var ba = a.Branches[Math.Min(i, a.Branches.Count - 1)];
                var bb = b.Branches[Math.Min(i, b.Branches.Count - 1)];
                if (ba.Count > 0 && bb.Count > 0)
                {
                    int maxlen = Math.Max(ba.Count, bb.Count);
                    R[] temp = new R[maxlen];
                    for (int j = 0; j < maxlen; j++)
                    {
                        T ax = ba[Math.Min(ba.Count - 1, j)];
                        Q bx = bb[Math.Min(bb.Count - 1, j)];
                        // Check and input
                        temp[j] = error.Validate((ax, bx)) ? action(ax, bx) : default;
                    }
                    result.AppendRange(temp,GetPath(paths,i));
                }
                else
                {
                    result.EnsurePath(GetPath(paths, i));
                }
            }
            return result;
        }

        /// <summary>
        /// Helper conversion delegate to use in the DuplicateCast method to be able to operate generically on GH_Structures
        /// </summary>
        public static IGH_Goo Gooify<T>(T data)
            where T : IGH_Goo
        {
            return data;
        }

        /// <summary>
        /// Applies GH's default tree matching logic when applying an action that takes and outputs 3 datatrees. 
        /// This is about the limit at which manually defining the structure is still viable.
        /// Both levels (per-branch and per-list) are parallelised.
        /// </summary>
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) ZipMaxTree3x3 <T, Q, R, A, B, C>(GH_Structure<T> a, 
            GH_Structure<Q> b, GH_Structure<R> c, Func<T, Q, R, (A,B,C)> action, ErrorChecker<(T, Q, R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {

            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            //GH_Structure<IGH_Goo>[] results = { result1.DuplicateCast(Gooify), result2.DuplicateCast(Gooify), result3.DuplicateCast(Gooify) };

            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var paths = GetPathList(a, b);

            for(int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths, i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath); 
            }

            //Dual nested Parallel Loops! Chunky. 
            Parallel.For(0, maxbranch, i =>
            {
               var targpath = GetPath(paths, i);
               var ba = a.Branches[Math.Min(i, a.Branches.Count - 1)];
               var bb = b.Branches[Math.Min(i, b.Branches.Count - 1)];
               var bc = c.Branches[Math.Min(i, c.Branches.Count - 1)];
               if (ba.Count > 0 && bb.Count > 0 && bc.Count > 0)
               {
                   int maxlen = Math.Max(Math.Max(ba.Count, bb.Count), bc.Count);
                   (A, B, C)[] temp = new(A, B, C)[maxlen];
                    Parallel.For(0, maxlen, j =>
                    {
                        T ax = ba[Math.Min(ba.Count - 1, j)];
                        Q bx = bb[Math.Min(bb.Count - 1, j)];
                        R cx = bc[Math.Min(bc.Count - 1, j)];
                        // Check and input
                        temp[j] = error.Validate((ax, bx, cx)) ? action(ax, bx, cx) : default;
                    });

                   result1.AppendRange(from item in temp select item.Item1, targpath);
                   result2.AppendRange(from item in temp select item.Item2, targpath);
                   result3.AppendRange(from item in temp select item.Item3, targpath);
               }
            });

            return (result1,result2,result3);
        }
        public static (int, int)[] GetPartitions<T, Q>(GH_Structure<T> a, GH_Structure<Q> b, int granularity)
            where T : IGH_Goo
            where Q : IGH_Goo
        {
            var parts = Math.Min(a.DataCount,b.DataCount) / granularity;
            if (parts < 2) return new(int, int)[] { (0, a.Branches.Count - 1) };

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
            if (prevIdx < PathLengths.Count - 1)
            {
                partitions.Add((prevIdx, PathLengths.Count - 1));
            }

            return partitions.ToArray();
        }


        /// <summary>
        /// Applies GH's looping in a 2->1 scenario with the outer level (per-branch) parallelised.
        /// </summary>
        public static GH_Structure<R> ZipMaxParallel1D<T, Q, R>(GH_Structure<T> a, GH_Structure<Q> b, Func<T, Q, R> action, ErrorChecker<(T, Q)> error, int granularity)
            where T : IGH_Goo
            where Q : IGH_Goo
            where R : IGH_Goo
        {
            var result = new GH_Structure<R>();
            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var partitions = GetPartitions(a, b, granularity);

            var paths = GetPathList(a, b);
            for (int i = 0; i < maxbranch; i++)
            {
                result.EnsurePath(GetPath(paths, i));
            }
            Parallel.For(0, partitions.Length, p =>
            {
                var part = partitions[p];
                for (int i = part.Item1; i <= part.Item2; i++)
                {
                    var ba = a.Branches[Math.Min(i, a.Branches.Count - 1)];
                    var bb = b.Branches[Math.Min(i, b.Branches.Count - 1)];
                    if (ba.Count > 0 && bb.Count > 0)
                    {
                        int maxlen = Math.Max(ba.Count, bb.Count);
                        R[] temp = new R[maxlen];
                        for (int j = 0; j < maxlen; j++)
                        {
                            T ax = ba[Math.Min(ba.Count - 1, j)];
                            Q bx = bb[Math.Min(bb.Count - 1, j)];
                            temp[j] = error.Validate((ax, bx)) ? action(ax, bx) : default;
                        }
                        result.AppendRange(temp, GetPath(paths, i));
                    }
                }
            });
            return result;
        }

        /// <summary>
        /// Applies GH's looping in a 2->1 scenario with both per-branch and per-list parallelism.
        /// </summary>
        public static GH_Structure<R> ZipMaxParallel2D<T, Q, R>(GH_Structure<T> a, GH_Structure<Q> b, Func<T, Q, R> action)
            where T : IGH_Goo
            where Q : IGH_Goo
            where R : IGH_Goo
        {
            var result = new GH_Structure<R>();
            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var paths = GetPathList(a, b);
            for (int i = 0; i < maxbranch; i++)
            {
                result.EnsurePath(GetPath(paths, i));
            }
            Parallel.For(0, maxbranch, i =>
            {
                var ba = a.Branches[Math.Min(i, a.Branches.Count - 1)];
                var bb = b.Branches[Math.Min(i, b.Branches.Count - 1)];
                if (ba.Count > 0 && bb.Count > 0)
                {
                    int maxlen = Math.Max(ba.Count, bb.Count);
                    R[] temp = new R[maxlen];
                    Parallel.For(0, maxlen, j =>
                    {
                        T ax = ba[Math.Min(ba.Count - 1, j)];
                        Q bx = bb[Math.Min(bb.Count - 1, j)];
                        temp[j] = action(ax, bx);
                    });
                    result.AppendRange(temp, GetPath(paths, i));
                }
            });
            return result;
        }


        /// <summary>
        /// Applies standard functional zip to GH_Structure types, trimming unused elements.
        /// </summary>
        public static GH_Structure<R> ZipTree<T, Q, R>(GH_Structure<T> a, GH_Structure<Q> b, Func<T, Q, R> action)
            where T : IGH_Goo
            where Q : IGH_Goo
            where R : IGH_Goo
        {
            var result = new GH_Structure<R>();
            var minBranch = Math.Min(a.Branches.Count, b.Branches.Count);
            for (int i = 0; i < minBranch; i++)
            {
                var ba = a.Branches[i];
                var bb = b.Branches[i];
                result.AppendRange(ba.Zip(bb, action));
            }
            return result;
        }

        /// <summary>
        /// Applies a function to every element in a tree without modifying its structure.
        /// </summary>
        public static GH_Structure<Q> MapStructure<T, Q>(GH_Structure<T> init, Func<T, Q> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where Q : IGH_Goo
        {
            var result = new GH_Structure<Q>();
            for (int i = 0; i < init.Branches.Count; i++)
            {
                result.AppendRange(init.Branches[i].Select(x => error.Validate(x) ? action(x) : default), init.Paths[i]);
            }
            return result;
        }


        public static GH_Structure<Q> ReduceStructure<T, Q>(GH_Structure<T> init, Func<List<T>, Q> action, ErrorChecker<List<T>> error, int granularity)
            where T : IGH_Goo
            where Q : IGH_Goo
        {
            var result = new GH_Structure<Q>();
            var partitions = GetPartitions1D(init, granularity);
            for (int i = 0; i < init.Branches.Count; i++)
            {
                result.EnsurePath(init.Paths[i]);
            }

            Parallel.For(0, partitions.Length, i =>
            {
                var partition = partitions[i];
                for (int j = partition.Item1; j <= partition.Item2; j++)
                {
                    var x = init.Branches[j];
                    if (error.Validate(x))
                    {
                        result.Append(action(x), init.Paths[j]);
                    }
                }
            });

            return result;
        }

        public static (int, int)[] GetPartitions1D<T>(GH_Structure<T> a, int granularity)
            where T : IGH_Goo
        {
            var PathLengths = a.Branches.Select(br => br.Count).ToList();
            var partitions = new List<(int, int)>();
            var parts = a.DataCount / granularity;
            if (parts < 2) return new(int, int)[] { (0, a.Branches.Count - 1) };

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
            if (prevIdx < PathLengths.Count - 1)
            {
                partitions.Add((prevIdx, PathLengths.Count - 1));
            }

            return partitions.ToArray();
        }

        /// <summary>
        /// Applies a function with a specified granularity (number of items per parallel branch) 
        /// </summary>
        public static GH_Structure<Q> MapStructureParallel<T, Q>(GH_Structure<T> init, Func<T, Q> action, ErrorChecker<T> error, int granularity)
            where T : IGH_Goo
            where Q : IGH_Goo
        {
            var result = new GH_Structure<Q>();
            var partitions = GetPartitions1D(init, granularity);           

            for (int i = 0; i < init.Branches.Count; i++)
            {
                result.EnsurePath(init.Paths[i]);
            }

            Parallel.For(0, partitions.Length, i =>
            {
                var partition = partitions[i];
                for (int j = partition.Item1; j <= partition.Item2; j++)
                {
                    result.AppendRange(init.Branches[j].Select(x => error.Validate(x) ? action(x) : default), init.Paths[j]);
                }
            });

            return result;
        }

        /// <summary>
        /// Aapplies GH's default tree matching logic when applying an action that takes in two datatrees. 
        /// </summary>
        public static GH_Structure<R> ZipMaxAuto<T, Q, R>(GH_Structure<T> a, GH_Structure<Q> b, Func<T, Q, R> action)
            where T : IGH_Goo
            where Q : IGH_Goo
            where R : IGH_Goo
        {
            var result = new GH_Structure<R>();
            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var paths = GetPathList(a, b);
            for (int i = 0; i < maxbranch; i++)
            {
                var ba = a.Branches[Math.Min(i, a.Branches.Count - 1)];
                var bb = b.Branches[Math.Min(i, b.Branches.Count - 1)];
                if (ba.Count > 0 && bb.Count > 0)
                {
                    var temp = ZipListMax(ba, bb, action);
                    var targ = GetPath(paths, i);
                    result.AppendRange(temp, targ);
                }
                else
                {
                    result.EnsurePath(GetPath(paths, i));
                }
            }
            return result;
        }

        // This is sadly less effective than the manual array allocation.
        // Todo: bench this on long lists and lots of short ones
        private static IEnumerable<R> ZipListMax<T, Q, R>(List<T> a, List<Q> b, Func<T, Q, R> action)
        {
            int maxlen = Math.Max(a.Count, b.Count);
            for (int i = 0; i < maxlen; i++)
            {
                T ax = a[Math.Min(a.Count - 1, i)];
                Q bx = b[Math.Min(b.Count - 1, i)];
                yield return action(ax, bx);
            }
        }
    }
}
