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

//// Retrieve the value of a custom property
//let retrieve (fieldName:string) (cusPropMgr: CustomPropertyManager) =
//    let mutable valOut = ""
//    let mutable resolvedValOut = ""
//    let mutable wasResolved = false
//    let mutable linkToProperty = false
//    let i =
//        cusPropMgr.Get6(
//            FieldName = fieldName,
//            UseCached = false,
//            ValOut = &valOut,
//            ResolvedValOut = &resolvedValOut,
//            WasResolved = &wasResolved,
//            LinkToProperty = &linkToProperty
//        )
//        |> enum<swCustomInfoGetResult_e>

//    if not wasResolved || i <> swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue then
//        //swApp.SendMsgToUser "CusPropMgr.Get6"
//        failwithf "%A" i
//    else
//        valOut,resolvedValOut


//let readProps (config:string) (swModel: ModelDoc2) =


/// 读取活动文件的所有自定义属性
let readCustomProps (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    let cusPropMgr = swModel.Extension.CustomPropertyManager("")

    //// Retrieve the value of a custom property
    //let retrieve (fieldName:string) =
    //    let mutable valOut = ""
    //    let mutable resolvedValOut = ""
    //    let mutable wasResolved = false
    //    let mutable linkToProperty = false
    //    let i =
    //        cusPropMgr.Get6(
    //            FieldName = fieldName,
    //            UseCached = false,
    //            ValOut = &valOut,
    //            ResolvedValOut = &resolvedValOut,
    //            WasResolved = &wasResolved,
    //            LinkToProperty = &linkToProperty
    //        )
    //        |> enum<swCustomInfoGetResult_e>
    //    if not wasResolved || i <> swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue then
    //        swApp.SendMsgToUser "CusPropMgr.Get6"
    //        failwith "CusPropMgr.Get6"
    //    else
    //        valOut,resolvedValOut

    let cells =
        cusPropMgr.GetNames()
        :?> obj[]
        |> Array.map (fun x -> x :?> string)
        |> Array.map(fun name ->
            let value =
                cusPropMgr 
                |> CustomPropertyManagerUtils.GetUpdatedProperty name 
                |> snd

            let typ =
                cusPropMgr.GetType2(name) 
                |> enum<swCustomInfoType_e>
                |> CustomInfoType.getCore
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
