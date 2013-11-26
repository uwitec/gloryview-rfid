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
using MySql.Data.MySqlClient;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// DeviceClass.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceClass : UserControl
    {
        public DeviceClass()
        {
            InitializeComponent();
        }

        private void Edit_DeviceClass(object sender, RoutedEventArgs e)
        {
            EditDeviceClass editDeviceClass =new EditDeviceClass();
            // MessageBox.Show(add_Equ.Children.Contains(equipmentDetails).ToString());
            RoomClass rc = new RoomClass();
            var a = this.deviceData.SelectedItem;
            var b = a as DataRowView;
            int typeId = Convert.ToInt32(b.Row[0]);
            MySqlDataReader reader = rc.getTypeInfor(typeId);
            
            if (reader.Read())
            {
                editDeviceClass.typeName.Text = reader["TYPE_NAME"].ToString();
                editDeviceClass.createUser.Content = reader["CREATE_USER"];
                editDeviceClass.createTime.Content = Convert.ToDateTime(reader["CREATE_TIME"]).ToString(BaseRequest.DATE_MS_FORMAT);
                editDeviceClass.id.Content = reader["ID"];
            }
            editDeviceClass.Owner = Window.GetWindow(this);
            editDeviceClass.ShowDialog();
        }

        private void Add_Category(object sender, RoutedEventArgs e)
        {

            AddDeviceClass category = new AddDeviceClass();
            // MessageBox.Show(add_Equ.Children.Contains(equipmentDetails).ToString());
            category.Owner = Window.GetWindow(this);
            category.ShowDialog();
        }
    }
}
