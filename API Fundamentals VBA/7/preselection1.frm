VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} UserForm1 
   Caption         =   "Preselection"
   ClientHeight    =   1950
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4500
   OleObjectBlob   =   "preselection1.frx":0000
   ShowModal       =   0   'False
   StartUpPosition =   1  '所有者中心
End
Attribute VB_Name = "UserForm1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' ============================================================
'
' Copyright 2003-2013 Dassault Syst鑝es SolidWorks Corporation
'
' ============================================================

Option Explicit

Private Sub cmdGenerate_Click()
  Dim swApp As SldWorks.SldWorks
  Dim swModel As SldWorks.ModelDoc2
  Dim swSelMgr As SldWorks.SelectionMgr
  Dim count As Long
  Dim Feature As SldWorks.Feature
  Dim ExtrudeFeatureData As SldWorks.ExtrudeFeatureData2
  Dim retval As Boolean
  Dim Depth As Double
  Dim Factor As Integer
  
  Factor = CInt(txtDepth.Text)
  Set swApp = Application.SldWorks
  Set swModel = swApp.ActiveDoc
  Set swSelMgr = swModel.SelectionManager
  count = swSelMgr.GetSelectedObjectCount2(-1)
  If count <> 1 Then
    swApp.SendMsgToUser2 "Please select only Extrude1.", _
      swMbWarning, swMbOk
    Exit Sub
  End If
  Set Feature = swSelMgr.GetSelectedObject6(count, -1)
  If Not Feature.GetTypeName2 = "Extrusion" Then
    swApp.SendMsgToUser2 "Please select only Extrude1.", _
      swMbWarning, swMbOk
    Exit Sub
  End If
  Set ExtrudeFeatureData = Feature.GetDefinition
  Depth = ExtrudeFeatureData.GetDepth(True)
  ExtrudeFeatureData.SetDepth True, Depth * Factor
  retval = Feature.ModifyDefinition _
    (ExtrudeFeatureData, swModel, Nothing)
End Sub

Private Sub cmdExit_Click()
  End
End Sub

Private Sub UserForm_Click()

End Sub
