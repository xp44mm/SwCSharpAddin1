module ComponentArchiveApp


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
        |> ComponentArchive.from

    let json = ComponentArchiveJson.from root
    let js = Json.print json
    let path = Path.Combine(Dir.CommandData,"component archive.json")
    File.WriteAllText(path,js,Encoding.UTF8)
    swApp.SendMsgToUser path
