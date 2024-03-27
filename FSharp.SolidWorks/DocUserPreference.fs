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
type DocUserPreference (swModel:IModelDoc2) =
    member _.swDetailingNoteFontHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingNoteFontHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingNoteFontHeight, int opt, value)
            |> ignore

    member _.swDetailingDimFontHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimFontHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimFontHeight, int opt, value)
            |> ignore

    member _.swSTLDeviation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSTLDeviation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSTLDeviation, int opt, value)
            |> ignore

    member _.swSTLAngleTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSTLAngleTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSTLAngleTolerance, int opt, value)
            |> ignore

    member _.swSpinBoxMetricLengthIncrement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxMetricLengthIncrement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxMetricLengthIncrement, int opt, value)
            |> ignore

    member _.swSpinBoxEnglishLengthIncrement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxEnglishLengthIncrement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxEnglishLengthIncrement, int opt, value)
            |> ignore

    member _.swSpinBoxAngleIncrement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxAngleIncrement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxAngleIncrement, int opt, value)
            |> ignore

    member _.swMaterialPropertyDensity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMaterialPropertyDensity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMaterialPropertyDensity, int opt, value)
            |> ignore

    member _.swTiffPrintPaperWidth
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintPaperWidth, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintPaperWidth, int opt, value)
            |> ignore

    member _.swTiffPrintDrawingPaperHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperHeight, int opt, value)
            |> ignore

    member _.swTiffPrintPaperHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintPaperHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintPaperHeight, int opt, value)
            |> ignore

    member _.swTiffPrintDrawingPaperWidth
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperWidth, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTiffPrintDrawingPaperWidth, int opt, value)
            |> ignore

    member _.swDetailingCenterlineExtension
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterlineExtension, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterlineExtension, int opt, value)
            |> ignore

    member _.swDetailingBreakLineGap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBreakLineGap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBreakLineGap, int opt, value)
            |> ignore

    member _.swDetailingCenterMarkSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkSize, int opt, value)
            |> ignore

    member _.swDetailingWitnessLineGap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineGap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineGap, int opt, value)
            |> ignore

    member _.swDetailingWitnessLineExtension
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineExtension, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingWitnessLineExtension, int opt, value)
            |> ignore

    member _.swDetailingObjectToDimOffset
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingObjectToDimOffset, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingObjectToDimOffset, int opt, value)
            |> ignore

    member _.swDetailingDimToDimOffset
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimToDimOffset, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimToDimOffset, int opt, value)
            |> ignore

    member _.swDetailingMaxLinearToleranceValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxLinearToleranceValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxLinearToleranceValue, int opt, value)
            |> ignore

    member _.swDetailingMinLinearToleranceValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMinLinearToleranceValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMinLinearToleranceValue, int opt, value)
            |> ignore

    member _.swDetailingMaxAngularToleranceValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxAngularToleranceValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxAngularToleranceValue, int opt, value)
            |> ignore

    member _.swDetailingMinAngularToleranceValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMinAngularToleranceValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMinAngularToleranceValue, int opt, value)
            |> ignore

    member _.swDetailingToleranceTextScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextScale, int opt, value)
            |> ignore

    member _.swDetailingToleranceTextHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceTextHeight, int opt, value)
            |> ignore

    member _.swDetailingNoteBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingNoteBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingNoteBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingArrowHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingArrowHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingArrowHeight, int opt, value)
            |> ignore

    member _.swDetailingArrowWidth
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingArrowWidth, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingArrowWidth, int opt, value)
            |> ignore

    member _.swDetailingArrowLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingArrowLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingArrowLength, int opt, value)
            |> ignore

    member _.swDetailingSectionArrowHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowHeight, int opt, value)
            |> ignore

    member _.swDetailingSectionArrowWidth
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowWidth, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowWidth, int opt, value)
            |> ignore

    member _.swDetailingSectionArrowLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSectionArrowLength, int opt, value)
            |> ignore

    member _.swGridMajorSpacing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swGridMajorSpacing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swGridMajorSpacing, int opt, value)
            |> ignore

    member _.swSnapToAngleValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSnapToAngleValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSnapToAngleValue, int opt, value)
            |> ignore

    member _.swImageQualityShadedDeviation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swImageQualityShadedDeviation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swImageQualityShadedDeviation, int opt, value)
            |> ignore

    member _.swDrawingDefaultSheetScaleNumerator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleNumerator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleNumerator, int opt, value)
            |> ignore

    member _.swDrawingDefaultSheetScaleDenominator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleDenominator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingDefaultSheetScaleDenominator, int opt, value)
            |> ignore

    member _.swDrawingDetailViewScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale, int opt, value)
            |> ignore

    member _.swViewRotationArrowKeys
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewRotationArrowKeys, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewRotationArrowKeys, int opt, value)
            |> ignore

    member _.swMateAnimationSpeed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMateAnimationSpeed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMateAnimationSpeed, int opt, value)
            |> ignore

    member _.swViewAnimationSpeed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewAnimationSpeed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewAnimationSpeed, int opt, value)
            |> ignore

    member _.swDetailingDimBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimBentLeaderLength, int opt, value)
            |> ignore

    member _.swMaterialPropertyCrosshatchScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchScale, int opt, value)
            |> ignore

    member _.swMaterialPropertyCrosshatchAngle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchAngle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMaterialPropertyCrosshatchAngle, int opt, value)
            |> ignore

    member _.swDrawingAreaHatchScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchScale, int opt, value)
            |> ignore

    member _.swDrawingAreaHatchAngle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchAngle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingAreaHatchAngle, int opt, value)
            |> ignore

    member _.swPageSetupPrinterTopMargin
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterTopMargin, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterTopMargin, int opt, value)
            |> ignore

    member _.swPageSetupPrinterBottomMargin
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterBottomMargin, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterBottomMargin, int opt, value)
            |> ignore

    member _.swPageSetupPrinterLeftMargin
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterLeftMargin, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterLeftMargin, int opt, value)
            |> ignore

    member _.swPageSetupPrinterRightMargin
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterRightMargin, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterRightMargin, int opt, value)
            |> ignore

    member _.swPageSetupPrinterThinLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThinLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThinLineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterNormalLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterNormalLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterNormalLineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterThickLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThickLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThickLineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterThick2LineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick2LineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick2LineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterThick3LineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick3LineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick3LineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterThick4LineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick4LineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick4LineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterThick5LineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick5LineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick5LineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterThick6LineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick6LineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterThick6LineWeight, int opt, value)
            |> ignore

    member _.swPageSetupPrinterDrawingScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterDrawingScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterDrawingScale, int opt, value)
            |> ignore

    member _.swPageSetupPrinterPartAsmScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterPartAsmScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPageSetupPrinterPartAsmScale, int opt, value)
            |> ignore

    member _.swCustomizedImportTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCustomizedImportTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCustomizedImportTolerance, int opt, value)
            |> ignore

    member _.swDetailingBalloonBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonBentLeaderLength, int opt, value)
            |> ignore

    member _.swBOMControlSplitHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swBOMControlSplitHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swBOMControlSplitHeight, int opt, value)
            |> ignore

    member _.swAnnotationTextScaleNumerator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleNumerator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleNumerator, int opt, value)
            |> ignore

    member _.swAnnotationTextScaleDenominator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleDenominator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swAnnotationTextScaleDenominator, int opt, value)
            |> ignore

    member _.swDetailingDimBreakGap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimBreakGap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimBreakGap, int opt, value)
            |> ignore

    member _.swCurvatureValue1
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue1, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue1, int opt, value)
            |> ignore

    member _.swCurvatureValue2
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue2, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue2, int opt, value)
            |> ignore

    member _.swCurvatureValue3
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue3, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue3, int opt, value)
            |> ignore

    member _.swCurvatureValue4
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue4, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue4, int opt, value)
            |> ignore

    member _.swCurvatureValue5
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue5, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swCurvatureValue5, int opt, value)
            |> ignore

    member _.swDetailingBreakLineExtension
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBreakLineExtension, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBreakLineExtension, int opt, value)
            |> ignore

    member _.swDetailingToleranceFitTolTextScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextScale, int opt, value)
            |> ignore

    member _.swDetailingToleranceFitTolTextHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingToleranceFitTolTextHeight, int opt, value)
            |> ignore

    member _.swDocumentColorAdvancedAmbient
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedAmbient, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedAmbient, int opt, value)
            |> ignore

    member _.swDocumentColorAdvancedDiffuse
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedDiffuse, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedDiffuse, int opt, value)
            |> ignore

    member _.swDocumentColorAdvancedSpecularity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedSpecularity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedSpecularity, int opt, value)
            |> ignore

    member _.swDocumentColorAdvancedShininess
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedShininess, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedShininess, int opt, value)
            |> ignore

    member _.swDocumentColorAdvancedTransparency
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedTransparency, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedTransparency, int opt, value)
            |> ignore

    member _.swDocumentColorAdvancedEmission
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedEmission, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDocumentColorAdvancedEmission, int opt, value)
            |> ignore

    member _.swDxfOutputScaleFactor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDxfOutputScaleFactor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDxfOutputScaleFactor, int opt, value)
            |> ignore

    member _.swHoleTableTagAngle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swHoleTableTagAngle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swHoleTableTagAngle, int opt, value)
            |> ignore

    member _.swHoleTableTagOffset
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swHoleTableTagOffset, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swHoleTableTagOffset, int opt, value)
            |> ignore

    member _.swDetailingMaxWitnessLineLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxWitnessLineLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxWitnessLineLength, int opt, value)
            |> ignore

    member _.swDrawingKeyboardMovementIncrement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingKeyboardMovementIncrement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDrawingKeyboardMovementIncrement, int opt, value)
            |> ignore

    member _.swSketchSnapsAngleValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSketchSnapsAngleValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSketchSnapsAngleValue, int opt, value)
            |> ignore

    member _.swDxfMergingDistance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDxfMergingDistance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDxfMergingDistance, int opt, value)
            |> ignore

    member _.swDetailingDimRadialSnapAngle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimRadialSnapAngle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDimRadialSnapAngle, int opt, value)
            |> ignore

    member _.swViewTransitionHideShowComponent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewTransitionHideShowComponent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewTransitionHideShowComponent, int opt, value)
            |> ignore

    member _.swViewTransitionIsolate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewTransitionIsolate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewTransitionIsolate, int opt, value)
            |> ignore

    member _.swLineFontVisibleEdgesThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontVisibleEdgesThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontVisibleEdgesThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontHiddenEdgesThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontHiddenEdgesThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontHiddenEdgesThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontSketchCurvesThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontSketchCurvesThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontSketchCurvesThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontDetailCircleThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontDetailCircleThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontDetailCircleThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontSectionLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontSectionLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontSectionLineThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontDimensionsThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontDimensionsThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontDimensionsThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontConstructionCurvesThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontConstructionCurvesThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontConstructionCurvesThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontCrosshatchThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontCrosshatchThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontCrosshatchThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontTangentEdgesThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontTangentEdgesThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontTangentEdgesThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontDetailBorderThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontDetailBorderThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontDetailBorderThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontCosmeticThreadThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontCosmeticThreadThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontCosmeticThreadThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontHideTangentEdgeThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontHideTangentEdgeThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontHideTangentEdgeThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontViewArrowThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontViewArrowThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontViewArrowThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontExplodedLinesThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontExplodedLinesThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontExplodedLinesThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontBreakLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontBreakLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontBreakLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingBalloonLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingBalloonFrameLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonFrameLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonFrameLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingDatumLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDatumLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDatumLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingDatumFrameLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDatumFrameLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingDatumFrameLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingGtolLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingGtolLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingGtolLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingGtolFrameLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingGtolFrameLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingGtolFrameLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingNoteLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingNoteLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingNoteLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingSFSymbolLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingWeldSymbolLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingWeldSymbolLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingWeldSymbolLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingAnnotationBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingAnnotationBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingAnnotationBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingGtolBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingGtolBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingGtolBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingSFSymbolBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingSFSymbolBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingMaxToleranceValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxToleranceValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMaxToleranceValue, int opt, value)
            |> ignore

    member _.swDetailingMinToleranceValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMinToleranceValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingMinToleranceValue, int opt, value)
            |> ignore

    member _.swSpinBoxTimeIncrement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxTimeIncrement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSpinBoxTimeIncrement, int opt, value)
            |> ignore

    member _.swDetailingBorderUserDefined
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderUserDefined, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderUserDefined, int opt, value)
            |> ignore

    member _.swDetailingBOMBalloonCustomSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonCustomSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonCustomSize, int opt, value)
            |> ignore

    member _.swDetailingBOMStackedBalloonCustomSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonCustomSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonCustomSize, int opt, value)
            |> ignore

    member _.swLineFontSpeedPakDrawingsModelEdgesThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontSpeedPakDrawingsModelEdgesThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontSpeedPakDrawingsModelEdgesThicknessCustom, int opt, value)
            |> ignore

    member _.swPartDimXpertLengthUnitTol1Value
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol1Value, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol1Value, int opt, value)
            |> ignore

    member _.swPartDimXpertLengthUnitTol2Value
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol2Value, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol2Value, int opt, value)
            |> ignore

    member _.swPartDimXpertLengthUnitTol3Value
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol3Value, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLengthUnitTol3Value, int opt, value)
            |> ignore

    member _.swPartDimXpertAngularUnitTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertAngularUnitTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertAngularUnitTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationDistanceTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationDistanceTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationDistanceTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationAngleTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationAngleTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertLocationAngleTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChainPatternLocTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChainPatternLocTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainPatternLocTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChainInnerTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChainInnerTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChainInnerTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricPrimaryTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPrimaryTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPrimaryTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricSecondFeatureSizeTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondFeatureSizeTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondFeatureSizeTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricSecondPlaneFeatureTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondPlaneFeatureTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSecondPlaneFeatureTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricThirdFeatureSizeTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdFeatureSizeTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdFeatureSizeTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricThirdPlaneFeatureTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdPlaneFeatureTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricThirdPlaneFeatureTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricPositionTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricPositionCompositeTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionCompositeTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricPositionCompositeTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricSurfaceProfileTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricSurfaceProfileCompositeTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileCompositeTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricSurfaceProfileCompositeTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricRunoutTolValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricRunoutTolValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertGeometricRunoutTolValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferWidthRatio
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferWidthRatio, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferWidthRatio, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferMaxWidth
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferMaxWidth, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferMaxWidth, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferDistanceTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferDistanceTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferDistanceTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferAngleTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferAngleTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertChamferAngleTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDiameterTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDiameterTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDiameterTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCounterboreDiameterTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkDiameterTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeCountersinkAngleTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeLengthSlotTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeWidthSlotTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDepthTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDepthTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeDepthTolLowerValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusTolUpperValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolUpperValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolUpperValue, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusTolLowerValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolLowerValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPartDimXpertSizeFilletRadiusTolLowerValue, int opt, value)
            |> ignore

    member _.swPunchTableTagAngle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPunchTableTagAngle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPunchTableTagAngle, int opt, value)
            |> ignore

    member _.swPunchTableTagOffset
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPunchTableTagOffset, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPunchTableTagOffset, int opt, value)
            |> ignore

    member _.swLineFontAdjoiningComponentCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontAdjoiningComponentCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontAdjoiningComponentCustom, int opt, value)
            |> ignore

    member _.swQuickViewTransparencyLevel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swQuickViewTransparencyLevel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swQuickViewTransparencyLevel, int opt, value)
            |> ignore

    member _.swDetailingRevisionCloudLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingRevisionCloudMaxArcRadius
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudMaxArcRadius, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingRevisionCloudMaxArcRadius, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesBorderSizeCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesBorderSizeCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesBorderSizeCustom, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalBendNotesLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingBorderAddPadding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderAddPadding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderAddPadding, int opt, value)
            |> ignore

    member _.swDetailingBOMBalloonPadding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonPadding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMBalloonPadding, int opt, value)
            |> ignore

    member _.swDetailingBOMStackedBalloonPadding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonPadding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBOMStackedBalloonPadding, int opt, value)
            |> ignore

    member _.swDetailingTablesHorizontalPadding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingTablesHorizontalPadding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingTablesHorizontalPadding, int opt, value)
            |> ignore

    member _.swDetailingTablesVerticalPadding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingTablesVerticalPadding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingTablesVerticalPadding, int opt, value)
            |> ignore

    member _.swLineFontBendLineUpThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontBendLineUpThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontBendLineUpThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontBendLineDownThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontBendLineDownThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontBendLineDownThicknessCustom, int opt, value)
            |> ignore

    member _.swLineFontEnvelopeComponentThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontEnvelopeComponentThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontEnvelopeComponentThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingCenterOfMassSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterOfMassSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterOfMassSize, int opt, value)
            |> ignore

    member _.swViewSelectorSpeed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewSelectorSpeed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swViewSelectorSpeed, int opt, value)
            |> ignore

    member _.swDetailingBalloonQtyGapDistance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonQtyGapDistance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBalloonQtyGapDistance, int opt, value)
            |> ignore

    member _.swDimensionsExtensionLineStyleThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDimensionsExtensionLineStyleThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDimensionsExtensionLineStyleThicknessCustom, int opt, value)
            |> ignore

    member _.swSmartMateSensitivity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSmartMateSensitivity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSmartMateSensitivity, int opt, value)
            |> ignore

    member _.swSystemTouchRotateWidth
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSystemTouchRotateWidth, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSystemTouchRotateWidth, int opt, value)
            |> ignore

    member _.swSystemTouchRotateVersusPanThreshhold
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSystemTouchRotateVersusPanThreshhold, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSystemTouchRotateVersusPanThreshhold, int opt, value)
            |> ignore

    member _.swDetailingParaSpacing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingParaSpacing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingParaSpacing, int opt, value)
            |> ignore

    member _.swTwistCountValuePerMeter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTwistCountValuePerMeter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swTwistCountValuePerMeter, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelFrameLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelFrameLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelFrameLineThicknessCustom, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelStyleCustomSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelStyleCustomSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelStyleCustomSize, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelPadding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelPadding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingLocationLabelPadding, int opt, value)
            |> ignore

    member _.swDetailingCenterMarkGap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkGap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingCenterMarkGap, int opt, value)
            |> ignore

    member _.swDetailingBorderLeaderCustomLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderLeaderCustomLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderLeaderCustomLineThickness, int opt, value)
            |> ignore

    member _.swDetailingBorderZoneDividerLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerLength, int opt, value)
            |> ignore

    member _.swDetailingBorderOuterCenterZoneDividerLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderOuterCenterZoneDividerLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderOuterCenterZoneDividerLength, int opt, value)
            |> ignore

    member _.swDetailingBorderInnerCenterZoneDividerLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderInnerCenterZoneDividerLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderInnerCenterZoneDividerLength, int opt, value)
            |> ignore

    member _.swDetailingBorderZoneDividerCustomLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerCustomLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingBorderZoneDividerCustomLineThickness, int opt, value)
            |> ignore

    member _.swDetailingOrdinateSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingOrdinateSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingOrdinateSize, int opt, value)
            |> ignore

    member _.swLineFontEmphasizedSectionThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontEmphasizedSectionThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swLineFontEmphasizedSectionThicknessCustom, int opt, value)
            |> ignore

    member _.swPrint3DBoxX
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPrint3DBoxX, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPrint3DBoxX, int opt, value)
            |> ignore

    member _.swPrint3DBoxY
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPrint3DBoxY, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPrint3DBoxY, int opt, value)
            |> ignore

    member _.swPrint3DBoxZ
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPrint3DBoxZ, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPrint3DBoxZ, int opt, value)
            |> ignore

    member _.swMatesMaximumDeviationForMisalignedMates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMatesMaximumDeviationForMisalignedMates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swMatesMaximumDeviationForMisalignedMates, int opt, value)
            |> ignore

    member _.swASMSLDPRT_ExcludeComponentsByVisibilityThreshold
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByVisibilityThreshold, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByVisibilityThreshold, int opt, value)
            |> ignore

    member _.swASMSLDPRT_ExcludeComponentsByBBoxVolumeThreshold
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByBBoxVolumeThreshold, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swASMSLDPRT_ExcludeComponentsByBBoxVolumeThreshold, int opt, value)
            |> ignore

    member _.swPLYDeviation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPLYDeviation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPLYDeviation, int opt, value)
            |> ignore

    member _.swPLYAngleTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPLYAngleTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swPLYAngleTolerance, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLeaderLineThicknessCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLineThicknessCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLineThicknessCustom, int opt, value)
            |> ignore

    member _.swSheetMetalMBDBorderSizeCustom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalMBDBorderSizeCustom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalMBDBorderSizeCustom, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swSheetMetalMBDLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingHatchDensityLimit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingHatchDensityLimit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceDouble(int swUserPreferenceDoubleValue_e.swDetailingHatchDensityLimit, int opt, value)
            |> ignore

    member _.swDxfVersion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfVersion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfVersion, int opt, value)
            |> ignore

    member _.swDxfOutputFonts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfOutputFonts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfOutputFonts, int opt, value)
            |> ignore

    member _.swDxfMappingFileIndex
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfMappingFileIndex, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfMappingFileIndex, int opt, value)
            |> ignore

    member _.swAutoSaveInterval
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAutoSaveInterval, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAutoSaveInterval, int opt, value)
            |> ignore

    member _.swResolveLightweight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swResolveLightweight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swResolveLightweight, int opt, value)
            |> ignore

    member _.swAcisOutputVersion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAcisOutputVersion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAcisOutputVersion, int opt, value)
            |> ignore

    member _.swTiffScreenOrPrintCapture
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffScreenOrPrintCapture, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffScreenOrPrintCapture, int opt, value)
            |> ignore

    member _.swTiffImageType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffImageType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffImageType, int opt, value)
            |> ignore

    member _.swTiffCompressionScheme
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffCompressionScheme, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffCompressionScheme, int opt, value)
            |> ignore

    member _.swTiffPrintDPI
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffPrintDPI, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffPrintDPI, int opt, value)
            |> ignore

    member _.swTiffPrintPaperSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffPrintPaperSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffPrintPaperSize, int opt, value)
            |> ignore

    member _.swTiffPrintScaleFactor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffPrintScaleFactor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTiffPrintScaleFactor, int opt, value)
            |> ignore

    member _.swCreateBodyFromSurfacesOption
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCreateBodyFromSurfacesOption, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCreateBodyFromSurfacesOption, int opt, value)
            |> ignore

    member _.swDetailingDimensionStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionStandard, int opt, value)
            |> ignore

    member _.swDetailingDualDimPosition
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDualDimPosition, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDualDimPosition, int opt, value)
            |> ignore

    member _.swDetailingDimTrailingZero
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimTrailingZero, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimTrailingZero, int opt, value)
            |> ignore

    member _.swDetailingArrowStyleForDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForDimensions, int opt, value)
            |> ignore

    member _.swDetailingDimensionArrowPosition
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionArrowPosition, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionArrowPosition, int opt, value)
            |> ignore

    member _.swDetailingLinearDimLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearDimLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearDimLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingRadialDimLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRadialDimLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRadialDimLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingAngularDimLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularDimLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularDimLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingLinearToleranceStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearToleranceStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearToleranceStyle, int opt, value)
            |> ignore

    member _.swDetailingAngularToleranceStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularToleranceStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularToleranceStyle, int opt, value)
            |> ignore

    member _.swDetailingToleranceTextSizing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceTextSizing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceTextSizing, int opt, value)
            |> ignore

    member _.swDetailingLinearDimPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearDimPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearDimPrecision, int opt, value)
            |> ignore

    member _.swDetailingLinearTolPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearTolPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearTolPrecision, int opt, value)
            |> ignore

    member _.swDetailingAltLinearDimPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAltLinearDimPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAltLinearDimPrecision, int opt, value)
            |> ignore

    member _.swDetailingAltLinearTolPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAltLinearTolPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAltLinearTolPrecision, int opt, value)
            |> ignore

    member _.swDetailingAngularDimPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularDimPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularDimPrecision, int opt, value)
            |> ignore

    member _.swDetailingAngularTolPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularTolPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularTolPrecision, int opt, value)
            |> ignore

    member _.swDetailingNoteTextAlignment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteTextAlignment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteTextAlignment, int opt, value)
            |> ignore

    member _.swDetailingNoteLeaderSide
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderSide, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderSide, int opt, value)
            |> ignore

    member _.swDetailingBalloonStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonStyle, int opt, value)
            |> ignore

    member _.swDetailingBalloonFit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonFit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonFit, int opt, value)
            |> ignore

    member _.swDetailingBOMBalloonStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonStyle, int opt, value)
            |> ignore

    member _.swDetailingBOMBalloonFit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonFit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMBalloonFit, int opt, value)
            |> ignore

    member _.swDetailingBOMUpperText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMUpperText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMUpperText, int opt, value)
            |> ignore

    member _.swDetailingBOMLowerText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMLowerText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMLowerText, int opt, value)
            |> ignore

    member _.swDetailingArrowStyleForEdgeVertexAttachment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForEdgeVertexAttachment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForEdgeVertexAttachment, int opt, value)
            |> ignore

    member _.swDetailingArrowStyleForFaceAttachment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForFaceAttachment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForFaceAttachment, int opt, value)
            |> ignore

    member _.swDetailingArrowStyleForUnattached
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForUnattached, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingArrowStyleForUnattached, int opt, value)
            |> ignore

    member _.swDetailingVirtualSharpStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingVirtualSharpStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingVirtualSharpStyle, int opt, value)
            |> ignore

    member _.swGridMinorLinesPerMajor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGridMinorLinesPerMajor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGridMinorLinesPerMajor, int opt, value)
            |> ignore

    member _.swSnapPointsPerMinor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSnapPointsPerMinor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSnapPointsPerMinor, int opt, value)
            |> ignore

    member _.swImageQualityShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImageQualityShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImageQualityShaded, int opt, value)
            |> ignore

    member _.swImageQualityWireframe
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImageQualityWireframe, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImageQualityWireframe, int opt, value)
            |> ignore

    member _.swImageQualityWireframeValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImageQualityWireframeValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImageQualityWireframeValue, int opt, value)
            |> ignore

    member _.swUnitsLinear
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinear, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinear, int opt, value)
            |> ignore

    member _.swUnitsLinearDecimalDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalDisplay, int opt, value)
            |> ignore

    member _.swUnitsLinearDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinearDecimalPlaces, int opt, value)
            |> ignore

    member _.swUnitsLinearFractionDenominator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinearFractionDenominator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsLinearFractionDenominator, int opt, value)
            |> ignore

    member _.swUnitsAngular
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsAngular, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsAngular, int opt, value)
            |> ignore

    member _.swUnitsAngularDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsAngularDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsAngularDecimalPlaces, int opt, value)
            |> ignore

    member _.swLineFontVisibleEdgesThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesThickness, int opt, value)
            |> ignore

    member _.swLineFontVisibleEdgesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesStyle, int opt, value)
            |> ignore

    member _.swLineFontHiddenEdgesThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesThickness, int opt, value)
            |> ignore

    member _.swLineFontHiddenEdgesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesStyle, int opt, value)
            |> ignore

    member _.swLineFontSketchCurvesThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesThickness, int opt, value)
            |> ignore

    member _.swLineFontSketchCurvesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesStyle, int opt, value)
            |> ignore

    member _.swLineFontDetailCircleThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleThickness, int opt, value)
            |> ignore

    member _.swLineFontDetailCircleStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailCircleStyle, int opt, value)
            |> ignore

    member _.swLineFontSectionLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSectionLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSectionLineThickness, int opt, value)
            |> ignore

    member _.swLineFontSectionLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSectionLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSectionLineStyle, int opt, value)
            |> ignore

    member _.swLineFontDimensionsThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDimensionsThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDimensionsThickness, int opt, value)
            |> ignore

    member _.swLineFontDimensionsStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDimensionsStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDimensionsStyle, int opt, value)
            |> ignore

    member _.swLineFontConstructionCurvesThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesThickness, int opt, value)
            |> ignore

    member _.swLineFontConstructionCurvesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontConstructionCurvesStyle, int opt, value)
            |> ignore

    member _.swLineFontCrosshatchThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchThickness, int opt, value)
            |> ignore

    member _.swLineFontCrosshatchStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCrosshatchStyle, int opt, value)
            |> ignore

    member _.swLineFontTangentEdgesThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesThickness, int opt, value)
            |> ignore

    member _.swLineFontTangentEdgesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontTangentEdgesStyle, int opt, value)
            |> ignore

    member _.swLineFontDetailBorderThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderThickness, int opt, value)
            |> ignore

    member _.swLineFontDetailBorderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontDetailBorderStyle, int opt, value)
            |> ignore

    member _.swLineFontCosmeticThreadThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadThickness, int opt, value)
            |> ignore

    member _.swLineFontCosmeticThreadStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontCosmeticThreadStyle, int opt, value)
            |> ignore

    member _.swStepAP
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swStepAP, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swStepAP, int opt, value)
            |> ignore

    member _.swHiddenEdgeDisplayDefault
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHiddenEdgeDisplayDefault, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHiddenEdgeDisplayDefault, int opt, value)
            |> ignore

    member _.swTangentEdgeDisplayDefault
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTangentEdgeDisplayDefault, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTangentEdgeDisplayDefault, int opt, value)
            |> ignore

    member _.swSTLQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSTLQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSTLQuality, int opt, value)
            |> ignore

    member _.swDrawingProjectionType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingProjectionType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingProjectionType, int opt, value)
            |> ignore

    member _.swDrawingPrintCrosshatchOutOfDateViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingPrintCrosshatchOutOfDateViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingPrintCrosshatchOutOfDateViews, int opt, value)
            |> ignore

    member _.swPerformanceAssemRebuildOnLoad
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPerformanceAssemRebuildOnLoad, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPerformanceAssemRebuildOnLoad, int opt, value)
            |> ignore

    member _.swLoadExternalReferences
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLoadExternalReferences, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLoadExternalReferences, int opt, value)
            |> ignore

    member _.swIGESRepresentation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIGESRepresentation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIGESRepresentation, int opt, value)
            |> ignore

    member _.swIGESSystem
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIGESSystem, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIGESSystem, int opt, value)
            |> ignore

    member _.swIGESCurveRepresentation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIGESCurveRepresentation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIGESCurveRepresentation, int opt, value)
            |> ignore

    member _.swViewRotationMouseSpeed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed, int opt, value)
            |> ignore

    member _.swBackupCopiesPerDocument
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBackupCopiesPerDocument, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBackupCopiesPerDocument, int opt, value)
            |> ignore

    member _.swCheckForOutOfDateLightweightComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCheckForOutOfDateLightweightComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCheckForOutOfDateLightweightComponents, int opt, value)
            |> ignore

    member _.swParasolidOutputVersion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swParasolidOutputVersion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swParasolidOutputVersion, int opt, value)
            |> ignore

    member _.swLineFontHideTangentEdgeThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeThickness, int opt, value)
            |> ignore

    member _.swLineFontHideTangentEdgeStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHideTangentEdgeStyle, int opt, value)
            |> ignore

    member _.swLineFontViewArrowThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontViewArrowThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontViewArrowThickness, int opt, value)
            |> ignore

    member _.swLineFontViewArrowStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontViewArrowStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontViewArrowStyle, int opt, value)
            |> ignore

    member _.swEdgesHiddenEdgeDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay, int opt, value)
            |> ignore

    member _.swEdgesTangentEdgeDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesTangentEdgeDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesTangentEdgeDisplay, int opt, value)
            |> ignore

    member _.swEdgesShadedModeDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesShadedModeDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesShadedModeDisplay, int opt, value)
            |> ignore

    member _.swDetailingBOMStackedBalloonStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonStyle, int opt, value)
            |> ignore

    member _.swDetailingBOMStackedBalloonFit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonFit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBOMStackedBalloonFit, int opt, value)
            |> ignore

    member _.swSystemColorsViewportBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground, int opt, value)
            |> ignore

    member _.swSystemColorsTopGradientColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTopGradientColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTopGradientColor, int opt, value)
            |> ignore

    member _.swSystemColorsBottomGradientColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsBottomGradientColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsBottomGradientColor, int opt, value)
            |> ignore

    member _.swSystemColorsDynamicHighlight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDynamicHighlight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDynamicHighlight, int opt, value)
            |> ignore

    member _.swSystemColorsHighlight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsHighlight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsHighlight, int opt, value)
            |> ignore

    member _.swSystemColorsSelectedItem1
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem1, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem1, int opt, value)
            |> ignore

    member _.swSystemColorsSelectedItem2
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem2, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem2, int opt, value)
            |> ignore

    member _.swSystemColorsSelectedItem3
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem3, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem3, int opt, value)
            |> ignore

    member _.swSystemColorsSelectedFaceShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedFaceShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedFaceShaded, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsVisibleModelEdge
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsVisibleModelEdge, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsVisibleModelEdge, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsHiddenModelEdge
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsHiddenModelEdge, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsHiddenModelEdge, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsPaperBorder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperBorder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperBorder, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsPaperShadow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperShadow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaperShadow, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsSheetBorder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSheetBorder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSheetBorder, int opt, value)
            |> ignore

    member _.swSystemColorsImportedDrivingAnnotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivingAnnotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivingAnnotation, int opt, value)
            |> ignore

    member _.swSystemColorsImportedDrivenAnnotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivenAnnotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsImportedDrivenAnnotation, int opt, value)
            |> ignore

    member _.swSystemColorsSketchOverDefined
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchOverDefined, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchOverDefined, int opt, value)
            |> ignore

    member _.swSystemColorsSketchFullyDefined
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchFullyDefined, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchFullyDefined, int opt, value)
            |> ignore

    member _.swSystemColorsSketchUnderDefined
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchUnderDefined, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchUnderDefined, int opt, value)
            |> ignore

    member _.swSystemColorsSketchInvalidGeometry
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInvalidGeometry, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInvalidGeometry, int opt, value)
            |> ignore

    member _.swSystemColorsSketchNotSolved
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchNotSolved, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchNotSolved, int opt, value)
            |> ignore

    member _.swSystemColorsGridLinesMinor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMinor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMinor, int opt, value)
            |> ignore

    member _.swSystemColorsGridLinesMajor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMajor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsGridLinesMajor, int opt, value)
            |> ignore

    member _.swSystemColorsConstructionGeometry
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsConstructionGeometry, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsConstructionGeometry, int opt, value)
            |> ignore

    member _.swSystemColorsDanglingDimension
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDanglingDimension, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDanglingDimension, int opt, value)
            |> ignore

    member _.swSystemColorsText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsText, int opt, value)
            |> ignore

    member _.swSystemColorsAssemblyEditPart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPart, int opt, value)
            |> ignore

    member _.swSystemColorsAssemblyEditPartHiddenLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPartHiddenLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyEditPartHiddenLines, int opt, value)
            |> ignore

    member _.swSystemColorsAssemblyNonEditPart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyNonEditPart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAssemblyNonEditPart, int opt, value)
            |> ignore

    member _.swSystemColorsInactiveEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveEntity, int opt, value)
            |> ignore

    member _.swSystemColorsTemporaryGraphics
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphics, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphics, int opt, value)
            |> ignore

    member _.swSystemColorsTemporaryGraphicsShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphicsShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTemporaryGraphicsShaded, int opt, value)
            |> ignore

    member _.swSystemColorsActiveSelectionListBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsActiveSelectionListBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsActiveSelectionListBox, int opt, value)
            |> ignore

    member _.swSystemColorsSurfacesOpenEdge
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSurfacesOpenEdge, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSurfacesOpenEdge, int opt, value)
            |> ignore

    member _.swSystemColorsTreeViewBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTreeViewBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTreeViewBackground, int opt, value)
            |> ignore

    member _.swAcisOutputUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAcisOutputUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAcisOutputUnits, int opt, value)
            |> ignore

    member _.swSystemColorsShadedEdge
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsShadedEdge, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsShadedEdge, int opt, value)
            |> ignore

    member _.swDxfOutputLineStyles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfOutputLineStyles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfOutputLineStyles, int opt, value)
            |> ignore

    member _.swDxfOutputNoScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfOutputNoScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfOutputNoScale, int opt, value)
            |> ignore

    member _.swPageSetupPrinterOrientation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPageSetupPrinterOrientation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPageSetupPrinterOrientation, int opt, value)
            |> ignore

    member _.swPageSetupPrinterDrawingColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPageSetupPrinterDrawingColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPageSetupPrinterDrawingColor, int opt, value)
            |> ignore

    member _.swImportCheckAndRepair
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportCheckAndRepair, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportCheckAndRepair, int opt, value)
            |> ignore

    member _.swUseCustomizedImportTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUseCustomizedImportTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUseCustomizedImportTolerance, int opt, value)
            |> ignore

    member _.swStepExportPreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swStepExportPreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swStepExportPreference, int opt, value)
            |> ignore

    member _.swEdgesInContextEditTransparencyType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparencyType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparencyType, int opt, value)
            |> ignore

    member _.swEdgesInContextEditTransparency
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparency, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdgesInContextEditTransparency, int opt, value)
            |> ignore

    member _.swPlaneDisplayFrontFaceColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayFrontFaceColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayFrontFaceColor, int opt, value)
            |> ignore

    member _.swPlaneDisplayBackFaceColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayBackFaceColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayBackFaceColor, int opt, value)
            |> ignore

    member _.swPlaneDisplayTransparency
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayTransparency, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayTransparency, int opt, value)
            |> ignore

    member _.swPlaneDisplayIntersectionLineColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayIntersectionLineColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPlaneDisplayIntersectionLineColor, int opt, value)
            |> ignore

    member _.swDetailingDatumDisplayType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumDisplayType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumDisplayType, int opt, value)
            |> ignore

    member _.swBOMConfigurationAnchorType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMConfigurationAnchorType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMConfigurationAnchorType, int opt, value)
            |> ignore

    member _.swBOMConfigurationWhatToShow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMConfigurationWhatToShow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMConfigurationWhatToShow, int opt, value)
            |> ignore

    member _.swBOMControlMissingRowDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMControlMissingRowDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMControlMissingRowDisplay, int opt, value)
            |> ignore

    member _.swBOMControlSplitDirection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMControlSplitDirection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBOMControlSplitDirection, int opt, value)
            |> ignore

    member _.swDetailingChamferDimLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingChamferDimLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingChamferDimLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingChamferDimTextStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingChamferDimTextStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingChamferDimTextStyle, int opt, value)
            |> ignore

    member _.swDetailingChamferDimXStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingChamferDimXStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingChamferDimXStyle, int opt, value)
            |> ignore

    member _.swDocumentColorFeatBend
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBend, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBend, int opt, value)
            |> ignore

    member _.swDocumentColorFeatBoss
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBoss, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatBoss, int opt, value)
            |> ignore

    member _.swDocumentColorFeatCavity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCavity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCavity, int opt, value)
            |> ignore

    member _.swDocumentColorFeatChamfer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatChamfer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatChamfer, int opt, value)
            |> ignore

    member _.swDocumentColorFeatCut
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCut, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatCut, int opt, value)
            |> ignore

    member _.swDocumentColorFeatLoftCut
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoftCut, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoftCut, int opt, value)
            |> ignore

    member _.swDocumentColorFeatSurfCut
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSurfCut, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSurfCut, int opt, value)
            |> ignore

    member _.swDocumentColorFeatSweepCut
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweepCut, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweepCut, int opt, value)
            |> ignore

    member _.swDocumentColorFeatWeldBead
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWeldBead, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWeldBead, int opt, value)
            |> ignore

    member _.swDocumentColorFeatExtrude
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatExtrude, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatExtrude, int opt, value)
            |> ignore

    member _.swDocumentColorFeatFillet
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatFillet, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatFillet, int opt, value)
            |> ignore

    member _.swDocumentColorFeatHole
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatHole, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatHole, int opt, value)
            |> ignore

    member _.swDocumentColorFeatLibrary
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLibrary, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLibrary, int opt, value)
            |> ignore

    member _.swDocumentColorFeatLoft
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoft, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatLoft, int opt, value)
            |> ignore

    member _.swDocumentColorFeatMidSurface
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatMidSurface, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatMidSurface, int opt, value)
            |> ignore

    member _.swDocumentColorFeatPattern
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatPattern, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatPattern, int opt, value)
            |> ignore

    member _.swDocumentColorFeatRefSurface
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRefSurface, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRefSurface, int opt, value)
            |> ignore

    member _.swDocumentColorFeatRevolution
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRevolution, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRevolution, int opt, value)
            |> ignore

    member _.swDocumentColorFeatShell
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShell, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShell, int opt, value)
            |> ignore

    member _.swDocumentColorFeatDerivedPart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDerivedPart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDerivedPart, int opt, value)
            |> ignore

    member _.swDocumentColorFeatSweep
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweep, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatSweep, int opt, value)
            |> ignore

    member _.swDocumentColorFeatThicken
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatThicken, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatThicken, int opt, value)
            |> ignore

    member _.swDocumentColorFeatRib
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRib, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatRib, int opt, value)
            |> ignore

    member _.swDocumentColorFeatDome
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDome, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatDome, int opt, value)
            |> ignore

    member _.swDocumentColorFeatForm
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatForm, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatForm, int opt, value)
            |> ignore

    member _.swDocumentColorFeatShape
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShape, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatShape, int opt, value)
            |> ignore

    member _.swDocumentColorFeatReplaceFace
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatReplaceFace, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatReplaceFace, int opt, value)
            |> ignore

    member _.swDocumentColorWireFrame
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorWireFrame, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorWireFrame, int opt, value)
            |> ignore

    member _.swDocumentColorShading
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorShading, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorShading, int opt, value)
            |> ignore

    member _.swDocumentColorHidden
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorHidden, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorHidden, int opt, value)
            |> ignore

    member _.swLineFontExplodedLinesThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesThickness, int opt, value)
            |> ignore

    member _.swLineFontExplodedLinesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontExplodedLinesStyle, int opt, value)
            |> ignore

    member _.swSystemColorsRefTriadX
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadX, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadX, int opt, value)
            |> ignore

    member _.swSystemColorsRefTriadY
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadY, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadY, int opt, value)
            |> ignore

    member _.swSystemColorsRefTriadZ
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadZ, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsRefTriadZ, int opt, value)
            |> ignore

    member _.swAcisOutputGeometryPreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAcisOutputGeometryPreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAcisOutputGeometryPreference, int opt, value)
            |> ignore

    member _.swSystemColorsDTDim
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDTDim, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDTDim, int opt, value)
            |> ignore

    member _.swLargeAsmModeThreshold
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeThreshold, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeThreshold, int opt, value)
            |> ignore

    member _.swLargeAsmModeAutoActivate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoActivate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoActivate, int opt, value)
            |> ignore

    member _.swLargeAsmModeCheckOutOfDateLightweight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeCheckOutOfDateLightweight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeCheckOutOfDateLightweight, int opt, value)
            |> ignore

    member _.swLargeAsmModeAutoRecoverCount
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoRecoverCount, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeAutoRecoverCount, int opt, value)
            |> ignore

    member _.swLargeAsmModeDisplayModeForNewDrawViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeDisplayModeForNewDrawViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeDisplayModeForNewDrawViews, int opt, value)
            |> ignore

    member _.swLineFontBreakLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBreakLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBreakLineThickness, int opt, value)
            |> ignore

    member _.swLineFontBreakLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBreakLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBreakLineStyle, int opt, value)
            |> ignore

    member _.swSaveAssemblyAsPartOptions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveAssemblyAsPartOptions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveAssemblyAsPartOptions, int opt, value)
            |> ignore

    member _.swDetailingDimensionTextAlignmentVertical
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentVertical, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentVertical, int opt, value)
            |> ignore

    member _.swDetailingDimensionTextAlignmentHorizontal
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentHorizontal, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAlignmentHorizontal, int opt, value)
            |> ignore

    member _.swDetailingToleranceFitTolTextSizing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolTextSizing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolTextSizing, int opt, value)
            |> ignore

    member _.swImportUnitPreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportUnitPreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportUnitPreference, int opt, value)
            |> ignore

    member _.swImportCurvePreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportCurvePreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportCurvePreference, int opt, value)
            |> ignore

    member _.swImportUseBrep
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportUseBrep, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportUseBrep, int opt, value)
            |> ignore

    member _.swImportStlVrmlModelType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportStlVrmlModelType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportStlVrmlModelType, int opt, value)
            |> ignore

    member _.swSystemColorsSelectedItem4
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem4, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem4, int opt, value)
            |> ignore

    member _.swImportStlVrmlUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportStlVrmlUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportStlVrmlUnits, int opt, value)
            |> ignore

    member _.swExportStlUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportStlUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportStlUnits, int opt, value)
            |> ignore

    member _.swExportVrmlUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportVrmlUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportVrmlUnits, int opt, value)
            |> ignore

    member _.swSystemColorsSketchInactive
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInactive, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSketchInactive, int opt, value)
            |> ignore

    member _.swExternalReferencesUpdateOutOfDateLinkedDesignTable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExternalReferencesUpdateOutOfDateLinkedDesignTable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExternalReferencesUpdateOutOfDateLinkedDesignTable, int opt, value)
            |> ignore

    member _.swSystemColorsTreeItemNormal
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemNormal, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemNormal, int opt, value)
            |> ignore

    member _.swSystemColorsTreeItemSelected
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemSelected, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTreeItemSelected, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsPaper
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaper, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsPaper, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsBackground, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsViewBorder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsViewBorder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsViewBorder, int opt, value)
            |> ignore

    member _.swDetailingNotesLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNotesLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNotesLeaderStyle, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsLockedFocus
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsLockedFocus, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsLockedFocus, int opt, value)
            |> ignore

    member _.swRevisionTableTagStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRevisionTableTagStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRevisionTableTagStyle, int opt, value)
            |> ignore

    member _.swRevisionTableSymbolShape
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRevisionTableSymbolShape, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRevisionTableSymbolShape, int opt, value)
            |> ignore

    member _.swBomTableZeroQuantityDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBomTableZeroQuantityDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBomTableZeroQuantityDisplay, int opt, value)
            |> ignore

    member _.swDocumentColorFeatStructuralMember
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatStructuralMember, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatStructuralMember, int opt, value)
            |> ignore

    member _.swDocumentColorFeatGusset
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatGusset, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatGusset, int opt, value)
            |> ignore

    member _.swDocumentColorFeatEndCap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatEndCap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatEndCap, int opt, value)
            |> ignore

    member _.swDetailingAutoBalloonLayout
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAutoBalloonLayout, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAutoBalloonLayout, int opt, value)
            |> ignore

    member _.swDocumentColorFeatWrap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWrap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDocumentColorFeatWrap, int opt, value)
            |> ignore

    member _.swRebuildOnActivation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRebuildOnActivation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRebuildOnActivation, int opt, value)
            |> ignore

    member _.swSystemColorsImportedAnnotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsImportedAnnotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsImportedAnnotation, int opt, value)
            |> ignore

    member _.swSystemColorsNonImportedAnnotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsNonImportedAnnotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsNonImportedAnnotation, int opt, value)
            |> ignore

    member _.swLevelOfDetail
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLevelOfDetail, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLevelOfDetail, int opt, value)
            |> ignore

    member _.swLargeAsmLevelOfDetail
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmLevelOfDetail, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmLevelOfDetail, int opt, value)
            |> ignore

    member _.swPropertyManagerColorDivider
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorDivider, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorDivider, int opt, value)
            |> ignore

    member _.swCollabCheckReadOnlyModifiedInterval
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCollabCheckReadOnlyModifiedInterval, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCollabCheckReadOnlyModifiedInterval, int opt, value)
            |> ignore

    member _.swEdrawingsSaveAsSelectionOption
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdrawingsSaveAsSelectionOption, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdrawingsSaveAsSelectionOption, int opt, value)
            |> ignore

    member _.swHoleTableOriginStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHoleTableOriginStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHoleTableOriginStandard, int opt, value)
            |> ignore

    member _.swHoleTableTagStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHoleTableTagStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHoleTableTagStyle, int opt, value)
            |> ignore

    member _.swHoleTableHoleLocationPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHoleTableHoleLocationPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swHoleTableHoleLocationPrecision, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_Name
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Name, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Name, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_Label
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Label, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Label, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_Scale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Scale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Scale, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_Delimiter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Delimiter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDetailViewLabels_Delimiter, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_Name
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Name, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Name, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_Label
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Label, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Label, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_Scale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Scale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Scale, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_Delimiter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Delimiter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLabels_Delimiter, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_Name
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Name, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Name, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_Label
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Label, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Label, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_Scale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Scale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Scale, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_Delimiter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Delimiter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxViewLabels_Delimiter, int opt, value)
            |> ignore

    member _.swDxfMultiSheetOption
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfMultiSheetOption, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDxfMultiSheetOption, int opt, value)
            |> ignore

    member _.swUnitsDualLinear
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinear, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinear, int opt, value)
            |> ignore

    member _.swUnitsDualLinearDecimalDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalDisplay, int opt, value)
            |> ignore

    member _.swUnitsDualLinearDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinearDecimalPlaces, int opt, value)
            |> ignore

    member _.swUnitsDualLinearFractionDenominator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinearFractionDenominator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDualLinearFractionDenominator, int opt, value)
            |> ignore

    member _.swUnitsMassPropLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropLength, int opt, value)
            |> ignore

    member _.swUnitsMassPropMass
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropMass, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropMass, int opt, value)
            |> ignore

    member _.swUnitsMassPropVolume
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropVolume, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropVolume, int opt, value)
            |> ignore

    member _.swUnitsMassPropDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsMassPropDecimalPlaces, int opt, value)
            |> ignore

    member _.swUnitsForce
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsForce, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsForce, int opt, value)
            |> ignore

    member _.swUnitSystem
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitSystem, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitSystem, int opt, value)
            |> ignore

    member _.swBendNoteStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendNoteStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendNoteStyle, int opt, value)
            |> ignore

    member _.swDetailingLeadingZero
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLeadingZero, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLeadingZero, int opt, value)
            |> ignore

    member _.swDetailingToleranceFitTolDisplayLinear
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayLinear, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayLinear, int opt, value)
            |> ignore

    member _.swDetailingToleranceFitTolDisplayAngular
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayAngular, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplayAngular, int opt, value)
            |> ignore

    member _.swMaterialPropertyAreaHatchFillStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swMaterialPropertyAreaHatchFillStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swMaterialPropertyAreaHatchFillStyle, int opt, value)
            |> ignore

    member _.swDrawingAreaHatchFillStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingAreaHatchFillStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingAreaHatchFillStyle, int opt, value)
            |> ignore

    member _.swPerformanceViewsToDraftQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPerformanceViewsToDraftQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPerformanceViewsToDraftQuality, int opt, value)
            |> ignore

    member _.swFeatureManagerDisplayWarnings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDisplayWarnings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDisplayWarnings, int opt, value)
            |> ignore

    member _.swSheetMetalColorBendLinesUp
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesUp, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesUp, int opt, value)
            |> ignore

    member _.swSheetMetalColorBendLinesDown
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesDown, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesDown, int opt, value)
            |> ignore

    member _.swSheetMetalColorFormFeature
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorFormFeature, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorFormFeature, int opt, value)
            |> ignore

    member _.swSheetMetalColorBendLinesHems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesHems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBendLinesHems, int opt, value)
            |> ignore

    member _.swSheetMetalColorModelEdges
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorModelEdges, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorModelEdges, int opt, value)
            |> ignore

    member _.swSystemColorsDimsNotMarkedForDrawing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDimsNotMarkedForDrawing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDimsNotMarkedForDrawing, int opt, value)
            |> ignore

    member _.swSystemColorsAsmInterferenceVolume
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAsmInterferenceVolume, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsAsmInterferenceVolume, int opt, value)
            |> ignore

    member _.swSystemColorsSwiftAnnotations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftAnnotations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftAnnotations, int opt, value)
            |> ignore

    member _.swSystemColorsSwiftUnderConstrained
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftUnderConstrained, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftUnderConstrained, int opt, value)
            |> ignore

    member _.swSystemColorsSwiftFullyConstrained
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftFullyConstrained, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftFullyConstrained, int opt, value)
            |> ignore

    member _.swSystemColorsSwiftOverConstrained
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftOverConstrained, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSwiftOverConstrained, int opt, value)
            |> ignore

    member _.swSystemColorsToleranceAnalysisDim
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsToleranceAnalysisDim, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsToleranceAnalysisDim, int opt, value)
            |> ignore

    member _.swSystemColorsPropertyManagerColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsPropertyManagerColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsPropertyManagerColor, int opt, value)
            |> ignore

    member _.swPropertyManagerColorBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorBackground, int opt, value)
            |> ignore

    member _.swPropertyManagerColorActiveClosedDivider
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorActiveClosedDivider, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorActiveClosedDivider, int opt, value)
            |> ignore

    member _.swPropertyManagerColorEditBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditBox, int opt, value)
            |> ignore

    member _.swPropertyManagerColorEditText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorEditText, int opt, value)
            |> ignore

    member _.swPropertyManagerColorLabelAndIcon
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorLabelAndIcon, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorLabelAndIcon, int opt, value)
            |> ignore

    member _.swPropertyManagerColorTitle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTitle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTitle, int opt, value)
            |> ignore

    member _.swPropertyManagerColorOuterBorder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorOuterBorder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorOuterBorder, int opt, value)
            |> ignore

    member _.swPropertyManagerColorInnerBorder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorInnerBorder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorInnerBorder, int opt, value)
            |> ignore

    member _.swPropertyManagerColorTopBorder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTopBorder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorTopBorder, int opt, value)
            |> ignore

    member _.swPropertyManagerColorImportantMessage
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorImportantMessage, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyManagerColorImportantMessage, int opt, value)
            |> ignore

    member _.swSystemColorsHiddenEdgeSelectionShow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsHiddenEdgeSelectionShow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsHiddenEdgeSelectionShow, int opt, value)
            |> ignore

    member _.swDetailingForeshortenedDiameterStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingForeshortenedDiameterStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingForeshortenedDiameterStyle, int opt, value)
            |> ignore

    member _.swRevisionTableMultipleSheetStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRevisionTableMultipleSheetStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRevisionTableMultipleSheetStyle, int opt, value)
            |> ignore

    member _.swUndoStepsMaximum
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUndoStepsMaximum, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUndoStepsMaximum, int opt, value)
            |> ignore

    member _.swDetailingDimFractionStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimFractionStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimFractionStyle, int opt, value)
            |> ignore

    member _.swDetailingDimFractionScaleIndex
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimFractionScaleIndex, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimFractionScaleIndex, int opt, value)
            |> ignore

    member _.swAutoSaveIntervalMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAutoSaveIntervalMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAutoSaveIntervalMode, int opt, value)
            |> ignore

    member _.swBackupRemoveInterval
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBackupRemoveInterval, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBackupRemoveInterval, int opt, value)
            |> ignore

    member _.swSaveReminderInterval
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveReminderInterval, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveReminderInterval, int opt, value)
            |> ignore

    member _.swSaveReminderIntervalMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveReminderIntervalMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveReminderIntervalMode, int opt, value)
            |> ignore

    member _.swColorsBackgroundAppearance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swColorsBackgroundAppearance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swColorsBackgroundAppearance, int opt, value)
            |> ignore

    member _.swRebuildErrorAction
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRebuildErrorAction, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRebuildErrorAction, int opt, value)
            |> ignore

    member _.swSheetMetalColorFlatPatternSketch
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorFlatPatternSketch, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorFlatPatternSketch, int opt, value)
            |> ignore

    member _.swLineFontVisibleEdgesEndCap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesEndCap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontVisibleEdgesEndCap, int opt, value)
            |> ignore

    member _.swLineFontHiddenEdgesEndCap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesEndCap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontHiddenEdgesEndCap, int opt, value)
            |> ignore

    member _.swLineFontSketchCurvesEndCap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesEndCap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSketchCurvesEndCap, int opt, value)
            |> ignore

    member _.swDetailingDimXpertChamferScheme
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferScheme, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferScheme, int opt, value)
            |> ignore

    member _.swDetailingDimXpertSlotScheme
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertSlotScheme, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertSlotScheme, int opt, value)
            |> ignore

    member _.swDetailingDimXpertFilletOptions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertFilletOptions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertFilletOptions, int opt, value)
            |> ignore

    member _.swDetailingDimXpertChamferOptions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferOptions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimXpertChamferOptions, int opt, value)
            |> ignore

    member _.swSystemColorsGhostSelColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsGhostSelColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsGhostSelColor, int opt, value)
            |> ignore

    member _.swFeatureManagerBlocksVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerBlocksVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerBlocksVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerDesignBinderVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignBinderVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignBinderVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerAnnotationsVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerAnnotationsVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerAnnotationsVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerLightsVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerLightsVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerLightsVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerSolidBodiesVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSolidBodiesVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSolidBodiesVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerSurfaceBodiesVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSurfaceBodiesVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSurfaceBodiesVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerEquationsVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerEquationsVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerEquationsVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerMaterialVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMaterialVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMaterialVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerDefaultPlanesVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDefaultPlanesVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDefaultPlanesVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerOriginVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerOriginVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerOriginVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerMateReferencesVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMateReferencesVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMateReferencesVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerDesignTableVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignTableVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerDesignTableVisibility, int opt, value)
            |> ignore

    member _.swSearchResultsPerPage
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchResultsPerPage, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchResultsPerPage, int opt, value)
            |> ignore

    member _.swSearchMaxResultsPerDataSource
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchMaxResultsPerDataSource, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchMaxResultsPerDataSource, int opt, value)
            |> ignore

    member _.swUnitsForceDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsForceDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsForceDecimalPlaces, int opt, value)
            |> ignore

    member _.swUnitsEnergyUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsEnergyUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsEnergyUnits, int opt, value)
            |> ignore

    member _.swUnitsEnergyDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsEnergyDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsEnergyDecimalPlaces, int opt, value)
            |> ignore

    member _.swUnitsPowerUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsPowerUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsPowerUnits, int opt, value)
            |> ignore

    member _.swUnitsPowerDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsPowerDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsPowerDecimalPlaces, int opt, value)
            |> ignore

    member _.swUnitsTimeUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsTimeUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsTimeUnits, int opt, value)
            |> ignore

    member _.swUnitsTimeDecimalPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsTimeDecimalPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsTimeDecimalPlaces, int opt, value)
            |> ignore

    member _.swSystemColorsInactiveHandles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveHandles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsInactiveHandles, int opt, value)
            |> ignore

    member _.swPropertyMgrDockingState
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyMgrDockingState, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPropertyMgrDockingState, int opt, value)
            |> ignore

    member _.swDetailingBalloonLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingBalloonLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineStyle, int opt, value)
            |> ignore

    member _.swDetailingBalloonLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonLeaderLineThickness, int opt, value)
            |> ignore

    member _.swDetailingBalloonFrameLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineStyle, int opt, value)
            |> ignore

    member _.swDetailingBalloonFrameLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonFrameLineThickness, int opt, value)
            |> ignore

    member _.swDetailingDatumLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineStyle, int opt, value)
            |> ignore

    member _.swDetailingDatumLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumLeaderLineThickness, int opt, value)
            |> ignore

    member _.swDetailingDatumFrameLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineStyle, int opt, value)
            |> ignore

    member _.swDetailingDatumFrameLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumFrameLineThickness, int opt, value)
            |> ignore

    member _.swDetailingGtolLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingGtolLeaderSide
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderSide, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderSide, int opt, value)
            |> ignore

    member _.swDetailingGtolLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineStyle, int opt, value)
            |> ignore

    member _.swDetailingGtolLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolLeaderLineThickness, int opt, value)
            |> ignore

    member _.swDetailingGtolFrameLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineStyle, int opt, value)
            |> ignore

    member _.swDetailingGtolFrameLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolFrameLineThickness, int opt, value)
            |> ignore

    member _.swDetailingNoteLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineStyle, int opt, value)
            |> ignore

    member _.swDetailingNoteLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingNoteLeaderLineThickness, int opt, value)
            |> ignore

    member _.swDetailingSFSymbolLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingSFSymbolLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineStyle, int opt, value)
            |> ignore

    member _.swDetailingSFSymbolLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSFSymbolLeaderLineThickness, int opt, value)
            |> ignore

    member _.swDetailingWeldSymbolLeaderSide
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderSide, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderSide, int opt, value)
            |> ignore

    member _.swDetailingWeldSymbolLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineStyle, int opt, value)
            |> ignore

    member _.swDetailingWeldSymbolLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldSymbolLeaderLineThickness, int opt, value)
            |> ignore

    member _.swDetailingGeneralTableBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableBorderLineWeight, int opt, value)
            |> ignore

    member _.swDetailingGeneralTableGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGeneralTableGridLineWeight, int opt, value)
            |> ignore

    member _.swDetailingBillOfMaterialBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialBorderLineWeight, int opt, value)
            |> ignore

    member _.swDetailingBillOfMaterialGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBillOfMaterialGridLineWeight, int opt, value)
            |> ignore

    member _.swDetailingHoleTableBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingHoleTableBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingHoleTableBorderLineWeight, int opt, value)
            |> ignore

    member _.swDetailingHoleTableGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingHoleTableGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingHoleTableGridLineWeight, int opt, value)
            |> ignore

    member _.swDetailingRevisionTableBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableBorderLineWeight, int opt, value)
            |> ignore

    member _.swDetailingRevisionTableGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionTableGridLineWeight, int opt, value)
            |> ignore

    member _.swDetailingDimensionTextAndLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAndLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDimensionTextAndLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingToleranceStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceStyle, int opt, value)
            |> ignore

    member _.swDetailingToleranceFitTolDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingToleranceFitTolDisplay, int opt, value)
            |> ignore

    member _.swFeatureManagerSensorVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSensorVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSensorVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerTableFolderVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerTableFolderVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerTableFolderVisibility, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsSpeedPakModelEdge
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSpeedPakModelEdge, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsSpeedPakModelEdge, int opt, value)
            |> ignore

    member _.swFeatureManagerConfigTableFolderVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerConfigTableFolderVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerConfigTableFolderVisibility, int opt, value)
            |> ignore

    member _.swDetailingDatumGbLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumGbLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingDatumGbLeaderStyle, int opt, value)
            |> ignore

    member _.swDetailingTitleBlockTableBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableBorderLineWeight, int opt, value)
            |> ignore

    member _.swDetailingTitleBlockTableGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTitleBlockTableGridLineWeight, int opt, value)
            |> ignore

    member _.swExportVrmlVersion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportVrmlVersion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportVrmlVersion, int opt, value)
            |> ignore

    member _.swExportJpegCompression
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportJpegCompression, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportJpegCompression, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsModelTangentEdges
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsModelTangentEdges, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsModelTangentEdges, int opt, value)
            |> ignore

    member _.swSystemColorsMateCalloutHealthy
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutHealthy, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutHealthy, int opt, value)
            |> ignore

    member _.swSystemColorsMateCalloutWarning
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutWarning, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutWarning, int opt, value)
            |> ignore

    member _.swSystemColorsMateCalloutError
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutError, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMateCalloutError, int opt, value)
            |> ignore

    member _.swCenterLineMarkOrient
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCenterLineMarkOrient, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCenterLineMarkOrient, int opt, value)
            |> ignore

    member _.swLineFontSpeedPakDrawingsModelEdgesThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesThickness, int opt, value)
            |> ignore

    member _.swLineFontSpeedPakDrawingsModelEdgesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontSpeedPakDrawingsModelEdgesStyle, int opt, value)
            |> ignore

    member _.swDisplayStateCreationChoice
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDisplayStateCreationChoice, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDisplayStateCreationChoice, int opt, value)
            |> ignore

    member _.swSystemColorsSheetMetalTemporaryGraphics
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSheetMetalTemporaryGraphics, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSheetMetalTemporaryGraphics, int opt, value)
            |> ignore

    member _.swSystemColorsMeasureSelection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMeasureSelection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsMeasureSelection, int opt, value)
            |> ignore

    member _.swPartDimXpertLengthUnitTol1Decimals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol1Decimals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol1Decimals, int opt, value)
            |> ignore

    member _.swPartDimXpertLengthUnitTol2Decimals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol2Decimals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol2Decimals, int opt, value)
            |> ignore

    member _.swPartDimXpertLengthUnitTol3Decimals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol3Decimals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLengthUnitTol3Decimals, int opt, value)
            |> ignore

    member _.swPartDimXpertGeneralToleranceClass
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertGeneralToleranceClass, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertGeneralToleranceClass, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationDistanceTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationAngleTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationDistanceBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationDistanceBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationAngleBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertLocationAngleBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertChainPatternLocTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertChainInnerTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainInnerTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainInnerTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertChainPatternLocBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainPatternLocBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertChainDistanceBwtnFeatBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainDistanceBwtnFeatBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChainDistanceBwtnFeatBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferDistanceTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferAngleTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferDistanceBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferDistanceBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertChamferAngleBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertChamferAngleBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDiameterTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDepthTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusTolType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusTolType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusTolType, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDiameterBlockPrecsion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterBlockPrecsion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDiameterBlockPrecsion, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCounterboreDiameterBlockPrecsion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterBlockPrecsion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCounterboreDiameterBlockPrecsion, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkDiameterBlockPrecsion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterBlockPrecsion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkDiameterBlockPrecsion, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeCountersinkAngleBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeCountersinkAngleBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeLengthSlotBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeLengthSlotBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeWidthSlotBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeWidthSlotBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeDepthBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeDepthBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertSizeFilletRadiusBlockPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusBlockPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertSizeFilletRadiusBlockPrecision, int opt, value)
            |> ignore

    member _.swPartDimXpertDisplaySlotDimensionType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplaySlotDimensionType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplaySlotDimensionType, int opt, value)
            |> ignore

    member _.swPartDimXpertDisplayHoleDimensionType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayHoleDimensionType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayHoleDimensionType, int opt, value)
            |> ignore

    member _.swPartDimXpertDisplayGtolLinearDimAttachment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayGtolLinearDimAttachment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayGtolLinearDimAttachment, int opt, value)
            |> ignore

    member _.swPartDimXpertDisplayDatumGtolSurfaceAttachment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolSurfaceAttachment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolSurfaceAttachment, int opt, value)
            |> ignore

    member _.swPartDimXpertDisplayDatumGtolLinearDimAttachment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolLinearDimAttachment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPartDimXpertDisplayDatumGtolLinearDimAttachment, int opt, value)
            |> ignore

    member _.swExportIFCUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportIFCUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportIFCUnits, int opt, value)
            |> ignore

    member _.swDetailingOrthoViewLabels_Scale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Scale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Scale, int opt, value)
            |> ignore

    member _.swDetailingOrthoViewLabels_Delimiter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Delimiter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingOrthoViewLabels_Delimiter, int opt, value)
            |> ignore

    member _.swSystemOptionDisplayAntiAliasing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemOptionDisplayAntiAliasing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemOptionDisplayAntiAliasing, int opt, value)
            |> ignore

    member _.swTableHoleDualDimensionPos
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTableHoleDualDimensionPos, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTableHoleDualDimensionPos, int opt, value)
            |> ignore

    member _.swSystemColorsDrawingsChangedDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsChangedDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsDrawingsChangedDimensions, int opt, value)
            |> ignore

    member _.swDetailingBendTableBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBendTableBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBendTableBorderLineWeight, int opt, value)
            |> ignore

    member _.swDetailingBendTableGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBendTableGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBendTableGridLineWeight, int opt, value)
            |> ignore

    member _.swBendLeadingZero
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendLeadingZero, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendLeadingZero, int opt, value)
            |> ignore

    member _.swBendTableZeroQuantityDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendTableZeroQuantityDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendTableZeroQuantityDisplay, int opt, value)
            |> ignore

    member _.swBendInnerRadiusPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendInnerRadiusPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendInnerRadiusPrecision, int opt, value)
            |> ignore

    member _.swBendAngularPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendAngularPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendAngularPrecision, int opt, value)
            |> ignore

    member _.swBendTableTagStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendTableTagStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendTableTagStyle, int opt, value)
            |> ignore

    member _.swPunchTableOriginStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPunchTableOriginStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPunchTableOriginStandard, int opt, value)
            |> ignore

    member _.swPunchTableLocationPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPunchTableLocationPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPunchTableLocationPrecision, int opt, value)
            |> ignore

    member _.swTablePunchDualDimensionPos
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTablePunchDualDimensionPos, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTablePunchDualDimensionPos, int opt, value)
            |> ignore

    member _.swPunchTableTagStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPunchTableTagStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPunchTableTagStyle, int opt, value)
            |> ignore

    member _.swDetailingSectionArrowStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionArrowStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionArrowStyle, int opt, value)
            |> ignore

    member _.swPerformanceFeedback
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPerformanceFeedback, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPerformanceFeedback, int opt, value)
            |> ignore

    member _.swLineFontAdjoiningComponent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponent, int opt, value)
            |> ignore

    member _.swLineFontAdjoiningComponentStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponentStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontAdjoiningComponentStyle, int opt, value)
            |> ignore

    member _.swSystemColorsNoteHandle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsNoteHandle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsNoteHandle, int opt, value)
            |> ignore

    member _.swSystemColorsCrossHair
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsCrossHair, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsCrossHair, int opt, value)
            |> ignore

    member _.swSystemColorsNoteEditHandle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsNoteEditHandle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsNoteEditHandle, int opt, value)
            |> ignore

    member _.swSystemColorsTemporarySketchDragging
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTemporarySketchDragging, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsTemporarySketchDragging, int opt, value)
            |> ignore

    member _.swSystemColorsWeldPathSelection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsWeldPathSelection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsWeldPathSelection, int opt, value)
            |> ignore

    member _.swDetailingPunchTableBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingPunchTableBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingPunchTableBorderLineWeight, int opt, value)
            |> ignore

    member _.swShowEquationCircularReferencesMessage
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swShowEquationCircularReferencesMessage, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swShowEquationCircularReferencesMessage, int opt, value)
            |> ignore

    member _.swDetailingPunchTableGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingPunchTableGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingPunchTableGridLineWeight, int opt, value)
            |> ignore

    member _.swDetailingWeldTableGridLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldTableGridLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldTableGridLineWeight, int opt, value)
            |> ignore

    member _.swDetailingWeldTableBorderLineWeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldTableBorderLineWeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingWeldTableBorderLineWeight, int opt, value)
            |> ignore

    member _.swSearchIndexingPerformance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchIndexingPerformance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchIndexingPerformance, int opt, value)
            |> ignore

    member _.swLargeAsmModeLargeDesignReviewThreshhold
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeLargeDesignReviewThreshhold, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLargeAsmModeLargeDesignReviewThreshhold, int opt, value)
            |> ignore

    member _.swShowEquationPotentialCircularReferencesMessage
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swShowEquationPotentialCircularReferencesMessage, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swShowEquationPotentialCircularReferencesMessage, int opt, value)
            |> ignore

    member _.swSaveReminderAutoDismissInterval
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveReminderAutoDismissInterval, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveReminderAutoDismissInterval, int opt, value)
            |> ignore

    member _.swDetailingRevisionCloudLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineStyle, int opt, value)
            |> ignore

    member _.swDetailingRevisionCloudLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRevisionCloudLineThickness, int opt, value)
            |> ignore

    member _.swDetailingHalfSectionArrow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingHalfSectionArrow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingHalfSectionArrow, int opt, value)
            |> ignore

    member _.swBendAllowancePrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendAllowancePrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBendAllowancePrecision, int opt, value)
            |> ignore

    member _.swFeatureManagerFavorites
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerFavorites, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerFavorites, int opt, value)
            |> ignore

    member _.swFeatureManagerEDrawingMarkups
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerEDrawingMarkups, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerEDrawingMarkups, int opt, value)
            |> ignore

    member _.swSheetMetalColorBoundingBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBoundingBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalColorBoundingBox, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineStyle, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderLineThickness, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesBorderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderStyle, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesBorderSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesBorderSize, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesTextAlignment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesTextAlignment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesTextAlignment, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLeaderAnchor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderAnchor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderAnchor, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLeaderDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalBendNotesLeaderDisplay, int opt, value)
            |> ignore

    member _.swSystemColorsCurrentColorScheme
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsCurrentColorScheme, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsCurrentColorScheme, int opt, value)
            |> ignore

    member _.swSystemColorsEnvelopes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsEnvelopes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsEnvelopes, int opt, value)
            |> ignore

    member _.swDetailingRadialDimsArrowPlacement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRadialDimsArrowPlacement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingRadialDimsArrowPlacement, int opt, value)
            |> ignore

    member _.swSearchDissectionDailyStartTime
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStartTime, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStartTime, int opt, value)
            |> ignore

    member _.swSearchDissectionDailyStopTime
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStopTime, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSearchDissectionDailyStopTime, int opt, value)
            |> ignore

    member _.swLineFontBendLineUpStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpStyle, int opt, value)
            |> ignore

    member _.swLineFontBendLineDownStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownStyle, int opt, value)
            |> ignore

    member _.swLineFontEnvelopeComponentStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentStyle, int opt, value)
            |> ignore

    member _.swLineFontBendLineUpThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineUpThickness, int opt, value)
            |> ignore

    member _.swLineFontBendLineDownThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontBendLineDownThickness, int opt, value)
            |> ignore

    member _.swLineFontEnvelopeComponentThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEnvelopeComponentThickness, int opt, value)
            |> ignore

    member _.swEnvelopeComponentColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEnvelopeComponentColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEnvelopeComponentColor, int opt, value)
            |> ignore

    member _.swAssemblyVisualizationComponentColor1
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor1, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor1, int opt, value)
            |> ignore

    member _.swAssemblyVisualizationComponentColor2
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor2, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor2, int opt, value)
            |> ignore

    member _.swAssemblyVisualizationComponentColor3
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor3, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor3, int opt, value)
            |> ignore

    member _.swAssemblyVisualizationComponentColor4
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor4, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor4, int opt, value)
            |> ignore

    member _.swAssemblyVisualizationComponentColor5
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor5, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor5, int opt, value)
            |> ignore

    member _.swAssemblyVisualizationComponentColor6
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor6, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyVisualizationComponentColor6, int opt, value)
            |> ignore

    member _.swDetailingMiscView_Scale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Scale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Scale, int opt, value)
            |> ignore

    member _.swDetailingMiscView_Delimiter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Delimiter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Delimiter, int opt, value)
            |> ignore

    member _.swDetailingMiscView_Name
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Name, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingMiscView_Name, int opt, value)
            |> ignore

    member _.swDetailingAuxView_ViewIndication
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxView_ViewIndication, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxView_ViewIndication, int opt, value)
            |> ignore

    member _.swDetailingAuxView_Rotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxView_Rotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAuxView_Rotation, int opt, value)
            |> ignore

    member _.swDetailingSectionView_Rotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionView_Rotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionView_Rotation, int opt, value)
            |> ignore

    member _.swDimensionsExtensionLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyle, int opt, value)
            |> ignore

    member _.swDimensionsExtensionLineStyleThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyleThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDimensionsExtensionLineStyleThickness, int opt, value)
            |> ignore

    member _.swDetailingOrthoView_Name
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingOrthoView_Name, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingOrthoView_Name, int opt, value)
            |> ignore

    member _.swAssemblyOpenMessagesDismissTime
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyOpenMessagesDismissTime, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyOpenMessagesDismissTime, int opt, value)
            |> ignore

    member _.swButtonSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swButtonSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swButtonSize, int opt, value)
            |> ignore

    member _.swTextSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTextSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTextSize, int opt, value)
            |> ignore

    member _.swUnitsDecimalRounding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDecimalRounding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUnitsDecimalRounding, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelFrameLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineStyle, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelFrameLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFrameLineThickness, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelStyle, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelFit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelFit, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelUpperText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelUpperText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelUpperText, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelLowerText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelLowerText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLocationLabelLowerText, int opt, value)
            |> ignore

    member _.swDrawingSheetsZonesOrigin
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesOrigin, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesOrigin, int opt, value)
            |> ignore

    member _.swDrawingSheetsZonesLetterLayout
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesLetterLayout, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingSheetsZonesLetterLayout, int opt, value)
            |> ignore

    member _.swDetailingBalloonAutoBalloons
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonAutoBalloons, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBalloonAutoBalloons, int opt, value)
            |> ignore

    member _.swFeatureManagerSelectionSetsVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSelectionSetsVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerSelectionSetsVisibility, int opt, value)
            |> ignore

    member _.swFeatureManagerHistory
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerHistory, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerHistory, int opt, value)
            |> ignore

    member _.swPDFExportShadedDraftDPI
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPDFExportShadedDraftDPI, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPDFExportShadedDraftDPI, int opt, value)
            |> ignore

    member _.swPDFExportOleDPI
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPDFExportOleDPI, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPDFExportOleDPI, int opt, value)
            |> ignore

    member _.swTwistCountValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTwistCountValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTwistCountValue, int opt, value)
            |> ignore

    member _.swManipConnectionPointColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swManipConnectionPointColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swManipConnectionPointColor, int opt, value)
            |> ignore

    member _.swRefVisualizationParentColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRefVisualizationParentColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRefVisualizationParentColor, int opt, value)
            |> ignore

    member _.swRefVisualizationChildrenColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRefVisualizationChildrenColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swRefVisualizationChildrenColor, int opt, value)
            |> ignore

    member _.swDrawingSheetCustomPropSheetNo
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingSheetCustomPropSheetNo, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawingSheetCustomPropSheetNo, int opt, value)
            |> ignore

    member _.swIFCExportSaveType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIFCExportSaveType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIFCExportSaveType, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLineStyleDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLineStyleDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingSectionViewLineStyleDisplay, int opt, value)
            |> ignore

    member _.swSaveIFCFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveIFCFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSaveIFCFormat, int opt, value)
            |> ignore

    member _.swDetailingLinearForeshortened
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearForeshortened, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingLinearForeshortened, int opt, value)
            |> ignore

    member _.swCartoonEdgeThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCartoonEdgeThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCartoonEdgeThickness, int opt, value)
            |> ignore

    member _.swTempGraphicsAddMaterialColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTempGraphicsAddMaterialColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTempGraphicsAddMaterialColor, int opt, value)
            |> ignore

    member _.swTempGraphicsRemoveMaterialColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTempGraphicsRemoveMaterialColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swTempGraphicsRemoveMaterialColor, int opt, value)
            |> ignore

    member _.swDetailingBorderLeaderLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineStyle, int opt, value)
            |> ignore

    member _.swDetailingBorderLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderLeaderLineThickness, int opt, value)
            |> ignore

    member _.swDetailingBorderZoneDividerLineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineStyle, int opt, value)
            |> ignore

    member _.swDetailingBorderZoneDividerLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingBorderZoneDividerLineThickness, int opt, value)
            |> ignore

    member _.swIFCOmniUniClassPreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIFCOmniUniClassPreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swIFCOmniUniClassPreference, int opt, value)
            |> ignore

    member _.swSystemColorsIconColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsIconColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsIconColor, int opt, value)
            |> ignore

    member _.swSystemColorsBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsBackground, int opt, value)
            |> ignore

    member _.swShadedSketchContourColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swShadedSketchContourColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swShadedSketchContourColor, int opt, value)
            |> ignore

    member _.sw3DPDFAccuracy
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.sw3DPDFAccuracy, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.sw3DPDFAccuracy, int opt, value)
            |> ignore

    member _.swLineFontEmphasizedSectionOutlineStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionOutlineStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionOutlineStyle, int opt, value)
            |> ignore

    member _.swLineFontEmphasizedSectionThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionThickness, int opt, value)
            |> ignore

    member _.swLineFontEmphasizedSectionEndCapStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionEndCapStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swLineFontEmphasizedSectionEndCapStyle, int opt, value)
            |> ignore

    member _.swBasicDimType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBasicDimType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBasicDimType, int opt, value)
            |> ignore

    member _.swPolarMinHoles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPolarMinHoles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPolarMinHoles, int opt, value)
            |> ignore

    member _.swGraphicsTreeItemNormalColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGraphicsTreeItemNormalColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGraphicsTreeItemNormalColor, int opt, value)
            |> ignore

    member _.swZoneLineColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swZoneLineColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swZoneLineColor, int opt, value)
            |> ignore

    member _.swSketch_Auto_Solve_Threshold
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSketch_Auto_Solve_Threshold, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSketch_Auto_Solve_Threshold, int opt, value)
            |> ignore

    member _.swDrawing_Auto_Solve_Threshold
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawing_Auto_Solve_Threshold, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDrawing_Auto_Solve_Threshold, int opt, value)
            |> ignore

    member _.swPenSketchStrokeThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPenSketchStrokeThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPenSketchStrokeThickness, int opt, value)
            |> ignore

    member _.swPenSketchStrokeColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPenSketchStrokeColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPenSketchStrokeColor, int opt, value)
            |> ignore

    member _.swMatesDefaultMisalignedType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swMatesDefaultMisalignedType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swMatesDefaultMisalignedType, int opt, value)
            |> ignore

    member _.swUpdateOutOfDateSpeedPakConfigOnSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUpdateOutOfDateSpeedPakConfigOnSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swUpdateOutOfDateSpeedPakConfigOnSave, int opt, value)
            |> ignore

    member _.swFeatureManagerMeshBodiesVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMeshBodiesVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMeshBodiesVisibility, int opt, value)
            |> ignore

    member _.swSolidBodiesDescriptionFirstPropertyIndex
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionFirstPropertyIndex, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionFirstPropertyIndex, int opt, value)
            |> ignore

    member _.swSolidBodiesDescriptionSecondPropertyIndex
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionSecondPropertyIndex, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionSecondPropertyIndex, int opt, value)
            |> ignore

    member _.swSolidBodiesDescriptionThirdPropertyIndex
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionThirdPropertyIndex, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSolidBodiesDescriptionThirdPropertyIndex, int opt, value)
            |> ignore

    member _.swDefaultConfigSortOrder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDefaultConfigSortOrder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDefaultConfigSortOrder, int opt, value)
            |> ignore

    member _.swGraphicalAnnotationsColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGraphicalAnnotationsColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGraphicalAnnotationsColor, int opt, value)
            |> ignore

    member _.swImportNeutral_KnitOption
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutral_KnitOption, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutral_KnitOption, int opt, value)
            |> ignore

    member _.swImportNeutral_CurvesAndPointsOption
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutral_CurvesAndPointsOption, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutral_CurvesAndPointsOption, int opt, value)
            |> ignore

    member _.swImportNeutralAssemblyStructureMapping
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutralAssemblyStructureMapping, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutralAssemblyStructureMapping, int opt, value)
            |> ignore

    member _.swImportNeutralUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutralUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swImportNeutralUnits, int opt, value)
            |> ignore

    member _.swBBoxDescriptionApplyMethod
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBBoxDescriptionApplyMethod, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBBoxDescriptionApplyMethod, int opt, value)
            |> ignore

    member _.swDetailingTrailingZeroTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroTolerance, int opt, value)
            |> ignore

    member _.swDetailingTrailingZeroProperties
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroProperties, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingTrailingZeroProperties, int opt, value)
            |> ignore

    member _.swDetailingAngleTrailingZero
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZero, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZero, int opt, value)
            |> ignore

    member _.swDetailingAngleTrailingZeroTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZeroTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngleTrailingZeroTolerance, int opt, value)
            |> ignore

    member _.swDetailingAngularRunningTrailingZero
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZero, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZero, int opt, value)
            |> ignore

    member _.swDetailingAngularRunningTrailingZeroTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZeroTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingAngularRunningTrailingZeroTolerance, int opt, value)
            |> ignore

    member _.swEdrawingsAttachmentOption
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentOption, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentOption, int opt, value)
            |> ignore

    member _.swEdrawingsAttachmentType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEdrawingsAttachmentType, int opt, value)
            |> ignore

    member _.swExportPlyUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportPlyUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swExportPlyUnits, int opt, value)
            |> ignore

    member _.swPLYQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPLYQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swPLYQuality, int opt, value)
            |> ignore

    member _.swMaximumRecentDocuments
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swMaximumRecentDocuments, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swMaximumRecentDocuments, int opt, value)
            |> ignore

    member _.swFlatPatternColorsBendLinesUpDirection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesUpDirection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesUpDirection, int opt, value)
            |> ignore

    member _.swFlatPatternColorsBendLinesDownDirection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesDownDirection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesDownDirection, int opt, value)
            |> ignore

    member _.swFlatPatternColorsFromFeature
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFromFeature, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFromFeature, int opt, value)
            |> ignore

    member _.swFlatPatternColorsBendLinesHems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesHems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBendLinesHems, int opt, value)
            |> ignore

    member _.swFlatPatternColorsModelEdges
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsModelEdges, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsModelEdges, int opt, value)
            |> ignore

    member _.swFlatPatternColorsFlatPatternSketchColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFlatPatternSketchColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsFlatPatternSketchColor, int opt, value)
            |> ignore

    member _.swFlatPatternColorsBoundingBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBoundingBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFlatPatternColorsBoundingBox, int opt, value)
            |> ignore

    member _.swSheetMetalMBDBendNotesStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBendNotesStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBendNotesStyle, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLeaderStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderStyle, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLeaderLineThickness
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderLineThickness, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderLineThickness, int opt, value)
            |> ignore

    member _.swSheetMetalMBDTextAlignment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDTextAlignment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDTextAlignment, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLeaderAnchor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderAnchor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderAnchor, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLeaderDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLeaderDisplay, int opt, value)
            |> ignore

    member _.swSheetMetalMBDBalloonStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBalloonStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDBalloonStyle, int opt, value)
            |> ignore

    member _.swSheetMetalMBDFit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDFit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDFit, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLineStyle_BendLinesUp
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesUp, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesUp, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLineStyle_BendLinesDown
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesDown, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetMetalMBDLineStyle_BendLinesDown, int opt, value)
            |> ignore

    member _.swFeatureManagerMarkupsVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMarkupsVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerMarkupsVisibility, int opt, value)
            |> ignore

    member _.swEnableAutoMateFlip
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEnableAutoMateFlip, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swEnableAutoMateFlip, int opt, value)
            |> ignore

    member _.swSystemColorsSelectedItem5
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem5, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem5, int opt, value)
            |> ignore

    member _.swSystemColorsSelectedItem6
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem6, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSystemColorsSelectedItem6, int opt, value)
            |> ignore

    member _.swFeatureManagerTranslatedLanguage
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerTranslatedLanguage, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swFeatureManagerTranslatedLanguage, int opt, value)
            |> ignore

    member _.swAssemblyLoadComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyLoadComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swAssemblyLoadComponents, int opt, value)
            |> ignore

    member _.swConfigurationViewForFeatureManagerTree
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swConfigurationViewForFeatureManagerTree, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swConfigurationViewForFeatureManagerTree, int opt, value)
            |> ignore

    member _.swDetailingGtolMaterialConditionSymbolPlacement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolMaterialConditionSymbolPlacement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDetailingGtolMaterialConditionSymbolPlacement, int opt, value)
            |> ignore

    member _.swBomOverriddenCellValueColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBomOverriddenCellValueColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swBomOverriddenCellValueColor, int opt, value)
            |> ignore

    member _.swSheetPrintQuadrant
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetPrintQuadrant, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSheetPrintQuadrant, int opt, value)
            |> ignore

    member _.swSketchExplodedColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSketchExplodedColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swSketchExplodedColor, int opt, value)
            |> ignore

    member _.swDefaultBOMPartNumberForNewConfig
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDefaultBOMPartNumberForNewConfig, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDefaultBOMPartNumberForNewConfig, int opt, value)
            |> ignore

    member _.swDimOverriddenCellValueColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDimOverriddenCellValueColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swDimOverriddenCellValueColor, int opt, value)
            |> ignore

    member _.swOppHandMirrorComp
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swOppHandMirrorComp, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swOppHandMirrorComp, int opt, value)
            |> ignore

    member _.swGtolDecimalSeparatorType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGtolDecimalSeparatorType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swGtolDecimalSeparatorType, int opt, value)
            |> ignore

    member _.swCollinearChainDimensionArrowHeadTerminationStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCollinearChainDimensionArrowHeadTerminationStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceInteger(int swUserPreferenceIntegerValue_e.swCollinearChainDimensionArrowHeadTerminationStyle, int opt, value)
            |> ignore

    member _.swFileLocationsDocuments
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDocuments, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDocuments, int opt, value)
            |> ignore

    member _.swFileLocationsPaletteFeatures
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteFeatures, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteFeatures, int opt, value)
            |> ignore

    member _.swFileLocationsPaletteParts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteParts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteParts, int opt, value)
            |> ignore

    member _.swFileLocationsPaletteFormTools
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteFormTools, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteFormTools, int opt, value)
            |> ignore

    member _.swFileLocationsBlocks
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBlocks, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBlocks, int opt, value)
            |> ignore

    member _.swFileLocationsDocumentTemplates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDocumentTemplates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDocumentTemplates, int opt, value)
            |> ignore

    member _.swFileLocationsSheetFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSheetFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSheetFormat, int opt, value)
            |> ignore

    member _.swDefaultTemplatePart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDefaultTemplatePart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDefaultTemplatePart, int opt, value)
            |> ignore

    member _.swDefaultTemplateAssembly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDefaultTemplateAssembly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDefaultTemplateAssembly, int opt, value)
            |> ignore

    member _.swDefaultTemplateDrawing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDefaultTemplateDrawing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDefaultTemplateDrawing, int opt, value)
            |> ignore

    member _.swBackupDirectory
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swBackupDirectory, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swBackupDirectory, int opt, value)
            |> ignore

    member _.swFileLocationsBendTable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendTable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendTable, int opt, value)
            |> ignore

    member _.swMaterialPropertyCrosshatchPattern
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swMaterialPropertyCrosshatchPattern, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swMaterialPropertyCrosshatchPattern, int opt, value)
            |> ignore

    member _.swDrawingAreaHatchPattern
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDrawingAreaHatchPattern, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDrawingAreaHatchPattern, int opt, value)
            |> ignore

    member _.swDetailingNextDatumFeatureLabel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingNextDatumFeatureLabel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingNextDatumFeatureLabel, int opt, value)
            |> ignore

    member _.swFileSaveAsCoordinateSystem
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileSaveAsCoordinateSystem, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileSaveAsCoordinateSystem, int opt, value)
            |> ignore

    member _.swFileLocationsPaletteAssemblies
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteAssemblies, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPaletteAssemblies, int opt, value)
            |> ignore

    member _.swCustomPropertyUsedAsComponentDescription
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swCustomPropertyUsedAsComponentDescription, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swCustomPropertyUsedAsComponentDescription, int opt, value)
            |> ignore

    member _.swFileLocationsLibraryFeatures
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsLibraryFeatures, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsLibraryFeatures, int opt, value)
            |> ignore

    member _.swFileLocationsMacroFeatures
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsMacroFeatures, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsMacroFeatures, int opt, value)
            |> ignore

    member _.swFileLocationsWebFolders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWebFolders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWebFolders, int opt, value)
            |> ignore

    member _.swFileLocationsBOMTemplates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBOMTemplates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBOMTemplates, int opt, value)
            |> ignore

    member _.swFileLocationsMacros
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsMacros, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsMacros, int opt, value)
            |> ignore

    member _.swFileLocationsJournalFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsJournalFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsJournalFile, int opt, value)
            |> ignore

    member _.swFileLocationsCustomPropertyFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomPropertyFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomPropertyFile, int opt, value)
            |> ignore

    member _.swFileLocationsHoleCalloutFormatFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHoleCalloutFormatFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHoleCalloutFormatFile, int opt, value)
            |> ignore

    member _.swFileLocationsDimensionFavorites
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDimensionFavorites, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDimensionFavorites, int opt, value)
            |> ignore

    member _.swFileLocationsMaterialDatabases
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsMaterialDatabases, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsMaterialDatabases, int opt, value)
            |> ignore

    member _.swFileLocationsWeldmentProfiles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldmentProfiles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldmentProfiles, int opt, value)
            |> ignore

    member _.swFileLocationsColorSwatches
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsColorSwatches, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsColorSwatches, int opt, value)
            |> ignore

    member _.swFileLocationsTextures
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTextures, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTextures, int opt, value)
            |> ignore

    member _.swFileLocationsWeldmentPropertyFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldmentPropertyFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldmentPropertyFile, int opt, value)
            |> ignore

    member _.swFileLocationsHoleTableTemplates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHoleTableTemplates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHoleTableTemplates, int opt, value)
            |> ignore

    member _.swFileLocationsWeldmentCutListTemplates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldmentCutListTemplates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldmentCutListTemplates, int opt, value)
            |> ignore

    member _.swFileLocationsRevisionTableTemplates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRevisionTableTemplates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRevisionTableTemplates, int opt, value)
            |> ignore

    member _.swDrawingCustomPropertyUsedAsRevision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDrawingCustomPropertyUsedAsRevision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDrawingCustomPropertyUsedAsRevision, int opt, value)
            |> ignore

    member _.swFileLocationsRouteComponentLibrary
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRouteComponentLibrary, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRouteComponentLibrary, int opt, value)
            |> ignore

    member _.swFileLocationsDesignLibrary
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDesignLibrary, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDesignLibrary, int opt, value)
            |> ignore

    member _.swFileLocationsLineStyleDefinitions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsLineStyleDefinitions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsLineStyleDefinitions, int opt, value)
            |> ignore

    member _.swFileLocationsDesignJournalTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDesignJournalTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDesignJournalTemplate, int opt, value)
            |> ignore

    member _.swFileLocationsRouteCableLibrary
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRouteCableLibrary, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRouteCableLibrary, int opt, value)
            |> ignore

    member _.swFileLocationsAppearances
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsAppearances, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsAppearances, int opt, value)
            |> ignore

    member _.swFileLocationsScenes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsScenes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsScenes, int opt, value)
            |> ignore

    member _.swFileLocationsLights
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsLights, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsLights, int opt, value)
            |> ignore

    member _.swFileLocationsBendNoteFormatFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendNoteFormatFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendNoteFormatFile, int opt, value)
            |> ignore

    member _.swSeparatorCharacterForDims
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSeparatorCharacterForDims, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSeparatorCharacterForDims, int opt, value)
            |> ignore

    member _.swFileLocationsRouteCoveringLibrary
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRouteCoveringLibrary, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsRouteCoveringLibrary, int opt, value)
            |> ignore

    member _.swFileLocationsDesignCheckerFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDesignCheckerFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDesignCheckerFile, int opt, value)
            |> ignore

    member _.swReferenceTriadXLabel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swReferenceTriadXLabel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swReferenceTriadXLabel, int opt, value)
            |> ignore

    member _.swReferenceTriadYLabel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swReferenceTriadYLabel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swReferenceTriadYLabel, int opt, value)
            |> ignore

    member _.swReferenceTriadZLabel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swReferenceTriadZLabel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swReferenceTriadZLabel, int opt, value)
            |> ignore

    member _.swHoleWizardToolBoxFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swHoleWizardToolBoxFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swHoleWizardToolBoxFolder, int opt, value)
            |> ignore

    member _.swAutoSaveDirectory
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swAutoSaveDirectory, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swAutoSaveDirectory, int opt, value)
            |> ignore

    member _.swColorsBackgroundImageFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swColorsBackgroundImageFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swColorsBackgroundImageFile, int opt, value)
            |> ignore

    member _.swDetailingBOMUpperCustomProperty
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingBOMUpperCustomProperty, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingBOMUpperCustomProperty, int opt, value)
            |> ignore

    member _.swDetailingBOMLowerCustomProperty
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingBOMLowerCustomProperty, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingBOMLowerCustomProperty, int opt, value)
            |> ignore

    member _.swFileLocationsTxCalloutFormatFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTxCalloutFormatFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTxCalloutFormatFile, int opt, value)
            |> ignore

    member _.swFileLocations3DCCModelFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocations3DCCModelFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocations3DCCModelFolder, int opt, value)
            |> ignore

    member _.swFileLocationsHoleWizardFavoritesDB
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHoleWizardFavoritesDB, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHoleWizardFavoritesDB, int opt, value)
            |> ignore

    member _.swFileLocationsSearchPaths
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSearchPaths, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSearchPaths, int opt, value)
            |> ignore

    member _.swFileLocationsSheetMetalGaugeTable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSheetMetalGaugeTable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSheetMetalGaugeTable, int opt, value)
            |> ignore

    member _.swFileLocationsSpellingFolders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSpellingFolders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSpellingFolders, int opt, value)
            |> ignore

    member _.swDetailingLayer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingLayer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingLayer, int opt, value)
            |> ignore

    member _.swFileLocationsDraftingStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDraftingStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDraftingStandard, int opt, value)
            |> ignore

    member _.swDetailingDimensionStandardName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingDimensionStandardName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingDimensionStandardName, int opt, value)
            |> ignore

    member _.swOverriddenQuantityColumnName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swOverriddenQuantityColumnName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swOverriddenQuantityColumnName, int opt, value)
            |> ignore

    member _.swFileLocationsCustomAppearances
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomAppearances, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomAppearances, int opt, value)
            |> ignore

    member _.swFileLocationsCustomDecals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomDecals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomDecals, int opt, value)
            |> ignore

    member _.swFileLocationsCustomScenes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomScenes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCustomScenes, int opt, value)
            |> ignore

    member _.swFileLocationsTitleBlockTableTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTitleBlockTableTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTitleBlockTableTemplate, int opt, value)
            |> ignore

    member _.swFileLocationsBendCalculationTable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendCalculationTable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendCalculationTable, int opt, value)
            |> ignore

    member _.swFileLocationsThemeFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsThemeFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsThemeFolder, int opt, value)
            |> ignore

    member _.swExportIFCType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swExportIFCType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swExportIFCType, int opt, value)
            |> ignore

    member _.swFileLocationsFuncBldrSegTypeDefinitions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsFuncBldrSegTypeDefinitions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsFuncBldrSegTypeDefinitions, int opt, value)
            |> ignore

    member _.swFileLocationsSustainabilityReportTemplateFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSustainabilityReportTemplateFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSustainabilityReportTemplateFolder, int opt, value)
            |> ignore

    member _.swFileLocationsCostingReportTemplateFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCostingReportTemplateFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCostingReportTemplateFolder, int opt, value)
            |> ignore

    member _.swFileLocationsCostingTemplates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCostingTemplates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsCostingTemplates, int opt, value)
            |> ignore

    member _.swFileLocationsWeldTableTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldTableTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsWeldTableTemplate, int opt, value)
            |> ignore

    member _.swFileLocationsBendTableTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendTableTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsBendTableTemplate, int opt, value)
            |> ignore

    member _.swFileLocationsPunchTableTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPunchTableTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsPunchTableTemplate, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_CustomName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomName, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_CustomScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingDetailViewLabels_CustomScale, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_CustomName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomName, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_CustomScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingSectionViewLabels_CustomScale, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_CustomName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomName, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_CustomScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingAuxViewLabels_CustomScale, int opt, value)
            |> ignore

    member _.swCenterLineLayer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swCenterLineLayer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swCenterLineLayer, int opt, value)
            |> ignore

    member _.swCenterMarkLayer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swCenterMarkLayer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swCenterMarkLayer, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLayer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSheetMetalBendNotesLayer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSheetMetalBendNotesLayer, int opt, value)
            |> ignore

    member _.swSearchDissectionLocation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSearchDissectionLocation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSearchDissectionLocation, int opt, value)
            |> ignore

    member _.swFileLocationsSymbolLibraryFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSymbolLibraryFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsSymbolLibraryFolder, int opt, value)
            |> ignore

    member _.swFileLocationsNewSheetFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsNewSheetFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsNewSheetFormat, int opt, value)
            |> ignore

    member _.swDetailingMiscView_CustomName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomName, int opt, value)
            |> ignore

    member _.swDetailingMiscView_CustomScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingMiscView_CustomScale, int opt, value)
            |> ignore

    member _.swDraftStandardExclusionList
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDraftStandardExclusionList, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDraftStandardExclusionList, int opt, value)
            |> ignore

    member _.swDetailingOrthoView_CustomName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomName, int opt, value)
            |> ignore

    member _.swDetailingOrthoView_CustomScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDetailingOrthoView_CustomScale, int opt, value)
            |> ignore

    member _.swElecDuctingDuctName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swElecDuctingDuctName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swElecDuctingDuctName, int opt, value)
            |> ignore

    member _.swElecCableTrayDuctName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swElecCableTrayDuctName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swElecCableTrayDuctName, int opt, value)
            |> ignore

    member _.swHvacRectDuctName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacRectDuctName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacRectDuctName, int opt, value)
            |> ignore

    member _.swHvacCirDuctName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacCirDuctName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacCirDuctName, int opt, value)
            |> ignore

    member _.swElecDuctingElbowName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swElecDuctingElbowName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swElecDuctingElbowName, int opt, value)
            |> ignore

    member _.swElecCableTrayElbowName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swElecCableTrayElbowName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swElecCableTrayElbowName, int opt, value)
            |> ignore

    member _.swHvacRectElbowName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacRectElbowName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacRectElbowName, int opt, value)
            |> ignore

    member _.swHvacCirElbowName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacCirElbowName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swHvacCirElbowName, int opt, value)
            |> ignore

    member _.swBorderLayer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swBorderLayer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swBorderLayer, int opt, value)
            |> ignore

    member _.swFileLocationsThreadProfiles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsThreadProfiles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsThreadProfiles, int opt, value)
            |> ignore

    member _.swFileLocationsGeneralTablesTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsGeneralTablesTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsGeneralTablesTemplate, int opt, value)
            |> ignore

    member _.swFileLocationsTxGeneralFileLocation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTxGeneralFileLocation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsTxGeneralFileLocation, int opt, value)
            |> ignore

    member _.swMySldSettings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swMySldSettings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swMySldSettings, int opt, value)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionPrefix
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionPrefix, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionPrefix, int opt, value)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionFirstSeparator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionFirstSeparator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionFirstSeparator, int opt, value)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionSecondSeparator
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSecondSeparator, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSecondSeparator, int opt, value)
            |> ignore

    member _.swSolidBodiesBBoxDescriptionSuffix
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSuffix, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSolidBodiesBBoxDescriptionSuffix, int opt, value)
            |> ignore

    member _.swSheetMetalDescription
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swSheetMetalDescription, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swSheetMetalDescription, int opt, value)
            |> ignore

    member _.swDimXpertGeneralToleranceCustomTable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swDimXpertGeneralToleranceCustomTable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swDimXpertGeneralToleranceCustomTable, int opt, value)
            |> ignore

    member _.swFileLocationsDefaultSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDefaultSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDefaultSave, int opt, value)
            |> ignore

    member _.swHoleTagsList
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swHoleTagsList, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swHoleTagsList, int opt, value)
            |> ignore

    member _.swBomTableBOMHeaderCustomText_ForTopLevelOnlyBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForTopLevelOnlyBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForTopLevelOnlyBOM, int opt, value)
            |> ignore

    member _.swBomTableBOMHeaderCustomText_ForPartOnlyBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForPartOnlyBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForPartOnlyBOM, int opt, value)
            |> ignore

    member _.swBomTableBOMHeaderCustomText_ForIndentedBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForIndentedBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swBomTableBOMHeaderCustomText_ForIndentedBOM, int opt, value)
            |> ignore

    member _.swFileLocationsDrawingScaleStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDrawingScaleStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDrawingScaleStandard, int opt, value)
            |> ignore

    member _.swStructureSystemsFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swStructureSystemsFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swStructureSystemsFolder, int opt, value)
            |> ignore

    member _.swWeldmentStructureCutlistID
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swWeldmentStructureCutlistID, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swWeldmentStructureCutlistID, int opt, value)
            |> ignore

    member _.swWeldmentSheetmetalCutlistID
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swWeldmentSheetmetalCutlistID, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swWeldmentSheetmetalCutlistID, int opt, value)
            |> ignore

    member _.swWeldmentGenericCutlistID
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swWeldmentGenericCutlistID, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swWeldmentGenericCutlistID, int opt, value)
            |> ignore

    member _.swFileLocationsHatchPatternFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHatchPatternFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsHatchPatternFile, int opt, value)
            |> ignore

    member _.swFileLocationsInspectionProjects
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsInspectionProjects, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsInspectionProjects, int opt, value)
            |> ignore

    member _.swFileLocationsInspectionReports
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsInspectionReports, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsInspectionReports, int opt, value)
            |> ignore

    member _.swLastSynchronizationTimeStamp
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swLastSynchronizationTimeStamp, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swLastSynchronizationTimeStamp, int opt, value)
            |> ignore

    member _.swFileLocationsInspectionExports
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsInspectionExports, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsInspectionExports, int opt, value)
            |> ignore

    member _.swFileLocationsStructureSystemsConnectionElements
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsStructureSystemsConnectionElements, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsStructureSystemsConnectionElements, int opt, value)
            |> ignore

    member _.swFileLocationsConnectedLibrary
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsConnectedLibrary, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsConnectedLibrary, int opt, value)
            |> ignore

    member _.swExportOutputCoordinateSystem
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swExportOutputCoordinateSystem, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swExportOutputCoordinateSystem, int opt, value)
            |> ignore

    member _.swFileLocationsDefeatureRuleSets
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDefeatureRuleSets, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swFileLocationsDefeatureRuleSets, int opt, value)
            |> ignore

    member _.swOppPrefixSuffixText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swOppPrefixSuffixText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swOppPrefixSuffixText, int opt, value)
            |> ignore

    member _.swVirtualComponentPrefixedit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceString(int swUserPreferenceStringValue_e.swVirtualComponentPrefixedit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceString(int swUserPreferenceStringValue_e.swVirtualComponentPrefixedit, int opt, value)
            |> ignore

    member _.swUseFolderSearchRules
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderSearchRules, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderSearchRules, int opt, value)
            |> ignore

    member _.swDisplayArcCenterPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayArcCenterPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayArcCenterPoints, int opt, value)
            |> ignore

    member _.swDisplayEntityPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEntityPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEntityPoints, int opt, value)
            |> ignore

    member _.swIgnoreFeatureColors
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreFeatureColors, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreFeatureColors, int opt, value)
            |> ignore

    member _.swDisplayAxes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAxes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAxes, int opt, value)
            |> ignore

    member _.swDisplayPlanes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlanes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlanes, int opt, value)
            |> ignore

    member _.swDisplayOrigins
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOrigins, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOrigins, int opt, value)
            |> ignore

    member _.swDisplayTemporaryAxes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTemporaryAxes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTemporaryAxes, int opt, value)
            |> ignore

    member _.swDxfMapping
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfMapping, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfMapping, int opt, value)
            |> ignore

    member _.swSketchAutomaticRelations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAutomaticRelations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAutomaticRelations, int opt, value)
            |> ignore

    member _.swInputDimValOnCreate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate, int opt, value)
            |> ignore

    member _.swFullyConstrainedSketchMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFullyConstrainedSketchMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFullyConstrainedSketchMode, int opt, value)
            |> ignore

    member _.swXTAssemSaveFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swXTAssemSaveFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swXTAssemSaveFormat, int opt, value)
            |> ignore

    member _.swDisplayCoordSystems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCoordSystems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCoordSystems, int opt, value)
            |> ignore

    member _.swExtRefOpenReadOnly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefOpenReadOnly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefOpenReadOnly, int opt, value)
            |> ignore

    member _.swExtRefNoPromptOrSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefNoPromptOrSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefNoPromptOrSave, int opt, value)
            |> ignore

    member _.swExtRefMultipleContexts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefMultipleContexts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefMultipleContexts, int opt, value)
            |> ignore

    member _.swExtRefAutoGenNames
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefAutoGenNames, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefAutoGenNames, int opt, value)
            |> ignore

    member _.swExtRefUpdateCompNames
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefUpdateCompNames, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefUpdateCompNames, int opt, value)
            |> ignore

    member _.swDisplayRoutePoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRoutePoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRoutePoints, int opt, value)
            |> ignore

    member _.swDisplayReferencePoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints, int opt, value)
            |> ignore

    member _.swUseShadedFaceHighlight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedFaceHighlight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedFaceHighlight, int opt, value)
            |> ignore

    member _.swDXFDontShowMap
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFDontShowMap, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFDontShowMap, int opt, value)
            |> ignore

    member _.swThumbnailGraphics
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swThumbnailGraphics, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swThumbnailGraphics, int opt, value)
            |> ignore

    member _.swUseAlphaTransparency
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseAlphaTransparency, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseAlphaTransparency, int opt, value)
            |> ignore

    member _.swDynamicDrawingViewActivation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicDrawingViewActivation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicDrawingViewActivation, int opt, value)
            |> ignore

    member _.swAutoLoadPartsLightweight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoLoadPartsLightweight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoLoadPartsLightweight, int opt, value)
            |> ignore

    member _.swIGESStandardSetting
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESStandardSetting, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESStandardSetting, int opt, value)
            |> ignore

    member _.swIGESNurbsSetting
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESNurbsSetting, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESNurbsSetting, int opt, value)
            |> ignore

    member _.swTiffPrintScaleToFit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintScaleToFit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintScaleToFit, int opt, value)
            |> ignore

    member _.swDisplayVirtualSharps
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayVirtualSharps, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayVirtualSharps, int opt, value)
            |> ignore

    member _.swUpdateMassPropsDuringSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateMassPropsDuringSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateMassPropsDuringSave, int opt, value)
            |> ignore

    member _.swDisplayAnnotations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotations, int opt, value)
            |> ignore

    member _.swDisplayFeatureDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayFeatureDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayFeatureDimensions, int opt, value)
            |> ignore

    member _.swDisplayReferenceDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceDimensions, int opt, value)
            |> ignore

    member _.swDisplayAnnotationsUseAssemblySettings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotationsUseAssemblySettings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAnnotationsUseAssemblySettings, int opt, value)
            |> ignore

    member _.swDisplayNotes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotes, int opt, value)
            |> ignore

    member _.swDisplayGeometricTolerances
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGeometricTolerances, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGeometricTolerances, int opt, value)
            |> ignore

    member _.swDisplaySurfaceFinishSymbols
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySurfaceFinishSymbols, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySurfaceFinishSymbols, int opt, value)
            |> ignore

    member _.swDisplayWeldSymbols
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldSymbols, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldSymbols, int opt, value)
            |> ignore

    member _.swDisplayDatums
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatums, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatums, int opt, value)
            |> ignore

    member _.swDisplayDatumTargets
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumTargets, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumTargets, int opt, value)
            |> ignore

    member _.swDisplayCosmeticThreads
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCosmeticThreads, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCosmeticThreads, int opt, value)
            |> ignore

    member _.swDetailingDisplayWithBrokenLeaders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayWithBrokenLeaders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayWithBrokenLeaders, int opt, value)
            |> ignore

    member _.swDetailingDualDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDualDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDualDimensions, int opt, value)
            |> ignore

    member _.swDetailingDisplayDatumsPer1982
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDatumsPer1982, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDatumsPer1982, int opt, value)
            |> ignore

    member _.swDetailingDisplayAlternateSection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayAlternateSection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayAlternateSection, int opt, value)
            |> ignore

    member _.swDetailingCenterMarkShowLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkShowLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkShowLines, int opt, value)
            |> ignore

    member _.swDetailingFixedSizeWeldSymbol
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingFixedSizeWeldSymbol, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingFixedSizeWeldSymbol, int opt, value)
            |> ignore

    member _.swDetailingDimsShowParenthesisByDefault
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowParenthesisByDefault, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowParenthesisByDefault, int opt, value)
            |> ignore

    member _.swDetailingDimsSnapTextToGrid
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsSnapTextToGrid, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsSnapTextToGrid, int opt, value)
            |> ignore

    member _.swDetailingDimsCenterText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsCenterText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsCenterText, int opt, value)
            |> ignore

    member _.swDetailingRadialDimsDisplay2ndOutsideArrow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplay2ndOutsideArrow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplay2ndOutsideArrow, int opt, value)
            |> ignore

    member _.swDetailingRadialDimsArrowsFollowText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsArrowsFollowText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsArrowsFollowText, int opt, value)
            |> ignore

    member _.swDetailingDimLeaderOverrideStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimLeaderOverrideStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimLeaderOverrideStandard, int opt, value)
            |> ignore

    member _.swDetailingNotesDisplayWithBentLeader
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesDisplayWithBentLeader, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesDisplayWithBentLeader, int opt, value)
            |> ignore

    member _.swDisplayTextAtSameSizeAlways
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTextAtSameSizeAlways, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTextAtSameSizeAlways, int opt, value)
            |> ignore

    member _.swDisplayOnlyInViewOfCreation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOnlyInViewOfCreation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayOnlyInViewOfCreation, int opt, value)
            |> ignore

    member _.swGridDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplay, int opt, value)
            |> ignore

    member _.swGridDisplayDashed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplayDashed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridDisplayDashed, int opt, value)
            |> ignore

    member _.swGridAutomaticScaling
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridAutomaticScaling, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swGridAutomaticScaling, int opt, value)
            |> ignore

    member _.swSnapToPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToPoints, int opt, value)
            |> ignore

    member _.swSnapToAngle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToAngle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapToAngle, int opt, value)
            |> ignore

    member _.swUnitsLinearRoundToNearestFraction
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearRoundToNearestFraction, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearRoundToNearestFraction, int opt, value)
            |> ignore

    member _.swUnitsLinearFeetAndInchesFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearFeetAndInchesFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsLinearFeetAndInchesFormat, int opt, value)
            |> ignore

    member _.swFeatureManagerEnsureVisible
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnsureVisible, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnsureVisible, int opt, value)
            |> ignore

    member _.swFeatureManagerNameFeatureWhenCreated
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerNameFeatureWhenCreated, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerNameFeatureWhenCreated, int opt, value)
            |> ignore

    member _.swFeatureManagerKeyboardNavigation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerKeyboardNavigation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerKeyboardNavigation, int opt, value)
            |> ignore

    member _.swFeatureManagerDynamicHighlight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerDynamicHighlight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerDynamicHighlight, int opt, value)
            |> ignore

    member _.swColorsGradientPartBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsGradientPartBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsGradientPartBackground, int opt, value)
            |> ignore

    member _.swSTLBinaryFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLBinaryFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLBinaryFormat, int opt, value)
            |> ignore

    member _.swSTLShowInfoOnSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLShowInfoOnSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLShowInfoOnSave, int opt, value)
            |> ignore

    member _.swSTLDontTranslateToPositive
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLDontTranslateToPositive, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLDontTranslateToPositive, int opt, value)
            |> ignore

    member _.swSTLComponentsIntoOneFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLComponentsIntoOneFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLComponentsIntoOneFile, int opt, value)
            |> ignore

    member _.swSTLCheckForInterference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLCheckForInterference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLCheckForInterference, int opt, value)
            |> ignore

    member _.swOpenLastUsedDocumentAtStart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOpenLastUsedDocumentAtStart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOpenLastUsedDocumentAtStart, int opt, value)
            |> ignore

    member _.swSingleCommandPerPick
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSingleCommandPerPick, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSingleCommandPerPick, int opt, value)
            |> ignore

    member _.swShowDimensionNames
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDimensionNames, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDimensionNames, int opt, value)
            |> ignore

    member _.swShowErrorsEveryRebuild
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowErrorsEveryRebuild, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowErrorsEveryRebuild, int opt, value)
            |> ignore

    member _.swMaximizeDocumentOnOpen
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaximizeDocumentOnOpen, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaximizeDocumentOnOpen, int opt, value)
            |> ignore

    member _.swEditDesignTableInSeparateWindow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditDesignTableInSeparateWindow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditDesignTableInSeparateWindow, int opt, value)
            |> ignore

    member _.swEnablePropertyManager
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePropertyManager, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePropertyManager, int opt, value)
            |> ignore

    member _.swUseSystemSeparatorForDims
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSystemSeparatorForDims, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSystemSeparatorForDims, int opt, value)
            |> ignore

    member _.swUseEnglishLanguage
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguage, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguage, int opt, value)
            |> ignore

    member _.swDrawingAutomaticModelDimPlacement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticModelDimPlacement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticModelDimPlacement, int opt, value)
            |> ignore

    member _.swDrawingDisplayViewBorders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayViewBorders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayViewBorders, int opt, value)
            |> ignore

    member _.swAutomaticScaling3ViewDrawings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticScaling3ViewDrawings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticScaling3ViewDrawings, int opt, value)
            |> ignore

    member _.swDrawingAutomaticBomUpdate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticBomUpdate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutomaticBomUpdate, int opt, value)
            |> ignore

    member _.swDrawingSelectHiddenEntities
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSelectHiddenEntities, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSelectHiddenEntities, int opt, value)
            |> ignore

    member _.swDrawingCreateDetailAsCircle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingCreateDetailAsCircle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingCreateDetailAsCircle, int opt, value)
            |> ignore

    member _.swAutomaticDrawingViewUpdate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdate, int opt, value)
            |> ignore

    member _.swDrawingDetailInferCorner
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCorner, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCorner, int opt, value)
            |> ignore

    member _.swDrawingDetailInferCenter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCenter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDetailInferCenter, int opt, value)
            |> ignore

    member _.swDrawingViewShowContentsWhileDragging
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewShowContentsWhileDragging, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewShowContentsWhileDragging, int opt, value)
            |> ignore

    member _.swSketchAlternateSplineCreation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAlternateSplineCreation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAlternateSplineCreation, int opt, value)
            |> ignore

    member _.swSketchInferFromModel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInferFromModel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInferFromModel, int opt, value)
            |> ignore

    member _.swSketchPromptToCloseSketch
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPromptToCloseSketch, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPromptToCloseSketch, int opt, value)
            |> ignore

    member _.swSketchCreateSketchOnNewPart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateSketchOnNewPart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateSketchOnNewPart, int opt, value)
            |> ignore

    member _.swSketchOverrideDimensionsOnDrag
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverrideDimensionsOnDrag, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverrideDimensionsOnDrag, int opt, value)
            |> ignore

    member _.swSketchDisplayPlaneWhenShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchDisplayPlaneWhenShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchDisplayPlaneWhenShaded, int opt, value)
            |> ignore

    member _.swSketchOverdefiningDimsPromptToSetState
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsPromptToSetState, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsPromptToSetState, int opt, value)
            |> ignore

    member _.swSketchOverdefiningDimsSetDrivenByDefault
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsSetDrivenByDefault, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchOverdefiningDimsSetDrivenByDefault, int opt, value)
            |> ignore

    member _.swPerformanceVerifyOnRebuild
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceVerifyOnRebuild, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceVerifyOnRebuild, int opt, value)
            |> ignore

    member _.swPerformanceDynamicUpdateOnMove
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceDynamicUpdateOnMove, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceDynamicUpdateOnMove, int opt, value)
            |> ignore

    member _.swPerformanceAlwaysGenerateCurvature
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysGenerateCurvature, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysGenerateCurvature, int opt, value)
            |> ignore

    member _.swPerformanceWin95ZoomClipping
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceWin95ZoomClipping, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceWin95ZoomClipping, int opt, value)
            |> ignore

    member _.swIGESDuplicateEntities
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESDuplicateEntities, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESDuplicateEntities, int opt, value)
            |> ignore

    member _.swIGESHighTrimCurveAccuracy
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESHighTrimCurveAccuracy, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESHighTrimCurveAccuracy, int opt, value)
            |> ignore

    member _.swIGESExportSketchEntities
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSketchEntities, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSketchEntities, int opt, value)
            |> ignore

    member _.swIGESComponentsIntoOneFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESComponentsIntoOneFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESComponentsIntoOneFile, int opt, value)
            |> ignore

    member _.swIGESFlattenAssemHierarchy
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESFlattenAssemHierarchy, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESFlattenAssemHierarchy, int opt, value)
            |> ignore

    member _.swAlwaysUseDefaultTemplates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAlwaysUseDefaultTemplates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAlwaysUseDefaultTemplates, int opt, value)
            |> ignore

    member _.swUseSimpleOpenGL
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSimpleOpenGL, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSimpleOpenGL, int opt, value)
            |> ignore

    member _.swShowRefGeomName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowRefGeomName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowRefGeomName, int opt, value)
            |> ignore

    member _.swUseShadedPreview
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedPreview, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseShadedPreview, int opt, value)
            |> ignore

    member _.swEdgesHiddenEdgeSelectionInWireframe
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInWireframe, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInWireframe, int opt, value)
            |> ignore

    member _.swEdgesHiddenEdgeSelectionInHLR
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInHLR, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHiddenEdgeSelectionInHLR, int opt, value)
            |> ignore

    member _.swEdgesRepaintAfterSelectionInHLR
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesRepaintAfterSelectionInHLR, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesRepaintAfterSelectionInHLR, int opt, value)
            |> ignore

    member _.swEdgesHighlightFeatureEdges
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighlightFeatureEdges, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighlightFeatureEdges, int opt, value)
            |> ignore

    member _.swEdgesDynamicHighlight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDynamicHighlight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDynamicHighlight, int opt, value)
            |> ignore

    member _.swEdgesHighQualityDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighQualityDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesHighQualityDisplay, int opt, value)
            |> ignore

    member _.swEdgesOpenEdgesDifferentColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesOpenEdgesDifferentColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesOpenEdgesDifferentColor, int opt, value)
            |> ignore

    member _.swEnableConfirmationCorner
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableConfirmationCorner, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableConfirmationCorner, int opt, value)
            |> ignore

    member _.swAutoShowPropertyManager
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoShowPropertyManager, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoShowPropertyManager, int opt, value)
            |> ignore

    member _.swIncontextFeatureHolderVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncontextFeatureHolderVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncontextFeatureHolderVisibility, int opt, value)
            |> ignore

    member _.swTransparencyHighQualityDynamic
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransparencyHighQualityDynamic, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransparencyHighQualityDynamic, int opt, value)
            |> ignore

    member _.swEdgesShadedEdgesDifferentColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedEdgesDifferentColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedEdgesDifferentColor, int opt, value)
            |> ignore

    member _.swEdgesAntiAlias
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesAntiAlias, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesAntiAlias, int opt, value)
            |> ignore

    member _.swPageSetupPrinterUsePrinterMargin
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterUsePrinterMargin, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterUsePrinterMargin, int opt, value)
            |> ignore

    member _.swPageSetupPrinterDrawingScaleToFit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterDrawingScaleToFit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterDrawingScaleToFit, int opt, value)
            |> ignore

    member _.swPageSetupPrinterPartAsmPrintWindow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterPartAsmPrintWindow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupPrinterPartAsmPrintWindow, int opt, value)
            |> ignore

    member _.swDisplayShadowsInShadedMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadowsInShadedMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadowsInShadedMode, int opt, value)
            |> ignore

    member _.swDrawingViewSmoothDynamicMotion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewSmoothDynamicMotion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewSmoothDynamicMotion, int opt, value)
            |> ignore

    member _.swDrawingEliminateDuplicateDimsOnInsert
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateDimsOnInsert, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateDimsOnInsert, int opt, value)
            |> ignore

    member _.swRapidDraftPrintOutOfSynchWaterMark
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swRapidDraftPrintOutOfSynchWaterMark, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swRapidDraftPrintOutOfSynchWaterMark, int opt, value)
            |> ignore

    member _.swDrawingViewAutoHideComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewAutoHideComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingViewAutoHideComponents, int opt, value)
            |> ignore

    member _.swEdgesDisplayShadedPlanes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDisplayShadedPlanes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDisplayShadedPlanes, int opt, value)
            |> ignore

    member _.swPlaneDisplayShowEdges
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowEdges, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowEdges, int opt, value)
            |> ignore

    member _.swPlaneDisplayShowIntersections
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowIntersections, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPlaneDisplayShowIntersections, int opt, value)
            |> ignore

    member _.swColorsUseSpecifiedEditColors
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseSpecifiedEditColors, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseSpecifiedEditColors, int opt, value)
            |> ignore

    member _.swEnablePerformanceEmail
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceEmail, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceEmail, int opt, value)
            |> ignore

    member _.swSnapOnlyIfGridDisplayed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapOnlyIfGridDisplayed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSnapOnlyIfGridDisplayed, int opt, value)
            |> ignore

    member _.swDetailingBalloonsDisplayWithBentLeader
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonsDisplayWithBentLeader, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonsDisplayWithBentLeader, int opt, value)
            |> ignore

    member _.swBOMConfigurationLocked
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationLocked, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationLocked, int opt, value)
            |> ignore

    member _.swBOMConfigurationUseDocumentFont
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseDocumentFont, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseDocumentFont, int opt, value)
            |> ignore

    member _.swBOMConfigurationUseSummaryInfo
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseSummaryInfo, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationUseSummaryInfo, int opt, value)
            |> ignore

    member _.swBOMConfigurationAlignBottom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationAlignBottom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMConfigurationAlignBottom, int opt, value)
            |> ignore

    member _.swBOMContentsDisplayAtTop
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMContentsDisplayAtTop, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMContentsDisplayAtTop, int opt, value)
            |> ignore

    member _.swBOMControlIdFromAssembly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlIdFromAssembly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlIdFromAssembly, int opt, value)
            |> ignore

    member _.swBOMControlMissingRows
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlMissingRows, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlMissingRows, int opt, value)
            |> ignore

    member _.swBOMControlSplitTable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlSplitTable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBOMControlSplitTable, int opt, value)
            |> ignore

    member _.swAutomaticDrawingViewUpdateDefault
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateDefault, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateDefault, int opt, value)
            |> ignore

    member _.swAutomaticDrawingViewUpdateForceOff
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateForceOff, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticDrawingViewUpdateForceOff, int opt, value)
            |> ignore

    member _.swAnnotationDisplayHideDanglingDim
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAnnotationDisplayHideDanglingDim, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAnnotationDisplayHideDanglingDim, int opt, value)
            |> ignore

    member _.swDetailingDimBreakAroundArrow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimBreakAroundArrow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimBreakAroundArrow, int opt, value)
            |> ignore

    member _.swDetailingDimensionsToleranceUseParentheses
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseParentheses, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseParentheses, int opt, value)
            |> ignore

    member _.swDetailingDimensionsToleranceUseDimensionFont
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseDimensionFont, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceUseDimensionFont, int opt, value)
            |> ignore

    member _.swImageQualityApplyToAllReferencedPartDoc
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityApplyToAllReferencedPartDoc, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityApplyToAllReferencedPartDoc, int opt, value)
            |> ignore

    member _.swPrintBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintBackground, int opt, value)
            |> ignore

    member _.swEDrawingsCompression
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsCompression, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsCompression, int opt, value)
            |> ignore

    member _.swImportSolidSurface
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidSurface, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidSurface, int opt, value)
            |> ignore

    member _.swImportFreeCurves
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportFreeCurves, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportFreeCurves, int opt, value)
            |> ignore

    member _.swImport2dCurvesAs2dSketch
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImport2dCurvesAs2dSketch, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImport2dCurvesAs2dSketch, int opt, value)
            |> ignore

    member _.swLargeAsmModeAutoLoadLightweight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoLoadLightweight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoLoadLightweight, int opt, value)
            |> ignore

    member _.swLargeAsmModeUpdateMassPropsOnSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUpdateMassPropsOnSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUpdateMassPropsOnSave, int opt, value)
            |> ignore

    member _.swLargeAsmModeAutoRecover
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoRecover, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoRecover, int opt, value)
            |> ignore

    member _.swLargeAsmModeRemoveDetail
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeRemoveDetail, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeRemoveDetail, int opt, value)
            |> ignore

    member _.swLargeAsmModeHideAllItems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeHideAllItems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeHideAllItems, int opt, value)
            |> ignore

    member _.swLargeAsmModeDynHighlightFeatureMgr
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightFeatureMgr, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightFeatureMgr, int opt, value)
            |> ignore

    member _.swLargeAsmModeDynHighlightGraphicsView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightGraphicsView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDynHighlightGraphicsView, int opt, value)
            |> ignore

    member _.swLargeAsmModeAntiAliasEdgesFastMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAntiAliasEdgesFastMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAntiAliasEdgesFastMode, int opt, value)
            |> ignore

    member _.swLargeAsmModeShadowsShadedMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShadowsShadedMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShadowsShadedMode, int opt, value)
            |> ignore

    member _.swLargeAsmModeTransparencyNormalViewMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyNormalViewMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyNormalViewMode, int opt, value)
            |> ignore

    member _.swLargeAsmModeTransparencyDynamicViewMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyDynamicViewMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeTransparencyDynamicViewMode, int opt, value)
            |> ignore

    member _.swLargeAsmModeShowContentsDragDrawView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShowContentsDragDrawView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeShowContentsDragDrawView, int opt, value)
            |> ignore

    member _.swLargeAsmModeSmoothDynamicMotionDrawView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSmoothDynamicMotionDrawView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSmoothDynamicMotionDrawView, int opt, value)
            |> ignore

    member _.swLargeAsmModeDrawingHLREdgesWhenShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingHLREdgesWhenShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingHLREdgesWhenShaded, int opt, value)
            |> ignore

    member _.swLargeAsmModeAutoHideCompsDrawViewCreation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoHideCompsDrawViewCreation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoHideCompsDrawViewCreation, int opt, value)
            |> ignore

    member _.swLargeAsmModeDrawingAutoLoadModels
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingAutoLoadModels, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDrawingAutoLoadModels, int opt, value)
            |> ignore

    member _.swLargeAsmModeAlwaysGenerateCurvature
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAlwaysGenerateCurvature, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAlwaysGenerateCurvature, int opt, value)
            |> ignore

    member _.swImportStepConfigData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStepConfigData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStepConfigData, int opt, value)
            |> ignore

    member _.swIGESExportSolidAndSurface
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSolidAndSurface, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSolidAndSurface, int opt, value)
            |> ignore

    member _.swIGESExportFreeCurves
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportFreeCurves, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportFreeCurves, int opt, value)
            |> ignore

    member _.swIGESExportAsWireframe
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportAsWireframe, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportAsWireframe, int opt, value)
            |> ignore

    member _.swDetailingDimensionsAngularToleranceUseParentheses
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsAngularToleranceUseParentheses, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsAngularToleranceUseParentheses, int opt, value)
            |> ignore

    member _.swDetailingDimensionsToleranceFitTolUseDimensionFont
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceFitTolUseDimensionFont, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceFitTolUseDimensionFont, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterMarks
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarks, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarks, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterLines, int opt, value)
            |> ignore

    member _.swSTLPreview
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLPreview, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSTLPreview, int opt, value)
            |> ignore

    member _.swDetailingCenterMarkUseCenterLine
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkUseCenterLine, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkUseCenterLine, int opt, value)
            |> ignore

    member _.swMaterialPropertySolidFill
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaterialPropertySolidFill, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMaterialPropertySolidFill, int opt, value)
            |> ignore

    member _.swSaveEModelData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveEModelData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveEModelData, int opt, value)
            |> ignore

    member _.swDisplayCurves
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCurves, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCurves, int opt, value)
            |> ignore

    member _.swDisplaySketches
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketches, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketches, int opt, value)
            |> ignore

    member _.swDisplayAllAnnotations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllAnnotations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllAnnotations, int opt, value)
            |> ignore

    member _.swViewDisplayHideAllTypes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDisplayHideAllTypes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDisplayHideAllTypes, int opt, value)
            |> ignore

    member _.swColorsUseShadedEdgeColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseShadedEdgeColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsUseShadedEdgeColor, int opt, value)
            |> ignore

    member _.swViewpointPreserveNormals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewpointPreserveNormals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewpointPreserveNormals, int opt, value)
            |> ignore

    member _.swSaveBackupFilesInSameLocationAsOriginal
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveBackupFilesInSameLocationAsOriginal, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveBackupFilesInSameLocationAsOriginal, int opt, value)
            |> ignore

    member _.swNotifySNLNotObtainedForEDrawingsSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swNotifySNLNotObtainedForEDrawingsSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swNotifySNLNotObtainedForEDrawingsSave, int opt, value)
            |> ignore

    member _.swPerformanceRemoveDetailDuringZoomPanRotate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceRemoveDetailDuringZoomPanRotate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceRemoveDetailDuringZoomPanRotate, int opt, value)
            |> ignore

    member _.swDisplayEnableSelectionThroughTransparency
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEnableSelectionThroughTransparency, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEnableSelectionThroughTransparency, int opt, value)
            |> ignore

    member _.swDisplayReferenceTriad
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceTriad, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferenceTriad, int opt, value)
            |> ignore

    member _.swDrawingsDefaultDisplayTypeFastHLRHLV
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeFastHLRHLV, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeFastHLRHLV, int opt, value)
            |> ignore

    member _.swDrawingsDefaultDisplayTypeHLREdgesWhenShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgesWhenShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgesWhenShaded, int opt, value)
            |> ignore

    member _.swPerformanceSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSave, int opt, value)
            |> ignore

    member _.swDetailingAutoUpdateBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoUpdateBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoUpdateBOM, int opt, value)
            |> ignore

    member _.swImageQualityUseHighQualityEdgeSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseHighQualityEdgeSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseHighQualityEdgeSize, int opt, value)
            |> ignore

    member _.swDrawingSaveShadedData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSaveShadedData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSaveShadedData, int opt, value)
            |> ignore

    member _.swEDrawingsOkayToMeasure
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsOkayToMeasure, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsOkayToMeasure, int opt, value)
            |> ignore

    member _.swBomTableKeepMissingItems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableKeepMissingItems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableKeepMissingItems, int opt, value)
            |> ignore

    member _.swBomTableStrikeThroughMissingItems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableStrikeThroughMissingItems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableStrikeThroughMissingItems, int opt, value)
            |> ignore

    member _.swRevisionTableUpdateAllLabels
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swRevisionTableUpdateAllLabels, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swRevisionTableUpdateAllLabels, int opt, value)
            |> ignore

    member _.swIGESImportShowLevel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESImportShowLevel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESImportShowLevel, int opt, value)
            |> ignore

    member _.swColorsMatchViewAndFeatureManagerBackground
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsMatchViewAndFeatureManagerBackground, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsMatchViewAndFeatureManagerBackground, int opt, value)
            |> ignore

    member _.swEDrawingsSaveShadedDataInDrawings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveShadedDataInDrawings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveShadedDataInDrawings, int opt, value)
            |> ignore

    member _.swDisplayReferencePoints2
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints2, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayReferencePoints2, int opt, value)
            |> ignore

    member _.swImportMultBodyAsPartData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMultBodyAsPartData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMultBodyAsPartData, int opt, value)
            |> ignore

    member _.swEDrawingsExportSTLOkay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsExportSTLOkay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsExportSTLOkay, int opt, value)
            |> ignore

    member _.swDetailingDisplaySFSymbolsPer2002
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplaySFSymbolsPer2002, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplaySFSymbolsPer2002, int opt, value)
            |> ignore

    member _.swDontCopyQTYColumnNameFromTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDontCopyQTYColumnNameFromTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDontCopyQTYColumnNameFromTemplate, int opt, value)
            |> ignore

    member _.swEDrawingsSaveAnimationOkay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationOkay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationOkay, int opt, value)
            |> ignore

    member _.swInsertViewForNewDrawing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertViewForNewDrawing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertViewForNewDrawing, int opt, value)
            |> ignore

    member _.swInsertComponentForNewAssembly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertComponentForNewAssembly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInsertComponentForNewAssembly, int opt, value)
            |> ignore

    member _.swCollabTopDocsNoPromptOrSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabTopDocsNoPromptOrSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabTopDocsNoPromptOrSave, int opt, value)
            |> ignore

    member _.swCollabEnableMultiUser
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabEnableMultiUser, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabEnableMultiUser, int opt, value)
            |> ignore

    member _.swViewSketchRelations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewSketchRelations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewSketchRelations, int opt, value)
            |> ignore

    member _.swDisplayShadedCosmeticThreads
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadedCosmeticThreads, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayShadedCosmeticThreads, int opt, value)
            |> ignore

    member _.swCollabAddShortcutMenuItems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddShortcutMenuItems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddShortcutMenuItems, int opt, value)
            |> ignore

    member _.swCollabCheckReadOnlyModifiedByOthers
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabCheckReadOnlyModifiedByOthers, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabCheckReadOnlyModifiedByOthers, int opt, value)
            |> ignore

    member _.swDisplayAllSplineHandles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllSplineHandles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAllSplineHandles, int opt, value)
            |> ignore

    member _.swAssemblyAllowComponentMoveByDragging
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowComponentMoveByDragging, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowComponentMoveByDragging, int opt, value)
            |> ignore

    member _.swHoleTableCombineTags
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineTags, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineTags, int opt, value)
            |> ignore

    member _.swHoleTableCombineSameSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineSameSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableCombineSameSize, int opt, value)
            |> ignore

    member _.swHoleTableHoleCentersVisible
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableHoleCentersVisible, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableHoleCentersVisible, int opt, value)
            |> ignore

    member _.swHoleTableAutomaticUpdate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAutomaticUpdate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAutomaticUpdate, int opt, value)
            |> ignore

    member _.swDetailingDimOffsetText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimOffsetText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimOffsetText, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_PerStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_PerStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_PerStandard, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_Stacked
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_Stacked, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_Stacked, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_PerStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_PerStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_PerStandard, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_Stacked
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_Stacked, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_Stacked, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_PerStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_PerStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_PerStandard, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_Stacked
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_Stacked, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_Stacked, int opt, value)
            |> ignore

    member _.swExportVrmlAllComponentsInSingleFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExportVrmlAllComponentsInSingleFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExportVrmlAllComponentsInSingleFile, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertBalloons
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertBalloons, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertBalloons, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertDimsMarkedForDrawing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDimsMarkedForDrawing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDimsMarkedForDrawing, int opt, value)
            |> ignore

    member _.swSketchInference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchInference, int opt, value)
            |> ignore

    member _.swSketchNoSolveMove
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchNoSolveMove, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchNoSolveMove, int opt, value)
            |> ignore

    member _.swDetailingDimANSIBentLeader
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimANSIBentLeader, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimANSIBentLeader, int opt, value)
            |> ignore

    member _.swUnitsDualLinearRoundToNearestFraction
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearRoundToNearestFraction, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearRoundToNearestFraction, int opt, value)
            |> ignore

    member _.swUnitsDualLinearFeetAndInchesFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearFeetAndInchesFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUnitsDualLinearFeetAndInchesFormat, int opt, value)
            |> ignore

    member _.swOneConfigOnlyTopLevelBom
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOneConfigOnlyTopLevelBom, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOneConfigOnlyTopLevelBom, int opt, value)
            |> ignore

    member _.swImageQualitySaveTesselationWithPartDoc
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualitySaveTesselationWithPartDoc, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualitySaveTesselationWithPartDoc, int opt, value)
            |> ignore

    member _.swShowSheetMetalBendNotes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowSheetMetalBendNotes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowSheetMetalBendNotes, int opt, value)
            |> ignore

    member _.swDetailingCThreadDisplayHighQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCThreadDisplayHighQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCThreadDisplayHighQuality, int opt, value)
            |> ignore

    member _.swDetailingDimsPrefixInsideBasicTolBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsPrefixInsideBasicTolBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsPrefixInsideBasicTolBox, int opt, value)
            |> ignore

    member _.swDetailingDimsAutoJogOrdinates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogOrdinates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogOrdinates, int opt, value)
            |> ignore

    member _.swColorsWireframeHLRShadedSame
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsWireframeHLRShadedSame, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorsWireframeHLRShadedSame, int opt, value)
            |> ignore

    member _.swEditMacroAfterRecord
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditMacroAfterRecord, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditMacroAfterRecord, int opt, value)
            |> ignore

    member _.swUseEnglishLanguageFeatureNames
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguageFeatureNames, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseEnglishLanguageFeatureNames, int opt, value)
            |> ignore

    member _.swDrawingDisplayArcCenterPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayArcCenterPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayArcCenterPoints, int opt, value)
            |> ignore

    member _.swDrawingDisplayEntityPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayEntityPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplayEntityPoints, int opt, value)
            |> ignore

    member _.swDrawingPrintBreaklinesInBrokenView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingPrintBreaklinesInBrokenView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingPrintBreaklinesInBrokenView, int opt, value)
            |> ignore

    member _.swSketchSnapsPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPoints, int opt, value)
            |> ignore

    member _.swSketchSnapsCenterPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsCenterPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsCenterPoints, int opt, value)
            |> ignore

    member _.swSketchSnapsMidPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsMidPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsMidPoints, int opt, value)
            |> ignore

    member _.swSketchSnapsQuadrantPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsQuadrantPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsQuadrantPoints, int opt, value)
            |> ignore

    member _.swSketchSnapsIntersections
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsIntersections, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsIntersections, int opt, value)
            |> ignore

    member _.swSketchSnapsNearest
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsNearest, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsNearest, int opt, value)
            |> ignore

    member _.swSketchSnapsTangent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsTangent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsTangent, int opt, value)
            |> ignore

    member _.swSketchSnapsPerpendicular
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPerpendicular, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsPerpendicular, int opt, value)
            |> ignore

    member _.swSketchSnapsParallel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsParallel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsParallel, int opt, value)
            |> ignore

    member _.swSketchSnapsHVLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVLines, int opt, value)
            |> ignore

    member _.swSketchSnapsHVPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsHVPoints, int opt, value)
            |> ignore

    member _.swSketchSnapsLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsLength, int opt, value)
            |> ignore

    member _.swSketchSnapsGrid
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsGrid, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsGrid, int opt, value)
            |> ignore

    member _.swSketchSnapToGridIfDisplayed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapToGridIfDisplayed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapToGridIfDisplayed, int opt, value)
            |> ignore

    member _.swSketchSnapsAngle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsAngle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchSnapsAngle, int opt, value)
            |> ignore

    member _.swPerformanceSheetMetalIgnoreSelfIntersect
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSheetMetalIgnoreSelfIntersect, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceSheetMetalIgnoreSelfIntersect, int opt, value)
            |> ignore

    member _.swExternalReferencesDisable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExternalReferencesDisable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExternalReferencesDisable, int opt, value)
            |> ignore

    member _.swFileExplorerShowMyDocuments
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyDocuments, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyDocuments, int opt, value)
            |> ignore

    member _.swFileExplorerShowMyComputer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyComputer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyComputer, int opt, value)
            |> ignore

    member _.swFileExplorerShowMyNetworkPlaces
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyNetworkPlaces, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowMyNetworkPlaces, int opt, value)
            |> ignore

    member _.swFileExplorerShowRecentDocuments
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowRecentDocuments, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowRecentDocuments, int opt, value)
            |> ignore

    member _.swFileExplorerShowHiddenReferencedDocuments
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowHiddenReferencedDocuments, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowHiddenReferencedDocuments, int opt, value)
            |> ignore

    member _.swFileExplorerShowSamples
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowSamples, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFileExplorerShowSamples, int opt, value)
            |> ignore

    member _.swBomTableDontAddQTYNextToConfigName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableDontAddQTYNextToConfigName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableDontAddQTYNextToConfigName, int opt, value)
            |> ignore

    member _.swImportAutoRunImportDiagnosticsPersist
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnosticsPersist, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnosticsPersist, int opt, value)
            |> ignore

    member _.swImportAutoRunImportDiagnostics
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnostics, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportAutoRunImportDiagnostics, int opt, value)
            |> ignore

    member _.swQuickTipsPart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsPart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsPart, int opt, value)
            |> ignore

    member _.swQuickTipsAssembly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsAssembly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsAssembly, int opt, value)
            |> ignore

    member _.swQuickTipsDrawing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsDrawing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickTipsDrawing, int opt, value)
            |> ignore

    member _.swSketchLineLengthVirtualSharp3d
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchLineLengthVirtualSharp3d, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchLineLengthVirtualSharp3d, int opt, value)
            |> ignore

    member _.swSketchShowSplineControlPolygon
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineControlPolygon, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineControlPolygon, int opt, value)
            |> ignore

    member _.swLargeAsmModeEnabled
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeEnabled, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeEnabled, int opt, value)
            |> ignore

    member _.swLargeAsmModeSuspendAutoRebuild
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSuspendAutoRebuild, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeSuspendAutoRebuild, int opt, value)
            |> ignore

    member _.swLargeAsmModeUseHLREdgesInShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseHLREdgesInShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseHLREdgesInShaded, int opt, value)
            |> ignore

    member _.swFourViewportProjectionType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFourViewportProjectionType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFourViewportProjectionType, int opt, value)
            |> ignore

    member _.swImportIDFAddDrilledHoles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFAddDrilledHoles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFAddDrilledHoles, int opt, value)
            |> ignore

    member _.swImportIDFReverseUndersideComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFReverseUndersideComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIDFReverseUndersideComponents, int opt, value)
            |> ignore

    member _.swImportStlVrmlTextureInformation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStlVrmlTextureInformation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportStlVrmlTextureInformation, int opt, value)
            |> ignore

    member _.swImportUGToolBodies
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUGToolBodies, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUGToolBodies, int opt, value)
            |> ignore

    member _.swDxfUseSolidworksLayers
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfUseSolidworksLayers, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfUseSolidworksLayers, int opt, value)
            |> ignore

    member _.swDisplayRelationsShowPropertyManager
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRelationsShowPropertyManager, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayRelationsShowPropertyManager, int opt, value)
            |> ignore

    member _.swReferenceTriadUseAlternateLabels
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceTriadUseAlternateLabels, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceTriadUseAlternateLabels, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterMarksForHoles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHoles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHoles, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterMarksForFillets
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFillets, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFillets, int opt, value)
            |> ignore

    member _.swDetailingScaleWithDimHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithDimHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithDimHeight, int opt, value)
            |> ignore

    member _.swDetailingScaleWithSectionTextHeight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithSectionTextHeight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleWithSectionTextHeight, int opt, value)
            |> ignore

    member _.swUserEnableAutoFix
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableAutoFix, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableAutoFix, int opt, value)
            |> ignore

    member _.swDisplayLights
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLights, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLights, int opt, value)
            |> ignore

    member _.swDisplayCameras
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameras, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameras, int opt, value)
            |> ignore

    member _.swDxfEndPointMerge
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfEndPointMerge, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfEndPointMerge, int opt, value)
            |> ignore

    member _.swPerformancePreviewDuringOpen
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformancePreviewDuringOpen, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformancePreviewDuringOpen, int opt, value)
            |> ignore

    member _.swImportDxfDimsToPartSketch
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDxfDimsToPartSketch, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDxfDimsToPartSketch, int opt, value)
            |> ignore

    member _.swAutoSaveEnable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSaveEnable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSaveEnable, int opt, value)
            |> ignore

    member _.swBackupEnable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupEnable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupEnable, int opt, value)
            |> ignore

    member _.swBackupRemoveEnable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupRemoveEnable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupRemoveEnable, int opt, value)
            |> ignore

    member _.swSaveReminderEnable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderEnable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderEnable, int opt, value)
            |> ignore

    member _.swPDFExportInColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportInColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportInColor, int opt, value)
            |> ignore

    member _.swPDFExportEmbedFonts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportEmbedFonts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportEmbedFonts, int opt, value)
            |> ignore

    member _.swPDFExportHighQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportHighQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportHighQuality, int opt, value)
            |> ignore

    member _.swPDFExportPrintHeaderFooter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportPrintHeaderFooter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportPrintHeaderFooter, int opt, value)
            |> ignore

    member _.swPDFExportUseCurrentPrintLineWeights
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportUseCurrentPrintLineWeights, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportUseCurrentPrintLineWeights, int opt, value)
            |> ignore

    member _.swSketchShadowDrag
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShadowDrag, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShadowDrag, int opt, value)
            |> ignore

    member _.swWarnSaveUpdateErrors
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSaveUpdateErrors, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSaveUpdateErrors, int opt, value)
            |> ignore

    member _.swEnablePerformanceFeedback
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceFeedback, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformanceFeedback, int opt, value)
            |> ignore

    member _.swShowDrawingViewPalette
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDrawingViewPalette, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowDrawingViewPalette, int opt, value)
            |> ignore

    member _.swDisplayDimensionsFlatToScreen
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimensionsFlatToScreen, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimensionsFlatToScreen, int opt, value)
            |> ignore

    member _.swPerformanceAlwaysResolveSubassemblies
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysResolveSubassemblies, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPerformanceAlwaysResolveSubassemblies, int opt, value)
            |> ignore

    member _.swWarnSavingReferencedDoc
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSavingReferencedDoc, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnSavingReferencedDoc, int opt, value)
            |> ignore

    member _.swFeatureManagerTransparentFlyout
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerTransparentFlyout, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerTransparentFlyout, int opt, value)
            |> ignore

    member _.swDetailingDimsShowBroken
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowBroken, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowBroken, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_AboveView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_AboveView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_AboveView, int opt, value)
            |> ignore

    member _.swDetailingSectionViewLabels_AboveView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_AboveView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionViewLabels_AboveView, int opt, value)
            |> ignore

    member _.swDetailingAuxViewLabels_AboveView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_AboveView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxViewLabels_AboveView, int opt, value)
            |> ignore

    member _.swPreserveRedundantGeometry
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreserveRedundantGeometry, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreserveRedundantGeometry, int opt, value)
            |> ignore

    member _.swTranslateNameAttribFromKernelBody
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTranslateNameAttribFromKernelBody, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTranslateNameAttribFromKernelBody, int opt, value)
            |> ignore

    member _.swPageSetupHighQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupHighQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupHighQuality, int opt, value)
            |> ignore

    member _.swSketchShowSplineOuterComb
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineOuterComb, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchShowSplineOuterComb, int opt, value)
            |> ignore

    member _.swViewShowAnnotationLinkErrors
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkErrors, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkErrors, int opt, value)
            |> ignore

    member _.swViewShowAnnotationLinkVariables
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkVariables, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewShowAnnotationLinkVariables, int opt, value)
            |> ignore

    member _.swHideUnitsOfLengthValues
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideUnitsOfLengthValues, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideUnitsOfLengthValues, int opt, value)
            |> ignore

    member _.swShowNewsFeedsInTaskPane
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowNewsFeedsInTaskPane, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowNewsFeedsInTaskPane, int opt, value)
            |> ignore

    member _.swViewReverseWheelZoomDirection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewReverseWheelZoomDirection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewReverseWheelZoomDirection, int opt, value)
            |> ignore

    member _.swDrawingMarkAllDimensionsForDrawing
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingMarkAllDimensionsForDrawing, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingMarkAllDimensionsForDrawing, int opt, value)
            |> ignore

    member _.swDrawingShowSheetFormatDialog
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingShowSheetFormatDialog, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingShowSheetFormatDialog, int opt, value)
            |> ignore

    member _.swDrawingSheetBackgroundAsPicture
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetBackgroundAsPicture, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetBackgroundAsPicture, int opt, value)
            |> ignore

    member _.swDisplayNotesFlatToScreen
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotesFlatToScreen, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayNotesFlatToScreen, int opt, value)
            |> ignore

    member _.swDisplayMissingRefsWhenEditFeature
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMissingRefsWhenEditFeature, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMissingRefsWhenEditFeature, int opt, value)
            |> ignore

    member _.swSearchWhileTyping
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchWhileTyping, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchWhileTyping, int opt, value)
            |> ignore

    member _.swDxfExportSplinesAsSplines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportSplinesAsSplines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportSplinesAsSplines, int opt, value)
            |> ignore

    member _.swDetailingDimsFollowDimXpertLayout
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsFollowDimXpertLayout, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsFollowDimXpertLayout, int opt, value)
            |> ignore

    member _.swDisplayDimXpertDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimXpertDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDimXpertDimensions, int opt, value)
            |> ignore

    member _.swDetailingShowHaloAroundAnnotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowHaloAroundAnnotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowHaloAroundAnnotation, int opt, value)
            |> ignore

    member _.swDetailingImportEntireAssemblyAnnotations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingImportEntireAssemblyAnnotations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingImportEntireAssemblyAnnotations, int opt, value)
            |> ignore

    member _.swSearchIncludeContentCentral
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchIncludeContentCentral, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchIncludeContentCentral, int opt, value)
            |> ignore

    member _.swUserEnablePlasticsMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode, int opt, value)
            |> ignore

    member _.swDrawingDisableNoteDimensionInference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteDimensionInference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteDimensionInference, int opt, value)
            |> ignore

    member _.swEDrawingsSaveAnimationToAllConfigs
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationToAllConfigs, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationToAllConfigs, int opt, value)
            |> ignore

    member _.swEDrawingsSaveAnimationRecalculate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationRecalculate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveAnimationRecalculate, int opt, value)
            |> ignore

    member _.swPromptForAutoMateFlip
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPromptForAutoMateFlip, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPromptForAutoMateFlip, int opt, value)
            |> ignore

    member _.swViewZoomFitAndCenter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewZoomFitAndCenter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewZoomFitAndCenter, int opt, value)
            |> ignore

    member _.swDisplayCameraFOVBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameraFOVBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCameraFOVBox, int opt, value)
            |> ignore

    member _.swSketchAcceptNumericInput
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAcceptNumericInput, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAcceptNumericInput, int opt, value)
            |> ignore

    member _.swDisableWeldmentConfigStrings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableWeldmentConfigStrings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableWeldmentConfigStrings, int opt, value)
            |> ignore

    member _.swDisplayLiveSections
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLiveSections, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayLiveSections, int opt, value)
            |> ignore

    member _.swDetailingAnnotationUseBentLeaders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationUseBentLeaders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationUseBentLeaders, int opt, value)
            |> ignore

    member _.swDetailingBalloonUseDocBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonUseDocBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBalloonUseDocBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingGtolUseDocBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingGtolUseDocBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingGtolUseDocBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingNoteUseDocBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoteUseDocBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoteUseDocBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingSFSymbolUseDocBentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSFSymbolUseDocBentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSFSymbolUseDocBentLeaderLength, int opt, value)
            |> ignore

    member _.swDetailingShowDualDimensionUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDualDimensionUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDualDimensionUnits, int opt, value)
            |> ignore

    member _.swDetailingOrdinateDisplayAsChain
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrdinateDisplayAsChain, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrdinateDisplayAsChain, int opt, value)
            |> ignore

    member _.swDetailingDatumsAnchorFilled
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorFilled, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorFilled, int opt, value)
            |> ignore

    member _.swDetailingDatumsAnchorShoulder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorShoulder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDatumsAnchorShoulder, int opt, value)
            |> ignore

    member _.swEDrawingsSaveBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsSaveBOM, int opt, value)
            |> ignore

    member _.swClearanceShowIgnored
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceShowIgnored, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceShowIgnored, int opt, value)
            |> ignore

    member _.swClearanceIgnoreEqual
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceIgnoreEqual, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceIgnoreEqual, int opt, value)
            |> ignore

    member _.swClearanceSubAssyAsComp
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceSubAssyAsComp, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceSubAssyAsComp, int opt, value)
            |> ignore

    member _.swClearanceCreateFasteners
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceCreateFasteners, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceCreateFasteners, int opt, value)
            |> ignore

    member _.swClearanceMakeTransparent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceMakeTransparent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceMakeTransparent, int opt, value)
            |> ignore

    member _.swClearanceDisplayOption
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceDisplayOption, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swClearanceDisplayOption, int opt, value)
            |> ignore

    member _.swStopDebuggingVstaOnExit
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStopDebuggingVstaOnExit, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStopDebuggingVstaOnExit, int opt, value)
            |> ignore

    member _.swOverrideQuantityColumnName
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOverrideQuantityColumnName, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOverrideQuantityColumnName, int opt, value)
            |> ignore

    member _.swAutoSizePropertyManager
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSizePropertyManager, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSizePropertyManager, int opt, value)
            |> ignore

    member _.swUserEnablePlasticsMode2
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode2, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnablePlasticsMode2, int opt, value)
            |> ignore

    member _.swStepExportSplitPeriodic
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportSplitPeriodic, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportSplitPeriodic, int opt, value)
            |> ignore

    member _.swStepExportFaceEdgeProps
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportFaceEdgeProps, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportFaceEdgeProps, int opt, value)
            |> ignore

    member _.swSATExportSplitPeriodic
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportSplitPeriodic, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportSplitPeriodic, int opt, value)
            |> ignore

    member _.swSATExportFaceEdgeProps
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportFaceEdgeProps, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportFaceEdgeProps, int opt, value)
            |> ignore

    member _.swDXFHighQualityExport
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFHighQualityExport, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFHighQualityExport, int opt, value)
            |> ignore

    member _.swDetailingNotesLeaderJustificationSnapping
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesLeaderJustificationSnapping, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNotesLeaderJustificationSnapping, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterMarksForSlots
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlots, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlots, int opt, value)
            |> ignore

    member _.swStepExportConfigurationData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportConfigurationData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportConfigurationData, int opt, value)
            |> ignore

    member _.swImageQualityZoomToFitForPreviewImages
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityZoomToFitForPreviewImages, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityZoomToFitForPreviewImages, int opt, value)
            |> ignore

    member _.swTiffPrintAllSheets
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintAllSheets, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintAllSheets, int opt, value)
            |> ignore

    member _.swTiffPrintUseSheetSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintUseSheetSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintUseSheetSize, int opt, value)
            |> ignore

    member _.swDrawingAutoSpaceDimsOnDelete
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutoSpaceDimsOnDelete, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingAutoSpaceDimsOnDelete, int opt, value)
            |> ignore

    member _.swDetailingTablesUseTemplateSettings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingTablesUseTemplateSettings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingTablesUseTemplateSettings, int opt, value)
            |> ignore

    member _.swSaveNewComponentsToExternalFile
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveNewComponentsToExternalFile, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveNewComponentsToExternalFile, int opt, value)
            |> ignore

    member _.swDoublePrimeMark
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDoublePrimeMark, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDoublePrimeMark, int opt, value)
            |> ignore

    member _.swDrawingHideEnds
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingHideEnds, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingHideEnds, int opt, value)
            |> ignore

    member _.swCenterLineMarkLinear
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkLinear, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkLinear, int opt, value)
            |> ignore

    member _.swCenterLineMarkCircular
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkCircular, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkCircular, int opt, value)
            |> ignore

    member _.swCenterLineMarkEndsOnlyLinear
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyLinear, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyLinear, int opt, value)
            |> ignore

    member _.swCenterLineMarkEndsOnlyCircular
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyCircular, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCenterLineMarkEndsOnlyCircular, int opt, value)
            |> ignore

    member _.swPreciseRenderingOfOverlappingGeometry
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreciseRenderingOfOverlappingGeometry, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPreciseRenderingOfOverlappingGeometry, int opt, value)
            |> ignore

    member _.swEnableMouseGestures
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableMouseGestures, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableMouseGestures, int opt, value)
            |> ignore

    member _.swPartExportFlatPattern
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartExportFlatPattern, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartExportFlatPattern, int opt, value)
            |> ignore

    member _.swHoleTableReuseDeleted
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableReuseDeleted, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableReuseDeleted, int opt, value)
            |> ignore

    member _.swHoleTableAddNewAtEnd
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAddNewAtEnd, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableAddNewAtEnd, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_SimplifyBends
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_SimplifyBends, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_SimplifyBends, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_CornerTreatment
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_CornerTreatment, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_CornerTreatment, int opt, value)
            |> ignore

    member _.swSATExportMultLumpsToSingleBody
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportMultLumpsToSingleBody, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSATExportMultLumpsToSingleBody, int opt, value)
            |> ignore

    member _.swPartDimXpertBlockTolerance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertBlockTolerance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertBlockTolerance, int opt, value)
            |> ignore

    member _.swPartDimXpertLocationInclinedPlane
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertLocationInclinedPlane, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertLocationInclinedPlane, int opt, value)
            |> ignore

    member _.swPartDimXpertChainHoleDimensionChain
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainHoleDimensionChain, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainHoleDimensionChain, int opt, value)
            |> ignore

    member _.swPartDimXpertChainPocketDimensionChain
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainPocketDimensionChain, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertChainPocketDimensionChain, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricApplyMMC
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricApplyMMC, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricApplyMMC, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricCreateBasicDimension
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricCreateBasicDimension, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricCreateBasicDimension, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricBasicDimensionChain
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricBasicDimensionChain, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricBasicDimensionChain, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricPositionAtMMC
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionAtMMC, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionAtMMC, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricPositionComposite
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionComposite, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricPositionComposite, int opt, value)
            |> ignore

    member _.swPartDimXpertGeometricSurfaceProfileComposite
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricSurfaceProfileComposite, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertGeometricSurfaceProfileComposite, int opt, value)
            |> ignore

    member _.swPartDimXpertDisplayEliminateDuplicates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayEliminateDuplicates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayEliminateDuplicates, int opt, value)
            |> ignore

    member _.swPartDimXpertDisplayShowInstanceCount
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayShowInstanceCount, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPartDimXpertDisplayShowInstanceCount, int opt, value)
            |> ignore

    member _.swDisplayPlaneSections
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlaneSections, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPlaneSections, int opt, value)
            |> ignore

    member _.swDisplaySimulationSymbol
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySimulationSymbol, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySimulationSymbol, int opt, value)
            |> ignore

    member _.swStoreImagesWithModel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreImagesWithModel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreImagesWithModel, int opt, value)
            |> ignore

    member _.swImageQualityUseOldTangentEdgeDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseOldTangentEdgeDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityUseOldTangentEdgeDisplay, int opt, value)
            |> ignore

    member _.swAddDimensionsToSketchEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSketchEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSketchEntity, int opt, value)
            |> ignore

    member _.swDetailingOrthoViewLabels_PerStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_PerStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_PerStandard, int opt, value)
            |> ignore

    member _.swDetailingOrthoViewLabels_AboveView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_AboveView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabels_AboveView, int opt, value)
            |> ignore

    member _.swDetailingOrthoViewLabelsEnableShow
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabelsEnableShow, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoViewLabelsEnableShow, int opt, value)
            |> ignore

    member _.swUseModelColorInDrawings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseModelColorInDrawings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseModelColorInDrawings, int opt, value)
            |> ignore

    member _.swDetailingShowDimensionUnits
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDimensionUnits, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowDimensionUnits, int opt, value)
            |> ignore

    member _.swUseFolderAsDefaultSearchLocation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderAsDefaultSearchLocation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseFolderAsDefaultSearchLocation, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterMarksForHolesAsm
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHolesAsm, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForHolesAsm, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterMarksForFilletsAsm
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFilletsAsm, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForFilletsAsm, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertCenterMarksForSlotsAsm
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlotsAsm, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertCenterMarksForSlotsAsm, int opt, value)
            |> ignore

    member _.swTableHoleDualDimensionDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleDualDimensionDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleDualDimensionDisplay, int opt, value)
            |> ignore

    member _.swTableHoleShowUnitsForDualDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleShowUnitsForDualDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTableHoleShowUnitsForDualDisplay, int opt, value)
            |> ignore

    member _.swDXFExportHiddenLayersOn
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersOn, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersOn, int opt, value)
            |> ignore

    member _.swDXFExportHiddenLayersWarnIsOn
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersWarnIsOn, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDXFExportHiddenLayersWarnIsOn, int opt, value)
            |> ignore

    member _.swDetailingLinkParentViewConfiguration
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinkParentViewConfiguration, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinkParentViewConfiguration, int opt, value)
            |> ignore

    member _.swLockRecentDocumentsList
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRecentDocumentsList, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRecentDocumentsList, int opt, value)
            |> ignore

    member _.swDxfAllSheetsToPaperSpace
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfAllSheetsToPaperSpace, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfAllSheetsToPaperSpace, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_DisableSplitters
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_DisableSplitters, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_DisableSplitters, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_WhenFlattenedShowPunches
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowPunches, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowPunches, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_WhenFlattenedShowProfiles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowProfiles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowProfiles, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_WhenFlattenedShowCenters
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowCenters, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowCenters, int opt, value)
            |> ignore

    member _.swUserEnableFreezeBar
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableFreezeBar, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUserEnableFreezeBar, int opt, value)
            |> ignore

    member _.swAddDimensionsToLineEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToLineEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToLineEntity, int opt, value)
            |> ignore

    member _.swAddDimensionsToRectangleEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToRectangleEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToRectangleEntity, int opt, value)
            |> ignore

    member _.swAddDimensionsToArcEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToArcEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToArcEntity, int opt, value)
            |> ignore

    member _.swAddDimensionsToCircleEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToCircleEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToCircleEntity, int opt, value)
            |> ignore

    member _.swAddDimensionsToSlotEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSlotEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDimensionsToSlotEntity, int opt, value)
            |> ignore

    member _.swUseChangedDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseChangedDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseChangedDimensions, int opt, value)
            |> ignore

    member _.swImportDoclessModelInAssem
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDoclessModelInAssem, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDoclessModelInAssem, int opt, value)
            |> ignore

    member _.swAddDrivenDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDrivenDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAddDrivenDimensions, int opt, value)
            |> ignore

    member _.swExtRefShowXInFeatureTree
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefShowXInFeatureTree, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefShowXInFeatureTree, int opt, value)
            |> ignore

    member _.swLargeAsmModeUseLargeDesignReview
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseLargeDesignReview, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeUseLargeDesignReview, int opt, value)
            |> ignore

    member _.swTablePunchShowUnitsForDualDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchShowUnitsForDualDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchShowUnitsForDualDisplay, int opt, value)
            |> ignore

    member _.swPunchTableCombineTags
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineTags, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineTags, int opt, value)
            |> ignore

    member _.swPunchTableCombineSameSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineSameSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPunchTableCombineSameSize, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_ShowGrainDirection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowGrainDirection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowGrainDirection, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_ShowFixedFace
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowFixedFace, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_ShowFixedFace, int opt, value)
            |> ignore

    member _.swAutoNormalToSketchMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoNormalToSketchMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoNormalToSketchMode, int opt, value)
            |> ignore

    member _.swUseSpeedpakModelColorInDrawings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSpeedpakModelColorInDrawings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUseSpeedpakModelColorInDrawings, int opt, value)
            |> ignore

    member _.swTablePunchDualDimensionsDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchDualDimensionsDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTablePunchDualDimensionsDisplay, int opt, value)
            |> ignore

    member _.swDrawingEliminateDuplicateModelNotesOnInsert
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateModelNotesOnInsert, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEliminateDuplicateModelNotesOnInsert, int opt, value)
            |> ignore

    member _.swDrawingDisableNoteMergeWhenDragging
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteMergeWhenDragging, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisableNoteMergeWhenDragging, int opt, value)
            |> ignore

    member _.swDrawingReuseViewLettersFromDeletedAuxilary
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingReuseViewLettersFromDeletedAuxilary, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingReuseViewLettersFromDeletedAuxilary, int opt, value)
            |> ignore

    member _.swFeatureManagerEnableTreeFilter
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableTreeFilter, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableTreeFilter, int opt, value)
            |> ignore

    member _.swDxfExportAllSheetsToPaperSpace
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportAllSheetsToPaperSpace, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDxfExportAllSheetsToPaperSpace, int opt, value)
            |> ignore

    member _.swDisplayAmbientOcclusionShadows
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAmbientOcclusionShadows, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayAmbientOcclusionShadows, int opt, value)
            |> ignore

    member _.swDraftQualityAmbientOcclusion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftQualityAmbientOcclusion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftQualityAmbientOcclusion, int opt, value)
            |> ignore

    member _.swQuickViewTransparencyEnabled
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyEnabled, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyEnabled, int opt, value)
            |> ignore

    member _.swQuickViewTransparencyDynamic
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyDynamic, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swQuickViewTransparencyDynamic, int opt, value)
            |> ignore

    member _.swDetailingDimsShowLeadingZeros
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowLeadingZeros, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsShowLeadingZeros, int opt, value)
            |> ignore

    member _.swHoleTableShowAnsiInchSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableShowAnsiInchSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHoleTableShowAnsiInchSize, int opt, value)
            |> ignore

    member _.swSaveWithoutCostingData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveWithoutCostingData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveWithoutCostingData, int opt, value)
            |> ignore

    member _.swLoadEnvelopeLightweight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeLightweight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeLightweight, int opt, value)
            |> ignore

    member _.swLoadEnvelopeReadOnly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeReadOnly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLoadEnvelopeReadOnly, int opt, value)
            |> ignore

    member _.swDetailingSectionHideShoulders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionHideShoulders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionHideShoulders, int opt, value)
            |> ignore

    member _.swLargeAsmModeDismissAutoUpdate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDismissAutoUpdate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeDismissAutoUpdate, int opt, value)
            |> ignore

    member _.swStepExport3DCurveFeatures
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExport3DCurveFeatures, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExport3DCurveFeatures, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertDowelSymForHolesPart
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesPart, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesPart, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertDowelSymForHolesAsm
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesAsm, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymForHolesAsm, int opt, value)
            |> ignore

    member _.swDetailingDimsApplyUpdatedRules
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsApplyUpdatedRules, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsApplyUpdatedRules, int opt, value)
            |> ignore

    member _.swDetailingAngularRunningDisplayAsChain
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningDisplayAsChain, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningDisplayAsChain, int opt, value)
            |> ignore

    member _.swDetailingAngularRunningRunBidirectionally
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningRunBidirectionally, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningRunBidirectionally, int opt, value)
            |> ignore

    member _.swDetailingDimsAutoJogAngularRunning
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogAngularRunning, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimsAutoJogAngularRunning, int opt, value)
            |> ignore

    member _.swDetailingLinearDimPrecisionLinkWithModel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearDimPrecisionLinkWithModel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearDimPrecisionLinkWithModel, int opt, value)
            |> ignore

    member _.swDetailingAltLinearDimPrecisionLinkWithModel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAltLinearDimPrecisionLinkWithModel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAltLinearDimPrecisionLinkWithModel, int opt, value)
            |> ignore

    member _.swDetailingDisplayDualBasicDimensionInOneBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDualBasicDimensionInOneBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDisplayDualBasicDimensionInOneBox, int opt, value)
            |> ignore

    member _.swAutoScaleTextureSFDecalsToModelSize
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoScaleTextureSFDecalsToModelSize, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoScaleTextureSFDecalsToModelSize, int opt, value)
            |> ignore

    member _.swLargeAsmModeAutoCheckUpdateAllComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoCheckUpdateAllComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeAutoCheckUpdateAllComponents, int opt, value)
            |> ignore

    member _.swDisplaySpeedpakGraphicsCircle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySpeedpakGraphicsCircle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySpeedpakGraphicsCircle, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesUseDocLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesUseDocLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesUseDocLeaderLength, int opt, value)
            |> ignore

    member _.swSheetMetalBendNotesLeaderJustificationSnapping
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesLeaderJustificationSnapping, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBendNotesLeaderJustificationSnapping, int opt, value)
            |> ignore

    member _.swEnableSoundsForSolidWorksEvents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableSoundsForSolidWorksEvents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableSoundsForSolidWorksEvents, int opt, value)
            |> ignore

    member _.swSearchShowSolidWorksSearchBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchShowSolidWorksSearchBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchShowSolidWorksSearchBox, int opt, value)
            |> ignore

    member _.swSearchDissectionScheduleDaily
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchDissectionScheduleDaily, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSearchDissectionScheduleDaily, int opt, value)
            |> ignore

    member _.swDrawingDisplaySketchHatchBehindGeometry
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchHatchBehindGeometry, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchHatchBehindGeometry, int opt, value)
            |> ignore

    member _.swDetailingRadialDimsDisplayWithSolidLeader
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayWithSolidLeader, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayWithSolidLeader, int opt, value)
            |> ignore

    member _.swSketchCreateDimensionOnlyWhenEntered
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateDimensionOnlyWhenEntered, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchCreateDimensionOnlyWhenEntered, int opt, value)
            |> ignore

    member _.swPurgeAllBodiesForNonActiveConfigurations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPurgeAllBodiesForNonActiveConfigurations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPurgeAllBodiesForNonActiveConfigurations, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertDowelSymbols
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbols, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbols, int opt, value)
            |> ignore

    member _.swDetailingAutoInsertDowelSymbolsAsm
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbolsAsm, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAutoInsertDowelSymbolsAsm, int opt, value)
            |> ignore

    member _.swSaveReminderAutoDismissEnable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderAutoDismissEnable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveReminderAutoDismissEnable, int opt, value)
            |> ignore

    member _.swDrawingDisplaySketchPicturesOnSheetBehindGeometry
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchPicturesOnSheetBehindGeometry, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingDisplaySketchPicturesOnSheetBehindGeometry, int opt, value)
            |> ignore

    member _.swDetailingShowUnitsForDualDisplay
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowUnitsForDualDisplay, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowUnitsForDualDisplay, int opt, value)
            |> ignore

    member _.swImageQualityWireframeHighCurveQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityWireframeHighCurveQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImageQualityWireframeHighCurveQuality, int opt, value)
            |> ignore

    member _.swDetailingCenterOfMassScaleByView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterOfMassScaleByView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterOfMassScaleByView, int opt, value)
            |> ignore

    member _.swDisplayCenterOfMassSymbol
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCenterOfMassSymbol, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCenterOfMassSymbol, int opt, value)
            |> ignore

    member _.swTiffPrintPadText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintPadText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTiffPrintPadText, int opt, value)
            |> ignore

    member _.swUpdateExternFilesDispList
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateExternFilesDispList, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUpdateExternFilesDispList, int opt, value)
            |> ignore

    member _.swDrawingsDefaultDisplayTypeHLREdgeQualityWhenShaded
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgeQualityWhenShaded, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingsDefaultDisplayTypeHLREdgeQualityWhenShaded, int opt, value)
            |> ignore

    member _.swDrawingSheetsUseDifferentSheetFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsUseDifferentSheetFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsUseDifferentSheetFormat, int opt, value)
            |> ignore

    member _.swDetailingMiscView_PerStandard
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_PerStandard, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_PerStandard, int opt, value)
            |> ignore

    member _.swDetailingMiscView_AboveView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AboveView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AboveView, int opt, value)
            |> ignore

    member _.swDetailingMiscView_AddViewLabelOnViewCreation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AddViewLabelOnViewCreation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_AddViewLabelOnViewCreation, int opt, value)
            |> ignore

    member _.swDetailingHighlightElements
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingHighlightElements, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingHighlightElements, int opt, value)
            |> ignore

    member _.swDetailingAllUpperCase
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAllUpperCase, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAllUpperCase, int opt, value)
            |> ignore

    member _.swDetailingMiscView_RemoveSpaceInScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_RemoveSpaceInScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_RemoveSpaceInScale, int opt, value)
            |> ignore

    member _.swWarnStartingSketchInContextAssembly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnStartingSketchInContextAssembly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWarnStartingSketchInContextAssembly, int opt, value)
            |> ignore

    member _.swDetailingAuxView_SimplifiedDetailed
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_SimplifiedDetailed, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_SimplifiedDetailed, int opt, value)
            |> ignore

    member _.swDetailingAuxView_RemoveSpaceInScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RemoveSpaceInScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RemoveSpaceInScale, int opt, value)
            |> ignore

    member _.swDetailingAuxView_RotateViewToHorizontalSheet
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateViewToHorizontalSheet, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateViewToHorizontalSheet, int opt, value)
            |> ignore

    member _.swDetailingAuxView_RotateClockwiseCounterclockwise
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateClockwiseCounterclockwise, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_RotateClockwiseCounterclockwise, int opt, value)
            |> ignore

    member _.swEdgeQualityShadedEdgeViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityShadedEdgeViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityShadedEdgeViews, int opt, value)
            |> ignore

    member _.swDetailingSectionView_RemoveSpaceInScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_RemoveSpaceInScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_RemoveSpaceInScale, int opt, value)
            |> ignore

    member _.swColorUseSelectedItemColorsSeedsPatterns
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorUseSelectedItemColorsSeedsPatterns, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swColorUseSelectedItemColorsSeedsPatterns, int opt, value)
            |> ignore

    member _.swDimensionsExtensionLineStyleSameAsLeader
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimensionsExtensionLineStyleSameAsLeader, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimensionsExtensionLineStyleSameAsLeader, int opt, value)
            |> ignore

    member _.swDraftingStandardUppercase
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardUppercase, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardUppercase, int opt, value)
            |> ignore

    member _.swEdgeQualityWireframeHiddenViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityWireframeHiddenViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgeQualityWireframeHiddenViews, int opt, value)
            |> ignore

    member _.swDetailingSplitWhenTextIsSolidLeaderAligned
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitWhenTextIsSolidLeaderAligned, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitWhenTextIsSolidLeaderAligned, int opt, value)
            |> ignore

    member _.swEdgesDefaultBulkSelection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection, int opt, value)
            |> ignore

    member _.swDisplayPatternInformationTooltips
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPatternInformationTooltips, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPatternInformationTooltips, int opt, value)
            |> ignore

    member _.swAssemblyUpdateModelGraphicsWhenSavingFiles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyUpdateModelGraphicsWhenSavingFiles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyUpdateModelGraphicsWhenSavingFiles, int opt, value)
            |> ignore

    member _.swDetailingOrthoView_AddViewLabelOnViewCreation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_AddViewLabelOnViewCreation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_AddViewLabelOnViewCreation, int opt, value)
            |> ignore

    member _.swDetailingOrthoView_RemoveSpaceInScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_RemoveSpaceInScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_RemoveSpaceInScale, int opt, value)
            |> ignore

    member _.swDetailingSplitDualDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitDualDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitDualDimensions, int opt, value)
            |> ignore

    member _.swDetailingDetailView_RemoveSpaceInScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_RemoveSpaceInScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_RemoveSpaceInScale, int opt, value)
            |> ignore

    member _.swEdgesShadedModeDisplayOptimizeForThinParts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedModeDisplayOptimizeForThinParts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesShadedModeDisplayOptimizeForThinParts, int opt, value)
            |> ignore

    member _.swWhileOpeningAssembliesAutoDismissMessages
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWhileOpeningAssembliesAutoDismissMessages, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWhileOpeningAssembliesAutoDismissMessages, int opt, value)
            |> ignore

    member _.swDetailingMiscView_DisplayLabelAboveView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_DisplayLabelAboveView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingMiscView_DisplayLabelAboveView, int opt, value)
            |> ignore

    member _.swDetailingSplitTextDualDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitTextDualDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSplitTextDualDimensions, int opt, value)
            |> ignore

    member _.swDetailingOrthoView_DisplayLabelAboveView
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_DisplayLabelAboveView, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingOrthoView_DisplayLabelAboveView, int opt, value)
            |> ignore

    member _.swIGESExportSplitPeriodic
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSplitPeriodic, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIGESExportSplitPeriodic, int opt, value)
            |> ignore

    member _.swRebuildSaveNewConfig
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swRebuildSaveNewConfig, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swRebuildSaveNewConfig, int opt, value)
            |> ignore

    member _.swTextSizeUseOperatingSystemScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTextSizeUseOperatingSystemScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTextSizeUseOperatingSystemScale, int opt, value)
            |> ignore

    member _.swPageSetupScaleDraftEdges
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupScaleDraftEdges, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPageSetupScaleDraftEdges, int opt, value)
            |> ignore

    member _.swWeldmentEnableAutomaticCutList
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList, int opt, value)
            |> ignore

    member _.swWeldmentEnableAutomaticUpdate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate, int opt, value)
            |> ignore

    member _.swDisplayCompAnnotations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCompAnnotations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCompAnnotations, int opt, value)
            |> ignore

    member _.swShowZoneLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowZoneLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowZoneLines, int opt, value)
            |> ignore

    member _.swDetailingAngDimensionsRemoveInsignificantZeros
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngDimensionsRemoveInsignificantZeros, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngDimensionsRemoveInsignificantZeros, int opt, value)
            |> ignore

    member _.swShowMateReferenceErrors
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowMateReferenceErrors, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowMateReferenceErrors, int opt, value)
            |> ignore

    member _.swDetailingDimensionsToleranceInwardRounding
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceInwardRounding, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDimensionsToleranceInwardRounding, int opt, value)
            |> ignore

    member _.swDetailingNoDimSpecificOptionSpecified
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoDimSpecificOptionSpecified, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingNoDimSpecificOptionSpecified, int opt, value)
            |> ignore

    member _.swPDFExportIncludeLayersNotToPrint
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeLayersNotToPrint, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeLayersNotToPrint, int opt, value)
            |> ignore

    member _.swEDrawingsIncludeLayersNotToPrint
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsIncludeLayersNotToPrint, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEDrawingsIncludeLayersNotToPrint, int opt, value)
            |> ignore

    member _.swTIFIncludeLayersNotToPrint
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFIncludeLayersNotToPrint, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFIncludeLayersNotToPrint, int opt, value)
            |> ignore

    member _.swSketchAddConstToRectEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstToRectEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstToRectEntity, int opt, value)
            |> ignore

    member _.swSketchAddConstLineDiagonalType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstLineDiagonalType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchAddConstLineDiagonalType, int opt, value)
            |> ignore

    member _.swDisableDerivedConfigurations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableDerivedConfigurations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisableDerivedConfigurations, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_WhenFlattenedShowGussetProfiles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetProfiles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetProfiles, int opt, value)
            |> ignore

    member _.swFlatPatternOpt_WhenFlattenedShowGussetCenters
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetCenters, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFlatPatternOpt_WhenFlattenedShowGussetCenters, int opt, value)
            |> ignore

    member _.swImportSLDXMLImportSketchData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportSketchData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportSketchData, int opt, value)
            |> ignore

    member _.swImportSLDXMLImportMechanismSketchObjectsAsBlocks
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportMechanismSketchObjectsAsBlocks, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportMechanismSketchObjectsAsBlocks, int opt, value)
            |> ignore

    member _.swAMFCompression
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFCompression, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFCompression, int opt, value)
            |> ignore

    member _.swAMFMaterials
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFMaterials, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFMaterials, int opt, value)
            |> ignore

    member _.swAMFColors
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFColors, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAMFColors, int opt, value)
            |> ignore

    member _.swEnhanceSmallFaceSelectionPrecision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnhanceSmallFaceSelectionPrecision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnhanceSmallFaceSelectionPrecision, int opt, value)
            |> ignore

    member _.swWeldmentRenameCutlistDescriptionPropertyValue
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue, int opt, value)
            |> ignore

    member _.swDetailingLocationLabelAddSameSheetNumber
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLocationLabelAddSameSheetNumber, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLocationLabelAddSameSheetNumber, int opt, value)
            |> ignore

    member _.swDetailingConnectionLinesHolePatternsCenterMarks
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingConnectionLinesHolePatternsCenterMarks, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingConnectionLinesHolePatternsCenterMarks, int opt, value)
            |> ignore

    member _.swDetailingAuxView_IncludeLocationLabelsForNewViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_IncludeLocationLabelsForNewViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAuxView_IncludeLocationLabelsForNewViews, int opt, value)
            |> ignore

    member _.swDetailingDetailView_IncludeLocationLabelsForNewViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_IncludeLocationLabelsForNewViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailView_IncludeLocationLabelsForNewViews, int opt, value)
            |> ignore

    member _.swDetailingSectionView_IncludeLocationLabelsForNewViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_IncludeLocationLabelsForNewViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingSectionView_IncludeLocationLabelsForNewViews, int opt, value)
            |> ignore

    member _.swDrawingSheetsListNumFirstInZoneCallout
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsListNumFirstInZoneCallout, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsListNumFirstInZoneCallout, int opt, value)
            |> ignore

    member _.swDrawingSheetsContinueColumnIteration
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsContinueColumnIteration, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsContinueColumnIteration, int opt, value)
            |> ignore

    member _.swDrawingEnableSymbolAddingNewRevision
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEnableSymbolAddingNewRevision, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingEnableSymbolAddingNewRevision, int opt, value)
            |> ignore

    member _.swImportSLDXMLImportAssemblyMatesData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportAssemblyMatesData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSLDXMLImportAssemblyMatesData, int opt, value)
            |> ignore

    member _.swNoteParagraphAutoNumbering
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swNoteParagraphAutoNumbering, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swNoteParagraphAutoNumbering, int opt, value)
            |> ignore

    member _.swBreakAlignWithParent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBreakAlignWithParent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBreakAlignWithParent, int opt, value)
            |> ignore

    member _.swShowAnnotationInAnnotationViews
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowAnnotationInAnnotationViews, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowAnnotationInAnnotationViews, int opt, value)
            |> ignore

    member _.swPrintGrid
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintGrid, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintGrid, int opt, value)
            |> ignore

    member _.swPrintZoneLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintZoneLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPrintZoneLines, int opt, value)
            |> ignore

    member _.swShowToolboxFavoritesFolder
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowToolboxFavoritesFolder, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowToolboxFavoritesFolder, int opt, value)
            |> ignore

    member _.swDetailingCenterMarkScaleByViewScale
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkScaleByViewScale, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingCenterMarkScaleByViewScale, int opt, value)
            |> ignore

    member _.swDrawingSheetsMatchCustomPropVals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsMatchCustomPropVals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingSheetsMatchCustomPropVals, int opt, value)
            |> ignore

    member _.swSaveAsmAsPartPreserveIDs
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveAsmAsPartPreserveIDs, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveAsmAsPartPreserveIDs, int opt, value)
            |> ignore

    member _.swHideShowSketchDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideShowSketchDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHideShowSketchDimensions, int opt, value)
            |> ignore

    member _.swPDFViewOnSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFViewOnSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFViewOnSave, int opt, value)
            |> ignore

    member _.swDisplayDatumCoordSystems
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumCoordSystems, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDatumCoordSystems, int opt, value)
            |> ignore

    member _.swMakeFirstSelectionTransparentInMateDialog
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeFirstSelectionTransparentInMateDialog, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeFirstSelectionTransparentInMateDialog, int opt, value)
            |> ignore

    member _.swMatchConfigurationNames
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMatchConfigurationNames, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMatchConfigurationNames, int opt, value)
            |> ignore

    member _.swDetailingLinearForeshortenedAutomatic
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearForeshortenedAutomatic, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingLinearForeshortenedAutomatic, int opt, value)
            |> ignore

    member _.swDetachSegmentOnDragMode
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetachSegmentOnDragMode, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetachSegmentOnDragMode, int opt, value)
            |> ignore

    member _.swDetailingDiameterForeshortenedAutomatic
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDiameterForeshortenedAutomatic, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDiameterForeshortenedAutomatic, int opt, value)
            |> ignore

    member _.swShowBreadcrumbsOnSelection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsOnSelection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsOnSelection, int opt, value)
            |> ignore

    member _.swDetailingShowPeriodWithBorders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowPeriodWithBorders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingShowPeriodWithBorders, int opt, value)
            |> ignore

    member _.swDetailingBorderDoubleLine
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderDoubleLine, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderDoubleLine, int opt, value)
            |> ignore

    member _.swDetailingBorderShowZoneDividers
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowZoneDividers, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowZoneDividers, int opt, value)
            |> ignore

    member _.swDetailingBorderShowColumns
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowColumns, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowColumns, int opt, value)
            |> ignore

    member _.swDetailingBorderShowRows
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowRows, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingBorderShowRows, int opt, value)
            |> ignore

    member _.swPointAxisCoordSystemHideNames
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPointAxisCoordSystemHideNames, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPointAxisCoordSystemHideNames, int opt, value)
            |> ignore

    member _.swFeatureManagerEnableRenamingComponent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableRenamingComponent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnableRenamingComponent, int opt, value)
            |> ignore

    member _.swDynamicReferenceVisualization_Parent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Parent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Parent, int opt, value)
            |> ignore

    member _.swDynamicReferenceVisualization_Child
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Child, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDynamicReferenceVisualization_Child, int opt, value)
            |> ignore

    member _.sw3MFAppearances
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFAppearances, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFAppearances, int opt, value)
            |> ignore

    member _.sw3MFMaterials
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFMaterials, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFMaterials, int opt, value)
            |> ignore

    member _.sw3MFDecals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFDecals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFDecals, int opt, value)
            |> ignore

    member _.swForceEnableImportDiagnosis
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swForceEnableImportDiagnosis, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swForceEnableImportDiagnosis, int opt, value)
            |> ignore

    member _.swDisplayCounterpartLocationLabel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCounterpartLocationLabel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayCounterpartLocationLabel, int opt, value)
            |> ignore

    member _.swExtRefLoadRefDocsInMemory
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefLoadRefDocsInMemory, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefLoadRefDocsInMemory, int opt, value)
            |> ignore

    member _.swScaleSketchOnFirstDimension
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swScaleSketchOnFirstDimension, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swScaleSketchOnFirstDimension, int opt, value)
            |> ignore

    member _.sw3MFShowInfoOnSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFShowInfoOnSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3MFShowInfoOnSave, int opt, value)
            |> ignore

    member _.swExtRefIncludeSubFolders
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefIncludeSubFolders, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefIncludeSubFolders, int opt, value)
            |> ignore

    member _.swExtRefExcludeActiveFoldersAndRecentSaveLocations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefExcludeActiveFoldersAndRecentSaveLocations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefExcludeActiveFoldersAndRecentSaveLocations, int opt, value)
            |> ignore

    member _.swSheetMetalOverrideTemplateParam
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateParam, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateParam, int opt, value)
            |> ignore

    member _.swSheetMetalOverrideTemplateAllowance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateAllowance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateAllowance, int opt, value)
            |> ignore

    member _.swSheetMetalOverrideTemplateRelief
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateRelief, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalOverrideTemplateRelief, int opt, value)
            |> ignore

    member _.swShadedSketchContours
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShadedSketchContours, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShadedSketchContours, int opt, value)
            |> ignore

    member _.swDetailingRadialDimsDisplayNearSideMessages
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayNearSideMessages, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingRadialDimsDisplayNearSideMessages, int opt, value)
            |> ignore

    member _.swCollabAddTimeStampToComments
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddTimeStampToComments, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabAddTimeStampToComments, int opt, value)
            |> ignore

    member _.swCollabShowCommentsInPropertyManager
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabShowCommentsInPropertyManager, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollabShowCommentsInPropertyManager, int opt, value)
            |> ignore

    member _.swDetailingScaleForJaggedStyle
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleForJaggedStyle, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingScaleForJaggedStyle, int opt, value)
            |> ignore

    member _.swDetailingDetailViewLabels_ScaleForJaggedOutline
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_ScaleForJaggedOutline, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingDetailViewLabels_ScaleForJaggedOutline, int opt, value)
            |> ignore

    member _.swFeatureManagerEnablePreviewHiddenComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnablePreviewHiddenComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerEnablePreviewHiddenComponents, int opt, value)
            |> ignore

    member _.swWeldmentCollectIdenticalBodies
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies, int opt, value)
            |> ignore

    member _.swLargeAsmModePreviewHiddenComponent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModePreviewHiddenComponent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModePreviewHiddenComponent, int opt, value)
            |> ignore

    member _.swLargeAsmModeVerificationOnRebuild
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeVerificationOnRebuild, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeVerificationOnRebuild, int opt, value)
            |> ignore

    member _.swLargeAsmModeImageQualityPerfomance
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeImageQualityPerfomance, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLargeAsmModeImageQualityPerfomance, int opt, value)
            |> ignore

    member _.sw3DPDFCompressLossyTessellation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3DPDFCompressLossyTessellation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.sw3DPDFCompressLossyTessellation, int opt, value)
            |> ignore

    member _.swDisplayDecals
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDecals, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDecals, int opt, value)
            |> ignore

    member _.swDisplayPartingLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPartingLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayPartingLines, int opt, value)
            |> ignore

    member _.swDisplaySketchPlanes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketchPlanes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplaySketchPlanes, int opt, value)
            |> ignore

    member _.swDisplayWeldBead
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldBead, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayWeldBead, int opt, value)
            |> ignore

    member _.swIFCOmniClassPreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCOmniClassPreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCOmniClassPreference, int opt, value)
            |> ignore

    member _.swIFCUniClass2Preference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCUniClass2Preference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCUniClass2Preference, int opt, value)
            |> ignore

    member _.swIFCCustomPropsPreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCCustomPropsPreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCCustomPropsPreference, int opt, value)
            |> ignore

    member _.swIFCMaterialsMassPropertiesPreference
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCMaterialsMassPropertiesPreference, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIFCMaterialsMassPropertiesPreference, int opt, value)
            |> ignore

    member _.swDisplayEquationIds
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEquationIds, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayEquationIds, int opt, value)
            |> ignore

    member _.swMagMatePreAlign
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMagMatePreAlign, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMagMatePreAlign, int opt, value)
            |> ignore

    member _.swOptimizeMatePlacement
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swOptimizeMatePlacement, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swOptimizeMatePlacement, int opt, value)
            |> ignore

    member _.swPdfIncludeBookmarks
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPdfIncludeBookmarks, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPdfIncludeBookmarks, int opt, value)
            |> ignore

    member _.swDisplayGraphicsComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGraphicsComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayGraphicsComponents, int opt, value)
            |> ignore

    member _.swDraftingStandardAllUppercaseForTable
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForTable, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForTable, int opt, value)
            |> ignore

    member _.swTransferHoleWizardSizeComboBoxSettings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransferHoleWizardSizeComboBoxSettings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTransferHoleWizardSizeComboBoxSettings, int opt, value)
            |> ignore

    member _.swAssemblyAllowCreationOfMisalignedMates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowCreationOfMisalignedMates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowCreationOfMisalignedMates, int opt, value)
            |> ignore

    member _.swVrmlStlImportAsPSMesh
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportAsPSMesh, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportAsPSMesh, int opt, value)
            |> ignore

    member _.swSolidBBoxDescriptionUseDefault
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSolidBBoxDescriptionUseDefault, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSolidBBoxDescriptionUseDefault, int opt, value)
            |> ignore

    member _.swSheetMetalBodiesDescriptionUseDefault
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBodiesDescriptionUseDefault, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalBodiesDescriptionUseDefault, int opt, value)
            |> ignore

    member _.swVrmlStlImportSegmented
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportSegmented, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swVrmlStlImportSegmented, int opt, value)
            |> ignore

    member _.swEnableVSTAVersion3
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableVSTAVersion3, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableVSTAVersion3, int opt, value)
            |> ignore

    member _.swViewDispGlobalBBox
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDispGlobalBBox, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swViewDispGlobalBBox, int opt, value)
            |> ignore

    member _.swDisplayComponentDimXpertAnnotations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayComponentDimXpertAnnotations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayComponentDimXpertAnnotations, int opt, value)
            |> ignore

    member _.swImportNeutral_SolidandSurface
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_SolidandSurface, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_SolidandSurface, int opt, value)
            |> ignore

    member _.swImportNeutral_FreeCurvesAndPoints
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_FreeCurvesAndPoints, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_FreeCurvesAndPoints, int opt, value)
            |> ignore

    member _.swImportNeutralReferencePlane
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralReferencePlane, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralReferencePlane, int opt, value)
            |> ignore

    member _.swImportNeutral_AttributesAndProperties
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_AttributesAndProperties, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutral_AttributesAndProperties, int opt, value)
            |> ignore

    member _.swImportNeutralRunDiagnostics
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralRunDiagnostics, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralRunDiagnostics, int opt, value)
            |> ignore

    member _.swMultiCAD_Enable3DInterconnect
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_Enable3DInterconnect, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_Enable3DInterconnect, int opt, value)
            |> ignore

    member _.swDrawingTurnOffAutomaticSolveModeAndUndo
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingTurnOffAutomaticSolveModeAndUndo, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDrawingTurnOffAutomaticSolveModeAndUndo, int opt, value)
            |> ignore

    member _.swSketchTurnOffAutomaticSolveModeAndUndo
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchTurnOffAutomaticSolveModeAndUndo, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchTurnOffAutomaticSolveModeAndUndo, int opt, value)
            |> ignore

    member _.swImportSolidBody
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidBody, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSolidBody, int opt, value)
            |> ignore

    member _.swImportSurfaceBody
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSurfaceBody, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportSurfaceBody, int opt, value)
            |> ignore

    member _.swImportReferencePlane
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferencePlane, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferencePlane, int opt, value)
            |> ignore

    member _.swImportReferenceAxis
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferenceAxis, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportReferenceAxis, int opt, value)
            |> ignore

    member _.swImportUnconsumedSketchesAndCurves
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUnconsumedSketchesAndCurves, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportUnconsumedSketchesAndCurves, int opt, value)
            |> ignore

    member _.swImportCustomProperties
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportCustomProperties, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportCustomProperties, int opt, value)
            |> ignore

    member _.swImportMaterialProperties
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMaterialProperties, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportMaterialProperties, int opt, value)
            |> ignore

    member _.swImportDissolveTopLevelAssemblyOnOpen
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDissolveTopLevelAssemblyOnOpen, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportDissolveTopLevelAssemblyOnOpen, int opt, value)
            |> ignore

    member _.swImportIgnoreHiddenEntities
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIgnoreHiddenEntities, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportIgnoreHiddenEntities, int opt, value)
            |> ignore

    member _.swImportToolBodiesFromUGNX
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportToolBodiesFromUGNX, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportToolBodiesFromUGNX, int opt, value)
            |> ignore

    member _.swIncludePMI
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludePMI, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludePMI, int opt, value)
            |> ignore

    member _.swAssemblyAllowGraphicsComponent
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowGraphicsComponent, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAssemblyAllowGraphicsComponent, int opt, value)
            |> ignore

    member _.swCheckCrashSolutions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCheckCrashSolutions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCheckCrashSolutions, int opt, value)
            |> ignore

    member _.swMakeTrimEntityConstruction
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeTrimEntityConstruction, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMakeTrimEntityConstruction, int opt, value)
            |> ignore

    member _.swIgnoreConstructionEntity
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreConstructionEntity, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIgnoreConstructionEntity, int opt, value)
            |> ignore

    member _.swLockRotationConcentricMates
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRotationConcentricMates, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swLockRotationConcentricMates, int opt, value)
            |> ignore

    member _.swASMSLDPRT_ExcludeComponentsByVisibility
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByVisibility, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByVisibility, int opt, value)
            |> ignore

    member _.swASMSLDPRT_ExcludeComponentsByBBoxVolume
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByBBoxVolume, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeComponentsByBBoxVolume, int opt, value)
            |> ignore

    member _.swASMSLDPRT_ExcludeIfToolboxComponents
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeIfToolboxComponents, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_ExcludeIfToolboxComponents, int opt, value)
            |> ignore

    member _.swASMSLDPRT_IncludeMassProperties
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_IncludeMassProperties, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swASMSLDPRT_IncludeMassProperties, int opt, value)
            |> ignore

    member _.swEnableAllowCosmeticThreadsUpgrade
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableAllowCosmeticThreadsUpgrade, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnableAllowCosmeticThreadsUpgrade, int opt, value)
            |> ignore

    member _.swSheetMetalUseMaterial
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalUseMaterial, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalUseMaterial, int opt, value)
            |> ignore

    member _.swPDFExportShadedEdgesHighQuality
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportShadedEdgesHighQuality, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportShadedEdgesHighQuality, int opt, value)
            |> ignore

    member _.swBomTableShowCustomTextinBOMHeader_ForTopLevelOnlyBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForTopLevelOnlyBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForTopLevelOnlyBOM, int opt, value)
            |> ignore

    member _.swBomTableShowCustomTextinBOMHeader_ForPartOnlyBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForPartOnlyBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForPartOnlyBOM, int opt, value)
            |> ignore

    member _.swBomTableShowCustomTextinBOMHeader_ForIndentedBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForIndentedBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowCustomTextinBOMHeader_ForIndentedBOM, int opt, value)
            |> ignore

    member _.swBomTableShowConfigurationInBOMHeader_ForTopLevelOnlyBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForTopLevelOnlyBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForTopLevelOnlyBOM, int opt, value)
            |> ignore

    member _.swBomTableShowConfigurationInBOMHeader_ForPartOnlyBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForPartOnlyBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForPartOnlyBOM, int opt, value)
            |> ignore

    member _.swBomTableShowConfigurationInBOMHeader_ForIndentedBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForIndentedBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBomTableShowConfigurationInBOMHeader_ForIndentedBOM, int opt, value)
            |> ignore

    member _.swEdit3DPDFTemplate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdit3DPDFTemplate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdit3DPDFTemplate, int opt, value)
            |> ignore

    member _.swPLYBinaryFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYBinaryFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYBinaryFormat, int opt, value)
            |> ignore

    member _.swPLYPreview
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYPreview, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYPreview, int opt, value)
            |> ignore

    member _.swPLYIncludeColors
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYIncludeColors, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPLYIncludeColors, int opt, value)
            |> ignore

    member _.swDisplayScrollbarsInGraphicsViewDrawings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewDrawings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewDrawings, int opt, value)
            |> ignore

    member _.swDisplayScrollbarsInGraphicsViewPartsAndAssemblies
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewPartsAndAssemblies, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayScrollbarsInGraphicsViewPartsAndAssemblies, int opt, value)
            |> ignore

    member _.swShowBreadcrumbsAtMousePointer
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsAtMousePointer, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowBreadcrumbsAtMousePointer, int opt, value)
            |> ignore

    member _.swIncludeDocumentsOpenedFromOtherDocuments
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDocumentsOpenedFromOtherDocuments, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDocumentsOpenedFromOtherDocuments, int opt, value)
            |> ignore

    member _.swIncludeSubfoldersForDrawingsSearchInPackAndGo
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSubfoldersForDrawingsSearchInPackAndGo, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSubfoldersForDrawingsSearchInPackAndGo, int opt, value)
            |> ignore

    member _.swAutomaticallyPopupSelectionToolForPreciseLocation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticallyPopupSelectionToolForPreciseLocation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticallyPopupSelectionToolForPreciseLocation, int opt, value)
            |> ignore

    member _.swCombineCutlistItemsInBOM
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCombineCutlistItemsInBOM, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCombineCutlistItemsInBOM, int opt, value)
            |> ignore

    member _.swEditNameWithSlowDoubleClick
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditNameWithSlowDoubleClick, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEditNameWithSlowDoubleClick, int opt, value)
            |> ignore

    member _.swSheetMetalMBDDisplaySheetMetalBendNotes
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDDisplaySheetMetalBendNotes, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDDisplaySheetMetalBendNotes, int opt, value)
            |> ignore

    member _.swSheetMetalMBDUseDocumentLeaderLength
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDUseDocumentLeaderLength, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDUseDocumentLeaderLength, int opt, value)
            |> ignore

    member _.swSheetMetalMBDLeaderJustificationSnapping
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDLeaderJustificationSnapping, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDLeaderJustificationSnapping, int opt, value)
            |> ignore

    member _.swSheetMetalMBDShowFixedFace
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowFixedFace, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowFixedFace, int opt, value)
            |> ignore

    member _.swSheetMetalMBDShowGrainDirection
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowGrainDirection, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDShowGrainDirection, int opt, value)
            |> ignore

    member _.swSheetMetalMBDFormat
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDFormat, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSheetMetalMBDFormat, int opt, value)
            |> ignore

    member _.swEnablePerformancePipeline
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformancePipeline, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnablePerformancePipeline, int opt, value)
            |> ignore

    member _.swReferenceOnlyEnvelopeComponentType
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceOnlyEnvelopeComponentType, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceOnlyEnvelopeComponentType, int opt, value)
            |> ignore

    member _.swReferenceInContextOfTopLevelAssembly
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceInContextOfTopLevelAssembly, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swReferenceInContextOfTopLevelAssembly, int opt, value)
            |> ignore

    member _.swDisplayDataMarkNewConfig
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDataMarkNewConfig, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayDataMarkNewConfig, int opt, value)
            |> ignore

    member _.swAllowCreationOfReferencesExternalToModel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAllowCreationOfReferencesExternalToModel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAllowCreationOfReferencesExternalToModel, int opt, value)
            |> ignore

    member _.swDetailingAnnotationShowTypeInThreadCallouts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationShowTypeInThreadCallouts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationShowTypeInThreadCallouts, int opt, value)
            |> ignore

    member _.swDetailingChainDimensionAddOverallDimensions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddOverallDimensions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddOverallDimensions, int opt, value)
            |> ignore

    member _.swDetailingChainDimensionAddLastReferenceDimension
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddLastReferenceDimension, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingChainDimensionAddLastReferenceDimension, int opt, value)
            |> ignore

    member _.swDraftingStandardAllUppercaseForDimensionsAndHoleCallouts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForDimensionsAndHoleCallouts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDraftingStandardAllUppercaseForDimensionsAndHoleCallouts, int opt, value)
            |> ignore

    member _.swBackupAfterMeshOrRunSimulationStudy
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupAfterMeshOrRunSimulationStudy, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swBackupAfterMeshOrRunSimulationStudy, int opt, value)
            |> ignore

    member _.swIncludeDataForDelmia
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDataForDelmia, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeDataForDelmia, int opt, value)
            |> ignore

    member _.swWeldmentGenerateCutlistIDs
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentGenerateCutlistIDs, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentGenerateCutlistIDs, int opt, value)
            |> ignore

    member _.swMultiCAD_ApplyOnlyToParts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_ApplyOnlyToParts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_ApplyOnlyToParts, int opt, value)
            |> ignore

    member _.swMultiCAD_CreateNewComponentsAsExternalFiles
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_CreateNewComponentsAsExternalFiles, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_CreateNewComponentsAsExternalFiles, int opt, value)
            |> ignore

    member _.swFeatureManagerShowTranslatedNameInFMTree
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerShowTranslatedNameInFMTree, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swFeatureManagerShowTranslatedNameInFMTree, int opt, value)
            |> ignore

    member _.swAutomaticSyncSettings
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticSyncSettings, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutomaticSyncSettings, int opt, value)
            |> ignore

    member _.swAutoSyncSettingsToInclude_SystemOptions
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_SystemOptions, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_SystemOptions, int opt, value)
            |> ignore

    member _.swAutoSyncSettingsToInclude_FileLocations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_FileLocations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_FileLocations, int opt, value)
            |> ignore

    member _.swAutoSyncSettingsToInclude_Customizations
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_Customizations, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swAutoSyncSettingsToInclude_Customizations, int opt, value)
            |> ignore

    member _.swEnable3DEXPERIENCEIntegration
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEIntegration, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEIntegration, int opt, value)
            |> ignore

    member _.swShowCADFamilyConfigOnly3dexpIntegration
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADFamilyConfigOnly3dexpIntegration, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADFamilyConfigOnly3dexpIntegration, int opt, value)
            |> ignore

    member _.swShowCADAndOtherConfig3dexpIntegration
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADAndOtherConfig3dexpIntegration, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swShowCADAndOtherConfig3dexpIntegration, int opt, value)
            |> ignore

    member _.swEnable3DEXPERIENCEFileCompatibilityUpdate
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEFileCompatibilityUpdate, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEnable3DEXPERIENCEFileCompatibilityUpdate, int opt, value)
            |> ignore

    member _.swImportNeutralAnalyticalConversion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralAnalyticalConversion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swImportNeutralAnalyticalConversion, int opt, value)
            |> ignore

    member _.swUsePositiveInertiaTensorNotation
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swUsePositiveInertiaTensorNotation, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swUsePositiveInertiaTensorNotation, int opt, value)
            |> ignore

    member _.swDisplayBendLines
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayBendLines, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayBendLines, int opt, value)
            |> ignore

    member _.swTIFExportIncludeDrawingsPaperColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFExportIncludeDrawingsPaperColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swTIFExportIncludeDrawingsPaperColor, int opt, value)
            |> ignore

    member _.swPDFExportIncludeDrawingsPaperColor
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeDrawingsPaperColor, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swPDFExportIncludeDrawingsPaperColor, int opt, value)
            |> ignore

    member _.swSaveFileProperties
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFileProperties, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFileProperties, int opt, value)
            |> ignore

    member _.swSaveFilePropertiesForEachComp
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFilePropertiesForEachComp, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSaveFilePropertiesForEachComp, int opt, value)
            |> ignore

    member _.swIncludeSketchData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSketchData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swIncludeSketchData, int opt, value)
            |> ignore

    member _.swSystemNotificationHideGraphicsNotification
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSystemNotificationHideGraphicsNotification, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSystemNotificationHideGraphicsNotification, int opt, value)
            |> ignore

    member _.swDetailingModeSaveModelData
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeSaveModelData, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeSaveModelData, int opt, value)
            |> ignore

    member _.swDetailingModeIncludeStandardViewsInViewPalette
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeIncludeStandardViewsInViewPalette, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingModeIncludeStandardViewsInViewPalette, int opt, value)
            |> ignore

    member _.swStoreOLEImagesWithModel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreOLEImagesWithModel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStoreOLEImagesWithModel, int opt, value)
            |> ignore

    member _.swDetailingAnnotationApplyNewCTDepthArchForToNewParts
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationApplyNewCTDepthArchForToNewParts, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAnnotationApplyNewCTDepthArchForToNewParts, int opt, value)
            |> ignore

    member _.swCreateConfigurationTableOnOpen
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCreateConfigurationTableOnOpen, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCreateConfigurationTableOnOpen, int opt, value)
            |> ignore

    member _.swExtRefForceSaveToCurrentVersion
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefForceSaveToCurrentVersion, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swExtRefForceSaveToCurrentVersion, int opt, value)
            |> ignore

    member _.swDisplayTempAxesOnMouseHover
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTempAxesOnMouseHover, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayTempAxesOnMouseHover, int opt, value)
            |> ignore

    member _.swStepExportAtomicSave
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAtomicSave, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAtomicSave, int opt, value)
            |> ignore

    member _.swStepExportAppearances
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAppearances, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swStepExportAppearances, int opt, value)
            |> ignore

    member _.swDisplayMeshBREPFacetFins
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMeshBREPFacetFins, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDisplayMeshBREPFacetFins, int opt, value)
            |> ignore

    member _.swEdgesDefaultBulkSelection2
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection2, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swEdgesDefaultBulkSelection2, int opt, value)
            |> ignore

    member _.swWeldmentUseEnglishDescriptionNameInCutlist
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentUseEnglishDescriptionNameInCutlist, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swWeldmentUseEnglishDescriptionNameInCutlist, int opt, value)
            |> ignore

    member _.swMultiCAD_3DInterconnectMaintainLinks
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectMaintainLinks, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectMaintainLinks, int opt, value)
            |> ignore

    member _.swMultiCAD_3DInterconnectManualBreakLink
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectManualBreakLink, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectManualBreakLink, int opt, value)
            |> ignore

    member _.swMultiCAD_3DInterconnectLinksFlag
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectLinksFlag, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swMultiCAD_3DInterconnectLinksFlag, int opt, value)
            |> ignore

    member _.swSketchPreviewDimensionOnSelect
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPreviewDimensionOnSelect, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swSketchPreviewDimensionOnSelect, int opt, value)
            |> ignore

    member _.swCollinearChainDimensionOffsetText
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionOffsetText, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionOffsetText, int opt, value)
            |> ignore

    member _.swCollinearChainDimensionArrowHeadTermination
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionArrowHeadTermination, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swCollinearChainDimensionArrowHeadTermination, int opt, value)
            |> ignore

    member _.swHardwareAccSilhouetteEdges
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swHardwareAccSilhouetteEdges, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swHardwareAccSilhouetteEdges, int opt, value)
            |> ignore

    member _.swDispDimXpertDimOnTopOfModel
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDispDimXpertDimOnTopOfModel, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDispDimXpertDimOnTopOfModel, int opt, value)
            |> ignore

    member _.swDimOverriddenHighlight
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimOverriddenHighlight, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDimOverriddenHighlight, int opt, value)
            |> ignore

    member _.swDetailingAngularRunningExtensionLineExtend
        with get (opt:swUserPreferenceOption_e) =
            swModel.Extension.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningExtensionLineExtend, int opt)
        and set (opt:swUserPreferenceOption_e) value =
            swModel.Extension.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swDetailingAngularRunningExtensionLineExtend, int opt, value)
            |> ignore
