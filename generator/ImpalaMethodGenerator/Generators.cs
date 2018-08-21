using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static ImpalaMethodGenerator.Extensions;

namespace ImpalaMethodGenerator
{
    public static class Generators
    {
        public static string Space => "    ";

        public static string MakeIndent(int level)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                builder.Append(Space);
            }
            return builder.ToString();
        }


        public static string MakeGHStructureDeclaration(string name, string type)
        {
            return $"var {name} = new GH_Structure<{type}>();";
        }

        public static string MakeEnsureGHPath(string structure, string path)
        {
            return $"{structure}.EnsurePath({path});";
        }

        public static string MakeDeclareGHBranchIndex(string name, string structure, string index)
        {
            return $"var {name} = {structure}.Branches[Math.Min({index}, {structure}.Branches.Count - 1)];";
        }

        public static string MakeDeclareGHBranchItem(string type, string name, string branch, string index)
        {
            return $"{type} {name} = {branch}[Math.Min({branch}.Count - 1, {index})];";
        }

        public static string MakeAppendGHTupleRange(string structure, string range, string tupleIndex, string path)
        {
            return $"{structure}.AppendRange(from item in {range} select item.Item{tupleIndex}, {path});";
        }

        public static string MakeAppendGHItemRange(string structure, string range, string path)
        {
            return $"{structure}.AppendRange({range},{path});";
        }

        public static string[] MakeSignature(string returnType, string name, IEnumerable<string> typeParams, IEnumerable<string> args)
        {
            var tParams = MakeTuple(typeParams.ToArray(), ",", "<", ">");
            var iArgs = MakeTuple(args.ToArray(), ", ", "(", ")");

            return new string[] { "public static " + returnType + name + tParams, iArgs };
        }

        public static string[] MakeQualifiers(params string[] qualifiers)
        {
            return qualifiers;
        }

        public static string[] MakeNullBodyTuple(int num)
        {
            var nullout = "return " + MakeTuple(IRange(0, num).Select(_ => "null").ToArray(), ", ", "(", ")") + ";";
            return new string[] { "{", Space + nullout, "}" };
        }

        /// <summary>
        /// Make a tuple out of an element array. Always caps with start and end.
        /// </summary>
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

        /// <summary>
        /// Make a tuple that returns just the element when there is a single item.
        /// </summary>
        public static string MakeNoOneTuple(string[] elements, string sep, string start, string end)
        {
            if (elements.Length < 2)
            {
                return elements.Length > 0 ? elements[0] : " ";
            }
            else
            {
                return MakeTuple(elements, sep, start, end);
            }
        }

        /// <summary>
        /// Make a default fnargs-style tuple that defaults to a single item.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static string MakeNoOneTuple(string[] elements)
        {
            if (elements.Length < 2)
            {
                return elements.Length > 0 ? elements[0] : " ";
            }
            else
            {
                return MakeTuple(elements, ", ", "(", ")");
            }
        }

        /// <summary>
        /// Make a tuple with defaults to look like (item1, item2, item3).
        /// </summary>
        public static string MakeFnArgs(string[] args)
        {
            return MakeTuple(args, ", ", "(", ")");
        }

        /// <summary>
        /// Create a blocked forLoop
        /// </summary>
        public static string[] MakeForLoop(string iterator, string start, string end, IEnumerable<string> body)
        {
            var loop = $"for (int {iterator} = {start}; {iterator} < {end}; {iterator}++)";
            return new string[] { loop, "{" }.Concat(body.Select(x => Space + x)).Concat(new string[] { "}" }).ToArray();
        }

        /// <summary>
        /// Create a blocked Parallel For loop
        /// </summary>
        public static string[] MakePForLoop(string iterator, string start, string end, IEnumerable<string> body)
        {
            var loop = $"Parallel.For({start},{end},{iterator} =>";
            return new string[] { loop, "{" }.Concat(body.Select(x => Space + x)).Concat(new string[] { "});" }).ToArray();
        }

        /// <summary>
        /// Create a blocked conditional statement
        /// </summary>
        public static string[] MakeIfStatement(string conditional, IEnumerable<string> body)
        {
            var guard = $"if ({conditional})";
            return new string[] { guard, "{" }.Concat(body.Select(x => Space + x)).Concat(new string[] { "}" }).ToArray();
        }

        /// <summary>
        /// Create a blocked generic body
        /// </summary>
        public static string[] MakeBody(IEnumerable<string> body)
        {
            return new string[] { "{" }.Concat(body.Select(x => Space + x)).Append("}").ToArray();
        }
    }
}
