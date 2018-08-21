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
        /// Super-Generic N x M, Dual-Parallel zip. This is unfortunately half the speed of the manually defined zip.
        /// </summary>
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
        /// Applies GH's default tree matching logic when applying an action that takes and outputs 3 datatrees. 
        /// This is about the limit at which manually defining the structure is still viable.
        /// Both levels (per-branch and per-list) are parallelised.
        /// </summary>
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>) ZipMaxTree3x3<T, Q, R, A, B, C>(GH_Structure<T> a,
            GH_Structure<Q> b, GH_Structure<R> c, Func<T, Q, R, (A, B, C)> action, ErrorChecker<(T, Q, R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {

            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();

            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var paths = GetPathList(a, b);

            for (int i = 0; i < maxbranch; i++)
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

            return (result1, result2, result3);
        }


        public static (GH_Structure<A>,GH_Structure<B>, GH_Structure<C>,GH_Structure<D>) Zip2Red1x4<T,Q,R,A,B,C,D>
           (GH_Structure<T> a, GH_Structure<Q> b, GH_Structure<R> redux, Func<T, Q, List<R>, (A, B, C, D)> action, ErrorChecker<(T, Q, List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();

            var maxbranch = Max(a.Branches.Count, b.Branches.Count, redux.Branches.Count);
            var paths = GetPathList(a, b);

            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths, i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }

            //Dual nested Parallel Loops! Chunky. 
            Parallel.For(0, maxbranch, i =>
            {
                var targpath = GetPath(paths, i);
                var ba = a.Branches[Math.Min(i, a.Branches.Count - 1)];
                var bb = b.Branches[Math.Min(i, b.Branches.Count - 1)];
                var bc = redux.Branches[Math.Min(i, redux.Branches.Count - 1)];
                if (ba.Count > 0 && bb.Count > 0 && bc.Count > 0)
                {
                    int maxlen = Math.Max(Math.Max(ba.Count, bb.Count), bc.Count);
                    (A, B, C, D)[] temp = new(A, B, C, D)[maxlen];
                    Parallel.For(0, maxlen, j =>
                    {
                        T ax = ba[Math.Min(ba.Count - 1, j)];
                        Q bx = bb[Math.Min(bb.Count - 1, j)];
                        // Check and input
                        temp[j] = error.Validate((ax, bx, bc)) ? action(ax, bx, bc) : default;
                    });

                    result1.AppendRange(temp.Select(x=> x.Item1), targpath);
                    result2.AppendRange(temp.Select(x=> x.Item2), targpath);
                    result3.AppendRange(temp.Select(x=> x.Item3), targpath);
                    result4.AppendRange(temp.Select(x=> x.Item4), targpath);
                }
            });

            return (result1, result2, result3,result4);
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


        public static GH_Structure<IGH_Goo>[] ZipMaxTree3xN<T, Q, R>(GH_Structure<T> a, GH_Structure<Q> b, GH_Structure<R> c, 
                                                       Func<T, Q, R, IGH_Goo[]> action, ErrorChecker<(T, Q, R)> error, int n)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
        {
            var opLen = Enumerable.Range(0, n);
            var result = opLen.Select(_ => new GH_Structure<IGH_Goo>()).ToArray();

            var maxbranch = Math.Max(a.Branches.Count, b.Branches.Count);
            var paths = GetPathList(a, b);

            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths, i);
                opLen.DoEach(j => result[j].EnsurePath(targpath));
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
                    var resultbranches = opLen.Select(_ => new IGH_Goo[maxlen]).ToArray();
                    Parallel.For(0, maxlen, j =>
                    {
                        T ax = ba[Math.Min(ba.Count - 1, j)];
                        Q bx = bb[Math.Min(bb.Count - 1, j)];
                        R cx = bc[Math.Min(bc.Count - 1, j)];
                        // Check and input
                        IGH_Goo[] calc = error.Validate((ax, bx, cx)) ? action(ax, bx, cx) : default;
                        for (int k = 0; k < calc.Length; k++)   // K branches of J length each
                        {
                            resultbranches[k][j] = calc[k];
                        }
                    });
                    for (int k = 0; k < n; k++)
                    {
                        result[k].AppendRange(resultbranches[k],targpath);
                    }
                }
            });

            return result;
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

        #endregion

        #region GranularityControlled
        /// <summary>
        /// Reductions that aggregate an entire list of elements into one (ex: avg, bounds)
        /// </summary>
        public static GH_Structure<Q> ParallelReduceStructure<T, Q>(GH_Structure<T> init, Func<List<T>, Q> action, ErrorChecker<List<T>> error, int granularity)
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
        /// Applies GH's looping in a 2->1 scenario with the outer level (per-branch) parallelised
        /// Uses Partitions
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
