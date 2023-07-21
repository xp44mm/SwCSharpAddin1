module CommandManager

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Runtime.InteropServices

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

let mainCmdGroupID = 5
let mainItemID1 = 0
let mainItemID2 = 1
let mainItemID3 = 2
let flyoutGroupID = 91

let Title = "C# Addin"
let ToolTip = "C# Addin"

let RemoveCommandMgr 
    (iBmp:BitmapHandler)
    (iCmdMgr:ICommandManager)
    =
    iBmp.Dispose()

    iCmdMgr.RemoveCommandGroup(mainCmdGroupID) 
    |> ignore

    iCmdMgr.RemoveFlyoutGroup(flyoutGroupID) 
    |> ignore

let equalsIDs (registryIDs:int[]) =
    //CompareIDs (registryIDs:?>int[]) knownIDs
    let knownIDs = Set.ofList [ mainItemID1; mainItemID2 ]
    registryIDs
    |> Set.ofArray
    |> (=) knownIDs

// 用现有版本覆盖前面不同的版本
let isIgnorePreviousVersion (iCmdMgr:ICommandManager) =
    let mutable registryIDs = null
    //get the ID information stored in the registry
    if iCmdMgr.GetGroupDataFromRegistry(mainCmdGroupID, &registryIDs) then
        //if the IDs don't match, reset the commandGroup
        registryIDs:?>int[]
        |> equalsIDs
        |> not
    else false

let RemoveCommandTabIfExist
    (typ:int)
    (title:string)
    (iCmdMgr:ICommandManager)
    =
    let cmdTab = iCmdMgr.GetCommandTab(typ, title)
    //if tab exists, but we have ignored the registry info (or changed command group ID), re-create the tab.  
    //Otherwise the ids won't matchup and the tab will be blank
    if cmdTab <> null then 
        iCmdMgr.RemoveCommandTab(cmdTab)
        |> ignore

// 首先排除有前版本，判定相同
let initCommandTab 
    (docType:int)
    (title:string)
    (iCmdMgr:ICommandManager)
    =
    let cmdTab = iCmdMgr.GetCommandTab(docType, title)
    // !getDataResult | 
    //if tab exists, but we have ignored the registry info (or changed command group ID), 
    // re-create the tab.  Otherwise the ids won't matchup and the tab will be blank
    if cmdTab <> null then 
        iCmdMgr.RemoveCommandTab(cmdTab)
        |> ignore
    iCmdMgr.AddCommandTab(docType, title)

let getUserIDs (iCmdMgr:ICommandManager) =
    let mutable registryIDs = null
    //get the ID information stored in the registry
    if iCmdMgr.GetGroupDataFromRegistry(mainCmdGroupID, &registryIDs) then
        //if the IDs don't match, reset the commandGroup
        registryIDs :?> int[]
    else null

let CreateCommandGroup mainCmdGroupID title toolTip (iCmdMgr:ICommandManager) =
    let mutable cmdGroupErr = 0
    iCmdMgr.CreateCommandGroup2(mainCmdGroupID, title, toolTip, "", -1, false, & cmdGroupErr)

let (|NoPrev|SamePrev|DiffPrev|) iCmdMgr =
    match getUserIDs iCmdMgr with
    | null -> NoPrev
    | ids ->
        if equalsIDs ids then
            SamePrev
        else
            DiffPrev

let AddCommandMgr
    (thisAssembly: System.Reflection.Assembly)
    (iBmp: BitmapHandler)
    (iCmdMgr:ICommandManager)
    =
    let ignorePrevious =
        match getUserIDs iCmdMgr with
        | null -> false
        | ids ->
            ids
            |> equalsIDs
            |> not

    let cmdGroup = 
        iCmdMgr
        |> CreateCommandGroup mainCmdGroupID Title ToolTip

    cmdGroup.LargeIconList <- iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarLarge.bmp", thisAssembly)
    cmdGroup.SmallIconList <- iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarSmall.bmp", thisAssembly)
    cmdGroup.LargeMainIcon <- iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconLarge.bmp", thisAssembly)
    cmdGroup.SmallMainIcon <- iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconSmall.bmp", thisAssembly)

    let menuToolbarOption = int(swCommandItemType_e.swMenuItem ||| swCommandItemType_e.swToolbarItem)
    let cmdIndex0 = cmdGroup.AddCommandItem2(
        "CreateCube", -1, "Create a cube", "Create cube", 0, 
        "CreateCube", "", mainItemID1, menuToolbarOption)

    let cmdIndex1 = cmdGroup.AddCommandItem2(
        "Show PMP", -1, "Display sample property manager", "Show PMP", 2, 
        "ShowPMP", "EnablePMP", mainItemID2, menuToolbarOption)

    cmdGroup.HasToolbar <- true
    cmdGroup.HasMenu <- true
    cmdGroup.Activate()
    |> ignore

    // fly group

    let flyGroup = iCmdMgr.CreateFlyoutGroup(
            flyoutGroupID, "Dynamic Flyout", "Flyout Tooltip", "Flyout Hint",
            cmdGroup.SmallMainIcon, cmdGroup.LargeMainIcon, cmdGroup.SmallIconList, cmdGroup.LargeIconList, 
            "FlyoutCallback", "FlyoutEnable")

    flyGroup.AddCommandItem("FlyoutCommand 1", "test", 0, "FlyoutCommandItem1", "FlyoutEnableCommandItem1")
    |> ignore

    flyGroup.FlyoutType <- int swCommandFlyoutStyle_e.swCommandFlyoutStyle_Simple

    for docType in Constants.docTypes do
        //let cmdTab = iCmdMgr.GetCommandTab(typ, Title)
        //if tab exists, but we have ignored the registry info (or changed command group ID), re-create the tab.  
        //Otherwise the ids won't matchup and the tab will be blank
        if ignorePrevious then 
            iCmdMgr
            |> RemoveCommandTabIfExist docType Title

            //if cmdTab is null, must be first load (possibly after reset), add the commands to the tabs
            let cmdTab = iCmdMgr.AddCommandTab(docType, Title)

            let cmdBox = cmdTab.AddCommandTabBox()

            let bResult = 
                let cmdIDs = 
                    [|
                        cmdGroup.get_CommandID(cmdIndex0)
                        cmdGroup.get_CommandID(cmdIndex1)
                        cmdGroup.ToolbarId
                    |]
                let TextType = 
                    [|
                        int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal
                        int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal
                        int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal ||| 
                        int swCommandTabButtonFlyoutStyle_e.swCommandTabButton_ActionFlyout
                    |]
                cmdBox.AddCommands(cmdIDs, TextType)

            let cmdBox1 = cmdTab.AddCommandTabBox()

            let cmdIDs = [|flyGroup.CmdID|]

            let _ = 
                let TextType = [|
                    int swCommandTabButtonTextDisplay_e.swCommandTabButton_TextBelow ||| 
                    int swCommandTabButtonFlyoutStyle_e.swCommandTabButton_ActionFlyout
                    |]
                cmdBox1.AddCommands(cmdIDs, TextType)

            cmdTab.AddSeparator(cmdBox1, cmdIDs.[0])
            |> ignore


