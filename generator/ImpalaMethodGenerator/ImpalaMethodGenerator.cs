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
        public static string InTypes => "TQRPUVWXYZ";
        public static string OutTypes => "ABCDEFGHIJ";
        public static int MaxZipInput => 5;
        public static int MaxZipOutput => 5;

        public static void WriteCommentary()
        {
            var c1 = "///<summary>";
            var c2 = "/// THESE METHODS ARE ENTIRELY GENERATED.";
            var c3 = "/// Any changes made to this file will be overwritten when it is regenerated.";
            var c4 = "/// To make any changes, modify the code in the ImpalaMethodGenerator project.";
            var c5 = "///</summary>";
            PrintLines(Array(c1,c2,c3,c4,c5));
        }

        static void Main(string[] args) 
        {
            System.IO.File.WriteAllText(FileName,"");
            PrintUsings();
            BeginNamespace("Impala");
            WriteCommentary();
            BeginClass("Generated");
            GenerateComposedMethods();
            EndFlatBlock();
            EndFlatBlock();
            
        }

        #region StatefulPrinters
        private static void PrintLines(string[] lines)
        {
            var indent = MakeIndent(currentIndentLevel);
            var iLines = lines.Select(l => indent + l);
            System.IO.File.AppendAllLines(FileName, iLines);
            //iLines.DoEach(x => Console.WriteLine(x));
        }

        private static void PrintPLines(int i, string[] lines)
        {
            PrintEmptyLines(i);
            PrintLines(lines);
            PrintEmptyLines(i);
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
            "using static Impala.Utilities;",
            ""
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
        /// <summary>
        /// Create the composable methods
        /// </summary>
        public static void GenerateComposedMethods()
        {
            var ZipLimit = 7;
            var RedxLimit = 4;
            var outLimit = 5;

            for (int i = 0; i < ZipLimit; i++)
            {
                for (int j = 0; j < RedxLimit; j++)
                {
                    if (i + j > 0 && i + j < InTypes.Length)
                    {
                        for (int k = 1; k < outLimit; k++)
                        {
                            PrintPLines(1, GenComposableFunction(i, j, k, false)); //no graft
                            PrintPLines(1, GenComposableFunction(i, j, k, true));  //graft 
                        }
                    }
                }
            }
        }

        /// <summary>
        /// OBSOLETE: Use composable method
        /// </summary>
        public static void GenerateZips()
        {
            for (int i = 1; i < MaxZipInput; i++)
            {
                for (int j = 1; j < MaxZipOutput; j++)
                {
                    var result = GenZipFunction(i, j);
                    PrintEmptyLines(2);
                    PrintLines(result);
                    PrintEmptyLines(2);
                }
            }
            PrintEmptyLines(2);
            PrintLines(GenZipFunction(6, 1));
            PrintEmptyLines(2);
        }

        /// <summary>
        /// OBSOLETE: Use Composable method
        /// </summary>
        public static void GenerateZipReduxes()
        {

            for (int zips = 1; zips < MaxZipInput; zips++)
            {
                for (int outs = 1; outs < MaxZipOutput; outs++)
                {
                    for (int redx = 1; redx + zips < MaxZipInput; redx++)
                    {
                        PrintEmptyLines(2);
                        var result = GenZipRedxFunction(zips, redx, outs);
                        PrintLines(result);
                        PrintEmptyLines(2);
                    }
                }
            }
        }

        /// <summary>
        /// OBSOLETE: Use Composable method
        /// </summary>
        public static void GenerateZipGrafts()
        {
            for (int i = 1; i < MaxZipInput; i++)
            {
                for (int j = 1; j < MaxZipOutput; j++)
                {
                    PrintEmptyLines(2);
                    var result = GenZipGraftFunction(i, j);
                    PrintLines(result);
                    PrintEmptyLines(2);
                }
            }
        }

        #endregion

        #region Function Generators

        public static string[] GenComposableFunction(int zips, int reds, int outs, bool graft)
        {
            var stub = GenComposableStub(zips, reds, outs, graft, out string[] tokens);
            var body = GenComposableBody(zips, reds, outs, graft, tokens);
            return stub.Concat(MakeBody(body)).ToArray();
        }

        public static string[] GenZipRedxFunction(int zips, int reds, int outs)
        {
            var stub = GenZipRedStub(zips, reds, outs, out string[] tokens);
            var body = GenZipRedBody(zips, reds, outs, tokens);
            return stub.Concat(MakeBody(body)).ToArray();
        }


        public static string[] GenZipFunction(int zips, int outs)
        {
            var stub = GenZipStub(zips, outs, out string[] tokens);
            var body = GenZipBody(zips, outs, tokens);
            return stub.Concat(MakeBody(body)).ToArray();
        }


        public static string[] GenZipGraftFunction(int zips, int outs)
        {
            var stub = GenZipGraftStub(zips, outs, out string[] tokens);
            var body = GenZipGraftBody(zips, outs, tokens);
            return stub.Concat(MakeBody(body)).ToArray();
        }


        public static string ZStr(string r,int v)
        {
            return v > 0 ? r + v: "";
        }

        //Declare global tokens used in all functions for consistency
        private static string actionToken => "action";
        private static string errorToken => "error";
        private static string zipPrefix => "zip_";
        private static string redPrefix => "redux_";
        private static string accessToken => "public static";
        private static string pathsToken => "paths";
        private static string maxBranchToken => "maxbranch";
        private static string prePathsToken => "path";
        private static string targPathsToken => "targpath";
        private static string iterator => "i";
        private static string pForIterator => "i";
        private static string innerIterator => "j";
        private static string maxLenToken => "maxlen";
        private static string computeToken => "compute";
        private static string tempToken => "temp";

        //Todo: Condense similar functions into reusable code. There are only slight difference between the stubs,
        //and the bodies are also quite similar (esp. Zip and ZipRedX)

        public static string[] GenComposableStub(int zips, int reduxes, int outs, bool graft, out string[] tokens)
        {
            // $Zip2Red1xOut3Graft2
            string name = $"{ZStr("Zip",zips)}{ZStr("Red",reduxes)}x{(graft ? "Graft" : "")}{outs}";

            //Output type list and type qualifiers
            var oTypes = IRange(0, outs).Select(i => OutTypes[i].ToString()).ToArray();
            var outputs = MakeNoOneTuple(oTypes.Select(i => $"GH_Structure<{i}>").ToArray());
            var outWhere = oTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);

            //Input type list and type qualifiers
            var iTypes = IRange(0, zips + reduxes).Select(i => InTypes[i].ToString()).ToArray();
            var inWhere = iTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);

            //Differentiate Zip and Reduction tokens with prefixes
            var ziptokens = IRange(0, zips).Select(i => zipPrefix + InTypes[i].ToString().ToLower());
            var reduxtokens = IRange(zips, zips + reduxes).Select(i => redPrefix + InTypes[i].ToString().ToLower());

            //Differentiate Zip and Reduction Types via List<T> or T[]. Benchmark to check?
            var zipTypes = IRange(0, zips).Select(i => InTypes[i].ToString());
            var reduxTypes = IRange(zips, zips + reduxes).Select(i => $"List<{InTypes[i].ToString()}>");

            //Create the agument list
            var structargs = ziptokens.Concat(reduxtokens).SelEach((token, i) => $"GH_Structure<{iTypes[i]}> {token}");
            var argTypes = MakeTuple(zipTypes.Concat(reduxTypes).ToArray(), ",", "", "");
            var compOTypes = oTypes.Select(typ => graft ? typ + "[]" : typ).ToArray();
            var functype = argTypes + "," + MakeNoOneTuple(compOTypes);
            var funcarg = $"Func<{functype}> {actionToken}";           // Func<T,(C, A[], B[])> action
            var errorarg = $"ErrorChecker<{(zips+reduxes > 1 ? $"({argTypes})" : argTypes)}> {errorToken}"; // ErrorChecker<T> error
            var args = MakeFnArgs(structargs.Append(funcarg, errorarg).ToArray()); 

            //Construct the overall function and body to a line[]
            var typedname = name + MakeTuple(iTypes.Concat(oTypes).ToArray(), ",", "<", ">"); //Add types to name
            var signature = accessToken + " " + outputs + typedname;
            var qualifier1 = Space + inWhere;
            var qualifier2 = Space + outWhere;
            var result = new string[] { signature, args, qualifier1, qualifier2 };

            tokens = ziptokens.Concat(reduxtokens).Append(actionToken, errorToken).ToArray();
            return result;
        }

        public static string[] GenComposableBody(int zips, int reduxes, int outs, bool graft, string[] inputTokens)
        {
            //Setup
            var resultList = new List<string>();
            var inTypes = InTypes.SelRange(0, zips).MkStrings().ToArray();
            var zipTokens = inputTokens.SelRange(0, zips).ToArray();
            var redTokens = inputTokens.SelRange(zips, zips + reduxes).ToArray();

            var outTypes = OutTypes.SelRange(0, outs).MkStrings().ToArray();
            var actionToken = inputTokens[zips + reduxes];
            var errorToken = inputTokens[zips + reduxes + 1];

            //Declare result structures
            var resultStructs = outTypes.SelEach((_, i) => $"result{i + 1}").ToArray();
            var declareResult = outTypes.SelEach((type, i) => MakeGHStructureDeclaration(resultStructs[i], type.ToString()));
            resultList.AddRange(declareResult);
            resultList.Add("");

            //generate target paths from zip
            var structTokens = zipTokens.Concat(redTokens).ToArray();
            var branchcounts = structTokens.Select(x => $"{x}.Branches.Count").ToArray();
            var maxbranch = $"var {maxBranchToken} = Max" + MakeFnArgs(branchcounts) + ";";
            var paths = $"var {pathsToken} = GetPathList" + MakeFnArgs(structTokens) + ";";
            resultList.Add(maxbranch);
            resultList.Add(paths);
            resultList.Add("");

            //create tokens
            var branches = zipTokens.Select(s => $"branch{s}");
            var redxbranches = redTokens.Select(r => $"rxbranch{r}");
            var allBranches = branches.Concat(redxbranches);
            var items = zipTokens.Select(s => s + "x").ToArray();
            var allItems = items.Concat(redxbranches).ToArray();
            var fnargs = MakeFnArgs(items);

            //ensure target paths into zip results
            var loop = GeneratePathEnsureLoop(branches, structTokens, resultStructs, graft);
            resultList.AddRange(loop);
            resultList.Add("");

            //declare branches in outer loop
            //$"var ba = a.Branches[Math.Min((i, a.Branches.Count - 1)];"
            var targPaths2 = $"var {prePathsToken} = GetPath({pathsToken},{pForIterator});";
            var branchDeclare = allBranches.SelEach((s, i) => MakeDeclareGHBranchIndex(s, inputTokens[i], pForIterator));

            //declare conditional in outer loop
            var ifCond = MakeTuple(allBranches.Select(b => $"{b}.Count > 0").ToArray(), " && ", "", "");
            var maxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";
            var ifBody = graft ? GenerateInnerGraftConditional(branches, resultStructs, allItems, inTypes, outTypes, maxLen) :
                                 GenerateInnerConditional(branches, resultStructs, allItems, inTypes, outTypes, maxLen);

            var ifStatement = MakeIfStatement(ifCond, ifBody);
            var outerBody = new string[] { targPaths2 }.Concat(branchDeclare).Concat(ifStatement);
            var outerLoop = MakePForLoop(pForIterator, "0", maxBranchToken, outerBody);
            resultList.AddRange(outerLoop);
            resultList.Add("");

            //Return
            var returnStmt = $"return {MakeFnArgs(resultStructs)};";
            resultList.Add(returnStmt);

            return resultList.ToArray();
        }

        public static string[] GeneratePathEnsureLoop(IEnumerable<string> branches, string[] structTokens, 
                                                     IEnumerable<string> resultStructs, bool graft)
        {
            //Ensure target paths into zip results
            if (graft)
            {
                var prePaths = $"var {prePathsToken} = GetPath({pathsToken},{iterator});";
                var ensbranchDeclare = branches.SelEach((s, i) => MakeDeclareGHBranchIndex(s, structTokens[i], iterator));
                var ensmaxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";

                var targPaths = $"var {targPathsToken} = {prePathsToken}.AppendElement({innerIterator});";
                var ensurePaths = resultStructs.Select(x => MakeEnsureGHPath(x, targPathsToken));
                var innerLoopBody = new string[] { targPaths }.Concat(ensurePaths);
                var innerloop = MakeForLoop(innerIterator, "0", maxLenToken, innerLoopBody);


                var loopbody = new string[] { prePaths }.Concat(ensbranchDeclare).Append(ensmaxLen).Concat(innerloop);
                var loop = MakeForLoop(iterator, "0", maxBranchToken, loopbody);
                return loop;
            }
            else
            {
                var targPaths = $"var {targPathsToken} = GetPath({pathsToken},{iterator});";
                var ensurePaths = resultStructs.Select(x => MakeEnsureGHPath(x, targPathsToken));
                var loopBody = new string[] { targPaths }.Concat(ensurePaths);
                var loop = MakeForLoop(iterator, "0", maxBranchToken, loopBody);
                return loop;
            }
        }

        public static string[] GenerateInnerGraftConditional(IEnumerable<string> branches, string[] structures, string[] items,
                                                            string[] inTypes, IEnumerable<string> outTypes, string maxLen)
        {
            var fnargs = MakeNoOneTuple(items);
            var actargs = MakeFnArgs(items);

            //declare inner loop
            var innerDeclares = branches.Select((s, i) => MakeDeclareGHBranchItem(inTypes[i], items[i], s, innerIterator));
            var defaultTuples = MakeFnArgs(outTypes.Select(t => $"new {t}[0]").ToArray());
            var compute = $"var {computeToken} = {errorToken}.Validate({fnargs}) ? {actionToken}{actargs} : {defaultTuples};";
            var tpath = $"var {targPathsToken} = {prePathsToken}.AppendElement({innerIterator});";
            var appendResult = structures.Count() > 1 ? structures.SelEach((s, i) => MakeAppendGHItemRange(s, computeToken + ".Item" + (i + 1).ToString(), targPathsToken))
                                                        : Array(MakeAppendGHItemRange(structures[0], computeToken, targPathsToken));

            //Compose back into nested structures
            var innerBody = innerDeclares.Append(compute, tpath).Concat(appendResult);
            var innerPForLoop = MakePForLoop(innerIterator, "0", maxLenToken, innerBody);

            return Array(maxLen).Concat(innerPForLoop).ToArray();
        }


        public static string[] GenerateInnerConditional(IEnumerable<string> branches, string[] resultStructs, string[] items,
                                                        string[] inTypes, string[] outTypes, string maxlen)
        {
            var fnargs = MakeNoOneTuple(items);
            var actargs = MakeFnArgs(items);

            var maxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";
            var makeTmp = $"{MakeNoOneTuple(outTypes)}[] {tempToken} = new {MakeNoOneTuple(outTypes)}[{maxLenToken}];";

            //declare inner loop
            var innerBody = branches.Select((s, i) => MakeDeclareGHBranchItem(inTypes[i], items[i], s, innerIterator));
            var addTmp = $"{tempToken}[{innerIterator}] = {errorToken}.Validate({fnargs}) ? {actionToken}{actargs} : default;";

            //Compose back into nested structures
            var innerLoop = MakePForLoop(innerIterator, "0", maxLenToken, innerBody.Append(addTmp));
            //Make sure we're not adding tuples if necessary
            var appendResult = resultStructs.Count() > 1 ? resultStructs.SelEach((s, i) => MakeAppendGHTupleRange(s, tempToken, (i + 1).ToString(), prePathsToken))
                                                         : Array(MakeAppendGHItemRange(resultStructs[0], tempToken, prePathsToken));
            return Array(maxlen,makeTmp).Concat(innerLoop).Concat(appendResult).ToArray();
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
            var errorArgs = MakeNoOneTuple(iTypes.ToArray());
            
            var functype = argTypes + "," + MakeNoOneTuple(oTypes, ",", "(", ")");
            var funcarg = $"Func<{functype}> action";
            var errorarg = $"ErrorChecker<{errorArgs}> error";
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
            var fnargs = MakeNoOneTuple(items);
            var actargs = MakeFnArgs(items);

            //declare branches in outer loop
            var targPaths2 = $"var {targPathsToken} = GetPath({pathsToken},{pForIterator});";
            var branchDeclare = branches.SelEach((s, i) => MakeDeclareGHBranchIndex(s, structTokens[i], pForIterator));

            //declare conditional in outer loop
            var ifCond = MakeTuple(branches.Select(b => $"{b}.Count > 0").ToArray(), " && ", "", "");
            var maxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";
            var makeTmp = $"{MakeNoOneTuple(outTypes)}[] {tempToken} = new {MakeNoOneTuple(outTypes)}[{maxLenToken}];";

            //declare inner loop
            var innerBody = branches.Select((s, i) => MakeDeclareGHBranchItem(inTypes[i], items[i], s, innerIterator));
            var addTmp = $"{tempToken}[{innerIterator}] = {errorToken}.Validate({fnargs}) ? {actionToken}{actargs} : default;";

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

        /// <summary>
        /// Generate a parameterized, generic ZipRedux stub
        /// </summary>
        public static string[] GenZipRedStub(int zips, int reds, int outs, out string[] tokens)
        {
            var name = $"Zip{zips}Red{reds}x{outs}";

            //Output type list and type qualifiers
            var oTypes = IRange(0, outs).Select(i => OutTypes[i].ToString()).ToArray();
            var outputs = MakeNoOneTuple(oTypes.Select(i => $"GH_Structure<{i}>").ToArray());
            var outWhere = oTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);

            //Input type list and type qualifiers
            var iTypes = IRange(0, zips + reds).Select(i => InTypes[i].ToString()).ToArray();
            var inWhere = iTypes.Select(i => $"where {i} : IGH_Goo").Aggregate((a, b) => a + " " + b);

            //Differentiate Zip and Reduction tokens with prefixes
            var ziptokens = IRange(0, zips).Select(i => "zip_" + InTypes[i].ToString().ToLower());
            var reduxtokens = IRange(zips, zips + reds).Select(i => "redux_" + InTypes[i].ToString().ToLower());

            //Differentiate Zip and Reduction Types via IEnumerable or List<T>
            var zipTypes = IRange(0, zips).Select(i => InTypes[i].ToString());
            var reduxTypes = IRange(zips, zips + reds).Select(i => $"List<{InTypes[i].ToString()}>");

            //Create the agument list
            var actionToken = "action";
            var errorToken = "error";

            var structargs = ziptokens.Concat(reduxtokens).SelEach((token, i) => $"GH_Structure<{iTypes[i]}> {token}");
            var argTypes = MakeTuple(zipTypes.Concat(reduxTypes).ToArray(), ",", "", "");
            var functype = argTypes + "," + MakeNoOneTuple(oTypes);
            var funcarg = $"Func<{functype}> {actionToken}";
            var errorarg = $"ErrorChecker<({argTypes})> {errorToken}";
            var args = MakeFnArgs(structargs.Append(funcarg,errorarg).ToArray());

            //Construct the overall function and body to a line[]
            name += MakeTuple(iTypes.Concat(oTypes).ToArray(), ",", "<", ">"); //Add types to name
            var signature = "public static " + outputs + name;
            var qualifier1 = Space + inWhere;
            var qualifier2 = Space + outWhere;
            var nullout = "return " + MakeTuple(oTypes.Select(_ => "null").ToArray(), ", ", "(", ")") + ";";
            var result = new string[] { signature, args, qualifier1, qualifier2 };

            tokens = ziptokens.Concat(reduxtokens).Append(actionToken, errorToken).ToArray();
            return result;
        }

        /// <summary>
        /// Generate a parameterized, generix ZipReduction function body
        /// </summary>
        public static string[] GenZipRedBody(int zips, int reds, int outs, string[] inputTokens)
        {
            //Setup
            var resultList = new List<string>();
            var inTypes = InTypes.SelRange(0, zips).MkStrings().ToArray();
            var zipTokens = inputTokens.SelRange(0, zips).ToArray();
            var redTokens = inputTokens.SelRange(zips,zips + reds).ToArray();
            
            var outTypes = OutTypes.SelRange(0, outs).MkStrings().ToArray();
            var actionToken = inputTokens[zips + reds];
            var errorToken = inputTokens[zips + reds + 1];

            //Declare result structures
            var resultStructs = outTypes.SelEach((_, i) => $"result{i + 1}").ToArray();
            var declareResult = outTypes.SelEach((type, i) => MakeGHStructureDeclaration(resultStructs[i], type.ToString()));
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
            var branchcounts = zipTokens.Concat(redTokens).Select(x => $"{x}.Branches.Count").ToArray();
            var maxbranch = $"var {maxBranchToken} = Max" + MakeFnArgs(branchcounts) + ";";
            var paths = $"var {pathsToken} = GetPathList" + MakeFnArgs(zipTokens.Concat(redTokens).ToArray()) + ";";
            resultList.Add(maxbranch);
            resultList.Add(paths);
            resultList.Add("");

            //ensure target paths into zip results
            var targPaths = $"var {targPathsToken} = GetPath({pathsToken},{iterator});";
            var ensurePaths = resultStructs.Select(x => MakeEnsureGHPath(x, targPathsToken));
            var loopBody = new string[] { targPaths }.Concat(ensurePaths);
            var loop = MakeForLoop(iterator, "0", maxBranchToken, loopBody);
            resultList.AddRange(loop);
            resultList.Add("");

            //create tokens
            var branches = zipTokens.Select(s => $"branch{s}");
            var redxbranches = redTokens.Select(r => $"redx{r}");
            var items = zipTokens.Select(s => s + "x").ToArray();
            var fnargs = MakeFnArgs(items.Concat(redxbranches).ToArray());

            //declare branches in outer loop
            //$"var ba = a.Branches[Math.Min((i, a.Branches.Count - 1)];"
            var targPaths2 = $"var {targPathsToken} = GetPath({pathsToken},{pForIterator});";
            var branchDeclare = branches.Concat(redxbranches).SelEach((s, i) => MakeDeclareGHBranchIndex(s, inputTokens[i], pForIterator));

            //declare conditional in outer loop
            var ifCond = MakeTuple(branches.Concat(redxbranches).Select(b => $"{b}.Count > 0").ToArray(), " && ", "", "");
            var maxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";
            var makeTmp = $"{MakeNoOneTuple(outTypes)}[] {tempToken} = new {MakeNoOneTuple(outTypes)}[{maxLenToken}];";

            //declare inner loop
            var innerBody = branches.Select((s, i) => MakeDeclareGHBranchItem(inTypes[i], items[i], s, innerIterator));
            var addTmp = $"{tempToken}[{innerIterator}] = {errorToken}.Validate({fnargs}) ? {actionToken}{fnargs} : default;";

            //Compose back into nested structures
            var innerLoop = MakePForLoop(innerIterator, "0", maxLenToken, innerBody.Append(addTmp));
            //Make sure we're not adding tuples if necessary
            var appendResult = resultStructs.Count() > 1 ? resultStructs.SelEach((s, i) => MakeAppendGHTupleRange(s, tempToken, (i + 1).ToString(), targPathsToken))
                                                         : new string[] { MakeAppendGHItemRange(resultStructs[0], tempToken, targPathsToken) };
            var ifBody = new string[] { maxLen, makeTmp }.Concat(innerLoop).Concat(appendResult);
            var ifStatement = MakeIfStatement(ifCond, ifBody);
            var outerBody = new string[] { targPaths }.Concat(branchDeclare).Concat(ifStatement);
            var outerLoop = MakePForLoop(pForIterator, "0", maxBranchToken, outerBody);
            resultList.AddRange(outerLoop);
            resultList.Add("");

            //Return
            var returnStmt = $"return {MakeFnArgs(resultStructs)};";
            resultList.Add(returnStmt);

            return resultList.ToArray();
        }

        /// <summary>
        /// Generate the method stub w/o implementation {} for a Zip-Only family method
        /// </summary>
        public static string[] GenZipGraftStub(int zips, int outs, out string[] tokens)
        {
            var name = $"ZipGraft{zips}x{outs}";

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
            var errorArgTypes = MakeNoOneTuple(iTypes.ToArray());
            var outArrays = oTypes.Select(o => o + "[]").ToArray();
            var functype = argTypes + "," + MakeNoOneTuple(outArrays, ",", "(", ")");
            var funcarg = $"Func<{functype}> action";
            var errorarg = $"ErrorChecker<{errorArgTypes}> error";
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
        public static string[] GenZipGraftBody(int zips, int outs, string[] inputTokens)
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


            //create tokens
            var branches = structTokens.Select(s => $"branch{s}");
            var items = structTokens.Select(s => s + "x").ToArray();
            var fnargs = MakeNoOneTuple(items);
            var actargs = MakeFnArgs(items);


            //generate target paths from zip
            var branchcounts = structTokens.Select(x => $"{x}.Branches.Count").ToArray();
            var maxbranch = $"var {maxBranchToken} = Max" + MakeFnArgs(branchcounts) + ";";
            var paths = $"var {pathsToken} = GetPathList" + MakeFnArgs(structTokens) + ";";
            resultList.Add(maxbranch);
            resultList.Add(paths);
            resultList.Add("");

            //ensure target paths into zip results
            var prePaths = $"var {prePathsToken} = GetPath({pathsToken},{iterator});";
            var ensbranchDeclare = branches.SelEach((s, i) => MakeDeclareGHBranchIndex(s, structTokens[i], iterator));
            var ensmaxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";
            var targPaths = $"var {targPathsToken} = {prePathsToken}.AppendElement({innerIterator});";
            var ensurePaths = structures.Select(x => MakeEnsureGHPath(x, targPathsToken));
            var innerLoopBody = new string[] { targPaths }.Concat(ensurePaths);
            var innerloop = MakeForLoop(innerIterator, "0", maxLenToken, innerLoopBody);
            var loopbody = new string[] { prePaths }.Concat(ensbranchDeclare).Append(ensmaxLen).Concat(innerloop);
            var loop = MakeForLoop(iterator, "0", maxBranchToken, loopbody);
            resultList.AddRange(loop);
            resultList.Add("");

            //declare branches in outer loop
            var prePaths2 = $"var {prePathsToken} = GetPath({pathsToken},{pForIterator});";
            var branchDeclare = branches.SelEach((s, i) => MakeDeclareGHBranchIndex(s, structTokens[i], pForIterator));

            //declare conditional in outer loop
            var ifCond = MakeTuple(branches.Select(b => $"{b}.Count > 0").ToArray(), " && ", "", "");
            var maxLen = $"int {maxLenToken} = Max" + MakeFnArgs(branches.Select(b => $"{b}.Count").ToArray()) + ";";

            //declare inner loop
            var innerDeclares = branches.Select((s, i) => MakeDeclareGHBranchItem(inTypes[i], items[i], s, innerIterator));
            var defaultTuples = MakeFnArgs(outTypes.Select(t => $"new {t}[0]").ToArray());
            var compute = $"var {computeToken} = {errorToken}.Validate({fnargs}) ? {actionToken}{actargs} : {defaultTuples};";
            var tpath = $"var {targPathsToken} = {prePathsToken}.AppendElement({innerIterator});";
            var appendResult = structures.Count() > 1 ? structures.SelEach((s, i) => MakeAppendGHItemRange(s, computeToken + ".Item" + (i + 1).ToString(), targPathsToken))
                                                      : new string[] { MakeAppendGHItemRange(structures[0], computeToken, targPathsToken) };

            //Compose back into nested structures
            var innerBody = innerDeclares.Append(compute, tpath).Concat(appendResult);
            var innerPForLoop = MakePForLoop(innerIterator, "0", maxLenToken, innerBody);

            var ifBody = new string[] { maxLen }.Concat(innerPForLoop);
            var ifStatement = MakeIfStatement(ifCond, ifBody);
            var outerBody = new string[] { prePaths2 }.Concat(branchDeclare).Concat(ifStatement);
            var outerPForLoop = MakePForLoop(pForIterator, "0", maxBranchToken, outerBody);
            resultList.AddRange(outerPForLoop);
            resultList.Add("");

            //Return
            var returnStmt = $"return {MakeFnArgs(structures)};";
            resultList.Add(returnStmt);

            return resultList.ToArray();
        }

        #endregion

    }
}
