namespace FSharp.SolidWorks

open FSharp.Idioms

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

type MateType =
| MateANGLE of angle: float * angleAbsUpperLimit: float * angleAbsLowerLimit: float
| MateCAMFOLLOWER
| MateCOINCIDENT
| MateCONCENTRIC of lockRotation: bool
| MateCOORDINATE
| MateDISTANCE of flip: bool * distance: float * distanceAbsUpperLimit: float * distanceAbsLowerLimit: float
| MateGEAR of gearRatioNumerator: float * gearRatioDenominator: float
| MateHINGE
| MateLINEARCOUPLER
| MateLOCK
| MateLOCKTOSKETCH
| MateMAGNETIC
| MateMAXMATES
| MatePARALLEL
| MatePATH
| MatePERPENDICULAR
| MatePROFILECENTER
| MateRACKPINION
| MateSCREW
| MateSLIDER
| MateSLOT
| MateSYMMETRIC
| MateTANGENT
| MateUNIVERSALJOINT
| MateUNKNOWN
| MateWIDTH of widthMateOption: swMateWidthOptions_e

type AddMate5Params =
    {
        MateType      : MateType //swMateType_e
        MateAlign         : swMateAlign_e
        ForPositioningOnly    : bool
    }

    static member ofArgs(
        mateTypeFromEnum      : int   ,
        alignFromEnum         : int   ,
        flip                  : bool  ,
        distance              : float ,
        distanceAbsUpperLimit : float ,
        distanceAbsLowerLimit : float ,
        gearRatioNumerator    : float ,
        gearRatioDenominator  : float ,
        angle                 : float ,
        angleAbsUpperLimit    : float ,
        angleAbsLowerLimit    : float ,
        forPositioningOnly    : bool  ,
        lockRotation          : bool  ,
        widthMateOption       : int

        ) =
        let mateType =
            match enum<swMateType_e> mateTypeFromEnum with
            | swMateType_e.swMateANGLE          -> MateANGLE(angle, angleAbsUpperLimit, angleAbsLowerLimit)
            | swMateType_e.swMateCAMFOLLOWER    -> MateCAMFOLLOWER
            | swMateType_e.swMateCOINCIDENT     -> MateCOINCIDENT
            | swMateType_e.swMateCONCENTRIC     -> MateCONCENTRIC lockRotation
            | swMateType_e.swMateCOORDINATE     -> MateCOORDINATE
            | swMateType_e.swMateDISTANCE       -> MateDISTANCE(flip, distance, distanceAbsUpperLimit, distanceAbsLowerLimit)
            | swMateType_e.swMateGEAR           -> MateGEAR(gearRatioNumerator, gearRatioDenominator)
            | swMateType_e.swMateHINGE          -> MateHINGE
            | swMateType_e.swMateLINEARCOUPLER  -> MateLINEARCOUPLER
            | swMateType_e.swMateLOCK           -> MateLOCK
            | swMateType_e.swMateLOCKTOSKETCH   -> MateLOCKTOSKETCH
            | swMateType_e.swMateMAGNETIC       -> MateMAGNETIC
            | swMateType_e.swMateMAXMATES       -> MateMAXMATES
            | swMateType_e.swMatePARALLEL       -> MatePARALLEL
            | swMateType_e.swMatePATH           -> MatePATH
            | swMateType_e.swMatePERPENDICULAR  -> MatePERPENDICULAR
            | swMateType_e.swMatePROFILECENTER  -> MatePROFILECENTER
            | swMateType_e.swMateRACKPINION     -> MateRACKPINION
            | swMateType_e.swMateSCREW          -> MateSCREW
            | swMateType_e.swMateSLIDER         -> MateSLIDER
            | swMateType_e.swMateSLOT           -> MateSLOT
            | swMateType_e.swMateSYMMETRIC      -> MateSYMMETRIC
            | swMateType_e.swMateTANGENT        -> MateTANGENT
            | swMateType_e.swMateUNIVERSALJOINT -> MateUNIVERSALJOINT
            | swMateType_e.swMateUNKNOWN        -> MateUNKNOWN
            | swMateType_e.swMateWIDTH          -> MateWIDTH(enum<swMateWidthOptions_e> widthMateOption)
            | _ -> failwith "AddMate5Params.ofArgs()"
        {
            MateType = mateType
            MateAlign = enum<swMateAlign_e> alignFromEnum
            ForPositioningOnly = forPositioningOnly
        }

    member this.toArgs() =
        let mateTypeFromEnum =
            match this.MateType with
            | MateANGLE (angle, angleAbsUpperLimit, angleAbsLowerLimit)                -> swMateType_e.swMateANGLE
            | MateCAMFOLLOWER                                                            -> swMateType_e.swMateCAMFOLLOWER
            | MateCOINCIDENT                                                             -> swMateType_e.swMateCOINCIDENT
            | MateCONCENTRIC _                                                           -> swMateType_e.swMateCONCENTRIC
            | MateCOORDINATE                                                             -> swMateType_e.swMateCOORDINATE
            | MateDISTANCE (flip, distance, distanceAbsUpperLimit, distanceAbsLowerLimit) -> swMateType_e.swMateDISTANCE
            | MateGEAR (gearRatioNumerator, gearRatioDenominator)                        -> swMateType_e.swMateGEAR
            | MateHINGE                                                                  -> swMateType_e.swMateHINGE
            | MateLINEARCOUPLER                                                          -> swMateType_e.swMateLINEARCOUPLER
            | MateLOCK                                                                   -> swMateType_e.swMateLOCK
            | MateLOCKTOSKETCH                                                           -> swMateType_e.swMateLOCKTOSKETCH
            | MateMAGNETIC                                                               -> swMateType_e.swMateMAGNETIC
            | MateMAXMATES                                                               -> swMateType_e.swMateMAXMATES
            | MatePARALLEL                                                               -> swMateType_e.swMatePARALLEL
            | MatePATH                                                                   -> swMateType_e.swMatePATH
            | MatePERPENDICULAR                                                          -> swMateType_e.swMatePERPENDICULAR
            | MatePROFILECENTER                                                          -> swMateType_e.swMatePROFILECENTER
            | MateRACKPINION                                                             -> swMateType_e.swMateRACKPINION
            | MateSCREW                                                                  -> swMateType_e.swMateSCREW
            | MateSLIDER                                                                 -> swMateType_e.swMateSLIDER
            | MateSLOT                                                                   -> swMateType_e.swMateSLOT
            | MateSYMMETRIC                                                              -> swMateType_e.swMateSYMMETRIC
            | MateTANGENT                                                                -> swMateType_e.swMateTANGENT
            | MateUNIVERSALJOINT                                                         -> swMateType_e.swMateUNIVERSALJOINT
            | MateUNKNOWN                                                                -> swMateType_e.swMateUNKNOWN
            | MateWIDTH (widthMateOption)                                              -> swMateType_e.swMateWIDTH

        let flip, distance, distanceAbsUpperLimit, distanceAbsLowerLimit =
            match this.MateType with
            | MateDISTANCE (flip, distance, distanceAbsUpperLimit, distanceAbsLowerLimit) ->
                flip, distance, distanceAbsUpperLimit, distanceAbsLowerLimit
            | _ -> Literal.defaultof<_>

        let gearRatioNumerator, gearRatioDenominator =
            match this.MateType with
            | MateGEAR (gearRatioNumerator, gearRatioDenominator) -> gearRatioNumerator, gearRatioDenominator
            | _ -> Literal.defaultof<_>

        let angle, angleAbsUpperLimit, angleAbsLowerLimit =
            match this.MateType with
            | MateANGLE (angle, angleAbsUpperLimit, angleAbsLowerLimit) -> angle, angleAbsUpperLimit, angleAbsLowerLimit
            | _ -> Literal.defaultof<_>

        let lockRotation =
            match this.MateType with
            | MateCONCENTRIC lockRotation -> lockRotation
            | _ -> Literal.defaultof<_>

        let widthMateOption =
            match this.MateType with
            | MateWIDTH ( widthMateOption ) -> widthMateOption
            | _ -> Literal.defaultof<_>

        mateTypeFromEnum,
        this.MateAlign,
        flip,
        distance,
        distanceAbsUpperLimit,
        distanceAbsLowerLimit,
        gearRatioNumerator,
        gearRatioDenominator,
        angle,
        angleAbsUpperLimit,
        angleAbsLowerLimit,
        this.ForPositioningOnly,
        lockRotation,
        widthMateOption

    member this.AddMate5(swAssy: IAssemblyDoc) =
        let mateTypeFromEnum,
            alignFromEnum,
            flip,
            distance,
            distanceAbsUpperLimit,
            distanceAbsLowerLimit,
            gearRatioNumerator,
            gearRatioDenominator,
            angle,
            angleAbsUpperLimit,
            angleAbsLowerLimit,
            forPositioningOnly,
            lockRotation,
            widthMateOption = this.toArgs()
        let noError = int swAddMateError_e.swAddMateError_NoError
        let mutable ErrorStatus = noError

        let mate2 = swAssy.AddMate5(
            int mateTypeFromEnum,
            int alignFromEnum,
            flip,
            distance,
            distanceAbsUpperLimit,
            distanceAbsLowerLimit,
            gearRatioNumerator,
            gearRatioDenominator,
            angle,
            angleAbsUpperLimit,
            angleAbsLowerLimit,
            forPositioningOnly,
            lockRotation,
            int widthMateOption,
            &ErrorStatus)
        if ErrorStatus = noError then
            mate2
        else failwith $"AddMate5Params.exec:{enum<swAddMateError_e> ErrorStatus}"
