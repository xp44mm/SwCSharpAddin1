Attribute VB_Name = "DrawingAutomation1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Const TRAININGDIR As String = _
    "C:\SOLIDWORKS Training Files\API Fundamentals\"
Const TEMPLATEDIR As String = _
    "C:\SolidWorks Training Files\Training Templates\"
Const TEMPLATENAME As String = _
    TEMPLATEDIR & "Drawing_ANSI.drwdot"
Const SCALENUM As Double = 1#
Const SCALEDENOM As Double = 2#
Const SAVEASPATH As String = TRAININGDIR & "Export\"

Dim errors As Long
Dim warnings As Long
Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2

Dim Response As Integer
Dim ThirdAngle As Boolean
Dim swDraw As SldWorks.DrawingDoc

Dim ConfigNamesArray As Variant
Dim ConfigName As Variant
Dim i As Long
Dim retval As Boolean
Dim swView As SldWorks.View

Sub main()
    Response = MsgBox("Create third angle projection?", vbYesNo)
    If Response = vbYes Then
        ThirdAngle = True
    Else
        ThirdAngle = False
    End If

    Set swApp = Application.SldWorks
    Set swModel = swApp.ActiveDoc
    Set swDraw = swApp.NewDocument(TEMPLATENAME, swDwgPaperA1size, 0#, 0#)
    ConfigNamesArray = swModel.GetConfigurationNames
    For i = 0 To UBound(ConfigNamesArray)
        ConfigName = ConfigNamesArray(i)
        If i > 0 Then
            retval = swDraw.NewSheet4(ConfigName, swDwgPaperA1size, swDwgTemplateA1size, SCALENUM, _
                SCALEDENOM, Not ThirdAngle, "", 0#, 0#, "", 0#, 0#, 0#, 0#, 0, 0)
        Else
            retval = swDraw.SetupSheet6(ConfigName, _
                swDwgPaperA1size, swDwgTemplateA1size, SCALENUM, _
                SCALEDENOM, Not ThirdAngle, "", 0#, 0#, "", False, 0#, _
                0#, 0#, 0#, 0, 0)
        End If
        If ThirdAngle = True Then
            retval = swDraw.Create3rdAngleViews2(swModel.GetPathName)
        Else
            retval = swDraw.Create1stAngleViews2(swModel.GetPathName)
        End If
        Set swView = swDraw.GetFirstView
        Do While Not swView Is Nothing
            swView.ReferencedConfiguration = ConfigName
            Set swView = swView.GetNextView
        Loop
        Dim RebuildSuccess As Boolean
        RebuildSuccess = swDraw.ForceRebuild3(True)
        swDraw.InsertModelAnnotations3 swImportModelItemsFromEntireModel, swInsertDimensionsMarkedForDrawing + _
            swInsertNotes, True, True, True, False
        swDraw.Extension.SaveAs SAVEASPATH & ConfigName & ".DXF", _
            swSaveAsCurrentVersion, swSaveAsOptions_Silent, _
            Nothing, errors, warnings
        swDraw.Extension.SaveAs SAVEASPATH & ConfigName & ".DWG", _
            swSaveAsCurrentVersion, swSaveAsOptions_Silent, _
            Nothing, errors, warnings
        swDraw.Extension.SaveAs SAVEASPATH & ConfigName & ".JPG", _
            swSaveAsCurrentVersion, swSaveAsOptions_Silent, _
            Nothing, errors, warnings
        swDraw.Extension.SaveAs SAVEASPATH & ConfigName & ".TIF", _
            swSaveAsCurrentVersion, swSaveAsOptions_Silent, _
            Nothing, errors, warnings
    Next i
End Sub
