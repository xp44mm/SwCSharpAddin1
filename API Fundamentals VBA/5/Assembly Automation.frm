Option Explicit

Const TRAININGDIR As String = _
  "C:\SolidWorks Training Files\API Fundamentals\"
Const LESSONDIR As String = TRAININGDIR & _
  "Lesson05 - Assembly Automation\"
Const FILEDIR As String = LESSONDIR & _
  "Case Study\Guitar Effect Pedal\"
  
Public swApp As SldWorks.SldWorks
Public swModel As SldWorks.ModelDoc2
Public swSelMgr As SldWorks.SelectionMgr
Public swAssy As SldWorks.AssemblyDoc
Public swSelFace As SldWorks.face2
Public swMathUtility As SldWorks.MathUtility
Public swCompTransform As SldWorks.MathTransform
Public swSafeSelFace As SldWorks.face2

Public AssemblyTitle As String
Public AssemblyName As String
Public errors As Long
Public warnings As Long

Public PointCollection As New Collection
Public CircularCurveCollection As New Collection
Public CircularEdgeCollection As New Collection
Public SafeCylindricalFaceCollection As New Collection
Public PointOnCylindricalSurfCollection As New Collection
Dim i As Integer
Dim j As Integer

Private Sub cmdExit_Click()
  End
End Sub

Private Sub UserForm_Activate()
  Set swApp = Application.SldWorks
  Set swMathUtility = swApp.GetMathUtility()
End Sub

'Simple helper function to chop the extension of the file name.
Public Sub ParseAssemblyName()
  Dim strings As Variant                 'Create an array of strings
  strings = Split(AssemblyTitle, ".")    'split the assembly title at the "." to strip of the extension
  AssemblyName = strings(0)              'Set the name to the first element of the array
End Sub

Private Sub cmdAddComponentsAndMate_Click()
  Set swModel = swApp.ActiveDoc
  If swModel Is Nothing Then
    MsgBox ("Open an assembly to run this macro.")
    Exit Sub
  End If
  AssemblyTitle = swModel.GetTitle
  Call ParseAssemblyName
  Set swSelMgr = swModel.SelectionManager
  
  'Do some validation before running routines....
  Dim SelObjType As Long
  SelObjType = swSelMgr.GetSelectedObjectType3(1, -1)
  If SelObjType = swSelFACES Then
    'Get the selected face, ignore marks
    Set swSelFace = swSelMgr.GetSelectedObject6(1, -1)
    'Create a Safe Entity so we can select it when the face
    'becomes invalid
    Dim swEntity As SldWorks.entity
    Set swEntity = swSelFace
    Set swSafeSelFace = swEntity.GetSafeEntity
  Else
    MsgBox ("You did not select a face.")
    Exit Sub
  End If
  'We broke the work of this project into several sub routines
  'to make it easier to grasp.
  Call EstablishTargetComponentsTransform
  Call OpenComponentModelToAddToAssembly _
    (FILEDIR & "control knob.SLDPRT")
  Call EstablishCircularCurveAndEdgeCollections
  Call EstablishCylindricalFaceCollection
  Call EstablishPointsCollection
  Call AddcomponentsToAssembly("control knob.SLDPRT")
  Call Finalize
End Sub
Public Function EstablishTargetComponentsTransform()
'We need to find out where the target component "lives" in the assembly
'There are 2 types of space in an assembly doc. Assembly Space, and Component space
'Think of the assembly space as the town where you live.
'Think of the Component space as the Address of your house in that town
  Dim swComponent As Component2                   'Create a component pointer
  Set swComponent = swSafeSelFace.GetComponent() 'Set the component to the entity objects owning component
  'Set the forms swCompTransform member to store this transform for later use.
  Set swCompTransform = swComponent.Transform2
End Function
Public Sub OpenComponentModelToAddToAssembly(ByVal _
    strCompModelname As String)
  'this sub routine will open the component that you want to add to the assembly
  swApp.DocumentVisible False, swDocPART     'We open the document invisible to the user *must set this back to true when program ends, or else any
                                              'parts that the user opens in the UI will be invisible! - See the finalize method
  swApp.OpenDoc6 strCompModelname, swDocPART, 0, "", errors, warnings                        'Open the component. This must be open or the AddComponent method will fail
  
  Set swModel = swApp.ActivateDoc3(AssemblyTitle, False, _
    swDontRebuildActiveDoc, errors)    'Reactivate the assembly because that is where the rest of the work is done
  Set swAssy = swModel
End Sub
Public Sub EstablishCircularCurveAndEdgeCollections()
  'These next several routines set up Collections of geometry gathered from the selected face
  'this first routine traverses all the loops on the selected face.
  'If the loop is an inner loop then it gets an array of all of the edges belonging to that loop
  'Then one by one it checks each edge to see if it is a complete circle. If it is then it adds the
  'Edge object and it's corresponding curve to their appropriate collections.
  Dim swLoop As SldWorks.Loop2
  Set swLoop = swSelFace.GetFirstLoop  'Get the first loop on the face
  While Not swLoop Is Nothing         'Traverse all the loops in the selected face
    'swLoop.Select swLoop.GetEdges(0), False, Nothing
    If swLoop.IsOuter = False Then          'Don't do anything if it is the outer loop
      Dim swEdges As Variant
      swEdges = swLoop.GetEdges()     'if it's an inner loop, get the array of edges belonging to the loop
      For i = 0 To UBound(swEdges)    'for every edge in the array get its curve object
        'swEdges(i).Select4 False, Nothing                 'uncomment this to see the edges in SW
        Dim swCurve As SldWorks.Curve
        Set swCurve = swEdges(i).GetCurve               'Set the current curve object
        If swCurve.IsCircle Then                        'if the curve is a circle then ...
          Dim dStart As Double
          Dim dEnd As Double
          Dim bIsClosed As Boolean
          Dim bIsPeriodic As Boolean
          swCurve.GetEndParams dStart, dEnd, bIsClosed, _
            bIsPeriodic
          If Not bIsClosed = False Then           'If the curve is a complete circle then ...
            CircularEdgeCollection.Add swEdges(i)  'Add the current edge to the edge collection
            CircularCurveCollection.Add swCurve    'Add the current curve to the curve collection
          End If
        End If
      Next i
    End If
    Set swLoop = swLoop.GetNext        'Traverse until no more loops are availiable
  Wend
End Sub
Public Sub EstablishCylindricalFaceCollection()
  'Not only do we need all of the edges and curves, but we need the cylindrical faces
  'This will help us establish the concentric mate needed to tie the control button concentrically to the hole in the chassis
  'For every edge in the EdgeCollection, we want to get the cylindrical face one one side of the edge.
  'Use the method GetTwoAdjacentFaces2 to get a pointer to each face that shares the edge.
  'One of these will be the cylindrical face needed for mating
  For i = 1 To CircularEdgeCollection.Count
    Dim swFaces As Variant
    swFaces = CircularEdgeCollection.Item(i). _
      GetTwoAdjacentFaces2() 'use this to get the 2 faces sharing the Circular edge
    Dim swSurface1 As SldWorks.surface  'Declare a surface pointer for the first face
    Dim swSurface2 As SldWorks.surface  'Declare another surface pointer for the second face
    Set swSurface1 = swFaces(0).GetSurface  'Set the first pointer
    Set swSurface2 = swFaces(1).GetSurface  'Set the second pointer
    Dim swEntity As SldWorks.entity
    Set swEntity = Nothing
    'Determine which one is the cylindrical surface
    If swSurface1.IsCylinder Then
      Set swEntity = swFaces(0)
    ElseIf swSurface2.IsCylinder Then
      Set swEntity = swFaces(1)
    End If
    'When the cylindrical Face is found....
    If Not swEntity Is Nothing Then
      Dim swSafeFace As SldWorks.entity
      Set swSafeFace = swEntity.GetSafeEntity
      SafeCylindricalFaceCollection.Add swSafeFace
    End If
  Next i
End Sub

Public Sub EstablishPointsCollection()
  'Now we need to establish a collection of points needed for adding the new components in the correct
  'location in the assembly
  'Remember that the points that we retrieve from the center location of the cylindrical face / circular edges are not in assembly coordinates.
  'Whatever the center position is needs to by multiplied by the target component's transform.
  'If we do not do this the new component is put in at the assembly space instead of where the component actually lives in the assembly
  'When I build the collection of center points, I use the MathPoint object from the MathUtility class.
  'this object has a very convenient method to multiply the point location by the transform of the target component in the assembly.
  'If we didn't have this method, we'd need to work all the math out programatically
  'the math classes are your friend! :)
  For i = 1 To CircularCurveCollection.Count() 'For every circular curve get it's center point and multiply by the transform and add it to the collection.
    Dim circleParams As Variant
    circleParams = CircularCurveCollection(i).circleParams    'Fill the Circle Params array with the Circle information from the curve.
    Dim arrayData(2) As Double                                  'Create a 3 element array to pass into the constructor of the math point object
    Dim swMathPoint As SldWorks.mathPoint                       'use the center point locations to create a Solidworks MathPoint object
    arrayData(0) = circleParams(0)                              'fill the coordinate data into the array
    arrayData(1) = circleParams(1)
    arrayData(2) = circleParams(2)
    
    'use the math point class to store these points
    Set swMathPoint = swMathUtility.CreatePoint(arrayData)         'Create the mathpoint using the location data
    Set swMathPoint = swMathPoint.MultiplyTransform _
      (swCompTransform) 'Now multiply the math point by the Target component's transform.
    PointCollection.Add swMathPoint                                   'Add it to the point collection for use in the mating routine.
  Next i
End Sub

Public Sub AddcomponentsToAssembly(ByVal strCompFullPath As _
    String)
  'Now we are ready to add the new components to the assembly and automatically mate them.
  'for every point in the point collection, we need to:
  
    '1.) Add the component at that location
    '2.) Add a coincident mate between the selected face on the target component, and the bottom face of the control knob (we use the top plane of the comp for that.)
    '3.) Once that mate is completed, we create the concentric mate by selecting the cylindrical face from the safecylindricalface collection
    'and the origin of the new component
      
  For j = 1 To PointCollection.Count        'For every location in the point collection ......
    'Add a coincident mate between the bottom face of the new component and the target face of the target component.....
    
    Dim pointData As Variant
    pointData = PointCollection.Item(j).arrayData  'Get the coordinates of the transformed math points in the mathpoint collection.
    Dim swComponent As Component2
    Set swComponent = swAssy.AddComponent5(strCompFullPath, _
      swAddComponentConfigOptions_CurrentSelectedConfig, "", _
      False, "", pointData(0), pointData(1), pointData(2))   'Add the control knob at that location.
    Dim strCompName As String
    strCompName = swComponent.Name2()                   'Get the name and instance of the newly added component for selection
    
    Dim SelData As SldWorks.SelectData
    Set SelData = swModel.SelectionManager.CreateSelectData
    SelData.Mark = 1
    swModel.ClearSelection2 True
    swSafeSelFace.Select4 True, SelData
    swModel.Extension.SelectByID2 "Top@" + strCompName & _
      "@" + AssemblyName, "PLANE", 0, 0, 0, True, 1, _
      Nothing, swSelectOptionDefault 'Select the top plane of the newly added control knob.
    swAssy.AddMate5 swMateCOINCIDENT, swMateAlignCLOSEST, _
      False, 0, 0, 0, 0, 0, 0, 0, 0, False, False, _
      swMateWidth_Centered, errors 'Add a coincident mate.
    swModel.ClearSelection2 True
    SafeCylindricalFaceCollection(j).Select4 True, SelData
    swModel.Extension.SelectByID2 "Point1@Origin@" + _
      strCompName + "@" + AssemblyName, _
      "EXTSKETCHPOINT", 0, 0, 0, True, 1, Nothing, _
      swSelectOptionDefault 'now select the origin of the new control knob
    swAssy.AddMate5 swMateCONCENTRIC, swMateAlignCLOSEST, _
      False, 0, 0, 0, 0, 0, 0, 0, 0, False, False, _
      swMateWidth_Centered, errors 'Add the concentric mate!
    swModel.ClearSelection2 True
  Next j
  
  '*Question...   'What is the purpose of Entity.GetSafeEntity and the SafeCylindricalFaceCollection collection ????
  '*Answer...     'It seems that when we add a new component to the assembly, and the assembly is rebuilt..
                  'we lose the pointers to the faces that we had stored in the face collection.
                  'If we tried to call entity.Select4 on the swSelFace after a component is added to the assembly, we
                  'get an error from VB telling us that the
                  'object has disconnected from it's client. That means that the pointer to the face is no longer valid.
                                      
                  'To fix this problem, we use the method Entity.GetSafeEntity. These pointers will not become invalid when
                  'a component is added to an assembly, and the assembly is regenerated.
                                      
                                      
                  'The same thing would happen if we tried to store pointers to the cylindrical faces needed for the
                  'concentric mate of the knob to the cylindrical face on the chasis.
                  
                  'I built a collection of safe entities so that I could ensure that these faces could still be selected
                  'even though the assembly is constantly being updated every time I add a component.
End Sub

Public Sub Finalize()
  'Clean up all the variables and reset SW settings
  swApp.DocumentVisible True, swDocPART
  Set swAssy = Nothing
  Set CircularCurveCollection = Nothing
  Set CircularEdgeCollection = Nothing
  Set SafeCylindricalFaceCollection = Nothing
  Set swModel = Nothing
  Set PointCollection = Nothing
  Set swSelFace = Nothing
  Set swSelMgr = Nothing
End Sub
