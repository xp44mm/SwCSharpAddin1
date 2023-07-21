module FeatureManager

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

// https://help.solidworks.com/2023/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IFeatureManager~FeatureExtrusion3.html
let FeatureExtrusion
    ( sd : bool)
    ( flip : bool)
    ( dir : bool)

    ( t1 : int)    ( t2 : int)
    ( d1 : float)    ( d2 : float)
    ( dchk1 : bool)    ( dchk2 : bool)
    ( ddir1 : bool)    ( ddir2 : bool)
    ( dang1 : float)    ( dang2 : float)
    ( offsetReverse1 : bool)    ( offsetReverse2 : bool)
    ( translateSurface1 : bool)    ( translateSurface2 : bool)

    ( merge : bool)
    ( useFeatScope : bool)
    ( useAutoSelect : bool)
    ( t0 : int)
    ( startOffset : float)
    ( flipStartOffset : bool)
    ( instance : IFeatureManager)
    : Feature =
        let value =
            instance.FeatureExtrusion3(sd, flip, dir, t1, t2, d1, d2, dchk1, dchk2, ddir1, ddir2, dang1, dang2,
                offsetReverse1,
                offsetReverse2,
                translateSurface1,
                translateSurface2,
                merge,
                useFeatScope,
                useAutoSelect,
                t0,
                startOffset,
                flipStartOffset)
        value