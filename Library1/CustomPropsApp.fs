module CustomPropsApp

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Drawing
open System.IO
open System.Reflection
open System.Runtime.InteropServices
open System.Text
open System.Text.RegularExpressions
open System.Windows.Forms

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.SolidWorks

open FSharp.Idioms
open FSharp.Idioms.Literal

/// 读取活动文件的所有自定义属性
let readCustomProps (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let cusPropMgr = swModel.Extension.CustomPropertyManager("")
    let cells =
        cusPropMgr
        |> CustomPropertyManagerUtils.getAllTypesValues
        |> Array.map(fun (name,typ,value) ->
            [| name;typ;value |]
        )
    let path = Path.Combine(Dir.CommandData,"customProps.tsv")
    let outp = Tsv.stringify cells
    File.WriteAllText(path,outp)
    swApp.SendMsgToUser path

/// 向活动文件写自定义属性
let writeCustomProps (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    let cusPropMgr = swModel.Extension.CustomPropertyManager("")
    let addProp name (ftype:swCustomInfoType_e) value =
        cusPropMgr.Add3(
            FieldName = name,
            FieldType = int ftype,
            FieldValue = value,
            OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd
        )
        |> ignore

    let text =
        if Clipboard.ContainsText(TextDataFormat.UnicodeText) then
            Clipboard.GetText(TextDataFormat.UnicodeText)
        else failwith "Clipboard.ContainsText"

    text
    |> Tsv.parseText
    |> Array.map (fun fs ->
        match fs with
        | [|name;typ;value|] ->
            name, CustomInfoType.parseCore typ, value
        | _ -> failwith "schema mismatch"
    )
    |> Array.map(fun (name,ftype,value)->
        addProp name ftype value
    )
