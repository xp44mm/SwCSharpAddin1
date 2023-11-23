module DocumentAttributes

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms.Literal
open FSharp.SolidWorks


let main
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =

    let swAttDef = 
        swApp
        |> SldWorksUtils.defineAttribute "pubMyDocAttributeDef"

    swAttDef
    |> AttributeDefUtils.addParameter "MyFirstParameter" swParamType_e.swParamTypeDouble 10.0

    swAttDef
    |> AttributeDefUtils.addParameter "MySecondParameter" swParamType_e.swParamTypeDouble 20.0

    swAttDef.Register()
    |> ignore

    let swAtt = 
        swAttDef
        |> AttributeDefUtils.createInstance5 
            swModel null "MyDocAttribute" 0 swInConfigurationOpts_e.swAllConfiguration

    let swParam1 = 
        swAtt
        |> AttributeUtils.getParameter "MyFirstParameter"

    let swParam2 = 
        swAtt
        |> AttributeUtils.getParameter "MySecondParameter"

    let text = 
        [
            "There is one attribute on this file, "
            "with two parameters."
            $"Parameter 1 = {swParam1.GetDoubleValue()}" //返回值类型不可以作为泛型参数输入。
            $"Parameter 2 = {swParam2.GetDoubleValue()}"
        ] |> String.concat "\n"

    swApp.SendMsgToUser text
