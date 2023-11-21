module FSharp.SolidWorks.SelectionMgrUtils

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

//open FSharp.Literals.Literal
type Mark =
    | All
    | WithoutMark
    | OtherMark of int

    member this.value =
        match this with
        | All -> -1
        | WithoutMark -> 0
        | OtherMark m -> m


let getSelectedObjectCount2 (mark:Mark) (swSelMgr: SelectionMgr) =
    mark.value
    |> swSelMgr.GetSelectedObjectCount2

let getSelectedObjectType3 index (mark:Mark) (swSelMgr: SelectionMgr) =
    //https://help.solidworks.com/2023/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.iselectionmgr~getselectedobjecttype3.html
    swSelMgr.GetSelectedObjectType3(index, mark.value)
    |> enum<swSelectType_e>

let getSelectedObject6
    (index: int  )
    (mark: Mark   )
    (swSelMgr: ISelectionMgr)
    = 
    swSelMgr.GetSelectedObject6(index, mark.value)

