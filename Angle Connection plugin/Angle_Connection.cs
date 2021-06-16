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
        [StructuresField("positive_Y")]
        public double positive_Y = 20.0;
        [StructuresField("positive_X")]
        public double positive_X = 20.0;
        [StructuresField("negative_X")]
        public double negative_X = 20.0;
        [StructuresField("negative_Y")]
        public double negative_Y = 20.0;
        [StructuresField("offset")]
        public double offset = 20.0;
        [StructuresField("Plate_b")]
        public double Plate_b = 100.0;
        [StructuresField("Plate_h")]
        public double Plate_h = 6.0;
        [StructuresField("Pos_1")]
        public string Pos_1 = "W";
        [StructuresField("Plate_pos2")]
        public int Plate_pos2 = 100;
        [StructuresField("Plate_matrial")]
        public string Plate_matrial = "aa";
        [StructuresField("Plate_name")]
        public string Plate_name = "SSSS";
        [StructuresField("holeDiam")]
        public double holeDiam = 50.0;
        [StructuresField("hole_L")]
        public double hole_L = 50.0;
        [StructuresField("hole_w")]
        public double hole_w = 50.0;
        [StructuresField("weld_aboveline")]
        public double weld_aboveline = 6.0;
        [StructuresField("weld_belowline")]
        public double weld_belowline = 6.0;
        [StructuresField("holeType")]
        public int holeType = 0;
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
            Part part = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick Main Part") as Part;
            ModelObjectEnumerator objectEnumerator = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS, "Pick Secendries");
            ArrayList _Input = new ArrayList();
            while (objectEnumerator.MoveNext())
            {
                Part current = objectEnumerator.Current as Part;
                Identifier identifier = current.Identifier;
                if (current != null)
                    _Input.Add((object)identifier);
            }
            PluginBase.InputDefinition inputDefinition1 = new PluginBase.InputDefinition(part.Identifier);
            PluginBase.InputDefinition inputDefinition2 = new PluginBase.InputDefinition(_Input);
            inputDefinitionList.Add(inputDefinition1);
            inputDefinitionList.Add(inputDefinition2);
            return inputDefinitionList;
        }

        public override bool Run(List<PluginBase.InputDefinition> Input)
        {
            try
            {
                if (this.IsDefaultValue(this.data.positive_Y))
                    this.data.positive_Y = 30.0;
                if (this.IsDefaultValue(this.data.positive_X))
                    this.data.positive_X = 30.0;
                if (this.IsDefaultValue(this.data.negative_X))
                    this.data.negative_X = 30.0;
                if (this.IsDefaultValue(this.data.negative_Y))
                    this.data.negative_Y = 30.0;
                if (this.IsDefaultValue(this.data.offset))
                    this.data.offset = 0.0;
                if (this.IsDefaultValue(this.data.Plate_b))
                    this.data.Plate_b = 100.0;
                if (this.IsDefaultValue(this.data.Plate_h))
                    this.data.Plate_h = 6.0;
                if (this.IsDefaultValue(this.data.Pos_1))
                    this.data.Pos_1 = "W";
                if (this.IsDefaultValue(this.data.Plate_pos2))
                    this.data.Plate_pos2 = 101;
                if (this.IsDefaultValue(this.data.Plate_matrial))
                    this.data.Plate_matrial = "A36";
                if (this.IsDefaultValue(this.data.Plate_name))
                    this.data.Plate_name = "Plate";
                if (this.IsDefaultValue(this.data.holeDiam))
                    this.data.holeDiam = 500.0;
                if (this.IsDefaultValue(this.data.hole_L))
                    this.data.hole_L = 20.0;
                if (this.IsDefaultValue(this.data.hole_w))
                    this.data.hole_w = 20.0;
                if (this.IsDefaultValue(this.data.weld_aboveline))
                    this.data.weld_aboveline = 6.0;
                if (this.IsDefaultValue(this.data.weld_belowline))
                    this.data.weld_belowline = 6.0;
                if (this.IsDefaultValue(this.data.holeType))
                    this.data.holeType = 0;
                this.createconnection((Part)this.myModel.SelectModelObject((Identifier)Input[0].GetInput()), (ArrayList)Input[1].GetInput());

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
            return true;
        }

        public void createconnection(Part main, ArrayList secondries)
        {
            foreach (Identifier secondry in secondries)
            {

            }
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

        private BoltArray InsertBolt(Point platePoint1, Point plateMidPoint, Part mainPart, Part plate, double dx, double boltSize,
            double tolerance, string boltStandard, int no_bolt_x, int no_bolt_y, string spacing_x, string spacing_y)
        {
            BoltArray boltArrayWithMain = new BoltArray();
            boltArrayWithMain.FirstPosition = plateMidPoint;
            boltArrayWithMain.SecondPosition = platePoint1;
            boltArrayWithMain.PartToBeBolted = plate;
            boltArrayWithMain.PartToBoltTo = mainPart;

            string[] spacing_X_array = spacing_x.Split(' ');
            string[] spacing_Y_array = spacing_y.Split(' ');
            for (int i = 0; i < no_bolt_x - 1; i++)
            {
                boltArrayWithMain.AddBoltDistX(double.Parse(spacing_X_array[i]));

            }
            for (int i = 0; i < no_bolt_y - 1; i++)
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





    }
}