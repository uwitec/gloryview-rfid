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
using GloryView.RFID.RoomManagement.Rooms;
using System.Data;
using GloryView.RFID.Utilities;
using GloryView.RFID.PageControl;
using MySql.Data.MySqlClient;
using GloryView.RFID.ReaderAndWriterClass;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// EquipmentList.xaml 的交互逻辑
    /// </summary>
    public partial class EquipmentList : UserControl
    {
        public EquipmentList()
        {
            InitializeComponent();
        }

       

        private void Equipment_Details(object sender, RoutedEventArgs e)
        {
            RoomClass rc = new RoomClass();
            var a = this.equipment.SelectedItem;
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
                    war.number.Text =reader["NUMBER"].ToString();
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
                    war.sweepTime.Text = reader["SWEEP_TIME"].ToString() + " 秒";
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
        }

        private void Search_Equipment(object sender, RoutedEventArgs e)
        {
            //int type=int.Parse(this.type.SelectedValue.ToString());
            ComboBoxItem item = (ComboBoxItem)this.type.SelectedItem;
            EquipmentBean bean = new EquipmentBean();
            if (!item.Tag.ToString().Equals(""))
            {
                bean.Type = (int)item.Tag;
                
            }
            bean.Number = this.number.Text;
            RoomClass rc = new RoomClass();
           
            DataSet equipmentSet = rc.queryEquipmentList(bean);
            //MessageBox.Show("===" + equipmentSet.Tables[0].Rows.Count);
            //if (equipmentSet.Tables[0].Rows.Count == 0)
            //{
            //    JXMessageBox.Show(Window.GetWindow(this), "搜索记录为空!", MsgImage.Exclamation);
            //}
            RoomManagerBean.EquipmentList.page.ShowPages(RoomManagerBean.EquipmentList.equipment, equipmentSet, BaseRequest.PAGE_SIZE);
            
        }

    }
}
