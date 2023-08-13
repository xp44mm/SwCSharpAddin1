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

let getFaceSeq (body:Body2) =
    let rec loop (face:obj) =
        seq {
            match face with
            | null -> ()
            | :? Face2 as face ->
                yield face
                yield! loop (face.GetNextFace())
            | _ -> failwith $"{face.GetType()}"
        }
    body.GetFirstFace() |> loop

let main

    (swApp: SldWorks    )
    (swModel: ModelDoc2 )
    (swPart: PartDoc    )
    //(retval: Variant             )
    (i: int                      )
    (swFace: Face2      )
    (matProps: float[]          )
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
        swPart.GetBodies2(int swBodyType_e.swSolidBody, true)
        |> unbox<obj[]>
        |> Array.map(unbox<Body2>)

    bodies
    |> Seq.iter(fun bd ->
        swFace.MaterialPropertyValues <- matProps
        (swModel.ActiveView:?>ModelView).GraphicsRedraw null
    )

