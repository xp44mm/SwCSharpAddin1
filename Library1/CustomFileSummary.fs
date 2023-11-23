module CustomFileSummary

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

/// 8.3
let main
    //(swApp: SldWorks)
    (swModel: ModelDoc2)
    =
    
    swModel
    |> ModelDoc2Utils.setSummaryInfo(swSummInfoField_e.swSumInfoTitle) "API Fundamentals"
    let text = 
        swModel
        |> ModelDoc2Utils.getSummaryInfo(swSummInfoField_e.swSumInfoTitle)
    
    swModel
    |> ModelDoc2Utils.setSummaryInfo(swSummInfoField_e.swSumInfoSubject) "Adding custom file summary information"
    let text = 
        swModel
        |> ModelDoc2Utils.getSummaryInfo(swSummInfoField_e.swSumInfoSubject)
    
    swModel
    |> ModelDoc2Utils.setSummaryInfo swSummInfoField_e.swSumInfoAuthor "SolidWorks Training"
    let text = 
        swModel
        |> ModelDoc2Utils.getSummaryInfo(swSummInfoField_e.swSumInfoAuthor)
    
    swModel
    |> ModelDoc2Utils.setSummaryInfo(swSummInfoField_e.swSumInfoKeywords) ""
    let text = 
        swModel
        |> ModelDoc2Utils.getSummaryInfo(swSummInfoField_e.swSumInfoKeywords)
    
    swModel
    |> ModelDoc2Utils.setSummaryInfo(swSummInfoField_e.swSumInfoComment) "Use the ModelDoc2::SummaryInfo method to add summary information."
    let text = 
        swModel
        |> ModelDoc2Utils.getSummaryInfo(swSummInfoField_e.swSumInfoComment)
    
    ()
