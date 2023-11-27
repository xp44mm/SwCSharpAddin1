Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports SolidWorks.Interop.swpublished

Public Class UserPMPage
    Dim iSwApp As SldWorks
    Dim userAddin As SwAddin
    Dim handler As PMPageHandler
    Dim ppage As PropertyManagerPage2

#Region "Property Manager Page Controls"
    'Groups
    Dim group1 As PropertyManagerPageGroup
    Dim group2 As PropertyManagerPageGroup

    'Controls
    Dim checkbox1 As PropertyManagerPageCheckbox
    Dim option1 As PropertyManagerPageOption
    Dim option2 As PropertyManagerPageOption
    Dim option3 As PropertyManagerPageOption
    Dim list1 As PropertyManagerPageListbox

    Dim selection1 As PropertyManagerPageSelectionbox
    Dim num1 As PropertyManagerPageNumberbox
    Dim combo1 As PropertyManagerPageCombobox
  Dim newCombo As PropertyManagerPageCombobox
  Dim newButton As PropertyManagerPageButton

    'Control IDs
    Dim group1ID As Integer = 0
    Dim group2ID As Integer = 1
    Dim checkbox1ID As Integer = 2
    Dim option1ID As Integer = 3
    Dim option2ID As Integer = 4
    Dim option3ID As Integer = 5
    Dim list1ID As Integer = 6
    Dim selection1ID As Integer = 7
    Dim num1ID As Integer = 8
    Dim combo1ID As Integer = 9
  Dim newComboID As Integer = 10
  Dim newButtonID As Integer = 11
#End Region

    Sub Init(ByVal sw As SldWorks, ByVal addin As SwAddin)
        iSwApp = sw
        userAddin = addin
        CreatePage()
        AddControls()
    End Sub

    Sub Show()
        ppage.Show()
    End Sub

    Sub CreatePage()
        handler = New PMPageHandler()
        handler.Init(iSwApp, userAddin)
        Dim options As Integer
        Dim errors As Integer
        options = swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton + swPropertyManagerPageOptions_e.swPropertyManagerOptions_CancelButton
        ppage = iSwApp.CreatePropertyManagerPage("Sample PMP", options, handler, errors)
    End Sub

    Sub AddControls()
        Dim options As Integer
        Dim leftAlign As Integer
        Dim controlType As Integer

        'Add Groups
    options = _
      swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded _
      + swAddGroupBoxOptions_e.swGroupBoxOptions_Visible
    group1 = ppage.AddGroupBox(group1ID, _
      "Change Face Colors", options)

        'Add Controls to Group1 
    'New ComboBox
    controlType = swPropertyManagerPageControlType_e. _
      swControlType_Combobox
    leftAlign = _
      swPropertyManagerPageControlLeftAlign_e. _
      swControlAlign_LeftEdge
    options = swAddControlOptions_e. _
      swControlOptions_Enabled + _
      swAddControlOptions_e.swControlOptions_Visible
    Me.newCombo = group1.AddControl(Me.newComboID, _
      controlType, "Color Selection", leftAlign, _
      options, "Color Selection")
    Me.newCombo.AddItems("Red")
    Me.newCombo.AddItems("Green")
    Me.newCombo.AddItems("Blue")

    'New Button
    controlType = swPropertyManagerPageControlType_e. _
      swControlType_Button
    leftAlign = _
      swPropertyManagerPageControlLeftAlign_e. _
      swControlAlign_LeftEdge
    options = swAddControlOptions_e. _
      swControlOptions_Enabled + _
      swAddControlOptions_e.swControlOptions_Visible
    Me.newButton = group1.AddControl(Me.newButtonID, _
      controlType, "Color Faces", leftAlign, _
      options, "Color Faces")
    End Sub

End Class

