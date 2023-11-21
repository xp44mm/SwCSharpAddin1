module FSharp.SolidWorks.AttributeDefUtils

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Runtime.InteropServices
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst

open SolidWorksTools
open SolidWorksTools.File

let addParameter
    (nameIn:string)
    (typ:swParamType_e)
    (defaultValue:float)
    (swAttDef:IAttributeDef)
    =
    let options = 0 // Not used
    swAttDef.AddParameter(
        nameIn,
        int typ,
        defaultValue,
        options)
    |> ignore

let createInstance5 
    (ownerDoc: ModelDoc2) (ownerObj:obj) (nameIn:string)
    (options:int) 
    (configurationOption:swInConfigurationOpts_e)
    (swAttDef:IAttributeDef) =
    swAttDef.CreateInstance5(
        ownerDoc, ownerObj, nameIn, options, int configurationOption)
