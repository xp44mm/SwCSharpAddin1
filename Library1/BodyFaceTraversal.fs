module BodyFaceTraversal

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
open FSharp.SolidWorks


let main

    (swFace: Face2      )
    (swModel: ModelDoc2 )
    (swApp: SldWorks    )
    =

    //Notice the Explicit Type Casting
    let swPart = swModel :?> PartDoc

    let matProps = [|
        1.0
        0.0
        0.0
        1.0
        1.0
        0.3
        0.3
        0.0
        0.0
    |]

    let bodies = 
        swPart
        |> PartDocUtils.getBodies2 swBodyType_e.swSolidBody true

    bodies
    |> Seq.iter(fun bd ->
        swFace.MaterialPropertyValues <- matProps
        (swModel.ActiveView:?>ModelView).GraphicsRedraw null
    )

