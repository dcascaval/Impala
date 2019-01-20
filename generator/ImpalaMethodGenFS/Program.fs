
module Main

open System
open Generator
open Bindings
open System.IO

// Todo: 
// Fix 0-item branchy boiis 

    [<EntryPoint>]
    let main argv = 
        let file = "C:\\Users\\Dan Cascaval\\Desktop\\Repos\\Impala\\Impala\\TestGeneration.cs"
        let _ = File.WriteAllText(file,"")                // Out with the old 
        let _ = PrintProgram file (GenerateProgram 7 4 4) // In With the  new
        //Console.ReadLine() |> ignore                    // Block for debugger
        0 
