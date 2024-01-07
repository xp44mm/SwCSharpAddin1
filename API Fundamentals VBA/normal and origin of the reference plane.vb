'------------------------------------------------------------
' Preconditions: Open a part document that has these planes:
' * Front Plane
' * Top Plane
' * Right Plane
' * Plane2
' * Plane3
' * Plane4
' * Plane5
'
' Postconditions:
' 1. Creates a 3D sketch (i.e., a line) from each reference plane
'    origin in the direction of the reference plane normal.
' 2. Examine the graphics area and FeatureManager design tree.
'-------------------------------------------------------------
Option Explicit
Dim swApp As SldWorks.SldWorks
Sub main()
    Dim swModel As SldWorks.ModelDoc2
    Dim swPart As SldWorks.PartDoc
    Dim swFeature As SldWorks.Feature
    Dim swRefPlane As SldWorks.RefPlane
    Dim swOriginPoint As SldWorks.MathPoint
    Dim swRefPlaneTransform As SldWorks.MathTransform
    Dim swMathUtility As SldWorks.MathUtility
    Dim aPointData(2) As Double
    Dim vPointData As Variant
    Dim swOriginPointOnRefPlane As SldWorks.MathPoint
    Dim swNormalVector As SldWorks.MathVector
    Dim swNormalVectorRefPlane As SldWorks.MathVector
    Dim aVectorData(2) As Double
    Dim vVectorData  As Variant
    Dim dScaleFactor As Double
    Dim strRefPlaneName As String
    Dim aRefPlanes(6) As String
    Dim lIdx As Long
    
    ' Connect to SOLIDWORKS
    Set swApp = Application.SldWorks
    ' Get the math utility
    Set swMathUtility = swApp.GetMathUtility
    ' Get active document
    Set swModel = swApp.ActiveDoc
    ' Cast down
    Set swPart = swModel
    ' Fill an array with names of reference planes to visit:
    ' *  You can replace this by a loop over all reference planes in the model
    ' *  In particular, check the "Front Plane" as this defines the canonical
    '    position and orientation of a reference plane
    aRefPlanes(0) = "Front Plane"
    aRefPlanes(1) = "Top Plane"
    aRefPlanes(2) = "Right Plane"
    aRefPlanes(3) = "Plane2"
    aRefPlanes(4) = "Plane3"
    aRefPlanes(5) = "Plane4"
    aRefPlanes(6) = "Plane5"
    ' Loop over all reference planes of interest
    For lIdx = LBound(aRefPlanes) To UBound(aRefPlanes)
        ' Get reference plane feature by name as feature
        Set swFeature = swPart.FeatureByName(aRefPlanes(lIdx))
        ' Get the name
        strRefPlaneName = swFeature.Name
        ' Cast down
        Set swRefPlane = swFeature.GetSpecificFeature2
        ' Get the reference plane transform:
        ' * This transform takes a reference plane from
        '   its canonical position/orientation to its
        '   actual Position / Orientation
        ' * The canonical position/orientation is aligned
        '   with the system defined "Front Plane"
        Set swRefPlaneTransform = swRefPlane.Transform
        ' Create a math point that represents the reference plane's origin
        ' in the canonical position in world coordinates; this is
        ' (0.0, 0.0, 0.0)
        ' Create array data
        aPointData(0) = 0#
        aPointData(1) = 0#
        aPointData(2) = 0#
        ' Turn into a Variant
        vPointData = aPointData
        ' Create a math point
        Set swOriginPoint = swMathUtility.CreatePoint(vPointData)
        ' Transform the reference plane origin from its canonical
        ' position to its actual position
        Set swOriginPointOnRefPlane = swOriginPoint.MultiplyTransform(swRefPlaneTransform)
        ' Get point data
        vPointData = swOriginPointOnRefPlane.ArrayData
        ' Create a math vector that represents the reference plane's normal in
        ' the canonical orientation in world coordinates; this is [0.0, 0.0, 1.0]
        ' Create array data
        aVectorData(0) = 0#
        aVectorData(1) = 0#
        aVectorData(2) = 1#
        ' Turn into a Variant
        vVectorData = aVectorData
        ' Create a math vector
        Set swNormalVector = swMathUtility.CreateVector(vVectorData)
            
        ' Now transform the reference plane normal from its canonical
        ' orientation to its actual orientation
        Set swNormalVectorRefPlane = swNormalVector.MultiplyTransform(swRefPlaneTransform)
        ' Get vector data
        vVectorData = swNormalVectorRefPlane.ArrayData
        ' Visualize
        ' As the reference plane normal is normalized, it may be bit out of
        ' proportion; this factor is arbitrary
        dScaleFactor = 0.1
        ' Insert a 3D sketch
        swModel.Insert3DSketch2 True
        ' Create a line from the reference plane origin in the direction
        ' of the reference plan normal
        swModel.CreateLine2 vPointData(0), vPointData(1), vPointData(2), vPointData(0) + dScaleFactor * vVectorData(0), vPointData(1) + dScaleFactor * vVectorData(1), vPointData(2) + dScaleFactor * vVectorData(2)
        ' Close the sketch
        swModel.Insert3DSketch2 True
        ' The sketch is still selected
        Set swFeature = swModel.SelectionManager.GetSelectedObject6(1, 0)
        
        ' Rename it
        swFeature.Name = strRefPlaneName & "-Normal"
        ' Clear selection for the next pass
        swModel.ClearSelection2 True
    Next lIdx
End Sub