module FSharp.SolidWorks.EntityUtils

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

//get the component to the entity objects owning component
let getComponent2 (ent:Entity) = 
    ent.GetComponent() 
    |> unbox<Component2>
