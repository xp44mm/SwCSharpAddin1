//-----------------------------------------------
// Preconditions:
// 1. Open a part document.
// 2. Select a feature in the FeatureManager design
//    tree.
// 3. Open the Immediate window.
//
// Postconditions:
// 1. Gets the name of the feature and number
//    of faces.
// 2. Colors the faces of the feature blue.
//    NOTE: The faces are the same faces as if you
//    selected the feature in the user interface.
// 3. Examine the Immediate window and graphics area.
//-----------------------------------------------
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
 
namespace GetFaceCountCSharp.csproj
{
    public partial class SolidWorksMacro
    {
        public void Main()
        {
            ModelDoc2 swModel = default(ModelDoc2);
            SelectionMgr swSelMgr = default(SelectionMgr);
            SelectData swSelData = default(SelectData);
            Feature swFeat = default(Feature);
            Feature swFaceFeat = default(Feature);
            object[] faceArr = null;
            double[] featColors = null;
            Face2 swFace = default(Face2);
            Entity swEnt = default(Entity);
            bool status = false;
 
            swModel = (ModelDoc2)swApp.ActiveDoc;
            swSelMgr = (SelectionMgr)swModel.SelectionManager;
            swFeat = (Feature)swSelMgr.GetSelectedObject6(1, -1);
            swSelData = (SelectData)swSelMgr.CreateSelectData();
 
            Debug.Print("Feature = " + swFeat.Name + " [" + swFeat.GetTypeName() + "]");
            Debug.Print("  Face count = " + swFeat.GetFaceCount());
 
            swModel.ClearSelection2(true);
 
            featColors = (double[])swModel.MaterialPropertyValues;
            featColors[0] = 0;    //R
            featColors[1] = 0;    //G
            featColors[2] = 1;    //B
 
            faceArr = (object[])swFeat.GetFaces();
            if ((faceArr == null))
                return;
            foreach (object oneFace in faceArr)
            {
                swFace = (Face2)oneFace;
                swEnt = (Entity)swFace;
                swFaceFeat = (Feature)swFace.GetFeature();
                // Check to see if face is owned by multiple features
                if (object.ReferenceEquals(swFaceFeat, swFeat))
                {
                    status = swEnt.Select4(true, swSelData);
                    Debug.Assert(status);
                    swFace.MaterialPropertyValues = featColors;
                }
                else
                {
                    Debug.Print("  Other feature = " + swFaceFeat.Name + " [" + swFaceFeat.GetTypeName() + "]");
                }
            }
 
        }
 
        /// <summary>
        ///  The SldWorks swApp variable is pre-assigned for you.
        /// </summary>
        public SldWorks swApp;
    }
}