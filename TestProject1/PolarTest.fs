namespace FSharp.SolidWorks

open Xunit
open Xunit.Abstractions
open FSharp.xUnit

open System
open System.IO
open System.Text

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open UnquotedJson
open type Math
type PolarTest (output: ITestOutputHelper) =
    let ls = [
        [0.0   ; 1.0      ; 0.0]
        [30.0  ; sqrt 3.0 ; -1.0 ]
        [45.0  ; 1.0      ; -1.0]
        [60.0  ; 1.0      ; -sqrt 3.0 ]
        [90.0  ; 0.0      ; -1.0]
        [120.0 ; -1.0     ; -sqrt 3.0 ]
        [135.0 ; -1.0     ; -1.0]
        [150.0 ; -sqrt 3.0; -1.0 ]
        [180.0 ; -1.0     ; 0.0]
        [-150.0; -sqrt 3.0; 1.0 ]
        [-135.0; -1.0     ; 1.0]
        [-120.0; -1.0     ; sqrt 3.0 ]
        [-90.0 ; 0.0      ; 1.0]
        [-60.0 ; 1.0      ; sqrt 3.0 ]
        [-45.0 ; 1.0      ; 1.0]
        [-30.0 ; sqrt 3.0 ; 1.0 ]

    ]

    [<Theory>]
    [<Natural(16)>]
    member _.``polar angle test``(i:int) =
        let row = ls.[i]
        let e,x,z = row.[0],row.[1],row.[2]
        let result = Polar.angle x z
        output.WriteLine($"{x},{z} = {result}")
        Should.equal e result

