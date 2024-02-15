'--------------------------------------------------------------
' Preconditions:
' 1. Verify that the specified part document to open exists.
' 2. Examine the Immediate window.
'
' Postconditions:
' 1. Opens the specified part document.
' 2. Selects all of the extrude features and marks Base-Extrude
'    and Boss-Extrude5 with a value of 8.
' 3. Gets the number of marked selections and total number of
'    selections.
' 4. Examine the Immediate window.
'--------------------------------------------------------------
Option Explicit
Dim swApp                   As SldWorks.SldWorks
Dim swModel                 As SldWorks.ModelDoc2
Dim swDocSpecification      As SldWorks.DocumentSpecification
Dim swSelMgr                As SldWorks.SelectionMgr
Dim swModelExt              As SldWorks.ModelDocExtension
Dim bRet                    As Boolean
Dim lMark                   As Long
Dim lMarkedIdx              As Long
Dim lNumMarkedSelections    As Long
Dim lNumAllSelections       As Long
Dim lAllIdx                 As Long
Dim swMarkedSelectedObject  As Object
Dim swSelectedObject        As Object
Sub main()
    Set swApp = Application.SldWorks
    ' Open  document
    Set swDocSpecification = swApp.GetOpenDocSpec("C:\Users\Public\Documents\SOLIDWORKS\SOLIDWORKS 2018\samples\tutorial\swutilities\bracket_a.sldprt")
    Set swModel = swApp.ActiveDoc
    If swModel Is Nothing Then
        Set swModel = swApp.OpenDoc7(swDocSpecification)
    End If
    Set swSelMgr = swModel.SelectionManager
    Set swModelExt = swModel.Extension    
    ' Select all of the extrude features; Base-Extrude and Boss-Extrude5 are marked with a value of 8
    bRet = swModelExt.SelectByID2("Base-Extrude", "BODYFEATURE", 0, 0, 0, True, 8, Nothing, swSelectOptionDefault)
    bRet = swModelExt.SelectByID2("Boss-Extrude3", "BODYFEATURE", 0, 0, 0, True, 0, Nothing, swSelectOptionDefault)
    bRet = swModelExt.SelectByID2("Boss-Extrude4", "BODYFEATURE", 0, 0, 0, True, 0, Nothing, swSelectOptionDefault)
    bRet = swModelExt.SelectByID2("Boss-Extrude5", "BODYFEATURE", 0, 0, 0, True, 8, Nothing, swSelectOptionDefault)
    bRet = swModelExt.SelectByID2("Boss-Extrude7", "BODYFEATURE", 0, 0, 0, True, 0, Nothing, swSelectOptionDefault)
    
    ' Look for a given mark value
    lMark = 8        
    ' Get the number of marked selections
    lNumMarkedSelections = swSelMgr.GetSelectedObjectCount2(lMark)
    Debug.Print "Number of marked selections = " & lNumMarkedSelections        
    ' Get the total number of selections
    lNumAllSelections = swSelMgr.GetSelectedObjectCount2(-1)
    Debug.Print "Number of selections        = " & lNumAllSelections
    Debug.Print " "

    For lMarkedIdx = 1 To lNumMarkedSelections
            Set swMarkedSelectedObject = swSelMgr.GetSelectedObject6(lMarkedIdx, lMark)
            
            For lAllIdx = 1 To lNumAllSelections
                Set swSelectedObject = swSelMgr.GetSelectedObject6(lAllIdx, -1)
                If (swMarkedSelectedObject Is swSelectedObject) Then
                ' Types must match
                Debug.Assert (swSelMgr.GetSelectedObjectType3(lMarkedIdx, lMark) = swSelMgr.GetSelectedObjectType3(lAllIdx, -1))
                Debug.Print "Number of marked selections = " & lMarkedIdx
                Debug.Print "Number of selections        = " & lAllIdx
                Debug.Print " "
                Exit For
                End If
            Next lAllIdx
        Next lMarkedIdx         
        swModel.ClearSelection2 True         
End Sub
