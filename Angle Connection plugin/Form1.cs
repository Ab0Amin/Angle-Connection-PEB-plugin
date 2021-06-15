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
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPart = new Picker().PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            secendaryPart = new Picker().PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;

            TransformationPlane currentPlan = myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            TransformationPlane transformationPlane = new TransformationPlane(secendaryPart.GetCoordinateSystem());

            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(transformationPlane);

            ArrayList centerPointsSecndaryPart = secendaryPart.GetCenterLine(false);
            t3d.Point point1CenterSecndary = centerPointsSecndaryPart[0] as t3d.Point;
            t3d.Point point2CenterSecendary = centerPointsSecndaryPart[1] as t3d.Point;

            ArrayList centerPointsMainPart = mainPart.GetCenterLine(false);
            t3d.Point point1CenterMain = centerPointsMainPart[0] as t3d.Point;
            t3d.Point point2CenterMain = centerPointsMainPart[1] as t3d.Point;

            LineSegment centerLineSecandryPart = new LineSegment(new t3d.Point(point1CenterSecndary.X - 5000, point1CenterSecndary.Y, point1CenterSecndary.Z), new t3d.Point(point2CenterSecendary.X + 5000, point2CenterSecendary.Y, point2CenterSecendary.Z));
            Solid mainSolid = mainPart.GetSolid();

            double thicknessOfMainPart = 0;
            mainPart.GetReportProperty("WIDTH", ref thicknessOfMainPart);


            #region case clumn to beam
            if (mainSolid.Intersect(centerLineSecandryPart).Count == 0)
            {
                string type = null;
                secendaryPart.GetReportProperty("PROFILE_TYPE", ref type);
                #region case beam c profie
                if (type == "C")
                {
                    //int noOfLowerFaces = get_lower_edge(secendaryPart).Count;
                    Solid secSolid = secendaryPart.GetSolid();

                    t3d.Point MaxSecndaryPoint = secSolid.MaximumPoint;
                    t3d.Point MinSecndaryPoint = secSolid.MinimumPoint;

                    t3d.Point point1_max = transformationPlane.TransformationMatrixToGlobal.Transform(MaxSecndaryPoint);
                    t3d.Point point2_min = transformationPlane.TransformationMatrixToGlobal.Transform(MinSecndaryPoint);


                    double z_Point = MaxSecndaryPoint.Z;
                    double z_dirFactor = 1;
                    
                    if (comboBox1.SelectedIndex ==0)
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
                    else if (comboBox1.SelectedIndex == 1)
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

                    double y_shifting = 500;
                    double plateLength_Z = 100;
                    double plateLength_Y = 100;
                    double plateWidth = 100;
                    double platethick = 10;



                    if (y_Point > 0)
                    {
                        factor = -1;

                    }


                    t3d.Point TemPlateMidPoint = new Point(x_Point, y_Point, z_Point);

                    t3d.Point lineForGetMidPoint1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y + y_shifting * factor + 10000, TemPlateMidPoint.Z);
                    t3d.Point lineForGetMidPoint2 = new Point(x_Point, y_Point - 10000, z_Point);
                    
                    t3d.Point lineForGetEndPoint1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y + y_shifting * factor + 10000, TemPlateMidPoint.Z + plateLength_Z*z_dirFactor);
                    t3d.Point lineForGetEndPoint2 = new Point(x_Point, y_Point - 10000, z_Point + plateLength_Z*z_dirFactor);
                    
                   
                    t3d.Point planeOrgin = new t3d.Point(point1CenterMain.X, point1CenterMain.Y + thicknessOfMainPart * factor / 2, point1CenterMain.Z);

                    LineSegment line1 = new LineSegment(lineForGetMidPoint1, lineForGetMidPoint2);
                    LineSegment line2 = new LineSegment(lineForGetEndPoint1, lineForGetEndPoint2);


                    // stiffner paramters 
                    double l1 = 50;
                    double l2 = 50;
                    double h1 = 10;
                    double h2 = 10;

                    t3d.Point lineForstiffner1 = new t3d.Point(TemPlateMidPoint.X, TemPlateMidPoint.Y + y_shifting * factor + 10000, TemPlateMidPoint.Z +l2*z_dirFactor);
                    t3d.Point lineForstiffner2 = new Point(x_Point, y_Point - 10000, z_Point + l2 * z_dirFactor);
                    LineSegment lineStiffner = new LineSegment(lineForstiffner1, lineForstiffner2);

                    //
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

                    PolyBeam plate = insertPolyPlate(plateWidth, platethick, platePoint1,plateMidPoint, platePoint3);

                    double dx_main = 20;
                    string X_spacing_main = "50 50";
                    string Y_spacing_main = "50 50";
                    double boltSize_main = 16;
                    double tolerance_main = 2;
                    string boltStandard_main = "4.6CSK";
                    int NO_ofBolts_X_main = 3;
                    int NO_ofBolts_Y_main = 3;


                    double dx_sec = 30;
                    string X_spacing_sec = "50";
                    string Y_spacing_sec = "50";
                    double boltSize_sec = 16;
                    double tolerance_sec = 2;
                    string boltStandard_sec = "4.6CSK";
                    int NO_ofBolts_X_sec = 2;
                    int NO_ofBolts_Y_sec = 2;

                    BoltArray boltWithMain = InsertBolt(platePoint1, plateMidPoint, mainPart, plate, dx_main, boltSize_main,
              tolerance_main, boltStandard_main, NO_ofBolts_X_main, NO_ofBolts_Y_main, X_spacing_main, Y_spacing_main);

                    BoltArray boltWithSec = InsertBolt(platePoint3, plateMidPoint, secendaryPart, plate, dx_sec, boltSize_sec,
            tolerance_sec, boltStandard_sec, NO_ofBolts_X_sec, NO_ofBolts_Y_sec, X_spacing_sec, Y_spacing_sec);


                 

                    ContourPlate stiffner = new ContourPlate();
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint0, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint1, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint2, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint3, null));
                    stiffner.AddContourPoint(new ContourPoint(stiffnerPoint4, null));
                    stiffner.Profile.ProfileString = "PL10";
                    stiffner.Material.MaterialString = "43";
                    stiffner.Insert();
                }
                #endregion



            }


            #endregion



            //myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlan);
            myModel.CommitChanges();
        }

        private PolyBeam insertPolyPlate(double plateWidth, double platethick, Point platePoint1, Point plateMidPoint, Point platePoint3)
        {
            PolyBeam plate = new PolyBeam();

            plate.AddContourPoint(new ContourPoint(platePoint1, null));
            plate.AddContourPoint(new ContourPoint(plateMidPoint, null));
            plate.AddContourPoint(new ContourPoint(platePoint3, null));
            plate.Profile.ProfileString = "PL" + plateWidth + "*" + platethick;
            plate.Material.MaterialString = "43";
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

        public List<t3d.Point> get_lower_points(Part Gpart)
        {
            List<LineSegment> lineSegmentList = new List<LineSegment>();
            List<t3d.Point> Points = new List<t3d.Point>();
           
            Point point3 = new Point();
          
            Tekla.Structures.Model.Solid solid = Gpart.GetSolid(Tekla.Structures.Model.Solid.SolidCreationTypeEnum.PLANECUTTED);
            EdgeEnumerator edgeEnumerator = solid.GetEdgeEnumerator();
            Point maximumPoint = solid.MaximumPoint;
            Point minimumPoint = solid.MinimumPoint;
            TransformationPlane transformationPlane = this.myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            Point point6 = transformationPlane.TransformationMatrixToGlobal.Transform(maximumPoint);
            Point point7 = transformationPlane.TransformationMatrixToGlobal.Transform(minimumPoint);
            if (point6.Z > point7.Z)
                point3 = minimumPoint;
            else if (point6.Z < point7.Z)
                point3 = maximumPoint;
            if (solid != null)
            {
                while (edgeEnumerator.MoveNext())
                {
                    Edge current = edgeEnumerator.Current as Edge;
                    if (current.StartPoint.Z - current.EndPoint.Z == 0.0 && current.StartPoint.Z == point3.Z)
                    {
                        LineSegment lineSegment = new LineSegment(current.StartPoint, current.EndPoint);
                        Points.Add(lineSegment.Point1);
                        Points.Add(lineSegment.Point2);
                    }
                }
                Points = Points.Distinct().ToList();
            }
            return Points;
        }


        public List<LineSegment> get_lower_edge(Part Gpart)
        {
            List<LineSegment> lineSegmentList = new List<LineSegment>();
         
            Point point3 = new Point();
         
            Tekla.Structures.Model.Solid solid = Gpart.GetSolid(Tekla.Structures.Model.Solid.SolidCreationTypeEnum.PLANECUTTED);
            EdgeEnumerator edgeEnumerator = solid.GetEdgeEnumerator();
            Point maximumPoint = solid.MaximumPoint;
            Point minimumPoint = solid.MinimumPoint;
            TransformationPlane transformationPlane = this.myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            Point point6 = transformationPlane.TransformationMatrixToGlobal.Transform(maximumPoint);
            Point point7 = transformationPlane.TransformationMatrixToGlobal.Transform(minimumPoint);
            if (point6.Z > point7.Z)
                point3 = minimumPoint;
            else if (point6.Z < point7.Z)
                point3 = maximumPoint;
            if (solid != null)
            {
                while (edgeEnumerator.MoveNext())
                {
                    Edge current = edgeEnumerator.Current as Edge;
                    if (current.StartPoint.Z - current.EndPoint.Z == 0.0 && current.StartPoint.Z == point3.Z)
                    {
                        LineSegment lineSegment = new LineSegment(current.StartPoint, current.EndPoint);
                        lineSegmentList.Add(lineSegment);
                    }
                }
            }
            return lineSegmentList;
        }

        public Weld insert_weld(Part Main_part, Part Secandary_part)
        {
            Weld weld = new Weld();
            weld.MainObject = (ModelObject)Main_part;
            weld.SecondaryObject = (ModelObject)Secandary_part;
            weld.SizeAbove = 6;
            weld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;
            weld.SizeBelow = 6;
            weld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;
            weld.ShopWeld = true;
            weld.AroundWeld = false;
            CoordinateSystem coordinateSystem = Secandary_part.GetCoordinateSystem();
            weld.Direction = coordinateSystem.AxisY;
            weld.Insert();
            return weld;
        }

        public Beam insert_toeplate(Point start_point, Point end_point)
        {
            Beam beam = new Beam();
            beam.StartPoint = start_point;
            beam.EndPoint = end_point;
            beam.Profile.ProfileString = "PL" + 10+ "*" + 200;
            beam.Position.Depth = Position.DepthEnum.FRONT;
            beam.Position.Plane = Position.PlaneEnum.RIGHT;
            beam.Position.Rotation = Position.RotationEnum.TOP;
            beam.Position.DepthOffset =0;
            beam.Material.MaterialString = "A36";
            beam.PartNumber.Prefix = "W";
            beam.PartNumber.StartNumber = 101;
            beam.Name = "Platr";
            beam.Class = "211";
            beam.Insert();
            return beam;
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
