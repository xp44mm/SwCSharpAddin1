namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

type ComponentSpecific =
    | SpecificAssembly of AssemblyDoc*ComponentNode[]
    | SpecificPart of PartDoc

and ComponentNode =
    {
        Component2: Component2
        ModelDoc2: ModelDoc2
        specific: ComponentSpecific
    }

    static member from (swComp:Component2) =
        let modelDoc = swComp.GetModelDoc2() :?> ModelDoc2
        let specific = 
            match enum<swDocumentTypes_e>(modelDoc.GetType()) with
            | swDocumentTypes_e.swDocASSEMBLY ->
                let assem = modelDoc :?> AssemblyDoc
                let children =
                    swComp.GetChildren()
                    :?> obj[]
                    |> Array.map(fun o -> o :?> Component2)
                    |> Array.map ComponentNode.from

                SpecificAssembly(assem,children)
            | swDocumentTypes_e.swDocPART ->
                let part = modelDoc :?> PartDoc
                SpecificPart part
            | x -> failwithf "%A" x
        {
            Component2 = swComp
            ModelDoc2 = modelDoc
            specific = specific
        }

type ComponentModelNode =
    {
        //Component2: Component2
        ModelDoc2: ModelDoc2
        specificModel: ComponentModelSpecific
    }

type ComponentModelSpecific =
    | SpecificModelAssembly of AssemblyDoc
    | SpecificModelPart of PartDoc

    static member from (modelDoc:ModelDoc2) =
        //let modelDoc = swComp.GetModelDoc2() :?> ModelDoc2
        let specific = 
            match enum<swDocumentTypes_e>(modelDoc.GetType()) with
            | swDocumentTypes_e.swDocASSEMBLY ->
                modelDoc :?> AssemblyDoc
                |> SpecificModelAssembly

            | swDocumentTypes_e.swDocPART ->
                modelDoc :?> PartDoc
                |> SpecificModelPart

            | x -> failwithf "%A" x
        modelDoc,specific
