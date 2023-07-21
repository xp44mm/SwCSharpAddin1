module FeatureUtils

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

let logfile = "d:/partmat.txt"

let printFeature (swFeat:Feature) =
    let nm = swFeat.Name
    let tp = swFeat.GetTypeName2()
    $"{nm} [{tp}]"

let TraverseSubFeatures (parentFeat:Feature) =
    let swChildFeat = parentFeat.GetFirstSubFeature() :?> Feature
    let rec loop (swChildFeat: Feature) =
        seq {
            if swChildFeat = null then
                ()
            else
                yield swChildFeat
                yield! loop (swChildFeat.GetNextSubFeature() :?> Feature)
        }

    loop swChildFeat
