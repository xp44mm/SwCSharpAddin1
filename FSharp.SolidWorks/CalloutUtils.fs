module FSharp.SolidWorks.CalloutUtils

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

let setTargetStyle (newval:swCalloutTargetStyle_e) (swCallout:Callout) =
    swCallout.TargetStyle <- int newval
