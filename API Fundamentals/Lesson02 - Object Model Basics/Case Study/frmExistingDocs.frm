VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmExistingDocs 
   Caption         =   "Existing Documents"
   ClientHeight    =   5616
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5310
   OleObjectBlob   =   "frmExistingDocs.frx":0000
   ShowModal       =   0   'False
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmExistingDocs"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

' ============================================================
'
' Copyright 2003-2015 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Const TRAININGDIR As String = _
  "C:\SolidWorks Training Files\API Fundamentals\"
Const FILEDIR As String = _
  TRAININGDIR & "Lesson02 - Object Model Basics\Case Study\"

Private Sub cmdConnect_Click()
  Dim swApp As SldWorks.SldWorks
  Set swApp = Application.SldWorks
  
  If chkOpen.Value = True Then
    Dim fileerror As Long
    Dim filewarning As Long
    swApp.OpenDoc6 FILEDIR + "Sample.sldprt", swDocPART, _
      swOpenDocOptions_Silent, "", fileerror, filewarning
  End If
  
  If chkLoad.Value = True Then
    Dim errors As Long
    Dim ImportedModelDoc As SldWorks.ModelDoc2
    Set ImportedModelDoc = swApp.LoadFile4(FILEDIR + _
      "Sample.igs", "", Nothing, errors)
  End If
  
  If chkNewWindow.Value = True Then
    swApp.CreateNewWindow
    swApp.ArrangeWindows 1
  End If
End Sub


Private Sub cmdNewModel_Click()
  Dim swApp As SldWorks.SldWorks
  Dim swModel As SldWorks.ModelDoc2
  
  Set swApp = Application.SldWorks
  Set swModel = swApp.ActiveDoc
  ' Check to see if a document is loaded
  If swModel Is Nothing Then
    swApp.SendMsgToUser2 _
    "Please open a part, assembly or drawing.", swMbStop, swMbOk
    Exit Sub
  End If
   
  If chkToolbars.Value = True Then
    swModel.SetToolbarVisibility swFeatureToolbar, True
    swModel.SetToolbarVisibility swMacroToolbar, True
    swModel.SetToolbarVisibility swMainToolbar, True
    swModel.SetToolbarVisibility swSketchToolbar, True
    swModel.SetToolbarVisibility swSketchToolsToolbar, True
    swModel.SetToolbarVisibility swStandardToolbar, True
    swModel.SetToolbarVisibility swStandardViewsToolbar, True
    swModel.SetToolbarVisibility swViewToolbar, True
  Else
    swModel.SetToolbarVisibility swFeatureToolbar, False
    swModel.SetToolbarVisibility swMacroToolbar, False
    swModel.SetToolbarVisibility swMainToolbar, False
    swModel.SetToolbarVisibility swSketchToolbar, False
    swModel.SetToolbarVisibility swSketchToolsToolbar, False
    swModel.SetToolbarVisibility swStandardToolbar, False
    swModel.SetToolbarVisibility swStandardViewsToolbar, False
    swModel.SetToolbarVisibility swViewToolbar, False
  End If
      
  If chkCustomInfo.Value = True Then
    Dim retval As Long

'    retval = swModel.Extension.CustomPropertyManager("").Add3 _
'      ("MyInfo", swCustomInfoText, "MyData", _
'      swCustomPropertyDeleteAndAdd)

    Dim custPropMan As CustomPropertyManager
    Set custPropMan = swModel.Extension.CustomPropertyManager("")
    retval = custPropMan.Add3("MyInfo", swCustomInfoText, "MyData", swCustomPropertyDeleteAndAdd)
  End If
End Sub

Private Sub cmdPart_Click()
  Dim swApp As SldWorks.SldWorks
  Dim swModel As SldWorks.ModelDoc2
  Dim swPart As SldWorks.PartDoc
  
  Set swApp = Application.SldWorks
  Set swModel = swApp.ActiveDoc
  Set swPart = swModel 'Explicit Type Cast

  ' Check to see if a part is loaded
  If swModel Is Nothing Then
    swApp.SendMsgToUser2 "Please open a part.", swMbStop, swMbOk
    Exit Sub
  End If

  If chkMirror.Value = True Then
    Dim boolstatus As Boolean
    boolstatus = swModel.Extension.SelectByID2("Top", _
      "PLANE", 0, 0, 0, False, 0, Nothing, 0)
    'Next method called from specific PartDoc object.
    swPart.MirrorPart2 False, _
      swMirrorPartOptions_ImportSolids, swModel
    swModel.ShowNamedView2 "*Isometric", 7
    swModel.ViewZoomtofit2
    swApp.ArrangeWindows 1
    Dim retval As Boolean
    Dim errors As Long
    Set swModel = swApp.ActivateDoc3( _
      "sheetmetalsample.SLDPRT", False, swRebuildActiveDoc, _
      errors)
    retval = swModel.DeSelectByID("Top", "PLANE", 0, 0, 0)
  End If
End Sub

Private Sub cmdAssy_Click()
  Dim swApp As SldWorks.SldWorks
  Dim swModel As SldWorks.ModelDoc2
  Dim swAssy As SldWorks.AssemblyDoc
  Set swApp = Application.SldWorks
  Set swModel = swApp.ActiveDoc
  Set swAssy = swModel 'Explicit Type Cast!
  
  
      Dim boolstatus1 As Boolean
    boolstatus1 = _
      swModel.Extension.SelectByID2( _
      "Part-1-1@sheetmetalsample", "COMPONENT", 0, 0, _
      0, False, 0, Nothing, 0)

  
  
  ' Check to see if an assembly is loaded
  If swModel Is Nothing Then
    swApp.SendMsgToUser2 "Please open an assembly.", _
      swMbStop, swMbOk
    Exit Sub
  End If
  
  If chkCavity.Value = True Then
    Dim boolstatus As Boolean
    boolstatus = _
      swModel.Extension.SelectByID2( _
      "sheetmetalsample-1@sheetmetalsample", "COMPONENT", 0, 0, _
      0, False, 0, Nothing, 0)
    Dim info As Long
    Dim retval As Long
    retval = swAssy.EditPart2(True, False, info)
    swModel.ClearSelection2 True
    boolstatus = swModel.Extension.SelectByID2( _
      "plug-1@sheetmetalsample", "COMPONENT", 0, 0, 0, True, _
      0, Nothing, 0)
    swAssy.InsertCavity4 10, 10, 10, 1, 1, -1
    swAssy.EditAssembly
    boolstatus = swModel.Extension.SelectByID2( _
      "plug-1@sheetmetalsample", "COMPONENT", 0, 0, 0, _
      True, 0, Nothing, 0)
    swAssy.EditSuppress2
  End If
End Sub

Private Sub cmdDraw_Click()
  Dim swApp As SldWorks.SldWorks
  Dim swDraw As SldWorks.DrawingDoc
  
  Set swApp = Application.SldWorks
  Set swDraw = swApp.ActiveDoc
  
  'Check to see if a drawing is loaded
  If swDraw Is Nothing Then
    swApp.SendMsgToUser2 "Please open a drawing.", _
      swMbStop, swMbOk
    Exit Sub
  End If
  
  If chkLayer.Value = True Then
    'Notice automatic type cast.
    swDraw.ClearSelection2 True
    Dim retval As Boolean
    retval = swDraw.CreateLayer2("MyRedLayer", "Red", RGB(255, _
      0, 0), swLineSTITCH, swLW_THICK, True, True)
  End If
End Sub

Private Sub UserForm_Click()

End Sub
