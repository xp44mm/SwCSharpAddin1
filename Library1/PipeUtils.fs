module rec PipeComponents.PipeUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text
open System.Text.RegularExpressions

open FSharp.SolidWorks
open FSharp.Idioms.Literal

let rec getoutlines (level:int) (data:ComponentData) =
    let pad = String.replicate (level*2) " "
    [
        yield $"{pad}+{data.toLine()}"
        match data.Specific with
        | ComponentDataAssembly _ 
        | ComponentDataRouteAssembly _ ->
            for child in data.getChildren() do
                yield! getoutlines (level+1) child
        | ComponentDataPart part -> ()
    ]

// Macro Entry point
let main (swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc :?> ModelDoc2

    let rootData = 
        swModel
        |> ComponentData.fromModel

    let outp = 
        rootData
        |> getoutlines 0
        |> String.concat "\n"

    let path = Path.Combine(Dir.CommandData,"comp.txt")
    File.WriteAllText(path,outp)
    swApp.SendMsgToUser path
