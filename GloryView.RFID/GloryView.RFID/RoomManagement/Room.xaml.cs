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
using System.Data;
using GloryView.RFID.RoomManagement.Rooms;
using MySql.Data.MySqlClient;
using GloryView.RFID.ReaderAndWriterClass;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// Room.xaml 的交互逻辑
    /// </summary>
    public partial class Room : UserControl
    {
        public Room()
        {
            InitializeComponent();
        }

        private void Add_Device(object sender, MouseButtonEventArgs e)
        {
            AddEquipment equip = RoomManagerBean.AddEquipment;
            if (add_Equ.Children.Contains(equip))
            {
                equip.Visibility = Visibility.Visible;
            }
            else
            {
                add_Equ.Children.Add(equip);
                equip.Name = "equip";
                equip.addRoomName.Content = roomName.Content;
            }
        }

        //private void Equipment_Details(object sender, RoutedEventArgs e)
        //{
        //    EquipmentDetails equipmentDetails = RoomManagerBean.EquipmentDetails;
        //   // MessageBox.Show(add_Equ.Children.Contains(equipmentDetails).ToString());
        //    if (add_Equ.Children.Contains(equipmentDetails))
        //    {
        //        equipmentDetails.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        add_Equ.Children.Add(equipmentDetails);
        //        equipmentDetails.Name = "equipmentDetails";
        //    }
        //}
        //查询设备详细信息
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            RoomClass rc=new RoomClass();
            var a = this.roomEquipment.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            int _TypeId = Convert.ToInt32(b.Row[1]);
            MySqlDataReader reader;
            if (_TypeId == 4)//如果设备类型等于4，则为读写器
            {
                reader = rc.getWriteAndReaderInformation(_Eid);
                if (reader.Read())
                {
                    WriteAndReaderInfo war = new WriteAndReaderInfo();
                    war.number.Text = reader["NUMBER"].ToString();
                    war.Ename.Text = reader["NAME"].ToString();
                    war.Etype.Text = reader["TYPE_NAME"].ToString();
                    war.room.Text = reader["ROOM_NAME"].ToString();
                    war.ip.Text = reader["IP"].ToString();
                    war.port.Text = reader["PORT"].ToString();
                    war.antenenSum.Text = reader["ANTENNA_SUM"].ToString();
                    if (int.Parse(reader["TYPE"].ToString()) == 0)
                    {
                        war.type.Text = "门禁读写器";

                    }
                    else
                    {
                        war.type.Text = "室内读写器";
                    }
                    war.sweepTime.Text = reader["SWEEP_TIME"].ToString()+" 秒";
                    war.userName.Text = reader["USER_NAME"].ToString();
                    war.createTime.Text = reader["CREATE_TIME"].ToString();
                    war.Owner = Window.GetWindow(this);
                    war.ShowDialog();
                }
            }
            else
            {
                reader = rc.getEquipmentInfo(_Eid);
                if (reader.Read())
                {
                    EquipmentsDetails ed = new EquipmentsDetails();
                    ed.number.Text = reader["NUMBER"].ToString();
                    ed.Ename.Text = reader["NAME"].ToString();
                    ed.Etype.Text = reader["TYPE_NAME"].ToString();
                    int status = int.Parse(reader["WORK_STATUS"].ToString());
                    if (status == 1)
                    {
                        ed.status.Text = "入库中";
                    }
                    else if (status == 0)
                    {
                        ed.status.Text = "正常使用";
                    }
                    else if (status == 15)
                    {
                        ed.status.Text = "保修中";
                    }
                    ed.room.Text = reader["ROOM_NAME"].ToString();
                    if (int.Parse(reader["POWER_SOURCE"].ToString()) == 0)
                    {
                        ed.powerSource.Text = "开";
                        //ed.powerSource.Foreground = Brush.TransformProperty;
                    }
                    else
                    {
                        ed.powerSource.Text = "关";
                    }
                    ed.userName.Text = reader["USER_NAME"].ToString();
                    ed.time.Text = reader["STORAGE_TIME"].ToString();
                    ed.Owner = Window.GetWindow(this);
                    ed.ShowDialog();
                }
            }
            //MySqlDataReader reader = rc.getHistoryAlarmImformation(_Aid);
            
        }
        //编辑设备信息
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            RoomClass rc=new RoomClass();
            var a = this.roomEquipment.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            int _TypeId = Convert.ToInt32(b.Row[1]);
            MySqlDataReader reader;
            if (_TypeId == 4)
            {
                reader = rc.getWriteAndReaderInformation(_Eid);
                if (reader.Read())
                {
                    EditWriteAndReader ear = new EditWriteAndReader();
                    ear.ID.Content = reader["READER_WRITER_ID"];
                    ear.numberStr.Text =reader["NUMBER"].ToString();
                    ear.Ename.Text = reader["NAME"].ToString();
                    ear.Etype.Text = reader["TYPE_NAME"].ToString();
                    ear.room.Text = reader["ROOM_NAME"].ToString();
                    ear.ip.Text = reader["IP"].ToString();
                    ear.port.Text = reader["PORT"].ToString();
                    ear.antenenSum.Text = reader["ANTENNA_SUM"].ToString();
                    if (int.Parse(reader["TYPE"].ToString()) == 0)
                    {
                        ear.type.SelectedIndex = 0;

                    }
                    else
                    {
                        ear.type.SelectedIndex = 1;
                    }
                    ear.sweepTime.Text = reader["SWEEP_TIME"].ToString();
                    ear.userName.Text = reader["USER_NAME"].ToString();
                    ear.createTime.Text = reader["CREATE_TIME"].ToString();
                    ear.Owner = Window.GetWindow(this);
                    ear.ShowDialog();
                }

            }
            else
            {
                 reader = rc.getEquipmentInfo(_Eid);
                if (reader.Read())
                {
                    EditEquipment ed = new EditEquipment();
                    ed.ID.Content = reader["ID"];
                    ed.numberStr.Text = reader["NUMBER"].ToString();
                    ed.Ename.Text = reader["NAME"].ToString();
                    //ed.Etype.Text = reader["TYPE_NAME"].ToString();
                    int status = int.Parse(reader["WORK_STATUS"].ToString());
                    if (status == 1)
                    {
                        ed.status.Text = "入库中";
                    }
                    else if (status == 0)
                    {
                        ed.status.Text = "正常使用";
                    }
                    else if (status == 15)
                    {
                        ed.status.Text = "保修中";
                    }
                    ed.room.Text = reader["ROOM_NAME"].ToString();
                    if (int.Parse(reader["POWER_SOURCE"].ToString()) == 0)
                    {
                        ed.powerSource.Text = "开";
                        //ed.powerSource.Foreground = Brush.TransformProperty;
                    }
                    else
                    {
                        ed.powerSource.Text = "关";
                    }
                    ed.userName.Text = reader["USER_NAME"].ToString();
                    ed.time.Text = reader["STORAGE_TIME"].ToString();
                    reader = rc.getTypeList();
                    ComboBox types = ed.Etype;
                    ComboBoxItem TypeItems;
                    while (reader.Read())
                    {
                        if (int.Parse(reader["ID"].ToString()) != 4)
                        {
                            TypeItems = new ComboBoxItem();
                            TypeItems.Content = reader["TYPE_NAME"];
                            TypeItems.Tag = reader["ID"];
                            if (int.Parse(reader["ID"].ToString()) == _TypeId)
                                TypeItems.IsSelected = true;
                            types.Items.Add(TypeItems);
                        }
                    }
                    
                    ed.Owner = Window.GetWindow(this);
                    ed.ShowDialog();
                }
            }
        }
    }
}
