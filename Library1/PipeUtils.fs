module rec PipeComponents.PipeUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.SolidWorks
open FSharp.Idioms.Literal

let rec getoutlines (level:int) (data:ComponentData) =
    let pad = String.replicate (level*2) " "
    [
        yield $"{pad}+{data.toLine()}"
        match data.SpecificModelDoc with
        | ModelSpecific.ModelAssembly assy ->
            for child in data.getChildren() do
                yield! getoutlines (level+1) child
        | ModelSpecific.ModelPart part -> ()
        | _ -> failwith ""
    ]

// Macro Entry point
let main (swApp: ISldWorks) =
    let swRootModel = 
        swApp.ActiveDoc :?> ModelDoc2

    // Get it's root component
    let swRootComp = swRootModel.ConfigurationManager.ActiveConfiguration.GetRootComponent3(true)

    let rootData = ComponentData.from swRootComp swRootModel -1

    let outp = 
        rootData
        |> getoutlines 0
        |> String.concat "\n"

    let path = Path.Combine(Dir.CommandData,"comp.txt")
    File.WriteAllText(path,outp)
    swApp.SendMsgToUser path

let rec toLines (level:int) (data:RouteComp) =
    let pad = String.replicate (level*2) " "
    [
        match data with
        | Pipe _
        | Elbow _ 
        | Reducer _ 
        | EccentricReducer _ 
        | Tee _ 
        | ReducingTee _ 
        | Flange _ 
        | Valve _ 
        | Bolt _
        | Nut _
        | Gasket _
            -> yield pad + data.toLine()
        | Flanges(comp,fls) ->
            yield $"{pad}+Flanges {stringify fls}"
            match comp.SpecificModelDoc with
            | ModelSpecific.ModelAssembly assy ->
                for child in RouteComponentSpecies.getChildren data do
                    yield! toLines (level+1) child
            | _ -> ()

        | GeneralComponent comp ->
            yield $"{pad}+{comp.toLine()}"
            match comp.SpecificModelDoc with
            | ModelSpecific.ModelAssembly assy ->
                for child in RouteComponentSpecies.getChildren data do
                    yield! toLines (level+1) child
            | _ -> ()

        | _ -> failwith ""
    ]

// Macro Entry point
let pipebom (swApp: ISldWorks) =
    let swRootModel = 
        swApp.ActiveDoc :?> ModelDoc2

    // Get it's root component
    let swRootComp = swRootModel.ConfigurationManager.ActiveConfiguration.GetRootComponent3(true)

    let rootData = 
        ComponentData.from swRootComp swRootModel -1
        |> RouteComponentSpecies.map

    let outp = 
        rootData
        |> toLines 0
        |> String.concat "\n"

    let path = Path.Combine(Dir.CommandData,"pipebom.txt")
    File.WriteAllText(path,outp)
    swApp.SendMsgToUser path
