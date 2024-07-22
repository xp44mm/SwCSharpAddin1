namespace FSharp.SolidWorks

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File
open FSharp.Idioms.Literal
open FSharp.Idioms.OrdinalIgnoreCase

type DocActivator = 
    {
        Name               : string
        UseUserPreferences : bool
        Option             : swRebuildOnActivation_e
    
    }
    static member just(name,useUserPreferences,option) =
        {
            Name = name
            UseUserPreferences= useUserPreferences
            Option = option
        }

    member this.ActivateDoc3 (swApp: ISldWorks) =
        let mutable errors = 0
        let obj = 
            swApp.ActivateDoc3(
                Name               = this.Name, 
                UseUserPreferences = this.UseUserPreferences,
                Option             = int this.Option, 
                Errors             = &errors
                )
        if errors = 0 then
            obj
        else
            failwith $"{enum<swActivateDocError_e> errors}"
