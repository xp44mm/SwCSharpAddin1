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

let getGroupDataFromRegistry (userGroupId) (iCmdMgr:ICommandManager) =
    match iCmdMgr.GetGroupDataFromRegistry(userGroupId) with
    | true,registryIDs -> registryIDs |> unbox<int[]>
    | _ -> [||]

type CommandGroupParameter = {
    userID : int
    title : string
    toolTip : string
    hint : string
    position : int //Specify 0 to add the CommandGroup to the beginning of the CommandMananger, or specify -1 to add it to the end of the CommandManager.
    ignorePreviousVersion : bool
}

///命令菜单
let createCommandGroup2
    (userID : int )
    (title : string )
    (toolTip : string )
    (hint : string )
    (position : int ) //Specify 0 to add the CommandGroup to the beginning of the CommandMananger, or specify -1 to add it to the end of the CommandManager.
    (ignorePreviousVersion : bool )
    (cmdMgr : ICommandManager )
    =
    let mutable err = 1
    try
        cmdMgr.CreateCommandGroup2(userID, title, toolTip, hint, position, ignorePreviousVersion, &err)
    with _ -> failwith $"{enum<swCreateCommandGroupErrors>err}"

let addCommandTab
    ( documentType:swDocumentTypes_e)
    ( tabName:string)
    ( cmdMgr:ICommandManager)
    =
    cmdMgr.AddCommandTab(
        int documentType, 
        tabName)

///命令选项卡
let createCommandTab
    (typ:int)
    (title:string)
    (cmdIndex0:int)
    (cmdIndex1:int)
    (cmdGroup:ICommandGroup)
    (flyGroup:IFlyoutGroup)
    (iCmdMgr : ICommandManager )
    =
    let cmdTab = iCmdMgr.AddCommandTab(typ, title)
    let cmdBox = cmdTab.AddCommandTabBox()
    let cmdIDs = [|
        cmdGroup.get_CommandID(cmdIndex0); // 命令0
        cmdGroup.get_CommandID(cmdIndex1); // 命令1
        cmdGroup.ToolbarId;
    |]
    let TextType = [|
        int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal;       
        int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal;
        int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal ||| int swCommandTabButtonFlyoutStyle_e.swCommandTabButton_ActionFlyout;
    |]

    let _ = cmdBox.AddCommands(cmdIDs, TextType);

    let cmdBox1 = cmdTab.AddCommandTabBox();
    let cmdIDs = [|
        flyGroup.CmdID;
    |]
    let TextType = [|
        int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextBelow ||| int swCommandTabButtonFlyoutStyle_e.swCommandTabButton_ActionFlyout
    |]

    let _ = cmdBox1.AddCommands(cmdIDs, TextType)

    let _ = cmdTab.AddSeparator(cmdBox1, cmdIDs.[0])
    cmdTab
