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

/// 域(sys(app)/doc)，自动生成代码
/// 枚举值(名称如swInputDimValOnCreate)，
/// 数据类型(bool/int/float/string)，
type SysUserPreference(swApp: ISldWorks) =

    member _.swDetailingNoteFontHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingNoteFontHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingNoteFontHeight,v)
            |> ignore

    member _.swDetailingDimFontHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimFontHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimFontHeight,v)
            |> ignore

    member _.swSTLDeviation
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSTLDeviation)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSTLDeviation,v)
            |> ignore

    member _.swSTLAngleTolerance
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSTLAngleTolerance)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSTLAngleTolerance,v)
            |> ignore

    member _.swSpinBoxMetricLengthIncrement
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxMetricLengthIncrement)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxMetricLengthIncrement,v)
            |> ignore

    member _.swSpinBoxEnglishLengthIncrement
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxEnglishLengthIncrement)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxEnglishLengthIncrement,v)
            |> ignore

    member _.swSpinBoxAngleIncrement
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxAngleIncrement)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxAngleIncrement,v)
            |> ignore

    member _.swMaterialPropertyDensity
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMaterialPropertyDensity)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMaterialPropertyDensity,v)
            |> ignore

    member _.swTiffPrintPaperWidth
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintPaperWidth)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintPaperWidth,v)
            |> ignore

    member _.swTiffPrintDrawingPaperHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperHeight,v)
            |> ignore

    member _.swTiffPrintPaperHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintPaperHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintPaperHeight,v)
            |> ignore

    member _.swTiffPrintDrawingPaperWidth
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperWidth)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperWidth,v)
            |> ignore

    member _.swDetailingCenterlineExtension
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterlineExtension)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterlineExtension,v)
            |> ignore

    member _.swDetailingBreakLineGap
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBreakLineGap)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBreakLineGap,v)
            |> ignore

    member _.swDetailingCenterMarkSize
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkSize)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkSize,v)
            |> ignore

    member _.swDetailingWitnessLineGap
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineGap)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineGap,v)
            |> ignore

    member _.swDetailingWitnessLineExtension
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineExtension)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineExtension,v)
            |> ignore

    member _.swDetailingObjectToDimOffset
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingObjectToDimOffset)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingObjectToDimOffset,v)
            |> ignore

    member _.swDetailingDimToDimOffset
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimToDimOffset)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimToDimOffset,v)
            |> ignore

    member _.swDetailingMaxLinearToleranceValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxLinearToleranceValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxLinearToleranceValue,v)
            |> ignore

    member _.swDetailingMinLinearToleranceValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMinLinearToleranceValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMinLinearToleranceValue,v)
            |> ignore

    member _.swDetailingMaxAngularToleranceValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxAngularToleranceValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxAngularToleranceValue,v)
            |> ignore

    member _.swDetailingMinAngularToleranceValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMinAngularToleranceValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMinAngularToleranceValue,v)
            |> ignore

    member _.swDetailingToleranceTextScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextScale,v)
            |> ignore

    member _.swDetailingToleranceTextHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextHeight,v)
            |> ignore

    member _.swDetailingNoteBentLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingNoteBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingNoteBentLeaderLength,v)
            |> ignore

    member _.swDetailingArrowHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingArrowHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingArrowHeight,v)
            |> ignore

    member _.swDetailingArrowWidth
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingArrowWidth)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingArrowWidth,v)
            |> ignore

    member _.swDetailingArrowLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingArrowLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingArrowLength,v)
            |> ignore

    member _.swDetailingSectionArrowHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowHeight,v)
            |> ignore

    member _.swDetailingSectionArrowWidth
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowWidth)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowWidth,v)
            |> ignore

    member _.swDetailingSectionArrowLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowLength,v)
            |> ignore

    member _.swGridMajorSpacing
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swGridMajorSpacing)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swGridMajorSpacing,v)
            |> ignore

    member _.swSnapToAngleValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSnapToAngleValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSnapToAngleValue,v)
            |> ignore

    member _.swImageQualityShadedDeviation
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swImageQualityShadedDeviation)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swImageQualityShadedDeviation,v)
            |> ignore

    member _.swDrawingDefaultSheetScaleNumerator
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleNumerator)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleNumerator,v)
            |> ignore

    member _.swDrawingDefaultSheetScaleDenominator
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleDenominator)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleDenominator,v)
            |> ignore

    member _.swDrawingDetailViewScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale,v)
            |> ignore

    member _.swViewRotationArrowKeys
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewRotationArrowKeys)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewRotationArrowKeys,v)
            |> ignore

    member _.swMateAnimationSpeed
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMateAnimationSpeed)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMateAnimationSpeed,v)
            |> ignore

    member _.swViewAnimationSpeed
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewAnimationSpeed)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewAnimationSpeed,v)
            |> ignore

    member _.swDetailingDimBentLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimBentLeaderLength,v)
            |> ignore

    member _.swMaterialPropertyCrosshatchScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchScale,v)
            |> ignore

    member _.swMaterialPropertyCrosshatchAngle
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchAngle)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchAngle,v)
            |> ignore

    member _.swDrawingAreaHatchScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchScale,v)
            |> ignore

    member _.swDrawingAreaHatchAngle
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchAngle)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchAngle,v)
            |> ignore

    member _.swPageSetupPrinterTopMargin
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterTopMargin)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterTopMargin,v)
            |> ignore

    member _.swPageSetupPrinterBottomMargin
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterBottomMargin)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterBottomMargin,v)
            |> ignore

    member _.swPageSetupPrinterLeftMargin
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterLeftMargin)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterLeftMargin,v)
            |> ignore

    member _.swPageSetupPrinterRightMargin
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterRightMargin)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterRightMargin,v)
            |> ignore

    member _.swPageSetupPrinterThinLineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThinLineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThinLineWeight,v)
            |> ignore

    member _.swPageSetupPrinterNormalLineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterNormalLineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterNormalLineWeight,v)
            |> ignore

    member _.swPageSetupPrinterThickLineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThickLineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThickLineWeight,v)
            |> ignore

    member _.swPageSetupPrinterThick2LineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick2LineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick2LineWeight,v)
            |> ignore

    member _.swPageSetupPrinterThick3LineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick3LineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick3LineWeight,v)
            |> ignore

    member _.swPageSetupPrinterThick4LineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick4LineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick4LineWeight,v)
            |> ignore

    member _.swPageSetupPrinterThick5LineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick5LineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick5LineWeight,v)
            |> ignore

    member _.swPageSetupPrinterThick6LineWeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick6LineWeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick6LineWeight,v)
            |> ignore

    member _.swPageSetupPrinterDrawingScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterDrawingScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterDrawingScale,v)
            |> ignore

    member _.swPageSetupPrinterPartAsmScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterPartAsmScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPageSetupPrinterPartAsmScale,v)
            |> ignore

    member _.swCustomizedImportTolerance
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCustomizedImportTolerance)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCustomizedImportTolerance,v)
            |> ignore

    member _.swDetailingBalloonBentLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonBentLeaderLength,v)
            |> ignore

    member _.swBOMControlSplitHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swBOMControlSplitHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swBOMControlSplitHeight,v)
            |> ignore

    member _.swAnnotationTextScaleNumerator
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleNumerator)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleNumerator,v)
            |> ignore

    member _.swAnnotationTextScaleDenominator
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleDenominator)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleDenominator,v)
            |> ignore

    member _.swDetailingDimBreakGap
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimBreakGap)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimBreakGap,v)
            |> ignore

    member _.swCurvatureValue1
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue1)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue1,v)
            |> ignore

    member _.swCurvatureValue2
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue2)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue2,v)
            |> ignore

    member _.swCurvatureValue3
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue3)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue3,v)
            |> ignore

    member _.swCurvatureValue4
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue4)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue4,v)
            |> ignore

    member _.swCurvatureValue5
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue5)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swCurvatureValue5,v)
            |> ignore

    member _.swDetailingBreakLineExtension
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBreakLineExtension)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBreakLineExtension,v)
            |> ignore

    member _.swDetailingToleranceFitTolTextScale
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextScale)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextScale,v)
            |> ignore

    member _.swDetailingToleranceFitTolTextHeight
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextHeight)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextHeight,v)
            |> ignore

    member _.swDocumentColorAdvancedAmbient
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedAmbient)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedAmbient,v)
            |> ignore

    member _.swDocumentColorAdvancedDiffuse
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedDiffuse)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedDiffuse,v)
            |> ignore

    member _.swDocumentColorAdvancedSpecularity
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedSpecularity)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedSpecularity,v)
            |> ignore

    member _.swDocumentColorAdvancedShininess
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedShininess)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedShininess,v)
            |> ignore

    member _.swDocumentColorAdvancedTransparency
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedTransparency)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedTransparency,v)
            |> ignore

    member _.swDocumentColorAdvancedEmission
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedEmission)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedEmission,v)
            |> ignore

    member _.swDxfOutputScaleFactor
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDxfOutputScaleFactor)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDxfOutputScaleFactor,v)
            |> ignore

    member _.swHoleTableTagAngle
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swHoleTableTagAngle)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swHoleTableTagAngle,v)
            |> ignore

    member _.swHoleTableTagOffset
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swHoleTableTagOffset)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swHoleTableTagOffset,v)
            |> ignore

    member _.swDetailingMaxWitnessLineLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxWitnessLineLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxWitnessLineLength,v)
            |> ignore

    member _.swDrawingKeyboardMovementIncrement
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingKeyboardMovementIncrement)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingKeyboardMovementIncrement,v)
            |> ignore

    member _.swSketchSnapsAngleValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSketchSnapsAngleValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSketchSnapsAngleValue,v)
            |> ignore

    member _.swDxfMergingDistance
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDxfMergingDistance)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDxfMergingDistance,v)
            |> ignore

    member _.swDetailingDimRadialSnapAngle
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimRadialSnapAngle)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDimRadialSnapAngle,v)
            |> ignore

    member _.swViewTransitionHideShowComponent
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewTransitionHideShowComponent)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewTransitionHideShowComponent,v)
            |> ignore

    member _.swViewTransitionIsolate
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewTransitionIsolate)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewTransitionIsolate,v)
            |> ignore

    member _.swLineFontVisibleEdgesThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontVisibleEdgesThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontVisibleEdgesThicknessCustom,v)
            |> ignore

    member _.swLineFontHiddenEdgesThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontHiddenEdgesThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontHiddenEdgesThicknessCustom,v)
            |> ignore

    member _.swLineFontSketchCurvesThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontSketchCurvesThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontSketchCurvesThicknessCustom,v)
            |> ignore

    member _.swLineFontDetailCircleThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontDetailCircleThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontDetailCircleThicknessCustom,v)
            |> ignore

    member _.swLineFontSectionLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontSectionLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontSectionLineThicknessCustom,v)
            |> ignore

    member _.swLineFontDimensionsThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontDimensionsThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontDimensionsThicknessCustom,v)
            |> ignore

    member _.swLineFontConstructionCurvesThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontConstructionCurvesThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontConstructionCurvesThicknessCustom,v)
            |> ignore

    member _.swLineFontCrosshatchThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontCrosshatchThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontCrosshatchThicknessCustom,v)
            |> ignore

    member _.swLineFontTangentEdgesThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontTangentEdgesThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontTangentEdgesThicknessCustom,v)
            |> ignore

    member _.swLineFontDetailBorderThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontDetailBorderThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontDetailBorderThicknessCustom,v)
            |> ignore

    member _.swLineFontCosmeticThreadThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontCosmeticThreadThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontCosmeticThreadThicknessCustom,v)
            |> ignore

    member _.swLineFontHideTangentEdgeThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontHideTangentEdgeThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontHideTangentEdgeThicknessCustom,v)
            |> ignore

    member _.swLineFontViewArrowThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontViewArrowThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontViewArrowThicknessCustom,v)
            |> ignore

    member _.swLineFontExplodedLinesThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontExplodedLinesThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontExplodedLinesThicknessCustom,v)
            |> ignore

    member _.swLineFontBreakLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontBreakLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontBreakLineThicknessCustom,v)
            |> ignore

    member _.swDetailingBalloonLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonLeaderLineThicknessCustom,v)
            |> ignore

    member _.swDetailingBalloonFrameLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonFrameLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonFrameLineThicknessCustom,v)
            |> ignore

    member _.swDetailingDatumLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDatumLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDatumLeaderLineThicknessCustom,v)
            |> ignore

    member _.swDetailingDatumFrameLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDatumFrameLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingDatumFrameLineThicknessCustom,v)
            |> ignore

    member _.swDetailingGtolLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingGtolLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingGtolLeaderLineThicknessCustom,v)
            |> ignore

    member _.swDetailingGtolFrameLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingGtolFrameLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingGtolFrameLineThicknessCustom,v)
            |> ignore

    member _.swDetailingNoteLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingNoteLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingNoteLeaderLineThicknessCustom,v)
            |> ignore

    member _.swDetailingSFSymbolLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolLeaderLineThicknessCustom,v)
            |> ignore

    member _.swDetailingWeldSymbolLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingWeldSymbolLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingWeldSymbolLeaderLineThicknessCustom,v)
            |> ignore

    member _.swDetailingAnnotationBentLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingAnnotationBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingAnnotationBentLeaderLength,v)
            |> ignore

    member _.swDetailingGtolBentLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingGtolBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingGtolBentLeaderLength,v)
            |> ignore

    member _.swDetailingSFSymbolBentLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolBentLeaderLength,v)
            |> ignore

    member _.swDetailingMaxToleranceValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxToleranceValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMaxToleranceValue,v)
            |> ignore

    member _.swDetailingMinToleranceValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMinToleranceValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingMinToleranceValue,v)
            |> ignore

    member _.swSpinBoxTimeIncrement
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxTimeIncrement)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSpinBoxTimeIncrement,v)
            |> ignore

    member _.swDetailingBorderUserDefined
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderUserDefined)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderUserDefined,v)
            |> ignore

    member _.swDetailingBOMBalloonCustomSize
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonCustomSize)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonCustomSize,v)
            |> ignore

    member _.swDetailingBOMStackedBalloonCustomSize
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonCustomSize)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonCustomSize,v)
            |> ignore

    member _.swLineFontSpeedPakDrawingsModelEdgesThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontSpeedPakDrawingsModelEdgesThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontSpeedPakDrawingsModelEdgesThicknessCustom,v)
            |> ignore

    member _.swPartDimXpertLengthUnitTol1Value
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol1Value)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol1Value,v)
            |> ignore

    member _.swPartDimXpertLengthUnitTol2Value
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol2Value)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol2Value,v)
            |> ignore

    member _.swPartDimXpertLengthUnitTol3Value
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol3Value)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol3Value,v)
            |> ignore

    member _.swPartDimXpertAngularUnitTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertAngularUnitTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertAngularUnitTolValue,v)
            |> ignore

    member _.swPartDimXpertLocationDistanceTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertLocationDistanceTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertLocationAngleTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertLocationAngleTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertChainPatternLocTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertChainPatternLocTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertChainInnerTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertChainInnerTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertGeometricPrimaryTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPrimaryTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPrimaryTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricSecondFeatureSizeTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondFeatureSizeTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondFeatureSizeTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricSecondPlaneFeatureTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondPlaneFeatureTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondPlaneFeatureTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricThirdFeatureSizeTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdFeatureSizeTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdFeatureSizeTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricThirdPlaneFeatureTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdPlaneFeatureTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdPlaneFeatureTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricPositionTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricPositionCompositeTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionCompositeTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionCompositeTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricSurfaceProfileTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricSurfaceProfileCompositeTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileCompositeTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileCompositeTolValue,v)
            |> ignore

    member _.swPartDimXpertGeometricRunoutTolValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricRunoutTolValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricRunoutTolValue,v)
            |> ignore

    member _.swPartDimXpertChamferWidthRatio
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferWidthRatio)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferWidthRatio,v)
            |> ignore

    member _.swPartDimXpertChamferMaxWidth
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferMaxWidth)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferMaxWidth,v)
            |> ignore

    member _.swPartDimXpertChamferDistanceTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertChamferDistanceTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertChamferAngleTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertChamferAngleTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeDiameterTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeDiameterTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeDepthTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeDepthTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolLowerValue,v)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusTolUpperValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolUpperValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolUpperValue,v)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusTolLowerValue
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolLowerValue)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolLowerValue,v)
            |> ignore

    member _.swPunchTableTagAngle
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPunchTableTagAngle)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPunchTableTagAngle,v)
            |> ignore

    member _.swPunchTableTagOffset
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPunchTableTagOffset)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPunchTableTagOffset,v)
            |> ignore

    member _.swLineFontAdjoiningComponentCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontAdjoiningComponentCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontAdjoiningComponentCustom,v)
            |> ignore

    member _.swQuickViewTransparencyLevel
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swQuickViewTransparencyLevel)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swQuickViewTransparencyLevel,v)
            |> ignore

    member _.swDetailingRevisionCloudLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudLineThicknessCustom,v)
            |> ignore

    member _.swDetailingRevisionCloudMaxArcRadius
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudMaxArcRadius)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudMaxArcRadius,v)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLineThicknessCustom,v)
            |> ignore

    member _.swSheetMetalBendNotesBorderSizeCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesBorderSizeCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesBorderSizeCustom,v)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLength,v)
            |> ignore

    member _.swDetailingBorderAddPadding
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderAddPadding)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderAddPadding,v)
            |> ignore

    member _.swDetailingBOMBalloonPadding
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonPadding)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonPadding,v)
            |> ignore

    member _.swDetailingBOMStackedBalloonPadding
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonPadding)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonPadding,v)
            |> ignore

    member _.swDetailingTablesHorizontalPadding
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingTablesHorizontalPadding)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingTablesHorizontalPadding,v)
            |> ignore

    member _.swDetailingTablesVerticalPadding
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingTablesVerticalPadding)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingTablesVerticalPadding,v)
            |> ignore

    member _.swLineFontBendLineUpThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontBendLineUpThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontBendLineUpThicknessCustom,v)
            |> ignore

    member _.swLineFontBendLineDownThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontBendLineDownThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontBendLineDownThicknessCustom,v)
            |> ignore

    member _.swLineFontEnvelopeComponentThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontEnvelopeComponentThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontEnvelopeComponentThicknessCustom,v)
            |> ignore

    member _.swDetailingCenterOfMassSize
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterOfMassSize)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterOfMassSize,v)
            |> ignore

    member _.swViewSelectorSpeed
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewSelectorSpeed)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swViewSelectorSpeed,v)
            |> ignore

    member _.swDetailingBalloonQtyGapDistance
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonQtyGapDistance)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBalloonQtyGapDistance,v)
            |> ignore

    member _.swDimensionsExtensionLineStyleThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDimensionsExtensionLineStyleThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDimensionsExtensionLineStyleThicknessCustom,v)
            |> ignore

    member _.swSmartMateSensitivity
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSmartMateSensitivity)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSmartMateSensitivity,v)
            |> ignore

    member _.swSystemTouchRotateWidth
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSystemTouchRotateWidth)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSystemTouchRotateWidth,v)
            |> ignore

    member _.swSystemTouchRotateVersusPanThreshhold
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSystemTouchRotateVersusPanThreshhold)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSystemTouchRotateVersusPanThreshhold,v)
            |> ignore

    member _.swDetailingParaSpacing
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingParaSpacing)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingParaSpacing,v)
            |> ignore

    member _.swTwistCountValuePerMeter
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTwistCountValuePerMeter)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swTwistCountValuePerMeter,v)
            |> ignore

    member _.swDetailingLocationLabelFrameLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelFrameLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelFrameLineThicknessCustom,v)
            |> ignore

    member _.swDetailingLocationLabelStyleCustomSize
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelStyleCustomSize)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelStyleCustomSize,v)
            |> ignore

    member _.swDetailingLocationLabelPadding
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelPadding)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelPadding,v)
            |> ignore

    member _.swDetailingCenterMarkGap
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkGap)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkGap,v)
            |> ignore

    member _.swDetailingBorderLeaderCustomLineThickness
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderLeaderCustomLineThickness)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderLeaderCustomLineThickness,v)
            |> ignore

    member _.swDetailingBorderZoneDividerLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerLength,v)
            |> ignore

    member _.swDetailingBorderOuterCenterZoneDividerLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderOuterCenterZoneDividerLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderOuterCenterZoneDividerLength,v)
            |> ignore

    member _.swDetailingBorderInnerCenterZoneDividerLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderInnerCenterZoneDividerLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderInnerCenterZoneDividerLength,v)
            |> ignore

    member _.swDetailingBorderZoneDividerCustomLineThickness
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerCustomLineThickness)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerCustomLineThickness,v)
            |> ignore

    member _.swDetailingOrdinateSize
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingOrdinateSize)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingOrdinateSize,v)
            |> ignore

    member _.swLineFontEmphasizedSectionThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontEmphasizedSectionThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swLineFontEmphasizedSectionThicknessCustom,v)
            |> ignore

    member _.swPrint3DBoxX
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPrint3DBoxX)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPrint3DBoxX,v)
            |> ignore

    member _.swPrint3DBoxY
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPrint3DBoxY)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPrint3DBoxY,v)
            |> ignore

    member _.swPrint3DBoxZ
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPrint3DBoxZ)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPrint3DBoxZ,v)
            |> ignore

    member _.swMatesMaximumDeviationForMisalignedMates
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMatesMaximumDeviationForMisalignedMates)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swMatesMaximumDeviationForMisalignedMates,v)
            |> ignore

    member _.swASMSLDPRT_ExcludeComponentsByVisibilityThreshold
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByVisibilityThreshold)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByVisibilityThreshold,v)
            |> ignore

    member _.swASMSLDPRT_ExcludeComponentsByBBoxVolumeThreshold
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByBBoxVolumeThreshold)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByBBoxVolumeThreshold,v)
            |> ignore

    member _.swPLYDeviation
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPLYDeviation)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPLYDeviation,v)
            |> ignore

    member _.swPLYAngleTolerance
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPLYAngleTolerance)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swPLYAngleTolerance,v)
            |> ignore

    member _.swSheetMetalMBDLeaderLineThicknessCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLineThicknessCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLineThicknessCustom,v)
            |> ignore

    member _.swSheetMetalMBDBorderSizeCustom
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalMBDBorderSizeCustom)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalMBDBorderSizeCustom,v)
            |> ignore

    member _.swSheetMetalMBDLeaderLength
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLength)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLength,v)
            |> ignore

    member _.swDetailingHatchDensityLimit
        with get () =
            swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingHatchDensityLimit)
        and set v =
            swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDetailingHatchDensityLimit,v)
            |> ignore

    member _.swDxfVersion
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfVersion)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfVersion,v)
            |> ignore

    member _.swDxfOutputFonts
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfOutputFonts)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfOutputFonts,v)
            |> ignore

    member _.swDxfMappingFileIndex
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfMappingFileIndex)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfMappingFileIndex,v)
            |> ignore

    member _.swAutoSaveInterval
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAutoSaveInterval)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAutoSaveInterval,v)
            |> ignore

    member _.swResolveLightweight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swResolveLightweight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swResolveLightweight,v)
            |> ignore

    member _.swAcisOutputVersion
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAcisOutputVersion)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAcisOutputVersion,v)
            |> ignore

    member _.swTiffScreenOrPrintCapture
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffScreenOrPrintCapture)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffScreenOrPrintCapture,v)
            |> ignore

    member _.swTiffImageType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffImageType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffImageType,v)
            |> ignore

    member _.swTiffCompressionScheme
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffCompressionScheme)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffCompressionScheme,v)
            |> ignore

    member _.swTiffPrintDPI
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffPrintDPI)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffPrintDPI,v)
            |> ignore

    member _.swTiffPrintPaperSize
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffPrintPaperSize)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffPrintPaperSize,v)
            |> ignore

    member _.swTiffPrintScaleFactor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffPrintScaleFactor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTiffPrintScaleFactor,v)
            |> ignore

    member _.swCreateBodyFromSurfacesOption
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCreateBodyFromSurfacesOption)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCreateBodyFromSurfacesOption,v)
            |> ignore

    member _.swDetailingDimensionStandard
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionStandard)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionStandard,v)
            |> ignore

    member _.swDetailingDualDimPosition
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDualDimPosition)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDualDimPosition,v)
            |> ignore

    member _.swDetailingDimTrailingZero
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimTrailingZero)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimTrailingZero,v)
            |> ignore

    member _.swDetailingArrowStyleForDimensions
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForDimensions)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForDimensions,v)
            |> ignore

    member _.swDetailingDimensionArrowPosition
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionArrowPosition)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionArrowPosition,v)
            |> ignore

    member _.swDetailingLinearDimLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearDimLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearDimLeaderStyle,v)
            |> ignore

    member _.swDetailingRadialDimLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRadialDimLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRadialDimLeaderStyle,v)
            |> ignore

    member _.swDetailingAngularDimLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularDimLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularDimLeaderStyle,v)
            |> ignore

    member _.swDetailingLinearToleranceStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearToleranceStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearToleranceStyle,v)
            |> ignore

    member _.swDetailingAngularToleranceStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularToleranceStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularToleranceStyle,v)
            |> ignore

    member _.swDetailingToleranceTextSizing
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceTextSizing)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceTextSizing,v)
            |> ignore

    member _.swDetailingLinearDimPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearDimPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearDimPrecision,v)
            |> ignore

    member _.swDetailingLinearTolPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearTolPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearTolPrecision,v)
            |> ignore

    member _.swDetailingAltLinearDimPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAltLinearDimPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAltLinearDimPrecision,v)
            |> ignore

    member _.swDetailingAltLinearTolPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAltLinearTolPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAltLinearTolPrecision,v)
            |> ignore

    member _.swDetailingAngularDimPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularDimPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularDimPrecision,v)
            |> ignore

    member _.swDetailingAngularTolPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularTolPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularTolPrecision,v)
            |> ignore

    member _.swDetailingNoteTextAlignment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteTextAlignment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteTextAlignment,v)
            |> ignore

    member _.swDetailingNoteLeaderSide
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderSide)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderSide,v)
            |> ignore

    member _.swDetailingBalloonStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonStyle,v)
            |> ignore

    member _.swDetailingBalloonFit
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonFit)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonFit,v)
            |> ignore

    member _.swDetailingBOMBalloonStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonStyle,v)
            |> ignore

    member _.swDetailingBOMBalloonFit
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonFit)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonFit,v)
            |> ignore

    member _.swDetailingBOMUpperText
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMUpperText)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMUpperText,v)
            |> ignore

    member _.swDetailingBOMLowerText
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMLowerText)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMLowerText,v)
            |> ignore

    member _.swDetailingArrowStyleForEdgeVertexAttachment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForEdgeVertexAttachment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForEdgeVertexAttachment,v)
            |> ignore

    member _.swDetailingArrowStyleForFaceAttachment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForFaceAttachment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForFaceAttachment,v)
            |> ignore

    member _.swDetailingArrowStyleForUnattached
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForUnattached)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForUnattached,v)
            |> ignore

    member _.swDetailingVirtualSharpStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingVirtualSharpStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingVirtualSharpStyle,v)
            |> ignore

    member _.swGridMinorLinesPerMajor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGridMinorLinesPerMajor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGridMinorLinesPerMajor,v)
            |> ignore

    member _.swSnapPointsPerMinor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSnapPointsPerMinor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSnapPointsPerMinor,v)
            |> ignore

    member _.swImageQualityShaded
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImageQualityShaded)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImageQualityShaded,v)
            |> ignore

    member _.swImageQualityWireframe
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImageQualityWireframe)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImageQualityWireframe,v)
            |> ignore

    member _.swImageQualityWireframeValue
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImageQualityWireframeValue)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImageQualityWireframeValue,v)
            |> ignore

    member _.swUnitsLinear
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinear)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinear,v)
            |> ignore

    member _.swUnitsLinearDecimalDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalDisplay,v)
            |> ignore

    member _.swUnitsLinearDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalPlaces,v)
            |> ignore

    member _.swUnitsLinearFractionDenominator
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinearFractionDenominator)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsLinearFractionDenominator,v)
            |> ignore

    member _.swUnitsAngular
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsAngular)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsAngular,v)
            |> ignore

    member _.swUnitsAngularDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsAngularDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsAngularDecimalPlaces,v)
            |> ignore

    member _.swLineFontVisibleEdgesThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesThickness,v)
            |> ignore

    member _.swLineFontVisibleEdgesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesStyle,v)
            |> ignore

    member _.swLineFontHiddenEdgesThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesThickness,v)
            |> ignore

    member _.swLineFontHiddenEdgesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesStyle,v)
            |> ignore

    member _.swLineFontSketchCurvesThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesThickness,v)
            |> ignore

    member _.swLineFontSketchCurvesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesStyle,v)
            |> ignore

    member _.swLineFontDetailCircleThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleThickness,v)
            |> ignore

    member _.swLineFontDetailCircleStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleStyle,v)
            |> ignore

    member _.swLineFontSectionLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSectionLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSectionLineThickness,v)
            |> ignore

    member _.swLineFontSectionLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSectionLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSectionLineStyle,v)
            |> ignore

    member _.swLineFontDimensionsThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDimensionsThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDimensionsThickness,v)
            |> ignore

    member _.swLineFontDimensionsStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDimensionsStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDimensionsStyle,v)
            |> ignore

    member _.swLineFontConstructionCurvesThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesThickness,v)
            |> ignore

    member _.swLineFontConstructionCurvesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesStyle,v)
            |> ignore

    member _.swLineFontCrosshatchThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchThickness,v)
            |> ignore

    member _.swLineFontCrosshatchStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchStyle,v)
            |> ignore

    member _.swLineFontTangentEdgesThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesThickness,v)
            |> ignore

    member _.swLineFontTangentEdgesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesStyle,v)
            |> ignore

    member _.swLineFontDetailBorderThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderThickness,v)
            |> ignore

    member _.swLineFontDetailBorderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderStyle,v)
            |> ignore

    member _.swLineFontCosmeticThreadThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadThickness,v)
            |> ignore

    member _.swLineFontCosmeticThreadStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadStyle,v)
            |> ignore

    member _.swStepAP
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swStepAP)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swStepAP,v)
            |> ignore

    member _.swHiddenEdgeDisplayDefault
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHiddenEdgeDisplayDefault)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHiddenEdgeDisplayDefault,v)
            |> ignore

    member _.swTangentEdgeDisplayDefault
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTangentEdgeDisplayDefault)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTangentEdgeDisplayDefault,v)
            |> ignore

    member _.swSTLQuality
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSTLQuality)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSTLQuality,v)
            |> ignore

    member _.swDrawingProjectionType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingProjectionType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingProjectionType,v)
            |> ignore

    member _.swDrawingPrintCrosshatchOutOfDateViews
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingPrintCrosshatchOutOfDateViews)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingPrintCrosshatchOutOfDateViews,v)
            |> ignore

    member _.swPerformanceAssemRebuildOnLoad
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPerformanceAssemRebuildOnLoad)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPerformanceAssemRebuildOnLoad,v)
            |> ignore

    member _.swLoadExternalReferences
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLoadExternalReferences)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLoadExternalReferences,v)
            |> ignore

    member _.swIGESRepresentation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIGESRepresentation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIGESRepresentation,v)
            |> ignore

    member _.swIGESSystem
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIGESSystem)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIGESSystem,v)
            |> ignore

    member _.swIGESCurveRepresentation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIGESCurveRepresentation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIGESCurveRepresentation,v)
            |> ignore

    member _.swViewRotationMouseSpeed
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed,v)
            |> ignore

    member _.swBackupCopiesPerDocument
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBackupCopiesPerDocument)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBackupCopiesPerDocument,v)
            |> ignore

    member _.swCheckForOutOfDateLightweightComponents
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCheckForOutOfDateLightweightComponents)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCheckForOutOfDateLightweightComponents,v)
            |> ignore

    member _.swParasolidOutputVersion
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swParasolidOutputVersion)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swParasolidOutputVersion,v)
            |> ignore

    member _.swLineFontHideTangentEdgeThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeThickness,v)
            |> ignore

    member _.swLineFontHideTangentEdgeStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeStyle,v)
            |> ignore

    member _.swLineFontViewArrowThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontViewArrowThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontViewArrowThickness,v)
            |> ignore

    member _.swLineFontViewArrowStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontViewArrowStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontViewArrowStyle,v)
            |> ignore

    member _.swEdgesHiddenEdgeDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay,v)
            |> ignore

    member _.swEdgesTangentEdgeDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesTangentEdgeDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesTangentEdgeDisplay,v)
            |> ignore

    member _.swEdgesShadedModeDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesShadedModeDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesShadedModeDisplay,v)
            |> ignore

    member _.swDetailingBOMStackedBalloonStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonStyle,v)
            |> ignore

    member _.swDetailingBOMStackedBalloonFit
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonFit)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonFit,v)
            |> ignore

    member _.swSystemColorsViewportBackground
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground,v)
            |> ignore

    member _.swSystemColorsTopGradientColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTopGradientColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTopGradientColor,v)
            |> ignore

    member _.swSystemColorsBottomGradientColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsBottomGradientColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsBottomGradientColor,v)
            |> ignore

    member _.swSystemColorsDynamicHighlight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDynamicHighlight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDynamicHighlight,v)
            |> ignore

    member _.swSystemColorsHighlight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsHighlight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsHighlight,v)
            |> ignore

    member _.swSystemColorsSelectedItem1
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem1)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem1,v)
            |> ignore

    member _.swSystemColorsSelectedItem2
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem2)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem2,v)
            |> ignore

    member _.swSystemColorsSelectedItem3
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem3)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem3,v)
            |> ignore

    member _.swSystemColorsSelectedFaceShaded
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedFaceShaded)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedFaceShaded,v)
            |> ignore

    member _.swSystemColorsDrawingsVisibleModelEdge
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsVisibleModelEdge)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsVisibleModelEdge,v)
            |> ignore

    member _.swSystemColorsDrawingsHiddenModelEdge
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsHiddenModelEdge)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsHiddenModelEdge,v)
            |> ignore

    member _.swSystemColorsDrawingsPaperBorder
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperBorder)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperBorder,v)
            |> ignore

    member _.swSystemColorsDrawingsPaperShadow
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperShadow)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperShadow,v)
            |> ignore

    member _.swSystemColorsDrawingsSheetBorder
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSheetBorder)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSheetBorder,v)
            |> ignore

    member _.swSystemColorsImportedDrivingAnnotation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivingAnnotation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivingAnnotation,v)
            |> ignore

    member _.swSystemColorsImportedDrivenAnnotation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivenAnnotation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivenAnnotation,v)
            |> ignore

    member _.swSystemColorsSketchOverDefined
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchOverDefined)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchOverDefined,v)
            |> ignore

    member _.swSystemColorsSketchFullyDefined
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchFullyDefined)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchFullyDefined,v)
            |> ignore

    member _.swSystemColorsSketchUnderDefined
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchUnderDefined)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchUnderDefined,v)
            |> ignore

    member _.swSystemColorsSketchInvalidGeometry
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInvalidGeometry)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInvalidGeometry,v)
            |> ignore

    member _.swSystemColorsSketchNotSolved
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchNotSolved)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchNotSolved,v)
            |> ignore

    member _.swSystemColorsGridLinesMinor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMinor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMinor,v)
            |> ignore

    member _.swSystemColorsGridLinesMajor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMajor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMajor,v)
            |> ignore

    member _.swSystemColorsConstructionGeometry
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsConstructionGeometry)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsConstructionGeometry,v)
            |> ignore

    member _.swSystemColorsDanglingDimension
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDanglingDimension)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDanglingDimension,v)
            |> ignore

    member _.swSystemColorsText
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsText)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsText,v)
            |> ignore

    member _.swSystemColorsAssemblyEditPart
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPart)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPart,v)
            |> ignore

    member _.swSystemColorsAssemblyEditPartHiddenLines
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPartHiddenLines)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPartHiddenLines,v)
            |> ignore

    member _.swSystemColorsAssemblyNonEditPart
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyNonEditPart)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyNonEditPart,v)
            |> ignore

    member _.swSystemColorsInactiveEntity
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveEntity)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveEntity,v)
            |> ignore

    member _.swSystemColorsTemporaryGraphics
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphics)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphics,v)
            |> ignore

    member _.swSystemColorsTemporaryGraphicsShaded
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphicsShaded)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphicsShaded,v)
            |> ignore

    member _.swSystemColorsActiveSelectionListBox
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsActiveSelectionListBox)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsActiveSelectionListBox,v)
            |> ignore

    member _.swSystemColorsSurfacesOpenEdge
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSurfacesOpenEdge)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSurfacesOpenEdge,v)
            |> ignore

    member _.swSystemColorsTreeViewBackground
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTreeViewBackground)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTreeViewBackground,v)
            |> ignore

    member _.swAcisOutputUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAcisOutputUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAcisOutputUnits,v)
            |> ignore

    member _.swSystemColorsShadedEdge
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsShadedEdge)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsShadedEdge,v)
            |> ignore

    member _.swDxfOutputLineStyles
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfOutputLineStyles)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfOutputLineStyles,v)
            |> ignore

    member _.swDxfOutputNoScale
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfOutputNoScale)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfOutputNoScale,v)
            |> ignore

    member _.swPageSetupPrinterOrientation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPageSetupPrinterOrientation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPageSetupPrinterOrientation,v)
            |> ignore

    member _.swPageSetupPrinterDrawingColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPageSetupPrinterDrawingColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPageSetupPrinterDrawingColor,v)
            |> ignore

    member _.swImportCheckAndRepair
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportCheckAndRepair)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportCheckAndRepair,v)
            |> ignore

    member _.swUseCustomizedImportTolerance
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUseCustomizedImportTolerance)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUseCustomizedImportTolerance,v)
            |> ignore

    member _.swStepExportPreference
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swStepExportPreference)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swStepExportPreference,v)
            |> ignore

    member _.swEdgesInContextEditTransparencyType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparencyType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparencyType,v)
            |> ignore

    member _.swEdgesInContextEditTransparency
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparency)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparency,v)
            |> ignore

    member _.swPlaneDisplayFrontFaceColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayFrontFaceColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayFrontFaceColor,v)
            |> ignore

    member _.swPlaneDisplayBackFaceColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayBackFaceColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayBackFaceColor,v)
            |> ignore

    member _.swPlaneDisplayTransparency
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayTransparency)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayTransparency,v)
            |> ignore

    member _.swPlaneDisplayIntersectionLineColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayIntersectionLineColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPlaneDisplayIntersectionLineColor,v)
            |> ignore

    member _.swDetailingDatumDisplayType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumDisplayType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumDisplayType,v)
            |> ignore

    member _.swBOMConfigurationAnchorType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMConfigurationAnchorType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMConfigurationAnchorType,v)
            |> ignore

    member _.swBOMConfigurationWhatToShow
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMConfigurationWhatToShow)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMConfigurationWhatToShow,v)
            |> ignore

    member _.swBOMControlMissingRowDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMControlMissingRowDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMControlMissingRowDisplay,v)
            |> ignore

    member _.swBOMControlSplitDirection
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMControlSplitDirection)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBOMControlSplitDirection,v)
            |> ignore

    member _.swDetailingChamferDimLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingChamferDimLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingChamferDimLeaderStyle,v)
            |> ignore

    member _.swDetailingChamferDimTextStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingChamferDimTextStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingChamferDimTextStyle,v)
            |> ignore

    member _.swDetailingChamferDimXStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingChamferDimXStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingChamferDimXStyle,v)
            |> ignore

    member _.swDocumentColorFeatBend
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBend)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBend,v)
            |> ignore

    member _.swDocumentColorFeatBoss
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBoss)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBoss,v)
            |> ignore

    member _.swDocumentColorFeatCavity
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCavity)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCavity,v)
            |> ignore

    member _.swDocumentColorFeatChamfer
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatChamfer)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatChamfer,v)
            |> ignore

    member _.swDocumentColorFeatCut
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCut)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCut,v)
            |> ignore

    member _.swDocumentColorFeatLoftCut
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoftCut)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoftCut,v)
            |> ignore

    member _.swDocumentColorFeatSurfCut
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSurfCut)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSurfCut,v)
            |> ignore

    member _.swDocumentColorFeatSweepCut
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweepCut)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweepCut,v)
            |> ignore

    member _.swDocumentColorFeatWeldBead
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWeldBead)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWeldBead,v)
            |> ignore

    member _.swDocumentColorFeatExtrude
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatExtrude)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatExtrude,v)
            |> ignore

    member _.swDocumentColorFeatFillet
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatFillet)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatFillet,v)
            |> ignore

    member _.swDocumentColorFeatHole
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatHole)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatHole,v)
            |> ignore

    member _.swDocumentColorFeatLibrary
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLibrary)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLibrary,v)
            |> ignore

    member _.swDocumentColorFeatLoft
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoft)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoft,v)
            |> ignore

    member _.swDocumentColorFeatMidSurface
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatMidSurface)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatMidSurface,v)
            |> ignore

    member _.swDocumentColorFeatPattern
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatPattern)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatPattern,v)
            |> ignore

    member _.swDocumentColorFeatRefSurface
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRefSurface)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRefSurface,v)
            |> ignore

    member _.swDocumentColorFeatRevolution
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRevolution)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRevolution,v)
            |> ignore

    member _.swDocumentColorFeatShell
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShell)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShell,v)
            |> ignore

    member _.swDocumentColorFeatDerivedPart
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDerivedPart)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDerivedPart,v)
            |> ignore

    member _.swDocumentColorFeatSweep
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweep)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweep,v)
            |> ignore

    member _.swDocumentColorFeatThicken
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatThicken)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatThicken,v)
            |> ignore

    member _.swDocumentColorFeatRib
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRib)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRib,v)
            |> ignore

    member _.swDocumentColorFeatDome
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDome)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDome,v)
            |> ignore

    member _.swDocumentColorFeatForm
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatForm)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatForm,v)
            |> ignore

    member _.swDocumentColorFeatShape
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShape)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShape,v)
            |> ignore

    member _.swDocumentColorFeatReplaceFace
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatReplaceFace)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatReplaceFace,v)
            |> ignore

    member _.swDocumentColorWireFrame
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorWireFrame)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorWireFrame,v)
            |> ignore

    member _.swDocumentColorShading
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorShading)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorShading,v)
            |> ignore

    member _.swDocumentColorHidden
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorHidden)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorHidden,v)
            |> ignore

    member _.swLineFontExplodedLinesThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesThickness,v)
            |> ignore

    member _.swLineFontExplodedLinesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesStyle,v)
            |> ignore

    member _.swSystemColorsRefTriadX
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadX)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadX,v)
            |> ignore

    member _.swSystemColorsRefTriadY
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadY)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadY,v)
            |> ignore

    member _.swSystemColorsRefTriadZ
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadZ)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadZ,v)
            |> ignore

    member _.swAcisOutputGeometryPreference
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAcisOutputGeometryPreference)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAcisOutputGeometryPreference,v)
            |> ignore

    member _.swSystemColorsDTDim
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDTDim)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDTDim,v)
            |> ignore

    member _.swLargeAsmModeThreshold
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeThreshold)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeThreshold,v)
            |> ignore

    member _.swLargeAsmModeAutoActivate
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoActivate)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoActivate,v)
            |> ignore

    member _.swLargeAsmModeCheckOutOfDateLightweight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeCheckOutOfDateLightweight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeCheckOutOfDateLightweight,v)
            |> ignore

    member _.swLargeAsmModeAutoRecoverCount
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoRecoverCount)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoRecoverCount,v)
            |> ignore

    member _.swLargeAsmModeDisplayModeForNewDrawViews
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeDisplayModeForNewDrawViews)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeDisplayModeForNewDrawViews,v)
            |> ignore

    member _.swLineFontBreakLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBreakLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBreakLineThickness,v)
            |> ignore

    member _.swLineFontBreakLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBreakLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBreakLineStyle,v)
            |> ignore

    member _.swSaveAssemblyAsPartOptions
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveAssemblyAsPartOptions)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveAssemblyAsPartOptions,v)
            |> ignore

    member _.swDetailingDimensionTextAlignmentVertical
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentVertical)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentVertical,v)
            |> ignore

    member _.swDetailingDimensionTextAlignmentHorizontal
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentHorizontal)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentHorizontal,v)
            |> ignore

    member _.swDetailingToleranceFitTolTextSizing
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolTextSizing)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolTextSizing,v)
            |> ignore

    member _.swImportUnitPreference
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportUnitPreference)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportUnitPreference,v)
            |> ignore

    member _.swImportCurvePreference
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportCurvePreference)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportCurvePreference,v)
            |> ignore

    member _.swImportUseBrep
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportUseBrep)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportUseBrep,v)
            |> ignore

    member _.swImportStlVrmlModelType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportStlVrmlModelType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportStlVrmlModelType,v)
            |> ignore

    member _.swSystemColorsSelectedItem4
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem4)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem4,v)
            |> ignore

    member _.swImportStlVrmlUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportStlVrmlUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportStlVrmlUnits,v)
            |> ignore

    member _.swExportStlUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportStlUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportStlUnits,v)
            |> ignore

    member _.swExportVrmlUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportVrmlUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportVrmlUnits,v)
            |> ignore

    member _.swSystemColorsSketchInactive
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInactive)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInactive,v)
            |> ignore

    member _.swExternalReferencesUpdateOutOfDateLinkedDesignTable
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExternalReferencesUpdateOutOfDateLinkedDesignTable)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExternalReferencesUpdateOutOfDateLinkedDesignTable,v)
            |> ignore

    member _.swSystemColorsTreeItemNormal
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemNormal)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemNormal,v)
            |> ignore

    member _.swSystemColorsTreeItemSelected
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemSelected)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemSelected,v)
            |> ignore

    member _.swSystemColorsDrawingsPaper
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaper)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaper,v)
            |> ignore

    member _.swSystemColorsDrawingsBackground
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsBackground)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsBackground,v)
            |> ignore

    member _.swSystemColorsDrawingsViewBorder
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsViewBorder)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsViewBorder,v)
            |> ignore

    member _.swDetailingNotesLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNotesLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNotesLeaderStyle,v)
            |> ignore

    member _.swSystemColorsDrawingsLockedFocus
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsLockedFocus)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsLockedFocus,v)
            |> ignore

    member _.swRevisionTableTagStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRevisionTableTagStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRevisionTableTagStyle,v)
            |> ignore

    member _.swRevisionTableSymbolShape
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRevisionTableSymbolShape)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRevisionTableSymbolShape,v)
            |> ignore

    member _.swBomTableZeroQuantityDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBomTableZeroQuantityDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBomTableZeroQuantityDisplay,v)
            |> ignore

    member _.swDocumentColorFeatStructuralMember
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatStructuralMember)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatStructuralMember,v)
            |> ignore

    member _.swDocumentColorFeatGusset
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatGusset)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatGusset,v)
            |> ignore

    member _.swDocumentColorFeatEndCap
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatEndCap)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatEndCap,v)
            |> ignore

    member _.swDetailingAutoBalloonLayout
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAutoBalloonLayout)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAutoBalloonLayout,v)
            |> ignore

    member _.swDocumentColorFeatWrap
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWrap)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWrap,v)
            |> ignore

    member _.swRebuildOnActivation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRebuildOnActivation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRebuildOnActivation,v)
            |> ignore

    member _.swSystemColorsImportedAnnotation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsImportedAnnotation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsImportedAnnotation,v)
            |> ignore

    member _.swSystemColorsNonImportedAnnotation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsNonImportedAnnotation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsNonImportedAnnotation,v)
            |> ignore

    member _.swLevelOfDetail
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLevelOfDetail)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLevelOfDetail,v)
            |> ignore

    member _.swLargeAsmLevelOfDetail
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmLevelOfDetail)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmLevelOfDetail,v)
            |> ignore

    member _.swPropertyManagerColorDivider
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorDivider)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorDivider,v)
            |> ignore

    member _.swCollabCheckReadOnlyModifiedInterval
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCollabCheckReadOnlyModifiedInterval)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCollabCheckReadOnlyModifiedInterval,v)
            |> ignore

    member _.swEdrawingsSaveAsSelectionOption
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdrawingsSaveAsSelectionOption)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdrawingsSaveAsSelectionOption,v)
            |> ignore

    member _.swHoleTableOriginStandard
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHoleTableOriginStandard)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHoleTableOriginStandard,v)
            |> ignore

    member _.swHoleTableTagStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHoleTableTagStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHoleTableTagStyle,v)
            |> ignore

    member _.swHoleTableHoleLocationPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHoleTableHoleLocationPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swHoleTableHoleLocationPrecision,v)
            |> ignore

    member _.swDetailingDetailViewLabels_Name
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Name)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Name,v)
            |> ignore

    member _.swDetailingDetailViewLabels_Label
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Label)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Label,v)
            |> ignore

    member _.swDetailingDetailViewLabels_Scale
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Scale)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Scale,v)
            |> ignore

    member _.swDetailingDetailViewLabels_Delimiter
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Delimiter)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Delimiter,v)
            |> ignore

    member _.swDetailingSectionViewLabels_Name
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Name)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Name,v)
            |> ignore

    member _.swDetailingSectionViewLabels_Label
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Label)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Label,v)
            |> ignore

    member _.swDetailingSectionViewLabels_Scale
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Scale)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Scale,v)
            |> ignore

    member _.swDetailingSectionViewLabels_Delimiter
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Delimiter)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Delimiter,v)
            |> ignore

    member _.swDetailingAuxViewLabels_Name
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Name)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Name,v)
            |> ignore

    member _.swDetailingAuxViewLabels_Label
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Label)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Label,v)
            |> ignore

    member _.swDetailingAuxViewLabels_Scale
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Scale)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Scale,v)
            |> ignore

    member _.swDetailingAuxViewLabels_Delimiter
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Delimiter)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Delimiter,v)
            |> ignore

    member _.swDxfMultiSheetOption
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfMultiSheetOption)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDxfMultiSheetOption,v)
            |> ignore

    member _.swUnitsDualLinear
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinear)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinear,v)
            |> ignore

    member _.swUnitsDualLinearDecimalDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalDisplay,v)
            |> ignore

    member _.swUnitsDualLinearDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalPlaces,v)
            |> ignore

    member _.swUnitsDualLinearFractionDenominator
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinearFractionDenominator)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDualLinearFractionDenominator,v)
            |> ignore

    member _.swUnitsMassPropLength
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropLength)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropLength,v)
            |> ignore

    member _.swUnitsMassPropMass
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropMass)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropMass,v)
            |> ignore

    member _.swUnitsMassPropVolume
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropVolume)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropVolume,v)
            |> ignore

    member _.swUnitsMassPropDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsMassPropDecimalPlaces,v)
            |> ignore

    member _.swUnitsForce
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsForce)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsForce,v)
            |> ignore

    member _.swUnitSystem
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitSystem)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitSystem,v)
            |> ignore

    member _.swBendNoteStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendNoteStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendNoteStyle,v)
            |> ignore

    member _.swDetailingLeadingZero
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLeadingZero)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLeadingZero,v)
            |> ignore

    member _.swDetailingToleranceFitTolDisplayLinear
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayLinear)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayLinear,v)
            |> ignore

    member _.swDetailingToleranceFitTolDisplayAngular
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayAngular)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayAngular,v)
            |> ignore

    member _.swMaterialPropertyAreaHatchFillStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swMaterialPropertyAreaHatchFillStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swMaterialPropertyAreaHatchFillStyle,v)
            |> ignore

    member _.swDrawingAreaHatchFillStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingAreaHatchFillStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingAreaHatchFillStyle,v)
            |> ignore

    member _.swPerformanceViewsToDraftQuality
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPerformanceViewsToDraftQuality)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPerformanceViewsToDraftQuality,v)
            |> ignore

    member _.swFeatureManagerDisplayWarnings
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDisplayWarnings)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDisplayWarnings,v)
            |> ignore

    member _.swSheetMetalColorBendLinesUp
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesUp)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesUp,v)
            |> ignore

    member _.swSheetMetalColorBendLinesDown
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesDown)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesDown,v)
            |> ignore

    member _.swSheetMetalColorFormFeature
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorFormFeature)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorFormFeature,v)
            |> ignore

    member _.swSheetMetalColorBendLinesHems
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesHems)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesHems,v)
            |> ignore

    member _.swSheetMetalColorModelEdges
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorModelEdges)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorModelEdges,v)
            |> ignore

    member _.swSystemColorsDimsNotMarkedForDrawing
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDimsNotMarkedForDrawing)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDimsNotMarkedForDrawing,v)
            |> ignore

    member _.swSystemColorsAsmInterferenceVolume
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAsmInterferenceVolume)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsAsmInterferenceVolume,v)
            |> ignore

    member _.swSystemColorsSwiftAnnotations
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftAnnotations)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftAnnotations,v)
            |> ignore

    member _.swSystemColorsSwiftUnderConstrained
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftUnderConstrained)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftUnderConstrained,v)
            |> ignore

    member _.swSystemColorsSwiftFullyConstrained
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftFullyConstrained)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftFullyConstrained,v)
            |> ignore

    member _.swSystemColorsSwiftOverConstrained
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftOverConstrained)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftOverConstrained,v)
            |> ignore

    member _.swSystemColorsToleranceAnalysisDim
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsToleranceAnalysisDim)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsToleranceAnalysisDim,v)
            |> ignore

    member _.swSystemColorsPropertyManagerColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsPropertyManagerColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsPropertyManagerColor,v)
            |> ignore

    member _.swPropertyManagerColorBackground
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorBackground)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorBackground,v)
            |> ignore

    member _.swPropertyManagerColorActiveClosedDivider
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorActiveClosedDivider)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorActiveClosedDivider,v)
            |> ignore

    member _.swPropertyManagerColorEditBox
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditBox)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditBox,v)
            |> ignore

    member _.swPropertyManagerColorEditText
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditText)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditText,v)
            |> ignore

    member _.swPropertyManagerColorLabelAndIcon
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorLabelAndIcon)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorLabelAndIcon,v)
            |> ignore

    member _.swPropertyManagerColorTitle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTitle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTitle,v)
            |> ignore

    member _.swPropertyManagerColorOuterBorder
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorOuterBorder)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorOuterBorder,v)
            |> ignore

    member _.swPropertyManagerColorInnerBorder
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorInnerBorder)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorInnerBorder,v)
            |> ignore

    member _.swPropertyManagerColorTopBorder
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTopBorder)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTopBorder,v)
            |> ignore

    member _.swPropertyManagerColorImportantMessage
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorImportantMessage)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyManagerColorImportantMessage,v)
            |> ignore

    member _.swSystemColorsHiddenEdgeSelectionShow
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsHiddenEdgeSelectionShow)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsHiddenEdgeSelectionShow,v)
            |> ignore

    member _.swDetailingForeshortenedDiameterStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingForeshortenedDiameterStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingForeshortenedDiameterStyle,v)
            |> ignore

    member _.swRevisionTableMultipleSheetStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRevisionTableMultipleSheetStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRevisionTableMultipleSheetStyle,v)
            |> ignore

    member _.swUndoStepsMaximum
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUndoStepsMaximum)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUndoStepsMaximum,v)
            |> ignore

    member _.swDetailingDimFractionStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimFractionStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimFractionStyle,v)
            |> ignore

    member _.swDetailingDimFractionScaleIndex
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimFractionScaleIndex)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimFractionScaleIndex,v)
            |> ignore

    member _.swAutoSaveIntervalMode
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAutoSaveIntervalMode)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAutoSaveIntervalMode,v)
            |> ignore

    member _.swBackupRemoveInterval
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBackupRemoveInterval)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBackupRemoveInterval,v)
            |> ignore

    member _.swSaveReminderInterval
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveReminderInterval)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveReminderInterval,v)
            |> ignore

    member _.swSaveReminderIntervalMode
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveReminderIntervalMode)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveReminderIntervalMode,v)
            |> ignore

    member _.swColorsBackgroundAppearance
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swColorsBackgroundAppearance)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swColorsBackgroundAppearance,v)
            |> ignore

    member _.swRebuildErrorAction
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRebuildErrorAction)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRebuildErrorAction,v)
            |> ignore

    member _.swSheetMetalColorFlatPatternSketch
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorFlatPatternSketch)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorFlatPatternSketch,v)
            |> ignore

    member _.swLineFontVisibleEdgesEndCap
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesEndCap)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesEndCap,v)
            |> ignore

    member _.swLineFontHiddenEdgesEndCap
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesEndCap)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesEndCap,v)
            |> ignore

    member _.swLineFontSketchCurvesEndCap
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesEndCap)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesEndCap,v)
            |> ignore

    member _.swDetailingDimXpertChamferScheme
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferScheme)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferScheme,v)
            |> ignore

    member _.swDetailingDimXpertSlotScheme
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertSlotScheme)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertSlotScheme,v)
            |> ignore

    member _.swDetailingDimXpertFilletOptions
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertFilletOptions)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertFilletOptions,v)
            |> ignore

    member _.swDetailingDimXpertChamferOptions
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferOptions)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferOptions,v)
            |> ignore

    member _.swSystemColorsGhostSelColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsGhostSelColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsGhostSelColor,v)
            |> ignore

    member _.swFeatureManagerBlocksVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerBlocksVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerBlocksVisibility,v)
            |> ignore

    member _.swFeatureManagerDesignBinderVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignBinderVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignBinderVisibility,v)
            |> ignore

    member _.swFeatureManagerAnnotationsVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerAnnotationsVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerAnnotationsVisibility,v)
            |> ignore

    member _.swFeatureManagerLightsVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerLightsVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerLightsVisibility,v)
            |> ignore

    member _.swFeatureManagerSolidBodiesVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSolidBodiesVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSolidBodiesVisibility,v)
            |> ignore

    member _.swFeatureManagerSurfaceBodiesVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSurfaceBodiesVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSurfaceBodiesVisibility,v)
            |> ignore

    member _.swFeatureManagerEquationsVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerEquationsVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerEquationsVisibility,v)
            |> ignore

    member _.swFeatureManagerMaterialVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMaterialVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMaterialVisibility,v)
            |> ignore

    member _.swFeatureManagerDefaultPlanesVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDefaultPlanesVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDefaultPlanesVisibility,v)
            |> ignore

    member _.swFeatureManagerOriginVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerOriginVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerOriginVisibility,v)
            |> ignore

    member _.swFeatureManagerMateReferencesVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMateReferencesVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMateReferencesVisibility,v)
            |> ignore

    member _.swFeatureManagerDesignTableVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignTableVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignTableVisibility,v)
            |> ignore

    member _.swSearchResultsPerPage
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchResultsPerPage)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchResultsPerPage,v)
            |> ignore

    member _.swSearchMaxResultsPerDataSource
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchMaxResultsPerDataSource)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchMaxResultsPerDataSource,v)
            |> ignore

    member _.swUnitsForceDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsForceDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsForceDecimalPlaces,v)
            |> ignore

    member _.swUnitsEnergyUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsEnergyUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsEnergyUnits,v)
            |> ignore

    member _.swUnitsEnergyDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsEnergyDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsEnergyDecimalPlaces,v)
            |> ignore

    member _.swUnitsPowerUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsPowerUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsPowerUnits,v)
            |> ignore

    member _.swUnitsPowerDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsPowerDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsPowerDecimalPlaces,v)
            |> ignore

    member _.swUnitsTimeUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsTimeUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsTimeUnits,v)
            |> ignore

    member _.swUnitsTimeDecimalPlaces
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsTimeDecimalPlaces)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsTimeDecimalPlaces,v)
            |> ignore

    member _.swSystemColorsInactiveHandles
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveHandles)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveHandles,v)
            |> ignore

    member _.swPropertyMgrDockingState
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyMgrDockingState)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPropertyMgrDockingState,v)
            |> ignore

    member _.swDetailingBalloonLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderStyle,v)
            |> ignore

    member _.swDetailingBalloonLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineStyle,v)
            |> ignore

    member _.swDetailingBalloonLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineThickness,v)
            |> ignore

    member _.swDetailingBalloonFrameLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineStyle,v)
            |> ignore

    member _.swDetailingBalloonFrameLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineThickness,v)
            |> ignore

    member _.swDetailingDatumLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineStyle,v)
            |> ignore

    member _.swDetailingDatumLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineThickness,v)
            |> ignore

    member _.swDetailingDatumFrameLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineStyle,v)
            |> ignore

    member _.swDetailingDatumFrameLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineThickness,v)
            |> ignore

    member _.swDetailingGtolLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderStyle,v)
            |> ignore

    member _.swDetailingGtolLeaderSide
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderSide)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderSide,v)
            |> ignore

    member _.swDetailingGtolLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineStyle,v)
            |> ignore

    member _.swDetailingGtolLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineThickness,v)
            |> ignore

    member _.swDetailingGtolFrameLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineStyle,v)
            |> ignore

    member _.swDetailingGtolFrameLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineThickness,v)
            |> ignore

    member _.swDetailingNoteLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineStyle,v)
            |> ignore

    member _.swDetailingNoteLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineThickness,v)
            |> ignore

    member _.swDetailingSFSymbolLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderStyle,v)
            |> ignore

    member _.swDetailingSFSymbolLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineStyle,v)
            |> ignore

    member _.swDetailingSFSymbolLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineThickness,v)
            |> ignore

    member _.swDetailingWeldSymbolLeaderSide
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderSide)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderSide,v)
            |> ignore

    member _.swDetailingWeldSymbolLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineStyle,v)
            |> ignore

    member _.swDetailingWeldSymbolLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineThickness,v)
            |> ignore

    member _.swDetailingGeneralTableBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableBorderLineWeight,v)
            |> ignore

    member _.swDetailingGeneralTableGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableGridLineWeight,v)
            |> ignore

    member _.swDetailingBillOfMaterialBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialBorderLineWeight,v)
            |> ignore

    member _.swDetailingBillOfMaterialGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialGridLineWeight,v)
            |> ignore

    member _.swDetailingHoleTableBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingHoleTableBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingHoleTableBorderLineWeight,v)
            |> ignore

    member _.swDetailingHoleTableGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingHoleTableGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingHoleTableGridLineWeight,v)
            |> ignore

    member _.swDetailingRevisionTableBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableBorderLineWeight,v)
            |> ignore

    member _.swDetailingRevisionTableGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableGridLineWeight,v)
            |> ignore

    member _.swDetailingDimensionTextAndLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAndLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAndLeaderStyle,v)
            |> ignore

    member _.swDetailingToleranceStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceStyle,v)
            |> ignore

    member _.swDetailingToleranceFitTolDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplay,v)
            |> ignore

    member _.swFeatureManagerSensorVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSensorVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSensorVisibility,v)
            |> ignore

    member _.swFeatureManagerTableFolderVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerTableFolderVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerTableFolderVisibility,v)
            |> ignore

    member _.swSystemColorsDrawingsSpeedPakModelEdge
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSpeedPakModelEdge)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSpeedPakModelEdge,v)
            |> ignore

    member _.swFeatureManagerConfigTableFolderVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerConfigTableFolderVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerConfigTableFolderVisibility,v)
            |> ignore

    member _.swDetailingDatumGbLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumGbLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingDatumGbLeaderStyle,v)
            |> ignore

    member _.swDetailingTitleBlockTableBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableBorderLineWeight,v)
            |> ignore

    member _.swDetailingTitleBlockTableGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableGridLineWeight,v)
            |> ignore

    member _.swExportVrmlVersion
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportVrmlVersion)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportVrmlVersion,v)
            |> ignore

    member _.swExportJpegCompression
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportJpegCompression)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportJpegCompression,v)
            |> ignore

    member _.swSystemColorsDrawingsModelTangentEdges
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsModelTangentEdges)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsModelTangentEdges,v)
            |> ignore

    member _.swSystemColorsMateCalloutHealthy
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutHealthy)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutHealthy,v)
            |> ignore

    member _.swSystemColorsMateCalloutWarning
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutWarning)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutWarning,v)
            |> ignore

    member _.swSystemColorsMateCalloutError
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutError)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutError,v)
            |> ignore

    member _.swCenterLineMarkOrient
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCenterLineMarkOrient)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCenterLineMarkOrient,v)
            |> ignore

    member _.swLineFontSpeedPakDrawingsModelEdgesThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesThickness,v)
            |> ignore

    member _.swLineFontSpeedPakDrawingsModelEdgesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesStyle,v)
            |> ignore

    member _.swDisplayStateCreationChoice
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDisplayStateCreationChoice)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDisplayStateCreationChoice,v)
            |> ignore

    member _.swSystemColorsSheetMetalTemporaryGraphics
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSheetMetalTemporaryGraphics)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSheetMetalTemporaryGraphics,v)
            |> ignore

    member _.swSystemColorsMeasureSelection
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMeasureSelection)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsMeasureSelection,v)
            |> ignore

    member _.swPartDimXpertLengthUnitTol1Decimals
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol1Decimals)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol1Decimals,v)
            |> ignore

    member _.swPartDimXpertLengthUnitTol2Decimals
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol2Decimals)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol2Decimals,v)
            |> ignore

    member _.swPartDimXpertLengthUnitTol3Decimals
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol3Decimals)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol3Decimals,v)
            |> ignore

    member _.swPartDimXpertGeneralToleranceClass
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertGeneralToleranceClass)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertGeneralToleranceClass,v)
            |> ignore

    member _.swPartDimXpertLocationDistanceTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceTolType,v)
            |> ignore

    member _.swPartDimXpertLocationAngleTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleTolType,v)
            |> ignore

    member _.swPartDimXpertLocationDistanceBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertLocationAngleBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertChainPatternLocTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocTolType,v)
            |> ignore

    member _.swPartDimXpertChainInnerTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainInnerTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainInnerTolType,v)
            |> ignore

    member _.swPartDimXpertChainPatternLocBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertChainDistanceBwtnFeatBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainDistanceBwtnFeatBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChainDistanceBwtnFeatBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertChamferDistanceTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceTolType,v)
            |> ignore

    member _.swPartDimXpertChamferAngleTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleTolType,v)
            |> ignore

    member _.swPartDimXpertChamferDistanceBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertChamferAngleBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertSizeDiameterTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterTolType,v)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterTolType,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterTolType,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleTolType,v)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotTolType,v)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotTolType,v)
            |> ignore

    member _.swPartDimXpertSizeDepthTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthTolType,v)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusTolType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusTolType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusTolType,v)
            |> ignore

    member _.swPartDimXpertSizeDiameterBlockPrecsion
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterBlockPrecsion)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterBlockPrecsion,v)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterBlockPrecsion
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterBlockPrecsion)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterBlockPrecsion,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterBlockPrecsion
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterBlockPrecsion)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterBlockPrecsion,v)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertSizeDepthBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusBlockPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusBlockPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusBlockPrecision,v)
            |> ignore

    member _.swPartDimXpertDisplaySlotDimensionType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplaySlotDimensionType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplaySlotDimensionType,v)
            |> ignore

    member _.swPartDimXpertDisplayHoleDimensionType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayHoleDimensionType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayHoleDimensionType,v)
            |> ignore

    member _.swPartDimXpertDisplayGtolLinearDimAttachment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayGtolLinearDimAttachment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayGtolLinearDimAttachment,v)
            |> ignore

    member _.swPartDimXpertDisplayDatumGtolSurfaceAttachment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolSurfaceAttachment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolSurfaceAttachment,v)
            |> ignore

    member _.swPartDimXpertDisplayDatumGtolLinearDimAttachment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolLinearDimAttachment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolLinearDimAttachment,v)
            |> ignore

    member _.swExportIFCUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportIFCUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportIFCUnits,v)
            |> ignore

    member _.swDetailingOrthoViewLabels_Scale
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Scale)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Scale,v)
            |> ignore

    member _.swDetailingOrthoViewLabels_Delimiter
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Delimiter)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Delimiter,v)
            |> ignore

    member _.swSystemOptionDisplayAntiAliasing
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemOptionDisplayAntiAliasing)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemOptionDisplayAntiAliasing,v)
            |> ignore

    member _.swTableHoleDualDimensionPos
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTableHoleDualDimensionPos)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTableHoleDualDimensionPos,v)
            |> ignore

    member _.swSystemColorsDrawingsChangedDimensions
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsChangedDimensions)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsChangedDimensions,v)
            |> ignore

    member _.swDetailingBendTableBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBendTableBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBendTableBorderLineWeight,v)
            |> ignore

    member _.swDetailingBendTableGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBendTableGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBendTableGridLineWeight,v)
            |> ignore

    member _.swBendLeadingZero
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendLeadingZero)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendLeadingZero,v)
            |> ignore

    member _.swBendTableZeroQuantityDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendTableZeroQuantityDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendTableZeroQuantityDisplay,v)
            |> ignore

    member _.swBendInnerRadiusPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendInnerRadiusPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendInnerRadiusPrecision,v)
            |> ignore

    member _.swBendAngularPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendAngularPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendAngularPrecision,v)
            |> ignore

    member _.swBendTableTagStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendTableTagStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendTableTagStyle,v)
            |> ignore

    member _.swPunchTableOriginStandard
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPunchTableOriginStandard)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPunchTableOriginStandard,v)
            |> ignore

    member _.swPunchTableLocationPrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPunchTableLocationPrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPunchTableLocationPrecision,v)
            |> ignore

    member _.swTablePunchDualDimensionPos
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTablePunchDualDimensionPos)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTablePunchDualDimensionPos,v)
            |> ignore

    member _.swPunchTableTagStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPunchTableTagStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPunchTableTagStyle,v)
            |> ignore

    member _.swDetailingSectionArrowStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionArrowStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionArrowStyle,v)
            |> ignore

    member _.swPerformanceFeedback
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPerformanceFeedback)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPerformanceFeedback,v)
            |> ignore

    member _.swLineFontAdjoiningComponent
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponent)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponent,v)
            |> ignore

    member _.swLineFontAdjoiningComponentStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponentStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponentStyle,v)
            |> ignore

    member _.swSystemColorsNoteHandle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsNoteHandle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsNoteHandle,v)
            |> ignore

    member _.swSystemColorsCrossHair
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsCrossHair)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsCrossHair,v)
            |> ignore

    member _.swSystemColorsNoteEditHandle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsNoteEditHandle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsNoteEditHandle,v)
            |> ignore

    member _.swSystemColorsTemporarySketchDragging
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTemporarySketchDragging)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsTemporarySketchDragging,v)
            |> ignore

    member _.swSystemColorsWeldPathSelection
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsWeldPathSelection)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsWeldPathSelection,v)
            |> ignore

    member _.swDetailingPunchTableBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingPunchTableBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingPunchTableBorderLineWeight,v)
            |> ignore

    member _.swShowEquationCircularReferencesMessage
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swShowEquationCircularReferencesMessage)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swShowEquationCircularReferencesMessage,v)
            |> ignore

    member _.swDetailingPunchTableGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingPunchTableGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingPunchTableGridLineWeight,v)
            |> ignore

    member _.swDetailingWeldTableGridLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldTableGridLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldTableGridLineWeight,v)
            |> ignore

    member _.swDetailingWeldTableBorderLineWeight
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldTableBorderLineWeight)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingWeldTableBorderLineWeight,v)
            |> ignore

    member _.swSearchIndexingPerformance
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchIndexingPerformance)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchIndexingPerformance,v)
            |> ignore

    member _.swLargeAsmModeLargeDesignReviewThreshhold
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeLargeDesignReviewThreshhold)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLargeAsmModeLargeDesignReviewThreshhold,v)
            |> ignore

    member _.swShowEquationPotentialCircularReferencesMessage
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swShowEquationPotentialCircularReferencesMessage)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swShowEquationPotentialCircularReferencesMessage,v)
            |> ignore

    member _.swSaveReminderAutoDismissInterval
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveReminderAutoDismissInterval)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveReminderAutoDismissInterval,v)
            |> ignore

    member _.swDetailingRevisionCloudLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineStyle,v)
            |> ignore

    member _.swDetailingRevisionCloudLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineThickness,v)
            |> ignore

    member _.swDetailingHalfSectionArrow
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingHalfSectionArrow)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingHalfSectionArrow,v)
            |> ignore

    member _.swBendAllowancePrecision
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendAllowancePrecision)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBendAllowancePrecision,v)
            |> ignore

    member _.swFeatureManagerFavorites
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerFavorites)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerFavorites,v)
            |> ignore

    member _.swFeatureManagerEDrawingMarkups
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerEDrawingMarkups)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerEDrawingMarkups,v)
            |> ignore

    member _.swSheetMetalColorBoundingBox
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBoundingBox)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalColorBoundingBox,v)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineStyle,v)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineThickness,v)
            |> ignore

    member _.swSheetMetalBendNotesBorderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderStyle,v)
            |> ignore

    member _.swSheetMetalBendNotesBorderSize
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderSize)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderSize,v)
            |> ignore

    member _.swSheetMetalBendNotesTextAlignment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesTextAlignment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesTextAlignment,v)
            |> ignore

    member _.swSheetMetalBendNotesLeaderAnchor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderAnchor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderAnchor,v)
            |> ignore

    member _.swSheetMetalBendNotesLeaderDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderDisplay,v)
            |> ignore

    member _.swSystemColorsCurrentColorScheme
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsCurrentColorScheme)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsCurrentColorScheme,v)
            |> ignore

    member _.swSystemColorsEnvelopes
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsEnvelopes)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsEnvelopes,v)
            |> ignore

    member _.swDetailingRadialDimsArrowPlacement
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRadialDimsArrowPlacement)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingRadialDimsArrowPlacement,v)
            |> ignore

    member _.swSearchDissectionDailyStartTime
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStartTime)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStartTime,v)
            |> ignore

    member _.swSearchDissectionDailyStopTime
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStopTime)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStopTime,v)
            |> ignore

    member _.swLineFontBendLineUpStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpStyle,v)
            |> ignore

    member _.swLineFontBendLineDownStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownStyle,v)
            |> ignore

    member _.swLineFontEnvelopeComponentStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentStyle,v)
            |> ignore

    member _.swLineFontBendLineUpThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpThickness,v)
            |> ignore

    member _.swLineFontBendLineDownThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownThickness,v)
            |> ignore

    member _.swLineFontEnvelopeComponentThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentThickness,v)
            |> ignore

    member _.swEnvelopeComponentColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEnvelopeComponentColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEnvelopeComponentColor,v)
            |> ignore

    member _.swAssemblyVisualizationComponentColor1
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor1)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor1,v)
            |> ignore

    member _.swAssemblyVisualizationComponentColor2
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor2)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor2,v)
            |> ignore

    member _.swAssemblyVisualizationComponentColor3
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor3)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor3,v)
            |> ignore

    member _.swAssemblyVisualizationComponentColor4
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor4)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor4,v)
            |> ignore

    member _.swAssemblyVisualizationComponentColor5
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor5)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor5,v)
            |> ignore

    member _.swAssemblyVisualizationComponentColor6
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor6)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor6,v)
            |> ignore

    member _.swDetailingMiscView_Scale
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Scale)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Scale,v)
            |> ignore

    member _.swDetailingMiscView_Delimiter
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Delimiter)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Delimiter,v)
            |> ignore

    member _.swDetailingMiscView_Name
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Name)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Name,v)
            |> ignore

    member _.swDetailingAuxView_ViewIndication
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxView_ViewIndication)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxView_ViewIndication,v)
            |> ignore

    member _.swDetailingAuxView_Rotation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxView_Rotation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAuxView_Rotation,v)
            |> ignore

    member _.swDetailingSectionView_Rotation
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionView_Rotation)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionView_Rotation,v)
            |> ignore

    member _.swDimensionsExtensionLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyle,v)
            |> ignore

    member _.swDimensionsExtensionLineStyleThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyleThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyleThickness,v)
            |> ignore

    member _.swDetailingOrthoView_Name
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingOrthoView_Name)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingOrthoView_Name,v)
            |> ignore

    member _.swAssemblyOpenMessagesDismissTime
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyOpenMessagesDismissTime)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyOpenMessagesDismissTime,v)
            |> ignore

    member _.swButtonSize
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swButtonSize)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swButtonSize,v)
            |> ignore

    member _.swTextSize
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTextSize)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTextSize,v)
            |> ignore

    member _.swUnitsDecimalRounding
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDecimalRounding)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUnitsDecimalRounding,v)
            |> ignore

    member _.swDetailingLocationLabelFrameLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineStyle,v)
            |> ignore

    member _.swDetailingLocationLabelFrameLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineThickness,v)
            |> ignore

    member _.swDetailingLocationLabelStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelStyle,v)
            |> ignore

    member _.swDetailingLocationLabelFit
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFit)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFit,v)
            |> ignore

    member _.swDetailingLocationLabelUpperText
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelUpperText)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelUpperText,v)
            |> ignore

    member _.swDetailingLocationLabelLowerText
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelLowerText)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelLowerText,v)
            |> ignore

    member _.swDrawingSheetsZonesOrigin
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesOrigin)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesOrigin,v)
            |> ignore

    member _.swDrawingSheetsZonesLetterLayout
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesLetterLayout)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesLetterLayout,v)
            |> ignore

    member _.swDetailingBalloonAutoBalloons
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonAutoBalloons)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBalloonAutoBalloons,v)
            |> ignore

    member _.swFeatureManagerSelectionSetsVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSelectionSetsVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerSelectionSetsVisibility,v)
            |> ignore

    member _.swFeatureManagerHistory
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerHistory)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerHistory,v)
            |> ignore

    member _.swPDFExportShadedDraftDPI
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPDFExportShadedDraftDPI)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPDFExportShadedDraftDPI,v)
            |> ignore

    member _.swPDFExportOleDPI
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPDFExportOleDPI)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPDFExportOleDPI,v)
            |> ignore

    member _.swTwistCountValue
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTwistCountValue)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTwistCountValue,v)
            |> ignore

    member _.swManipConnectionPointColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swManipConnectionPointColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swManipConnectionPointColor,v)
            |> ignore

    member _.swRefVisualizationParentColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRefVisualizationParentColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRefVisualizationParentColor,v)
            |> ignore

    member _.swRefVisualizationChildrenColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRefVisualizationChildrenColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swRefVisualizationChildrenColor,v)
            |> ignore

    member _.swDrawingSheetCustomPropSheetNo
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingSheetCustomPropSheetNo)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawingSheetCustomPropSheetNo,v)
            |> ignore

    member _.swIFCExportSaveType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIFCExportSaveType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIFCExportSaveType,v)
            |> ignore

    member _.swDetailingSectionViewLineStyleDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLineStyleDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLineStyleDisplay,v)
            |> ignore

    member _.swSaveIFCFormat
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveIFCFormat)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSaveIFCFormat,v)
            |> ignore

    member _.swDetailingLinearForeshortened
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearForeshortened)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingLinearForeshortened,v)
            |> ignore

    member _.swCartoonEdgeThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCartoonEdgeThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCartoonEdgeThickness,v)
            |> ignore

    member _.swTempGraphicsAddMaterialColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTempGraphicsAddMaterialColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTempGraphicsAddMaterialColor,v)
            |> ignore

    member _.swTempGraphicsRemoveMaterialColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTempGraphicsRemoveMaterialColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swTempGraphicsRemoveMaterialColor,v)
            |> ignore

    member _.swDetailingBorderLeaderLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineStyle,v)
            |> ignore

    member _.swDetailingBorderLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineThickness,v)
            |> ignore

    member _.swDetailingBorderZoneDividerLineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineStyle,v)
            |> ignore

    member _.swDetailingBorderZoneDividerLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineThickness,v)
            |> ignore

    member _.swIFCOmniUniClassPreference
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIFCOmniUniClassPreference)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swIFCOmniUniClassPreference,v)
            |> ignore

    member _.swSystemColorsIconColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsIconColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsIconColor,v)
            |> ignore

    member _.swSystemColorsBackground
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsBackground)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsBackground,v)
            |> ignore

    member _.swShadedSketchContourColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swShadedSketchContourColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swShadedSketchContourColor,v)
            |> ignore

    member _.sw3DPDFAccuracy
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.sw3DPDFAccuracy)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.sw3DPDFAccuracy,v)
            |> ignore

    member _.swLineFontEmphasizedSectionOutlineStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionOutlineStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionOutlineStyle,v)
            |> ignore

    member _.swLineFontEmphasizedSectionThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionThickness,v)
            |> ignore

    member _.swLineFontEmphasizedSectionEndCapStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionEndCapStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionEndCapStyle,v)
            |> ignore

    member _.swBasicDimType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBasicDimType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBasicDimType,v)
            |> ignore

    member _.swPolarMinHoles
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPolarMinHoles)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPolarMinHoles,v)
            |> ignore

    member _.swGraphicsTreeItemNormalColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGraphicsTreeItemNormalColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGraphicsTreeItemNormalColor,v)
            |> ignore

    member _.swZoneLineColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swZoneLineColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swZoneLineColor,v)
            |> ignore

    member _.swSketch_Auto_Solve_Threshold
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSketch_Auto_Solve_Threshold)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSketch_Auto_Solve_Threshold,v)
            |> ignore

    member _.swDrawing_Auto_Solve_Threshold
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawing_Auto_Solve_Threshold)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDrawing_Auto_Solve_Threshold,v)
            |> ignore

    member _.swPenSketchStrokeThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPenSketchStrokeThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPenSketchStrokeThickness,v)
            |> ignore

    member _.swPenSketchStrokeColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPenSketchStrokeColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPenSketchStrokeColor,v)
            |> ignore

    member _.swMatesDefaultMisalignedType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swMatesDefaultMisalignedType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swMatesDefaultMisalignedType,v)
            |> ignore

    member _.swUpdateOutOfDateSpeedPakConfigOnSave
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUpdateOutOfDateSpeedPakConfigOnSave)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swUpdateOutOfDateSpeedPakConfigOnSave,v)
            |> ignore

    member _.swFeatureManagerMeshBodiesVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMeshBodiesVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMeshBodiesVisibility,v)
            |> ignore

    member _.swSolidBodiesDescriptionFirstPropertyIndex
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionFirstPropertyIndex)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionFirstPropertyIndex,v)
            |> ignore

    member _.swSolidBodiesDescriptionSecondPropertyIndex
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionSecondPropertyIndex)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionSecondPropertyIndex,v)
            |> ignore

    member _.swSolidBodiesDescriptionThirdPropertyIndex
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionThirdPropertyIndex)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionThirdPropertyIndex,v)
            |> ignore

    member _.swDefaultConfigSortOrder
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDefaultConfigSortOrder)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDefaultConfigSortOrder,v)
            |> ignore

    member _.swGraphicalAnnotationsColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGraphicalAnnotationsColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGraphicalAnnotationsColor,v)
            |> ignore

    member _.swImportNeutral_KnitOption
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutral_KnitOption)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutral_KnitOption,v)
            |> ignore

    member _.swImportNeutral_CurvesAndPointsOption
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutral_CurvesAndPointsOption)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutral_CurvesAndPointsOption,v)
            |> ignore

    member _.swImportNeutralAssemblyStructureMapping
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutralAssemblyStructureMapping)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutralAssemblyStructureMapping,v)
            |> ignore

    member _.swImportNeutralUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutralUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swImportNeutralUnits,v)
            |> ignore

    member _.swBBoxDescriptionApplyMethod
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBBoxDescriptionApplyMethod)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBBoxDescriptionApplyMethod,v)
            |> ignore

    member _.swDetailingTrailingZeroTolerance
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroTolerance)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroTolerance,v)
            |> ignore

    member _.swDetailingTrailingZeroProperties
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroProperties)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroProperties,v)
            |> ignore

    member _.swDetailingAngleTrailingZero
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZero)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZero,v)
            |> ignore

    member _.swDetailingAngleTrailingZeroTolerance
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZeroTolerance)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZeroTolerance,v)
            |> ignore

    member _.swDetailingAngularRunningTrailingZero
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZero)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZero,v)
            |> ignore

    member _.swDetailingAngularRunningTrailingZeroTolerance
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZeroTolerance)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZeroTolerance,v)
            |> ignore

    member _.swEdrawingsAttachmentOption
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentOption)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentOption,v)
            |> ignore

    member _.swEdrawingsAttachmentType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentType,v)
            |> ignore

    member _.swExportPlyUnits
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportPlyUnits)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swExportPlyUnits,v)
            |> ignore

    member _.swPLYQuality
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPLYQuality)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swPLYQuality,v)
            |> ignore

    member _.swMaximumRecentDocuments
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swMaximumRecentDocuments)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swMaximumRecentDocuments,v)
            |> ignore

    member _.swFlatPatternColorsBendLinesUpDirection
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesUpDirection)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesUpDirection,v)
            |> ignore

    member _.swFlatPatternColorsBendLinesDownDirection
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesDownDirection)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesDownDirection,v)
            |> ignore

    member _.swFlatPatternColorsFromFeature
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFromFeature)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFromFeature,v)
            |> ignore

    member _.swFlatPatternColorsBendLinesHems
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesHems)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesHems,v)
            |> ignore

    member _.swFlatPatternColorsModelEdges
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsModelEdges)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsModelEdges,v)
            |> ignore

    member _.swFlatPatternColorsFlatPatternSketchColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFlatPatternSketchColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFlatPatternSketchColor,v)
            |> ignore

    member _.swFlatPatternColorsBoundingBox
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBoundingBox)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBoundingBox,v)
            |> ignore

    member _.swSheetMetalMBDBendNotesStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBendNotesStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBendNotesStyle,v)
            |> ignore

    member _.swSheetMetalMBDLeaderStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderStyle,v)
            |> ignore

    member _.swSheetMetalMBDLeaderLineThickness
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderLineThickness)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderLineThickness,v)
            |> ignore

    member _.swSheetMetalMBDTextAlignment
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDTextAlignment)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDTextAlignment,v)
            |> ignore

    member _.swSheetMetalMBDLeaderAnchor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderAnchor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderAnchor,v)
            |> ignore

    member _.swSheetMetalMBDLeaderDisplay
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderDisplay)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderDisplay,v)
            |> ignore

    member _.swSheetMetalMBDBalloonStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBalloonStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBalloonStyle,v)
            |> ignore

    member _.swSheetMetalMBDFit
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDFit)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDFit,v)
            |> ignore

    member _.swSheetMetalMBDLineStyle_BendLinesUp
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesUp)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesUp,v)
            |> ignore

    member _.swSheetMetalMBDLineStyle_BendLinesDown
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesDown)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesDown,v)
            |> ignore

    member _.swFeatureManagerMarkupsVisibility
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMarkupsVisibility)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerMarkupsVisibility,v)
            |> ignore

    member _.swEnableAutoMateFlip
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEnableAutoMateFlip)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swEnableAutoMateFlip,v)
            |> ignore

    member _.swSystemColorsSelectedItem5
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem5)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem5,v)
            |> ignore

    member _.swSystemColorsSelectedItem6
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem6)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem6,v)
            |> ignore

    member _.swFeatureManagerTranslatedLanguage
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerTranslatedLanguage)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swFeatureManagerTranslatedLanguage,v)
            |> ignore

    member _.swAssemblyLoadComponents
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyLoadComponents)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swAssemblyLoadComponents,v)
            |> ignore

    member _.swConfigurationViewForFeatureManagerTree
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swConfigurationViewForFeatureManagerTree)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swConfigurationViewForFeatureManagerTree,v)
            |> ignore

    member _.swDetailingGtolMaterialConditionSymbolPlacement
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolMaterialConditionSymbolPlacement)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDetailingGtolMaterialConditionSymbolPlacement,v)
            |> ignore

    member _.swBomOverriddenCellValueColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBomOverriddenCellValueColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swBomOverriddenCellValueColor,v)
            |> ignore

    member _.swSheetPrintQuadrant
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetPrintQuadrant)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSheetPrintQuadrant,v)
            |> ignore

    member _.swSketchExplodedColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSketchExplodedColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSketchExplodedColor,v)
            |> ignore

    member _.swDefaultBOMPartNumberForNewConfig
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDefaultBOMPartNumberForNewConfig)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDefaultBOMPartNumberForNewConfig,v)
            |> ignore

    member _.swDimOverriddenCellValueColor
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDimOverriddenCellValueColor)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swDimOverriddenCellValueColor,v)
            |> ignore

    member _.swOppHandMirrorComp
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swOppHandMirrorComp)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swOppHandMirrorComp,v)
            |> ignore

    member _.swGtolDecimalSeparatorType
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGtolDecimalSeparatorType)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swGtolDecimalSeparatorType,v)
            |> ignore

    member _.swCollinearChainDimensionArrowHeadTerminationStyle
        with get () =
            swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCollinearChainDimensionArrowHeadTerminationStyle)
        and set v =
            swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swCollinearChainDimensionArrowHeadTerminationStyle,v)
            |> ignore

    member _.swFileLocationsDocuments
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDocuments)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDocuments,v)
            |> ignore

    member _.swFileLocationsPaletteFeatures
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteFeatures)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteFeatures,v)
            |> ignore

    member _.swFileLocationsPaletteParts
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteParts)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteParts,v)
            |> ignore

    member _.swFileLocationsPaletteFormTools
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteFormTools)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteFormTools,v)
            |> ignore

    member _.swFileLocationsBlocks
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBlocks)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBlocks,v)
            |> ignore

    member _.swFileLocationsDocumentTemplates
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDocumentTemplates)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDocumentTemplates,v)
            |> ignore

    member _.swFileLocationsSheetFormat
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSheetFormat)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSheetFormat,v)
            |> ignore

    member _.swDefaultTemplatePart
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplatePart)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplatePart,v)
            |> ignore

    member _.swDefaultTemplateAssembly
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplateAssembly)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplateAssembly,v)
            |> ignore

    member _.swDefaultTemplateDrawing
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplateDrawing)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplateDrawing,v)
            |> ignore

    member _.swBackupDirectory
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBackupDirectory)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBackupDirectory,v)
            |> ignore

    member _.swFileLocationsBendTable
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendTable)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendTable,v)
            |> ignore

    member _.swMaterialPropertyCrosshatchPattern
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swMaterialPropertyCrosshatchPattern)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swMaterialPropertyCrosshatchPattern,v)
            |> ignore

    member _.swDrawingAreaHatchPattern
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDrawingAreaHatchPattern)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDrawingAreaHatchPattern,v)
            |> ignore

    member _.swDetailingNextDatumFeatureLabel
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingNextDatumFeatureLabel)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingNextDatumFeatureLabel,v)
            |> ignore

    member _.swFileSaveAsCoordinateSystem
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileSaveAsCoordinateSystem)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileSaveAsCoordinateSystem,v)
            |> ignore

    member _.swFileLocationsPaletteAssemblies
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteAssemblies)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPaletteAssemblies,v)
            |> ignore

    member _.swCustomPropertyUsedAsComponentDescription
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swCustomPropertyUsedAsComponentDescription)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swCustomPropertyUsedAsComponentDescription,v)
            |> ignore

    member _.swFileLocationsLibraryFeatures
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsLibraryFeatures)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsLibraryFeatures,v)
            |> ignore

    member _.swFileLocationsMacroFeatures
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsMacroFeatures)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsMacroFeatures,v)
            |> ignore

    member _.swFileLocationsWebFolders
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWebFolders)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWebFolders,v)
            |> ignore

    member _.swFileLocationsBOMTemplates
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBOMTemplates)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBOMTemplates,v)
            |> ignore

    member _.swFileLocationsMacros
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsMacros)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsMacros,v)
            |> ignore

    member _.swFileLocationsJournalFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsJournalFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsJournalFile,v)
            |> ignore

    member _.swFileLocationsCustomPropertyFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomPropertyFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomPropertyFile,v)
            |> ignore

    member _.swFileLocationsHoleCalloutFormatFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHoleCalloutFormatFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHoleCalloutFormatFile,v)
            |> ignore

    member _.swFileLocationsDimensionFavorites
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDimensionFavorites)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDimensionFavorites,v)
            |> ignore

    member _.swFileLocationsMaterialDatabases
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsMaterialDatabases)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsMaterialDatabases,v)
            |> ignore

    member _.swFileLocationsWeldmentProfiles
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldmentProfiles)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldmentProfiles,v)
            |> ignore

    member _.swFileLocationsColorSwatches
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsColorSwatches)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsColorSwatches,v)
            |> ignore

    member _.swFileLocationsTextures
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTextures)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTextures,v)
            |> ignore

    member _.swFileLocationsWeldmentPropertyFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldmentPropertyFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldmentPropertyFile,v)
            |> ignore

    member _.swFileLocationsHoleTableTemplates
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHoleTableTemplates)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHoleTableTemplates,v)
            |> ignore

    member _.swFileLocationsWeldmentCutListTemplates
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldmentCutListTemplates)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldmentCutListTemplates,v)
            |> ignore

    member _.swFileLocationsRevisionTableTemplates
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRevisionTableTemplates)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRevisionTableTemplates,v)
            |> ignore

    member _.swDrawingCustomPropertyUsedAsRevision
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDrawingCustomPropertyUsedAsRevision)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDrawingCustomPropertyUsedAsRevision,v)
            |> ignore

    member _.swFileLocationsRouteComponentLibrary
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRouteComponentLibrary)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRouteComponentLibrary,v)
            |> ignore

    member _.swFileLocationsDesignLibrary
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDesignLibrary)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDesignLibrary,v)
            |> ignore

    member _.swFileLocationsLineStyleDefinitions
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsLineStyleDefinitions)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsLineStyleDefinitions,v)
            |> ignore

    member _.swFileLocationsDesignJournalTemplate
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDesignJournalTemplate)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDesignJournalTemplate,v)
            |> ignore

    member _.swFileLocationsRouteCableLibrary
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRouteCableLibrary)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRouteCableLibrary,v)
            |> ignore

    member _.swFileLocationsAppearances
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsAppearances)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsAppearances,v)
            |> ignore

    member _.swFileLocationsScenes
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsScenes)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsScenes,v)
            |> ignore

    member _.swFileLocationsLights
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsLights)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsLights,v)
            |> ignore

    member _.swFileLocationsBendNoteFormatFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendNoteFormatFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendNoteFormatFile,v)
            |> ignore

    member _.swSeparatorCharacterForDims
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSeparatorCharacterForDims)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSeparatorCharacterForDims,v)
            |> ignore

    member _.swFileLocationsRouteCoveringLibrary
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRouteCoveringLibrary)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsRouteCoveringLibrary,v)
            |> ignore

    member _.swFileLocationsDesignCheckerFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDesignCheckerFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDesignCheckerFile,v)
            |> ignore

    member _.swReferenceTriadXLabel
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swReferenceTriadXLabel)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swReferenceTriadXLabel,v)
            |> ignore

    member _.swReferenceTriadYLabel
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swReferenceTriadYLabel)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swReferenceTriadYLabel,v)
            |> ignore

    member _.swReferenceTriadZLabel
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swReferenceTriadZLabel)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swReferenceTriadZLabel,v)
            |> ignore

    member _.swHoleWizardToolBoxFolder
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHoleWizardToolBoxFolder)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHoleWizardToolBoxFolder,v)
            |> ignore

    member _.swAutoSaveDirectory
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swAutoSaveDirectory)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swAutoSaveDirectory,v)
            |> ignore

    member _.swColorsBackgroundImageFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swColorsBackgroundImageFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swColorsBackgroundImageFile,v)
            |> ignore

    member _.swDetailingBOMUpperCustomProperty
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingBOMUpperCustomProperty)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingBOMUpperCustomProperty,v)
            |> ignore

    member _.swDetailingBOMLowerCustomProperty
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingBOMLowerCustomProperty)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingBOMLowerCustomProperty,v)
            |> ignore

    member _.swFileLocationsTxCalloutFormatFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTxCalloutFormatFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTxCalloutFormatFile,v)
            |> ignore

    member _.swFileLocations3DCCModelFolder
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocations3DCCModelFolder)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocations3DCCModelFolder,v)
            |> ignore

    member _.swFileLocationsHoleWizardFavoritesDB
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHoleWizardFavoritesDB)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHoleWizardFavoritesDB,v)
            |> ignore

    member _.swFileLocationsSearchPaths
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSearchPaths)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSearchPaths,v)
            |> ignore

    member _.swFileLocationsSheetMetalGaugeTable
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSheetMetalGaugeTable)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSheetMetalGaugeTable,v)
            |> ignore

    member _.swFileLocationsSpellingFolders
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSpellingFolders)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSpellingFolders,v)
            |> ignore

    member _.swDetailingLayer
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingLayer)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingLayer,v)
            |> ignore

    member _.swFileLocationsDraftingStandard
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDraftingStandard)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDraftingStandard,v)
            |> ignore

    member _.swDetailingDimensionStandardName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingDimensionStandardName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingDimensionStandardName,v)
            |> ignore

    member _.swOverriddenQuantityColumnName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swOverriddenQuantityColumnName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swOverriddenQuantityColumnName,v)
            |> ignore

    member _.swFileLocationsCustomAppearances
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomAppearances)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomAppearances,v)
            |> ignore

    member _.swFileLocationsCustomDecals
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomDecals)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomDecals,v)
            |> ignore

    member _.swFileLocationsCustomScenes
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomScenes)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCustomScenes,v)
            |> ignore

    member _.swFileLocationsTitleBlockTableTemplate
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTitleBlockTableTemplate)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTitleBlockTableTemplate,v)
            |> ignore

    member _.swFileLocationsBendCalculationTable
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendCalculationTable)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendCalculationTable,v)
            |> ignore

    member _.swFileLocationsThemeFolder
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsThemeFolder)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsThemeFolder,v)
            |> ignore

    member _.swExportIFCType
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swExportIFCType)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swExportIFCType,v)
            |> ignore

    member _.swFileLocationsFuncBldrSegTypeDefinitions
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsFuncBldrSegTypeDefinitions)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsFuncBldrSegTypeDefinitions,v)
            |> ignore

    member _.swFileLocationsSustainabilityReportTemplateFolder
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSustainabilityReportTemplateFolder)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSustainabilityReportTemplateFolder,v)
            |> ignore

    member _.swFileLocationsCostingReportTemplateFolder
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCostingReportTemplateFolder)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCostingReportTemplateFolder,v)
            |> ignore

    member _.swFileLocationsCostingTemplates
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCostingTemplates)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsCostingTemplates,v)
            |> ignore

    member _.swFileLocationsWeldTableTemplate
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldTableTemplate)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsWeldTableTemplate,v)
            |> ignore

    member _.swFileLocationsBendTableTemplate
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendTableTemplate)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsBendTableTemplate,v)
            |> ignore

    member _.swFileLocationsPunchTableTemplate
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPunchTableTemplate)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsPunchTableTemplate,v)
            |> ignore

    member _.swDetailingDetailViewLabels_CustomName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomName,v)
            |> ignore

    member _.swDetailingDetailViewLabels_CustomScale
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomScale)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomScale,v)
            |> ignore

    member _.swDetailingSectionViewLabels_CustomName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomName,v)
            |> ignore

    member _.swDetailingSectionViewLabels_CustomScale
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomScale)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomScale,v)
            |> ignore

    member _.swDetailingAuxViewLabels_CustomName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomName,v)
            |> ignore

    member _.swDetailingAuxViewLabels_CustomScale
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomScale)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomScale,v)
            |> ignore

    member _.swCenterLineLayer
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swCenterLineLayer)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swCenterLineLayer,v)
            |> ignore

    member _.swCenterMarkLayer
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swCenterMarkLayer)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swCenterMarkLayer,v)
            |> ignore

    member _.swSheetMetalBendNotesLayer
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSheetMetalBendNotesLayer)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSheetMetalBendNotesLayer,v)
            |> ignore

    member _.swSearchDissectionLocation
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSearchDissectionLocation)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSearchDissectionLocation,v)
            |> ignore

    member _.swFileLocationsSymbolLibraryFolder
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSymbolLibraryFolder)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsSymbolLibraryFolder,v)
            |> ignore

    member _.swFileLocationsNewSheetFormat
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsNewSheetFormat)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsNewSheetFormat,v)
            |> ignore

    member _.swDetailingMiscView_CustomName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomName,v)
            |> ignore

    member _.swDetailingMiscView_CustomScale
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomScale)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomScale,v)
            |> ignore

    member _.swDraftStandardExclusionList
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDraftStandardExclusionList)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDraftStandardExclusionList,v)
            |> ignore

    member _.swDetailingOrthoView_CustomName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomName,v)
            |> ignore

    member _.swDetailingOrthoView_CustomScale
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomScale)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomScale,v)
            |> ignore

    member _.swElecDuctingDuctName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecDuctingDuctName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecDuctingDuctName,v)
            |> ignore

    member _.swElecCableTrayDuctName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecCableTrayDuctName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecCableTrayDuctName,v)
            |> ignore

    member _.swHvacRectDuctName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacRectDuctName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacRectDuctName,v)
            |> ignore

    member _.swHvacCirDuctName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacCirDuctName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacCirDuctName,v)
            |> ignore

    member _.swElecDuctingElbowName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecDuctingElbowName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecDuctingElbowName,v)
            |> ignore

    member _.swElecCableTrayElbowName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecCableTrayElbowName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swElecCableTrayElbowName,v)
            |> ignore

    member _.swHvacRectElbowName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacRectElbowName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacRectElbowName,v)
            |> ignore

    member _.swHvacCirElbowName
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacCirElbowName)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHvacCirElbowName,v)
            |> ignore

    member _.swBorderLayer
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBorderLayer)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBorderLayer,v)
            |> ignore

    member _.swFileLocationsThreadProfiles
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsThreadProfiles)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsThreadProfiles,v)
            |> ignore

    member _.swFileLocationsGeneralTablesTemplate
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsGeneralTablesTemplate)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsGeneralTablesTemplate,v)
            |> ignore

    member _.swFileLocationsTxGeneralFileLocation
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTxGeneralFileLocation)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsTxGeneralFileLocation,v)
            |> ignore

    member _.swMySldSettings
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swMySldSettings)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swMySldSettings,v)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionPrefix
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionPrefix)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionPrefix,v)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionFirstSeparator
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionFirstSeparator)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionFirstSeparator,v)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionSecondSeparator
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSecondSeparator)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSecondSeparator,v)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionSuffix
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSuffix)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSuffix,v)
            |> ignore

    member _.swSheetMetalDescription
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSheetMetalDescription)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swSheetMetalDescription,v)
            |> ignore

    member _.swDimXpertGeneralToleranceCustomTable
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDimXpertGeneralToleranceCustomTable)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDimXpertGeneralToleranceCustomTable,v)
            |> ignore

    member _.swFileLocationsDefaultSave
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDefaultSave)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDefaultSave,v)
            |> ignore

    member _.swHoleTagsList
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHoleTagsList)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swHoleTagsList,v)
            |> ignore

    member _.swBomTableBOMHeaderCustomText_ForTopLevelOnlyBOM
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForTopLevelOnlyBOM)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForTopLevelOnlyBOM,v)
            |> ignore

    member _.swBomTableBOMHeaderCustomText_ForPartOnlyBOM
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForPartOnlyBOM)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForPartOnlyBOM,v)
            |> ignore

    member _.swBomTableBOMHeaderCustomText_ForIndentedBOM
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForIndentedBOM)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForIndentedBOM,v)
            |> ignore

    member _.swFileLocationsDrawingScaleStandard
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDrawingScaleStandard)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDrawingScaleStandard,v)
            |> ignore

    member _.swStructureSystemsFolder
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swStructureSystemsFolder)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swStructureSystemsFolder,v)
            |> ignore

    member _.swWeldmentStructureCutlistID
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swWeldmentStructureCutlistID)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swWeldmentStructureCutlistID,v)
            |> ignore

    member _.swWeldmentSheetmetalCutlistID
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swWeldmentSheetmetalCutlistID)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swWeldmentSheetmetalCutlistID,v)
            |> ignore

    member _.swWeldmentGenericCutlistID
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swWeldmentGenericCutlistID)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swWeldmentGenericCutlistID,v)
            |> ignore

    member _.swFileLocationsHatchPatternFile
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHatchPatternFile)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsHatchPatternFile,v)
            |> ignore

    member _.swFileLocationsInspectionProjects
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsInspectionProjects)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsInspectionProjects,v)
            |> ignore

    member _.swFileLocationsInspectionReports
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsInspectionReports)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsInspectionReports,v)
            |> ignore

    member _.swLastSynchronizationTimeStamp
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swLastSynchronizationTimeStamp)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swLastSynchronizationTimeStamp,v)
            |> ignore

    member _.swFileLocationsInspectionExports
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsInspectionExports)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsInspectionExports,v)
            |> ignore

    member _.swFileLocationsStructureSystemsConnectionElements
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsStructureSystemsConnectionElements)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsStructureSystemsConnectionElements,v)
            |> ignore

    member _.swFileLocationsConnectedLibrary
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsConnectedLibrary)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsConnectedLibrary,v)
            |> ignore

    member _.swExportOutputCoordinateSystem
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swExportOutputCoordinateSystem)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swExportOutputCoordinateSystem,v)
            |> ignore

    member _.swFileLocationsDefeatureRuleSets
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDefeatureRuleSets)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swFileLocationsDefeatureRuleSets,v)
            |> ignore

    member _.swOppPrefixSuffixText
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swOppPrefixSuffixText)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swOppPrefixSuffixText,v)
            |> ignore

    member _.swVirtualComponentPrefixedit
        with get () =
            swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swVirtualComponentPrefixedit)
        and set v =
            swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swVirtualComponentPrefixedit,v)
            |> ignore

    member _.swUseFolderSearchRules
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderSearchRules)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderSearchRules,v)

    member _.swDisplayArcCenterPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayArcCenterPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayArcCenterPoints,v)

    member _.swDisplayEntityPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEntityPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEntityPoints,v)

    member _.swIgnoreFeatureColors
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreFeatureColors)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreFeatureColors,v)

    member _.swDisplayAxes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAxes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAxes,v)

    member _.swDisplayPlanes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlanes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlanes,v)

    member _.swDisplayOrigins
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOrigins)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOrigins,v)

    member _.swDisplayTemporaryAxes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTemporaryAxes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTemporaryAxes,v)

    member _.swDxfMapping
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfMapping)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfMapping,v)

    member _.swSketchAutomaticRelations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAutomaticRelations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAutomaticRelations,v)

    member _.swInputDimValOnCreate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate,v)

    member _.swFullyConstrainedSketchMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFullyConstrainedSketchMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFullyConstrainedSketchMode,v)

    member _.swXTAssemSaveFormat
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swXTAssemSaveFormat)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swXTAssemSaveFormat,v)

    member _.swDisplayCoordSystems
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCoordSystems)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCoordSystems,v)

    member _.swExtRefOpenReadOnly
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefOpenReadOnly)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefOpenReadOnly,v)

    member _.swExtRefNoPromptOrSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefNoPromptOrSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefNoPromptOrSave,v)

    member _.swExtRefMultipleContexts
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefMultipleContexts)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefMultipleContexts,v)

    member _.swExtRefAutoGenNames
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefAutoGenNames)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefAutoGenNames,v)

    member _.swExtRefUpdateCompNames
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefUpdateCompNames)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefUpdateCompNames,v)

    member _.swDisplayRoutePoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRoutePoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRoutePoints,v)

    member _.swDisplayReferencePoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints,v)

    member _.swUseShadedFaceHighlight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedFaceHighlight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedFaceHighlight,v)

    member _.swDXFDontShowMap
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFDontShowMap)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFDontShowMap,v)

    member _.swThumbnailGraphics
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swThumbnailGraphics)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swThumbnailGraphics,v)

    member _.swUseAlphaTransparency
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseAlphaTransparency)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseAlphaTransparency,v)

    member _.swDynamicDrawingViewActivation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicDrawingViewActivation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicDrawingViewActivation,v)

    member _.swAutoLoadPartsLightweight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoLoadPartsLightweight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoLoadPartsLightweight,v)

    member _.swIGESStandardSetting
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESStandardSetting)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESStandardSetting,v)

    member _.swIGESNurbsSetting
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESNurbsSetting)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESNurbsSetting,v)

    member _.swTiffPrintScaleToFit
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintScaleToFit)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintScaleToFit,v)

    member _.swDisplayVirtualSharps
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayVirtualSharps)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayVirtualSharps,v)

    member _.swUpdateMassPropsDuringSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateMassPropsDuringSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateMassPropsDuringSave,v)

    member _.swDisplayAnnotations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotations,v)

    member _.swDisplayFeatureDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayFeatureDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayFeatureDimensions,v)

    member _.swDisplayReferenceDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceDimensions,v)

    member _.swDisplayAnnotationsUseAssemblySettings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotationsUseAssemblySettings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotationsUseAssemblySettings,v)

    member _.swDisplayNotes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotes,v)

    member _.swDisplayGeometricTolerances
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGeometricTolerances)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGeometricTolerances,v)

    member _.swDisplaySurfaceFinishSymbols
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySurfaceFinishSymbols)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySurfaceFinishSymbols,v)

    member _.swDisplayWeldSymbols
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldSymbols)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldSymbols,v)

    member _.swDisplayDatums
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatums)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatums,v)

    member _.swDisplayDatumTargets
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumTargets)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumTargets,v)

    member _.swDisplayCosmeticThreads
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCosmeticThreads)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCosmeticThreads,v)

    member _.swDetailingDisplayWithBrokenLeaders
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayWithBrokenLeaders)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayWithBrokenLeaders,v)

    member _.swDetailingDualDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDualDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDualDimensions,v)

    member _.swDetailingDisplayDatumsPer1982
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDatumsPer1982)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDatumsPer1982,v)

    member _.swDetailingDisplayAlternateSection
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayAlternateSection)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayAlternateSection,v)

    member _.swDetailingCenterMarkShowLines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkShowLines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkShowLines,v)

    member _.swDetailingFixedSizeWeldSymbol
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingFixedSizeWeldSymbol)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingFixedSizeWeldSymbol,v)

    member _.swDetailingDimsShowParenthesisByDefault
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowParenthesisByDefault)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowParenthesisByDefault,v)

    member _.swDetailingDimsSnapTextToGrid
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsSnapTextToGrid)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsSnapTextToGrid,v)

    member _.swDetailingDimsCenterText
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsCenterText)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsCenterText,v)

    member _.swDetailingRadialDimsDisplay2ndOutsideArrow
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplay2ndOutsideArrow)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplay2ndOutsideArrow,v)

    member _.swDetailingRadialDimsArrowsFollowText
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsArrowsFollowText)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsArrowsFollowText,v)

    member _.swDetailingDimLeaderOverrideStandard
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimLeaderOverrideStandard)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimLeaderOverrideStandard,v)

    member _.swDetailingNotesDisplayWithBentLeader
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesDisplayWithBentLeader)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesDisplayWithBentLeader,v)

    member _.swDisplayTextAtSameSizeAlways
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTextAtSameSizeAlways)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTextAtSameSizeAlways,v)

    member _.swDisplayOnlyInViewOfCreation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOnlyInViewOfCreation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOnlyInViewOfCreation,v)

    member _.swGridDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplay,v)

    member _.swGridDisplayDashed
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplayDashed)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplayDashed,v)

    member _.swGridAutomaticScaling
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridAutomaticScaling)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridAutomaticScaling,v)

    member _.swSnapToPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToPoints,v)

    member _.swSnapToAngle
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToAngle)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToAngle,v)

    member _.swUnitsLinearRoundToNearestFraction
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearRoundToNearestFraction)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearRoundToNearestFraction,v)

    member _.swUnitsLinearFeetAndInchesFormat
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearFeetAndInchesFormat)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearFeetAndInchesFormat,v)

    member _.swFeatureManagerEnsureVisible
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnsureVisible)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnsureVisible,v)

    member _.swFeatureManagerNameFeatureWhenCreated
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerNameFeatureWhenCreated)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerNameFeatureWhenCreated,v)

    member _.swFeatureManagerKeyboardNavigation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerKeyboardNavigation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerKeyboardNavigation,v)

    member _.swFeatureManagerDynamicHighlight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerDynamicHighlight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerDynamicHighlight,v)

    member _.swColorsGradientPartBackground
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsGradientPartBackground)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsGradientPartBackground,v)

    member _.swSTLBinaryFormat
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLBinaryFormat)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLBinaryFormat,v)

    member _.swSTLShowInfoOnSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLShowInfoOnSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLShowInfoOnSave,v)

    member _.swSTLDontTranslateToPositive
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLDontTranslateToPositive)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLDontTranslateToPositive,v)

    member _.swSTLComponentsIntoOneFile
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLComponentsIntoOneFile)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLComponentsIntoOneFile,v)

    member _.swSTLCheckForInterference
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLCheckForInterference)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLCheckForInterference,v)

    member _.swOpenLastUsedDocumentAtStart
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOpenLastUsedDocumentAtStart)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOpenLastUsedDocumentAtStart,v)

    member _.swSingleCommandPerPick
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSingleCommandPerPick)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSingleCommandPerPick,v)

    member _.swShowDimensionNames
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDimensionNames)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDimensionNames,v)

    member _.swShowErrorsEveryRebuild
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowErrorsEveryRebuild)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowErrorsEveryRebuild,v)

    member _.swMaximizeDocumentOnOpen
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaximizeDocumentOnOpen)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaximizeDocumentOnOpen,v)

    member _.swEditDesignTableInSeparateWindow
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditDesignTableInSeparateWindow)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditDesignTableInSeparateWindow,v)

    member _.swEnablePropertyManager
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePropertyManager)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePropertyManager,v)

    member _.swUseSystemSeparatorForDims
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSystemSeparatorForDims)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSystemSeparatorForDims,v)

    member _.swUseEnglishLanguage
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguage)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguage,v)

    member _.swDrawingAutomaticModelDimPlacement
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticModelDimPlacement)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticModelDimPlacement,v)

    member _.swDrawingDisplayViewBorders
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayViewBorders)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayViewBorders,v)

    member _.swAutomaticScaling3ViewDrawings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticScaling3ViewDrawings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticScaling3ViewDrawings,v)

    member _.swDrawingAutomaticBomUpdate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticBomUpdate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticBomUpdate,v)

    member _.swDrawingSelectHiddenEntities
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSelectHiddenEntities)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSelectHiddenEntities,v)

    member _.swDrawingCreateDetailAsCircle
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingCreateDetailAsCircle)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingCreateDetailAsCircle,v)

    member _.swAutomaticDrawingViewUpdate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdate,v)

    member _.swDrawingDetailInferCorner
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCorner)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCorner,v)

    member _.swDrawingDetailInferCenter
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCenter)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCenter,v)

    member _.swDrawingViewShowContentsWhileDragging
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewShowContentsWhileDragging)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewShowContentsWhileDragging,v)

    member _.swSketchAlternateSplineCreation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAlternateSplineCreation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAlternateSplineCreation,v)

    member _.swSketchInferFromModel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInferFromModel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInferFromModel,v)

    member _.swSketchPromptToCloseSketch
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPromptToCloseSketch)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPromptToCloseSketch,v)

    member _.swSketchCreateSketchOnNewPart
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateSketchOnNewPart)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateSketchOnNewPart,v)

    member _.swSketchOverrideDimensionsOnDrag
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverrideDimensionsOnDrag)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverrideDimensionsOnDrag,v)

    member _.swSketchDisplayPlaneWhenShaded
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchDisplayPlaneWhenShaded)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchDisplayPlaneWhenShaded,v)

    member _.swSketchOverdefiningDimsPromptToSetState
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsPromptToSetState)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsPromptToSetState,v)

    member _.swSketchOverdefiningDimsSetDrivenByDefault
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsSetDrivenByDefault)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsSetDrivenByDefault,v)

    member _.swPerformanceVerifyOnRebuild
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceVerifyOnRebuild)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceVerifyOnRebuild,v)

    member _.swPerformanceDynamicUpdateOnMove
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceDynamicUpdateOnMove)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceDynamicUpdateOnMove,v)

    member _.swPerformanceAlwaysGenerateCurvature
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysGenerateCurvature)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysGenerateCurvature,v)

    member _.swPerformanceWin95ZoomClipping
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceWin95ZoomClipping)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceWin95ZoomClipping,v)

    member _.swIGESDuplicateEntities
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESDuplicateEntities)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESDuplicateEntities,v)

    member _.swIGESHighTrimCurveAccuracy
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESHighTrimCurveAccuracy)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESHighTrimCurveAccuracy,v)

    member _.swIGESExportSketchEntities
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSketchEntities)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSketchEntities,v)

    member _.swIGESComponentsIntoOneFile
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESComponentsIntoOneFile)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESComponentsIntoOneFile,v)

    member _.swIGESFlattenAssemHierarchy
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESFlattenAssemHierarchy)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESFlattenAssemHierarchy,v)

    member _.swAlwaysUseDefaultTemplates
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAlwaysUseDefaultTemplates)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAlwaysUseDefaultTemplates,v)

    member _.swUseSimpleOpenGL
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSimpleOpenGL)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSimpleOpenGL,v)

    member _.swShowRefGeomName
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowRefGeomName)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowRefGeomName,v)

    member _.swUseShadedPreview
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedPreview)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedPreview,v)

    member _.swEdgesHiddenEdgeSelectionInWireframe
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInWireframe)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInWireframe,v)

    member _.swEdgesHiddenEdgeSelectionInHLR
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInHLR)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInHLR,v)

    member _.swEdgesRepaintAfterSelectionInHLR
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesRepaintAfterSelectionInHLR)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesRepaintAfterSelectionInHLR,v)

    member _.swEdgesHighlightFeatureEdges
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighlightFeatureEdges)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighlightFeatureEdges,v)

    member _.swEdgesDynamicHighlight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDynamicHighlight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDynamicHighlight,v)

    member _.swEdgesHighQualityDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighQualityDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighQualityDisplay,v)

    member _.swEdgesOpenEdgesDifferentColor
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesOpenEdgesDifferentColor)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesOpenEdgesDifferentColor,v)

    member _.swEnableConfirmationCorner
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableConfirmationCorner)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableConfirmationCorner,v)

    member _.swAutoShowPropertyManager
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoShowPropertyManager)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoShowPropertyManager,v)

    member _.swIncontextFeatureHolderVisibility
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncontextFeatureHolderVisibility)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncontextFeatureHolderVisibility,v)

    member _.swTransparencyHighQualityDynamic
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransparencyHighQualityDynamic)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransparencyHighQualityDynamic,v)

    member _.swEdgesShadedEdgesDifferentColor
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedEdgesDifferentColor)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedEdgesDifferentColor,v)

    member _.swEdgesAntiAlias
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesAntiAlias)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesAntiAlias,v)

    member _.swPageSetupPrinterUsePrinterMargin
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterUsePrinterMargin)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterUsePrinterMargin,v)

    member _.swPageSetupPrinterDrawingScaleToFit
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterDrawingScaleToFit)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterDrawingScaleToFit,v)

    member _.swPageSetupPrinterPartAsmPrintWindow
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterPartAsmPrintWindow)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterPartAsmPrintWindow,v)

    member _.swDisplayShadowsInShadedMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadowsInShadedMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadowsInShadedMode,v)

    member _.swDrawingViewSmoothDynamicMotion
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewSmoothDynamicMotion)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewSmoothDynamicMotion,v)

    member _.swDrawingEliminateDuplicateDimsOnInsert
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateDimsOnInsert)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateDimsOnInsert,v)

    member _.swRapidDraftPrintOutOfSynchWaterMark
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swRapidDraftPrintOutOfSynchWaterMark)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swRapidDraftPrintOutOfSynchWaterMark,v)

    member _.swDrawingViewAutoHideComponents
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewAutoHideComponents)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewAutoHideComponents,v)

    member _.swEdgesDisplayShadedPlanes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDisplayShadedPlanes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDisplayShadedPlanes,v)

    member _.swPlaneDisplayShowEdges
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowEdges)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowEdges,v)

    member _.swPlaneDisplayShowIntersections
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowIntersections)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowIntersections,v)

    member _.swColorsUseSpecifiedEditColors
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseSpecifiedEditColors)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseSpecifiedEditColors,v)

    member _.swEnablePerformanceEmail
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceEmail)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceEmail,v)

    member _.swSnapOnlyIfGridDisplayed
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapOnlyIfGridDisplayed)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapOnlyIfGridDisplayed,v)

    member _.swDetailingBalloonsDisplayWithBentLeader
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonsDisplayWithBentLeader)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonsDisplayWithBentLeader,v)

    member _.swBOMConfigurationLocked
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationLocked)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationLocked,v)

    member _.swBOMConfigurationUseDocumentFont
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseDocumentFont)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseDocumentFont,v)

    member _.swBOMConfigurationUseSummaryInfo
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseSummaryInfo)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseSummaryInfo,v)

    member _.swBOMConfigurationAlignBottom
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationAlignBottom)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationAlignBottom,v)

    member _.swBOMContentsDisplayAtTop
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMContentsDisplayAtTop)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMContentsDisplayAtTop,v)

    member _.swBOMControlIdFromAssembly
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlIdFromAssembly)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlIdFromAssembly,v)

    member _.swBOMControlMissingRows
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlMissingRows)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlMissingRows,v)

    member _.swBOMControlSplitTable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlSplitTable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlSplitTable,v)

    member _.swAutomaticDrawingViewUpdateDefault
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateDefault)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateDefault,v)

    member _.swAutomaticDrawingViewUpdateForceOff
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateForceOff)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateForceOff,v)

    member _.swAnnotationDisplayHideDanglingDim
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAnnotationDisplayHideDanglingDim)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAnnotationDisplayHideDanglingDim,v)

    member _.swDetailingDimBreakAroundArrow
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimBreakAroundArrow)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimBreakAroundArrow,v)

    member _.swDetailingDimensionsToleranceUseParentheses
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseParentheses)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseParentheses,v)

    member _.swDetailingDimensionsToleranceUseDimensionFont
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseDimensionFont)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseDimensionFont,v)

    member _.swImageQualityApplyToAllReferencedPartDoc
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityApplyToAllReferencedPartDoc)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityApplyToAllReferencedPartDoc,v)

    member _.swPrintBackground
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintBackground)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintBackground,v)

    member _.swEDrawingsCompression
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsCompression)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsCompression,v)

    member _.swImportSolidSurface
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidSurface)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidSurface,v)

    member _.swImportFreeCurves
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportFreeCurves)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportFreeCurves,v)

    member _.swImport2dCurvesAs2dSketch
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImport2dCurvesAs2dSketch)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImport2dCurvesAs2dSketch,v)

    member _.swLargeAsmModeAutoLoadLightweight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoLoadLightweight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoLoadLightweight,v)

    member _.swLargeAsmModeUpdateMassPropsOnSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUpdateMassPropsOnSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUpdateMassPropsOnSave,v)

    member _.swLargeAsmModeAutoRecover
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoRecover)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoRecover,v)

    member _.swLargeAsmModeRemoveDetail
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeRemoveDetail)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeRemoveDetail,v)

    member _.swLargeAsmModeHideAllItems
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeHideAllItems)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeHideAllItems,v)

    member _.swLargeAsmModeDynHighlightFeatureMgr
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightFeatureMgr)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightFeatureMgr,v)

    member _.swLargeAsmModeDynHighlightGraphicsView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightGraphicsView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightGraphicsView,v)

    member _.swLargeAsmModeAntiAliasEdgesFastMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAntiAliasEdgesFastMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAntiAliasEdgesFastMode,v)

    member _.swLargeAsmModeShadowsShadedMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShadowsShadedMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShadowsShadedMode,v)

    member _.swLargeAsmModeTransparencyNormalViewMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyNormalViewMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyNormalViewMode,v)

    member _.swLargeAsmModeTransparencyDynamicViewMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyDynamicViewMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyDynamicViewMode,v)

    member _.swLargeAsmModeShowContentsDragDrawView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShowContentsDragDrawView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShowContentsDragDrawView,v)

    member _.swLargeAsmModeSmoothDynamicMotionDrawView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSmoothDynamicMotionDrawView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSmoothDynamicMotionDrawView,v)

    member _.swLargeAsmModeDrawingHLREdgesWhenShaded
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingHLREdgesWhenShaded)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingHLREdgesWhenShaded,v)

    member _.swLargeAsmModeAutoHideCompsDrawViewCreation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoHideCompsDrawViewCreation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoHideCompsDrawViewCreation,v)

    member _.swLargeAsmModeDrawingAutoLoadModels
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingAutoLoadModels)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingAutoLoadModels,v)

    member _.swLargeAsmModeAlwaysGenerateCurvature
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAlwaysGenerateCurvature)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAlwaysGenerateCurvature,v)

    member _.swImportStepConfigData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStepConfigData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStepConfigData,v)

    member _.swIGESExportSolidAndSurface
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSolidAndSurface)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSolidAndSurface,v)

    member _.swIGESExportFreeCurves
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportFreeCurves)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportFreeCurves,v)

    member _.swIGESExportAsWireframe
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportAsWireframe)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportAsWireframe,v)

    member _.swDetailingDimensionsAngularToleranceUseParentheses
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsAngularToleranceUseParentheses)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsAngularToleranceUseParentheses,v)

    member _.swDetailingDimensionsToleranceFitTolUseDimensionFont
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceFitTolUseDimensionFont)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceFitTolUseDimensionFont,v)

    member _.swDetailingAutoInsertCenterMarks
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarks)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarks,v)

    member _.swDetailingAutoInsertCenterLines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterLines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterLines,v)

    member _.swSTLPreview
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLPreview)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLPreview,v)

    member _.swDetailingCenterMarkUseCenterLine
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkUseCenterLine)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkUseCenterLine,v)

    member _.swMaterialPropertySolidFill
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaterialPropertySolidFill)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaterialPropertySolidFill,v)

    member _.swSaveEModelData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveEModelData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveEModelData,v)

    member _.swDisplayCurves
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCurves)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCurves,v)

    member _.swDisplaySketches
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketches)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketches,v)

    member _.swDisplayAllAnnotations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllAnnotations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllAnnotations,v)

    member _.swViewDisplayHideAllTypes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDisplayHideAllTypes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDisplayHideAllTypes,v)

    member _.swColorsUseShadedEdgeColor
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseShadedEdgeColor)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseShadedEdgeColor,v)

    member _.swViewpointPreserveNormals
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewpointPreserveNormals)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewpointPreserveNormals,v)

    member _.swSaveBackupFilesInSameLocationAsOriginal
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveBackupFilesInSameLocationAsOriginal)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveBackupFilesInSameLocationAsOriginal,v)

    member _.swNotifySNLNotObtainedForEDrawingsSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swNotifySNLNotObtainedForEDrawingsSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swNotifySNLNotObtainedForEDrawingsSave,v)

    member _.swPerformanceRemoveDetailDuringZoomPanRotate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceRemoveDetailDuringZoomPanRotate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceRemoveDetailDuringZoomPanRotate,v)

    member _.swDisplayEnableSelectionThroughTransparency
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEnableSelectionThroughTransparency)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEnableSelectionThroughTransparency,v)

    member _.swDisplayReferenceTriad
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceTriad)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceTriad,v)

    member _.swDrawingsDefaultDisplayTypeFastHLRHLV
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeFastHLRHLV)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeFastHLRHLV,v)

    member _.swDrawingsDefaultDisplayTypeHLREdgesWhenShaded
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgesWhenShaded)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgesWhenShaded,v)

    member _.swPerformanceSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSave,v)

    member _.swDetailingAutoUpdateBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoUpdateBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoUpdateBOM,v)

    member _.swImageQualityUseHighQualityEdgeSize
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseHighQualityEdgeSize)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseHighQualityEdgeSize,v)

    member _.swDrawingSaveShadedData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSaveShadedData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSaveShadedData,v)

    member _.swEDrawingsOkayToMeasure
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsOkayToMeasure)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsOkayToMeasure,v)

    member _.swBomTableKeepMissingItems
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableKeepMissingItems)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableKeepMissingItems,v)

    member _.swBomTableStrikeThroughMissingItems
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableStrikeThroughMissingItems)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableStrikeThroughMissingItems,v)

    member _.swRevisionTableUpdateAllLabels
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swRevisionTableUpdateAllLabels)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swRevisionTableUpdateAllLabels,v)

    member _.swIGESImportShowLevel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESImportShowLevel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESImportShowLevel,v)

    member _.swColorsMatchViewAndFeatureManagerBackground
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsMatchViewAndFeatureManagerBackground)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsMatchViewAndFeatureManagerBackground,v)

    member _.swEDrawingsSaveShadedDataInDrawings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveShadedDataInDrawings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveShadedDataInDrawings,v)

    member _.swDisplayReferencePoints2
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints2)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints2,v)

    member _.swImportMultBodyAsPartData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMultBodyAsPartData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMultBodyAsPartData,v)

    member _.swEDrawingsExportSTLOkay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsExportSTLOkay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsExportSTLOkay,v)

    member _.swDetailingDisplaySFSymbolsPer2002
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplaySFSymbolsPer2002)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplaySFSymbolsPer2002,v)

    member _.swDontCopyQTYColumnNameFromTemplate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDontCopyQTYColumnNameFromTemplate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDontCopyQTYColumnNameFromTemplate,v)

    member _.swEDrawingsSaveAnimationOkay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationOkay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationOkay,v)

    member _.swInsertViewForNewDrawing
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertViewForNewDrawing)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertViewForNewDrawing,v)

    member _.swInsertComponentForNewAssembly
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertComponentForNewAssembly)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertComponentForNewAssembly,v)

    member _.swCollabTopDocsNoPromptOrSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabTopDocsNoPromptOrSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabTopDocsNoPromptOrSave,v)

    member _.swCollabEnableMultiUser
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabEnableMultiUser)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabEnableMultiUser,v)

    member _.swViewSketchRelations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewSketchRelations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewSketchRelations,v)

    member _.swDisplayShadedCosmeticThreads
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadedCosmeticThreads)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadedCosmeticThreads,v)

    member _.swCollabAddShortcutMenuItems
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddShortcutMenuItems)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddShortcutMenuItems,v)

    member _.swCollabCheckReadOnlyModifiedByOthers
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabCheckReadOnlyModifiedByOthers)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabCheckReadOnlyModifiedByOthers,v)

    member _.swDisplayAllSplineHandles
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllSplineHandles)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllSplineHandles,v)

    member _.swAssemblyAllowComponentMoveByDragging
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowComponentMoveByDragging)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowComponentMoveByDragging,v)

    member _.swHoleTableCombineTags
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineTags)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineTags,v)

    member _.swHoleTableCombineSameSize
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineSameSize)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineSameSize,v)

    member _.swHoleTableHoleCentersVisible
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableHoleCentersVisible)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableHoleCentersVisible,v)

    member _.swHoleTableAutomaticUpdate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAutomaticUpdate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAutomaticUpdate,v)

    member _.swDetailingDimOffsetText
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimOffsetText)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimOffsetText,v)

    member _.swDetailingDetailViewLabels_PerStandard
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_PerStandard)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_PerStandard,v)

    member _.swDetailingDetailViewLabels_Stacked
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_Stacked)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_Stacked,v)

    member _.swDetailingSectionViewLabels_PerStandard
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_PerStandard)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_PerStandard,v)

    member _.swDetailingSectionViewLabels_Stacked
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_Stacked)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_Stacked,v)

    member _.swDetailingAuxViewLabels_PerStandard
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_PerStandard)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_PerStandard,v)

    member _.swDetailingAuxViewLabels_Stacked
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_Stacked)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_Stacked,v)

    member _.swExportVrmlAllComponentsInSingleFile
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExportVrmlAllComponentsInSingleFile)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExportVrmlAllComponentsInSingleFile,v)

    member _.swDetailingAutoInsertBalloons
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertBalloons)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertBalloons,v)

    member _.swDetailingAutoInsertDimsMarkedForDrawing
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDimsMarkedForDrawing)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDimsMarkedForDrawing,v)

    member _.swSketchInference
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInference)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInference,v)

    member _.swSketchNoSolveMove
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchNoSolveMove)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchNoSolveMove,v)

    member _.swDetailingDimANSIBentLeader
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimANSIBentLeader)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimANSIBentLeader,v)

    member _.swUnitsDualLinearRoundToNearestFraction
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearRoundToNearestFraction)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearRoundToNearestFraction,v)

    member _.swUnitsDualLinearFeetAndInchesFormat
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearFeetAndInchesFormat)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearFeetAndInchesFormat,v)

    member _.swOneConfigOnlyTopLevelBom
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOneConfigOnlyTopLevelBom)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOneConfigOnlyTopLevelBom,v)

    member _.swImageQualitySaveTesselationWithPartDoc
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualitySaveTesselationWithPartDoc)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualitySaveTesselationWithPartDoc,v)

    member _.swShowSheetMetalBendNotes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowSheetMetalBendNotes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowSheetMetalBendNotes,v)

    member _.swDetailingCThreadDisplayHighQuality
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCThreadDisplayHighQuality)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCThreadDisplayHighQuality,v)

    member _.swDetailingDimsPrefixInsideBasicTolBox
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsPrefixInsideBasicTolBox)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsPrefixInsideBasicTolBox,v)

    member _.swDetailingDimsAutoJogOrdinates
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogOrdinates)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogOrdinates,v)

    member _.swColorsWireframeHLRShadedSame
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsWireframeHLRShadedSame)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsWireframeHLRShadedSame,v)

    member _.swEditMacroAfterRecord
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditMacroAfterRecord)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditMacroAfterRecord,v)

    member _.swUseEnglishLanguageFeatureNames
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguageFeatureNames)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguageFeatureNames,v)

    member _.swDrawingDisplayArcCenterPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayArcCenterPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayArcCenterPoints,v)

    member _.swDrawingDisplayEntityPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayEntityPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayEntityPoints,v)

    member _.swDrawingPrintBreaklinesInBrokenView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingPrintBreaklinesInBrokenView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingPrintBreaklinesInBrokenView,v)

    member _.swSketchSnapsPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPoints,v)

    member _.swSketchSnapsCenterPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsCenterPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsCenterPoints,v)

    member _.swSketchSnapsMidPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsMidPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsMidPoints,v)

    member _.swSketchSnapsQuadrantPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsQuadrantPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsQuadrantPoints,v)

    member _.swSketchSnapsIntersections
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsIntersections)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsIntersections,v)

    member _.swSketchSnapsNearest
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsNearest)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsNearest,v)

    member _.swSketchSnapsTangent
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsTangent)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsTangent,v)

    member _.swSketchSnapsPerpendicular
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPerpendicular)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPerpendicular,v)

    member _.swSketchSnapsParallel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsParallel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsParallel,v)

    member _.swSketchSnapsHVLines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVLines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVLines,v)

    member _.swSketchSnapsHVPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVPoints,v)

    member _.swSketchSnapsLength
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsLength)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsLength,v)

    member _.swSketchSnapsGrid
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsGrid)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsGrid,v)

    member _.swSketchSnapToGridIfDisplayed
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapToGridIfDisplayed)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapToGridIfDisplayed,v)

    member _.swSketchSnapsAngle
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsAngle)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsAngle,v)

    member _.swPerformanceSheetMetalIgnoreSelfIntersect
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSheetMetalIgnoreSelfIntersect)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSheetMetalIgnoreSelfIntersect,v)

    member _.swExternalReferencesDisable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExternalReferencesDisable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExternalReferencesDisable,v)

    member _.swFileExplorerShowMyDocuments
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyDocuments)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyDocuments,v)

    member _.swFileExplorerShowMyComputer
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyComputer)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyComputer,v)

    member _.swFileExplorerShowMyNetworkPlaces
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyNetworkPlaces)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyNetworkPlaces,v)

    member _.swFileExplorerShowRecentDocuments
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowRecentDocuments)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowRecentDocuments,v)

    member _.swFileExplorerShowHiddenReferencedDocuments
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowHiddenReferencedDocuments)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowHiddenReferencedDocuments,v)

    member _.swFileExplorerShowSamples
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowSamples)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowSamples,v)

    member _.swBomTableDontAddQTYNextToConfigName
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableDontAddQTYNextToConfigName)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableDontAddQTYNextToConfigName,v)

    member _.swImportAutoRunImportDiagnosticsPersist
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnosticsPersist)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnosticsPersist,v)

    member _.swImportAutoRunImportDiagnostics
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnostics)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnostics,v)

    member _.swQuickTipsPart
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsPart)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsPart,v)

    member _.swQuickTipsAssembly
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsAssembly)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsAssembly,v)

    member _.swQuickTipsDrawing
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsDrawing)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsDrawing,v)

    member _.swSketchLineLengthVirtualSharp3d
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchLineLengthVirtualSharp3d)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchLineLengthVirtualSharp3d,v)

    member _.swSketchShowSplineControlPolygon
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineControlPolygon)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineControlPolygon,v)

    member _.swLargeAsmModeEnabled
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeEnabled)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeEnabled,v)

    member _.swLargeAsmModeSuspendAutoRebuild
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSuspendAutoRebuild)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSuspendAutoRebuild,v)

    member _.swLargeAsmModeUseHLREdgesInShaded
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseHLREdgesInShaded)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseHLREdgesInShaded,v)

    member _.swFourViewportProjectionType
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFourViewportProjectionType)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFourViewportProjectionType,v)

    member _.swImportIDFAddDrilledHoles
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFAddDrilledHoles)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFAddDrilledHoles,v)

    member _.swImportIDFReverseUndersideComponents
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFReverseUndersideComponents)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFReverseUndersideComponents,v)

    member _.swImportStlVrmlTextureInformation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStlVrmlTextureInformation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStlVrmlTextureInformation,v)

    member _.swImportUGToolBodies
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUGToolBodies)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUGToolBodies,v)

    member _.swDxfUseSolidworksLayers
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfUseSolidworksLayers)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfUseSolidworksLayers,v)

    member _.swDisplayRelationsShowPropertyManager
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRelationsShowPropertyManager)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRelationsShowPropertyManager,v)

    member _.swReferenceTriadUseAlternateLabels
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceTriadUseAlternateLabels)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceTriadUseAlternateLabels,v)

    member _.swDetailingAutoInsertCenterMarksForHoles
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHoles)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHoles,v)

    member _.swDetailingAutoInsertCenterMarksForFillets
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFillets)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFillets,v)

    member _.swDetailingScaleWithDimHeight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithDimHeight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithDimHeight,v)

    member _.swDetailingScaleWithSectionTextHeight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithSectionTextHeight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithSectionTextHeight,v)

    member _.swUserEnableAutoFix
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableAutoFix)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableAutoFix,v)

    member _.swDisplayLights
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLights)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLights,v)

    member _.swDisplayCameras
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameras)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameras,v)

    member _.swDxfEndPointMerge
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfEndPointMerge)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfEndPointMerge,v)

    member _.swPerformancePreviewDuringOpen
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformancePreviewDuringOpen)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformancePreviewDuringOpen,v)

    member _.swImportDxfDimsToPartSketch
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDxfDimsToPartSketch)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDxfDimsToPartSketch,v)

    member _.swAutoSaveEnable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSaveEnable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSaveEnable,v)

    member _.swBackupEnable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupEnable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupEnable,v)

    member _.swBackupRemoveEnable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupRemoveEnable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupRemoveEnable,v)

    member _.swSaveReminderEnable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderEnable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderEnable,v)

    member _.swPDFExportInColor
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportInColor)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportInColor,v)

    member _.swPDFExportEmbedFonts
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportEmbedFonts)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportEmbedFonts,v)

    member _.swPDFExportHighQuality
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportHighQuality)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportHighQuality,v)

    member _.swPDFExportPrintHeaderFooter
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportPrintHeaderFooter)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportPrintHeaderFooter,v)

    member _.swPDFExportUseCurrentPrintLineWeights
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportUseCurrentPrintLineWeights)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportUseCurrentPrintLineWeights,v)

    member _.swSketchShadowDrag
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShadowDrag)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShadowDrag,v)

    member _.swWarnSaveUpdateErrors
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSaveUpdateErrors)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSaveUpdateErrors,v)

    member _.swEnablePerformanceFeedback
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceFeedback)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceFeedback,v)

    member _.swShowDrawingViewPalette
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDrawingViewPalette)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDrawingViewPalette,v)

    member _.swDisplayDimensionsFlatToScreen
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimensionsFlatToScreen)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimensionsFlatToScreen,v)

    member _.swPerformanceAlwaysResolveSubassemblies
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysResolveSubassemblies)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysResolveSubassemblies,v)

    member _.swWarnSavingReferencedDoc
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSavingReferencedDoc)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSavingReferencedDoc,v)

    member _.swFeatureManagerTransparentFlyout
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerTransparentFlyout)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerTransparentFlyout,v)

    member _.swDetailingDimsShowBroken
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowBroken)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowBroken,v)

    member _.swDetailingDetailViewLabels_AboveView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_AboveView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_AboveView,v)

    member _.swDetailingSectionViewLabels_AboveView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_AboveView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_AboveView,v)

    member _.swDetailingAuxViewLabels_AboveView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_AboveView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_AboveView,v)

    member _.swPreserveRedundantGeometry
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreserveRedundantGeometry)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreserveRedundantGeometry,v)

    member _.swTranslateNameAttribFromKernelBody
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTranslateNameAttribFromKernelBody)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTranslateNameAttribFromKernelBody,v)

    member _.swPageSetupHighQuality
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupHighQuality)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupHighQuality,v)

    member _.swSketchShowSplineOuterComb
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineOuterComb)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineOuterComb,v)

    member _.swViewShowAnnotationLinkErrors
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkErrors)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkErrors,v)

    member _.swViewShowAnnotationLinkVariables
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkVariables)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkVariables,v)

    member _.swHideUnitsOfLengthValues
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideUnitsOfLengthValues)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideUnitsOfLengthValues,v)

    member _.swShowNewsFeedsInTaskPane
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowNewsFeedsInTaskPane)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowNewsFeedsInTaskPane,v)

    member _.swViewReverseWheelZoomDirection
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewReverseWheelZoomDirection)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewReverseWheelZoomDirection,v)

    member _.swDrawingMarkAllDimensionsForDrawing
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingMarkAllDimensionsForDrawing)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingMarkAllDimensionsForDrawing,v)

    member _.swDrawingShowSheetFormatDialog
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingShowSheetFormatDialog)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingShowSheetFormatDialog,v)

    member _.swDrawingSheetBackgroundAsPicture
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetBackgroundAsPicture)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetBackgroundAsPicture,v)

    member _.swDisplayNotesFlatToScreen
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotesFlatToScreen)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotesFlatToScreen,v)

    member _.swDisplayMissingRefsWhenEditFeature
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMissingRefsWhenEditFeature)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMissingRefsWhenEditFeature,v)

    member _.swSearchWhileTyping
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchWhileTyping)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchWhileTyping,v)

    member _.swDxfExportSplinesAsSplines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportSplinesAsSplines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportSplinesAsSplines,v)

    member _.swDetailingDimsFollowDimXpertLayout
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsFollowDimXpertLayout)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsFollowDimXpertLayout,v)

    member _.swDisplayDimXpertDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimXpertDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimXpertDimensions,v)

    member _.swDetailingShowHaloAroundAnnotation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowHaloAroundAnnotation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowHaloAroundAnnotation,v)

    member _.swDetailingImportEntireAssemblyAnnotations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingImportEntireAssemblyAnnotations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingImportEntireAssemblyAnnotations,v)

    member _.swSearchIncludeContentCentral
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchIncludeContentCentral)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchIncludeContentCentral,v)

    member _.swUserEnablePlasticsMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode,v)

    member _.swDrawingDisableNoteDimensionInference
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteDimensionInference)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteDimensionInference,v)

    member _.swEDrawingsSaveAnimationToAllConfigs
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationToAllConfigs)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationToAllConfigs,v)

    member _.swEDrawingsSaveAnimationRecalculate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationRecalculate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationRecalculate,v)

    member _.swPromptForAutoMateFlip
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPromptForAutoMateFlip)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPromptForAutoMateFlip,v)

    member _.swViewZoomFitAndCenter
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewZoomFitAndCenter)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewZoomFitAndCenter,v)

    member _.swDisplayCameraFOVBox
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameraFOVBox)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameraFOVBox,v)

    member _.swSketchAcceptNumericInput
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAcceptNumericInput)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAcceptNumericInput,v)

    member _.swDisableWeldmentConfigStrings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableWeldmentConfigStrings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableWeldmentConfigStrings,v)

    member _.swDisplayLiveSections
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLiveSections)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLiveSections,v)

    member _.swDetailingAnnotationUseBentLeaders
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationUseBentLeaders)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationUseBentLeaders,v)

    member _.swDetailingBalloonUseDocBentLeaderLength
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonUseDocBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonUseDocBentLeaderLength,v)

    member _.swDetailingGtolUseDocBentLeaderLength
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingGtolUseDocBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingGtolUseDocBentLeaderLength,v)

    member _.swDetailingNoteUseDocBentLeaderLength
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoteUseDocBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoteUseDocBentLeaderLength,v)

    member _.swDetailingSFSymbolUseDocBentLeaderLength
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSFSymbolUseDocBentLeaderLength)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSFSymbolUseDocBentLeaderLength,v)

    member _.swDetailingShowDualDimensionUnits
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDualDimensionUnits)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDualDimensionUnits,v)

    member _.swDetailingOrdinateDisplayAsChain
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrdinateDisplayAsChain)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrdinateDisplayAsChain,v)

    member _.swDetailingDatumsAnchorFilled
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorFilled)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorFilled,v)

    member _.swDetailingDatumsAnchorShoulder
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorShoulder)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorShoulder,v)

    member _.swEDrawingsSaveBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveBOM,v)

    member _.swClearanceShowIgnored
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceShowIgnored)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceShowIgnored,v)

    member _.swClearanceIgnoreEqual
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceIgnoreEqual)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceIgnoreEqual,v)

    member _.swClearanceSubAssyAsComp
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceSubAssyAsComp)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceSubAssyAsComp,v)

    member _.swClearanceCreateFasteners
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceCreateFasteners)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceCreateFasteners,v)

    member _.swClearanceMakeTransparent
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceMakeTransparent)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceMakeTransparent,v)

    member _.swClearanceDisplayOption
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceDisplayOption)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceDisplayOption,v)

    member _.swStopDebuggingVstaOnExit
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStopDebuggingVstaOnExit)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStopDebuggingVstaOnExit,v)

    member _.swOverrideQuantityColumnName
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOverrideQuantityColumnName)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOverrideQuantityColumnName,v)

    member _.swAutoSizePropertyManager
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSizePropertyManager)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSizePropertyManager,v)

    member _.swUserEnablePlasticsMode2
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode2)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode2,v)

    member _.swStepExportSplitPeriodic
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportSplitPeriodic)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportSplitPeriodic,v)

    member _.swStepExportFaceEdgeProps
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportFaceEdgeProps)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportFaceEdgeProps,v)

    member _.swSATExportSplitPeriodic
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportSplitPeriodic)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportSplitPeriodic,v)

    member _.swSATExportFaceEdgeProps
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportFaceEdgeProps)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportFaceEdgeProps,v)

    member _.swDXFHighQualityExport
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFHighQualityExport)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFHighQualityExport,v)

    member _.swDetailingNotesLeaderJustificationSnapping
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesLeaderJustificationSnapping)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesLeaderJustificationSnapping,v)

    member _.swDetailingAutoInsertCenterMarksForSlots
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlots)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlots,v)

    member _.swStepExportConfigurationData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportConfigurationData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportConfigurationData,v)

    member _.swImageQualityZoomToFitForPreviewImages
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityZoomToFitForPreviewImages)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityZoomToFitForPreviewImages,v)

    member _.swTiffPrintAllSheets
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintAllSheets)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintAllSheets,v)

    member _.swTiffPrintUseSheetSize
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintUseSheetSize)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintUseSheetSize,v)

    member _.swDrawingAutoSpaceDimsOnDelete
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutoSpaceDimsOnDelete)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutoSpaceDimsOnDelete,v)

    member _.swDetailingTablesUseTemplateSettings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingTablesUseTemplateSettings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingTablesUseTemplateSettings,v)

    member _.swSaveNewComponentsToExternalFile
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveNewComponentsToExternalFile)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveNewComponentsToExternalFile,v)

    member _.swDoublePrimeMark
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDoublePrimeMark)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDoublePrimeMark,v)

    member _.swDrawingHideEnds
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingHideEnds)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingHideEnds,v)

    member _.swCenterLineMarkLinear
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkLinear)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkLinear,v)

    member _.swCenterLineMarkCircular
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkCircular)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkCircular,v)

    member _.swCenterLineMarkEndsOnlyLinear
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyLinear)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyLinear,v)

    member _.swCenterLineMarkEndsOnlyCircular
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyCircular)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyCircular,v)

    member _.swPreciseRenderingOfOverlappingGeometry
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreciseRenderingOfOverlappingGeometry)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreciseRenderingOfOverlappingGeometry,v)

    member _.swEnableMouseGestures
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableMouseGestures)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableMouseGestures,v)

    member _.swPartExportFlatPattern
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartExportFlatPattern)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartExportFlatPattern,v)

    member _.swHoleTableReuseDeleted
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableReuseDeleted)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableReuseDeleted,v)

    member _.swHoleTableAddNewAtEnd
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAddNewAtEnd)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAddNewAtEnd,v)

    member _.swFlatPatternOpt_SimplifyBends
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_SimplifyBends)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_SimplifyBends,v)

    member _.swFlatPatternOpt_CornerTreatment
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_CornerTreatment)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_CornerTreatment,v)

    member _.swSATExportMultLumpsToSingleBody
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportMultLumpsToSingleBody)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportMultLumpsToSingleBody,v)

    member _.swPartDimXpertBlockTolerance
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertBlockTolerance)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertBlockTolerance,v)

    member _.swPartDimXpertLocationInclinedPlane
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertLocationInclinedPlane)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertLocationInclinedPlane,v)

    member _.swPartDimXpertChainHoleDimensionChain
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainHoleDimensionChain)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainHoleDimensionChain,v)

    member _.swPartDimXpertChainPocketDimensionChain
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainPocketDimensionChain)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainPocketDimensionChain,v)

    member _.swPartDimXpertGeometricApplyMMC
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricApplyMMC)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricApplyMMC,v)

    member _.swPartDimXpertGeometricCreateBasicDimension
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricCreateBasicDimension)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricCreateBasicDimension,v)

    member _.swPartDimXpertGeometricBasicDimensionChain
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricBasicDimensionChain)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricBasicDimensionChain,v)

    member _.swPartDimXpertGeometricPositionAtMMC
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionAtMMC)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionAtMMC,v)

    member _.swPartDimXpertGeometricPositionComposite
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionComposite)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionComposite,v)

    member _.swPartDimXpertGeometricSurfaceProfileComposite
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricSurfaceProfileComposite)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricSurfaceProfileComposite,v)

    member _.swPartDimXpertDisplayEliminateDuplicates
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayEliminateDuplicates)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayEliminateDuplicates,v)

    member _.swPartDimXpertDisplayShowInstanceCount
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayShowInstanceCount)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayShowInstanceCount,v)

    member _.swDisplayPlaneSections
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlaneSections)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlaneSections,v)

    member _.swDisplaySimulationSymbol
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySimulationSymbol)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySimulationSymbol,v)

    member _.swStoreImagesWithModel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreImagesWithModel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreImagesWithModel,v)

    member _.swImageQualityUseOldTangentEdgeDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseOldTangentEdgeDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseOldTangentEdgeDisplay,v)

    member _.swAddDimensionsToSketchEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSketchEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSketchEntity,v)

    member _.swDetailingOrthoViewLabels_PerStandard
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_PerStandard)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_PerStandard,v)

    member _.swDetailingOrthoViewLabels_AboveView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_AboveView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_AboveView,v)

    member _.swDetailingOrthoViewLabelsEnableShow
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabelsEnableShow)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabelsEnableShow,v)

    member _.swUseModelColorInDrawings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseModelColorInDrawings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseModelColorInDrawings,v)

    member _.swDetailingShowDimensionUnits
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDimensionUnits)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDimensionUnits,v)

    member _.swUseFolderAsDefaultSearchLocation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderAsDefaultSearchLocation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderAsDefaultSearchLocation,v)

    member _.swDetailingAutoInsertCenterMarksForHolesAsm
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHolesAsm)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHolesAsm,v)

    member _.swDetailingAutoInsertCenterMarksForFilletsAsm
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFilletsAsm)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFilletsAsm,v)

    member _.swDetailingAutoInsertCenterMarksForSlotsAsm
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlotsAsm)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlotsAsm,v)

    member _.swTableHoleDualDimensionDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleDualDimensionDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleDualDimensionDisplay,v)

    member _.swTableHoleShowUnitsForDualDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleShowUnitsForDualDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleShowUnitsForDualDisplay,v)

    member _.swDXFExportHiddenLayersOn
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersOn)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersOn,v)

    member _.swDXFExportHiddenLayersWarnIsOn
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersWarnIsOn)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersWarnIsOn,v)

    member _.swDetailingLinkParentViewConfiguration
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinkParentViewConfiguration)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinkParentViewConfiguration,v)

    member _.swLockRecentDocumentsList
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRecentDocumentsList)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRecentDocumentsList,v)

    member _.swDxfAllSheetsToPaperSpace
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfAllSheetsToPaperSpace)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfAllSheetsToPaperSpace,v)

    member _.swFlatPatternOpt_DisableSplitters
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_DisableSplitters)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_DisableSplitters,v)

    member _.swFlatPatternOpt_WhenFlattenedShowPunches
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowPunches)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowPunches,v)

    member _.swFlatPatternOpt_WhenFlattenedShowProfiles
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowProfiles)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowProfiles,v)

    member _.swFlatPatternOpt_WhenFlattenedShowCenters
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowCenters)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowCenters,v)

    member _.swUserEnableFreezeBar
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableFreezeBar)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableFreezeBar,v)

    member _.swAddDimensionsToLineEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToLineEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToLineEntity,v)

    member _.swAddDimensionsToRectangleEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToRectangleEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToRectangleEntity,v)

    member _.swAddDimensionsToArcEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToArcEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToArcEntity,v)

    member _.swAddDimensionsToCircleEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToCircleEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToCircleEntity,v)

    member _.swAddDimensionsToSlotEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSlotEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSlotEntity,v)

    member _.swUseChangedDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseChangedDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseChangedDimensions,v)

    member _.swImportDoclessModelInAssem
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDoclessModelInAssem)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDoclessModelInAssem,v)

    member _.swAddDrivenDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDrivenDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDrivenDimensions,v)

    member _.swExtRefShowXInFeatureTree
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefShowXInFeatureTree)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefShowXInFeatureTree,v)

    member _.swLargeAsmModeUseLargeDesignReview
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseLargeDesignReview)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseLargeDesignReview,v)

    member _.swTablePunchShowUnitsForDualDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchShowUnitsForDualDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchShowUnitsForDualDisplay,v)

    member _.swPunchTableCombineTags
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineTags)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineTags,v)

    member _.swPunchTableCombineSameSize
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineSameSize)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineSameSize,v)

    member _.swFlatPatternOpt_ShowGrainDirection
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowGrainDirection)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowGrainDirection,v)

    member _.swFlatPatternOpt_ShowFixedFace
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowFixedFace)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowFixedFace,v)

    member _.swAutoNormalToSketchMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoNormalToSketchMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoNormalToSketchMode,v)

    member _.swUseSpeedpakModelColorInDrawings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSpeedpakModelColorInDrawings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSpeedpakModelColorInDrawings,v)

    member _.swTablePunchDualDimensionsDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchDualDimensionsDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchDualDimensionsDisplay,v)

    member _.swDrawingEliminateDuplicateModelNotesOnInsert
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateModelNotesOnInsert)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateModelNotesOnInsert,v)

    member _.swDrawingDisableNoteMergeWhenDragging
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteMergeWhenDragging)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteMergeWhenDragging,v)

    member _.swDrawingReuseViewLettersFromDeletedAuxilary
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingReuseViewLettersFromDeletedAuxilary)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingReuseViewLettersFromDeletedAuxilary,v)

    member _.swFeatureManagerEnableTreeFilter
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableTreeFilter)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableTreeFilter,v)

    member _.swDxfExportAllSheetsToPaperSpace
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportAllSheetsToPaperSpace)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportAllSheetsToPaperSpace,v)

    member _.swDisplayAmbientOcclusionShadows
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAmbientOcclusionShadows)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAmbientOcclusionShadows,v)

    member _.swDraftQualityAmbientOcclusion
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftQualityAmbientOcclusion)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftQualityAmbientOcclusion,v)

    member _.swQuickViewTransparencyEnabled
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyEnabled)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyEnabled,v)

    member _.swQuickViewTransparencyDynamic
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyDynamic)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyDynamic,v)

    member _.swDetailingDimsShowLeadingZeros
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowLeadingZeros)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowLeadingZeros,v)

    member _.swHoleTableShowAnsiInchSize
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableShowAnsiInchSize)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableShowAnsiInchSize,v)

    member _.swSaveWithoutCostingData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveWithoutCostingData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveWithoutCostingData,v)

    member _.swLoadEnvelopeLightweight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeLightweight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeLightweight,v)

    member _.swLoadEnvelopeReadOnly
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeReadOnly)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeReadOnly,v)

    member _.swDetailingSectionHideShoulders
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionHideShoulders)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionHideShoulders,v)

    member _.swLargeAsmModeDismissAutoUpdate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDismissAutoUpdate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDismissAutoUpdate,v)

    member _.swStepExport3DCurveFeatures
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExport3DCurveFeatures)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExport3DCurveFeatures,v)

    member _.swDetailingAutoInsertDowelSymForHolesPart
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesPart)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesPart,v)

    member _.swDetailingAutoInsertDowelSymForHolesAsm
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesAsm)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesAsm,v)

    member _.swDetailingDimsApplyUpdatedRules
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsApplyUpdatedRules)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsApplyUpdatedRules,v)

    member _.swDetailingAngularRunningDisplayAsChain
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningDisplayAsChain)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningDisplayAsChain,v)

    member _.swDetailingAngularRunningRunBidirectionally
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningRunBidirectionally)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningRunBidirectionally,v)

    member _.swDetailingDimsAutoJogAngularRunning
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogAngularRunning)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogAngularRunning,v)

    member _.swDetailingLinearDimPrecisionLinkWithModel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearDimPrecisionLinkWithModel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearDimPrecisionLinkWithModel,v)

    member _.swDetailingAltLinearDimPrecisionLinkWithModel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAltLinearDimPrecisionLinkWithModel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAltLinearDimPrecisionLinkWithModel,v)

    member _.swDetailingDisplayDualBasicDimensionInOneBox
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDualBasicDimensionInOneBox)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDualBasicDimensionInOneBox,v)

    member _.swAutoScaleTextureSFDecalsToModelSize
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoScaleTextureSFDecalsToModelSize)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoScaleTextureSFDecalsToModelSize,v)

    member _.swLargeAsmModeAutoCheckUpdateAllComponents
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoCheckUpdateAllComponents)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoCheckUpdateAllComponents,v)

    member _.swDisplaySpeedpakGraphicsCircle
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySpeedpakGraphicsCircle)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySpeedpakGraphicsCircle,v)

    member _.swSheetMetalBendNotesUseDocLeaderLength
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesUseDocLeaderLength)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesUseDocLeaderLength,v)

    member _.swSheetMetalBendNotesLeaderJustificationSnapping
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesLeaderJustificationSnapping)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesLeaderJustificationSnapping,v)

    member _.swEnableSoundsForSolidWorksEvents
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableSoundsForSolidWorksEvents)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableSoundsForSolidWorksEvents,v)

    member _.swSearchShowSolidWorksSearchBox
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchShowSolidWorksSearchBox)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchShowSolidWorksSearchBox,v)

    member _.swSearchDissectionScheduleDaily
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchDissectionScheduleDaily)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchDissectionScheduleDaily,v)

    member _.swDrawingDisplaySketchHatchBehindGeometry
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchHatchBehindGeometry)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchHatchBehindGeometry,v)

    member _.swDetailingRadialDimsDisplayWithSolidLeader
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayWithSolidLeader)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayWithSolidLeader,v)

    member _.swSketchCreateDimensionOnlyWhenEntered
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateDimensionOnlyWhenEntered)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateDimensionOnlyWhenEntered,v)

    member _.swPurgeAllBodiesForNonActiveConfigurations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPurgeAllBodiesForNonActiveConfigurations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPurgeAllBodiesForNonActiveConfigurations,v)

    member _.swDetailingAutoInsertDowelSymbols
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbols)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbols,v)

    member _.swDetailingAutoInsertDowelSymbolsAsm
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbolsAsm)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbolsAsm,v)

    member _.swSaveReminderAutoDismissEnable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderAutoDismissEnable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderAutoDismissEnable,v)

    member _.swDrawingDisplaySketchPicturesOnSheetBehindGeometry
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchPicturesOnSheetBehindGeometry)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchPicturesOnSheetBehindGeometry,v)

    member _.swDetailingShowUnitsForDualDisplay
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowUnitsForDualDisplay)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowUnitsForDualDisplay,v)

    member _.swImageQualityWireframeHighCurveQuality
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityWireframeHighCurveQuality)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityWireframeHighCurveQuality,v)

    member _.swDetailingCenterOfMassScaleByView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterOfMassScaleByView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterOfMassScaleByView,v)

    member _.swDisplayCenterOfMassSymbol
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCenterOfMassSymbol)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCenterOfMassSymbol,v)

    member _.swTiffPrintPadText
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintPadText)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintPadText,v)

    member _.swUpdateExternFilesDispList
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateExternFilesDispList)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateExternFilesDispList,v)

    member _.swDrawingsDefaultDisplayTypeHLREdgeQualityWhenShaded
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgeQualityWhenShaded)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgeQualityWhenShaded,v)

    member _.swDrawingSheetsUseDifferentSheetFormat
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsUseDifferentSheetFormat)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsUseDifferentSheetFormat,v)

    member _.swDetailingMiscView_PerStandard
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_PerStandard)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_PerStandard,v)

    member _.swDetailingMiscView_AboveView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AboveView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AboveView,v)

    member _.swDetailingMiscView_AddViewLabelOnViewCreation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AddViewLabelOnViewCreation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AddViewLabelOnViewCreation,v)

    member _.swDetailingHighlightElements
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingHighlightElements)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingHighlightElements,v)

    member _.swDetailingAllUpperCase
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAllUpperCase)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAllUpperCase,v)

    member _.swDetailingMiscView_RemoveSpaceInScale
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_RemoveSpaceInScale)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_RemoveSpaceInScale,v)

    member _.swWarnStartingSketchInContextAssembly
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnStartingSketchInContextAssembly)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnStartingSketchInContextAssembly,v)

    member _.swDetailingAuxView_SimplifiedDetailed
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_SimplifiedDetailed)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_SimplifiedDetailed,v)

    member _.swDetailingAuxView_RemoveSpaceInScale
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RemoveSpaceInScale)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RemoveSpaceInScale,v)

    member _.swDetailingAuxView_RotateViewToHorizontalSheet
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateViewToHorizontalSheet)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateViewToHorizontalSheet,v)

    member _.swDetailingAuxView_RotateClockwiseCounterclockwise
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateClockwiseCounterclockwise)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateClockwiseCounterclockwise,v)

    member _.swEdgeQualityShadedEdgeViews
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityShadedEdgeViews)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityShadedEdgeViews,v)

    member _.swDetailingSectionView_RemoveSpaceInScale
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_RemoveSpaceInScale)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_RemoveSpaceInScale,v)

    member _.swColorUseSelectedItemColorsSeedsPatterns
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorUseSelectedItemColorsSeedsPatterns)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorUseSelectedItemColorsSeedsPatterns,v)

    member _.swDimensionsExtensionLineStyleSameAsLeader
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimensionsExtensionLineStyleSameAsLeader)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimensionsExtensionLineStyleSameAsLeader,v)

    member _.swDraftingStandardUppercase
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardUppercase)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardUppercase,v)

    member _.swEdgeQualityWireframeHiddenViews
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityWireframeHiddenViews)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityWireframeHiddenViews,v)

    member _.swDetailingSplitWhenTextIsSolidLeaderAligned
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitWhenTextIsSolidLeaderAligned)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitWhenTextIsSolidLeaderAligned,v)

    member _.swEdgesDefaultBulkSelection
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection,v)

    member _.swDisplayPatternInformationTooltips
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPatternInformationTooltips)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPatternInformationTooltips,v)

    member _.swAssemblyUpdateModelGraphicsWhenSavingFiles
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyUpdateModelGraphicsWhenSavingFiles)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyUpdateModelGraphicsWhenSavingFiles,v)

    member _.swDetailingOrthoView_AddViewLabelOnViewCreation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_AddViewLabelOnViewCreation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_AddViewLabelOnViewCreation,v)

    member _.swDetailingOrthoView_RemoveSpaceInScale
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_RemoveSpaceInScale)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_RemoveSpaceInScale,v)

    member _.swDetailingSplitDualDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitDualDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitDualDimensions,v)

    member _.swDetailingDetailView_RemoveSpaceInScale
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_RemoveSpaceInScale)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_RemoveSpaceInScale,v)

    member _.swEdgesShadedModeDisplayOptimizeForThinParts
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedModeDisplayOptimizeForThinParts)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedModeDisplayOptimizeForThinParts,v)

    member _.swWhileOpeningAssembliesAutoDismissMessages
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWhileOpeningAssembliesAutoDismissMessages)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWhileOpeningAssembliesAutoDismissMessages,v)

    member _.swDetailingMiscView_DisplayLabelAboveView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_DisplayLabelAboveView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_DisplayLabelAboveView,v)

    member _.swDetailingSplitTextDualDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitTextDualDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitTextDualDimensions,v)

    member _.swDetailingOrthoView_DisplayLabelAboveView
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_DisplayLabelAboveView)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_DisplayLabelAboveView,v)

    member _.swIGESExportSplitPeriodic
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSplitPeriodic)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSplitPeriodic,v)

    member _.swRebuildSaveNewConfig
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swRebuildSaveNewConfig)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swRebuildSaveNewConfig,v)

    member _.swTextSizeUseOperatingSystemScale
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTextSizeUseOperatingSystemScale)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTextSizeUseOperatingSystemScale,v)

    member _.swPageSetupScaleDraftEdges
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupScaleDraftEdges)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupScaleDraftEdges,v)

    member _.swWeldmentEnableAutomaticCutList
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList,v)

    member _.swWeldmentEnableAutomaticUpdate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate,v)

    member _.swDisplayCompAnnotations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCompAnnotations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCompAnnotations,v)

    member _.swShowZoneLines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowZoneLines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowZoneLines,v)

    member _.swDetailingAngDimensionsRemoveInsignificantZeros
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngDimensionsRemoveInsignificantZeros)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngDimensionsRemoveInsignificantZeros,v)

    member _.swShowMateReferenceErrors
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowMateReferenceErrors)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowMateReferenceErrors,v)

    member _.swDetailingDimensionsToleranceInwardRounding
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceInwardRounding)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceInwardRounding,v)

    member _.swDetailingNoDimSpecificOptionSpecified
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoDimSpecificOptionSpecified)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoDimSpecificOptionSpecified,v)

    member _.swPDFExportIncludeLayersNotToPrint
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeLayersNotToPrint)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeLayersNotToPrint,v)

    member _.swEDrawingsIncludeLayersNotToPrint
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsIncludeLayersNotToPrint)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsIncludeLayersNotToPrint,v)

    member _.swTIFIncludeLayersNotToPrint
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFIncludeLayersNotToPrint)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFIncludeLayersNotToPrint,v)

    member _.swSketchAddConstToRectEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstToRectEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstToRectEntity,v)

    member _.swSketchAddConstLineDiagonalType
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstLineDiagonalType)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstLineDiagonalType,v)

    member _.swDisableDerivedConfigurations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableDerivedConfigurations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableDerivedConfigurations,v)

    member _.swFlatPatternOpt_WhenFlattenedShowGussetProfiles
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetProfiles)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetProfiles,v)

    member _.swFlatPatternOpt_WhenFlattenedShowGussetCenters
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetCenters)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetCenters,v)

    member _.swImportSLDXMLImportSketchData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportSketchData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportSketchData,v)

    member _.swImportSLDXMLImportMechanismSketchObjectsAsBlocks
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportMechanismSketchObjectsAsBlocks)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportMechanismSketchObjectsAsBlocks,v)

    member _.swAMFCompression
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFCompression)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFCompression,v)

    member _.swAMFMaterials
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFMaterials)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFMaterials,v)

    member _.swAMFColors
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFColors)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFColors,v)

    member _.swEnhanceSmallFaceSelectionPrecision
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnhanceSmallFaceSelectionPrecision)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnhanceSmallFaceSelectionPrecision,v)

    member _.swWeldmentRenameCutlistDescriptionPropertyValue
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue,v)

    member _.swDetailingLocationLabelAddSameSheetNumber
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLocationLabelAddSameSheetNumber)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLocationLabelAddSameSheetNumber,v)

    member _.swDetailingConnectionLinesHolePatternsCenterMarks
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingConnectionLinesHolePatternsCenterMarks)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingConnectionLinesHolePatternsCenterMarks,v)

    member _.swDetailingAuxView_IncludeLocationLabelsForNewViews
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_IncludeLocationLabelsForNewViews)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_IncludeLocationLabelsForNewViews,v)

    member _.swDetailingDetailView_IncludeLocationLabelsForNewViews
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_IncludeLocationLabelsForNewViews)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_IncludeLocationLabelsForNewViews,v)

    member _.swDetailingSectionView_IncludeLocationLabelsForNewViews
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_IncludeLocationLabelsForNewViews)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_IncludeLocationLabelsForNewViews,v)

    member _.swDrawingSheetsListNumFirstInZoneCallout
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsListNumFirstInZoneCallout)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsListNumFirstInZoneCallout,v)

    member _.swDrawingSheetsContinueColumnIteration
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsContinueColumnIteration)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsContinueColumnIteration,v)

    member _.swDrawingEnableSymbolAddingNewRevision
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEnableSymbolAddingNewRevision)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEnableSymbolAddingNewRevision,v)

    member _.swImportSLDXMLImportAssemblyMatesData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportAssemblyMatesData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportAssemblyMatesData,v)

    member _.swNoteParagraphAutoNumbering
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swNoteParagraphAutoNumbering)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swNoteParagraphAutoNumbering,v)

    member _.swBreakAlignWithParent
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBreakAlignWithParent)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBreakAlignWithParent,v)

    member _.swShowAnnotationInAnnotationViews
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowAnnotationInAnnotationViews)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowAnnotationInAnnotationViews,v)

    member _.swPrintGrid
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintGrid)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintGrid,v)

    member _.swPrintZoneLines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintZoneLines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintZoneLines,v)

    member _.swShowToolboxFavoritesFolder
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowToolboxFavoritesFolder)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowToolboxFavoritesFolder,v)

    member _.swDetailingCenterMarkScaleByViewScale
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkScaleByViewScale)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkScaleByViewScale,v)

    member _.swDrawingSheetsMatchCustomPropVals
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsMatchCustomPropVals)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsMatchCustomPropVals,v)

    member _.swSaveAsmAsPartPreserveIDs
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveAsmAsPartPreserveIDs)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveAsmAsPartPreserveIDs,v)

    member _.swHideShowSketchDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideShowSketchDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideShowSketchDimensions,v)

    member _.swPDFViewOnSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFViewOnSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFViewOnSave,v)

    member _.swDisplayDatumCoordSystems
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumCoordSystems)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumCoordSystems,v)

    member _.swMakeFirstSelectionTransparentInMateDialog
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeFirstSelectionTransparentInMateDialog)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeFirstSelectionTransparentInMateDialog,v)

    member _.swMatchConfigurationNames
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMatchConfigurationNames)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMatchConfigurationNames,v)

    member _.swDetailingLinearForeshortenedAutomatic
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearForeshortenedAutomatic)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearForeshortenedAutomatic,v)

    member _.swDetachSegmentOnDragMode
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetachSegmentOnDragMode)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetachSegmentOnDragMode,v)

    member _.swDetailingDiameterForeshortenedAutomatic
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDiameterForeshortenedAutomatic)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDiameterForeshortenedAutomatic,v)

    member _.swShowBreadcrumbsOnSelection
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsOnSelection)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsOnSelection,v)

    member _.swDetailingShowPeriodWithBorders
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowPeriodWithBorders)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowPeriodWithBorders,v)

    member _.swDetailingBorderDoubleLine
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderDoubleLine)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderDoubleLine,v)

    member _.swDetailingBorderShowZoneDividers
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowZoneDividers)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowZoneDividers,v)

    member _.swDetailingBorderShowColumns
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowColumns)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowColumns,v)

    member _.swDetailingBorderShowRows
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowRows)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowRows,v)

    member _.swPointAxisCoordSystemHideNames
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPointAxisCoordSystemHideNames)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPointAxisCoordSystemHideNames,v)

    member _.swFeatureManagerEnableRenamingComponent
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableRenamingComponent)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableRenamingComponent,v)

    member _.swDynamicReferenceVisualization_Parent
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Parent)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Parent,v)

    member _.swDynamicReferenceVisualization_Child
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Child)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Child,v)

    member _.sw3MFAppearances
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFAppearances)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFAppearances,v)

    member _.sw3MFMaterials
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFMaterials)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFMaterials,v)

    member _.sw3MFDecals
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFDecals)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFDecals,v)

    member _.swForceEnableImportDiagnosis
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swForceEnableImportDiagnosis)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swForceEnableImportDiagnosis,v)

    member _.swDisplayCounterpartLocationLabel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCounterpartLocationLabel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCounterpartLocationLabel,v)

    member _.swExtRefLoadRefDocsInMemory
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefLoadRefDocsInMemory)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefLoadRefDocsInMemory,v)

    member _.swScaleSketchOnFirstDimension
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swScaleSketchOnFirstDimension)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swScaleSketchOnFirstDimension,v)

    member _.sw3MFShowInfoOnSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFShowInfoOnSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFShowInfoOnSave,v)

    member _.swExtRefIncludeSubFolders
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefIncludeSubFolders)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefIncludeSubFolders,v)

    member _.swExtRefExcludeActiveFoldersAndRecentSaveLocations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefExcludeActiveFoldersAndRecentSaveLocations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefExcludeActiveFoldersAndRecentSaveLocations,v)

    member _.swSheetMetalOverrideTemplateParam
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateParam)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateParam,v)

    member _.swSheetMetalOverrideTemplateAllowance
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateAllowance)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateAllowance,v)

    member _.swSheetMetalOverrideTemplateRelief
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateRelief)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateRelief,v)

    member _.swShadedSketchContours
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShadedSketchContours)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShadedSketchContours,v)

    member _.swDetailingRadialDimsDisplayNearSideMessages
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayNearSideMessages)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayNearSideMessages,v)

    member _.swCollabAddTimeStampToComments
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddTimeStampToComments)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddTimeStampToComments,v)

    member _.swCollabShowCommentsInPropertyManager
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabShowCommentsInPropertyManager)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabShowCommentsInPropertyManager,v)

    member _.swDetailingScaleForJaggedStyle
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleForJaggedStyle)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleForJaggedStyle,v)

    member _.swDetailingDetailViewLabels_ScaleForJaggedOutline
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_ScaleForJaggedOutline)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_ScaleForJaggedOutline,v)

    member _.swFeatureManagerEnablePreviewHiddenComponents
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnablePreviewHiddenComponents)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnablePreviewHiddenComponents,v)

    member _.swWeldmentCollectIdenticalBodies
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies,v)

    member _.swLargeAsmModePreviewHiddenComponent
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModePreviewHiddenComponent)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModePreviewHiddenComponent,v)

    member _.swLargeAsmModeVerificationOnRebuild
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeVerificationOnRebuild)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeVerificationOnRebuild,v)

    member _.swLargeAsmModeImageQualityPerfomance
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeImageQualityPerfomance)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeImageQualityPerfomance,v)

    member _.sw3DPDFCompressLossyTessellation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3DPDFCompressLossyTessellation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3DPDFCompressLossyTessellation,v)

    member _.swDisplayDecals
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDecals)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDecals,v)

    member _.swDisplayPartingLines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPartingLines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPartingLines,v)

    member _.swDisplaySketchPlanes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketchPlanes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketchPlanes,v)

    member _.swDisplayWeldBead
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldBead)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldBead,v)

    member _.swIFCOmniClassPreference
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCOmniClassPreference)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCOmniClassPreference,v)

    member _.swIFCUniClass2Preference
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCUniClass2Preference)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCUniClass2Preference,v)

    member _.swIFCCustomPropsPreference
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCCustomPropsPreference)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCCustomPropsPreference,v)

    member _.swIFCMaterialsMassPropertiesPreference
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCMaterialsMassPropertiesPreference)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCMaterialsMassPropertiesPreference,v)

    member _.swDisplayEquationIds
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEquationIds)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEquationIds,v)

    member _.swMagMatePreAlign
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMagMatePreAlign)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMagMatePreAlign,v)

    member _.swOptimizeMatePlacement
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOptimizeMatePlacement)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOptimizeMatePlacement,v)

    member _.swPdfIncludeBookmarks
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPdfIncludeBookmarks)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPdfIncludeBookmarks,v)

    member _.swDisplayGraphicsComponents
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGraphicsComponents)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGraphicsComponents,v)

    member _.swDraftingStandardAllUppercaseForTable
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForTable)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForTable,v)

    member _.swTransferHoleWizardSizeComboBoxSettings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransferHoleWizardSizeComboBoxSettings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransferHoleWizardSizeComboBoxSettings,v)

    member _.swAssemblyAllowCreationOfMisalignedMates
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowCreationOfMisalignedMates)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowCreationOfMisalignedMates,v)

    member _.swVrmlStlImportAsPSMesh
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportAsPSMesh)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportAsPSMesh,v)

    member _.swSolidBBoxDescriptionUseDefault
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSolidBBoxDescriptionUseDefault)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSolidBBoxDescriptionUseDefault,v)

    member _.swSheetMetalBodiesDescriptionUseDefault
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBodiesDescriptionUseDefault)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBodiesDescriptionUseDefault,v)

    member _.swVrmlStlImportSegmented
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportSegmented)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportSegmented,v)

    member _.swEnableVSTAVersion3
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableVSTAVersion3)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableVSTAVersion3,v)

    member _.swViewDispGlobalBBox
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDispGlobalBBox)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDispGlobalBBox,v)

    member _.swDisplayComponentDimXpertAnnotations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayComponentDimXpertAnnotations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayComponentDimXpertAnnotations,v)

    member _.swImportNeutral_SolidandSurface
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_SolidandSurface)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_SolidandSurface,v)

    member _.swImportNeutral_FreeCurvesAndPoints
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_FreeCurvesAndPoints)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_FreeCurvesAndPoints,v)

    member _.swImportNeutralReferencePlane
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralReferencePlane)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralReferencePlane,v)

    member _.swImportNeutral_AttributesAndProperties
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_AttributesAndProperties)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_AttributesAndProperties,v)

    member _.swImportNeutralRunDiagnostics
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralRunDiagnostics)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralRunDiagnostics,v)

    member _.swMultiCAD_Enable3DInterconnect
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_Enable3DInterconnect)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_Enable3DInterconnect,v)

    member _.swDrawingTurnOffAutomaticSolveModeAndUndo
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingTurnOffAutomaticSolveModeAndUndo)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingTurnOffAutomaticSolveModeAndUndo,v)

    member _.swSketchTurnOffAutomaticSolveModeAndUndo
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchTurnOffAutomaticSolveModeAndUndo)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchTurnOffAutomaticSolveModeAndUndo,v)

    member _.swImportSolidBody
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidBody)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidBody,v)

    member _.swImportSurfaceBody
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSurfaceBody)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSurfaceBody,v)

    member _.swImportReferencePlane
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferencePlane)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferencePlane,v)

    member _.swImportReferenceAxis
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferenceAxis)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferenceAxis,v)

    member _.swImportUnconsumedSketchesAndCurves
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUnconsumedSketchesAndCurves)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUnconsumedSketchesAndCurves,v)

    member _.swImportCustomProperties
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportCustomProperties)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportCustomProperties,v)

    member _.swImportMaterialProperties
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMaterialProperties)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMaterialProperties,v)

    member _.swImportDissolveTopLevelAssemblyOnOpen
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDissolveTopLevelAssemblyOnOpen)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDissolveTopLevelAssemblyOnOpen,v)

    member _.swImportIgnoreHiddenEntities
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIgnoreHiddenEntities)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIgnoreHiddenEntities,v)

    member _.swImportToolBodiesFromUGNX
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportToolBodiesFromUGNX)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportToolBodiesFromUGNX,v)

    member _.swIncludePMI
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludePMI)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludePMI,v)

    member _.swAssemblyAllowGraphicsComponent
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowGraphicsComponent)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowGraphicsComponent,v)

    member _.swCheckCrashSolutions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCheckCrashSolutions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCheckCrashSolutions,v)

    member _.swMakeTrimEntityConstruction
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeTrimEntityConstruction)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeTrimEntityConstruction,v)

    member _.swIgnoreConstructionEntity
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreConstructionEntity)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreConstructionEntity,v)

    member _.swLockRotationConcentricMates
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRotationConcentricMates)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRotationConcentricMates,v)

    member _.swASMSLDPRT_ExcludeComponentsByVisibility
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByVisibility)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByVisibility,v)

    member _.swASMSLDPRT_ExcludeComponentsByBBoxVolume
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByBBoxVolume)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByBBoxVolume,v)

    member _.swASMSLDPRT_ExcludeIfToolboxComponents
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeIfToolboxComponents)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeIfToolboxComponents,v)

    member _.swASMSLDPRT_IncludeMassProperties
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_IncludeMassProperties)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_IncludeMassProperties,v)

    member _.swEnableAllowCosmeticThreadsUpgrade
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableAllowCosmeticThreadsUpgrade)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableAllowCosmeticThreadsUpgrade,v)

    member _.swSheetMetalUseMaterial
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalUseMaterial)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalUseMaterial,v)

    member _.swPDFExportShadedEdgesHighQuality
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportShadedEdgesHighQuality)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportShadedEdgesHighQuality,v)

    member _.swBomTableShowCustomTextinBOMHeader_ForTopLevelOnlyBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForTopLevelOnlyBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForTopLevelOnlyBOM,v)

    member _.swBomTableShowCustomTextinBOMHeader_ForPartOnlyBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForPartOnlyBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForPartOnlyBOM,v)

    member _.swBomTableShowCustomTextinBOMHeader_ForIndentedBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForIndentedBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForIndentedBOM,v)

    member _.swBomTableShowConfigurationInBOMHeader_ForTopLevelOnlyBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForTopLevelOnlyBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForTopLevelOnlyBOM,v)

    member _.swBomTableShowConfigurationInBOMHeader_ForPartOnlyBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForPartOnlyBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForPartOnlyBOM,v)

    member _.swBomTableShowConfigurationInBOMHeader_ForIndentedBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForIndentedBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForIndentedBOM,v)

    member _.swEdit3DPDFTemplate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdit3DPDFTemplate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdit3DPDFTemplate,v)

    member _.swPLYBinaryFormat
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYBinaryFormat)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYBinaryFormat,v)

    member _.swPLYPreview
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYPreview)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYPreview,v)

    member _.swPLYIncludeColors
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYIncludeColors)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYIncludeColors,v)

    member _.swDisplayScrollbarsInGraphicsViewDrawings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewDrawings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewDrawings,v)

    member _.swDisplayScrollbarsInGraphicsViewPartsAndAssemblies
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewPartsAndAssemblies)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewPartsAndAssemblies,v)

    member _.swShowBreadcrumbsAtMousePointer
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsAtMousePointer)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsAtMousePointer,v)

    member _.swIncludeDocumentsOpenedFromOtherDocuments
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDocumentsOpenedFromOtherDocuments)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDocumentsOpenedFromOtherDocuments,v)

    member _.swIncludeSubfoldersForDrawingsSearchInPackAndGo
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSubfoldersForDrawingsSearchInPackAndGo)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSubfoldersForDrawingsSearchInPackAndGo,v)

    member _.swAutomaticallyPopupSelectionToolForPreciseLocation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticallyPopupSelectionToolForPreciseLocation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticallyPopupSelectionToolForPreciseLocation,v)

    member _.swCombineCutlistItemsInBOM
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCombineCutlistItemsInBOM)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCombineCutlistItemsInBOM,v)

    member _.swEditNameWithSlowDoubleClick
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditNameWithSlowDoubleClick)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditNameWithSlowDoubleClick,v)

    member _.swSheetMetalMBDDisplaySheetMetalBendNotes
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDDisplaySheetMetalBendNotes)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDDisplaySheetMetalBendNotes,v)

    member _.swSheetMetalMBDUseDocumentLeaderLength
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDUseDocumentLeaderLength)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDUseDocumentLeaderLength,v)

    member _.swSheetMetalMBDLeaderJustificationSnapping
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDLeaderJustificationSnapping)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDLeaderJustificationSnapping,v)

    member _.swSheetMetalMBDShowFixedFace
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowFixedFace)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowFixedFace,v)

    member _.swSheetMetalMBDShowGrainDirection
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowGrainDirection)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowGrainDirection,v)

    member _.swSheetMetalMBDFormat
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDFormat)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDFormat,v)

    member _.swEnablePerformancePipeline
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformancePipeline)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformancePipeline,v)

    member _.swReferenceOnlyEnvelopeComponentType
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceOnlyEnvelopeComponentType)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceOnlyEnvelopeComponentType,v)

    member _.swReferenceInContextOfTopLevelAssembly
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceInContextOfTopLevelAssembly)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceInContextOfTopLevelAssembly,v)

    member _.swDisplayDataMarkNewConfig
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDataMarkNewConfig)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDataMarkNewConfig,v)

    member _.swAllowCreationOfReferencesExternalToModel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAllowCreationOfReferencesExternalToModel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAllowCreationOfReferencesExternalToModel,v)

    member _.swDetailingAnnotationShowTypeInThreadCallouts
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationShowTypeInThreadCallouts)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationShowTypeInThreadCallouts,v)

    member _.swDetailingChainDimensionAddOverallDimensions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddOverallDimensions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddOverallDimensions,v)

    member _.swDetailingChainDimensionAddLastReferenceDimension
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddLastReferenceDimension)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddLastReferenceDimension,v)

    member _.swDraftingStandardAllUppercaseForDimensionsAndHoleCallouts
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForDimensionsAndHoleCallouts)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForDimensionsAndHoleCallouts,v)

    member _.swBackupAfterMeshOrRunSimulationStudy
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupAfterMeshOrRunSimulationStudy)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupAfterMeshOrRunSimulationStudy,v)

    member _.swIncludeDataForDelmia
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDataForDelmia)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDataForDelmia,v)

    member _.swWeldmentGenerateCutlistIDs
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentGenerateCutlistIDs)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentGenerateCutlistIDs,v)

    member _.swMultiCAD_ApplyOnlyToParts
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_ApplyOnlyToParts)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_ApplyOnlyToParts,v)

    member _.swMultiCAD_CreateNewComponentsAsExternalFiles
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_CreateNewComponentsAsExternalFiles)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_CreateNewComponentsAsExternalFiles,v)

    member _.swFeatureManagerShowTranslatedNameInFMTree
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerShowTranslatedNameInFMTree)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerShowTranslatedNameInFMTree,v)

    member _.swAutomaticSyncSettings
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticSyncSettings)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticSyncSettings,v)

    member _.swAutoSyncSettingsToInclude_SystemOptions
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_SystemOptions)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_SystemOptions,v)

    member _.swAutoSyncSettingsToInclude_FileLocations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_FileLocations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_FileLocations,v)

    member _.swAutoSyncSettingsToInclude_Customizations
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_Customizations)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_Customizations,v)

    member _.swEnable3DEXPERIENCEIntegration
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEIntegration)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEIntegration,v)

    member _.swShowCADFamilyConfigOnly3dexpIntegration
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADFamilyConfigOnly3dexpIntegration)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADFamilyConfigOnly3dexpIntegration,v)

    member _.swShowCADAndOtherConfig3dexpIntegration
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADAndOtherConfig3dexpIntegration)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADAndOtherConfig3dexpIntegration,v)

    member _.swEnable3DEXPERIENCEFileCompatibilityUpdate
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEFileCompatibilityUpdate)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEFileCompatibilityUpdate,v)

    member _.swImportNeutralAnalyticalConversion
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralAnalyticalConversion)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralAnalyticalConversion,v)

    member _.swUsePositiveInertiaTensorNotation
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUsePositiveInertiaTensorNotation)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUsePositiveInertiaTensorNotation,v)

    member _.swDisplayBendLines
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayBendLines)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayBendLines,v)

    member _.swTIFExportIncludeDrawingsPaperColor
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFExportIncludeDrawingsPaperColor)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFExportIncludeDrawingsPaperColor,v)

    member _.swPDFExportIncludeDrawingsPaperColor
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeDrawingsPaperColor)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeDrawingsPaperColor,v)

    member _.swSaveFileProperties
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFileProperties)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFileProperties,v)

    member _.swSaveFilePropertiesForEachComp
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFilePropertiesForEachComp)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFilePropertiesForEachComp,v)

    member _.swIncludeSketchData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSketchData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSketchData,v)

    member _.swSystemNotificationHideGraphicsNotification
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSystemNotificationHideGraphicsNotification)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSystemNotificationHideGraphicsNotification,v)

    member _.swDetailingModeSaveModelData
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeSaveModelData)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeSaveModelData,v)

    member _.swDetailingModeIncludeStandardViewsInViewPalette
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeIncludeStandardViewsInViewPalette)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeIncludeStandardViewsInViewPalette,v)

    member _.swStoreOLEImagesWithModel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreOLEImagesWithModel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreOLEImagesWithModel,v)

    member _.swDetailingAnnotationApplyNewCTDepthArchForToNewParts
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationApplyNewCTDepthArchForToNewParts)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationApplyNewCTDepthArchForToNewParts,v)

    member _.swCreateConfigurationTableOnOpen
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCreateConfigurationTableOnOpen)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCreateConfigurationTableOnOpen,v)

    member _.swExtRefForceSaveToCurrentVersion
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefForceSaveToCurrentVersion)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefForceSaveToCurrentVersion,v)

    member _.swDisplayTempAxesOnMouseHover
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTempAxesOnMouseHover)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTempAxesOnMouseHover,v)

    member _.swStepExportAtomicSave
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAtomicSave)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAtomicSave,v)

    member _.swStepExportAppearances
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAppearances)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAppearances,v)

    member _.swDisplayMeshBREPFacetFins
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMeshBREPFacetFins)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMeshBREPFacetFins,v)

    member _.swEdgesDefaultBulkSelection2
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection2)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection2,v)

    member _.swWeldmentUseEnglishDescriptionNameInCutlist
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentUseEnglishDescriptionNameInCutlist)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentUseEnglishDescriptionNameInCutlist,v)

    member _.swMultiCAD_3DInterconnectMaintainLinks
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectMaintainLinks)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectMaintainLinks,v)

    member _.swMultiCAD_3DInterconnectManualBreakLink
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectManualBreakLink)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectManualBreakLink,v)

    member _.swMultiCAD_3DInterconnectLinksFlag
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectLinksFlag)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectLinksFlag,v)

    member _.swSketchPreviewDimensionOnSelect
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPreviewDimensionOnSelect)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPreviewDimensionOnSelect,v)

    member _.swCollinearChainDimensionOffsetText
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionOffsetText)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionOffsetText,v)

    member _.swCollinearChainDimensionArrowHeadTermination
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionArrowHeadTermination)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionArrowHeadTermination,v)

    member _.swHardwareAccSilhouetteEdges
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHardwareAccSilhouetteEdges)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHardwareAccSilhouetteEdges,v)

    member _.swDispDimXpertDimOnTopOfModel
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDispDimXpertDimOnTopOfModel)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDispDimXpertDimOnTopOfModel,v)

    member _.swDimOverriddenHighlight
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimOverriddenHighlight)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimOverriddenHighlight,v)

    member _.swDetailingAngularRunningExtensionLineExtend
        with get () =
            swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningExtensionLineExtend)
        and set v =
            swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningExtensionLineExtend,v)
