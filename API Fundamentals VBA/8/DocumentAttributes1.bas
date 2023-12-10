Attribute VB_Name = "DocumentAttributes1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim swAttDef As SldWorks.attributeDef
Dim swAtt As SldWorks.Attribute
Dim swParam1 As SldWorks.Parameter
Dim swParam2 As SldWorks.Parameter
Sub main()
    Set swApp = Application.SldWorks
    Set swModel = swApp.ActiveDoc
    Set swAttDef = swApp.DefineAttribute _
        ("pubMyDocAttributeDef")
    swAttDef.AddParameter "MyFirstParameter", _
        SwConst.swParamTypeDouble, 10, 0
    swAttDef.AddParameter "MySecondParameter", _
        SwConst.swParamTypeDouble, 20, 0
    swAttDef.Register
    Set swAtt = swAttDef.CreateInstance5(swModel, Nothing, _
        "MyDocAttribute", 0, SwConst.swAllConfiguration)
    Set swParam1 = swAtt.GetParameter("MyFirstParameter")
    Set swParam2 = swAtt.GetParameter("MySecondParameter")
    MsgBox "There is one attribute on this file, " & vbCrLf & _
        "with two parameters." & vbCrLf & _
        "Parameter 1 = " & swParam1.GetDoubleValue & vbCrLf & _
        "Parameter 2 = " & swParam2.GetDoubleValue
End Sub
