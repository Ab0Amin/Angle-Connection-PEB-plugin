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

            double stiff_weldAbove_X = double.Parse(tx_stiffWeldSizeAbove_X.Text);
            double stiff_weldBelow_X = double.Parse(tx_stiffWeldSizeBelow_X.Text);
            double stiff_weldAbove_Y = double.Parse(tx_stiffWeldSizeAbove_Y.Text);
            double stiff_weldBelow_Y = double.Parse(tx_stiffWeldSizeBelow_Y.Text);

            int NO_ofStiffner = int.Parse(tx_no_ofStiffners.Text);
            double Spacing_stiffners = double.Parse(tx_spacingStiffners.Text);
            double stiff_shift = double.Parse(tx_stiffnerShift.Text);

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
                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_ARC;

                    }
                    else
                    {

                        polyBeam_chanfetType.Type = Chamfer.ChamferTypeEnum.CHAMFER_NONE;

                    }
                    polyBeam_chanfetType.X = polyBeam_chanfer_x;
                    polyBeam_chanfetType.Y = polyBeam_chanfer_y;

                    PolyBeam plate = insertPolyPlate(plateWidth, platethick, platePoint1,plateMidPoint, platePoint3,polyBeam_material,polyBeam_name,polyBeam_perfix,polyBeam_startNO, polyBeam_chanfetType);

                    BoltArray boltWithMain = InsertBolt(platePoint1, plateMidPoint, mainPart, plate, dx_Boltedge_main, boltSize_main,
              tolerance_main, boltStandard_main, NO_ofBolts_X_main, NO_ofBolts_Y_main, X_spacing_main, Y_spacing_main);

                    BoltArray boltWithSec = InsertBolt(platePoint3, plateMidPoint, secendaryPart, plate, dx_Boltedge_sec, boltSize_sec,
            tolerance_sec, boltStandard_sec, NO_ofBolts_X_sec, NO_ofBolts_Y_sec, X_spacing_sec, Y_spacing_sec);



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
                    insert_weld(plate, stiffner, stiff_weldAbove_X, stiff_weldBelow_X, new Vector(-1, 0, 0));
                    insert_weld(plate, stiffner, stiff_weldAbove_Y, stiff_weldBelow_Y, new Vector(0, -1, 0));

                    // move stiffner

                    Operation.MoveObject(stiffner, new Vector(0, 0,stiff_shift));

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
                }
                #endregion



            }


            #endregion



          //  myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlan);
            myModel.CommitChanges();
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
            double tolerance, string boltStandard, int no_bolt_x, int no_bolt_y ,string spacing_x,string spacing_y)
        {
            BoltArray boltArrayWithMain = new BoltArray();
            boltArrayWithMain.FirstPosition = plateMidPoint;
            boltArrayWithMain.SecondPosition = platePoint1;
            boltArrayWithMain.PartToBeBolted = plate;
            boltArrayWithMain.PartToBoltTo = mainPart;

            string[] spacing_X_array = spacing_x.Split(' ');
            string[] spacing_Y_array = spacing_y.Split(' ');
            for (int i = 0; i < no_bolt_x-1; i++)
            {
                boltArrayWithMain.AddBoltDistX(double.Parse(spacing_X_array[i]));

            }
            for (int i = 0; i < no_bolt_y-1; i++)
            {
                boltArrayWithMain.AddBoltDistY(double.Parse(spacing_Y_array[i]));

            }
            boltArrayWithMain.StartPointOffset.Dx = dx;

            boltArrayWithMain.BoltSize = boltSize;
            boltArrayWithMain.Tolerance = tolerance;
            boltArrayWithMain.BoltStandard = boltStandard;
            boltArrayWithMain.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
            boltArrayWithMain.Position.Rotation = Position.RotationEnum.TOP;


            boltArrayWithMain.Insert();
            return boltArrayWithMain;
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

        private void textBox25_TextChanged(object sender, EventArgs e)
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
