Attribute VB_Name = "Custom_Props1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2

Sub main()

  Set swApp = Application.SldWorks
  Set swModel = swApp.ActiveDoc
  Dim CusPropMgr As SldWorks.CustomPropertyManager
  Set CusPropMgr = swModel.Extension. _
    CustomPropertyManager("")
  Dim AddStatus As Long
  AddStatus = CusPropMgr.Add3("MyProp1", _
    swCustomInfoNumber, "1", swCustomPropertyReplaceValue)
  AddStatus = CusPropMgr.Add3("MyProp2", _
    swCustomInfoNumber, "2", swCustomPropertyReplaceValue)
  AddStatus = CusPropMgr.Add3("MyProp3", _
    swCustomInfoNumber, "3", swCustomPropertyReplaceValue)
  AddStatus = CusPropMgr.Add3("MyProp4", _
    swCustomInfoNumber, "4", swCustomPropertyReplaceValue)
  
  Dim retval() As String
  Dim i As Integer
  retval = CusPropMgr.GetNames
  For i = 0 To UBound(retval)
    swApp.SendMsgToUser2 retval(i), swMbInformation, _
      swMbOk
  Next

  Dim Count As Long
  Count = CusPropMgr.Count
  swApp.SendMsgToUser2 "You have " & Count & _
    " custom properties.", swMbInformation, swMbOk
End Sub
