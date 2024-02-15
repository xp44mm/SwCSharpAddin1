using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using SolidWorks.Interop.swconst;
using SolidWorksTools;
using SolidWorksTools.File;

using FSharp.SolidWorks;

namespace SwCSharpAddin1
{
    [ComVisible(true)]
    [Guid("43f85157-13ec-476b-a57e-02fb5973e8bb")]
    [SwAddin(
            Description = "崔胜利的SW插件",
            Title = "CuiShengLi",
            LoadAtStartup = true
            )]
    public class SwAddin : ISwAddin
    {
        public const int cmdGroupID = 5;

        ISldWorks iSwApp;
        public ISldWorks SwApp { get { return this.iSwApp; } }

        ICommandManager iCmdMgr;
        public ICommandManager CmdMgr { get { return this.iCmdMgr; } }

        BitmapHandler iBmp;

        [ComRegisterFunction]
        public static void RegisterFunction(Type t)
        {
            SwAddinAttribute SWattr = null;
            var typ = typeof(SwAddin);

            foreach (System.Attribute attr in typ.GetCustomAttributes(false).Cast<System.Attribute>()) {
                if (attr is SwAddinAttribute) {
                    SWattr = attr as SwAddinAttribute;
                    break;
                }
            }

            try {
                var hklm = Microsoft.Win32.Registry.LocalMachine;
                var hkcu = Microsoft.Win32.Registry.CurrentUser;

                var keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                var addinkey = hklm.CreateSubKey(keyname);
                addinkey.SetValue(null, 0);

                addinkey.SetValue("Description", SWattr.Description);
                addinkey.SetValue("Title", SWattr.Title);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                addinkey = hkcu.CreateSubKey(keyname);
                addinkey.SetValue(null, Convert.ToInt32(SWattr.LoadAtStartup), Microsoft.Win32.RegistryValueKind.DWord);
            }
            catch (System.NullReferenceException nl) {
                //Console.WriteLine("There was a problem registering this dll: SWattr is null. \n\"" + nl.Message + "\"");
                System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: SWattr is null.\n\"" + nl.Message + "\"");
            }
            catch (System.Exception e) {
                //Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem registering the function: \n\"" + e.Message + "\"");
            }
        }

        [ComUnregisterFunction]
        public static void UnregisterFunction(Type t)
        {
            try {
                var hklm = Microsoft.Win32.Registry.LocalMachine;
                var hkcu = Microsoft.Win32.Registry.CurrentUser;

                var keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                hklm.DeleteSubKey(keyname);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                hkcu.DeleteSubKey(keyname);
            }
            catch (System.NullReferenceException nl) {
                //Console.WriteLine("There was a problem unregistering this dll: " + nl.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + nl.Message + "\"");
            }
            catch (System.Exception e) {
                //Console.WriteLine("There was a problem unregistering this dll: " + e.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + e.Message + "\"");
            }
        }

        public bool ConnectToSW(object ThisSW, int cookie)
        {
            this.iSwApp = (ISldWorks)ThisSW;
            this.iSwApp.SetAddinCallbackInfo(0, this, cookie);

            this.iCmdMgr = this.iSwApp.GetCommandManager(cookie);
            this.AddCommandMgr();

            return true;
        }

        public bool DisconnectFromSW()
        {
            this.RemoveCommandMgr();

            Marshal.ReleaseComObject(this.iCmdMgr);
            this.iBmp.Dispose();
            Marshal.ReleaseComObject(this.iSwApp);

            //The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers 
            GC.Collect();
            GC.WaitForPendingFinalizers();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return true;
        }

        public void AddCommandMgr()
        {
            //收集命令项目
            var cmds = new CommandItemCollection();

            ////命令
            //cmds.add(
            //    hintString: "training1",
            //    toolTip: "第1章示例",
            //    callbackFunction: nameof(this.Training1),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "connect to sw",
            //    toolTip: "图2-7",
            //    callbackFunction: nameof(this.Training2_3),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "new part",
            //    toolTip: "图2-12",
            //    callbackFunction: nameof(this.Training2_NewModel_Part),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "new assy",
            //    toolTip: "图2-12",
            //    callbackFunction: nameof(this.Training2_NewModel_ASM),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "new drw",
            //    toolTip: "图2-12",
            //    callbackFunction: nameof(this.Training2_NewModel_DRW),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "New PartDoc",
            //    toolTip: "图2-18",
            //    callbackFunction: nameof(this.Training2_NewPartDoc),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "New AssemblyDoc",
            //    toolTip: "图2-18",
            //    callbackFunction: nameof(this.Training2_NewAssemblyDoc),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "New DrawingDoc",
            //    toolTip: "图2-18",
            //    callbackFunction: nameof(this.Training2_NewDrawingDoc),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "New DrawingDoc",
            //    toolTip: "步骤29~31",
            //    callbackFunction: nameof(this.Training2_existingDocs_connectToSolidWorks),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "ToolbarAndCustomProperty",
            //    toolTip: "步骤33~35",
            //    callbackFunction: nameof(this.Training2_existingDocs_ToolbarAndCustomProperty),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "第2章步骤36~38",
            //    toolTip: "",
            //    callbackFunction: nameof(this.Training2_existingDocs_MirrorPart),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "第2章步骤39~41",
            //    toolTip: "",
            //    callbackFunction: nameof(this.Training2_existingDocs_InsertCavity),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "第2章步骤42~44",
            //    toolTip: "",
            //    callbackFunction: nameof(this.Training2_existingDocs_CreateLayer),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "第3章之系统选项",
            //    toolTip: "",
            //    callbackFunction: nameof(this.Training3_systemOptions),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "第3章之文档属性",
            //    toolTip: "",
            //    callbackFunction: nameof(this.Training3_documentProperties),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "第4章之零件材料",
            //    toolTip: "",
            //    callbackFunction: nameof(this.Training4_PartMaterial),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之矩形拉伸",
            //    callbackFunction: nameof(this.Training4_rectExtrusion)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之矩形旋转",
            //    callbackFunction: nameof(this.Training4_rectRevolve)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之圆形拉伸",
            //    callbackFunction: nameof(this.Training4_circleExtrusion)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之圆形旋转",
            //    callbackFunction: nameof(this.Training4_circleRevolve)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第5章",
            //    callbackFunction: nameof(this.Training5_AddComponentsAndMate)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第6章",
            //    callbackFunction: nameof(this.Training6)
            //    );

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

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章",
            //    callbackFunction: nameof(this.Training8_CustomProps_main)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章属性遍历",
            //    callbackFunction: nameof(this.Training8_CustomPropertyTraversal)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章属性在配置特定",
            //    callbackFunction: nameof(this.Training8_CustomPropsConfig)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章文件摘要信息",
            //    callbackFunction: nameof(this.Training8_CustomFileSummary)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章文档特性",
            //    callbackFunction: nameof(this.Training8_DocumentAttributes)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章CNCDrilling",
            //    callbackFunction: nameof(this.Training8_CNCDrilling)
            //    );

            //命令
            cmds.add(
                hintOrTip: "附录D装配体遍历",
                callbackFunction: nameof(this.AppendexD_WatchAssemblyTraversal)
                );

            //命令
            cmds.add(
                hintOrTip: "箱子",
                callbackFunction: nameof(this.Salon_tank)
                );
            //命令
            cmds.add(
                hintOrTip: "提取箱子数据",
                callbackFunction: nameof(this.Salon_tankinfo)
                );
            //命令
            cmds.add(
                hintOrTip: "批量生成箱子",
                callbackFunction: nameof(this.Asia_generate)
                );

            //命令
            cmds.add(
                hintOrTip: "批量创建参考平面",
                callbackFunction: nameof(this.Asia_createPlanes)
                );

            ////命令
            //cmds.add(
            //    hintOrTip: "插入圆柱参考配合",
            //    callbackFunction: nameof(this.圆柱配合参考)
            //    );

            //命令
            cmds.add(
                hintOrTip: "库特征",
                callbackFunction: nameof(this.库特征)
                );

            //命令
            cmds.add(
                hintOrTip: "箱罐信息",
                callbackFunction: nameof(this.箱罐信息)
                );

            //命令
            cmds.add(
                hintOrTip: "生成管嘴的配合参考",
                callbackFunction: nameof(this.generateNozzleMateRefs)
                );

            //命令
            cmds.add(
                hintOrTip: "坐标系",
                callbackFunction: nameof(this.获取坐标系)
                );

            //命令
            cmds.add(
                hintOrTip: "收集所有坐标系并生成配合参考",
                callbackFunction: nameof(this.收集所有坐标系并生成配合参考)
                );

            //命令
            cmds.add(
                hintOrTip: "在所有配置隐藏选中的特征",
                callbackFunction: nameof(this.blankSelectedFeatures)
                );

            //命令
            cmds.add(
                hintOrTip: "unblank selectecd features",
                callbackFunction: nameof(this.显示特征)
                );

            //命令
            cmds.add(
                hintOrTip: "读取文件的自定义属性",
                callbackFunction: nameof(this.readCustomProps)
                );

            //命令
            cmds.add(
                hintOrTip: "写文件的自定义属性",
                callbackFunction: nameof(this.writeCustomProps)
                );

            //命令
            cmds.add(
                hintOrTip: "添加组件并坐标系配合",
                callbackFunction: nameof(this.addManyCompToCoordSys)
                );

            //命令
            cmds.add(
                hintOrTip: "管道材料明细表",
                callbackFunction: nameof(this.pipeBom)
                );



            // 命令组
            var cmdGroup = CommandManagerUtils.createCommandGroup2(
                    userID: cmdGroupID,
                    title: "CuiShengLi",
                    toolTip: "CuiShengLi tool tip",
                    hint: "hint",
                    ignorePreviousVersion: cmds.getUserIDs().SetEquals(CommandManagerUtils.getIDsFromRegistry(cmdGroupID, this.iCmdMgr)),
                    cmdMgr: this.iCmdMgr
                );
            var callingAssy = Assembly.GetAssembly(this.GetType());
            this.iBmp = new BitmapHandler();

            cmdGroup.LargeMainIcon = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconLarge.bmp", callingAssy);
            cmdGroup.SmallMainIcon = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconSmall.bmp", callingAssy);
            cmdGroup.LargeIconList = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarLarge.bmp", callingAssy);
            cmdGroup.SmallIconList = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarSmall.bmp", callingAssy);

            cmds.update(cmdGroup);

            cmdGroup.HasMenu = true;
            cmdGroup.HasToolbar = false;
            cmdGroup.Activate();

        }

        public void RemoveCommandMgr()
        {
            this.iCmdMgr.RemoveCommandGroup(cmdGroupID);
        }


        //public void Training1()
        //{
        //    training1.exec(this.iSwApp);
        //    //iSwApp.SendMsgToUser("这是占位的命令");

        //    //trainingcylinder.main(iSwApp);

        //    //training2.cmdConnect(iSwApp);
        //    //training2.cmdNewModel_Part(iSwApp);

        //    //training4.testPartMat(iSwApp);
        //    //training4.rectangularExtrude(iSwApp);
        //    //training4.circularExtrude(iSwApp);
        //    //training4.testDrawCirc(iSwApp);
        //    //training4.testCircleContourRevolve(iSwApp);
        //    //training5.testSelectFace(this.iSwApp);

        //    //SldWorksUtils.testCutLists(iSwApp);
        //    //SldWorksUtils.detectCutLists(iSwApp);
        //    //SldWorksUtils.setPartWeldment(iSwApp);

        //}

        public void pipeBom()
        {
            //SWRoutingLibUtils.ExportPipeData(iSwApp);

            //var clss = new Library1.RecursiveTraverseAssembly(iSwApp);
            //clss.Main();

            PipeComponents.PipeUtils.main(this.iSwApp);
        }


        //public void Training2_3()
        //{
        //    training2.connectToSolidWorks(this.iSwApp);
        //}

        //public void Training2_NewModel_Part()
        //{
        //    training2.NewModel_Part(this.iSwApp);
        //}

        //public void Training2_NewModel_ASM()
        //{
        //    training2.NewModel_ASM(this.iSwApp);
        //}

        //public void Training2_NewModel_DRW()
        //{
        //    training2.NewModel_DRW(this.iSwApp);
        //}

        //public void Training2_NewPartDoc()
        //{
        //    training2.NewPartDoc(this.iSwApp);
        //}

        //public void Training2_NewAssemblyDoc()
        //{
        //    training2.NewAssemblyDoc(this.iSwApp);
        //}

        //public void Training2_NewDrawingDoc()
        //{
        //    training2.NewDrawingDoc(this.iSwApp);
        //}

        //public void Training2_existingDocs_connectToSolidWorks()
        //{
        //    training2_existingDocs.connectToSolidWorks(this.iSwApp);
        //}

        //public void Training2_existingDocs_ToolbarAndCustomProperty()
        //{
        //    training2_existingDocs.ToolbarAndCustomProperty(this.iSwApp);
        //}

        //public void Training2_existingDocs_MirrorPart()
        //{
        //    training2_existingDocs.MirrorPart(this.iSwApp);
        //}

        //public void Training2_existingDocs_InsertCavity()
        //{
        //    training2_existingDocs.InsertCavity(this.iSwApp);
        //}

        //public void Training2_existingDocs_CreateLayer()
        //{
        //    training2_existingDocs.CreateLayer(this.iSwApp);
        //}

        //public void Training3_systemOptions()
        //{
        //    training3.systemOptions(this.iSwApp);
        //}

        //public void Training3_documentProperties()
        //{
        //    training3.documentProperties(this.iSwApp);
        //}

        //public void Training4_PartMaterial()
        //{
        //    training4.PartMaterial(this.iSwApp);
        //}

        //public void Training4_rectExtrusion ()
        //{
        //    training4.rectExtrusion(this.iSwApp);
        //}

        //public void Training4_rectRevolve()
        //{
        //    training4.rectRevolve(this.iSwApp);
        //}

        //public void Training4_circleExtrusion()
        //{
        //    training4_circle.circleExtrusion(this.iSwApp);
        //}

        //public void Training4_circleRevolve()
        //{
        //    training4_circle.circleRevolve(this.iSwApp);
        //}

        //public void Training5_AddComponentsAndMate()
        //{
        //    training5.AddComponentsAndMate(this.iSwApp);
        //}

        //public void Training6()
        //{
        //    training6.main(this.iSwApp);
        //}

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

        //public void Training8_CustomProps_main()
        //{
        //    CustomProps.main(this.iSwApp);
        //}

        //public void Training8_CustomPropertyTraversal()
        //{
        //    CustomProps.CustomPropertyTraversal(this.iSwApp);
        //}

        //public void Training8_CustomPropsConfig()
        //{
        //    CustomProps.CustomPropsConfig(this.iSwApp);
        //}

        //public void Training8_CustomFileSummary()
        //{
        //    CustomFileSummary.main(this.iSwApp);
        //}

        //public void Training8_DocumentAttributes()
        //{
        //    DocumentAttributes.main(this.iSwApp);
        //}

        //public void Training8_CNCDrilling()
        //{
        //    Training8.CNCDrilling.main(this.iSwApp);
        //}

        public void AppendexD_WatchAssemblyTraversal()
        {
            WatchAssemblyTraversal.main(this.iSwApp);
        }

        public void Salon_tank()
        {
            Salon.tank(this.iSwApp);
        }
        public void Salon_tankinfo()
        {
            Salon.tankinfo(this.iSwApp);
        }
        public void Asia_generate()
        {
            Asia.generate(this.iSwApp);
        }

        public void Asia_createPlanes()
        {
            Asia.createPlanes(this.iSwApp);
        }

        //public void 圆柱配合参考()
        //{
        //    Asia.preselect(this.iSwApp);
        //}

        public void 库特征()
        {
            Asia.getLibraryFeatureData(this.iSwApp);
        }

        public void generateNozzleMateRefs()
        {
            FacesWithFeature.generateNozzleMateRefs(this.iSwApp);
        }

        public void 箱罐信息()
        {
            FacesWithFeature.tankInfo(this.iSwApp);
        }

        public void 获取坐标系()
        {
            CoordinateSystem.getAllOfCoordinateSystems(this.iSwApp);
        }

        public void 收集所有坐标系并生成配合参考()
        {
            CoordinateSystem.collectCoordSysMateRefs(this.iSwApp);
        }

        public void blankSelectedFeatures()
        {
            BlankRefGeom.blankSelectedFeatures(this.iSwApp);
        }

        public void 显示特征()
        {
            BlankRefGeom.unblankSelectedFeatures(this.iSwApp);
        }

        public void readCustomProps()
        {
            CustomPropsApp.readCustomProps(this.iSwApp);
        }

        public void writeCustomProps()
        {
            CustomPropsApp.writeCustomProps(this.iSwApp);
        }

        public void addManyCompToCoordSys()
        {
            CoordinateSystem.addManyCompToCoordSys(this.iSwApp);
        }

        public bool Always() { return true; }
    }

}
