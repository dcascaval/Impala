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
    public static class Generated
    {
        
        
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(temp,targpath);
                }
            });
            
            return (result1);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)Zip2x2<T,Q,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A,B)> action, ErrorChecker<(T,Q)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                }
            });
            
            return (result1, result2);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)Zip2x3<T,Q,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A,B,C)> action, ErrorChecker<(T,Q)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                }
            });
            
            return (result1, result2, result3);
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(temp,targpath);
                }
            });
            
            return (result1);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)Zip3x2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A,B)> action, ErrorChecker<(T,Q,R)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                }
            });
            
            return (result1, result2);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)Zip3x3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A,B,C)> action, ErrorChecker<(T,Q,R)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                }
            });
            
            return (result1, result2, result3);
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(temp,targpath);
                }
            });
            
            return (result1);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)Zip4x2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A,B)> action, ErrorChecker<(T,Q,R,P)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                }
            });
            
            return (result1, result2);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)Zip4x3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A,B,C)> action, ErrorChecker<(T,Q,R,P)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
    }
}
