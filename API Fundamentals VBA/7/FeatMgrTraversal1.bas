Attribute VB_Name = "FeatMgrTraversal1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim swFeature As SldWorks.feature
Dim FeatName As String
Dim FeatType As String

Sub main()
  Set swApp = Application.SldWorks
  If Not swApp Is Nothing Then
    Set swModel = swApp.ActiveDoc
    If Not swModel Is Nothing Then
      Set swFeature = swModel.FirstFeature
      While Not swFeature Is Nothing
        FeatName = swFeature.Name
        FeatType = swFeature.GetTypeName2
        
        swFeature.Select2 False, 0
        
        MsgBox "Feature screen name = " & FeatName & vbCrLf & _
          "Feature type name = " & FeatType
        Set swFeature = swFeature.GetNextFeature
      Wend
    End If
    Set swModel = Nothing
  End If
  Set swApp = Nothing
End Sub

