using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGen
{

    public static class Generators{

        public static MakeGHStructure(string name, string type)
        {
            return $"var {name} = new GH_Structure<{type}>();";
        }

        public static EnsureGHPath(string structure,string path)
        {
            return $"{structure}.EnsurePath({path})";
        }

        public static GetGHBranch(string name, string structure, string index)
        {
            return $"var {name} = {structure}.Branches[Math.Min({index}, {structure}.Branches.Count - 1)];";
        }

        public static AppendGHTupleRange(string structure, string range, string tupleIndex, string path)
        {
            return $"{structure}.AppendRange(from item in {range} select item.Item{tupleIndex}, {path});";
        }
    }
    /*
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
     */


    /* 
    public static (GH_Structure<A>,GH_Structure<B>, GH_Structure<C>,GH_Structure<D>) Zip2Red1x4<T,Q,R,A,B,C,D>
           (GH_Structure<T> a, GH_Structure<Q> b, GH_Structure<R> redux, 
            Func<T, Q, List<R>, (A, B, C, D)> action, ErrorChecker<(T, Q, List<R>)> error)
            where T : IGH_Goo where Q : IGH_Goo where R : IGH_Goo
            where A : IGH_Goo where B : IGH_Goo where C : IGH_Goo where D : IGH_Goo
        {
            return (null,null,null,null)
        }
    */


    class Program
    {

        /// Generate a parameterized, generic ZipRedux stub
        public static string[] GenZipRedStub(int zips, int reds, int outs)
        {
            var name = $"Zip{zips}Red{reds}x{outs}";
            
            //Output type list and type qualifiers
            var oTypes = Enumerable.Range(0, outs).Select(i => OutTypes[i].ToString()).ToArray();
            var outputs = MakeTuple(oTypes.Select(i => $"GH_Structure<{i}>").ToArray(), ",", "(", ")");
            var outWhere = oTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);

            //Input type list and type qualifiers
            var iTypes = Enumerable.Range(0, zips + reds).Select(i => InTypes[i].ToString()).ToArray();
            var inWhere = iTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);

            //Differentiate Zip and Reduction tokens with prefixes
            var ziptokens = Enumerable.Range(0,zips).Select(i => "zip_"+InTypes[i].ToString().ToLower());
            var reduxtokens = Enumerable.Range(zips,reds).Select(i => "redux_"+InTypes[i].ToString().ToLower());

            //Differentiate Zip and Reduction Types via IEnumerable or List<T>
            var zipTypes = Enumerable.Range(0, zips).Select(i => InTypes[i].ToString());
            var reduxTypes = Enumerable.Range(zips,reds).Select(i => $"List<{InTypes[i].ToString()}>");
            
            //Create the agument list
            var structargs = ziptokens.Concat(reduxtokens).SelEach((token,i) => $"GH_Structure<{iTypes[i]}> {token}");
            var argTypes = MakeTuple(zipTypes.Concat(reduxTypes).ToArray(),",","",""); 
            var functype = argTypes + "," + MakeTuple(oTypes,",","(",")");         
            var funcarg = $"Func<{functype}> action";
            var errorarg  = $"ErrorChecker<({argTypes})> error";
            var args = MakeTuple(structargs.Concat(new string[]{funcarg, errorarg}).ToArray(), ", ", "(", ")");

            //Construct the overall function and body to a line[]
            name += MakeTuple(iTypes.Concat(oTypes).ToArray(), ",", "<", ">"); //Add types to name
            var space = "    ";
            var signature = "public static " + outputs + name;
            var qualifier1 = space + inWhere;
            var qualifier2 = space + outWhere;
            var nullout = "return " + MakeTuple(oTypes.Select(_ => "null").ToArray(), ", ", "(", ")") + ";";
            var body = new string[] { "{", space + nullout, "}" };
            var result = new string[] { signature, args, qualifier1, qualifier2 }.Concat(body).ToArray();

            return result;
        }

        static void Main(string[] args) 
        {
            GenerateZipReduxes(6);
        }

        public static GenerateZipReduxes(int num)
        {
            for (int i = 1; i < num; i++)
            {
                for (int j = 1; j < num; j++)
                {
                    var zips = i;
                    var redx = num - i; 
                    var outs = j;
                    var result = GenZipRedStub(zips, redx, outs);
                    System.IO.File.AppendAllLines(@"generated.txt", result);
                    result.DoEach(x => System.Console.WriteLine(x));
                }
            }
        }

        public static string InTypes => "TQRPUVQXYZ";
        public static string OutTypes => "ABCDEFGHIJ";

        public static string MakeTuple(string[] elements, string sep, string start, string end)
        {
            var str = new StringBuilder();
            for (int i = 0; i < elements.Length - 1; i++)
            {
                str.Append(elements[i]);
                str.Append(sep);
            }
            str.Append(elements[elements.Length - 1]);
            return start + str.ToString() + end;
        }

    }

    public static class Extensions{
        
        public static IEnumerable<Q> SelEach<T,Q>(this IEnumerable<T> collection, Func<T,int,Q> action)
        {
            int i = 0; 
            var result = new List<Q>();
            foreach(var item in collection)
            {
                result.Add(action(item,i)); 
                i++;
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
    }
}
