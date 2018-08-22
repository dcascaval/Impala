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
        
        
        public static GH_Structure<A>ZipGraft1x1<T,A>
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)ZipGraft1x2<T,A,B>
        (GH_Structure<T> zip_t, Func<T,(A[],B[])> action, ErrorChecker<T> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)ZipGraft1x3<T,A,B,C>
        (GH_Structure<T> zip_t, Func<T,(A[],B[],C[])> action, ErrorChecker<T> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)ZipGraft1x4<T,A,B,C,D>
        (GH_Structure<T> zip_t, Func<T,(A[],B[],C[],D[])> action, ErrorChecker<T> error)
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
        
        
        
        
        public static GH_Structure<A>ZipGraft2x1<T,Q,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,A[]> action, ErrorChecker<(T, Q)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)ZipGraft2x2<T,Q,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A[],B[])> action, ErrorChecker<(T, Q)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)ZipGraft2x3<T,Q,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A[],B[],C[])> action, ErrorChecker<(T, Q)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)ZipGraft2x4<T,Q,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A[],B[],C[],D[])> action, ErrorChecker<(T, Q)> error)
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
        
        
        
        
        public static GH_Structure<A>ZipGraft3x1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,A[]> action, ErrorChecker<(T, Q, R)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)ZipGraft3x2<T,Q,R,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A[],B[])> action, ErrorChecker<(T, Q, R)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)ZipGraft3x3<T,Q,R,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A[],B[],C[])> action, ErrorChecker<(T, Q, R)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)ZipGraft3x4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A[],B[],C[],D[])> action, ErrorChecker<(T, Q, R)> error)
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
        
        
        
        
        public static GH_Structure<A>ZipGraft4x1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,A[]> action, ErrorChecker<(T, Q, R, P)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)ZipGraft4x2<T,Q,R,P,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A[],B[])> action, ErrorChecker<(T, Q, R, P)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)ZipGraft4x3<T,Q,R,P,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A[],B[],C[])> action, ErrorChecker<(T, Q, R, P)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)ZipGraft4x4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A[],B[],C[],D[])> action, ErrorChecker<(T, Q, R, P)> error)
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
        
        
        
        
        public static GH_Structure<A>Zip1Red4x1<T,Q,R,P,U,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,List<Q>,List<R>,List<P>,List<U>,A> action, ErrorChecker<(T,List<Q>,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p, redux_u);
            
            for (int i = 0; i < maxbranch; i++)
            {
                var targpath = GetPath(paths,i);
                result1.EnsurePath(targpath);
            }
            
            Parallel.For(0,maxbranch,i =>
            {
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var redxredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && redxredux_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(temp,targpath);
                }
            });
            
            return (result1);
        }
        
        
        
        
        public static (GH_Structure<A>, GH_Structure<B>)Zip1Red4x2<T,Q,R,P,U,A,B>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,List<Q>,List<R>,List<P>,List<U>,(A, B)> action, ErrorChecker<(T,List<Q>,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p, redux_u);
            
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
                var redxredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && redxredux_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                }
            });
            
            return (result1, result2);
        }
        
        
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>)Zip1Red4x3<T,Q,R,P,U,A,B,C>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,List<Q>,List<R>,List<P>,List<U>,(A, B, C)> action, ErrorChecker<(T,List<Q>,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p, redux_u);
            
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
                var redxredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && redxredux_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        
        
        public static (GH_Structure<A>, GH_Structure<B>, GH_Structure<C>, GH_Structure<D>)Zip1Red4x4<T,Q,R,P,U,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<P> redux_p, GH_Structure<U> redux_u, Func<T,List<Q>,List<R>,List<P>,List<U>,(A, B, C, D)> action, ErrorChecker<(T,List<Q>,List<R>,List<P>,List<U>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo where P : IGH_Goo where U : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            var result1 = new GH_Structure<A>();
            var result2 = new GH_Structure<B>();
            var result3 = new GH_Structure<C>();
            var result4 = new GH_Structure<D>();
            
            var maxbranch = Max(zip_t.Branches.Count, redux_q.Branches.Count, redux_r.Branches.Count, redux_p.Branches.Count, redux_u.Branches.Count);
            var paths = GetPathList(zip_t, redux_q, redux_r, redux_p, redux_u);
            
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var redxredux_q = redux_q.Branches[Math.Min(i, redux_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && redxredux_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, redxredux_q, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(temp,targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var redxredux_r = redux_r.Branches[Math.Min(i, redux_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && redxredux_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, redxredux_r, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(temp,targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var redxredux_p = redux_p.Branches[Math.Min(i, redux_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && redxredux_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, redxredux_p, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    A[] temp = new A[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, redxredux_u) : default;
                    });
                    result1.AppendRange(temp,targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B)[] temp = new (A, B)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C)[] temp = new (A, B, C)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
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
                var targpath = GetPath(paths,i);
                var branchzip_t = zip_t.Branches[Math.Min(i, zip_t.Branches.Count - 1)];
                var branchzip_q = zip_q.Branches[Math.Min(i, zip_q.Branches.Count - 1)];
                var branchzip_r = zip_r.Branches[Math.Min(i, zip_r.Branches.Count - 1)];
                var branchzip_p = zip_p.Branches[Math.Min(i, zip_p.Branches.Count - 1)];
                var redxredux_u = redux_u.Branches[Math.Min(i, redux_u.Branches.Count - 1)];
                if (branchzip_t.Count > 0 && branchzip_q.Count > 0 && branchzip_r.Count > 0 && branchzip_p.Count > 0 && redxredux_u.Count > 0)
                {
                    int maxlen = Max(branchzip_t.Count, branchzip_q.Count, branchzip_r.Count, branchzip_p.Count);
                    (A, B, C, D)[] temp = new (A, B, C, D)[maxlen];
                    Parallel.For(0,maxlen,j =>
                    {
                        T zip_tx = branchzip_t[Math.Min(branchzip_t.Count - 1, j)];
                        Q zip_qx = branchzip_q[Math.Min(branchzip_q.Count - 1, j)];
                        R zip_rx = branchzip_r[Math.Min(branchzip_r.Count - 1, j)];
                        P zip_px = branchzip_p[Math.Min(branchzip_p.Count - 1, j)];
                        temp[j] = error.Validate((zip_tx, zip_qx, zip_rx, zip_px, redxredux_u)) ? action(zip_tx, zip_qx, zip_rx, zip_px, redxredux_u) : default;
                    });
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(temp,targpath);
                }
            });
            
            return (result1);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>)Zip1x2<T,A,B>
        (GH_Structure<T> zip_t, Func<T,(A,B)> action, ErrorChecker<T> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                }
            });
            
            return (result1, result2);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>)Zip1x3<T,A,B,C>
        (GH_Structure<T> zip_t, Func<T,(A,B,C)> action, ErrorChecker<T> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                }
            });
            
            return (result1, result2, result3);
        }
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)Zip1x4<T,A,B,C,D>
        (GH_Structure<T> zip_t, Func<T,(A,B,C,D)> action, ErrorChecker<T> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        
        
        public static GH_Structure<A>Zip2x1<T,Q,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,A> action, ErrorChecker<(T, Q)> error)
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
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A,B)> action, ErrorChecker<(T, Q)> error)
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
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A,B,C)> action, ErrorChecker<(T, Q)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)Zip2x4<T,Q,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, Func<T,Q,(A,B,C,D)> action, ErrorChecker<(T, Q)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        
        
        public static GH_Structure<A>Zip3x1<T,Q,R,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,A> action, ErrorChecker<(T, Q, R)> error)
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
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A,B)> action, ErrorChecker<(T, Q, R)> error)
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
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A,B,C)> action, ErrorChecker<(T, Q, R)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)Zip3x4<T,Q,R,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<T,Q,R,(A,B,C,D)> action, ErrorChecker<(T, Q, R)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
        
        
        public static GH_Structure<A>Zip4x1<T,Q,R,P,A>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,A> action, ErrorChecker<(T, Q, R, P)> error)
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
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A,B)> action, ErrorChecker<(T, Q, R, P)> error)
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
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A,B,C)> action, ErrorChecker<(T, Q, R, P)> error)
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
        
        
        
        
        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>)Zip4x4<T,Q,R,P,A,B,C,D>
        (GH_Structure<T> zip_t, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<P> zip_p, Func<T,Q,R,P,(A,B,C,D)> action, ErrorChecker<(T, Q, R, P)> error)
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
                var targpath = GetPath(paths,i);
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
                    result1.AppendRange(from item in temp select item.Item1, targpath);
                    result2.AppendRange(from item in temp select item.Item2, targpath);
                    result3.AppendRange(from item in temp select item.Item3, targpath);
                    result4.AppendRange(from item in temp select item.Item4, targpath);
                }
            });
            
            return (result1, result2, result3, result4);
        }
        
        
    }
}
