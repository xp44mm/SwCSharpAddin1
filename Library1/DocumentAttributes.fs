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

open FSharp.Literals.Literal


let main
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =

    let swAttDef = 
        swApp.DefineAttribute ("pubMyDocAttributeDef")
        |> unbox<AttributeDef>

    swAttDef.AddParameter("MyFirstParameter", int swParamType_e.swParamTypeDouble, 10.0, 0)
    |> ignore

    swAttDef.AddParameter("MySecondParameter", int swParamType_e.swParamTypeDouble, 20.0, 0)
    |> ignore

    swAttDef.Register() |> ignore
    let swAtt = swAttDef.CreateInstance5(swModel, null, "MyDocAttribute", 0, int swInConfigurationOpts_e.swAllConfiguration)
    let swParam1 = swAtt.GetParameter("MyFirstParameter") |> unbox<Parameter>
    let swParam2 = swAtt.GetParameter("MySecondParameter")|> unbox<Parameter>
    let text = 
        [
            "There is one attribute on this file, "
            "with two parameters."
            $"Parameter 1 = {swParam1.GetDoubleValue()}"
            $"Parameter 2 = {swParam2.GetDoubleValue()}"
        ] |> String.concat "\n"

    swApp.SendMsgToUser text
