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
let main(swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoTitle) <- "API Fundamentals"
    let tt = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoTitle)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoSubject) <- "Adding custom file summary information"
    let sj = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoSubject)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoAuthor) <- "SolidWorks Training"
    let th = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoAuthor)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoKeywords) <- ""
    let kw = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoKeywords)
    
    swModel.SummaryInfo(int swSummInfoField_e.swSumInfoComment) <- "Use the ModelDoc2::SummaryInfo method to add summary information."
    let cm = swModel.SummaryInfo(int swSummInfoField_e.swSumInfoComment)
    
    [ tt;sj;th;kw;cm ]
    |> String.concat "\n"
    |> swApp.SendMsgToUser

