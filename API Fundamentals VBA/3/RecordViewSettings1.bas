Attribute VB_Name = "RecordViewSettings1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As Object
Dim Part As Object
Dim boolstatus As Boolean
Dim longstatus As Long, longwarnings As Long

Sub main()
  Set swApp = Application.SldWorks
  'Fast value of Mouse Speed
  boolstatus = swApp.SetUserPreferenceIntegerValue _
    (swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed, _
    100)
  'Fast value of View Transition
  boolstatus = swApp.SetUserPreferenceDoubleValue _
    (swUserPreferenceDoubleValue_e.swViewAnimationSpeed, 0.5)
  'Slow value of Mouse Speed
  boolstatus = swApp.SetUserPreferenceIntegerValue _
    (swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed, _
    0)
  'Slow value of View Transition
  boolstatus = swApp.SetUserPreferenceDoubleValue _
    (swUserPreferenceDoubleValue_e.swViewAnimationSpeed, 3)
End Sub
