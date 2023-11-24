namespace Library1

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

type Class1(iSwApp: ISldWorks) = 
    member this.CreateCube() =
        //make sure we have a part open
        let partTemplate = 
            iSwApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplatePart)
        if partTemplate <> null && partTemplate <> "" then
            let modDoc = 
                iSwApp.NewDocument(partTemplate, int swDwgPaperSizes_e.swDwgPaperA2size, 0.0, 0.0)
                :?> IModelDoc2

            modDoc.InsertSketch2(true)
            modDoc.SketchRectangle(0., 0., 0., 0.1, 0.1, 0.1, false)

            //Extrude the sketch
            let featMan = modDoc.FeatureManager
            featMan.FeatureExtrusion(true,
                    false, false,
                    int swEndConditions_e.swEndCondBlind, int swEndConditions_e.swEndCondBlind,
                    0.1, 0.0,
                    false, false,
                    false, false,
                    0.0, 0.0,
                    false, false,
                    false, false,
                    true,
                    false, false)
            |> ignore
        else
            iSwApp.SendMsgToUser "There is no part template available. Please check your options and make sure there is a part template selected, or select a new part template."
