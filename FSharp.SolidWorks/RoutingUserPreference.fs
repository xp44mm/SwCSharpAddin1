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
open SolidWorks.Interop.SWRoutingLib

/// 数据类型(bool/int/float/string)
type RoutingUserPreference(rtSettings: IRoutingSettings) =
    member _.swAutomaticallyCreateSketchFillets
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyCreateSketchFillets)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyCreateSketchFillets,v)

    member _.swSaveRouteAssemblyExternally
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swSaveRouteAssemblyExternally)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swSaveRouteAssemblyExternally,v)

    member _.swSaveRoutePartsExternally
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swSaveRoutePartsExternally)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swSaveRoutePartsExternally,v)

    member _.swUseAutomaticNamingForRouteParts
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseAutomaticNamingForRouteParts)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseAutomaticNamingForRouteParts,v)

    member _.swCreateCustomFittings
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swCreateCustomFittings)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swCreateCustomFittings,v)

    member _.swCreatePipesOnOpenLineSegments
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swCreatePipesOnOpenLineSegments)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swCreatePipesOnOpenLineSegments,v)

    member _.swAutomaticallyRouteOnDropOfFlangeConnectors
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyRouteOnDropOfFlangeConnectors)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyRouteOnDropOfFlangeConnectors,v)

    member _.swAutomaticallyRouteOnDropOfClips
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyRouteOnDropOfClips)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyRouteOnDropOfClips,v)

    member _.swAutomaticallyAddDimensionToRouteStubs
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyAddDimensionToRouteStubs)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyAddDimensionToRouteStubs,v)

    member _.swEnableRouteErrorChecking
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swEnableRouteErrorChecking)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swEnableRouteErrorChecking,v)

    member _.swDisplayErrorBalloons
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swDisplayErrorBalloons)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swDisplayErrorBalloons,v)

    member _.swIncludeCoveringsInBOM
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swIncludeCoveringsInBOM)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swIncludeCoveringsInBOM,v)

    member _.swAlwaysUseDefaultDocumentTemplate
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAlwaysUseDefaultDocumentTemplate)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAlwaysUseDefaultDocumentTemplate,v)

    member _.swUseTriadToPosAndOrientComp
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseTriadToPosAndOrientComp)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseTriadToPosAndOrientComp,v)

    member _.swUseAutoNamingForRouteParts
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseAutoNamingForRouteParts)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseAutoNamingForRouteParts,v)

    member _.swUseCenterlineDim
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseCenterlineDim)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseCenterlineDim,v)

    member _.swAutomaticallyZoomToFitRouteComponents
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyZoomToFitRouteComponents)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swAutomaticallyZoomToFitRouteComponents,v)

    member _.swUseConfigureComponentsToSelectConfigurations
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseConfigureComponentsToSelectConfigurations)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swUseConfigureComponentsToSelectConfigurations,v)

    member _.swCreateRoutePartForSegmentsHavingBendRadiusLessThanMinimum
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swCreateRoutePartForSegmentsHavingBendRadiusLessThanMinimum)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swCreateRoutePartForSegmentsHavingBendRadiusLessThanMinimum,v)

    member _.swHideConfigurationDialogForSWElectricalComponents
        with get () =
            rtSettings.GetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swHideConfigurationDialogForSWElectricalComponents)
        and set v =
            rtSettings.SetRoutingUserPreferenceToggle(int swUserPreferenceRoutingToggle_e.swHideConfigurationDialogForSWElectricalComponents,v)

    member _.swComponentRotationIncrementDegrees
        with get () =
            rtSettings.GetRoutingUserPreferenceIntegerValue(int swUserPreferenceRoutingInteger_e.swComponentRotationIncrementDegrees)
        and set v =
            rtSettings.SetRoutingUserPreferenceIntegerValue(int swUserPreferenceRoutingInteger_e.swComponentRotationIncrementDegrees,v)
            |> ignore

    member _.swEnableMinimumBendRadiusChecks
        with get () =
            rtSettings.GetRoutingUserPreferenceIntegerValue(int swUserPreferenceRoutingInteger_e.swEnableMinimumBendRadiusChecks)
        and set v =
            rtSettings.SetRoutingUserPreferenceIntegerValue(int swUserPreferenceRoutingInteger_e.swEnableMinimumBendRadiusChecks,v)
            |> ignore

    member _.swSlackPercentage
        with get () =
            rtSettings.GetRoutingUserPreferenceDoubleValue(int swUserPreferenceRoutingDouble_e.swSlackPercentage)
        and set v =
            rtSettings.SetRoutingUserPreferenceDoubleValue(int swUserPreferenceRoutingDouble_e.swSlackPercentage,v)
            |> ignore

    member _.swTextSizeForConnectionAndRoutePoints
        with get () =
            rtSettings.GetRoutingUserPreferenceDoubleValue(int swUserPreferenceRoutingDouble_e.swTextSizeForConnectionAndRoutePoints)
        and set v =
            rtSettings.SetRoutingUserPreferenceDoubleValue(int swUserPreferenceRoutingDouble_e.swTextSizeForConnectionAndRoutePoints,v)
            |> ignore
