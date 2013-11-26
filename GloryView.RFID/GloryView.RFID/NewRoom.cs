using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace GloryView.RFID
{

    public class NewRoom
    {
        public string roomname;
        public List<ModelWall> walls = new List<ModelWall>();
        public SortedList myStore = new SortedList();
       
        public NewRoom()
        {

        }

        public void setfloor(string size, string position)
        {
            string[] Size = size.Split(',');
            string[] Position = position.Split(',');
            double x1 = System.Convert.ToDouble(Size[0]);
            double y1 = System.Convert.ToDouble(Size[1]);
            double z1 = System.Convert.ToDouble(Size[2]);
            ModelWall f1 = new ModelWall();
            f1.floor(x1,y1,z1);
            walls.Add(f1);
        }

        public void setoutwall(string size, string position)
        {
            string[] Size = size.Split(',');
            string[] Position = position.Split(',');
            double x1 = System.Convert.ToDouble(Size[0]);
            double y1 = System.Convert.ToDouble(Size[1]);
            double z1 = System.Convert.ToDouble(Size[2]);
            double x2 = System.Convert.ToDouble(Position[0]);
            double y2 = System.Convert.ToDouble(Position[1]);
            double z2 = System.Convert.ToDouble(Position[2]);
            ModelWall wa = new ModelWall();
            wa.outwall(x1, y1, z1);
            wa.Move(x2, y2, z2,0);
            walls.Add(wa);
        }

        public void setinwall(string size, string position)
        {
            string[] Size = size.Split(',');
            string[] Position = position.Split(',');
            double x1 = System.Convert.ToDouble(Size[0]);
            double y1 = System.Convert.ToDouble(Size[1]);
            double z1 = System.Convert.ToDouble(Size[2]);
            double x2 = System.Convert.ToDouble(Position[0]);
            double y2 = System.Convert.ToDouble(Position[1]);
            double z2 = System.Convert.ToDouble(Position[2]);
            ModelWall wa = new ModelWall();
            wa.inwall(x1, y1, z1);
            wa.Move(x2, y2, z2,0);
            walls.Add(wa);
        }

        public void setcabinet(string[] devicename, string position,string RFID)
        {
            ModelObject cabinet = new ModelObject();
            cabinet.servercabinet(2, 8.4, 2);
            cabinet.usize = devicename;
            cabinet.RFID = RFID;
            string[] Position = position.Split(',');
            double x1 = System.Convert.ToDouble(Position[0]);
            double y1 = System.Convert.ToDouble(Position[1]);
            double z1 = System.Convert.ToDouble(Position[2]);
            double angel = System.Convert.ToDouble(Position[3]);
            cabinet.Move(x1, y1, z1, angel);
            myStore.Add(RFID, cabinet);
        }

        public void setserver(int utype ,string position,string URFID,string RFID,int ut)
        {
            ModelObject server1 = new ModelObject();
            server1.RFID = RFID;
            server1.server(1.5, 0.2*utype, 0.95);
            string[] Position = position.Split(',');
            double x1 = System.Convert.ToDouble(Position[0]);
            double y1 = System.Convert.ToDouble(Position[1]);
            double z1 = System.Convert.ToDouble(Position[2]);
            double angel = System.Convert.ToDouble(Position[3]);
            server1.Move(x1,(ut+1+1)*0.2,z1,angel);
            server1.parentrfid = RFID;
            myStore.Add(URFID, server1);
        }
        public void setups(string position, string RFID)
        {
            ModelObject ups = new ModelObject();
            ups.RFID = RFID;
            ups.ups(1.5, 5, 1);
            string[] Position = position.Split(',');
            double x1 = System.Convert.ToDouble(Position[0]);
            double y1 = System.Convert.ToDouble(Position[1]);
            double z1 = System.Convert.ToDouble(Position[2]);
            double angel = System.Convert.ToDouble(Position[3]);
            ups.Move(x1, y1, z1, angel);
            myStore.Add(RFID, ups);
        }

        public void setaircondition(string position, string RFID)
        {
            ModelObject air = new ModelObject();
            air.RFID = RFID;
            air.aricondition(1.5, 8, 1);
            string[] Position = position.Split(',');
            double x1 = System.Convert.ToDouble(Position[0]);
            double y1 = System.Convert.ToDouble(Position[1]);
            double z1 = System.Convert.ToDouble(Position[2]);
            double angel = System.Convert.ToDouble(Position[3]);
            air.Move(x1, y1, z1, angel);
            myStore.Add(RFID, air);
        }
    }
}
