Option Explicit

Const TRAININGDIR As String = _
    "C:\SolidWorks Training Files\API Fundamentals\"
Const TEMPLATEDIR As String = _
    "C:\SolidWorks Training Files\Training Templates\"
Const FILEDIR As String = _
    TRAININGDIR & "Lesson02 - Object Model Basics\Case Study\"

Private Sub cmdConnect_Click()
    Dim swApp As SldWorks.SldWorks
    Set swApp = Application.SldWorks
    
    If chkRevNum.Value = True Then
        Dim retval As String
        retval = swApp.RevisionNumber
        Dim vRevNo As Variant
        vRevNo = Split(retval, ".", -1, vbTextCompare)
        If vRevNo(0) > 1 Then   'Version is 2000 or later
            Dim MajorRev As String
            '8 + 1992 = SOLIDWORKS 2000
            MajorRev = vRevNo(0) + 1992
            MajorRev = IIf(MajorRev = "2002", _
                "2001Plus", MajorRev)
            MsgBox "You are running SOLIDWORKS " & MajorRev & _
                " SP" & vRevNo(1) & "." & vRevNo(2)
        Else
            MsgBox "You are running pre-SOLIDWORKS 2000"
        End If
    End If
    
    If chkDispStatBar.Value = True Then
        swApp.DisplayStatusBar True
    Else
        swApp.DisplayStatusBar False
    End If
    
    If chkCurLang.Value = True Then
        Dim CurrentLanguage As String
        CurrentLanguage = swApp.GetCurrentLanguage
        MsgBox "SOLIDWORKS is currently using the " _
            & CurrentLanguage & " language."
    End If
End Sub

Private Sub cmdNewModel_Click()
    Dim swApp As SldWorks.SldWorks
    Set swApp = Application.SldWorks
    Dim swModel As SldWorks.ModelDoc2
    
    ' Find the selected option and connect to the ModelDoc2 object
    If optPart.Value = True Then
        Set swModel = swApp.NewDocument(TEMPLATEDIR + _
                        "Part_MM.prtdot", 0, 0#, 0#)
    End If
    
    If optAssy.Value = True Then
        Set swModel = swApp.NewDocument(TEMPLATEDIR + _
                        "Assembly_MM.asmdot", 0, 0#, 0#)
    End If
    
    If optDraw.Value = True Then
        Set swModel = swApp.NewDocument(TEMPLATEDIR + _
                        "B_Size_ANSI_MM.drwdot", 0, 0#, 0#)
    End If
       
    ' Determine which items are checked
    ' and call specific methods and properties on ModelDoc2
    
    Dim swView As SldWorks.View
    If chkSketch.Value = True Then
        If optDraw.Value = True Then
            Set swView = preparedrawingView(swApp, swModel)
            swView.FocusLocked = True
        Else
            swModel.SketchManager.InsertSketch True
        End If
    End If

    If chkFamilyTable.Value = True Then
        If optDraw.Value = True Then
            Set swView = preparedrawingView(swApp, swModel)
            swModel.Extension.SelectByID2 swView.GetName2, _
                            "DRAWINGVIEW", 0, 0, 0, False, 0, _
                            Nothing, swSelectOptionDefault
            swModel.InsertFamilyTableNew
        Else
            swModel.InsertFamilyTableNew
        End If
    End If
    
    If chkNote.Value = True Then
        Dim swNote As SldWorks.note
        Dim swAnnotation As SldWorks.Annotation
        Dim text As String
        
        text = "Sample Note"
        Set swNote = swModel.InsertNote(text)
        Set swAnnotation = swNote.GetAnnotation
        swAnnotation.SetPosition 0.01, 0.01, 0
    End If
    
End Sub

Private Function preparedrawingView(ByRef swApp As _
                SldWorks.SldWorks, ByRef swModel As SldWorks.ModelDoc2) As _
                SldWorks.View
    Dim drawname As String
    Dim errors As Long
    Dim warnings As Long
    
    drawname = swModel.GetTitle
    swApp.OpenDoc6 FILEDIR + "BlockwithDesignTable.SLDPRT", 1, _
    0, "", errors, warnings
    Set swModel = swApp.ActivateDoc3(drawname, False, _
                swRebuildActiveDoc, errors)
    'Notice automatic typecasting to DrawingDoc!
    Set preparedrawingView = swModel.CreateDrawViewFromModelView3 _
                (FILEDIR + "BlockwithDesignTable.SLDPRT", _
                "*Isometric", 0.1, 0.1, 0)
End Function

Private Sub cmdPart_Click()
    Dim swApp As SldWorks.SldWorks
    Set swApp = Application.SldWorks
    Dim swModel As SldWorks.ModelDoc2
    Set swModel = swApp.NewDocument(TEMPLATEDIR + _
        "Part_MM.prtdot", 0, 0#, 0#)
    Dim swPart As SldWorks.PartDoc
    Set swPart = swModel
    swModel.SketchManager.InsertSketch True
    swModel.SketchManager.CreateCornerRectangle 0, 0, 0, 0.1, _
        0.1, 0
    swModel.FeatureManager.FeatureExtrusion2 True, False, _
        False, 0, 0, 0.1, 0.01, False, False, False, False, _
        0.01745329251994, 0.01745329251994, False, False, _
        False, False, 1, 1, 1, 0, 0, False
        
    If chkRollback.Value = True Then
        swPart.EditRollback
    End If
End Sub

Private Sub cmdAssy_Click()
    Dim swApp As SldWorks.SldWorks
    Set swApp = Application.SldWorks
    Dim fileerror As Long
    Dim filewarning As Long
    swApp.OpenDoc6 FILEDIR + "Sample.sldprt", swDocPART, _
    swOpenDocOptions_Silent, "", fileerror, filewarning
    
    If fileerror And swFileNotFoundError = swFileNotFoundError Then '2
      MsgBox "file not found"
    End If
      
    
    Dim swModel As SldWorks.ModelDoc2
    Set swModel = swApp.NewDocument(TEMPLATEDIR + _
    "Assembly_MM.asmdot", 0, 0#, 0#)
    
    Dim swAssy As SldWorks.AssemblyDoc
    Set swAssy = swModel
    If chkComponent.Value = True Then
        swAssy.AddComponent5 FILEDIR + "Sample.sldprt", _
        swAddComponentConfigOptions_CurrentSelectedConfig, _
        "", False, "", 0, 0, 0
    End If
End Sub

Private Sub cmdDraw_Click()
    Dim swApp As SldWorks.SldWorks
    Set swApp = Application.SldWorks
    Dim swDraw As SldWorks.DrawingDoc
    Set swDraw = swApp.NewDocument(TEMPLATEDIR + _
    "B_Size_ANSI_MM.drwdot", 0, 0#, 0#)
    
    If chkFormat.Value = True Then
    'Notice the automatic type casting
    'Visual Basic does for you.
        swDraw.EditTemplate
    End If
End Sub

Private Sub fraModelDoc2_Click()

End Sub

Private Sub UserForm_Click()

End Sub
