Attribute VB_Name = "Custom_Props1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim Value As String

Sub main()
    Set swApp = Application.SldWorks
    Set swModel = swApp.ActiveDoc
    Dim CusPropMgr As SldWorks.CustomPropertyManager
    Set CusPropMgr = swModel.Extension. _
        CustomPropertyManager("")
    Dim AddStatus As Long
    AddStatus = CusPropMgr.Add3("MyTest", swCustomInfoText, _
        "This is a test.", swCustomPropertyReplaceValue)
    ' Retrieve the value of a custom property called MyTest
    Dim ResValue As String
    CusPropMgr.Get4 "MyTest", False, Value, ResValue
    swApp.SendMsgToUser2 Value, swMbInformation, swMbOk
    ' Change the value of a custom property called MyTest
    Value = "Test has now changed!"
    Dim SetStatus As Long
    SetStatus = CusPropMgr.Set2("MyTest", Value)
    ' Retrieve the new value
    Value = ""
    ResValue = ""
    CusPropMgr.Get4 "MyTest", False, Value, ResValue
    swApp.SendMsgToUser2 Value, swMbInformation, swMbOk
End Sub
