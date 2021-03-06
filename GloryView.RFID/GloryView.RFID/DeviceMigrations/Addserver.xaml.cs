﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// Addserver.xaml 的交互逻辑
    /// </summary>
    /// 
    public delegate void MyDelegate();
    public partial class Addserver : UserControl
    {
        public string servertype;
        public int aservertype;
        public string RFID;
        public string rfid;
        public string position;
        public int aposition;

        public List<NewRoom> roomgate = new List<NewRoom>();
        public ModelObject server = new ModelObject();
        public ModelObject servercabinet = new ModelObject();
        public event MyDelegate MyEvent;
        public Addserver()
        {
            InitializeComponent();
            aposition = 0;
        }

        private void upclick(object sender, RoutedEventArgs e)
        {     
            //上移
            if (aposition < 42)
            {
                this.textBox3.Text = server.translate.OffsetY.ToString();
                server.Move(-1.5, server.translate.OffsetY + 0.2, 0, 0);
                aposition = Convert.ToInt32((server.translate.OffsetY + 5) / 0.2);
                position = aposition.ToString();
                this.textBox2.Text = server.translate.OffsetY.ToString();
                this.textBox1.Text = position;
            }
        }


        private void  downclick(object sender, RoutedEventArgs e)
        {   //下移
            if (aposition>1)
            {
                this.textBox3.Text = server.translate.OffsetY.ToString();
                server.Move(-1.5, server.translate.OffsetY - 0.2, 0, 0);
                aposition = Convert.ToInt32((server.translate.OffsetY + 5) / 0.2);
                position = aposition.ToString();
                this.textBox2.Text = server.translate.OffsetY.ToString();
                this.textBox1.Text = position;
            }
        }

        public void setmessge(string s1, string s2, string s3)
        {
            RFID = s1;
            rfid = s2;
            servertype = s3;
            aservertype = Convert.ToInt32(s3);
            this.FurnitureContainer3.Children.Clear();
            Getxmal xmal = new Getxmal("2.xml");
            xmal.scenelayout(ref roomgate);
            NewRoom room = roomgate[0];

            for (int i = 0; i < room.myStore.Count; i++)
            {
                ModelObject ex = (ModelObject)room.myStore.GetByIndex(i);
                string RFID1 = room.myStore.GetKey(i).ToString();
                string parentrfid = ex.parentrfid;
                if ((RFID1 == RFID) || (parentrfid == RFID))
                {
                    if (ex.type==2)
                    {
                        servercabinet = ex;
                    }
                    ex.Move(-1.5, ex.translate.OffsetY - 5, 0, 0);
                    this.FurnitureContainer3.Children.Add(ex);
                }               
            }

            server.RFID = rfid;
            server.server(1.5, 0.2 * aservertype, 0.95);
            int cout = 0;
            for (int j = 0; j <= servercabinet.usize.Length; j++)// 从头循环
            {
                if (servercabinet.usize[j] == "0")
                {
                    cout++;
                }
                else
                {
                    cout = 0;
                }
                if (aservertype <= (cout - 2))
                {
                    server.Move(-1.5, ((j + 2 - aservertype) * 0.2 - 5), 0, 0);
                    aposition = Convert.ToInt32((server.translate.OffsetY + 5) / 0.2);
                    break;
                }
            }
           
            this.FurnitureContainer3.Children.Add(server);
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            OldEquipment s1 = DeviceMigrationsFactory.OldEquipment;
            if (s1.grid.Children.Contains(addserver))
            {
                this.FurnitureContainer3.Children.Clear();
                roomgate.Clear();
                s1.grid.Children.Remove(addserver);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Getxmal xmal = new Getxmal("2.xml");
            //这里需要判断放的位置是否能满足要求
            MessageBox.Show(position);

            for (int i = 0; i <= aservertype; i++)
            {
                if (servercabinet.usize[aposition - 1 + i] == "1")
                {
                    MessageBox.Show("此位置已被占用");
                    return;
                }
            }
            if (servercabinet.usize[aposition - 2] == "1")
            {
                MessageBox.Show("此位置已被占用");
                return;
            }

            if (servercabinet.usize[aposition + aservertype - 1] == "1")
            {
                MessageBox.Show("此位置已被占用");
                return;
            }
            MessageBox.Show(rfid);
            xmal.addnode(RFID, rfid, position, servertype);

            string sql = "UPDATE equipment  SET Position='" + @position + "' WHERE ID=" + @rfid;
            MySqlParameter[] _Parameters =
                {
                    new MySqlParameter("@position", position),
                    new MySqlParameter("@rfid", rfid)
                };
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, _Parameters);
            NewEquipment s1 = DeviceMigrationsFactory.NewEquipment;
            OldEquipment s2 = DeviceMigrationsFactory.OldEquipment;
            s2.grid.Children.Remove(addserver);
            s2.FurnitureContainer2.Children.Clear();
            s1.addequipment.Children.Remove(s2);
            MyEvent();
        }
    }
}
