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
using GloryView.RFID.SystemManagement.SystemClass;
using System.Data;
using MySql.Data.MySqlClient;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.SystemManagement
{
    /// <summary>
    /// MovedDevicesLog.xaml 的交互逻辑
    /// </summary>
    public partial class MovedDevicesLog : UserControl
    {
        public MovedDevicesLog()
        {
            InitializeComponent();
        }

        private void HistoryOrder_Click(object sender, RoutedEventArgs e)
        {
            SystemManager sm = new SystemManager();
            var a = this.EquiplogGrid.SelectedItem;
            var b = a as DataRowView;
            int _LogId = Convert.ToInt32(b.Row[0]);
            OperationEquipmentInfo opi = new OperationEquipmentInfo();
            MySqlDataReader reader = sm.getEquipmentInfo(_LogId);
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    opi.number.Text = reader["NUMBER"].ToString();
                    opi.Ename.Text = reader["NAME"].ToString();
                    opi.Etype.Text = reader["TYPE_NAME"].ToString();
                    opi.room.Text = reader["ROOM_NAME"].ToString();
                    opi.Otype.Text = OperationTypeString.getTypeStr(int.Parse(reader["TYPE"].ToString()));
                    opi.Ouser.Text = reader["ACCOUNT"].ToString();
                    opi.Etime.Text = Convert.ToDateTime(reader["STORAGE_TIME"]).ToString(BaseRequest.DATE_MS_FORMAT);
                    opi.Otime.Text = Convert.ToDateTime(reader["DATE_TIME"]).ToString(BaseRequest.DATE_MS_FORMAT);
                }
                opi.Owner = Window.GetWindow(this);
                opi.ShowDialog();
            }
        }
    }
}
