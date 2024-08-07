﻿namespace FSharp.SolidWorks

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

///https://help.solidworks.com/2023/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.isldworks~opendoc6.html
type OpenDocExecutor =
    {
        FileName      : string
        Type          : swDocumentTypes_e
        Options       : swOpenDocOptions_e
        Configuration : string
    }
    static member just(fileName, docType, options, configuration) =
        {
            FileName      = fileName
            Type          = docType
            Options       = options
            Configuration = configuration
        }

    static member from(fileName: string, configuration: string, options: swOpenDocOptions_e)=
        //let configuration = defaultArg configuration ""
        //let options = defaultArg options swOpenDocOptions_e.swOpenDocOptions_Silent

        let docType =
            let e = Path.GetExtension fileName
            if e == ".SLDASM" then
                swDocumentTypes_e.swDocASSEMBLY
            elif e == ".SLDPRT" then
                swDocumentTypes_e.swDocPART
            else
                swDocumentTypes_e.swDocNONE
        {
            FileName = fileName
            Type = docType
            Options = options
            Configuration = configuration
        }

    static member from (fileName: string, configName:string) =
        OpenDocExecutor.from(fileName,configName,swOpenDocOptions_e.swOpenDocOptions_Silent)

    member this.openDoc(swApp: ISldWorks) =
        let mutable errors = 0
        let mutable warnings = 0
        let modelDoc = swApp.OpenDoc6(
            FileName      = this.FileName,
            Type          = int this.Type,
            Options       = int this.Options,
            Configuration = this.Configuration,
            Errors        = &errors,
            Warnings      = &warnings 
            )
        if modelDoc <> null && errors = 0 
            //&& warnings = 0 
        then
            modelDoc
        else
            [
                if errors > 0 then
                    enum<swFileLoadError_e> errors
                    |> sprintf "%A"
                //if warnings > 0 then
                //    enum<swFileLoadWarning_e> warnings
                //    |> sprintf "%A"
            ]
            |> String.concat " & "
            |> (+) $"{stringify this}\n"
            |> failwith

    member this.OpenDocAndShowConfiguration (swApp: ISldWorks) =
        let swModel = this.openDoc swApp

        // Shows the named configuration by switching to that configuration and making it the active configuration.
        swModel.ShowConfiguration2 this.Configuration
        |> ignore

        swModel
