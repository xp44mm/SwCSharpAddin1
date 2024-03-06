module RouteWrapperApp

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text
open System.Text.RegularExpressions

open FSharp.SolidWorks
open FSharp.Idioms
open FSharp.Idioms.Literal


let main (swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc :?> ModelDoc2

    let root = 
        swModel
        |> ComponentEasy.fromModel
        |> RouteComponentConstructor.toroute
    let outp = 
        root
        |> RouteComponentApp.tojson
        |> Json.print
    let path = Path.Combine(Dir.CommandData,"route.json")
    File.WriteAllText(path,outp,Encoding.UTF8)
    swApp.SendMsgToUser path
