module FSharp.SolidWorks.SketchManagerUtils

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

let createLine (x1,y1,z1)(x2,y2,z2) (mgr:ISketchManager) =
    mgr.CreateLine(x1, y1, z1, x2, y2, z2)

let createCenterLine  (x1,y1,z1)(x2,y2,z2) (mgr:ISketchManager) =
    mgr.CreateCenterLine (x1, y1, z1, x2, y2, z2)

let createCircleByRadius (x1,y1,z1) (radius:float) (mgr:ISketchManager) =
    mgr.CreateCircleByRadius(x1,y1,z1,radius)

let sketchOffset2
    (offset)
    (bothDirections)
    (chain)
    (capEnds: swSkOffsetCapEndType_e)
    (makeConstruction:swSkOffsetMakeConstructionType_e)
    (addDimensions)
    (mgr:ISketchManager) =

    mgr.SketchOffset2(
        offset,
        bothDirections,
        chain,
        int capEnds,
        int makeConstruction,
        addDimensions)
    |> ignore