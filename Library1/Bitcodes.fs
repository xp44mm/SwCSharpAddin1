module Bitcodes

open System.IO
open System.Text
open System.Collections.Generic

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal

let parseToMap (text:string) =
    let tbl = Tsv.parseText text
    let dict = new Dictionary<_,_>(System.StringComparer.OrdinalIgnoreCase)
    tbl
    |> Array.map(fun arr ->
        let bitcode = arr.[0]
        let file = if arr.Length > 1 then arr.[1] else ""
        let config = if arr.Length > 2 then arr.[2] else ""
        bitcode,file,config
    )
    |> Array.iter(fun (bitcode,file,config) ->
        dict.Add(bitcode,(file,config))
    )
    dict
