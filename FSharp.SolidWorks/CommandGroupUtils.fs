module FSharp.SolidWorks.CommandGroupUtils

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

type CommandItemParameter = {
    name:string
    position:int
    hintString:string
    toolTip:string
    imageListIndex:int
    callbackFunction:string
    enableMethod:string
    userID:int
    menuTBOption:swCommandItemType_e //bitmask
}

let addCommandItem2
    (name:string)
    (position:int)
    (hintString:string)
    (toolTip:string)
    (imageListIndex:int)
    (callbackFunction:string)
    (enableMethod:string)
    (userID:int)
    (menuTBOption:swCommandItemType_e) //bitmask
    (cmdGroup:ICommandGroup)

    = 

    cmdGroup.AddCommandItem2(
        name,
        position,
        hintString,
        toolTip,
        imageListIndex,
        callbackFunction,
        enableMethod,
        userID,
        int menuTBOption)
