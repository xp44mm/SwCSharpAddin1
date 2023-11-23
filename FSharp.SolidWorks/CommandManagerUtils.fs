module FSharp.SolidWorks.CommandManagerUtils

open System
open System.Runtime.InteropServices
open System.Reflection
open System.Collections
open System.Collections.Generic
open System.Diagnostics

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

let ignorePreviousVersion (cmdGroupId:int) (cmdItemIDs:HashSet<int>) (iCmdMgr:ICommandManager) =
    match iCmdMgr.GetGroupDataFromRegistry(cmdGroupId) with
    | true, userIDs ->
        userIDs 
        |> unbox<seq<int>>
        |> cmdItemIDs.SetEquals
    | _ -> false

///命令组：菜单，工具栏共用
let createCommandGroup2
    (userID : int )
    (title : string )
    (toolTip : string )
    (hint : string )
    (ignorePreviousVersion : bool )
    (cmdMgr : ICommandManager )
    =
    let position = -1 //Specify 0 to add the CommandGroup to the beginning of the CommandMananger, or specify -1 to add it to the end of the CommandManager.
    let mutable err = 1
    try
        cmdMgr.CreateCommandGroup2(userID, title, toolTip, hint, position, ignorePreviousVersion, &err)
    with _ -> failwith $"{enum<swCreateCommandGroupErrors>err}"
