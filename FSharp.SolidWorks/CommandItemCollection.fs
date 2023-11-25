namespace FSharp.SolidWorks

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

type CommandItemInfo = {
    hintString      :string
    toolTip         :string
    callbackFunction:string
    enableMethod    :string
    menuTBOption    :swCommandItemType_e
}
///1.回调函数名作为命令名;
///2.位置为-1;
///3.按index顺序值作为命令ID;
///4.按index顺序值作为位图索引;
type CommandItemCollection() =
    let mutable ls:list<CommandItemInfo> = []

    member _.add(
        hintString       : string,
        toolTip          : string,
        callbackFunction : string,
        enableMethod     : string,
        menuTBOption     : swCommandItemType_e
        ) =
        let x = {
            hintString       = hintString
            toolTip          = toolTip
            callbackFunction = callbackFunction
            enableMethod     = enableMethod
            menuTBOption     = menuTBOption
        }
        ls <- x::ls

    member this.getUserIDs() =
        ls
        |> List.mapi(fun i _ -> i)
        |> HashSet

    member this.update(cmdGroup:ICommandGroup) =
        ls
        |> List.rev
        |> List.iteri(fun i x ->
            cmdGroup.AddCommandItem2(
                Name             = x.callbackFunction,
                Position         = -1,
                HintString       = x.hintString,
                ToolTip          = x.toolTip,
                ImageListIndex   = i,
                CallbackFunction = x.callbackFunction,
                EnableMethod     = x.enableMethod,
                UserID           = i,
                MenuTBOption     = int x.menuTBOption)
            |> ignore
        )








