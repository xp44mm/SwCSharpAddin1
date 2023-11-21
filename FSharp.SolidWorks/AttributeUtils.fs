module FSharp.SolidWorks.AttributeUtils

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

let getParameter (nameIn:string) (swAtt:IAttribute) = 
    swAtt.GetParameter nameIn 
    |> unbox<Parameter>
