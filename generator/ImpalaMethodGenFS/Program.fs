
module Main

open System
open Generator
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

    [<EntryPoint>]
    let main argv = 
        printf "%s" (FmtFunction (generateFunction 2 3 2 true)) 
        Console.ReadLine() |> ignore
        0 // return an integer exit code
