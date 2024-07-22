module FSharp.SolidWorks.Clipboard


open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.Windows.Forms

open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal

open UnquotedJson
open System.Text

/// read tsv from Clipboard
let tryParseTsv (swApp: ISldWorks) =
    if Clipboard.ContainsText(TextDataFormat.UnicodeText) then
        let arr =
            Clipboard.GetText(TextDataFormat.UnicodeText)
            |> Tsv.parseText
        let text =
            arr
            |> Array.map (fun fs -> 
                fs 
                |> List.ofArray
                |> stringify  )
            |> String.concat "\r\n"
        let result =
            swApp.SendMsgToUser2(
                Message = text + "\r\n查阅剪切板内容后，请问是否继续？",
                Icon = int swMessageBoxIcon_e.swMbQuestion,
                Buttons = int swMessageBoxBtn_e.swMbYesNo)
            |> enum<swMessageBoxResult_e>
        if result = swMessageBoxResult_e.swMbHitYes then  
            Some arr
        else
            None
    else 
        swApp.SendMsgToUser "剪切板中没有内容！"
        None


