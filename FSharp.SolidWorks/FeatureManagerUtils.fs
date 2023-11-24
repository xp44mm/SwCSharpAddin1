module FSharp.SolidWorks.FeatureManagerUtils

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Runtime.InteropServices
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

type DirectionExtrusion =
    {
        t : swEndConditions_e //改为可区分联合
        d : float
        dchk : bool
        ddir : bool
        dang : float
        offsetReverse : bool
        translateSurface : bool
    }

type DirectionRevolve = {
    dirType       :swEndConditions_e
    dirAngle      :float
    offsetReverse :bool
    offsetDistance:float
    thinThickness :float
}

// https://help.solidworks.com/2023/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IFeatureManager~FeatureExtrusion3.html
let featureExtrusion3
    (sd: bool)
    (flip: bool)
    (dir: bool)
    (direction1: DirectionExtrusion)
    (direction2: DirectionExtrusion)
    (merge: bool)
    (useFeatScope: bool)
    (useAutoSelect: bool)
    (t0: swStartConditions_e)
    (startOffset: float)
    (flipStartOffset: bool)
    (mgr: IFeatureManager)
    : Feature =

    let {
        t=t1
        d=d1
        dchk=dchk1
        ddir=ddir1
        dang=dang1
        offsetReverse=offsetReverse1
        translateSurface=translateSurface1
    } = direction1

    let {
        t=t2
        d=d2
        dchk=dchk2
        ddir=ddir2
        dang=dang2
        offsetReverse=offsetReverse2
        translateSurface=translateSurface2
    } = direction2

    mgr.FeatureExtrusion3(
        sd, flip, dir,
        int t1, int t2,
        d1, d2,
        dchk1, dchk2,
        ddir1, ddir2,
        dang1, dang2,
        offsetReverse1, offsetReverse2,
        translateSurface1, translateSurface2,
        merge,
        useFeatScope,
        useAutoSelect,
        int t0,
        startOffset,
        flipStartOffset)

//type
let featureRevolve2
    (singleDir:bool)
    (isSolid:bool)
    (isThin:bool)
    (isCut:bool)
    (reverseDir:bool)
    (bothDirectionUpToSameEntity:bool)
    (thinType:swThinWallType_e)
    directionRevolve1
    directionRevolve2
    (merge:bool)
    (useFeatScope:bool)
    (useAutoSelect:bool)
    (mgr: IFeatureManager)
    : Feature =

    let {
        dirType        = dir1Type
        dirAngle       = dir1Angle
        offsetReverse  = offsetReverse1
        offsetDistance = offsetDistance1
        thinThickness  = thinThickness1
    } = directionRevolve1

    let {
        dirType        = dir2Type
        dirAngle       = dir2Angle
        offsetReverse  = offsetReverse2
        offsetDistance = offsetDistance2
        thinThickness  = thinThickness2
    } = directionRevolve2

    mgr.FeatureRevolve2(
        singleDir ,
        isSolid   ,
        isThin    ,
        isCut     ,
        reverseDir,
        bothDirectionUpToSameEntity,
        int dir1Type, int dir2Type,
        dir1Angle,  dir2Angle,
        offsetReverse1,        offsetReverse2,
        offsetDistance1,       offsetDistance2,
        int thinType,
        thinThickness1 ,        thinThickness2 ,
        merge,
        useFeatScope,
        useAutoSelect
        )

let featureExtrusion (c:{|
    sd: bool                      
    flip: bool                    
    dir: bool                     
    direction1: DirectionExtrusion
    direction2: DirectionExtrusion
    merge: bool                   
    useFeatScope: bool            
    useAutoSelect: bool           
    t0: swStartConditions_e       
    startOffset: float            
    flipStartOffset: bool
    |})
    (mgr: IFeatureManager)
    =
    let {
        t=t1
        d=d1
        dchk=dchk1
        ddir=ddir1
        dang=dang1
        offsetReverse=offsetReverse1
        translateSurface=translateSurface1
    } = c.direction1
    let {
        t=t2
        d=d2
        dchk=dchk2
        ddir=ddir2
        dang=dang2
        offsetReverse=offsetReverse2
        translateSurface=translateSurface2
    } = c.direction2
    mgr.FeatureExtrusion3(
        c.sd, c.flip, c.dir,
        int t1, int t2,
        d1, d2,
        dchk1, dchk2,
        ddir1, ddir2,
        dang1, dang2,
        offsetReverse1, offsetReverse2,
        translateSurface1, translateSurface2,
        c.merge,
        c.useFeatScope,
        c.useAutoSelect,
        int c.t0,
        c.startOffset,
        c.flipStartOffset)
    |> ignore
