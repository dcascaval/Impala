
module Main

open Generator
open Bindings
open System.IO

    [<EntryPoint>]
    let main argv = 
        let file = ".\\..\\..\\..\\..\\Impala\\Generated.cs"
        let _ = File.WriteAllText(file,"")                // Out with the old 
        let _ = PrintProgram file (GenerateProgram 7 4 4) // In With the  new
        0 
