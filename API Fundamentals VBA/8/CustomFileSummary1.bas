Attribute VB_Name = "CustomFileSummary1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim text As String

Sub main()
    Set swApp = Application.SldWorks
    Set swModel = swApp.ActiveDoc
    
    swModel.SummaryInfo(swSumInfoTitle) = _
        "API Fundamentals"
    text = swModel.SummaryInfo(swSumInfoTitle)
    
    swModel.SummaryInfo(swSumInfoSubject) = _
        "Adding custom file summary information"
    text = swModel.SummaryInfo(swSumInfoSubject)
    
    swModel.SummaryInfo(swSumInfoAuthor) = _
        "SolidWorks Training"
    text = swModel.SummaryInfo(swSumInfoAuthor)
    
    swModel.SummaryInfo(swSumInfoKeywords) = ""
    text = swModel.SummaryInfo(swSumInfoKeywords)
    
    swModel.SummaryInfo(swSumInfoComment) = _
        "Use the ModelDoc2::SummaryInfo method" & _
        " to add summary information."
    text = swModel.SummaryInfo(swSumInfoComment)
End Sub
