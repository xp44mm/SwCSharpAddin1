module FSharp.SolidWorks.ParameterUtils

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Runtime.InteropServices
open System.IO

open SolidWorks.Interop.sldworks // as sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst

open SolidWorksTools
open SolidWorksTools.File
open FSharp.SolidWorks

let setDoubleValue2 
    (value)
    (configurationOption:swInConfigurationOpts_e)
    (configurationName)
    (swAttParam:Parameter) = 
    swAttParam.SetDoubleValue2(
        value,
        int configurationOption,
        configurationName)
    |> ignore