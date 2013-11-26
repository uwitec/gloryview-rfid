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
using GloryView.RFID.DeviceMigrations.DeviceClass;
using MySql.Data.MySqlClient;
using GloryView.RFID.RoomManagement.Rooms;
using System.Data;
using GloryView.RFID.Utilities;
using GloryView.RFID.ReaderAndWriterClass;
using GloryView.RFID.PageControl;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// NewEquipment.xaml 的交互逻辑
    /// </summary>
    public partial class NewEquipment : UserControl
    {
        public event ClickEventHandler MyEvent;
        public List<NewRoom> roomgate = new List<NewRoom>();
        public NewEquipment()
        {
            InitializeComponent();
            //this.addd2.Children.Add(new SearchControl());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var a = this.comingGrild.SelectedItem;
            var b = a as DataRowView;

            string id = (Convert.ToInt32(b.Row[0])).ToString();
            string name5 = (string)(b.Row[4]);
            addposition window = new addposition();
            window.MyEvent += new ClickEventHandler(form_MyEvent);
            window.setmessege(id, name5);
            window.Owner = Window.GetWindow(this);
            window.ShowDialog();


        }

        private void form_MyEvent()
        {
            MyEvent();
        }
        //录入设备
        private void Add_NewEquipment(object sender, RoutedEventArgs e)
        {
            AddEquipment add = new AddEquipment(); ;
            EquipmentClass equip = new EquipmentClass();
            RoomClass room = new RoomClass();
            MySqlDataReader roomReader = room.queryRoomsName();
            MySqlDataReader typeReader = room.getTypeList();
            MySqlDataReader reader = equip.getMaxId();
            if (reader.Read())
            {
                // ReaderAndWriterConnection EpcNumber = new ReaderAndWriterConnection();
                int i = 1;
                if (reader["ID"].ToString().Equals("") || reader["ID"] == null)
                {

                    add.ID.Content = i;

                    add.numberStr.Text = ReaderAndWriterConnection.getEPCCode(i);

                }
                else
                {
                    add.ID.Content = reader["ID"];
                    add.numberStr.Text = ReaderAndWriterConnection.getEPCCode(int.Parse(reader["ID"].ToString()));

                }
            }
            ComboBox rooms = add.roomBox;
            ComboBoxItem check = new ComboBoxItem();
            check.Content = "请选择...";
            check.Tag = "";
            check.IsSelected = true;
            rooms.Items.Add(check);
            while (roomReader.Read())
            {
                check = new ComboBoxItem();
                check.Content = roomReader["ROOM_NAME"];
                check.Tag = roomReader["ID"];
                rooms.Items.Add(check);
            }
            ComboBox types = add.typeBox;
            ComboBoxItem checkType = new ComboBoxItem();
            checkType.Content = "请选择...";
            checkType.Tag = "";
            checkType.IsSelected = true;
            types.Items.Add(checkType);
            while (typeReader.Read())
            {
                if (int.Parse(typeReader["ID"].ToString()) == 4)
                {
                    continue;
                }
                else
                {
                    ComboBoxItem TypeItems = new ComboBoxItem();
                    TypeItems.Content = typeReader["TYPE_NAME"];
                    TypeItems.Tag = typeReader["ID"];
                    types.Items.Add(TypeItems);
                }
            }
            add.Owner = Window.GetWindow(this);
            add.ShowDialog();
        }
        //编辑新添加设备
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditEquipments edit = new EditEquipments();
            var a = this.comingGrild.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            EquipmentClass _Eclass = new EquipmentClass();
            RoomClass room = new RoomClass();
            MySqlDataReader reader = _Eclass.editNewEquipment(_Eid);
            ComboBox rooms = edit.roomBox;
            ComboBoxItem roomItem = new ComboBoxItem();
            if (reader.Read())
            {
                edit.ID.Content = reader["ID"];
                edit.numberStr.Text = reader["NUMBER"].ToString();
                edit.Ename.Text = reader["NAME"].ToString();
                edit.Etype.Content = reader["TYPE_NAME"];
                roomItem.Content = reader["ROOM_NAME"];
                roomItem.Tag = reader["RID"];
                roomItem.IsSelected = true;
                rooms.Items.Add(roomItem);
                edit.UserName.Content = reader["USER_NAME"];
                edit.CreateTime.Content = Convert.ToDateTime(reader["STORAGE_TIME"]).ToString(BaseRequest.DATE_TIME_FORMAT);
            }

            MySqlDataReader roomReader = room.queryRoomsName();
            while (roomReader.Read())
            {
                if (!reader["RID"].ToString().Equals(roomReader["ID"].ToString()))
                {
                    roomItem = new ComboBoxItem();
                    roomItem.Content = roomReader["ROOM_NAME"];
                    roomItem.Tag = roomReader["ID"];
                    rooms.Items.Add(roomItem);
                }
            }
            edit.Owner = Window.GetWindow(this);
            edit.ShowDialog();
        }

        private void Repair_Equipment(object sender, RoutedEventArgs e)
        {
            EquipmentClass ec = new EquipmentClass();
            DataSet set = ec.getRepairEquipmentList();
            TakeRepairComing tr = new TakeRepairComing();
            tr.page.ShowPages(tr.repair_Grid, set, BaseRequest.PAGE_SIZE);
            //this.apply_repair.Children.Add(tr);//.Add(_Repair);
            //JXMessageBox.Show(Window.GetWindow(this)
            tr.Owner = Window.GetWindow(this);
            tr.ShowDialog();
        }

        private void Add_ReaderAndWrite(object sender, RoutedEventArgs e)
        {
            AddReaderWrider rw = new AddReaderWrider();
            EquipmentClass ec = new EquipmentClass();
            RoomClass rc = new RoomClass();
            MySqlDataReader roomReader = rc.queryRoomsName();
            ComboBox rooms = rw.roomBox;
            ComboBoxItem roomItem = new ComboBoxItem();
            roomItem.Content = "请选择...";
            roomItem.Tag = "";
            roomItem.IsSelected = true;
            rooms.Items.Add(roomItem);
            while (roomReader.Read())
            {
                roomItem = new ComboBoxItem();
                roomItem.Content = roomReader["ROOM_NAME"];
                roomItem.Tag = roomReader["ID"];
                rooms.Items.Add(roomItem);
            }
            MySqlDataReader reader = ec.getWriderMaxId();
            if (reader.Read())
            {
                if ("".Equals(reader["ID"].ToString()) || reader["ID"] == null)
                {
                    int _Ecode = 100000;
                    rw.number.Text = "100000";
                    rw.numberStr.Text = ReaderAndWriterConnection.getEPCCode(_Ecode);
                }
                else
                {
                    rw.number.Text = reader["ID"].ToString();
                    rw.numberStr.Text = ReaderAndWriterConnection.getEPCCode(int.Parse(reader["ID"].ToString()));
                }
            }
            rw.Owner = Window.GetWindow(this);
            rw.ShowDialog();
        }

       

       
       

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    DataSet set = new DataSet();
        //    DataTable table = new DataTable();
        //    DataView view = (DataView)this.comingGrild.ItemsSource;
        //    MessageBox.Show(view.Table.ToString());
        //    table = (DataTable)view.Table; 
        //    set.Tables.Add(table);
        //    DataColumn[] keys = new DataColumn[1];
        //    keys[0] = set.Tables[0].Columns["NAME"];

        //    DataRow findRow = set.Tables[0].Rows.Find(this.name);
        //    if (findRow == null)
        //    {
        //        MessageBox.Show("没有找到");
        //    }
        //    else
        //    {
        //        MessageBox.Show("成功找到,CNAME = " + findRow["NAME"]);
        //    } 
        //}
    }
}
