module Preselection //第7章1节

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms.Literal
open FSharp.SolidWorks

let generate (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let factor = 5.0

    let swSelMgr =
        swModel.SelectionManager
        :?> SelectionMgr

    let count =
        swSelMgr
        |> SelectionMgrUtils.getSelectedObjectCount2 SelectionMgrUtils.Mark.All

    if count <> 1 then
        swApp
        |> SldWorksUtils.sendMsgToUser2
            "Please select only Extrude1."
            swMessageBoxIcon_e.swMbWarning
            swMessageBoxBtn_e.swMbOk
        |> ignore

    else
        let feat =
            swSelMgr
            |> SelectionMgrUtils.getSelectedObject6 1 SelectionMgrUtils.Mark.All
            :?> Feature

        if feat.GetTypeName2() <> "Extrusion" then
            swApp
            |> SldWorksUtils.sendMsgToUser2
                "Please select only Extrude1."
                swMessageBoxIcon_e.swMbWarning
                swMessageBoxBtn_e.swMbOk
            |> ignore

        else
            //修改特征的代码
            let extrudeFeatureData =
                feat.GetDefinition() :?> ExtrudeFeatureData2

            let depth = extrudeFeatureData.GetDepth(true)
            extrudeFeatureData.SetDepth(true, depth * factor)

            feat.ModifyDefinition(extrudeFeatureData, swModel, null)
            |> ignore

            ////命令
            //cmds.add(
            //    hintOrTip: "第7章1节",
            //    callbackFunction: nameof(this.Training7_Preselection)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第7章3节",
            //    callbackFunction: nameof(this.Training7_BodyFaceTraversal)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第7章4节1~2",
            //    callbackFunction: nameof(this.Training7_FeatMgrTraversal_msg)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第7章4节之压缩圆角",
            //    callbackFunction: nameof(this.Training7_FeatMgrTraversal_suppress)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第7章4节之隐藏设计树所有特征",
            //    callbackFunction: nameof(this.Training7_FeatMgrTraversal_setUIState)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第7章4节之设计树指定位置的特征",
            //    callbackFunction: nameof(this.Training7_FeatMgrTraversal_featureByPositionReverse)
            //    );

        //public void Training7_Preselection()
        //{
        //    Preselection.generate(this.iSwApp);
        //}

        //public void Training7_BodyFaceTraversal()
        //{
        //    BodyFaceTraversal.main(this.iSwApp);
        //}

        //public void Training7_FeatMgrTraversal_msg()
        //{
        //    FeatMgrTraversal.msg(this.iSwApp);
        //}

        //public void Training7_FeatMgrTraversal_suppress()
        //{
        //    FeatMgrTraversal.suppress(this.iSwApp);
        //}

        //public void Training7_FeatMgrTraversal_setUIState()
        //{
        //    FeatMgrTraversal.setUIState(this.iSwApp);
        //}

        //public void Training7_FeatMgrTraversal_featureByPositionReverse()
        //{
        //    FeatMgrTraversal.featureByPositionReverse(this.iSwApp);
        //}
