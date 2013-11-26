using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Windows;
namespace GloryView.RFID
{
   public class Getxmal
    {
        private string xmlname;

        public Getxmal(string filename)
        {
            xmlname = filename;
        }

        public void scenelayout(ref List<NewRoom> rooms)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlname);
            XmlNodeList roomnodes = xmldoc.GetElementsByTagName("RoomNo");
            if (roomnodes != null)
            {
                foreach (XmlNode roomnode in roomnodes)
                {
                    NewRoom room = new NewRoom();
                    room.roomname = roomnode.Attributes["Name"].Value;
                    XmlNodeList typenodes = roomnode.ChildNodes;
                    foreach (XmlNode typenode in typenodes)
                    {
                        if (typenode.Name == "Ground")
                        {
                            XmlNodeList nodes = typenode.ChildNodes;
                            foreach (XmlNode node in nodes)
                            {
                                string name = node.Attributes["Name"].Value;
                                string positon;
                                string size;
                                if (name == "Floor")
                                {
                                    size = node.SelectSingleNode("SizeParam").InnerXml;
                                    positon = node.SelectSingleNode("Position").InnerXml;
                                    room.setfloor(size, positon);
                                }
                                else if (name == "Outwall")
                                {
                                    size = node.SelectSingleNode("SizeParam").InnerXml;
                                    positon = node.SelectSingleNode("Position").InnerXml;
                                    room.setoutwall(size, positon);
                                }
                                else if (name == "Inwall")
                                {
                                    size = node.SelectSingleNode("SizeParam").InnerXml;
                                    positon = node.SelectSingleNode("Position").InnerXml;
                                    room.setinwall(size, positon);
                                }
                            }
                        }
                        else if (typenode.Name == "Device")
                        {
                            XmlNodeList nodes = typenode.ChildNodes;
                            
                            foreach (XmlNode node in nodes)
                            {
                                string RFID = node.Attributes["RFID"].Value;
                                string positon = node.Attributes["Position"].Value;
                                
                                if (node.Name == "Cabinet")
                                {                                   
                                    XmlNodeList unodes = node.ChildNodes;                               
                                    string[] statues = new string[42];
                                    for (int j = 0; j < 42;j++ )
                                    {
                                        statues[j] = "0";
                                    }
                                    foreach (XmlNode unode in unodes)
                                    {
                                        if (unode.Name=="Server")
                                        {
                                            string URFID = unode.Attributes["RFID"].Value;
                                            string UPosition = unode.Attributes["Position"].Value;
                                            string UType = unode.Attributes["Type"].Value;
                                            int tt = Convert.ToInt32(UPosition)-1;
                                            int yy = Convert.ToInt32(UType);
                                            for (int i = 0; i < yy;i++ )
                                            {
                                                statues[tt + i] = "1";
                                            }
                                            room.setserver(yy, positon, URFID,RFID,tt);
                                        }
                                    }
                                    room.setcabinet(statues, positon,RFID);
                                }
                                else if (node.Name == "Ups")
                                {
                                    room.setups(positon, RFID);
                                }
                                else if (node.Name == "Air")
                                {
                                    room.setaircondition(positon, RFID);
                                }
                            }
                        }
                    }
                    rooms.Add(room);
                }
            }
        }


        public void addnode(string s1,string s2,string s3,string s4)//机柜RFID,服务器RFID，服务器position,服务器type
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlname);
            XmlNode root = xmldoc.DocumentElement;//获得根节点	
            foreach (XmlNode itemss in root.ChildNodes)
            {
                if (itemss.Name == "RoomNo")
                {
                    foreach (XmlNode items in itemss.ChildNodes)
                    {
                        if (items.Name == "Device")
                        {
                            foreach (XmlNode item in items.ChildNodes)
                            {
                                if (item.Name == "Cabinet")
                                {
                                        string RFID11 = item.Attributes["RFID"].Value;
                                        if (RFID11==s1)
                                        {
                                            XmlElement el = xmldoc.CreateElement("Server");
                                            el.SetAttribute("RFID", s2);
                                            el.SetAttribute("Position", s3);
                                            el.SetAttribute("Type", s4);
                                            item.AppendChild(el);
                                            xmldoc.Save(xmlname);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
        }
    }
}
