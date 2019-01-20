
module Main

open System
open Generator
open Bindings

    [<EntryPoint>]
    let main argv = 
        printf "%s" (FmtFunction (GenerateFunction 2 3 2 true)) 
        Console.ReadLine() |> ignore // Block for debugger
        0 
