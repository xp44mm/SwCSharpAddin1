module PartDocUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

let GetMaterialPropertyName configName (swPart:PartDoc) =
    let mutable db = ""
    let nm = swPart.GetMaterialPropertyName2(configName, &db)
    nm,db