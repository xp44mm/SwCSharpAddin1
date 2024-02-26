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
        match data.SpecificModelDoc with
        | ModelSpecific.ModelAssembly assy ->
            for child in data.getChildren() do
                yield! getoutlines (level+1) child
        | ModelSpecific.ModelPart part -> ()
        | _ -> failwith ""
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

//let rec toLines (level:int) (data:RouteComp) =
//    let pad = String.replicate (level*2) " "
//    [
//        yield pad + data.toLine()
//        match data with
//        | Pipe _
//        | Elbow _ 
//        | Reducer _ 
//        | EccentricReducer _ 
//        | Tee _ 
//        | ReducingTee _ 
//        | Flange _ 
//        | Bolt _
//        | DoubleScrewBolt _
//        | Nut _
//        | Washer _
//        | Gasket _
//        | BallValve            _
//        | Expansion            _
//        | Flowmeter            _
//        | MagneticFilter       _
//        | WaferButterflyValve  _
//        | WaferCheckValve      _
//            -> ()
//        | BallValveFlanges (comp,_)
//        | BallValveSolo (comp,_)
//        | ExpansionFlanges (comp,_)
//        | ExpansionSolo (comp,_)
//        | Flanges (comp,_)
//        | FlowmeterFlanges (comp,_)
//        | MagneticFilterFlanges (comp,_)
//        | WaferButterflyValveFlanges (comp,_)
//        | WaferButterflyValveSolo (comp,_)
//        | WaferCheckValveFlanges (comp,_)
//        | GeneralComponent comp ->
//            match comp.SpecificModelDoc with
//            | ModelSpecific.ModelAssembly assy ->
//                for child in RouteComponentApp.getChildren data do
//                    yield! toLines (level+1) child
//            | _ -> ()
//    ]

//// Macro Entry point
//let pipebom (swApp: ISldWorks) =
//    let swRootModel = 
//        swApp.ActiveDoc :?> ModelDoc2

//    // Get it's root component
//    let swRootComp = swRootModel.ConfigurationManager.ActiveConfiguration.GetRootComponent3(true)

//    let rootData = 
//        ComponentData.from swRootComp swRootModel -1
//        |> RouteComponentApp.map

//    let outp = 
//        rootData
//        |> toLines 0
//        |> String.concat "\n"

//    let path = Path.Combine(Dir.CommandData,"pipebom.txt")
//    File.WriteAllText(path,outp,Encoding.UTF8)
//    swApp.SendMsgToUser path
