module SystemOptionsSetting

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File
open FSharp.SolidWorks
open SolidWorks.Interop.SWRoutingLib

let main(swApp: ISldWorks) =
    let sysPref = SysUserPreference(swApp)

    // Colors 
    sysPref.swSystemColorsBackground <- int swInterfaceBrightnessTheme_e.swInterfaceBrightnessTheme_Dark
    sysPref.swColorsUseSpecifiedEditColors <- true

    // Display
    sysPref.swEdgesInContextEditTransparencyType <- int swInContextEditTransparencyType_e.swInContextEditTransparencyOpaque

    // Assemblies
    sysPref.swLargeAsmModeHideAllItems <- false

    // External References
    sysPref.swExtRefOpenReadOnly <- true
    sysPref.swExtRefNoPromptOrSave <- true

    sysPref.swLoadExternalReferences <- int swLoadExternalReferences_e.swLoadExternalReferences_All
    sysPref.swExternalReferencesUpdateOutOfDateLinkedDesignTable <- int swExternalReferencesUpdateOutOfDateLinkedDesignTable_e.swUpdateLinkedDesignTable_ExcelFile
    
    sysPref.swUseFolderSearchRules <- true    
    sysPref.swExtRefIncludeSubFolders <- true    

    sysPref.swAllowCreationOfReferencesExternalToModel <- false

    // Default Templates
    sysPref.swAlwaysUseDefaultTemplates <- true

    let rtUp = RoutingUserPreference(swApp.GetRoutingSettings())
    rtUp.swAlwaysUseDefaultDocumentTemplate <- true
    rtUp.swCreateRoutePartForSegmentsHavingBendRadiusLessThanMinimum <- false
    rtUp.swIncludeCoveringsInBOM <- false
    rtUp.swSaveRouteAssemblyExternally <- true
    rtUp.swUseTriadToPosAndOrientComp <- false
    rtUp.swUseCenterlineDim <- true
    rtUp.swUseConfigureComponentsToSelectConfigurations <- true
    rtUp.swComponentRotationIncrementDegrees <- 90
