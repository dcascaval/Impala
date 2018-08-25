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
    ///<summary>
    /// THESE METHODS ARE ENTIRELY GENERATED.
    /// Any changes made to this file will be overwritten when it is regenerated.
    /// To make any changes, modify the code in the ImpalaMethodGenerator project.
    ///</summary>
    public static class Generated
    {
        
        public static GH_Structure<A>Red1x1<T,A>
        (GH_Structure<T> redux_t, Func<List<T>,A> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Red1xGraft1<T,A>
        (GH_Structure<T> redux_t, Func<List<T>,A[]> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Red1x2<T,A,B>
        (GH_Structure<T> redux_t, Func<List<T>,(A, B)> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Red1xGraft2<T,A,B>
        (GH_Structure<T> redux_t, Func<List<T>,(A[], B[])> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Red1x3<T,A,B,C>
        (GH_Structure<T> redux_t, Func<List<T>,(A, B, C)> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Red1xGraft3<T,A,B,C>
        (GH_Structure<T> redux_t, Func<List<T>,(A[], B[], C[])> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Red1x4<T,A,B,C,D>
        (GH_Structure<T> redux_t, Func<List<T>,(A, B, C, D)> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Red1xGraft4<T,A,B,C,D>
        (GH_Structure<T> redux_t, Func<List<T>,(A[], B[], C[], D[])> action, ErrorChecker<List<T>> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(redux_t.Branches.Count);
            var paths = GetPathList(redux_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate(rxbranchredux_t) ? action(rxbranchredux_t) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Red2x1<T,Q,A>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,A> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Red2xGraft1<T,Q,A>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,A[]> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Red2x2<T,Q,A,B>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,(A, B)> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Red2xGraft2<T,Q,A,B>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,(A[], B[])> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Red2x3<T,Q,A,B,C>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,(A, B, C)> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Red2xGraft3<T,Q,A,B,C>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,(A[], B[], C[])> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Red2x4<T,Q,A,B,C,D>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,(A, B, C, D)> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Red2xGraft4<T,Q,A,B,C,D>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, Func<List<T>,List<Q>,(A[], B[], C[], D[])> action, ErrorChecker<(List<T>,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(redux_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q)) ? action(rxbranchredux_t, rxbranchredux_q) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Red3x1<T,Q,R,A>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,A> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Red3xGraft1<T,Q,R,A>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,A[]> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Red3x2<T,Q,R,A,B>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,(A, B)> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Red3xGraft2<T,Q,R,A,B>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,(A[], B[])> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Red3x3<T,Q,R,A,B,C>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,(A, B, C)> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Red3xGraft3<T,Q,R,A,B,C>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,(A[], B[], C[])> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Red3x4<T,Q,R,A,B,C,D>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,(A, B, C, D)> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        temp[j] = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Red3xGraft4<T,Q,R,A,B,C,D>
        (GH_Structure<T> redux_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<List<T>,List<Q>,List<R>,(A[], B[], C[], D[])> action, ErrorChecker<(List<T>,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(redux_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(redux_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                int maxlen = Max();
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var rxbranchredux_t = redux_t.Branches[Math.Min(i, redux_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (rxbranchredux_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max();
                    Parallel.For(0,maxlen,j =>
                    {
                        var compute = error.Validate((rxbranchredux_t, rxbranchredux_q, rxbranchredux_r)) ? action(rxbranchredux_t, rxbranchredux_q, rxbranchredux_r) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip1x1<T,A>
        (GH_Structure<T> zip_t, Func<T,A> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate(zip_tx) ? action(zip_tx) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip1xGraft1<T,A>
        (GH_Structure<T> zip_t, Func<T,A[]> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate(zip_tx) ? action(zip_tx) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1x2<T,A,B>
        (GH_Structure<T> zip_t, Func<T,(A, B)> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate(zip_tx) ? action(zip_tx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1xGraft2<T,A,B>
        (GH_Structure<T> zip_t, Func<T,(A[], B[])> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate(zip_tx) ? action(zip_tx) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1x3<T,A,B,C>
        (GH_Structure<T> zip_t, Func<T,(A, B, C)> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate(zip_tx) ? action(zip_tx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1xGraft3<T,A,B,C>
        (GH_Structure<T> zip_t, Func<T,(A[], B[], C[])> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate(zip_tx) ? action(zip_tx) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1x4<T,A,B,C,D>
        (GH_Structure<T> zip_t, Func<T,(A, B, C, D)> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate(zip_tx) ? action(zip_tx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1xGraft4<T,A,B,C,D>
        (GH_Structure<T> zip_t, Func<T,(A[], B[], C[], D[])> action, ErrorChecker<T> error)
            where T : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count);
            var paths = GetPathList(zip_t);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                if (branchzip_t.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate(zip_tx) ? action(zip_tx) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip1Red1x1<T,Q,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,A> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip1Red1xGraft1<T,Q,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,A[]> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1Red1x2<T,Q,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,(A, B)> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1Red1xGraft2<T,Q,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,(A[], B[])> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1Red1x3<T,Q,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,(A, B, C)> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1Red1xGraft3<T,Q,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,(A[], B[], C[])> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1Red1x4<T,Q,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,(A, B, C, D)> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1Red1xGraft4<T,Q,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, Func<T,List<Q>,(A[], B[], C[], D[])> action, ErrorChecker<(T,List<Q>)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count);
            var paths = GetPathList(zip_t, redux_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q)) ? action(zip_tx, rxbranchredux_q) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip1Red2x1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,A> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip1Red2xGraft1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,A[]> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1Red2x2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,(A, B)> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1Red2xGraft2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,(A[], B[])> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1Red2x3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,(A, B, C)> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1Red2xGraft3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,(A[], B[], C[])> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1Red2x4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,(A, B, C, D)> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1Red2xGraft4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<T,List<Q>,List<R>,(A[], B[], C[], D[])> action, ErrorChecker<(T,List<Q>,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip1Red3x1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,A> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip1Red3xGraft1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,A[]> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1Red3x2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,(A, B)> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1Red3xGraft2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,(A[], B[])> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1Red3x3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,(A, B, C)> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1Red3xGraft3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,(A[], B[], C[])> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1Red3x4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,(A, B, C, D)> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1Red3xGraft4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,List<Q>,List<R>,List<P>,(A[], B[], C[], D[])> action, ErrorChecker<(T,List<Q>,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var rxbranchredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && rxbranchredux_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        var compute = error.Validate((zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, rxbranchredux_q, rxbranchredux_r, rxbranchredux_p) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip2x1<T,Q,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,A> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip2xGraft1<T,Q,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,A[]> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2x2<T,Q,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A, B)> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2xGraft2<T,Q,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A[], B[])> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2x3<T,Q,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A, B, C)> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2xGraft3<T,Q,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A[], B[], C[])> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2x4<T,Q,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A, B, C, D)> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2xGraft4<T,Q,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q)> error)
            where T : IGH_Goo where Q : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count);
            var paths = GetPathList(zip_t, zip_q);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx)) ? action(zip_tx, zip_qx) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip2Red1x1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,A> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip2Red1xGraft1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,A[]> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2Red1x2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,(A, B)> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2Red1xGraft2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,(A[], B[])> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2Red1x3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,(A, B, C)> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2Red1xGraft3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,(A[], B[], C[])> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2Red1x4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,(A, B, C, D)> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2Red1xGraft4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<T,Q,List<R>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r)) ? action(zip_tx, zip_qx, rxbranchredux_r) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip2Red2x1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,A> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip2Red2xGraft1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,A[]> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2Red2x2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,(A, B)> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2Red2xGraft2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,(A[], B[])> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2Red2x3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,(A, B, C)> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2Red2xGraft3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,(A[], B[], C[])> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2Red2x4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,(A, B, C, D)> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2Red2xGraft4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, Func<T,Q,List<R>,List<P>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,List<R>,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip2Red3x1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,A> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip2Red3xGraft1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,A[]> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2Red3x2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,(A, B)> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip2Red3xGraft2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,(A[], B[])> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2Red3x3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,(A, B, C)> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip2Red3xGraft3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,(A[], B[], C[])> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2Red3x4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,(A, B, C, D)> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip2Red3xGraft4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,List<R>,List<P>,List<U>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var rxbranchredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && rxbranchredux_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, rxbranchredux_r, rxbranchredux_p, rxbranchredux_u) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip3x1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,A> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip3xGraft1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,A[]> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3x2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A, B)> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3xGraft2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A[], B[])> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3x3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A, B, C)> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3xGraft3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A[], B[], C[])> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3x4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A, B, C, D)> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3xGraft4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx)) ? action(zip_tx, zip_qx, zip_rx) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip3Red1x1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,A> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip3Red1xGraft1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,A[]> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3Red1x2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,(A, B)> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3Red1xGraft2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,(A[], B[])> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3Red1x3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,(A, B, C)> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3Red1xGraft3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3Red1x4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3Red1xGraft4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, Func<T,Q,R,List<P>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,List<P>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip3Red2x1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,A> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip3Red2xGraft1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,A[]> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3Red2x2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,(A, B)> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3Red2xGraft2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,(A[], B[])> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3Red2x3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,(A, B, C)> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3Red2xGraft3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3Red2x4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3Red2xGraft4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,Q,R,List<P>,List<U>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip3Red3x1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,A> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip3Red3xGraft1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,A[]> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3Red3x2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,(A, B)> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip3Red3xGraft2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,(A[], B[])> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3Red3x3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,(A, B, C)> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip3Red3xGraft3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3Red3x4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip3Red3xGraft4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,List<P>,List<U>,List<V>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,List<P>,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, redux_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var rxbranchredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && rxbranchredux_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, rxbranchredux_p, rxbranchredux_u, rxbranchredux_v) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip4x1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,A> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip4xGraft1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,A[]> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4x2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A, B)> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4xGraft2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A[], B[])> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4x3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A, B, C)> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4xGraft3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4x4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4xGraft4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px)) ? action(zip_tx, zip_qx, zip_rx, zip_px) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip4Red1x1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,A> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip4Red1xGraft1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,A[]> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4Red1x2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,(A, B)> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4Red1xGraft2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4Red1x3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4Red1xGraft3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4Red1x4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4Red1xGraft4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, Func<T,Q,R,P,List<U>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip4Red2x1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,A> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip4Red2xGraft1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,A[]> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4Red2x2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,(A, B)> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4Red2xGraft2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4Red2x3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4Red2xGraft3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4Red2x4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4Red2xGraft4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<T,Q,R,P,List<U>,List<V>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip4Red3x1<T,Q,R,P,U,V,W,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,A> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip4Red3xGraft1<T,Q,R,P,U,V,W,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,A[]> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4Red3x2<T,Q,R,P,U,V,W,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,(A, B)> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip4Red3xGraft2<T,Q,R,P,U,V,W,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4Red3x3<T,Q,R,P,U,V,W,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip4Red3xGraft3<T,Q,R,P,U,V,W,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4Red3x4<T,Q,R,P,U,V,W,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip4Red3xGraft4<T,Q,R,P,U,V,W,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> redux_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,List<U>,List<V>,List<W>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,List<U>,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, redux_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, redux_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var rxbranchredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && rxbranchredux_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, rxbranchredux_u, rxbranchredux_v, rxbranchredux_w) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip5x1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,A> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip5xGraft1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,A[]> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5x2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,(A, B)> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5xGraft2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5x3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5xGraft3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5x4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5xGraft4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, Func<T,Q,R,P,U,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip5Red1x1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,A> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip5Red1xGraft1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,A[]> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5Red1x2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,(A, B)> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5Red1xGraft2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5Red1x3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5Red1xGraft3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5Red1x4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5Red1xGraft4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, Func<T,Q,R,P,U,List<V>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U,List<V>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip5Red2x1<T,Q,R,P,U,V,W,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,A> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip5Red2xGraft1<T,Q,R,P,U,V,W,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,A[]> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5Red2x2<T,Q,R,P,U,V,W,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,(A, B)> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5Red2xGraft2<T,Q,R,P,U,V,W,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5Red2x3<T,Q,R,P,U,V,W,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5Red2xGraft3<T,Q,R,P,U,V,W,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5Red2x4<T,Q,R,P,U,V,W,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5Red2xGraft4<T,Q,R,P,U,V,W,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,List<V>,List<W>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip5Red3x1<T,Q,R,P,U,V,W,X,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,A> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip5Red3xGraft1<T,Q,R,P,U,V,W,X,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,A[]> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5Red3x2<T,Q,R,P,U,V,W,X,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,(A, B)> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip5Red3xGraft2<T,Q,R,P,U,V,W,X,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5Red3x3<T,Q,R,P,U,V,W,X,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip5Red3xGraft3<T,Q,R,P,U,V,W,X,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5Red3x4<T,Q,R,P,U,V,W,X,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip5Red3xGraft4<T,Q,R,P,U,V,W,X,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> redux_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,List<V>,List<W>,List<X>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U,List<V>,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, redux_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, redux_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var rxbranchredux_v = redux_v.Branches[Math.Min(i, redux_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && rxbranchredux_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, rxbranchredux_v, rxbranchredux_w, rxbranchredux_x) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip6x1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,A> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip6xGraft1<T,Q,R,P,U,V,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,A[]> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6x2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,(A, B)> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6xGraft2<T,Q,R,P,U,V,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6x3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6xGraft3<T,Q,R,P,U,V,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6x4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6xGraft4<T,Q,R,P,U,V,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, Func<T,Q,R,P,U,V,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U,V)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip6Red1x1<T,Q,R,P,U,V,W,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,A> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip6Red1xGraft1<T,Q,R,P,U,V,W,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,A[]> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6Red1x2<T,Q,R,P,U,V,W,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,(A, B)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6Red1xGraft2<T,Q,R,P,U,V,W,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6Red1x3<T,Q,R,P,U,V,W,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6Red1xGraft3<T,Q,R,P,U,V,W,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6Red1x4<T,Q,R,P,U,V,W,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6Red1xGraft4<T,Q,R,P,U,V,W,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, Func<T,Q,R,P,U,V,List<W>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip6Red2x1<T,Q,R,P,U,V,W,X,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,A> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip6Red2xGraft1<T,Q,R,P,U,V,W,X,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,A[]> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6Red2x2<T,Q,R,P,U,V,W,X,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,(A, B)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6Red2xGraft2<T,Q,R,P,U,V,W,X,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6Red2x3<T,Q,R,P,U,V,W,X,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6Red2xGraft3<T,Q,R,P,U,V,W,X,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6Red2x4<T,Q,R,P,U,V,W,X,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6Red2xGraft4<T,Q,R,P,U,V,W,X,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, Func<T,Q,R,P,U,V,List<W>,List<X>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static GH_Structure<A>Zip6Red3x1<T,Q,R,P,U,V,W,X,Y,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,A> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : default;
                    });
                    result1.AppendRange(temp,path);
                }
            });
            
            return (result1);
        }
        
        
        public static GH_Structure<A>Zip6Red3xGraft1<T,Q,R,P,U,V,W,X,Y,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,A[]> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : (new A[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute,targpath);
                    });
                }
            });
            
            return (result1);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6Red3x2<T,Q,R,P,U,V,W,X,Y,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,(A, B)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip6Red3xGraft2<T,Q,R,P,U,V,W,X,Y,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,(A[], B[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : (new A[0], new B[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                    });
                }
            });
            
            return (result1, result2);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6Red3x3<T,Q,R,P,U,V,W,X,Y,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,(A, B, C)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip6Red3xGraft3<T,Q,R,P,U,V,W,X,Y,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,(A[], B[], C[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : (new A[0], new B[0], new C[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                    });
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6Red3x4<T,Q,R,P,U,V,W,X,Y,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,(A, B, C, D)> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
                result2.EnsurePath(targpath);
                result3.EnsurePath(targpath);
                result4.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, path);
                    result2.AppendRange(from item in temp select item.Item2, path);
                    result3.AppendRange(from item in temp select item.Item3, path);
                    result4.AppendRange(from item in temp select item.Item4, path);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip6Red3xGraft4<T,Q,R,P,U,V,W,X,Y,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, GH_Structure<U> zip_u, GH_Structure<V> zip_v, GH_Structure<W> redux_w, GH_Structure<X> redux_x, GH_Structure<Y> redux_y, Func<T,Q,R,P,U,V,List<W>,List<X>,List<Y>,(A[], B[], C[], D[])> action, ErrorChecker<(T,Q,R,P,U,V,List<W>,List<X>,List<Y>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo where V : IGH_Goo where W : IGH_Goo where X : IGH_Goo where Y : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, zip_q.Branches.Count, zip_r.Branches.Count, zip_p.Branches.Count, zip_u.Branches.Count, zip_v.Branches.Count, redux_w.Branches.Count, redux_x.Branches.Count, redux_y.Branches.Count);
            var paths = GetPathList(zip_t, zip_q, zip_r, zip_p, zip_u, zip_v, redux_w, redux_x, redux_y);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                for (int j = 0; j < maxlen; j++)
                {
                    var targpath = path.AppendElement(j);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                    result4.EnsurePath(targpath);
                }
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var path = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var branchzip_u = zip_u.Branches[Math.Min(i, zip_u.Branches.Count - 1)];
                var branchzip_v = zip_v.Branches[Math.Min(i, zip_v.Branches.Count - 1)];
                var rxbranchredux_w = redux_w.Branches[Math.Min(i, redux_w.Branches.Count - 1)];
                var rxbranchredux_x = redux_x.Branches[Math.Min(i, redux_x.Branches.Count - 1)];
                var rxbranchredux_y = redux_y.Branches[Math.Min(i, redux_y.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && branchzip_u.Count > 0 && branchzip_v.Count > 0 && rxbranchredux_w.Count > 0 && rxbranchredux_x.Count > 0 && rxbranchredux_y.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count, branchzip_u.Count, branchzip_v.Count);
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        U zip_ux = branchzip_u[Math.Min(branchzip_u.Count - 1, j)];
                        V zip_vx = branchzip_v[Math.Min(branchzip_v.Count - 1, j)];
                        var compute = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y)) ? action(zip_tx, zip_qx, zip_rx, zip_px, zip_ux, zip_vx, rxbranchredux_w, rxbranchredux_x, rxbranchredux_y) : (new A[0], new B[0], new C[0], new D[0]);
                        var targpath = path.AppendElement(j);
                        result1.AppendRange(compute.Item1,targpath);
                        result2.AppendRange(compute.Item2,targpath);
                        result3.AppendRange(compute.Item3,targpath);
                        result4.AppendRange(compute.Item4,targpath);
                    });
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
    }
}
