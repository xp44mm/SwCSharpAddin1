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

/// 枚举值(名称如swInputDimValOnCreate)，数据类型(bool/int/float/string)，域(sys(app)/doc)，自动生成代码
type SysUserPreference(swApp: ISldWorks) =

    member this.swInputDimValOnCreate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate, v)

    member this.swDrawingDetailViewScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale, v)
            |> ignore

    member this.swViewAnimationSpeed
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewAnimationSpeed)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewAnimationSpeed, v)
            |> ignore

    member this.swSystemColorsViewportBackground
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground, v)
            |> ignore

    member this.swBackupDirectory
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBackupDirectory)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBackupDirectory, v)
            |> ignore

    member this.swDefaultTemplatePart
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplatePart)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplatePart, v)
            |> ignore

    member this.swDefaultTemplateAssembly
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplateAssembly)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplateAssembly, v)
            |> ignore


    member this.swEdgesHiddenEdgeDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay, v)
            |> ignore

    member this.swViewRotationMouseSpeed
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed, v)
            |> ignore

type DocUserPreference (swModel:IModelDoc2) =

    member t.swDetailingDualDimensions
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swDetailingDualDimensions,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swDetailingDualDimensions,
                    int e,
                    value)
            |> ignore

    member t.swWeldmentEnableAutomaticCutList
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList,
                    int e,
                    value)
            |> ignore

    member t.swWeldmentEnableAutomaticUpdate
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate,
                    int e,
                    value)
            |> ignore

    member t.swWeldmentRenameCutlistDescriptionPropertyValue
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue,
                    int e,
                    value)
            |> ignore

    member t.swWeldmentCollectIdenticalBodies
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies,
                    int e,
                    value)
            |> ignore

    member t.swDisableDerivedConfigurations
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swDisableDerivedConfigurations,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceToggle(
                    int swUserPreferenceToggle_e.swDisableDerivedConfigurations,
                    int e,
                    value)
            |> ignore

    member t.swUnitsLinear
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceInteger(
                    int swUserPreferenceIntegerValue_e.swUnitsLinear,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceInteger(
                    int swUserPreferenceIntegerValue_e.swUnitsLinear,
                    int e,
                    value)
            |> ignore


    member t.swMaterialPropertyDensity
        with get (e:swUserPreferenceOption_e) = 
                swModel.Extension.GetUserPreferenceDouble(
                    int swUserPreferenceDoubleValue_e.swMaterialPropertyDensity,
                    int e)

        and set (e:swUserPreferenceOption_e) value = 
            swModel.Extension.SetUserPreferenceDouble(
                    int swUserPreferenceDoubleValue_e.swMaterialPropertyDensity,
                    int e,
                    value)
            |> ignore

