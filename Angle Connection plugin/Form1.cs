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
        private Part mainPart , secendaryPart;
        private t3d.Point plateMidPoint;

        public Form1()
        {
            InitializeComponent();
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

            LineSegment centerLineSecandryPart = new LineSegment(new t3d.Point(point1CenterSecndary.X-5000,point1CenterSecndary.Y,point1CenterSecndary.Z), new t3d.Point(point2CenterSecendary.X + 5000, point2CenterSecendary.Y, point2CenterSecendary.Z));
            Solid mainSolid = mainPart.GetSolid();

            double thicknessOfMainPart = 0;
             mainPart.GetReportProperty("WIDTH", ref thicknessOfMainPart);
            

            #region case clumn to beam
            if (mainSolid.Intersect(centerLineSecandryPart).Count==0)
            {
                string type = null;
                secendaryPart.GetReportProperty("PROFILE_TYPE", ref type);
                #region case beam c profie
                if (type == "C")
                {
                int d=    get_lower_edge(secendaryPart).Count;
                    Solid secSolid = secendaryPart.GetSolid();

                    t3d.Point MaxSecndaryPoint = secSolid.MaximumPoint;
                    t3d.Point MinSecndaryPoint = secSolid.MinimumPoint;

                    t3d.Point point1 = transformationPlane.TransformationMatrixToGlobal.Transform(MaxSecndaryPoint);
                    t3d.Point point2 = transformationPlane.TransformationMatrixToGlobal.Transform(MinSecndaryPoint);
                    t3d.Point minPoint = MaxSecndaryPoint;
                  
                    if (point1.Z>point2.Z)
                    {
                        minPoint = MinSecndaryPoint;
                  
                    }
                    double  x_Point = point1CenterMain.X;
                    double y_Point = point1CenterMain.Y;
                    double factor = 1;
                    double z_shifting = 500;
                    double y_shifting = 500;

                    if (y_Point > 0)
                    {
                        factor = -1;
                    }
                      //  y_Point = y_Point + (factor)*thicknessOfMainPart/2;

                    double z_Point = minPoint.Z;

                    plateMidPoint = new Point(x_Point,y_Point,z_Point);




                    PolyBeam plate = new PolyBeam();
                    t3d.Point platePoint1 = new t3d.Point(plateMidPoint.X, plateMidPoint.Y, plateMidPoint.Z-z_shifting*factor);
                    t3d.Point platePoint3 = new t3d.Point(plateMidPoint.X , plateMidPoint.Y+y_shifting*factor, plateMidPoint.Z);

                    plate.AddContourPoint(new ContourPoint(platePoint1, null));
                    plate.AddContourPoint(new ContourPoint(plateMidPoint, null));
                    plate.AddContourPoint(new ContourPoint(platePoint3, null));
                    plate.Profile.ProfileString = "PL10*200";
                    plate.Material.MaterialString = "A36";

                    plate.Insert();

                }
                #endregion



            }


            #endregion



            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlan);
            myModel.CommitChanges();
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

    }
}
