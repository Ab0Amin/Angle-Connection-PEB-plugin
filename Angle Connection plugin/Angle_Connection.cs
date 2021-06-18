//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Angle_Connection_plugin
{
    //{{
    //    class Angle_plate
    //    {
    //    }
    //}
    // Decompiled with JetBrains decompiler
    // Type: Grating_Connection
    // Assembly: Grating_Connection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
    // MVID: A4432C2E-0C22-4137-A6FB-119A33FF0290
    // Assembly location: D:\encrypted\amin\My Tekla APP\plugin without colum trial\Grating_hole_with_toeplates\Grating_Connection\bin\Debug\Grating_Connection.dll

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tekla.Structures;
    using Tekla.Structures.Geometry3d;
    using t3d = Tekla.Structures.Geometry3d;
    using Tekla.Structures.Model;
    using Tekla.Structures.Model.Operations;
    using Tekla.Structures.Model.UI;
    using Tekla.Structures.Plugins;
    using Tekla.Structures.Solid;
    using System.Windows.Forms;
    using System.Linq;

    [Plugin("Angle_Connection")]
    [PluginUserInterface(UserInterfaceDefinition.Plugin3)]



    public class StructuresData3
    {


      [StructuresField("plateLength_Z")]
        public double plateLength_Z ;
        [StructuresField("plateLength_Y")]
        public double plateLength_Y ;

        [StructuresField("plateWidth")]
        public double plateWidth;
        [StructuresField("platethick")]
        public double platethick;
        [StructuresField("polyBeam_material")]
        public string polyBeam_material;
      
        [StructuresField("polyBeam_name")]
        public string polyBeam_name;
        [StructuresField("polyBeam_perfix")]
        public string polyBeam_perfix;
        [StructuresField("polyBeam_startNO")]
        public int polyBeam_startNO;

        [StructuresField("polyBeam_chanfer_x")]
        public double polyBeam_chanfer_x;

        [StructuresField("polyBeam_chanfer_y")]
        public double polyBeam_chanfer_y;

        [StructuresField("polybeam_weldWithMain")]
        public double polybeam_weldWithMain;
        [StructuresField("polybeam_weldWithSec")]
        public double polybeam_weldWithSec;


        [StructuresField("Connection_shift")]
        public double Connection_shift;
        [StructuresField("stiffner_thik")]
        public double stiffner_thik;
        [StructuresField("stiffner_material")]
        public string stiffner_material;
        [StructuresField("stiff_name")]
        public string stiff_name;
        [StructuresField("stiff_perfix")]
        public string stiff_perfix;

        [StructuresField("stiff_sttartNo")]
        public int stiff_sttartNo;
        [StructuresField("l1")]
        public double l1;
        [StructuresField("l2")]
        public double l2;
        [StructuresField("h1")]
        public double h1;
        [StructuresField("h2")]
        public double h2;

        [StructuresField("stiff_chanfer_x")]
        public double stiff_chanfer_x;
        [StructuresField("stiff_chanfer_y")]
        public double stiff_chanfer_y;

        [StructuresField("NO_ofStiffner ")]
        public int NO_ofStiffner;
        [StructuresField("Spacing_stiffners ")]
        public double Spacing_stiffners;
       
        [StructuresField("stiff_shift ")]
        public double stiff_shift;
        
        [StructuresField("stiff_weldAbove_X")]
        public double stiff_weldAbove_X;
        [StructuresField("stiff_weldBelow_X")]
        public double stiff_weldBelow_X;
       
        [StructuresField("stiff_weldAbove_Y")]
        public double stiff_weldAbove_Y;
        [StructuresField("stiff_weldBelow_Y")]
        public double stiff_weldBelow_Y;

        [StructuresField("weld_above_1_type")]
        public int weld_above_1_type;
        [StructuresField("weld_above_2_type")]
        public int weld_above_2_type;

        [StructuresField("weld_below_1_type")]
        public int weld_below_1_type;
        [StructuresField("weld_below_2_type")]
        public int weld_below_2_type;

        [StructuresField("weld_angle_above_1")]
        public double weld_angle_above_1;
        [StructuresField("weld_angle_above_2")]
        public double weld_angle_above_2;
        
        [StructuresField("weld_angle_below_1")]
        public double weld_angle_below_1;
        [StructuresField("weld_angle_below_2")]
        public double weld_angle_below_2;
      
        [StructuresField("weld_root_above_1")]
        public double weld_root_above_1;
        [StructuresField("weld_root_above_2")]
        public double weld_root_above_2;
        [StructuresField("weld_root_below_1")]
        public double weld_root_below_1;
        [StructuresField("weld_root_below_2")]
        public double weld_root_below_2;
       
        [StructuresField("weld_throat_above_1")]
        public double weld_throat_above_1;
        [StructuresField("weld_throat_above_2")]
        public double weld_throat_above_2;
        [StructuresField("weld_throat_below_1")]
        public double weld_throat_below_1;
        [StructuresField("weld_throat_below_2")]
        public double weld_throat_below_2;

        [StructuresField("weld_contour_above_1")]
        public int weld_contour_above_1 ;
        [StructuresField("weld_contour_above_2")]
        public int weld_contour_above_2;
        [StructuresField("weld_contour_below_1")]
        public int weld_contour_below_1;
        [StructuresField("weld_contour_below_2")]
        public int weld_contour_below_2;



        [StructuresField("weld_shopOrSite_1")]
        public int weld_shopOrSite_1;
        [StructuresField("weld_shopOrSite_2")]
        public int weld_shopOrSite_2;
        [StructuresField("weld_comment_1")]
        public string weld_comment_1;
        [StructuresField("weld_comment_2")]
        public string weld_comment_2;


        [StructuresField("dx_Boltedge_main")]
        public double dx_Boltedge_main;
        [StructuresField("X_spacing_main")]
        public string X_spacing_main;
        [StructuresField("Y_spacing_main")]
        public string Y_spacing_main;
        [StructuresField("boltSize_main")]
        public double boltSize_main;


        [StructuresField("tolerance_main")]
        public double tolerance_main;
        [StructuresField("boltStandard_main")]
        public string boltStandard_main;
        [StructuresField("NO_ofBolts_X_main")]
        public int NO_ofBolts_X_main;
        [StructuresField("NO_ofBolts_Y_main")]
        public int NO_ofBolts_Y_main;

        [StructuresField("dx_Boltedge_sec")]
        public double dx_Boltedge_sec;
        [StructuresField("X_spacing_sec")]
        public string X_spacing_sec;
        [StructuresField("Y_spacing_sec")]
        public string Y_spacing_sec;
        [StructuresField("boltSize_sec")]
        public double boltSize_sec;



        [StructuresField("tolerance_sec")]
        public double tolerance_sec;
        [StructuresField("boltStandard_sec")]
        public string boltStandard_sec;
        [StructuresField("NO_ofBolts_X_sec")]
        public int NO_ofBolts_X_sec;
        [StructuresField("NO_ofBolts_Y_sec")]
        public int NO_ofBolts_Y_sec;

        [StructuresField("slotX_1")]
        public double slotX_1;
        [StructuresField("slotY_1")]
        public double slotY_1;

        [StructuresField("slotX_2")]
        public double slotX_2;
        [StructuresField("slotY_2")]
        public double slotY_2;


        [StructuresField("bolt_shift_1")]
        public double bolt_shift_1;
        [StructuresField("bolt_shift_2")]
        public double bolt_shift_2;

        [StructuresField("cb_weldedBolt_1")]
        public int cb_weldedBolt_1;
        [StructuresField("cb_weldedBolt_2")]
        public int cb_weldedBolt_2;
        [StructuresField("cb_sloted_1")]
        public int cb_sloted_1;
        [StructuresField("cb_solted_2")]
        public int cb_solted_2;

        [StructuresField("cm_washerNo_1")]
        public int cm_washerNo_1;
        [StructuresField("cm_washerNo_2")]
        public int cm_washerNo_2;
        [StructuresField("cm_nutNo_1")]
        public int cm_nutNo_1;
        [StructuresField("cm_nutNo_2")]
        public int cm_nutNo_2;

        [StructuresField("cb_workshop_1")]
        public int cb_workshop_1;
        [StructuresField("cb_workshop_2")]
        public int cb_workshop_2;
        [StructuresField("boltEdge2_x_1")]
        public double boltEdge2_x_1;
        [StructuresField("boltEdge2_x_2")]
        public double boltEdge2_x_2;

        [StructuresField("cb_location")]
        public int cb_location;
        [StructuresField("cb_polybeamChanfer")]
        public int cb_polybeamChanfer;
        [StructuresField("cb_stiffChanfer")]
        public int cb_stiffChanfer;

        

    }

  
    public class Angle_Connection : PluginBase
    {
        private readonly StructuresData3 data;
        private readonly Tekla.Structures.Model.Model myModel;

        public Angle_Connection(StructuresData3 data)
        {
            this.data = data;
            this.myModel = new Tekla.Structures.Model.Model();
        }

        public override List<PluginBase.InputDefinition> DefineInput()
        {
            List<PluginBase.InputDefinition> inputDefinitionList = new List<PluginBase.InputDefinition>();
            Picker picker = new Picker();
            Part mainPart = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick Main Part") as Part;
            Part secendaryPart = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick Main Part") as Part;
                
            PluginBase.InputDefinition inputDefinition1 = new PluginBase.InputDefinition(mainPart.Identifier);
            PluginBase.InputDefinition inputDefinition2 = new PluginBase.InputDefinition(secendaryPart.Identifier);
            inputDefinitionList.Add(inputDefinition1);
            inputDefinitionList.Add(inputDefinition2);
            return inputDefinitionList;
        }

        public override bool Run(List<PluginBase.InputDefinition> Input)
        {
            try
            {
                #region defults
                //plate
                if (this.IsDefaultValue(this.data.plateLength_Z))
                    this.data.plateLength_Z = 150;
                if (this.IsDefaultValue(this.data.plateLength_Y))
                    this.data.plateLength_Y = 150;
                if (this.IsDefaultValue(this.data.plateWidth))
                    this.data.plateWidth = 150;
                if (this.IsDefaultValue(this.data.platethick))
                    this.data.platethick = 4;
                if (this.IsDefaultValue(this.data.polyBeam_material))
                    this.data.polyBeam_material = "A572 GR-50";
                if (this.IsDefaultValue(this.data.polyBeam_name))
                    this.data.polyBeam_name = "CLIP";
                if (this.IsDefaultValue(this.data.polyBeam_perfix))
                    this.data.polyBeam_perfix = "W";
                if (this.IsDefaultValue(this.data.polyBeam_startNO))
                    this.data.polyBeam_startNO = 101;
                if (this.IsDefaultValue(this.data.polyBeam_chanfer_x))
                    this.data.polyBeam_chanfer_x = 10;
                if (this.IsDefaultValue(this.data.polyBeam_chanfer_y))
                    this.data.polyBeam_chanfer_y = 10;
                if (this.IsDefaultValue(this.data.polybeam_weldWithMain))
                    this.data.polybeam_weldWithMain = 6;
                if (this.IsDefaultValue(this.data.polybeam_weldWithSec))
                    this.data.polybeam_weldWithSec = 6;
                if (this.IsDefaultValue(this.data.cb_polybeamChanfer))
                    this.data.cb_polybeamChanfer = 1;

                
             //connection
                if (this.IsDefaultValue(this.data.Connection_shift))
                    this.data.Connection_shift = 0;
               //stiffner
                if (this.IsDefaultValue(this.data.stiffner_thik))
                    this.data.stiffner_thik = 4;
                if (this.IsDefaultValue(this.data.stiffner_material))
                    this.data.stiffner_material = "A572 GR-50";
                if (this.IsDefaultValue(this.data.stiff_name))
                    this.data.stiff_name = "Plate";
                if (this.IsDefaultValue(this.data.stiff_perfix))
                    this.data.stiff_perfix = "W";
                if (this.IsDefaultValue(this.data.stiff_sttartNo))
                    this.data.stiff_sttartNo = 101;
                if (this.IsDefaultValue(this.data.l1))
                    this.data.l1 = 145;
                if (this.IsDefaultValue(this.data.l2))
                    this.data.l2 = 145;
                if (this.IsDefaultValue(this.data.h1))
                    this.data.h1 = 30.0;
                if (this.IsDefaultValue(this.data.h2))
                    this.data.h2 = 30.0;
                if (this.IsDefaultValue(this.data.stiff_chanfer_x))
                    this.data.stiff_chanfer_x = 15;
                if (this.IsDefaultValue(this.data.stiff_chanfer_y))
                    this.data.stiff_chanfer_y = 15;
                if (this.IsDefaultValue(this.data.NO_ofStiffner))
                    this.data.NO_ofStiffner = 1;
                if (this.IsDefaultValue(this.data.Spacing_stiffners))
                    this.data.Spacing_stiffners = 0;
                if (this.IsDefaultValue(this.data.stiff_shift))
                    this.data.stiff_shift = 0;
                if (this.IsDefaultValue(this.data.cb_stiffChanfer))
                    this.data.cb_stiffChanfer = 1;

                // weld
                if (this.IsDefaultValue(this.data.stiff_weldAbove_X))
                    this.data.stiff_weldAbove_X = 6;
                if (this.IsDefaultValue(this.data.stiff_weldBelow_X))
                    this.data.stiff_weldBelow_X = 6;
                if (this.IsDefaultValue(this.data.stiff_weldAbove_Y))
                    this.data.stiff_weldAbove_Y = 6;
                if (this.IsDefaultValue(this.data.stiff_weldBelow_Y))
                    this.data.stiff_weldBelow_Y = 6;
                if (this.IsDefaultValue(this.data.weld_above_1_type))
                    this.data.weld_above_1_type = 0;
                if (this.IsDefaultValue(this.data.weld_above_2_type))
                    this.data.weld_above_2_type = 0;
                if (this.IsDefaultValue(this.data.weld_below_1_type))
                    this.data.weld_below_1_type = 0;
                if (this.IsDefaultValue(this.data.weld_below_2_type))
                    this.data.weld_below_2_type = 0;
                if (this.IsDefaultValue(this.data.weld_angle_above_1))
                    this.data.weld_angle_above_1 = 0;
                if (this.IsDefaultValue(this.data.weld_angle_above_2))
                    this.data.weld_angle_above_2 = 0;
                if (this.IsDefaultValue(this.data.weld_angle_below_1))
                    this.data.weld_angle_below_1 = 0;
                if (this.IsDefaultValue(this.data.weld_angle_below_2))
                    this.data.weld_angle_below_2 = 0;
                if (this.IsDefaultValue(this.data.weld_root_above_1))
                    this.data.weld_root_above_1 = 0;
                if (this.IsDefaultValue(this.data.weld_root_above_2))
                    this.data.weld_root_above_2 = 0;
                if (this.IsDefaultValue(this.data.weld_root_below_1))
                    this.data.weld_root_below_1 = 0;
                if (this.IsDefaultValue(this.data.weld_root_below_2))
                    this.data.weld_root_below_2 = 0;
                if (this.IsDefaultValue(this.data.weld_throat_above_1))
                    this.data.weld_throat_above_1 =0;
                if (this.IsDefaultValue(this.data.weld_throat_above_2))
                    this.data.weld_throat_above_2 = 0;
                if (this.IsDefaultValue(this.data.weld_throat_below_1))
                    this.data.weld_throat_below_1 = 0;
                if (this.IsDefaultValue(this.data.weld_throat_below_2))
                    this.data.weld_throat_below_2 = 0;
                if (this.IsDefaultValue(this.data.weld_contour_above_1))
                    this.data.weld_contour_above_1 = 0;
                if (this.IsDefaultValue(this.data.weld_contour_above_2))
                    this.data.weld_contour_above_2 = 0;
                if (this.IsDefaultValue(this.data.weld_contour_below_1))
                    this.data.weld_contour_below_1 = 0;
                if (this.IsDefaultValue(this.data.weld_contour_below_2))
                    this.data.weld_contour_below_2 = 0;
                if (this.IsDefaultValue(this.data.weld_shopOrSite_1))
                    this.data.weld_shopOrSite_1 = 0;
                if (this.IsDefaultValue(this.data.weld_shopOrSite_2))
                    this.data.weld_shopOrSite_2 = 0;
                if (this.IsDefaultValue(this.data.weld_comment_1))
                    this.data.weld_comment_1 = null;
                if (this.IsDefaultValue(this.data.weld_comment_2))
                    this.data.weld_comment_2 = null;
               //bolts
                if (this.IsDefaultValue(this.data.dx_Boltedge_main))
                    this.data.dx_Boltedge_main = 30.0;
                if (this.IsDefaultValue(this.data.X_spacing_main))
                    this.data.X_spacing_main = "50";
                if (this.IsDefaultValue(this.data.Y_spacing_main))
                    this.data.Y_spacing_main = "50";
                if (this.IsDefaultValue(this.data.boltSize_main))
                    this.data.boltSize_main = 10;
                if (this.IsDefaultValue(this.data.tolerance_main))
                    this.data.tolerance_main = 2;
                if (this.IsDefaultValue(this.data.boltStandard_main))
                    this.data.boltStandard_main = "MSB";
                if (this.IsDefaultValue(this.data.NO_ofBolts_X_main))
                    this.data.NO_ofBolts_X_main = 2;
                if (this.IsDefaultValue(this.data.NO_ofBolts_Y_main))
                    this.data.NO_ofBolts_Y_main = 2;
                if (this.IsDefaultValue(this.data.dx_Boltedge_sec))
                    this.data.dx_Boltedge_sec = 30.0;
                if (this.IsDefaultValue(this.data.X_spacing_sec))
                    this.data.X_spacing_sec = "50";
                if (this.IsDefaultValue(this.data.Y_spacing_sec))
                    this.data.Y_spacing_sec = "50";
                if (this.IsDefaultValue(this.data.boltSize_sec))
                    this.data.boltSize_sec = 10;
                if (this.IsDefaultValue(this.data.tolerance_sec))
                    this.data.tolerance_sec = 2;
                if (this.IsDefaultValue(this.data.boltStandard_sec))
                    this.data.boltStandard_sec = "MSB";
                if (this.IsDefaultValue(this.data.NO_ofBolts_X_sec))
                    this.data.NO_ofBolts_X_sec = 2;
                if (this.IsDefaultValue(this.data.NO_ofBolts_Y_sec))
                    this.data.NO_ofBolts_Y_sec = 2;
                if (this.IsDefaultValue(this.data.slotX_1))
                    this.data.slotX_1 = 0;
                if (this.IsDefaultValue(this.data.slotY_1))
                    this.data.slotY_1 = 0;
                if (this.IsDefaultValue(this.data.slotX_2))
                    this.data.slotX_2 = 0;
                if (this.IsDefaultValue(this.data.slotY_2))
                    this.data.slotY_2 = 0;
                if (this.IsDefaultValue(this.data.bolt_shift_1))
                    this.data.bolt_shift_1 = 0;
                if (this.IsDefaultValue(this.data.bolt_shift_2))
                    this.data.bolt_shift_2 = 0;
                if (this.IsDefaultValue(this.data.cb_weldedBolt_1))
                    this.data.cb_weldedBolt_1 = 0;
                if (this.IsDefaultValue(this.data.cb_weldedBolt_2))
                    this.data.cb_weldedBolt_2 = 0;
                if (this.IsDefaultValue(this.data.cb_sloted_1))
                    this.data.cb_sloted_1 = 0;
                if (this.IsDefaultValue(this.data.cb_solted_2))
                    this.data.cb_solted_2 = 0;
                if (this.IsDefaultValue(this.data.cm_washerNo_1))
                    this.data.cm_washerNo_1 = 0;
                if (this.IsDefaultValue(this.data.cm_washerNo_2))
                    this.data.cm_washerNo_2 = 0;
                if (this.IsDefaultValue(this.data.cm_nutNo_1))
                    this.data.cm_nutNo_1 = 0;
                if (this.IsDefaultValue(this.data.cm_nutNo_2))
                    this.data.cm_nutNo_2 = 0;
                if (this.IsDefaultValue(this.data.cb_workshop_1))
                    this.data.cb_workshop_1 = 0;
                if (this.IsDefaultValue(this.data.cb_workshop_2))
                    this.data.cb_workshop_2 = 0;
                if (this.IsDefaultValue(this.data.boltEdge2_x_1))
                    this.data.boltEdge2_x_1 = 30;
                if (this.IsDefaultValue(this.data.boltEdge2_x_2))
                    this.data.boltEdge2_x_2 = 30;
                if (this.IsDefaultValue(this.data.cb_location))
                    this.data.cb_location = 30;
               

                
                #endregion
                this.createconnection((Part)this.myModel.SelectModelObject((Identifier)Input[0].GetInput()), (Part)this.myModel.SelectModelObject((Identifier)Input[1].GetInput()));

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
            return true;
        }

        public void createconnection(Part mainPart, Part secendaryPart)
        {
            BoltArray.BoltTypeEnum boltType_1 = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;
            BoltArray.BoltTypeEnum boltType_2 = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;

            bool slotMainPart_1 = false;
            bool slotSecPart_1 = false;
            bool washer2_1 = false;
            bool nut2_1 = false;
            bool slotMainPart_2 = false;
            bool slotSecPart_2 = false;
            bool washer2_2 = false;
            bool nut2_2 = false;
// calculate polybeam widtth
            double sum_1 = 0;
            string[] spacing_X_array_1 = data.X_spacing_main.Split(' ');
            for (int i = 0; i < data.NO_ofBolts_X_main - 1; i++)
            {
                sum_1 = sum_1 + double.Parse(spacing_X_array_1[i]);
            }
            sum_1 = sum_1 + data.boltEdge2_x_1 + data.dx_Boltedge_main;


            double sum_2 = 0;
            string[] spacing_X_array_2 =data.X_spacing_sec.Split(' ');
            for (int i = 0; i < data.NO_ofBolts_X_sec - 1; i++)
            {
                sum_2 = sum_2 + double.Parse(spacing_X_array_2[i]);
            }
            sum_2 = sum_2 + data.dx_Boltedge_sec + data.boltEdge2_x_2;

            double plateLength_Z = sum_1;
            double plateLength_Y = sum_2;


            // code




            // get transformation plane cuurent to return it after we finished and secandry beam plane to use it
            TransformationPlane currentPlan = myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            TransformationPlane transformationPlane = new TransformationPlane(secendaryPart.GetCoordinateSystem());

            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(transformationPlane);

            // get centerline points for secandery part
            ArrayList centerPointsSecndaryPart = secendaryPart.GetCenterLine(false);
            t3d.Point point1CenterSecndary = centerPointsSecndaryPart[0] as t3d.Point;
            t3d.Point point2CenterSecendary = centerPointsSecndaryPart[1] as t3d.Point;
            // get centerline point to main part 
            ArrayList centerPointsMainPart = mainPart.GetCenterLine(false);
            t3d.Point point1CenterMain = centerPointsMainPart[0] as t3d.Point;
            t3d.Point point2CenterMain = centerPointsMainPart[1] as t3d.Point;

            // create line from secandry part to check if it is connected to column or beam
            LineSegment centerLineSecandryPart = new LineSegment(new t3d.Point(point1CenterSecndary.X - 5000, point1CenterSecndary.Y, point1CenterSecndary.Z), new t3d.Point(point2CenterSecendary.X + 5000, point2CenterSecendary.Y, point2CenterSecendary.Z));

            Solid mainSolid = mainPart.GetSolid();

            // get distance from center to main part
            double thicknessOfMainPart = 0;
            mainPart.GetReportProperty("WIDTH", ref thicknessOfMainPart);

            double thicknessOfSecPart = 0;
            secendaryPart.GetReportProperty("WIDTH", ref thicknessOfSecPart);

            int direction = BeamDirection(secendaryPart);
            #region case clumn to beam
            if (mainSolid.Intersect(centerLineSecandryPart).Count == 0)
            {
                #region case beam c profie
                {
                    // get max and min points for secandry part to detect its direction
                    Solid secSolid = secendaryPart.GetSolid();

                    t3d.Point MaxSecndaryPoint = secSolid.MaximumPoint;
                    t3d.Point MinSecndaryPoint = secSolid.MinimumPoint;

                    t3d.Point point1_max = transformationPlane.TransformationMatrixToGlobal.Transform(MaxSecndaryPoint);
                    t3d.Point point2_min = transformationPlane.TransformationMatrixToGlobal.Transform(MinSecndaryPoint);

                    t3d.Point MidSecndaryPoint = getmidpoint(point1CenterSecndary, point2CenterSecendary);
                    //  double z_Point = MaxSecndaryPoint.Z;
                    double z_dirFactor = 1;

                    if (direction == 0)
                    {
                        
                        data.cb_location = 0;
                        if (point1_max.Z > point2_min.Z)
                        {
                            // z_Point = MaxSecndaryPoint.Z;
                            z_dirFactor = 1;
                        }
                        else if (point1_max.Z < point2_min.Z)
                        {
                            //  z_Point = MinSecndaryPoint.Z;
                            z_dirFactor = -1;

                        }
                    }
                    else if (direction == 1)
                    {
                        data.cb_location = 1;
                        if (point1_max.Z < point2_min.Z)
                        {
                            //    z_Point = MaxSecndaryPoint.Z;
                            z_dirFactor = 1;
                        }
                        else if (point1_max.Z > point2_min.Z)
                        {
                            //  z_Point = MinSecndaryPoint.Z;
                            z_dirFactor = -1;

                        }
                    }

                    double x_Point = MidSecndaryPoint.X + data.Connection_shift;
                    double y_Point = MidSecndaryPoint.Y;

                    double z_Point = MidSecndaryPoint.Z + thicknessOfSecPart * z_dirFactor / 2;

                    double factor = 1;


                    if (point1CenterMain.Y > 0)
                    {
                        factor = -1;

                    }

                    // get mid point of the polyplates
                    t3d.Point TemPlateMidPoint = new Point(x_Point, y_Point, z_Point);

                    t3d.Point lineForGetMidPoint1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y + 10000, TemPlateMidPoint.Z);
                    t3d.Point lineForGetMidPoint2 = new Point(x_Point, y_Point - 10000, z_Point);

                    t3d.Point lineForGetEndPoint1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y + 10000, TemPlateMidPoint.Z + plateLength_Z * z_dirFactor);
                    t3d.Point lineForGetEndPoint2 = new Point(x_Point, y_Point - 10000, z_Point + plateLength_Z * z_dirFactor);


                    t3d.Point planeOrgin = new t3d.Point(point1CenterMain.X, point1CenterMain.Y + thicknessOfMainPart * factor / 2, point1CenterMain.Z);

                    LineSegment line1 = new LineSegment(lineForGetMidPoint1, lineForGetMidPoint2);
                    LineSegment line2 = new LineSegment(lineForGetEndPoint1, lineForGetEndPoint2);




                    t3d.Point lineForstiffner1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y + 10000, TemPlateMidPoint.Z + data.l2 * z_dirFactor);
                    t3d.Point lineForstiffner2 = new Point(x_Point, y_Point - 10000, z_Point + data.l2 * z_dirFactor);
                    LineSegment lineStiffner = new LineSegment(lineForstiffner1, lineForstiffner2);


                    GeometricPlane mainPartPlane = new GeometricPlane(planeOrgin, mainPart.GetCoordinateSystem().AxisX, mainPart.GetCoordinateSystem().AxisY);

                    t3d.Point plateMidPoint = Intersection.LineSegmentToPlane(line1, mainPartPlane);
                    t3d.Point platePoint1 = Intersection.LineSegmentToPlane(line2, mainPartPlane);
                    t3d.Point platePoint3 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + plateLength_Y * factor, plateMidPoint.Z);

                    //check_with_beam(plateMidPoint, platePoint1);
                    //check_with_beam(plateMidPoint, platePoint3);

                    // stiffner points
                    t3d.Point stiffnerPoint0 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + data.platethick * factor, plateMidPoint.Z + data.platethick * z_dirFactor);
                    t3d.Point stiffnerPoint1 = Intersection.LineSegmentToPlane(lineStiffner, mainPartPlane);
                    stiffnerPoint1 = new t3d.Point(stiffnerPoint1.X, stiffnerPoint1.Y + data.platethick * factor, stiffnerPoint1.Z + data.platethick * z_dirFactor);
                    t3d.Point stiffnerPoint2 = new t3d.Point(stiffnerPoint1.X, stiffnerPoint1.Y + data.h2 * factor, stiffnerPoint1.Z);
                    t3d.Point stiffnerPoint3 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + (data.platethick + data.l1) * factor, plateMidPoint.Z + data.platethick * z_dirFactor + data.h1 * z_dirFactor);
                    t3d.Point stiffnerPoint4 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + (data.platethick + data.l1) * factor, plateMidPoint.Z + data.platethick * z_dirFactor);


                    //trancfer points to plate plane

                    Vector vector1 = new Vector(-plateMidPoint.X + platePoint1.X, -plateMidPoint.Y + platePoint1.Y, -plateMidPoint.Z + platePoint1.Z);
                    Vector vector2 = new Vector(platePoint3.X - plateMidPoint.X, platePoint3.Y - plateMidPoint.Y, platePoint3.Z - plateMidPoint.Z);
                    TransformationPlane platePlane = new TransformationPlane(platePoint1, vector1, vector2);
                    myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(platePlane);

                    platePoint1 = platePlane.TransformationMatrixToLocal.Transform(
                        transformationPlane.TransformationMatrixToGlobal.Transform(platePoint1));

                    platePoint3 = platePlane.TransformationMatrixToLocal.Transform(
                            transformationPlane.TransformationMatrixToGlobal.Transform(platePoint3));

                    plateMidPoint = platePlane.TransformationMatrixToLocal.Transform(
                           transformationPlane.TransformationMatrixToGlobal.Transform(plateMidPoint));

                    stiffnerPoint0 = platePlane.TransformationMatrixToLocal.Transform(
                          transformationPlane.TransformationMatrixToGlobal.Transform(stiffnerPoint0));

                    stiffnerPoint1 = platePlane.TransformationMatrixToLocal.Transform(
                         transformationPlane.TransformationMatrixToGlobal.Transform(stiffnerPoint1));

                    stiffnerPoint2 = platePlane.TransformationMatrixToLocal.Transform(
                         transformationPlane.TransformationMatrixToGlobal.Transform(stiffnerPoint2));

                    stiffnerPoint3 = platePlane.TransformationMatrixToLocal.Transform(
                         transformationPlane.TransformationMatrixToGlobal.Transform(stiffnerPoint3));

                    stiffnerPoint4 = platePlane.TransformationMatrixToLocal.Transform(
                         transformationPlane.TransformationMatrixToGlobal.Transform(stiffnerPoint4));


                    //plate chamfer

                    Chamfer polyBeam_chanfetType = new Chamfer();
                    if (data.cb_polybeamChanfer == 0)
                    {
                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_LINE; ;

                    }
                    else if (data.cb_polybeamChanfer == 1)
                    {
                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_ROUNDING;

                    }
                    else
                    {

                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_NONE;

                    }
                    polyBeam_chanfetType.X = data.polyBeam_chanfer_x;
                    polyBeam_chanfetType.Y = data.polyBeam_chanfer_y;

                    PolyBeam plate = insertPolyPlate(data.plateWidth, data.platethick, platePoint1, plateMidPoint, platePoint3, data.polyBeam_material, data.polyBeam_name, data.polyBeam_perfix, data.polyBeam_startNO, polyBeam_chanfetType);

                    // bolts

                    if (data.cb_sloted_1 == 1)
                    {
                        slotMainPart_1 = true;
                    }
                    else if (data.cb_sloted_1 == 2)
                    {
                        slotSecPart_1 = true;
                    }

                    if (data.cb_solted_2 == 2)
                    {
                        slotMainPart_2 = true;
                    }
                    else if (data.cb_solted_2 == 1)
                    { 
                    
                        slotSecPart_2 = true;
                    }

                    if (data.cm_washerNo_1 == 1)
                    {
                        washer2_1 = true;
                    }
                    if (data.cm_washerNo_2 == 1)
                    {
                        washer2_2 = true;
                    }
                    if (data.cm_nutNo_1 == 1)
                    {
                        nut2_1 = true;
                    }
                    if (data.cm_nutNo_1 == 1)
                    {
                        nut2_2 = true;
                    }

                    if (data.cb_workshop_1 == 1)
                    {
                        boltType_1 = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
                    }

                    if (data.cb_workshop_2 == 1)
                    {
                        boltType_2 = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
                    }



       
                    if (data.cb_weldedBolt_1 == 0)
                    {

                        BoltArray boltWithMain = InsertBolt(platePoint1, plateMidPoint, mainPart, plate, data.dx_Boltedge_main, data.boltSize_main,
                            data.tolerance_main, data.boltStandard_main, data.NO_ofBolts_X_main, data.NO_ofBolts_Y_main, data.X_spacing_main, data.Y_spacing_main
                            , boltType_1, slotMainPart_1, slotSecPart_1, data.slotX_1, data.slotY_1, washer2_1, nut2_1, data.bolt_shift_1
);
                    }
                    else
                    {
                        insert_weld_allaround(mainPart, plate, data.polybeam_weldWithMain);
                    }


                    if (data.cb_weldedBolt_2 == 0)
                    {

                        BoltArray boltWithSec = InsertBolt(platePoint3, plateMidPoint, secendaryPart, plate, data.dx_Boltedge_sec, data.boltSize_sec,
                            data.tolerance_sec, data.boltStandard_sec, data.NO_ofBolts_X_sec, data.NO_ofBolts_Y_sec, data.X_spacing_sec, data.Y_spacing_sec
                            , boltType_2, slotMainPart_2, slotSecPart_2, data.slotX_2, data.slotY_2, washer2_2, nut2_2, data.bolt_shift_2
            );
                    }
                    else
                    {
                        insert_weld_allaround(secendaryPart, plate, data.polybeam_weldWithMain);
                    }




                    Chamfer stiff_chanfetType = new Chamfer();
                    if (data.cb_stiffChanfer == 0)
                    {
                        stiff_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_LINE; ;

                    }
                    else if (data.cb_stiffChanfer == 1)
                    {
                        stiff_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_ARC;

                    }
                    else
                    {

                        stiff_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_NONE;

                    }



                    stiff_chanfetType.X = data.stiff_chanfer_x;
                    stiff_chanfetType.Y = data.stiff_chanfer_y;
                    ContourPlate stiffner = new ContourPlate();
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint0, stiff_chanfetType));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint1, null));
                    //  stiffner.AddContourPoint(new ContourPoint(stiffnerPoint2, null));
                    // stiffner.AddContourPoint(new ContourPoint(stiffnerPoint3, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint4, null));
                    stiffner.Position.Depth = Position.DepthEnum.MIDDLE;
                    stiffner.Profile.ProfileString = "PL" + data.stiffner_thik;
                    stiffner.Material.MaterialString = data.stiffner_material;
                    stiffner.Name = data.stiff_name;
                    stiffner.PartNumber.StartNumber = data.stiff_sttartNo;
                    stiffner.PartNumber.Prefix = data.stiff_perfix;
                    stiffner.Insert();

                    //weld stiff to polybem
                    //insert_weld(plate, stiffner, stiff_weldAbove_X, stiff_weldBelow_X, new Vector(-1, 0, 0));
                    //insert_weld(plate, stiffner, stiff_weldAbove_Y, stiff_weldBelow_Y, new Vector(0, -1, 0));

                    Weld(plate, stiffner, data.stiff_weldAbove_X, data.stiff_weldBelow_X, data.weld_above_1_type, data.weld_below_1_type, data.weld_angle_above_1, data.weld_angle_below_1, 
                        data.weld_root_above_1, data.weld_root_below_1,
                        data.weld_throat_above_1, data.weld_throat_below_1, data.weld_shopOrSite_1, "-x", data.weld_comment_1, data.weld_contour_above_1, data.weld_contour_below_1);


                    groovebetween2points(stiffner, data.stiffner_thik, stiffnerPoint0, stiffnerPoint4, new t3d.Vector(0, 0, 1), new t3d.Vector(1, 0, 0), getmidpoint(stiffnerPoint0, stiffnerPoint4),
                      data.stiff_weldAbove_X, data.stiff_weldBelow_X, data.weld_above_1_type, data.weld_below_1_type, data.weld_angle_above_1, data.weld_angle_below_1, 5);




                    Weld(plate, stiffner, data.stiff_weldAbove_Y, data.stiff_weldBelow_Y, data.weld_above_2_type, data.weld_below_2_type, data.weld_angle_above_2,
                        data.weld_angle_below_2, data.weld_root_above_2, data.weld_angle_below_2,
                      data.weld_throat_above_2, data.weld_throat_below_2, data.weld_shopOrSite_2, "-y", data.weld_comment_2, data.weld_contour_above_2, data.weld_contour_below_2);

                    groovebetween2points(stiffner, data.stiffner_thik, stiffnerPoint0, stiffnerPoint1, new t3d.Vector(0, 0, 1), new t3d.Vector(0, 1, 0), getmidpoint(stiffnerPoint0, stiffnerPoint1),
                    data.stiff_weldAbove_Y, data.stiff_weldBelow_Y, data.weld_above_2_type, data.weld_below_2_type, data.weld_angle_above_2, data.weld_angle_below_2, 5);


                    // move stiffner

                    Operation.MoveObject(stiffner, new Vector(0, 0, data.stiff_shift));

                    // copy stiffners
                    if (data.NO_ofStiffner > 1)
                    {

                        double rest = data.NO_ofStiffner % 2;
                        if (rest == 0)
                        {
                            Part stiff1 = (Part)Operation.CopyObject(stiffner, new Vector(0, 0, data.Spacing_stiffners / 2));
                            Part stiff2 = (Part)Operation.CopyObject(stiffner, new Vector(0, 0, -data.Spacing_stiffners / 2));
                            double rest_NO_ofStiffner = (data.NO_ofStiffner - 2) / 2;
                            for (int i = 0; i < rest_NO_ofStiffner; i++)
                            {
                                Operation.CopyObject(stiff1, new Vector(0, 0, data.Spacing_stiffners));
                                Operation.CopyObject(stiff2, new Vector(0, 0, -data.Spacing_stiffners));
                                stiffner.Delete();
                            }
                        }
                        else
                        {
                            int rest_NO_ofStiffner = (data.NO_ofStiffner / 2);
                            for (int i = 0; i < rest_NO_ofStiffner; i++)
                            {
                                Operation.CopyObject(stiffner, new Vector(0, 0, data.Spacing_stiffners));
                                Operation.CopyObject(stiffner, new Vector(0, 0, -data.Spacing_stiffners));

                            }
                        }
                    }



                    // compoboxes


                }
                #endregion



            }


            #endregion



            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlan);
            myModel.CommitChanges();

        }







        private void createBevel(Part cuttedpart, t3d.Point p1, t3d.Point p2, t3d.Point p3, string profile)
        {
            ContourPlate contourPlate = new ContourPlate();
            contourPlate.Class = BooleanPart.BooleanOperativeClassName;
            contourPlate.Profile.ProfileString = profile;
            contourPlate.Contour.AddContourPoint(new ContourPoint(p1, new Chamfer()));
            contourPlate.Contour.AddContourPoint(new ContourPoint(p2, new Chamfer()));
            contourPlate.Contour.AddContourPoint(new ContourPoint(p3, new Chamfer()));
            contourPlate.Name = "PLUGIN";
            ///  if 
            contourPlate.Insert();
            {
                BooleanPart booleanPart = new BooleanPart();
                booleanPart.Father = cuttedpart;
                booleanPart.SetOperativePart(contourPlate);
                try
                {
                    booleanPart.Insert();
                }
                catch
                {
                }
                contourPlate.Delete();
            }
        }
        public t3d.Point getmidpoint(t3d.Point p1, t3d.Point p2)
        {
            double dis = t3d.Distance.PointToPoint(p1, p2);
            t3d.Vector vec = new t3d.Vector(p2 - p1); vec.Normalize();
            return p1 + 0.5 * dis * vec;
        }


        private void groovebetween2points(Part cutpart, double cutthk, t3d.Point p1, t3d.Point p2, t3d.Vector normalvec, t3d.Vector insidevec, t3d.Point stiffmidpoint, double wsize, double wsize2, int wtype, int wtype2, double wangle, double wangle2, double extension)
        {
            normalvec.Normalize();
            insidevec.Normalize();
            t3d.GeometricPlane faceplane = new t3d.GeometricPlane(p1, new t3d.Vector(p2 - p1), normalvec);
            // t3d.Vector insidevec = new t3d.Vector(stiffmidpoint - t3d.Projection.PointToPlane(stiffmidpoint, faceplane));
            insidevec.Normalize();

            t3d.Point mymidpoint = getmidpoint(p1, p2);

            t3d.Point gr1p1 = mymidpoint + cutthk / 2 * normalvec;
            t3d.Point gr1p2 = gr1p1 - wsize * normalvec;
            t3d.Point gr1p3 = gr1p1 + wsize * Math.Tan(wangle * Math.PI / 180) * insidevec;

            t3d.Point gr2p1 = mymidpoint - cutthk / 2 * normalvec;
            t3d.Point gr2p2 = gr2p1 + wsize2 * normalvec;
            t3d.Point gr2p3 = gr2p1 + wsize2 * Math.Tan(wangle2 * Math.PI / 180) * insidevec;

            string grooveprofie = "PL" + (t3d.Distance.PointToPoint(p1, p2) + 2 * extension);
            if (wtype == 1 || wtype == 2)
            {
                createBevel(cutpart, gr1p1, gr1p2, gr1p3, grooveprofie);
            }
            if (wtype2 == 1 || wtype2 == 2)
            {
                createBevel(cutpart, gr2p1, gr2p2, gr2p3, grooveprofie);
            }
        }


        public Weld Weld(Part main, Part sec, double Size, double Size2, int type, int type2, double angle, double angle2, double root, double root2, double throat, double throat2, int ShoporSite, string WeldDirection, string Comment, int topgrind, int topgrind2)
        {
            Weld weld = new Weld();
            weld.MainObject = main;
            weld.SecondaryObject = sec;
            weld.SizeAbove = Size;
            weld.SizeBelow = Size2;
            weld.AngleAbove = angle;
            weld.AngleBelow = angle2;
            weld.RootFaceAbove = root;
            weld.RootFaceBelow = root2;
            weld.EffectiveThroatAbove = throat;
            weld.EffectiveThroatBelow = throat2;
            weld.AroundWeld = false;
            weld.ReferenceText = Comment;
            if (ShoporSite == 0)
            {
                weld.ShopWeld = true;
            }
            else
            {
                weld.ShopWeld = false;
            }
            switch (WeldDirection)
            {
                case "+x": weld.Position = Tekla.Structures.Model.Weld.WeldPositionEnum.WELD_POSITION_PLUS_X; break;
                case "-x": weld.Position = Tekla.Structures.Model.Weld.WeldPositionEnum.WELD_POSITION_MINUS_X; ; break;
                case "+y": weld.Position = Tekla.Structures.Model.Weld.WeldPositionEnum.WELD_POSITION_PLUS_Y; break;
                case "-y": weld.Position = Tekla.Structures.Model.Weld.WeldPositionEnum.WELD_POSITION_MINUS_Y; break;
                case "+z": weld.Position = Tekla.Structures.Model.Weld.WeldPositionEnum.WELD_POSITION_PLUS_Z; break;
                case "-z": weld.Position = Tekla.Structures.Model.Weld.WeldPositionEnum.WELD_POSITION_MINUS_Z; break;
            }
            if (topgrind == 0)
            {
                weld.ContourAbove = BaseWeld.WeldContourEnum.WELD_CONTOUR_NONE;
            }
            else if (topgrind == 1)
            {
                weld.ContourAbove = BaseWeld.WeldContourEnum.WELD_CONTOUR_FLUSH;
            }
            else if (topgrind == 2)
            {
                weld.ContourAbove = BaseWeld.WeldContourEnum.WELD_CONTOUR_CONVEX;
            }
            else
            {
                weld.ContourAbove = BaseWeld.WeldContourEnum.WELD_CONTOUR_CONCAVE;
            }

            if (topgrind2 == 0)
            {
                weld.ContourBelow = BaseWeld.WeldContourEnum.WELD_CONTOUR_NONE;
            }
            else if (topgrind2 == 1)
            {
                weld.ContourBelow = BaseWeld.WeldContourEnum.WELD_CONTOUR_FLUSH;
            }
            else if (topgrind2 == 2)
            {
                weld.ContourBelow = BaseWeld.WeldContourEnum.WELD_CONTOUR_CONVEX;
            }
            else
            {
                weld.ContourBelow = BaseWeld.WeldContourEnum.WELD_CONTOUR_CONCAVE;
            }

            if (type != 0)
            {
                weld.AngleAbove = angle;
            }
            if (type2 != 0)
            {
                weld.AngleBelow = angle2;
            }

            /*(0 = fillet , 1 = grove)*/
            if (type == 1)
            {
                weld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_BEVEL_GROOVE_SINGLE_BEVEL_BUTT;
            }
            else if (type == 2)
            {
                weld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_PARTIAL_PENETRATION_SINGLE_BEVEL_BUTT_PLUS_FILLET;
            }
            else if (type == 3)
            {
                weld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_NONE;
            }
            else
            {
                weld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;
            }

            if (type2 == 1)
            {
                weld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_BEVEL_GROOVE_SINGLE_BEVEL_BUTT;
            }
            else if (type2 == 2)
            {
                weld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_PARTIAL_PENETRATION_SINGLE_BEVEL_BUTT_PLUS_FILLET;
            }
            else if (type2 == 3)
            {
                weld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_NONE;
            }
            else
            {
                weld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;
            }

            try
            {
                weld.Insert();
            }
            catch
            {
            }


            return weld;
        }


        private PolyBeam insertPolyPlate(double plateWidth, double platethick, Point platePoint1, Point plateMidPoint, Point platePoint3, string material, string name, string perfix, int startNO, Chamfer c)
        {
            PolyBeam plate = new PolyBeam();

            plate.AddContourPoint(new ContourPoint(platePoint1, null));
            plate.AddContourPoint(new ContourPoint(plateMidPoint, c));
            plate.AddContourPoint(new ContourPoint(platePoint3, null));
            plate.Profile.ProfileString = "PL" + plateWidth + "*" + platethick;
            plate.Material.MaterialString = material;
            plate.Name = name;
            plate.PartNumber.Prefix = perfix;
            plate.PartNumber.StartNumber = startNO;
            Position.PlaneEnum positionPlane = Position.PlaneEnum.MIDDLE;
            Position.RotationEnum positionRotation = Position.RotationEnum.TOP;
            Position.DepthEnum positionDepth = Position.DepthEnum.MIDDLE;
            plate.Position.Depth = positionDepth;
            plate.Position.Rotation = positionRotation;
            plate.Position.Plane = positionPlane;
            plate.Position.PlaneOffset = -platethick / 2;
            plate.Insert();
            return plate;
        }

        private BoltArray InsertBolt(Point platePoint1, Point plateMidPoint, Part mainPart, Part plate, double dx, double boltSize,
            double tolerance, string boltStandard, int no_bolt_x, int no_bolt_y, string spacing_x, string spacing_y,
              BoltArray.BoltTypeEnum boltType, bool sloyInMainPart, bool sloyInSecnPart, double slot_X, double slot_y, bool Washer2, bool nut2
           , double shift)
        {

            BoltArray boltArray = new BoltArray();
            boltArray.FirstPosition = plateMidPoint;
            boltArray.SecondPosition = platePoint1;
            boltArray.PartToBeBolted = plate;
            boltArray.PartToBoltTo = mainPart;

            string[] spacing_X_array = spacing_x.Split(' ');
            string[] spacing_Y_array = spacing_y.Split(' ');
            for (int i = 0; i < no_bolt_x - 1; i++)
            {
                boltArray.AddBoltDistX(double.Parse(spacing_X_array[i]));

            }
            for (int i = 0; i < no_bolt_y - 1; i++)
            {
                boltArray.AddBoltDistY(double.Parse(spacing_Y_array[i]));

            }
            boltArray.StartPointOffset.Dx = dx;

            boltArray.BoltSize = boltSize;
            boltArray.Tolerance = tolerance;
            boltArray.BoltStandard = boltStandard;
            boltArray.Position.Rotation = Position.RotationEnum.TOP;

            boltArray.BoltType = boltType;
            boltArray.Hole1 = sloyInMainPart;
            boltArray.Hole2 = sloyInSecnPart;
            boltArray.SlottedHoleX = slot_X;
            boltArray.SlottedHoleY = slot_y;
            boltArray.Washer2 = Washer2;
            boltArray.Nut2 = nut2;


            boltArray.Washer1 = true;
            boltArray.Nut1 = true;
            boltArray.HoleType = BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_SLOTTED;

            boltArray.StartPointOffset.Dz = shift;
            boltArray.EndPointOffset.Dz = shift;
            boltArray.Insert();
            return boltArray;
        }


        public Weld insert_weld_allaround(Part Main_part, Part Secandary_part, double below)
        {
            Weld weld = new Weld();
            weld.MainObject = Main_part;
            weld.SecondaryObject = Secandary_part;
            weld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_NONE;
            weld.SizeAbove = 0;
            weld.SizeBelow = below;
            weld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;

            weld.ShopWeld = true;
            weld.AroundWeld = true;
            weld.Insert();
            return weld;
        }
        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }
        public int BeamDirection(Part part)
        {
            //  part = new Picker().PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;

            // get transformation plane cuurent to return it after we finished and secandry beam plane to use it
            //  TransformationPlane currentPlan = myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            TransformationPlane transformationPlane = new TransformationPlane(part.GetCoordinateSystem());

            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(transformationPlane);
            ArrayList centerPointsSecndaryPart = part.GetCenterLine(false);
            t3d.Point point1CenterSecndary = centerPointsSecndaryPart[0] as t3d.Point;
            t3d.Point point2CenterSecendary = centerPointsSecndaryPart[1] as t3d.Point;

            double thicknessOfMainPart = 0;
            part.GetReportProperty("WIDTH", ref thicknessOfMainPart);
            t3d.Point MidSecndaryPoint = getmidpoint(point1CenterSecndary, point2CenterSecendary);

            t3d.Point lineForGetMidPoint1 = new t3d.Point(MidSecndaryPoint.X, MidSecndaryPoint.Y + 1000, MidSecndaryPoint.Z + thicknessOfMainPart / 2 - 1);
            t3d.Point lineForGetMidPoint2 = new Point(MidSecndaryPoint.X, MidSecndaryPoint.Y - 1000, MidSecndaryPoint.Z + thicknessOfMainPart / 2 - 1);

            t3d.Point lineForGetEndPoint1 = new t3d.Point(MidSecndaryPoint.X, MidSecndaryPoint.Y + 1000, MidSecndaryPoint.Z - thicknessOfMainPart / 2 + 1);
            t3d.Point lineForGetEndPoint2 = new Point(MidSecndaryPoint.X, MidSecndaryPoint.Y - 1000, MidSecndaryPoint.Z - thicknessOfMainPart / 2 + 1);



            LineSegment line1 = new LineSegment(lineForGetMidPoint1, lineForGetMidPoint2);
            LineSegment line2 = new LineSegment(lineForGetEndPoint1, lineForGetEndPoint2);

            Solid solid = part.GetSolid();
            ArrayList points1 = solid.Intersect(line1);
            ArrayList points2 = solid.Intersect(line2);

            t3d.Point point_1 = points1[0] as t3d.Point;
            t3d.Point point_2 = points2[0] as t3d.Point;
            point_1 = transformationPlane.TransformationMatrixToGlobal.Transform(point_1);
            point_2 = transformationPlane.TransformationMatrixToGlobal.Transform(point_2);
            int direction = 0;
            if (points1.Count < points2.Count)
            {
                if (point_1.Z > point_2.Z)
                {
                    direction = 0;
                }
                else
                {
                    direction = 1;

                }
            }

            else if (points1.Count > points2.Count)
            {
                if (point_2.Z > point_1.Z)
                {
                    direction = 0;

                }
                else
                {
                    direction = 1;


                }
            }

            return direction;
        }

        public class UserInterfaceDefinition
        {
            public const string Plugin3 =
                    "page(\"TeklaStructures\",\"\")\n   " +
                    " {\n    joint(1, Grating_Connection)\n   " +

                    " {\n      tab_page(\"1\", \" Picture \", 1)\n   " +


                    "     {\n      " +
                    "   parameter(\"\", \"negative_X\", distance, number, 317, 21, 80)\n     " +
                    "    parameter(\"\", \"positive_X\", distance, number, 534, 21, 80)\n      " +
                    "   picture(\"tee-column2\", 0, 0, 192, 63)\n    " +
                    "     parameter(\"\", \"positive_Y\", distance, number, 70, 116, 80)\n    " +
                    "     parameter(\"\", \"negative_Y\", distance, number, 89, 323, 80)\n       " +
                    "  picture(\"13\", 0, 0, 885, 269)\n      " +
                    "   parameter(\"\", \"offset\", distance, number, 785, 416, 70)\n  " +


                     "   attribute(\"\", \"t\", label, \"%s\", none, none, \"0\", \"0\", 197, 530)\n     " +
                    "       attribute(\"\", \"h\", label, \"%s\", none, none, \"0\", \"0\", 329, 530)\n         " +
                    "   attribute(\"\", \"Prefix\", label, \"%s\", none, none, \"0\", \"0\", 464, 530)\n         " +
                    "   attribute(\"\", \"Start_NO\", label, \"%s\", none, none, \"0\", \"0\", 577, 530)\n       " +
                    "     attribute(\"\", \"Matrial\", label, \"%s\", none, none, \"0\", \"0\", 741, 530)\n     " +
                    "       attribute(\"\", \"name\", label, \"%s\", none, none, \"0\", \"0\", 930, 530)\n      " +
                    "      attribute(\"\", \"Plate\", label, \"%s\", none, none, \"0\", \"0\", 69, 555)\n       " +
                    "     parameter(\"\", \"Plate_h\", distance, number, 177, 555, 40)\n         " +
                    "   parameter(\"\", \"Plate_b\", distance, number, 290, 555, 70)\n       " +
                    "     parameter(\"\", \"Pos_1\", string, text, 456, 555, 40)\n         " +
                    "   parameter(\"\", \"Plate_pos2\", integer, number, 565, 555, 70)\n   " +
                    "         parameter(\"\", \"Plate_matrial\", material, text, 720, 555, 100)\n   " +
                    "         parameter(\"\", \"Plate_name\", string, text, 900, 555, 100)\n  " +



                      "       attribute(\"\", \"size\", label, \"%s\", none, none, \"0\", \"0\", 224, 623)\n         " +
                     "       attribute(\"\", \"wled Above line\", label, \"%s\", none, none, \"0\", \"0\", 40, 650)\n         " +
                    "    attribute(\"\", \"weld Below line\", label, \"%s\", none, none, \"0\", \"0\", 40, 700)\n     " +
                    "        parameter(\"\", \"weld_aboveline\", distance, number, 200, 650, 100)\n         " +
                    "    parameter(\"\", \"weld_belowline\", distance, number, 200, 700, 100)\n  " +

                    "  }\n   " +



                    //"   tab_page(\"2\", \" Parameters \", 2)\n   " +
                    //"     {\n     " +
                    //"   attribute(\"\", \"t\", label, \"%s\", none, none, \"0\", \"0\", 122, 43)\n     " +
                    //"       attribute(\"\", \"h\", label, \"%s\", none, none, \"0\", \"0\", 210, 43)\n         " +
                    //"   attribute(\"\", \"Perfix\", label, \"%s\", none, none, \"0\", \"0\", 308, 43)\n         " +
                    //"   attribute(\"\", \"Start_NO\", label, \"%s\", none, none, \"0\", \"0\", 406, 43)\n       " +
                    //"     attribute(\"\", \"Matrial\", label, \"%s\", none, none, \"0\", \"0\", 538, 43)\n     " +
                    //"       attribute(\"\", \"Name\", label, \"%s\", none, none, \"0\", \"0\", 685, 43)\n      " +
                    //"      attribute(\"\", \"Plate\", label, \"%s\", none, none, \"0\", \"0\", 25, 76)\n       " +
                    //"     parameter(\"\", \"Plate_h\", distance, number, 120, 76, 40)\n         " +
                    //"   parameter(\"\", \"Plate_b\", distance, number, 190, 76, 70)\n       " +
                    //"     parameter(\"\", \"Pos_1\", string, text, 320, 76, 40)\n         " +
                    //"   parameter(\"\", \"Plate_pos2\", integer, number, 400, 76, 70)\n   " +
                    //"         parameter(\"\", \"Plate_matrial\", material, text, 522, 76, 100)\n   " +
                    //"         parameter(\"\", \"Plate_name\", string, text, 677, 76, 100)\n  " +
                    //"  }\n   " +



                    //"   tab_page(\"3\", \" Welds \", 3)\n      " +
                    //"  {\n  " +
                    //"       attribute(\"\", \"aboveline\", label, \"%s\", none, none, \"0\", \"0\", 33, 55)\n         " +
                    //"    attribute(\"\", \"belowline\", label, \"%s\", none, none, \"0\", \"0\", 36, 109)\n     " +
                    //"        parameter(\"\", \"weld_aboveline\", distance, number, 165, 55, 100)\n         " +
                    //"    parameter(\"\", \"weld_belowline\", distance, number, 165, 109, 100)\n  " +
                    //"  }\n   " +
                    " }\n}\n";
        }

    }
}