Attribute VB_Name = "SystemOptions1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim viewportColor As Long
Dim value As String

Sub main()
  Set swApp = Application.SldWorks
  swApp.SetUserPreferenceToggle _
    swInputDimValOnCreate, True
  swApp.SetUserPreferenceToggle _
    swSingleCommandPerPick, True
  swApp.SetUserPreferenceDoubleValue _
    swDrawingDetailViewScale, 1.5
  viewportColor = RGB(128, 255, 128) 'sets color to green
  swApp.SetUserPreferenceIntegerValue _
    swSystemColorsViewportBackground, viewportColor
  value = ("C:\Temp")
  swApp.SetUserPreferenceStringValue swBackupDirectory, value
  swApp.SetUserPreferenceIntegerValue _
    swEdgesHiddenEdgeDisplay, _
    swEdgesHiddenEdgeDisplayDashed

  ' View Rotation - Mouse Speed
  '
  ' 0 = Slow
  ' 100 = Fast
  swApp.SetUserPreferenceIntegerValue _
    swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed, 50

  ' View Rotation - ViewAnimationSpeed
  ' 0 = Off
  ' 0.5 = Fast
  ' 1.0
  ' 1.5
  ' 2.0
  ' 2.5
  ' 3.0 = Slow
  swApp.SetUserPreferenceDoubleValue swViewAnimationSpeed, 2#
End Sub

