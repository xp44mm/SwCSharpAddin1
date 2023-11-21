module FSharp.SolidWorks.ConfigurationUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open System
open System.Diagnostics
open System.IO

let getRootComponent (swConf:IConfiguration)= 
    swConf.GetRootComponent()
    |> unbox<Component2>
