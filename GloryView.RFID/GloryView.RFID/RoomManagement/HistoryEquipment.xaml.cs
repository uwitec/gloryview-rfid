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
using GloryView.RFID.ReaderAndWriterClass;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// HistoryEquipment.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryEquipment : UserControl
    {
        public HistoryEquipment()
        {
            InitializeComponent();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            RoomClass rc = new RoomClass();
            var a = this.historyEquipment.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            MySqlDataReader reader=rc.queryHistoryEquipmentInformation(_Eid);
            HistoryEquipmentDetails _Details = new HistoryEquipmentDetails();
            if (reader.Read())
            {
                _Details.number.Text = reader["NUMBER"].ToString();
                _Details.name.Text=reader["NAME"].ToString();
                _Details.type.Text = reader["TYPE_NAME"].ToString();
                _Details.room.Text = reader["ROOM_NAME"].ToString();
                _Details.takeUser.Text = reader["TAKE_NAME"].ToString();
                _Details.takeTime.Text = Convert.ToDateTime(reader["TAKE_TIME"]).ToString(BaseRequest.DATE_MS_FORMAT);
                _Details.userName.Text = reader["USER_NAME"].ToString();
                _Details.time.Text = Convert.ToDateTime(reader["STORAGE_TIME"]).ToString(BaseRequest.DATE_MS_FORMAT);
            }
            _Details.Owner = Window.GetWindow(this);
            _Details.ShowDialog();
        }
    }
}
