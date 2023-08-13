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

let getSelectedObjectType3 index mark (swSelMgr: SelectionMgr) =
    //https://help.solidworks.com/2023/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.iselectionmgr~getselectedobjecttype3.html
    swSelMgr.GetSelectedObjectType3(index, mark)
    |> enum<swSelectType_e>