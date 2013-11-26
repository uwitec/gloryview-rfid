using System;
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

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// OldEquipment.xaml 的交互逻辑
    /// </summary>
 
    public partial class OldEquipment : UserControl
    {
        public List<NewRoom> roomgate = new List<NewRoom>();
        public ContextMenu cmenu = new ContextMenu();
        public string rfid;//分配的设备RFID号
        public string RFID;//机柜
        public string servertype;//服务器类型
        public string roomname;//服务器所在机房名
        public OldEquipment()
        {
            InitializeComponent();
        }

        public void setmessege(string s1,string s2)
        {
            rfid = s1;
            roomname = s2;
            this.label3.Content = "RFID编号：" + s1;
            this.label1.Content = s2 + "机房" ;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {  
            
            this.FurnitureContainer2.Children.Clear();
            roomgate.Clear();
            Getxmal xmal = new Getxmal("2.xml");
            xmal.scenelayout(ref roomgate);
            NewRoom room = roomgate[0];

            foreach (ModelWall wall in room.walls)
            {
                this.FurnitureContainer2.Children.Add(wall);
            }
            for (int i = 0; i < room.myStore.Count; i++)
            {
                ModelObject ex = (ModelObject)room.myStore.GetByIndex(i);
                room.myStore.GetKey(i).ToString();

                this.FurnitureContainer2.Children.Add(ex);
            }

            for (int i = 0; i < room.myStore.Count; i++)
            {
                ModelObject ex = (ModelObject)room.myStore.GetByIndex(i);
                int type = 0;
                type = ex.type;

                if (type == 2)
                {
                    int servercout = Convert.ToInt32(comboBox1.Text);
                    int cout = 0;
                    for (int j = 0; j < ex.usize.Length; j++)// 从头循环
                    {
                        if (ex.usize[j] == "0")
                        {
                            cout++;
                        }
                        else
                        {
                            cout = 0;
                        }
                        if ((servercout + 2) <= cout)
                        {
                            //ex.selected = 1;
                            //ex.cabinetmaterial.Brush = Brushes.Red;
                            //ex.cabinetbackmaterial.Brush = Brushes.Red;
                            break;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)//取消按钮
        {
            NewEquipment s1 = DeviceMigrationsFactory.NewEquipment;
            if (s1.addequipment.Children.Contains(addusetrol))
            {
                addusetrol.FurnitureContainer2.Children.Clear();
                s1.addequipment.Children.Remove(addusetrol);
            }
        }

        private void rightleftdown(object sender, MouseButtonEventArgs args)
        {
            Viewport3D viewport = (Viewport3D)sender;
            Point mouseposition = args.GetPosition(viewport);
            HitTestResult HitTestResult = VisualTreeHelper.HitTest(viewport, mouseposition);
            cmenu.Items.Clear();
            viewport.ContextMenu = null;
            if (HitTestResult != null)
            {
                var visual3D = HitTestResult.VisualHit as ModelObject;
                if (FurnitureContainer2.Children.Contains(visual3D))
                {
                    if ((visual3D.type == 2)&&(visual3D.selected==1))
                    {
                        RFID = visual3D.RFID;
                        //rfid = textBox2.Text;
                        cmenu.Visibility = Visibility.Visible;
                        MenuItem itemA = new MenuItem()
                        {
                            Header = "选择机柜放置"
                        };
                        //MenuItem itemB = new MenuItem()
                        //{
                        //    Header = "移除服务器"
                        //};
                        itemA.Click += addMenuItemClick;
                        cmenu.Items.Add(itemA);
                        //cmenu.Items.Add(itemB);
                        viewport.ContextMenu = cmenu;
                    }
                }
            }

        }

        private void addMenuItemClick(object sender, RoutedEventArgs e)//增加菜单
        {
            Addserver add = DeviceMigrationsFactory.Addserver;
            servertype = comboBox1.Text;
            MessageBox.Show(rfid);
            add.setmessge(RFID, rfid, servertype);
            
            grid.Children.Add(add);
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            servertype = comboBox1.Text;
        }
    }
}
