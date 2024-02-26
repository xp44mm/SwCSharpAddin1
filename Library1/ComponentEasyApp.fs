module ComponentEasyApp

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text
open System.Text.RegularExpressions

open FSharp.SolidWorks
open FSharp.Idioms.Literal

let rec getlines (level:int) (data:ComponentEasy) =
    let pad = String.replicate (level*3) " "
    [
        yield $"{pad}+{data.toLine()}"
        match data.specific with
        | ComponentEasyAssembly (i,children) ->
            for child in children do
                yield! getlines (level+1) child
        | _ -> ()
    ]

let main (swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc :?> ModelDoc2

    let root = 
        swModel
        |> ComponentEasy.fromModel

    let outp = 
        root
        |> getlines 0
        |> String.concat "\n"

    let path = Path.Combine(Dir.CommandData,"component easy.txt")
    File.WriteAllText(path,outp,Encoding.UTF8)
    swApp.SendMsgToUser path
