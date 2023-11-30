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

type AddCommandItem2Params = {
    Name : string
    Position : int
    HintString : string
    ToolTip : string
    ImageListIndex : int
    CallbackFunction : string
    EnableMethod : string
    UserID : int
    MenuTBOption : swCommandItemType_e
}

type CommandItemCollection() =
    let mutable ls:list<AddCommandItem2Params> = []

    ///全参数添加
    member _.add(
        name : string                      ,
        position : int                     ,
        hintString : string                ,
        toolTip : string                   ,
        imageListIndex : int               ,
        callbackFunction : string          ,
        enableMethod : string              ,
        userID : int                       ,
        menuTBOption : swCommandItemType_e ) =
        let x = {
            Name             = name             ;
            Position         = position         ;
            HintString       = hintString       ;
            ToolTip          = toolTip          ;
            ImageListIndex   = imageListIndex   ;
            CallbackFunction = callbackFunction ;
            EnableMethod     = enableMethod     ;
            UserID           = userID           ;
            MenuTBOption     = menuTBOption     ;
        }
        ls <- x::ls

    member this.add(
        hintString       : string,
        toolTip          : string,
        callbackFunction : string,
        enableMethod     : string,
        menuTBOption     : swCommandItemType_e ) =

        this.add(
            name             = callbackFunction , //.回调函数名作为命令名;
            position         = -1 , //.位置为-1;
            hintString       = hintString ,
            toolTip          = toolTip ,
            imageListIndex   = -1 ,
            callbackFunction = callbackFunction ,
            enableMethod     = enableMethod ,
            userID           = -1 ,
            menuTBOption     = menuTBOption )
                
    member this.add(
        hintOrTip       : string,
        callbackFunction : string
        ) =
        this.add(
        hintString       = hintOrTip,
        toolTip          = hintOrTip,
        callbackFunction = callbackFunction,
        enableMethod     = "",
        menuTBOption     = swCommandItemType_e.swMenuItem
        )

    member this.getUserIDs() =
        ls
        |> List.mapi(fun i _ -> i)
        |> HashSet

    member this.update(cmdGroup:ICommandGroup) =
        ls
        |> List.rev
        |> List.iteri(fun i x ->
            cmdGroup.AddCommandItem2(
                Name             = x.Name,
                Position         = x.Position,
                HintString       = x.HintString,
                ToolTip          = x.ToolTip,
                ImageListIndex   = i,///.按index顺序值作为命令ID;
                CallbackFunction = x.CallbackFunction,
                EnableMethod     = x.EnableMethod,
                UserID           = i,///.按index顺序值作为位图索引;
                MenuTBOption     = int x.MenuTBOption)
            |> ignore
        )








