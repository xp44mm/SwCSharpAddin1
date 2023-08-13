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

open FSharp.Literals.Literal

/// 8.3
let main
    //(swApp: SldWorks)
    (swModel: ModelDoc2)
    =
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoTitle) <- "API Fundamentals"
    let text = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoTitle)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoSubject) <- "Adding custom file summary information"
    let text = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoSubject)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoAuthor) <- "SolidWorks Training"
    let text = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoAuthor)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoKeywords) <- ""
    let text = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoKeywords)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoComment) <- "Use the ModelDoc2::SummaryInfo method" + " to add summary information."
    let text = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoComment)

    ()
