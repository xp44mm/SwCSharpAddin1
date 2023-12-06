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

let getIDsFromRegistry (cmdGroupId:int) (iCmdMgr:ICommandManager) =
    match iCmdMgr.GetGroupDataFromRegistry(cmdGroupId) with
    | true, userIDs ->        
        userIDs :?> int[]
    | _ -> [||]

///命令组：菜单，工具栏共用
let createCommandGroup2
    (userID                : int            )
    (title                 : string         )
    (toolTip               : string         )
    (hint                  : string         )
    (ignorePreviousVersion : bool           )
    (cmdMgr                : ICommandManager)
    =
    let mutable err = 1
    try
        cmdMgr.CreateCommandGroup2(
            UserID                = userID, 
            Title                 = title, 
            ToolTip               = toolTip, 
            Hint                  = hint, 
            Position              = -1, 
            IgnorePreviousVersion = ignorePreviousVersion, 
            Errors                = &err)
    with _ -> 
    failwith $"{enum<swCreateCommandGroupErrors> err}"







