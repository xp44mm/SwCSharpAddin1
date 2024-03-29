﻿namespace FSharp.SolidWorks
open FSharp.Idioms

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

type AddComponentConfigOptions =
    | CurrentSelectedConfig
    | NewConfigWithAllReferenceModels of newConfigName: string
    | NewConfigWithAsmStructure of newConfigName: string
    //| UseConfigForPartReferences of existingConfigName: string

// executor
type AddComponent5Params =
    {
        CompName:string
        //todo:ConfigOption+MaybeUseConfigForPartReferences?
        ConfigOption: AddComponentConfigOptions
        MaybeUseConfigForPartReferences: string option // ExistingConfigName
        CompCenter: float*float*float
    }

    static member ofArgs(
        compName, 
        configOption, 
        newConfigName, 
        useConfigForPartReferences, 
        existingConfigName, 
        x, 
        y, 
        z) =
        {
            CompName = compName
            ConfigOption =
                match enum<swAddComponentConfigOptions_e> configOption with
                | swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig ->
                    CurrentSelectedConfig
                | swAddComponentConfigOptions_e.swAddComponentConfigOptions_NewConfigWithAllReferenceModels ->
                    NewConfigWithAllReferenceModels newConfigName
                | swAddComponentConfigOptions_e.swAddComponentConfigOptions_NewConfigWithAsmStructure ->
                    NewConfigWithAsmStructure newConfigName
                | _ -> failwith "AddComponent5Params.ofArgs"

            MaybeUseConfigForPartReferences =
                if useConfigForPartReferences then
                    Some existingConfigName
                else None
            CompCenter = x,y,z
        }
        
    member this.toArgs() =
        let CompName = this.CompName
        let ConfigOption = 
            match this.ConfigOption with
            | CurrentSelectedConfig -> 
                swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig
            | NewConfigWithAllReferenceModels newConfigName -> 
                swAddComponentConfigOptions_e.swAddComponentConfigOptions_NewConfigWithAllReferenceModels
            | NewConfigWithAsmStructure newConfigName ->
                swAddComponentConfigOptions_e.swAddComponentConfigOptions_NewConfigWithAsmStructure

        let NewConfigName = 
            match this.ConfigOption with
            | CurrentSelectedConfig -> Literal.defaultof<_>
            | NewConfigWithAllReferenceModels newConfigName 
            | NewConfigWithAsmStructure newConfigName -> newConfigName

        let UseConfigForPartReferences,ExistingConfigName = 
            match this.MaybeUseConfigForPartReferences with
            | Some existingConfigName -> true,existingConfigName
            | None -> Literal.defaultof<_>
        let X, Y, Z = this.CompCenter
        CompName, ConfigOption, NewConfigName, UseConfigForPartReferences, ExistingConfigName, X, Y, Z

    member this.AddComponent5(swAssy: IAssemblyDoc) =
        let CompName, ConfigOption, NewConfigName, UseConfigForPartReferences, ExistingConfigName, X, Y, Z =
            this.toArgs()

        swAssy.AddComponent5(
            CompName                   = CompName                  ,
            ConfigOption               = int ConfigOption          ,
            NewConfigName              = NewConfigName             ,
            UseConfigForPartReferences = UseConfigForPartReferences,
            ExistingConfigName         = ExistingConfigName        ,
            X                          = X                         ,
            Y                          = Y                         ,
            Z                          = Z
            )
