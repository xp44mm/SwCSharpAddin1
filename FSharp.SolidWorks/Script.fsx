// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.


// Define your library scripting code here

open System
open System.Collections
open System.Collections.Generic

let hs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)

[
    "a";"b";"c"
]
|> Seq.iter(fun s -> hs.Add s |> ignore)

hs.IntersectWith ["B";"C"]

let ls = hs |> Seq.toList

ls