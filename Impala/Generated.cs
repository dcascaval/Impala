using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public static GH_Structure<A> Red1xGraft1<N,A>
        (GH_Structure<N> redux_n, Func<List<N>,A[]> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var compute = error.Validate(branchredux_n) ? action(branchredux_n) : new A[0];
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute,targpath);
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Red1x1<N,A>
        (GH_Structure<N> redux_n, Func<List<N>,A> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var temp = error.Validate(branchredux_n) ? action(branchredux_n) : default;
                        result0.Append(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Red1xGraft2<N,A,B>
        (GH_Structure<N> redux_n, Func<List<N>,(A[],B[])> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var compute = error.Validate(branchredux_n) ? action(branchredux_n) : (new A[0],new B[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Red1x2<N,A,B>
        (GH_Structure<N> redux_n, Func<List<N>,(A,B)> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var temp = error.Validate(branchredux_n) ? action(branchredux_n) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Red1xGraft3<N,A,B,C>
        (GH_Structure<N> redux_n, Func<List<N>,(A[],B[],C[])> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var compute = error.Validate(branchredux_n) ? action(branchredux_n) : (new A[0],new B[0],new C[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                        result2.AppendRange(compute.Item3,targpath);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Red1x3<N,A,B,C>
        (GH_Structure<N> redux_n, Func<List<N>,(A,B,C)> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var temp = error.Validate(branchredux_n) ? action(branchredux_n) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                        result2.Append(temp.Item3,path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Red1xGraft4<N,A,B,C,D>
        (GH_Structure<N> redux_n, Func<List<N>,(A[],B[],C[],D[])> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var compute = error.Validate(branchredux_n) ? action(branchredux_n) : (new A[0],new B[0],new C[0],new D[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                        result2.AppendRange(compute.Item3,targpath);
                        result3.AppendRange(compute.Item4,targpath);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Red1x4<N,A,B,C,D>
        (GH_Structure<N> redux_n, Func<List<N>,(A,B,C,D)> action, ErrorChecker<List<N>> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(redux_n.Branches.Count);
                var paths = GetPathList(redux_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    if ((branchredux_n.Count > 0))                     
                    {
                        var temp = error.Validate(branchredux_n) ? action(branchredux_n) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                        result2.Append(temp.Item3,path);
                        result3.Append(temp.Item4,path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Red2xGraft1<N,O,A>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,A[]> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : new A[0];
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute,targpath);
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Red2x1<N,O,A>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,A> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : default;
                        result0.Append(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Red2xGraft2<N,O,A,B>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,(A[],B[])> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : (new A[0],new B[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Red2x2<N,O,A,B>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,(A,B)> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Red2xGraft3<N,O,A,B,C>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,(A[],B[],C[])> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : (new A[0],new B[0],new C[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                        result2.AppendRange(compute.Item3,targpath);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Red2x3<N,O,A,B,C>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,(A,B,C)> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                        result2.Append(temp.Item3,path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Red2xGraft4<N,O,A,B,C,D>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,(A[],B[],C[],D[])> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : (new A[0],new B[0],new C[0],new D[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                        result2.AppendRange(compute.Item3,targpath);
                        result3.AppendRange(compute.Item4,targpath);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Red2x4<N,O,A,B,C,D>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, Func<List<N>,List<O>,(A,B,C,D)> action, ErrorChecker<(List<N>,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(redux_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchredux_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o)) ? action(branchredux_n,branchredux_o) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                        result2.Append(temp.Item3,path);
                        result3.Append(temp.Item4,path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Red3xGraft1<N,O,P,A>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,A[]> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : new A[0];
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute,targpath);
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Red3x1<N,O,P,A>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,A> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : default;
                        result0.Append(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Red3xGraft2<N,O,P,A,B>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,(A[],B[])> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : (new A[0],new B[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Red3x2<N,O,P,A,B>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,(A,B)> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Red3xGraft3<N,O,P,A,B,C>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,(A[],B[],C[])> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : (new A[0],new B[0],new C[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                        result2.AppendRange(compute.Item3,targpath);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Red3x3<N,O,P,A,B,C>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,(A,B,C)> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                        result2.Append(temp.Item3,path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Red3xGraft4<N,O,P,A,B,C,D>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,(A[],B[],C[],D[])> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var compute = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : (new A[0],new B[0],new C[0],new D[0]);
                        var targpath = path.AppendElement(0);
                        result0.AppendRange(compute.Item1,targpath);
                        result1.AppendRange(compute.Item2,targpath);
                        result2.AppendRange(compute.Item3,targpath);
                        result3.AppendRange(compute.Item4,targpath);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Red3x4<N,O,P,A,B,C,D>
        (GH_Structure<N> redux_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<List<N>,List<O>,List<P>,(A,B,C,D)> action, ErrorChecker<(List<N>,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(redux_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(redux_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var targpath = path.AppendElement(0);
                    result0.EnsurePath(targpath);
                    result1.EnsurePath(targpath);
                    result2.EnsurePath(targpath);
                    result3.EnsurePath(targpath);
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchredux_n = redux_n.Branches[Math.Min(i,(redux_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchredux_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var temp = error.Validate((branchredux_n,branchredux_o,branchredux_p)) ? action(branchredux_n,branchredux_o,branchredux_p) : default;
                        result0.Append(temp.Item1,path);
                        result1.Append(temp.Item2,path);
                        result2.Append(temp.Item3,path);
                        result3.Append(temp.Item4,path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip1xGraft1<N,A>
        (GH_Structure<N> zip_n, Func<N,A[]> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate(zip_nx) ? action(zip_nx) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip1x1<N,A>
        (GH_Structure<N> zip_n, Func<N,A> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate(zip_nx) ? action(zip_nx) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1xGraft2<N,A,B>
        (GH_Structure<N> zip_n, Func<N,(A[],B[])> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate(zip_nx) ? action(zip_nx) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1x2<N,A,B>
        (GH_Structure<N> zip_n, Func<N,(A,B)> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate(zip_nx) ? action(zip_nx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1xGraft3<N,A,B,C>
        (GH_Structure<N> zip_n, Func<N,(A[],B[],C[])> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate(zip_nx) ? action(zip_nx) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1x3<N,A,B,C>
        (GH_Structure<N> zip_n, Func<N,(A,B,C)> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate(zip_nx) ? action(zip_nx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1xGraft4<N,A,B,C,D>
        (GH_Structure<N> zip_n, Func<N,(A[],B[],C[],D[])> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate(zip_nx) ? action(zip_nx) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1x4<N,A,B,C,D>
        (GH_Structure<N> zip_n, Func<N,(A,B,C,D)> action, ErrorChecker<N> error)
            where N : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count);
                var paths = GetPathList(zip_n);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    if ((branchzip_n.Count > 0))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate(zip_nx) ? action(zip_nx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip1Red1xGraft1<N,O,A>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,A[]> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip1Red1x1<N,O,A>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,A> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1Red1xGraft2<N,O,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,(A[],B[])> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1Red1x2<N,O,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,(A,B)> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1Red1xGraft3<N,O,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,(A[],B[],C[])> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1Red1x3<N,O,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,(A,B,C)> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1Red1xGraft4<N,O,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,(A[],B[],C[],D[])> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1Red1x4<N,O,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, Func<N,List<O>,(A,B,C,D)> action, ErrorChecker<(N,List<O>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count);
                var paths = GetPathList(zip_n,redux_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchredux_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o)) ? action(zip_nx,branchredux_o) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip1Red2xGraft1<N,O,P,A>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,A[]> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip1Red2x1<N,O,P,A>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,A> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1Red2xGraft2<N,O,P,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,(A[],B[])> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1Red2x2<N,O,P,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,(A,B)> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1Red2xGraft3<N,O,P,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,(A[],B[],C[])> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1Red2x3<N,O,P,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,(A,B,C)> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1Red2xGraft4<N,O,P,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,(A[],B[],C[],D[])> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1Red2x4<N,O,P,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, Func<N,List<O>,List<P>,(A,B,C,D)> action, ErrorChecker<(N,List<O>,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p)) ? action(zip_nx,branchredux_o,branchredux_p) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip1Red3xGraft1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,A[]> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip1Red3x1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,A> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1Red3xGraft2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,(A[],B[])> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip1Red3x2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,(A,B)> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1Red3xGraft3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,(A[],B[],C[])> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip1Red3x3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,(A,B,C)> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1Red3xGraft4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,(A[],B[],C[],D[])> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var compute = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip1Red3x4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> redux_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,List<O>,List<P>,List<Q>,(A,B,C,D)> action, ErrorChecker<(N,List<O>,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,redux_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,redux_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchredux_o = redux_o.Branches[Math.Min(i,(redux_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchredux_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            temp[j] = error.Validate((zip_nx,branchredux_o,branchredux_p,branchredux_q)) ? action(zip_nx,branchredux_o,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip2xGraft1<N,O,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,A[]> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip2x1<N,O,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,A> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2xGraft2<N,O,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,(A[],B[])> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2x2<N,O,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,(A,B)> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2xGraft3<N,O,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,(A[],B[],C[])> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2x3<N,O,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,(A,B,C)> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2xGraft4<N,O,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,(A[],B[],C[],D[])> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2x4<N,O,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, Func<N,O,(A,B,C,D)> action, ErrorChecker<(N,O)> error)
            where N : IGH_Goo  where O : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count);
                var paths = GetPathList(zip_n,zip_o);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    if (((branchzip_n.Count > 0) && (branchzip_o.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox)) ? action(zip_nx,zip_ox) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip2Red1xGraft1<N,O,P,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,A[]> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip2Red1x1<N,O,P,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,A> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2Red1xGraft2<N,O,P,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,(A[],B[])> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2Red1x2<N,O,P,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,(A,B)> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2Red1xGraft3<N,O,P,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,(A[],B[],C[])> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2Red1x3<N,O,P,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,(A,B,C)> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2Red1xGraft4<N,O,P,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2Red1x4<N,O,P,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, Func<N,O,List<P>,(A,B,C,D)> action, ErrorChecker<(N,O,List<P>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p)) ? action(zip_nx,zip_ox,branchredux_p) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip2Red2xGraft1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,A[]> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip2Red2x1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,A> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2Red2xGraft2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,(A[],B[])> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2Red2x2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,(A,B)> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2Red2xGraft3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,(A[],B[],C[])> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2Red2x3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,(A,B,C)> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2Red2xGraft4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2Red2x4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, Func<N,O,List<P>,List<Q>,(A,B,C,D)> action, ErrorChecker<(N,O,List<P>,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip2Red3xGraft1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,A[]> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip2Red3x1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,A> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2Red3xGraft2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,(A[],B[])> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip2Red3x2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,(A,B)> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2Red3xGraft3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,(A[],B[],C[])> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip2Red3x3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,(A,B,C)> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2Red3xGraft4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip2Red3x4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> redux_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,List<P>,List<Q>,List<R>,(A,B,C,D)> action, ErrorChecker<(N,O,List<P>,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,redux_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,redux_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchredux_p = redux_p.Branches[Math.Min(i,(redux_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchredux_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,branchredux_p,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip3xGraft1<N,O,P,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,A[]> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip3x1<N,O,P,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,A> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3xGraft2<N,O,P,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,(A[],B[])> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3x2<N,O,P,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,(A,B)> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3xGraft3<N,O,P,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,(A[],B[],C[])> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3x3<N,O,P,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,(A,B,C)> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3xGraft4<N,O,P,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3x4<N,O,P,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, Func<N,O,P,(A,B,C,D)> action, ErrorChecker<(N,O,P)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    if ((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px)) ? action(zip_nx,zip_ox,zip_px) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip3Red1xGraft1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,A[]> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip3Red1x1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,A> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3Red1xGraft2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,(A[],B[])> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3Red1x2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,(A,B)> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3Red1xGraft3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3Red1x3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,(A,B,C)> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3Red1xGraft4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3Red1x4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, Func<N,O,P,List<Q>,(A,B,C,D)> action, ErrorChecker<(N,O,P,List<Q>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q)) ? action(zip_nx,zip_ox,zip_px,branchredux_q) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip3Red2xGraft1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,A[]> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip3Red2x1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,A> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3Red2xGraft2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,(A[],B[])> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3Red2x2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,(A,B)> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3Red2xGraft3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3Red2x3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,(A,B,C)> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3Red2xGraft4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3Red2x4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, Func<N,O,P,List<Q>,List<R>,(A,B,C,D)> action, ErrorChecker<(N,O,P,List<Q>,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip3Red3xGraft1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,A[]> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip3Red3x1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,A> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3Red3xGraft2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,(A[],B[])> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip3Red3x2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,(A,B)> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3Red3xGraft3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip3Red3x3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,(A,B,C)> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3Red3xGraft4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip3Red3x4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> redux_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,List<Q>,List<R>,List<S>,(A,B,C,D)> action, ErrorChecker<(N,O,P,List<Q>,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,redux_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,redux_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchredux_q = redux_q.Branches[Math.Min(i,(redux_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchredux_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,branchredux_q,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip4xGraft1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,A[]> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip4x1<N,O,P,Q,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,A> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4xGraft2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,(A[],B[])> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4x2<N,O,P,Q,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,(A,B)> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4xGraft3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4x3<N,O,P,Q,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,(A,B,C)> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4xGraft4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4x4<N,O,P,Q,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, Func<N,O,P,Q,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    if (((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx)) ? action(zip_nx,zip_ox,zip_px,zip_qx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip4Red1xGraft1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,A[]> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip4Red1x1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,A> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4Red1xGraft2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4Red1x2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,(A,B)> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4Red1xGraft3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4Red1x3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4Red1xGraft4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4Red1x4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, Func<N,O,P,Q,List<R>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,List<R>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip4Red2xGraft1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,A[]> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip4Red2x1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,A> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4Red2xGraft2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4Red2x2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,(A,B)> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4Red2xGraft3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4Red2x3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4Red2xGraft4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4Red2x4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, Func<N,O,P,Q,List<R>,List<S>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip4Red3xGraft1<N,O,P,Q,R,S,T,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,A[]> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip4Red3x1<N,O,P,Q,R,S,T,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,A> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4Red3xGraft2<N,O,P,Q,R,S,T,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip4Red3x2<N,O,P,Q,R,S,T,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,(A,B)> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4Red3xGraft3<N,O,P,Q,R,S,T,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip4Red3x3<N,O,P,Q,R,S,T,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4Red3xGraft4<N,O,P,Q,R,S,T,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip4Red3x4<N,O,P,Q,R,S,T,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> redux_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,List<R>,List<S>,List<T>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,List<R>,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,redux_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,redux_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchredux_r = redux_r.Branches[Math.Min(i,(redux_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchredux_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,branchredux_r,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip5xGraft1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,A[]> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip5x1<N,O,P,Q,R,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,A> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5xGraft2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5x2<N,O,P,Q,R,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,(A,B)> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5xGraft3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5x3<N,O,P,Q,R,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5xGraft4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5x4<N,O,P,Q,R,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, Func<N,O,P,Q,R,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    if ((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip5Red1xGraft1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,A[]> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip5Red1x1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,A> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5Red1xGraft2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5Red1x2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,(A,B)> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5Red1xGraft3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5Red1x3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5Red1xGraft4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5Red1x4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, Func<N,O,P,Q,R,List<S>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R,List<S>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip5Red2xGraft1<N,O,P,Q,R,S,T,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,A[]> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip5Red2x1<N,O,P,Q,R,S,T,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,A> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5Red2xGraft2<N,O,P,Q,R,S,T,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5Red2x2<N,O,P,Q,R,S,T,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,(A,B)> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5Red2xGraft3<N,O,P,Q,R,S,T,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5Red2x3<N,O,P,Q,R,S,T,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5Red2xGraft4<N,O,P,Q,R,S,T,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5Red2x4<N,O,P,Q,R,S,T,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,List<S>,List<T>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip5Red3xGraft1<N,O,P,Q,R,S,T,U,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,A[]> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip5Red3x1<N,O,P,Q,R,S,T,U,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,A> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5Red3xGraft2<N,O,P,Q,R,S,T,U,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip5Red3x2<N,O,P,Q,R,S,T,U,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,(A,B)> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5Red3xGraft3<N,O,P,Q,R,S,T,U,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip5Red3x3<N,O,P,Q,R,S,T,U,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5Red3xGraft4<N,O,P,Q,R,S,T,U,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip5Red3x4<N,O,P,Q,R,S,T,U,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> redux_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,List<S>,List<T>,List<U>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R,List<S>,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,redux_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,redux_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchredux_s = redux_s.Branches[Math.Min(i,(redux_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchredux_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,branchredux_s,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip6xGraft1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,A[]> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip6x1<N,O,P,Q,R,S,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,A> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6xGraft2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6x2<N,O,P,Q,R,S,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,(A,B)> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6xGraft3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6x3<N,O,P,Q,R,S,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6xGraft4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6x4<N,O,P,Q,R,S,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, Func<N,O,P,Q,R,S,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R,S)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    if (((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip6Red1xGraft1<N,O,P,Q,R,S,T,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,A[]> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip6Red1x1<N,O,P,Q,R,S,T,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,A> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6Red1xGraft2<N,O,P,Q,R,S,T,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6Red1x2<N,O,P,Q,R,S,T,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,(A,B)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6Red1xGraft3<N,O,P,Q,R,S,T,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6Red1x3<N,O,P,Q,R,S,T,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6Red1xGraft4<N,O,P,Q,R,S,T,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6Red1x4<N,O,P,Q,R,S,T,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, Func<N,O,P,Q,R,S,List<T>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    if ((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip6Red2xGraft1<N,O,P,Q,R,S,T,U,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,A[]> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip6Red2x1<N,O,P,Q,R,S,T,U,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,A> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6Red2xGraft2<N,O,P,Q,R,S,T,U,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6Red2x2<N,O,P,Q,R,S,T,U,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,(A,B)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6Red2xGraft3<N,O,P,Q,R,S,T,U,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6Red2x3<N,O,P,Q,R,S,T,U,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6Red2xGraft4<N,O,P,Q,R,S,T,U,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6Red2x4<N,O,P,Q,R,S,T,U,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, Func<N,O,P,Q,R,S,List<T>,List<U>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    if (((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static GH_Structure<A> Zip6Red3xGraft1<N,O,P,Q,R,S,T,U,V,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,A[]> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : new A[0];
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute,targpath);
                        });
                    }
                });
                
                return result0;
            }

        public static GH_Structure<A> Zip6Red3x1<N,O,P,Q,R,S,T,U,V,A>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,A> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new A[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : default;
                        });
                        result0.AppendRange(temp,path);
                    }
                });
                
                return result0;
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6Red3xGraft2<N,O,P,Q,R,S,T,U,V,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,(A[],B[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : (new A[0],new B[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                        });
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>) Zip6Red3x2<N,O,P,Q,R,S,T,U,V,A,B>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,(A,B)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                    }
                });
                
                return (result0,result1);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6Red3xGraft3<N,O,P,Q,R,S,T,U,V,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,(A[],B[],C[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : (new A[0],new B[0],new C[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>) Zip6Red3x3<N,O,P,Q,R,S,T,U,V,A,B,C>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,(A,B,C)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                    }
                });
                
                return (result0,result1,result2);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6Red3xGraft4<N,O,P,Q,R,S,T,U,V,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,(A[],B[],C[],D[])> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            var compute = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : (new A[0],new B[0],new C[0],new D[0]);
                            var targpath = path.AppendElement(j);
                            result0.AppendRange(compute.Item1,targpath);
                            result1.AppendRange(compute.Item2,targpath);
                            result2.AppendRange(compute.Item3,targpath);
                            result3.AppendRange(compute.Item4,targpath);
                        });
                    }
                });
                
                return (result0,result1,result2,result3);
            }

        public static (GH_Structure<A>,GH_Structure<B>,GH_Structure<C>,GH_Structure<D>) Zip6Red3x4<N,O,P,Q,R,S,T,U,V,A,B,C,D>
        (GH_Structure<N> zip_n, GH_Structure<O> zip_o, GH_Structure<P> zip_p, GH_Structure<Q> zip_q, GH_Structure<R> zip_r, GH_Structure<S> zip_s, GH_Structure<T> redux_t, GH_Structure<U> redux_u, GH_Structure<V> redux_v, Func<N,O,P,Q,R,S,List<T>,List<U>,List<V>,(A,B,C,D)> action, ErrorChecker<(N,O,P,Q,R,S,List<T>,List<U>,List<V>)> error)
            where N : IGH_Goo  where O : IGH_Goo  where P : IGH_Goo  where Q : IGH_Goo  where R : IGH_Goo  where S : IGH_Goo  where T : IGH_Goo  where U : IGH_Goo  where V : IGH_Goo  where A : IGH_Goo  where B : IGH_Goo  where C : IGH_Goo  where D : IGH_Goo            
            {
                var result0 = new GH_Structure<A>();
                var result1 = new GH_Structure<B>();
                var result2 = new GH_Structure<C>();
                var result3 = new GH_Structure<D>();
                
                var maxbranch = Max(zip_n.Branches.Count,zip_o.Branches.Count,zip_p.Branches.Count,zip_q.Branches.Count,zip_r.Branches.Count,zip_s.Branches.Count,redux_t.Branches.Count,redux_u.Branches.Count,redux_v.Branches.Count);
                var paths = GetPathList(zip_n,zip_o,zip_p,zip_q,zip_r,zip_s,redux_t,redux_u,redux_v);
                
                for (int i = 0; (i < maxbranch); i++ )                
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                    for (int j = 0; (j < maxlen); j++ )                    
                    {
                        var targpath = path.AppendElement(j);
                        result0.EnsurePath(targpath);
                        result1.EnsurePath(targpath);
                        result2.EnsurePath(targpath);
                        result3.EnsurePath(targpath);
                    }
                }
                
                Parallel.For( 0, maxbranch, i =>                 
                {
                    var path = GetPath(paths,i);
                    var branchzip_n = zip_n.Branches[Math.Min(i,(zip_n.Branches.Count - 1))];
                    var branchzip_o = zip_o.Branches[Math.Min(i,(zip_o.Branches.Count - 1))];
                    var branchzip_p = zip_p.Branches[Math.Min(i,(zip_p.Branches.Count - 1))];
                    var branchzip_q = zip_q.Branches[Math.Min(i,(zip_q.Branches.Count - 1))];
                    var branchzip_r = zip_r.Branches[Math.Min(i,(zip_r.Branches.Count - 1))];
                    var branchzip_s = zip_s.Branches[Math.Min(i,(zip_s.Branches.Count - 1))];
                    var branchredux_t = redux_t.Branches[Math.Min(i,(redux_t.Branches.Count - 1))];
                    var branchredux_u = redux_u.Branches[Math.Min(i,(redux_u.Branches.Count - 1))];
                    var branchredux_v = redux_v.Branches[Math.Min(i,(redux_v.Branches.Count - 1))];
                    if ((((((((((branchzip_n.Count > 0) && (branchzip_o.Count > 0)) && (branchzip_p.Count > 0)) && (branchzip_q.Count > 0)) && (branchzip_r.Count > 0)) && (branchzip_s.Count > 0)) && (branchredux_t.Count > 0)) && (branchredux_u.Count > 0)) && (branchredux_v.Count > 0)))                     
                    {
                        var maxlen = Max(branchzip_n.Count,branchzip_o.Count,branchzip_p.Count,branchzip_q.Count,branchzip_r.Count,branchzip_s.Count);
                        var temp = new (A,B,C,D)[maxlen];
                        Parallel.For( 0, maxlen, j =>                         
                        {
                            var zip_nx = branchzip_n[Math.Min(j,(branchzip_n.Count - 1))];
                            var zip_ox = branchzip_o[Math.Min(j,(branchzip_o.Count - 1))];
                            var zip_px = branchzip_p[Math.Min(j,(branchzip_p.Count - 1))];
                            var zip_qx = branchzip_q[Math.Min(j,(branchzip_q.Count - 1))];
                            var zip_rx = branchzip_r[Math.Min(j,(branchzip_r.Count - 1))];
                            var zip_sx = branchzip_s[Math.Min(j,(branchzip_s.Count - 1))];
                            temp[j] = error.Validate((zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v)) ? action(zip_nx,zip_ox,zip_px,zip_qx,zip_rx,zip_sx,branchredux_t,branchredux_u,branchredux_v) : default;
                        });
                        result0.AppendRange(temp.Select(item => item.Item1),path);
                        result1.AppendRange(temp.Select(item => item.Item2),path);
                        result2.AppendRange(temp.Select(item => item.Item3),path);
                        result3.AppendRange(temp.Select(item => item.Item4),path);
                    }
                });
                
                return (result0,result1,result2,result3);
            }


    }

}