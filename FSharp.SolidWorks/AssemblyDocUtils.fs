module FSharp.SolidWorks.AssemblyDocUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

let addComponent5 
    compName 
    (configOpt:swAddComponentConfigOptions_e)
    (newConfigName:string)
    (useConfigForPartReferences:bool)
    (existingConfigName:string)
    (x:float,y:float,z:float)
    (swAssy: IAssemblyDoc) =
    swAssy.AddComponent5(compName,int configOpt, newConfigName, useConfigForPartReferences, existingConfigName, x, y, z)


let editPart2 
    (silent : bool)
    (allowReadOnly : bool)
    (swAssy: IAssemblyDoc) =
    //(information : int)
    //(value : int)
    let mutable information = 0
    try
        swAssy.EditPart2(silent, allowReadOnly, &information)
        |> enum<swEditPartCommandStatus_e>
    with _ -> failwith $"{enum<swEditPartCommandStatus_e>information}"

let addMate5 
    (mateTypeFromEnum      : swMateType_e )
    (alignFromEnum         : swMateAlign_e )
    (flip                  : bool )
    (distance              : float  )
    (distanceAbsUpperLimit : float  )
    (distanceAbsLowerLimit : float  )
    (gearRatioNumerator    : float  )
    (gearRatioDenominator  : float  )
    (angle                 : float  )
    (angleAbsUpperLimit    : float  )
    (angleAbsLowerLimit    : float  )
    (forPositioningOnly    : bool )
    (lockRotation          : bool )
    (widthMateOption       : swMateWidthOptions_e )
    (instance              : IAssemblyDoc   )
    : Mate2 =
    let mutable errorStatus = int swAddMateError_e.swAddMateError_NoError
    try
        instance.AddMate5(
            int mateTypeFromEnum, 
            int alignFromEnum, 
            flip, 
            distance, 
            distanceAbsUpperLimit, 
            distanceAbsLowerLimit, 
            gearRatioNumerator, 
            gearRatioDenominator, 
            angle, 
            angleAbsUpperLimit, 
            angleAbsLowerLimit, 
            forPositioningOnly, 
            lockRotation, 
            int widthMateOption, 
            &errorStatus)
    with _ -> failwith $"{enum<swAddMateError_e>errorStatus}"
