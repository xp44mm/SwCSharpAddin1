namespace FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

type ModelSpecific =
    | ModelAssembly of AssemblyDoc
    | ModelPart of PartDoc
    | ModelDrawing of DrawingDoc

    static member from (modelDoc:ModelDoc2) =
        match enum<swDocumentTypes_e>(modelDoc.GetType()) with
        | swDocumentTypes_e.swDocASSEMBLY ->
            modelDoc :?> AssemblyDoc
            |> ModelAssembly

        | swDocumentTypes_e.swDocPART ->
            modelDoc :?> PartDoc
            |> ModelPart

        | swDocumentTypes_e.swDocDRAWING ->
            modelDoc :?> DrawingDoc
            |> ModelDrawing
            
        | x -> failwithf "%A" x
