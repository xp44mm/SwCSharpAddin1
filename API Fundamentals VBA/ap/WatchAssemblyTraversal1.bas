Attribute VB_Name = "WatchAssemblyTraversal1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================


'This code demonstrates how to traverse an assembly and create a list of
'All of its components. You could use this code to create a bill of materials.
'Also in this code we traverse all of the features in each component and
'print them underneath the component in the list.
'You should show your Immediate window when running your macro to see the output.
'Ctrl+G

Option Explicit

Sub main()
  'Macro Entry point
  Dim swApp                   As SldWorks.SldWorks
  Dim swModel                 As SldWorks.ModelDoc2
  Dim swConfigMgr             As SldWorks.ConfigurationManager
  Dim swAssy                  As SldWorks.AssemblyDoc
  Dim swConf                  As SldWorks.configuration
  Dim swRootComp              As SldWorks.Component2
  Dim nStart                  As Single
  Dim bRet                    As Boolean
  Set swApp = Application.SldWorks 'Connect to SW
  Set swModel = swApp.ActiveDoc 'Get the active assembly
  Set swConfigMgr = swModel.ConfigurationManager
  'Get the active config
  Set swConf = swConfigMgr.ActiveConfiguration
  'Get it's root component
  Set swRootComp = swConf.GetRootComponent3(True)
  nStart = Timer
  Debug.Print "File = " & swModel.GetPathName
  
  'traverse all of the assembly features
  TraverseModelFeatures swModel, 1
  'Now traverse all of the components and sub assemblies
  TraverseComponent swRootComp, 1
  Debug.Print ""
  Debug.Print "Time = " & Timer - nStart & " s"
End Sub

Sub TraverseModelFeatures(swModel As SldWorks.ModelDoc2, _
  nLevel As Long)
  'this code recursively traverses all of the
  'features in a model
  Dim swFeat                      As SldWorks.feature
  Set swFeat = swModel.FirstFeature
  TraverseFeatureFeatures swFeat, nLevel
End Sub

Sub TraverseFeatureFeatures(swFeat As SldWorks.feature, _
  nLevel As Long)
  'recursively traversing the feature's features
  Dim swSubFeat                   As SldWorks.feature
  Dim swSubSubFeat                As SldWorks.feature
  Dim swSubSubSubFeat             As SldWorks.feature
  Dim sPadStr                     As String
  Dim i                           As Long
  
  For i = 0 To nLevel
    sPadStr = sPadStr + "  "
  Next i
  While Not swFeat Is Nothing
    Debug.Print sPadStr + swFeat.Name + " [" + _
      swFeat.GetTypeName2 + "]"
    Set swSubFeat = swFeat.GetFirstSubFeature
    While Not swSubFeat Is Nothing
      Debug.Print sPadStr + "  " + swSubFeat.Name + _
        " [" + swSubFeat.GetTypeName2 + "]"
      Set swSubSubFeat = swSubFeat.GetFirstSubFeature
      While Not swSubSubFeat Is Nothing
        Debug.Print sPadStr + "    " + _
          swSubSubFeat.Name + " [" + _
          swSubSubFeat.GetTypeName2 + "]"
        Set swSubSubSubFeat = swSubFeat. _
          GetFirstSubFeature
        While Not swSubSubSubFeat Is Nothing
          Debug.Print sPadStr + "      " + _
            swSubSubSubFeat.Name + " [" + _
            swSubSubSubFeat.GetTypeName2 + "]"
          Set swSubSubSubFeat = swSubSubSubFeat. _
            GetNextSubFeature()
        Wend
        Set swSubSubFeat = swSubSubFeat. _
          GetNextSubFeature()
      Wend
      Set swSubFeat = swSubFeat.GetNextSubFeature()
    Wend
    Set swFeat = swFeat.GetNextFeature
  Wend
End Sub

Sub TraverseComponent(swComp As SldWorks.Component2, _
  nLevel As Long)
  'this recursively traverses all of the components in an
  'assembly and prints their name to the immediate window
  Dim vChildComp                  As Variant
  Dim swChildComp                 As SldWorks.Component2
  Dim swCompConfig                As SldWorks.configuration
  Dim sPadStr                     As String
  Dim i                           As Long
  For i = 0 To nLevel - 1
    sPadStr = sPadStr + "  "
  Next i
  
  vChildComp = swComp.GetChildren
  For i = 0 To UBound(vChildComp)
    Set swChildComp = vChildComp(i)
    Debug.Print sPadStr & "+" & swChildComp.Name2 & " <" & _
      swChildComp.ReferencedConfiguration & ">"
    TraverseComponentFeatures swChildComp, nLevel
    TraverseComponent swChildComp, nLevel + 1
  Next i
End Sub

Sub TraverseComponentFeatures(swComp As SldWorks.Component2, _
  nLevel As Long)
  'this recursively traverses all of the components features
  Dim swFeat                      As SldWorks.feature
  Set swFeat = swComp.FirstFeature
  TraverseFeatureFeatures swFeat, nLevel
End Sub

