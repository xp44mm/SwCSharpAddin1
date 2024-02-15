-----------------------------------------

' Precondition: Model document is open.

'

' Postconditions: Coordinate system feature is created.

'-----------------------------------------

Option Explicit

 

Dim swApp As SldWorks.SldWorks

Dim swModel As SldWorks.ModelDoc2

Dim swModelDocExt As SldWorks.ModelDocExtension

Dim swSelMgr As SldWorks.SelectionMgr

Dim swFeat As SldWorks.Feature

Dim swFeatMgr As SldWorks.FeatureManager

Dim cSysData As SldWorks.CoordinateSystemFeatureData

Dim component As SldWorks.Component2

Dim boolstatus As Boolean

Dim vo As Variant

Dim vx As Variant

Dim vy As Variant

Dim vz As Variant

Dim evo As Variant

Dim evx As Variant

Dim evy As Variant

Dim evz As Variant

Dim so(0) As Object

Dim sx(1) As Object

Dim sy(1) As Object

Dim sz(1) As Object

Dim eso(0) As Object

Dim esx(1) As Object

Dim esy(1) As Object

Dim esz(1) As Object

Dim xEnt   As Object

 

Sub main()

 

Set swApp = Application.SldWorks

Set swModel = swApp.ActiveDoc

Set swSelMgr = swModel.SelectionManager

Set swModelDocExt = swModel.Extension

Set swFeatMgr = swModel.FeatureManager

boolstatus = swModelDocExt.SelectByID2("", "VERTEX", 0, 0.00635, 0, False, 0, Nothing, 0)

boolstatus = swModelDocExt.SelectByID2("", "FACE", 0.0308159564126, 0.006349999999827, 0.01220751949762, True, 0, Nothing, 0)

boolstatus = swModelDocExt.SelectByID2("", "VERTEX", 0.0762, 0.00635, 0.01905, True, 0, Nothing, 0)

boolstatus = swModelDocExt.SelectByID2("", "VERTEX", 0.0762, 0.00635, 0, True, 0, Nothing, 0)

 

' Assume a vertex was selected for the origin

Set so(0) = swSelMgr.GetSelectedObject6(1, -1)

' Assume one entity (point, line/edge, plane/face) was selected for the x axis

Set sx(0) = swSelMgr.GetSelectedObject6(2, -1)

' Assume two entities (point, line/edge, plane/face) were selected for the y axis

Set sy(0) = swSelMgr.GetSelectedObject6(3, -1)

Set sy(1) = swSelMgr.GetSelectedObject6(4, -1)

' Try getting additional selected entities for the z axis

Set sz(0) = swSelMgr.GetSelectedObject6(5, -1)

Set sz(1) = swSelMgr.GetSelectedObject6(6, -1)

 

vo = so

vx = sx

vy = sy

vz = sz

 

swModel.ClearSelection2 True

 

' Create coordinate system

Set swFeat = swFeatMgr.CreateCoordinateSystem(so(0), (vx), (vy), (vz))

    
If swFeat Is Nothing Then

    Debug.Print "Did not create a coordinate system feature!"

Else

    Set cSysData = swFeat.GetDefinition

    boolstatus = cSysData.AccessSelections(swModel, component)

    
    ' Get and output the transform

    Dim swXform  As SldWorks.MathTransform

    Set swXform = cSysData.Transform

    Debug.Print "    Origin = (" & -1# * swXform.ArrayData(9) * 1000# & ", " & -1# * swXform.ArrayData(10) * 1000# & ", " & -1# * swXform.ArrayData(11) * 1000# & ") mm"

    Debug.Print "    Rot1   = (" & swXform.ArrayData(0) & ", " & swXform.ArrayData(1) & ", " & swXform.ArrayData(2) & ")"

    Debug.Print "    Rot2   = (" & swXform.ArrayData(3) & ", " & swXform.ArrayData(4) & ", " & swXform.ArrayData(5) & ")"

    Debug.Print "    Rot3   = (" & swXform.ArrayData(6) & ", " & swXform.ArrayData(7) & ", " & swXform.ArrayData(8) & ")"

    Debug.Print "    Trans  = (" & swXform.ArrayData(9) * 1000# & ", " & swXform.ArrayData(10) * 1000# & ", " & swXform.ArrayData(11) * 1000# & ") mm"

    Debug.Print "    Scale  = " & swXform.ArrayData(12)

    
    Debug.Print "XFlipped? " & cSysData.XFlipped

    cSysData.XFlipped = True

   
    
    ' Select new entities for editing the coordinate system feature

    boolstatus = swModelDocExt.SelectByID2("", "VERTEX", 0, 0.00635, 0.01905, False, 0, Nothing, 0)

    boolstatus = swModelDocExt.SelectByID2("", "EDGE", 0.03505266269053, -6.420391980555E-05, 0.01914079805448, True, 2, Nothing, 0) ' Assume a vertex was selected for the origin

    boolstatus = swModelDocExt.SelectByID2("", "FACE", 0.0308159564126, 0.006349999999827, 0.01220751949762, True, 3, Nothing, 0)

    
    ' Edit the origin

    Set eso(0) = swSelMgr.GetSelectedObject6(1, -1)

    
    ' Edit the y axis

    ' Assume two entities (point, line/edge, plane/face) were selected for the y axis

   
    Set esy(0) = swSelMgr.GetSelectedObject6(2, -1)

    Set esz(0) = swSelMgr.GetSelectedObject6(3, -1)

    
    evo = eso

    evy = esy

    evz = esz

    
    swModel.ClearSelection2 True

   
    cSysData.OriginEntity = eso(0)

    cSysData.YAxisEntities = evy

    
    ' Try appending z-axis entities to see if they replace x-axis entity

    ' If this happens, then y and z are the active axes,

    ' and x-axis entity is inaccessible

    cSysData.ZAxisEntities = evz

    
    ' Get the origin entity

    Dim entType As Long

    Stop

    Dim geo As SldWorks.Entity

    Set geo = cSysData.OriginEntity

    entType = geo.GetType

    
    ' Get the x-axis entities; there shouldn't be any, because x is not active

    Dim gv As Variant

    Dim vCount As Long

    vCount = cSysData.GetXAxisEntitiesCount

    gv = cSysData.XAxisEntities

    
    Dim i As Long

  
    ' Get the y-axis entities

    vCount = cSysData.GetYAxisEntitiesCount

    gv = cSysData.YAxisEntities

    
        
    For i = 0 To UBound(gv)

        Set xEnt = gv(i)

        entType = xEnt.GetType

    Next i

    
    boolstatus = swFeat.ModifyDefinition(cSysData, swModel, Nothing)

    
    cSysData.ReleaseSelectionAccess

End If

 

swModel.EditRebuild3

 

End Sub

