namespace FSharp.SolidWorks.FeatureExtrusion3

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

// swStartConditions_e
type StartCondition =
    | Offset of StartOffset:float * FlipStartOffset: bool
    | SketchPlane
    | Surface
    | Vertex

    member this.getT0() =
        match this with
        | Offset _    -> swStartConditions_e.swStartOffset
        | SketchPlane -> swStartConditions_e.swStartSketchPlane
        | Surface     -> swStartConditions_e.swStartSurface
        | Vertex      -> swStartConditions_e.swStartVertex

    member this.getOffsetParams() =
        match this with
        | Offset (startOffset, flipStartOffset) ->
            startOffset,flipStartOffset
        | _ -> 0.0, false

// swEndConditions_e
type EndCond =
    | Blind of depth:float
    | MidPlane of depth:float
    | OffsetFromSurface of offset:float*OffsetReverse:bool*TranslateSurface:bool
    | ThroughAll
    | ThroughAllBoth
    | ThroughNext
    | UpToBody
    | UpToNext
    | UpToSelection

    member this.getT () =
        match this with
        | Blind _             -> swEndConditions_e.swEndCondBlind
        | MidPlane _          -> swEndConditions_e.swEndCondMidPlane
        | OffsetFromSurface _ -> swEndConditions_e.swEndCondOffsetFromSurface
        | ThroughAll          -> swEndConditions_e.swEndCondThroughAll
        | ThroughAllBoth      -> swEndConditions_e.swEndCondThroughAllBoth
        | ThroughNext         -> swEndConditions_e.swEndCondThroughNext
        | UpToBody            -> swEndConditions_e.swEndCondUpToBody
        | UpToNext            -> swEndConditions_e.swEndCondUpToNext
        | UpToSelection       -> swEndConditions_e.swEndCondUpToSelection

    member this.getOffsetParams () =
        match this with
        | Blind d | MidPlane d ->
            d,false,false
        | OffsetFromSurface(offset,offsetReverse, translateSurface) -> 
            offset,offsetReverse,translateSurface
        | _ -> 0.0,false,false

type Drafting = {
    Ddir : bool
    Dang : float
}

type DirectionExtrusionParams =
    {
        EndCond: EndCond
        Drafting: option<Drafting>
    }

    member this.toTuple() =
        let t = this.EndCond.getT()
        let d,offsetReverse, translateSurface =
            this.EndCond.getOffsetParams()
        let Dchk = this.Drafting.IsSome
        let Ddir,Dang =
            match this.Drafting with 
            | Some df -> df.Ddir,df.Dang 
            | _ -> false, 0.0
        t,d,offsetReverse,translateSurface,Dchk,Ddir,Dang

// https://help.solidworks.com/2023/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IFeatureManager~FeatureExtrusion3.html
type ExtrusionParams = 
    {
    sd: bool
    flip: bool
    dir: bool
    direction1: DirectionExtrusionParams
    direction2: DirectionExtrusionParams
    merge: bool
    useFeatScope: bool
    useAutoSelect: bool
    startCond: StartCondition
    }
    member w.create(mgr: IFeatureManager) =
        let t1,d1,offsetReverse1,translateSurface1,Dchk1,Ddir1,Dang1 =
            w.direction1.toTuple()

        let t2,d2,offsetReverse2,translateSurface2,Dchk2,Ddir2,Dang2 =
            w.direction2.toTuple()

        let StartOffset,FlipStartOffset =
            w.startCond.getOffsetParams()

        mgr.FeatureExtrusion3 (
            Sd = w.sd ,
            Flip = w.flip ,
            Dir = w.dir ,
            T1 = int t1 ,
            T2 = int t2 ,
            D1 = d1 ,
            D2 = d2 ,
            Dchk1 = Dchk1 ,
            Dchk2 = Dchk2 ,
            Ddir1 = Ddir1 ,
            Ddir2 = Ddir2 ,
            Dang1 = Dang1 ,
            Dang2 = Dang2 ,
            OffsetReverse1 = offsetReverse1 ,
            OffsetReverse2 = offsetReverse2 ,
            TranslateSurface1 = translateSurface1 ,
            TranslateSurface2 = translateSurface2 ,
            Merge = w.merge ,
            UseFeatScope = w.useFeatScope ,
            UseAutoSelect = w.useAutoSelect ,
            T0 = int (w.startCond.getT0()) ,
            StartOffset = StartOffset ,
            FlipStartOffset = FlipStartOffset
        )
