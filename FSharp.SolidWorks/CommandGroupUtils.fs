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

let addCommandItem2
    (name            :string)
    (hintString      :string)
    (toolTip         :string)
    (imageListIndex  :int)
    (callbackFunction:string)
    (enableMethod    :string)
    (userID          :int)
    (menuTBOption    :swCommandItemType_e) //bitmask
    (cmdGroup        :ICommandGroup)

    = 
    let position = -1 // Specify 0 to add this item to the beginning of the CommandGroup, or specify -1 to add it to the end of the CommandGroup. This argument specifies the position of the item in relation to its immediate parent item.    
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
