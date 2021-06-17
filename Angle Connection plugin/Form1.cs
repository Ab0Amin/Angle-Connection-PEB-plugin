using System;
using System.Collections;
using System.Collections.Generic;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using t3d = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Solid;
using System.Windows.Forms;
using System.Linq;


namespace Angle_Connection_plugin
{
    public partial class Form1 : Form
    {
        Model myModel = new Model();
        private Part mainPart, secendaryPart;
        private t3d.Point plateMidPoint;
       

        public Form1()
        {
            InitializeComponent();
            cb_location.SelectedIndex = 0;
            cb_weldedBolt_1.SelectedIndex = 0;
            cb_weldedBolt_2.SelectedIndex = 0;
            cb_sloted_1.SelectedIndex = 0;
            cb_solted_2.SelectedIndex = 0;
            cb_workshop_1.SelectedIndex = 0;
            cb_workshop_2.SelectedIndex = 1;
        
            cm_washerNo_1.SelectedIndex = 0;
            cm_washerNo_2.SelectedIndex = 0;
            cm_nutNo_1.SelectedIndex = 0;
            cm_nutNo_2.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum_1 = 0;
            string[] spacing_X_array_1 = tx_boltsXSpacing_1.Text.Split(' ');
            for (int i = 0; i < int.Parse(tx_NoOfXBolts_1.Text) - 1; i++)
            {
                sum_1 = sum_1 + double.Parse(spacing_X_array_1[i]);
            }
            sum_1 = sum_1 + double.Parse(tx_boltedge2_x_1.Text) + double.Parse(tx_boltedge_x_1.Text);


            double sum_2 = 0;
            string[] spacing_X_array_2 = tx_boltSpacing_X_2.Text.Split(' ');
            for (int i = 0; i < int.Parse(tx_bolt_X_No_2.Text) - 1; i++)
            {
                sum_2 = sum_2 + double.Parse(spacing_X_array_2[i]);
            }
            sum_2 = sum_2 + double.Parse(tx_boltedge_X_2.Text) + double.Parse(tx_boltengde1_x_2.Text);


            //plate 

            double plateLength_Z = sum_1;
            double plateLength_Y = sum_2;
            double plateWidth = double.Parse(tx_polybeamWidth.Text);
            double platethick = double.Parse(tx_polybeamThik.Text);
            string polyBeam_material = tx_polybeamMaterial.Text;
            string polyBeam_name = tx_polybeamName.Text;
            string polyBeam_perfix = tx_polybeamPerfix.Text;
            int polyBeam_startNO = int.Parse(tx_polybeamStartNo.Text);
            double polyBeam_chanfer_x = double.Parse(tx_polybeamChanferX.Text);
            double polyBeam_chanfer_y = double.Parse(tx_polybeamChanferY.Text);

            double polybeam_weldWithMain = double.Parse(tx_poybeamWeldToMain.Text);
            double polybeam_weldWithSec = double.Parse(tx_poybeamWeldToSec.Text);

            //stiffner
            double stiffner_thik =double.Parse( tx_stiffThik.Text);
            string stiffner_material = tx_stiffMaterial.Text;
            string stiff_name = tx_stiffName.Text;
            string stiff_perfix = tx_stiffPerfix.Text;
            int stiff_sttartNo = int.Parse(tx_stiffStartNoo.Text);



            double l1 = double.Parse(tx_stiffnerL1.Text);
            double l2 = double.Parse(tx_stiffnerL2.Text);
            double h1 = double.Parse(tx_stiffnerH1.Text);
            double h2 = double.Parse(tx_stiffnerH2.Text);

            double stiff_chanfer_x = double.Parse(tx_stffnerChanferX.Text);
            double stiff_chanfer_y = double.Parse(tx_stffnerChanferY.Text);

           

            int NO_ofStiffner = int.Parse(tx_no_ofStiffners.Text);
            double Spacing_stiffners = double.Parse(tx_spacingStiffners.Text);
            double stiff_shift = double.Parse(tx_stiffnerShift.Text);


            //stiffner welds 

            double stiff_weldAbove_X = double.Parse(tx_stiffWeldSizeAbove_X.Text);
            double stiff_weldBelow_X = double.Parse(tx_stiffWeldSizeBelow_X.Text);
            double stiff_weldAbove_Y = double.Parse(tx_stiffWeldSizeAbove_Y.Text);
            double stiff_weldBelow_Y = double.Parse(tx_stiffWeldSizeBelow_Y.Text);

            int weld_above_1_type = cb_type_above_1.SelectedIndex;
            int weld_above_2_type = cb_type_above_2.SelectedIndex;
            int weld_below_1_type = cb_type_below_1.SelectedIndex;
            int weld_below_2_type = cb_type_below_2.SelectedIndex;

            double weld_angle_above_1 = double.Parse(tx_angle_above_1.Text);
            double weld_angle_above_2 = double.Parse(tx_angle_above_2.Text);
            double weld_angle_below_1 = double.Parse(tx_angle_below_1.Text);
            double weld_angle_below_2 = double.Parse(tx_angle_below_2.Text);


            double weld_root_above_1 = double.Parse(tx_root_above_1.Text);
            double weld_root_above_2 = double.Parse(tx_root_above_2.Text);
            double weld_root_below_1 = double.Parse(tx_root_below_1.Text);
            double weld_root_below_2 = double.Parse(tx_root_below_2.Text);


            double weld_throat_above_1 = double.Parse(tx_throat_above_1.Text);
            double weld_throat_above_2 = double.Parse(tx_throat_above_2.Text);
            double weld_throat_below_1 = double.Parse(tx_throat_below_1.Text);
            double weld_throat_below_2 = double.Parse(tx_throat_below_2.Text);

            int weld_contour_above_1 = cb_above_contor_1.SelectedIndex;
            int weld_contour_above_2 = cb_above_contor_2.SelectedIndex;
            int weld_contour_below_1 = cb_below_contor_1.SelectedIndex;
            int weld_contour_below_2 = cb_below_contor_2.SelectedIndex;

            int weld_shopOrSite_1 = cb_weld_stieOrShop_1.SelectedIndex;
            int weld_shopOrSite_2 = cb_weld_stieOrShop_2.SelectedIndex;

            string weld_comment_1 = tx_weld_comment_1.Text;
            string weld_comment_2 = tx_weld_comment_2.Text;

            // bolts 


            double dx_Boltedge_main = double.Parse(tx_boltedge_x_1.Text);
            string X_spacing_main = tx_boltsXSpacing_1.Text;
            string Y_spacing_main = tx_boltSpacing_Y_1.Text;
            double boltSize_main =double.Parse( tx_boltSize_1.Text);
            double tolerance_main = double.Parse(tx_boltTolerence_1.Text);
            string boltStandard_main = tx_boltStandard_1.Text;
            int NO_ofBolts_X_main = int.Parse(tx_NoOfXBolts_1.Text);
            int NO_ofBolts_Y_main = int.Parse(tx_boltNo_Y_1.Text);


            double dx_Boltedge_sec = double.Parse(tx_boltedge_X_2.Text);
            string X_spacing_sec = tx_boltSpacing_X_2.Text;
            string Y_spacing_sec = tx_boltSpacing_Y_2.Text;
            double boltSize_sec = double.Parse(tx_boltSize_2.Text);
            double tolerance_sec = double.Parse(tx_bolttolerance_2.Text);
            string boltStandard_sec = tx_boltStandard_2.Text;
            int NO_ofBolts_X_sec = int.Parse(tx_bolt_X_No_2.Text);
            int NO_ofBolts_Y_sec = int.Parse(tx_boltNo_Y_2.Text);

            BoltArray.BoltTypeEnum boltType_1 = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;
            BoltArray.BoltTypeEnum boltType_2 = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;



            bool slotMainPart_1 = false;
            bool slotSecPart_1 = false;
            bool washer2_1 = false;
            bool nut2_1 = false;


            double slotX_1 = double.Parse(tx_Slot_x_1.Text);
            double slotY_1 = double.Parse(tx_Slot_y_1.Text);
          
            bool slotMainPart_2 = false;
            bool slotSecPart_2 = false;
            bool washer2_2 = false;
            bool nut2_2 = false;


            double slotX_2 = double.Parse(tx_slotX_2.Text);
            double slotY_2 = double.Parse(tx_slotY_2.Text);

           
            // pick 2 parts main and secandy part
            mainPart = new Picker().PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            secendaryPart = new Picker().PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;

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


                    double z_Point = MaxSecndaryPoint.Z;
                    double z_dirFactor = 1;
                    
                    if (cb_location.SelectedIndex ==0)
                    {
                        if (point1_max.Z > point2_min.Z)
                        {
                            z_Point = MaxSecndaryPoint.Z;
                            z_dirFactor = 1;
                        }
                        else if (point1_max.Z < point2_min.Z)
                        {
                            z_Point = MinSecndaryPoint.Z;
                            z_dirFactor = -1;

                        }
                    }
                    else if (cb_location.SelectedIndex == 1)
                    {
                        if (point1_max.Z < point2_min.Z)
                        {
                            z_Point = MaxSecndaryPoint.Z;
                            z_dirFactor = 1;
                        }
                        else if (point1_max.Z > point2_min.Z)
                        {
                            z_Point = MinSecndaryPoint.Z;
                            z_dirFactor = -1;

                        }
                    }

                    double x_Point = point1CenterMain.X;
                    double y_Point = point1CenterMain.Y;
                    double factor = 1;


                    if (y_Point > 0)
                    {
                        factor = -1;

                    }

                    // get mid point of the polyplates
                    t3d.Point TemPlateMidPoint = new Point(x_Point, y_Point, z_Point);

                    t3d.Point lineForGetMidPoint1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y  + 10000, TemPlateMidPoint.Z);
                    t3d.Point lineForGetMidPoint2 = new Point(x_Point, y_Point - 10000, z_Point);
                    
                    t3d.Point lineForGetEndPoint1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y  + 10000, TemPlateMidPoint.Z + plateLength_Z*z_dirFactor);
                    t3d.Point lineForGetEndPoint2 = new Point(x_Point, y_Point - 10000, z_Point + plateLength_Z*z_dirFactor);
                    
                   
                    t3d.Point planeOrgin = new t3d.Point(point1CenterMain.X, point1CenterMain.Y + thicknessOfMainPart * factor / 2, point1CenterMain.Z);

                    LineSegment line1 = new LineSegment(lineForGetMidPoint1, lineForGetMidPoint2);
                    LineSegment line2 = new LineSegment(lineForGetEndPoint1, lineForGetEndPoint2);


                 

                    t3d.Point lineForstiffner1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y  + 10000, TemPlateMidPoint.Z +l2*z_dirFactor);
                    t3d.Point lineForstiffner2 = new Point(x_Point, y_Point - 10000, z_Point + l2 * z_dirFactor);
                    LineSegment lineStiffner = new LineSegment(lineForstiffner1, lineForstiffner2);

                    
                    GeometricPlane mainPartPlane = new GeometricPlane(planeOrgin, mainPart.GetCoordinateSystem().AxisX, mainPart.GetCoordinateSystem().AxisY);

                    plateMidPoint = Intersection.LineSegmentToPlane(line1, mainPartPlane);
                    t3d.Point platePoint1 = Intersection.LineSegmentToPlane(line2, mainPartPlane);
                    t3d.Point platePoint3 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + plateLength_Y * factor, plateMidPoint.Z);

                    // stiffner points
                    t3d.Point stiffnerPoint0 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + platethick * factor, plateMidPoint.Z + platethick *z_dirFactor);
                   t3d.Point stiffnerPoint1 = Intersection.LineSegmentToPlane(lineStiffner, mainPartPlane);
                    stiffnerPoint1 = new t3d.Point(stiffnerPoint1.X, stiffnerPoint1.Y + platethick * factor, stiffnerPoint1.Z+platethick*z_dirFactor);
                    t3d.Point stiffnerPoint2 = new t3d.Point(stiffnerPoint1.X, stiffnerPoint1.Y + h2 * factor, stiffnerPoint1.Z);
                    t3d.Point stiffnerPoint3 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + (platethick + l1) * factor, plateMidPoint.Z + platethick * z_dirFactor + h1*z_dirFactor);
                    t3d.Point stiffnerPoint4 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y + (platethick + l1) * factor, plateMidPoint.Z + platethick * z_dirFactor);


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
                    if (cb_polybeamChanfer.SelectedIndex == 0)
                    {
                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_LINE; ;

                    }
                    else if (cb_polybeamChanfer.SelectedIndex == 1)
                    {
                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_ROUNDING;

                    }
                    else
                    {

                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_NONE;

                    }
                    polyBeam_chanfetType.X = polyBeam_chanfer_x;
                    polyBeam_chanfetType.Y = polyBeam_chanfer_y;

                    PolyBeam plate = insertPolyPlate(plateWidth, platethick, platePoint1,plateMidPoint, platePoint3,polyBeam_material,polyBeam_name,polyBeam_perfix,polyBeam_startNO, polyBeam_chanfetType);


                  

                    // bolts

                    if (cb_sloted_1.SelectedIndex == 1 )
                    {
                        slotMainPart_1 = true;
                    }
                    else if (cb_sloted_1.SelectedIndex == 2)
                    {
                        slotSecPart_1 = true;
                    }

                    if (cb_solted_2.SelectedIndex == 2)
                    {
                        slotMainPart_2 = true;
                    }
                    else if (cb_solted_2.SelectedIndex == 1)
                    {
                        slotSecPart_2 = true;
                    }

                    if (cm_washerNo_1.SelectedIndex == 1)
                    {
                        washer2_1 = true;
                    }
                    if (cm_washerNo_2.SelectedIndex == 1)
                    {
                        washer2_2 = true;
                    }
                    if (cm_nutNo_1.SelectedIndex == 1)
                    {
                        nut2_1 = true;
                    }
                    if (cm_nutNo_1.SelectedIndex == 1)
                    {
                        nut2_2 = true;
                    }

                    if (cb_workshop_1.SelectedIndex == 1)
                    {
                        boltType_1 = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
                    }

                    if (cb_workshop_2.SelectedIndex == 1)
                    {
                        boltType_2 = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
                    }

                    if (cb_weldedBolt_1.SelectedIndex == 0)
                    {
                       
                        BoltArray boltWithMain = InsertBolt(platePoint1, plateMidPoint, mainPart, plate, dx_Boltedge_main, boltSize_main,
tolerance_main, boltStandard_main, NO_ofBolts_X_main, NO_ofBolts_Y_main, X_spacing_main, Y_spacing_main
, boltType_1, slotMainPart_1, slotSecPart_1, slotX_1, slotY_1, washer2_1, nut2_1
);
                    }
                    else
                    {
                        insert_weld_allaround(mainPart, plate, polybeam_weldWithMain);
                    }


                    if (cb_weldedBolt_2.SelectedIndex == 0)
                    {

                        BoltArray boltWithSec = InsertBolt(platePoint3, plateMidPoint, secendaryPart, plate, dx_Boltedge_sec, boltSize_sec,
            tolerance_sec, boltStandard_sec, NO_ofBolts_X_sec, NO_ofBolts_Y_sec, X_spacing_sec, Y_spacing_sec
              , boltType_2, slotMainPart_2, slotSecPart_2, slotX_2, slotY_2, washer2_2, nut2_2
            );
                    }
                    else
                    {
                        insert_weld_allaround(secendaryPart, plate, polybeam_weldWithMain);
                    }




                    Chamfer stiff_chanfetType = new Chamfer();
                    if (cb_stiffChanfer.SelectedIndex == 0)
                    {
                        stiff_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_LINE;;

                    }
                    else  if (cb_stiffChanfer.SelectedIndex == 1)
                    {
                        stiff_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_ARC;

                    }
                    else
                    {

                        stiff_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_NONE;

                    }



                    stiff_chanfetType.X = stiff_chanfer_x;
                    stiff_chanfetType.Y = stiff_chanfer_y;
                    ContourPlate stiffner = new ContourPlate();
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint0, stiff_chanfetType));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint1, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint2, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint3, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint4, null));
                    stiffner.Position.Depth = Position.DepthEnum.MIDDLE;
                    stiffner.Profile.ProfileString = "PL"+stiffner_thik;
                    stiffner.Material.MaterialString = stiffner_material;
                    stiffner.Name = stiff_name;
                    stiffner.PartNumber.StartNumber = stiff_sttartNo;
                    stiffner.PartNumber.Prefix = stiff_perfix;
                    stiffner.Insert();

                    //weld stiff to polybem
                    //insert_weld(plate, stiffner, stiff_weldAbove_X, stiff_weldBelow_X, new Vector(-1, 0, 0));
                    //insert_weld(plate, stiffner, stiff_weldAbove_Y, stiff_weldBelow_Y, new Vector(0, -1, 0));

                    Weld(plate, stiffner, stiff_weldAbove_X, stiff_weldBelow_X, weld_above_1_type, weld_below_1_type, weld_angle_above_1, weld_angle_below_1, weld_root_above_1, weld_root_below_1,
                        weld_throat_above_1, weld_throat_below_1, weld_shopOrSite_1, "-x", weld_comment_1, weld_contour_above_1, weld_contour_below_1);


                    groovebetween2points(stiffner, stiffner_thik, stiffnerPoint0, stiffnerPoint4, new t3d.Vector(0, 0, 1), new t3d.Vector(1, 0, 0), getmidpoint(stiffnerPoint0, stiffnerPoint4),
                        stiff_weldAbove_X, stiff_weldBelow_X, weld_above_1_type, weld_below_1_type, weld_angle_above_1, weld_angle_below_1, 5);

                  


                    Weld(plate, stiffner, stiff_weldAbove_Y, stiff_weldBelow_Y, weld_above_2_type, weld_below_2_type, weld_angle_above_2, weld_angle_below_2, weld_root_above_2, weld_angle_below_2,
                       weld_throat_above_2, weld_throat_below_2, weld_shopOrSite_2, "-y", weld_comment_2, weld_contour_above_2, weld_contour_below_2);

                    groovebetween2points(stiffner, stiffner_thik, stiffnerPoint0, stiffnerPoint1, new t3d.Vector(0, 0, 1), new t3d.Vector(0, 1, 0), getmidpoint(stiffnerPoint0, stiffnerPoint1),
                       stiff_weldAbove_Y, stiff_weldBelow_Y, weld_above_2_type, weld_below_2_type, weld_angle_above_2, weld_angle_below_2, 5);


                    // move stiffner

                    Operation.MoveObject(stiffner, new Vector(0, 0,stiff_shift));

                    // copy stiffners
                    if (NO_ofStiffner>1)
                    {

                        double rest = NO_ofStiffner % 2;
                        if (rest ==0)
                        {
                            Part stiff1=   (Part)Operation.CopyObject(stiffner, new Vector(0, 0,Spacing_stiffners/2));
                            Part stiff2 = (Part)Operation.CopyObject(stiffner, new Vector(0, 0,-Spacing_stiffners/2));
                          double  rest_NO_ofStiffner = (NO_ofStiffner - 2)/2;
                            for (int i = 0; i < rest_NO_ofStiffner; i++)
                            {
                                Operation.CopyObject(stiff1, new Vector(0, 0, Spacing_stiffners ));
                                Operation.CopyObject(stiff2, new Vector(0, 0, -Spacing_stiffners ));
                                stiffner.Delete();
                            }
                        }
                        else
                        {
                            int rest_NO_ofStiffner = (NO_ofStiffner  / 2);
                            for (int i = 0; i < rest_NO_ofStiffner; i++)
                            {
                                Operation.CopyObject(stiffner, new Vector(0, 0, Spacing_stiffners));
                                Operation.CopyObject(stiffner, new Vector(0, 0, -Spacing_stiffners));
                               
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

       
        private void groovebetween2points(Part cutpart, double cutthk, t3d.Point p1, t3d.Point p2, t3d.Vector normalvec, t3d.Vector insidevec , t3d.Point stiffmidpoint, double wsize, double wsize2, int wtype, int wtype2, double wangle, double wangle2, double extension)
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


        private PolyBeam insertPolyPlate(double plateWidth, double platethick, Point platePoint1, Point plateMidPoint, Point platePoint3,string material,string name ,string perfix ,int startNO,Chamfer c)
        {
            PolyBeam plate = new PolyBeam();

            plate.AddContourPoint(new ContourPoint(platePoint1, null));
            plate.AddContourPoint(new ContourPoint(plateMidPoint, c));
            plate.AddContourPoint(new ContourPoint(platePoint3, null));
            plate.Profile.ProfileString = "PL" + plateWidth + "*" + platethick;
            plate.Material.MaterialString =material ;
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

        private BoltArray InsertBolt(Point platePoint1,Point plateMidPoint,Part mainPart, Part plate, double dx, double boltSize,
            double tolerance, string boltStandard, int no_bolt_x, int no_bolt_y ,string spacing_x,string spacing_y,
              BoltArray.BoltTypeEnum boltType ,bool sloyInMainPart , bool sloyInSecnPart, double slot_X ,double slot_y ,bool Washer2 , bool nut2
            )
        {
          
            BoltArray boltArray = new BoltArray();
            boltArray.FirstPosition = plateMidPoint;
            boltArray.SecondPosition = platePoint1;
            boltArray.PartToBeBolted = plate;
            boltArray.PartToBoltTo = mainPart;

            string[] spacing_X_array = spacing_x.Split(' ');
            string[] spacing_Y_array = spacing_y.Split(' ');
            for (int i = 0; i < no_bolt_x-1; i++)
            {
                boltArray.AddBoltDistX(double.Parse(spacing_X_array[i]));

            }
            for (int i = 0; i < no_bolt_y-1; i++)
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

            boltArray.Insert();
            return boltArray;
        }

      

     

        public Weld insert_weld(Part Main_part, Part Secandary_part,double above ,double below,Vector vector)
        {
            Weld weld = new Weld();
            weld.MainObject =Main_part;
            weld.SecondaryObject = Secandary_part;
            weld.SizeAbove =above;
            weld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;
            weld.SizeBelow =below;
            weld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;
            weld.ShopWeld = true;
            weld.AroundWeld = false;
            weld.Direction = vector;
            weld.Insert();
            return weld;
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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        public Beam check_with_beam(Point start_point, Point end_point)
        {
            Beam beam = new Beam();
            beam.StartPoint = start_point;
            beam.EndPoint = end_point;
            beam.Profile.ProfileString = "ROD100";
            beam.Position.Depth = Position.DepthEnum.FRONT;
            beam.Position.Plane = Position.PlaneEnum.RIGHT;
            beam.Position.Rotation = Position.RotationEnum.TOP;
            beam.Insert();
            return beam;
        }

    }
}
