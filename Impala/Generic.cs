using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using static Impala.Utilities;

namespace Impala
{

    /// <summary>
    /// Collection of static generic methods that operate on GH_Structures and 
    /// provide built-in looping and parallel functionality.
    /// </summary>
    public static class Generic
    {
        #region Converters
        /// <summary>
        /// Helper conversion delegate to use in the DuplicateCast method to be able to operate generically on GH_Structures
        /// </summary>
        public static IGH_Goo Gooify<T>(T data)
            where T : IGH_Goo
        {
            return data;
        }

        public static GH_Point GooToPoint(IGH_Goo data)
        {
            return (GH_Point)data;
        }

        public static GH_Integer GooToInt(IGH_Goo data)
        {
            return (GH_Integer)data;
        }

        public static GH_Boolean GooToBool(IGH_Goo data)
        {
            return (GH_Boolean) data;
        }

        /// <summary>
        /// Like GH_Structure.DuplicateCast(), but it works.
        /// </summary>
        public static GH_Structure<Q> DupCast<T, Q>(GH_Structure<T> structure, Func<T, Q> cast)
            where T : IGH_Goo where Q : IGH_Goo
        {
            var res = new GH_Structure<Q>();
            for (int i = 0; i < structure.PathCount; i++)
            {
                res.AppendRange(structure.Branches[i].Select(item => cast(item)), structure.Paths[i]);
            }
            return res;
        }

        #endregion

        #region ZipFunctions

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



        public static void DoEach<T>(this IEnumerable<T> collection, Action<T,int> action)
        {
            int i = 0; 
            foreach(var item in collection)
            {
                action(item,i); i++;
            }
        }

        public static void DoEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }


        /// <summary>
        /// Applies GH's looping in a 2->1 scenario with both per-branch and per-list parallelism.
        /// Does not use partitions
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

        #endregion

        #region SequentialBasic
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

        
        /// <summary>
        /// Grafts a standard list into a tree.
        /// </summary>
        public static GH_Structure<T> GraftList<T>(IEnumerable<T> source)
            where T : IGH_Goo
        {
            var result = new GH_Structure<T>();
            int i = 0;
            foreach(var item in source)
            {
                result.Append(item, new GH_Path(i));
                i++;
            }
            return result;
        }

        /// <summary>
        /// Grafts a standard tree.
        /// </summary>
        public static GH_Structure<T> GraftStructure<T>(this GH_Structure<T> source)
            where T : IGH_Goo 
        {
            var result = new GH_Structure<T>();
            for(int i = 0; i < source.Branches.Count; i++)
            {
                var path = source.Paths[i];
                var branch = source.Branches[i];
                for(int j = 0; j < branch.Count; j++)
                {
                    result.Append(branch[j], path.AppendElement(j));
                }
            }
            return result;
        }



        #endregion

        #region GranularityControlled
        /// <summary>
        /// Reductions that aggregate an entire list of elements into one (ex: avg, bounds)
        /// </summary>
        public static GH_Structure<Q> ParallelReduceStructure<T, Q>(GH_Structure<T> init, Func<List<T>, Q> action, ErrorChecker<List<T>> error, int granularity, int branchGranularity)
            where T : IGH_Goo
            where Q : IGH_Goo
        {
            var result = new GH_Structure<Q>();
            var partitions = PartitionItems1D(init, granularity);
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

        /// <summary>
        /// Applies a function with a specified granularity (number of items per parallel branch) 
        /// </summary>
        public static GH_Structure<Q> MapStructureParallel<T, Q>(GH_Structure<T> init, Func<T, Q> action, ErrorChecker<T> error, int granularity, int branchGranularity)
            where T : IGH_Goo
            where Q : IGH_Goo
        {
            var result = new GH_Structure<Q>();
            var partitions = Partition(init, granularity, branchGranularity);           

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
        /// Applies GH's looping in a 2->1 scenario with the outer level (per-branch) parallelised
        /// Uses Partitions
        /// </summary>
        public static GH_Structure<R> ZipMaxParallel1D<T, Q, R>(GH_Structure<T> a, GH_Structure<Q> b, Func<T, Q, R> action, ErrorChecker<(T, Q)> error, int granularity, int branchGranularity)
            where T : IGH_Goo
            where Q : IGH_Goo
            where R : IGH_Goo
        {
            var result = new GH_Structure<R>();
            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var partitions = Partition(a, b, granularity, branchGranularity);

            var paths = PathList2(a, b);
            
            for (int i = 0; i < maxbranch; i++)
            {
                result.EnsurePath(paths[i]);
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
                        if (maxlen > 1)
                        {
                            R[] temp = new R[maxlen];
                            for (int j = 0; j < maxlen; j++)
                            {
                                T ax = ba[Math.Min(ba.Count - 1, j)];
                                Q bx = bb[Math.Min(bb.Count - 1, j)];
                                temp[j] = error.Validate((ax, bx)) ? action(ax, bx) : default;
                            }
                            result.AppendRange(temp,paths[i]);
                        }
                        else
                        {
                            T ax = ba[0];
                            Q bx = bb[0];
                            R res = error.Validate((ax, bx)) ? action(ax, bx) : default;
                            result.Append(res, paths[i]);
                        }
                    }
                }
            });
            return result;
        }

        #endregion

        #region Generators
        /// <summary>
        /// Applies datatree matching logic using a generator as opposed to arrays. This is usually slower.
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

        #endregion
    }
}
