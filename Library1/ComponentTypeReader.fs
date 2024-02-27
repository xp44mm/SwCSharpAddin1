module ComponentTypeReader

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text
open System.Text.RegularExpressions

open FSharp.SolidWorks
open FSharp.Idioms.Literal

let main (swApp: ISldWorks) =
    let tryRead (exer: OpenDocExecutor) =
        let swModel = exer.openDoc(swApp)

        let custPropMgr = swModel.Extension.CustomPropertyManager("")
        let propName = "Component Type"
        let maybeValue =
            if CustomPropertyManagerUtils.contains propName custPropMgr then
                custPropMgr
                |> CustomPropertyManagerUtils.GetUpdatedProperty propName
                |> snd
                |> Some
            else None
        // Close Document
        swModel.GetPathName()
        |> swApp.CloseDoc
        maybeValue
    let paths = 
        let x = @"D:\Application Data\SolidWorks\SW Design Library\routing\components.txt"
        File.ReadAllLines(x)
    let outp =
        paths
        |> Array.map(fun path -> OpenDocExecutor.from(path))
        |> Array.filter(fun exer -> exer.Type = swDocumentTypes_e.swDocASSEMBLY || exer.Type = swDocumentTypes_e.swDocPART)
        |> Array.map(fun exer -> 
            $"{Path.GetFileName(exer.FileName)},{stringify(tryRead exer)}"
            )
        |> String.concat "\n"
    let path = Path.Combine(Dir.CommandData,"component types.txt")
    File.WriteAllText(path,outp,Encoding.UTF8)
    swApp.SendMsgToUser path
