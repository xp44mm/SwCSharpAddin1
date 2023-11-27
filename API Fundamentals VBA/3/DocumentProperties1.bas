Attribute VB_Name = "DocumentProperties1"
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
  swModel.Extension.SetUserPreferenceToggle _
    swDetailingDualDimensions, swDetailingDimension, True
End Sub



