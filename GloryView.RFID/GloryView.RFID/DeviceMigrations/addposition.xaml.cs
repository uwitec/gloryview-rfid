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
using System.Windows.Shapes;
using System.Windows.Navigation;


namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// addposition.xaml 的交互逻辑
    
    public partial class addposition : Window
    {
        public List<NewRoom> roomgate = new List<NewRoom>();
        public ContextMenu cmenu = new ContextMenu();
        public string rfid;//分配的设备RFID号
        public string RFID;//机柜
        public string servertype;//服务器类型
        public string roomname;//服务器所在机房名
        public event ClickEventHandler MyEvent;
        public addposition()
        {
            InitializeComponent();
        }

        public void setmessege(string s1, string s2)
        {
            rfid = s1;
            roomname = s2;
            this.label3.Content = "RFID编号：" + s1;
            this.label1.Content = "";
            this.label1.Content = s2 + "机房";
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
                            ex.selected = 1;
                            ex.materiala[4].Brush = Brushes.Red;
                            ex.materiala[5].Brush = Brushes.Red;
                            ex.materiala[6].Brush = Brushes.Red;
                            ex.materiala[7].Brush = Brushes.Red;
                            ex.materiala[8].Brush = Brushes.Red;
                            ex.materiala[9].Brush = Brushes.Red;
                            ex.materiala[10].Brush = Brushes.Red;
                            ex.materiala[11].Brush = Brushes.Red;

                            ex.materialb[1].Brush = Brushes.Red;
                            ex.materialb[2].Brush = Brushes.Red;
                            ex.materialb[3].Brush = Brushes.Red;
                            ex.materialb[4].Brush = Brushes.Red;
                            ex.materialb[5].Brush = Brushes.Red;
                            ex.materialb[6].Brush = Brushes.Red;
                            ex.materialb[7].Brush = Brushes.Red;
                            ex.materialb[8].Brush = Brushes.Red;
                            ex.materialb[9].Brush = Brushes.Red;
                            ex.materialb[10].Brush = Brushes.Red;
                            ex.materialb[11].Brush = Brushes.Red;

                            ex.materialc[1].Brush = Brushes.Red;
                            ex.materialc[2].Brush = Brushes.Red;
                            ex.materialc[3].Brush = Brushes.Red;
                            ex.materialc[4].Brush = Brushes.Red;
                            ex.materialc[5].Brush = Brushes.Red;
                            ex.materialc[8].Brush = Brushes.Red;
                            ex.materialc[9].Brush = Brushes.Red;
                            ex.materialc[10].Brush = Brushes.Red;
                            ex.materialc[11].Brush = Brushes.Red;

                            ex.materiald[1].Brush = Brushes.Red;
                            ex.materiald[2].Brush = Brushes.Red;
                            ex.materiald[3].Brush = Brushes.Red;
                            ex.materiald[6].Brush = Brushes.Red;
                            ex.materiald[7].Brush = Brushes.Red;
                            ex.materiald[8].Brush = Brushes.Red;
                            ex.materiald[9].Brush = Brushes.Red;
                            ex.materiald[10].Brush = Brushes.Red;
                            ex.materiald[11].Brush = Brushes.Red;

                            ex.materialf[1].Brush = Brushes.Red;
                            ex.materialf[2].Brush = Brushes.Red;
                            ex.materialf[3].Brush = Brushes.Red;
                            ex.materialf[4].Brush = Brushes.Red;
                            ex.materialf[5].Brush = Brushes.Red;
                            ex.materialf[6].Brush = Brushes.Red;
                            ex.materialf[7].Brush = Brushes.Red;
                            ex.materialf[10].Brush = Brushes.Red;
                            ex.materialf[11].Brush = Brushes.Red;
                            break;
                        }
                    }
                }
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
                    if ((visual3D.type == 2) && (visual3D.selected == 1))
                    {
                        RFID = visual3D.RFID;
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
            servertype = comboBox1.Text;
            addwindow window = new addwindow();
            window.MyEvent += new ClickEventHandler(form_MyEvent);   
            servertype = comboBox1.Text;
            window.setmessge(RFID, rfid, servertype);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();
        }

        private void form_MyEvent()
        {
            MyEvent();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            servertype = comboBox1.Text;
        }
    }
}
