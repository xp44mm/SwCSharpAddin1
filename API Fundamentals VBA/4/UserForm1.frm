VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} UserForm1 
   Caption         =   "Part Automation Tool"
   ClientHeight    =   4215
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4920
   OleObjectBlob   =   "UserForm1.frx":0000
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
' Copyright 2003-2015 Dassault Syst鑝es SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim swPart As SldWorks.PartDoc

Private Sub cmdBuild_Click()
    Set swApp = Application.SldWorks
    ' Get the file path of the default part template
    
    'MATERIAL
    
    'PROFILE
    
    'MACHINE OPERATION
    
End Sub

Private Sub cmdExit_Click()
    End
End Sub


Private Sub MultiPage1_Change()

End Sub

'---------------------Page 1 focus -------------------------
Private Sub optAl_Click()
    optAl.ForeColor = RGB(0, 0, 0)
    optBr.ForeColor = RGB(128, 128, 128)
End Sub

Private Sub optBr_Click()
    optBr.ForeColor = RGB(0, 0, 0)
    optAl.ForeColor = RGB(128, 128, 128)
End Sub

'---------------------Page 2 focus -------------------------
Private Sub optCircular_Click()
    optCircular.ForeColor = RGB(0, 0, 0)
    txtRadius.enabled = True
    txtRadius.Locked = False
    txtRadius.BackColor = RGB(255, 255, 255)
    lblRadius.ForeColor = RGB(0, 0, 0)
    
    optRectangular.ForeColor = RGB(128, 128, 128)
    txtHeight.text = ""
    txtHeight.enabled = False
    txtHeight.Locked = True
    txtHeight.BackColor = RGB(212, 208, 200)
    lblHeight.ForeColor = RGB(128, 128, 128)
    txtWidth.text = ""
    txtWidth.enabled = False
    txtWidth.Locked = True
    txtWidth.BackColor = RGB(212, 208, 200)
    lblWidth.ForeColor = RGB(128, 128, 128)
End Sub

Private Sub optRectangular_Click()
    optRectangular.ForeColor = RGB(0, 0, 0)
    txtHeight.enabled = True
    txtHeight.Locked = False
    txtHeight.BackColor = RGB(255, 255, 255)
    lblHeight.ForeColor = RGB(0, 0, 0)
    txtWidth.enabled = True
    txtWidth.Locked = False
    txtWidth.BackColor = RGB(255, 255, 255)
    lblWidth.ForeColor = RGB(0, 0, 0)
    
    optCircular.ForeColor = RGB(128, 128, 128)
    txtRadius.text = ""
    txtRadius.enabled = False
    txtRadius.Locked = True
    txtRadius.BackColor = RGB(212, 208, 200)
    lblRadius.ForeColor = RGB(128, 128, 128)
End Sub


'---------------------Page 3 focus -------------------------
Private Sub optExtrude_Click()
    optExtrude.ForeColor = RGB(0, 0, 0)
    txtDepth.enabled = True
    txtDepth.Locked = False
    txtDepth.BackColor = RGB(255, 255, 255)
    lblDepth.ForeColor = RGB(0, 0, 0)
    
    optRevolve.ForeColor = RGB(128, 128, 128)
    txtAngle.text = ""
    txtAngle.enabled = False
    txtAngle.Locked = True
    txtAngle.BackColor = RGB(212, 208, 200)
    lblAngle.ForeColor = RGB(128, 128, 128)
    
    chkContour1.enabled = True
    chkContour1.Locked = False
    chkContour2.enabled = True
    chkContour2.Locked = False
End Sub

Private Sub optRevolve_Click()
    optRevolve.ForeColor = RGB(0, 0, 0)
    txtAngle.enabled = True
    txtAngle.Locked = False
    txtAngle.BackColor = RGB(255, 255, 255)
    lblAngle.ForeColor = RGB(0, 0, 0)
    
    optExtrude.ForeColor = RGB(128, 128, 128)
    txtDepth.text = ""
    txtDepth.enabled = False
    txtDepth.Locked = True
    txtDepth.BackColor = RGB(212, 208, 200)
    lblDepth.ForeColor = RGB(128, 128, 128)
    
    chkContour1.enabled = False
    chkContour1.Locked = True
    chkContour2.enabled = False
    chkContour2.Locked = True
End Sub


'---------------------Initial  focus -------------------------
Private Sub UserForm_Initialize()
        'Page 1
        optBr.ForeColor = RGB(128, 128, 128)
        
        'Page 2
        optCircular.ForeColor = RGB(128, 128, 128)
        txtRadius.enabled = False
        txtRadius.Locked = True
        txtRadius.BackColor = RGB(212, 208, 200)
        lblRadius.ForeColor = RGB(128, 128, 128)
        
        'Page 3
        optRevolve.ForeColor = RGB(128, 128, 128)
        txtAngle.enabled = False
        txtAngle.Locked = True
        txtAngle.BackColor = RGB(212, 208, 200)
        lblAngle.ForeColor = RGB(128, 128, 128)
End Sub









