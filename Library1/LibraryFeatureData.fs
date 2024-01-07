module LibraryFeatureData


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

open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.SolidWorks.FeatureExtrusion3
open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open UnquotedJson
open System.Text

let getData =fun (swFeature:Feature) (swModel:ModelDoc2)->
    let sb = StringBuilder()

    sb.Append($"{swFeature.Name}\n") |> ignore
    let LibraryFeatureData = swFeature.GetDefinition() :?> LibraryFeatureData
    LibraryFeatureData.AccessSelections(swModel, null)
    |> ignore

    //' Get its placement type
    let placementPlane,placementPlaneType = 
        LibraryFeatureData.GetPlacementPlane2(int swLibFeatureData_e.swLibFeatureData_PartRespect)
    sb.Append $"PlacementPlaneType = {placementPlaneType}\n" |> ignore
    //(placementPlane:?>IRefPlane).Select false

    //' Get the name of the active library feature configuration
    let ConfigurationName = LibraryFeatureData.ConfigurationName
    sb.Append $"ConfigurationName = {ConfigurationName}\n" |> ignore
                        
    //' Determine if the library feature is linked to
    //' the library feature part
    let LinkToLibraryPart = LibraryFeatureData.LinkToLibraryPart
    sb.Append $"LinkToLibraryPart = {LinkToLibraryPart}\n" |> ignore
        
    //' If the library feature part document is open or
    //' if the library feature is linked to the library feature
    //' part document, then get the names of all of the
    //' library feature configurations; if neither,
    //' then only the name of the active library configuration
    //' is returned
    let vConfigs = LibraryFeatureData.GetAllConfigurationNames()
    sb.Append $"Configuration names : {stringify vConfigs}" |> ignore
    //If Not IsEmpty(vConfigs) Then
    //    For x = LBound(vConfigs) To UBound(vConfigs)
    //        Debug.Print "  " & vConfigs(x)
    //    Next x
    //End If

    //' Get the number of locating dimensions
    let LocatingDimensionsCount = LibraryFeatureData.GetDimensionsCount(0)
    sb.Append $"LocatingDimensionsCount = {LocatingDimensionsCount}\n" |> ignore
    //' Get the locating dimensions
    let vLocDimVal,vLocDimName = LibraryFeatureData.GetDimensions(0)
    sb.Append $"Locating dimensions :{vLocDimVal},{vLocDimName}" |> ignore
    //If Not IsEmpty(vLocDimName) Then
    //    For i = LBound(vLocDimName) To UBound(vLocDimName)
    //        Debug.Print "  " & vLocDimName(i), vLocDimVal(i)
    //    Next i
    //End If
    //' Determine if existing dimension values of the library
    //' feature can be overridden
    let bOverrideDimVal = LibraryFeatureData.OverrideDimension
    sb.Append $"OverrideDimension = {bOverrideDimVal}\n" |> ignore
    //' Get the number of feature dimensions
    let SizeDimensionsCount = LibraryFeatureData.GetDimensionsCount(1)
    sb.Append $"SizeDimensionsCount = {SizeDimensionsCount}\n" |> ignore
    //' Get the feature dimensions
    let vSizDimVal,vSizDimName = LibraryFeatureData.GetDimensions(1)
    sb.Append $"Size dimensions :{vSizDimName},{vSizDimVal}\n" |> ignore
    //If Not IsEmpty(vSizDimName) Then
    //    For i = LBound(vSizDimName) To UBound(vSizDimName)
    //        Debug.Print "  " & vSizDimName(i), vSizDimVal(i)
    //    Next i
    //End If
    //' Get the number of references
    let ReferencesCount = LibraryFeatureData.GetReferencesCount()
    sb.Append $"GetReferencesCount = {ReferencesCount}\n" |> ignore
    //' Get the references
    let vRefs,vRefType,vRefName = LibraryFeatureData.GetReferences3(int swLibFeatureData_e.swLibFeatureData_PartRespect)
    sb.Append $"Reference types and names: {vRefs},{vRefType},{vRefName}\n" |> ignore

    //If Not IsEmpty(vRefType) Then
    //    Debug.Print "Reference types and names: "
    //    For i = LBound(vRefType) To UBound(vRefType)
    //        Debug.Print "  " & vRefType(i) & ", " & vRefName(i)
    //        vRefs(i).Select False
    //    Next i
    //End If

    //'Release the selections that define the library feature
    LibraryFeatureData.ReleaseSelectionAccess()
