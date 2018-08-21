using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ImpalaMethodGenerator.Generators;
using static ImpalaMethodGenerator.Extensions;

namespace ImpalaMethodGenerator
{
    public class ImpalaMethodGenerator
    {

        private static int currentIndentLevel = 0;
        public static string FileName => @"C:\Users\Dan\source\repos\Impala\Impala\Generated.cs";
        public static string InTypes => "TQRPUVQXYZ";
        public static string OutTypes => "ABCDEFGHIJ";
        public static int MaxZipInput => 5;
        public static int MaxZipOutput => 4;


        static void Main(string[] args) 
        {
            System.IO.File.WriteAllText(FileName,"");
            PrintUsings();
            BeginNamespace("Impala");
            BeginClass("Generated");
            GenerateZips();
            EndFlatBlock();
            EndFlatBlock();
            //GenerateZipReduxes(6);
        }

        #region StatefulPrinters
        private static void PrintLines(string[] lines)
        {
            var indent = MakeIndent(currentIndentLevel);
            var iLines = lines.Select(l => indent + l);
            System.IO.File.AppendAllLines(FileName, iLines);
            iLines.DoEach(x => Console.WriteLine(x));
        }

        private static void PrintUsings()
        {
            var usings = new string[]
            {
            "using System;",
            "using System.Collections.Generic;",
            "using System.Linq;",
            "using System.Text;",
            "using System.Threading.Tasks;",
            "",
            "using Grasshopper.Kernel;",
            "using Grasshopper.Kernel.Data;",
            "using Grasshopper.Kernel.Types;",
            "",
            "using static Impala.Utilities;"
            };
            PrintLines(usings);
        }

        private static void BeginNamespace(string name)
        {
            BeginFlatBlock("namespace", name);
        }

        private static void BeginClass(string name)
        {
            BeginFlatBlock("public static class", name);
        }

        private static void BeginFlatBlock(string type, string name)
        {
            PrintLines(new string[] { $"{type} {name}", "{" });
            currentIndentLevel += 1;
        }

        private static void EndFlatBlock()
        {
            currentIndentLevel -= 1;
            PrintLines(new string[] { "}" });
        }

        private static void PrintEmptyLines(int num)
        {
            var empties = IRange(0, num).Select(_ => "").ToArray();
            PrintLines(empties);
        }
        #endregion

        #region Generation Controllers
        public static void GenerateZips()
        {
            for (int i = 2; i < MaxZipInput; i++)
            {
                for (int j = 1; j < MaxZipOutput; j++)
                {
                    var result = GenZipFunction(i, j);
                    PrintEmptyLines(2);
                    PrintLines(result);
                    PrintEmptyLines(2);
                }
            }
        }


        public static void GenerateZipReduxes(int num)
        {
            for (int i = 1; i < num; i++)
            {
                for (int j = 1; j < num; j++)
                {
                    var zips = i;
                    var redx = num - i; 
                    var outs = j;
                    var result = GenZipRedStub(zips, redx, outs);
                    PrintLines(result);
                }
            }
        }

        #endregion

        #region Function Generators
        public static string[] GenZipFunction(int zips, int outs)
        {
            var stub = GenZipStub(zips, outs, out string[] tokens);
            var body = GenZipBody(zips, outs, tokens);
            return stub.Concat(MakeBody(body)).ToArray();
        }

        /// <summary>
        /// Generate the method stub w/o implementation {} for a Zip-Only family method
        /// </summary>
        public static string[] GenZipStub(int zips, int outs, out string[] tokens)
        {
            var name = $"Zip{zips}x{outs}";

            //Input and output types and type constraints
            var oTypes = OutTypes.SelRange(0, outs).MkStrings().ToArray();
            var outputs = MakeNoOneTuple(oTypes.Select(i => $"GH_Structure<{i}>").ToArray(), ",", "(", ")");
            var outWhere = oTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);
            var iTypes = InTypes.SelRange(0, zips).MkStrings().ToArray();
            var inWhere = iTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);

            //generate argument list 
            var ziptokens = iTypes.Select(type => "zip_" + type.ToLower());
            var structargs = ziptokens.Zip(iTypes, (token, type) => $"GH_Structure<{type}> {token}");
            var argTypes = MakeTuple(iTypes.ToArray(), ",", "", "");
            var functype = argTypes + "," + MakeNoOneTuple(oTypes, ",", "(", ")");
            var funcarg = $"Func<{functype}> action";
            var errorarg = $"ErrorChecker<({argTypes})> error";
            var args = structargs.Concat(new string[] { funcarg, errorarg });


            //put it together
            var signature = MakeSignature(outputs, name, iTypes.Concat(oTypes), args);
            var qualifiers = MakeQualifiers(Space + inWhere, Space + outWhere);

            tokens = ziptokens.Append("action", "error").ToArray();
            return signature.Concat(qualifiers).ToArray();
        }


        /// <summary>
        /// Generate a parameterized Zip Body
        /// </summary>
        public static string[] GenZipBody(int zips, int outs, string[] inputTokens)
        {
            //Setup
            var resultList = new List<string>();
            var inTypes = InTypes.SelRange(0, zips).MkStrings().ToArray();
            var structTokens = inputTokens.SelRange(0, zips).ToArray();
            var outTypes = OutTypes.SelRange(0, outs).MkStrings().ToArray();
            var actionToken = inputTokens[zips];
            var errorToken = inputTokens[zips + 1];

            var structures = outTypes.SelEach((_, i) => $"result{i + 1}").ToArray();
            var declareResult = outTypes.SelEach((type, i) => MakeGHStructureDeclaration(structures[i], type.ToString()));
            resultList.AddRange(declareResult);
            resultList.Add("");

            //Define inner tokens for consistency
            var pathsToken = "paths";
            var maxBranchToken = "maxbranch";
            var targPathsToken = "targpath";
            var iterator = "i";
            var pForIterator = "i";
            var innerIterator = "j";
            var maxLenToken = "maxlen";
            var tempToken = "temp";

            //generate target paths from zip
            var branchcounts = structTokens.Select(x => $"{x}.Branches.Count").ToArray();
            var maxbranch = $"var {maxBranchToken} = Max" + MakeFnArgs(branchcounts) + ";";
            var paths = $"var {pathsToken} = GetPathList" + MakeFnArgs(structTokens) + ";";
            resultList.Add(maxbranch);
            resultList.Add(paths);
            resultList.Add("");

            //ensure target paths into zip results
            var targPaths = $"var {targPathsToken} = GetPath({pathsToken},{iterator});";
            var ensurePaths = structures.Select(x => MakeEnsureGHPath(x, targPathsToken));
            var loopBody = new string[] { targPaths }.Concat(ensurePaths);
            var loop = MakeForLoop(iterator, "0", maxBranchToken, loopBody);
            resultList.AddRange(loop);
            resultList.Add("");

            //create tokens
            var branches = structTokens.Select(s => $"branch{s}");
            var items = structTokens.Select(s => s + "x").ToArray();
            var fnargs = MakeFnArgs(items);

            //declare branches in outer loop
            var targPaths2 = $"var {targPathsToken} = GetPath({pathsToken},{pForIterator});";
            var branchDeclare = branches.SelEach((s, i) => MakeDeclareGHBranchIndex(s, structTokens[i], pForIterator));

            //declare conditional in outer loop
            var ifCond = MakeTuple(branches.Select(b => $"{b}.Count > 0").ToArray(), " && ", "", "");
            var maxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";
            var makeTmp = $"{MakeNoOneTuple(outTypes)}[] {tempToken} = new {MakeNoOneTuple(outTypes)}[{maxLenToken}];";

            //declare inner loop
            var innerBody = branches.Select((s, i) => MakeDeclareGHBranchItem(inTypes[i], items[i], s, innerIterator));
            var addTmp = $"{tempToken}[{innerIterator}] = {errorToken}.Validate({fnargs}) ? {actionToken}{fnargs} : default;";

            //Compose back into nested structures
            var innerLoop = MakePForLoop(innerIterator,"0",maxLenToken,innerBody.Append(addTmp));
            //Make sure we're not adding tuples if necessary
            var appendResult = structures.Count() > 1 ? structures.SelEach((s, i) => MakeAppendGHTupleRange(s, tempToken, (i + 1).ToString(), targPathsToken))
                                                      : new string[] { MakeAppendGHItemRange(structures[0], tempToken, targPathsToken) };
            var ifBody = new string[] { maxLen, makeTmp }.Concat(innerLoop).Concat(appendResult);
            var ifStatement = MakeIfStatement(ifCond, ifBody);
            var outerBody = new string[] { targPaths }.Concat(branchDeclare).Concat(ifStatement);
            var outerLoop = MakePForLoop(pForIterator, "0", maxBranchToken, outerBody);
            resultList.AddRange(outerLoop);
            resultList.Add("");

            //Return
            var returnStmt = $"return {MakeFnArgs(structures)};";
            resultList.Add(returnStmt);

            return resultList.ToArray();
        }


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
            var ziptokens = Enumerable.Range(0, zips).Select(i => "zip_" + InTypes[i].ToString().ToLower());
            var reduxtokens = Enumerable.Range(zips, reds).Select(i => "redux_" + InTypes[i].ToString().ToLower());

            //Differentiate Zip and Reduction Types via IEnumerable or List<T>
            var zipTypes = Enumerable.Range(0, zips).Select(i => InTypes[i].ToString());
            var reduxTypes = Enumerable.Range(zips, reds).Select(i => $"List<{InTypes[i].ToString()}>");

            //Create the agument list
            var structargs = ziptokens.Concat(reduxtokens).SelEach((token, i) => $"GH_Structure<{iTypes[i]}> {token}");
            var argTypes = MakeTuple(zipTypes.Concat(reduxTypes).ToArray(), ",", "", "");
            var functype = argTypes + "," + MakeTuple(oTypes, ",", "(", ")");
            var funcarg = $"Func<{functype}> action";
            var errorarg = $"ErrorChecker<({argTypes})> error";
            var args = MakeTuple(structargs.Concat(new string[] { funcarg, errorarg }).ToArray(), ", ", "(", ")");

            //Construct the overall function and body to a line[]
            name += MakeTuple(iTypes.Concat(oTypes).ToArray(), ",", "<", ">"); //Add types to name
            var signature = "public static " + outputs + name;
            var qualifier1 = Space + inWhere;
            var qualifier2 = Space + outWhere;
            var nullout = "return " + MakeTuple(oTypes.Select(_ => "null").ToArray(), ", ", "(", ")") + ";";
            var body = new string[] { "{", Space + nullout, "}" };
            var result = new string[] { signature, args, qualifier1, qualifier2 }.Concat(body).ToArray();

            return result;
        }
        #endregion
    }
}
