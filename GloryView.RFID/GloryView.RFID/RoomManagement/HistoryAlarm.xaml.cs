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
using GloryView.RFID.PrintDocument;
using GloryView.RFID.RoomManagement.Rooms;
using MySql.Data.MySqlClient;
using System.Data;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// HistoryAlarm.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryAlarm : UserControl
    {
        public HistoryAlarm()
        {
            InitializeComponent();
        }

        private void Alarm_Details(object sender, RoutedEventArgs e)
        {
            
        }

        private void Report(object sender, RoutedEventArgs e)
        {
            Export_Window ew = new Export_Window();
            ew.Owner = Window.GetWindow(this);
            ew.ShowDialog();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            RoomClass rc=new RoomClass();
            var a = this.alarmGrid.SelectedItem;
            var b = a as DataRowView;
            int _Aid = Convert.ToInt32(b.Row[0]);
            MySqlDataReader reader = rc.getHistoryAlarmImformation(_Aid);
            AlarmDetails ad = new AlarmDetails();
            TextRange _Text = new TextRange(ad.Information.Document.ContentStart, ad.Information.Document.ContentEnd);
            if (reader.Read())
            {
                ad.number.Text = reader["NUMBER"].ToString();
                ad.Ename.Text = reader["NAME"].ToString();
                ad.Etype.Text = reader["TYPE_NAME"].ToString();
                ad.Atype.Text = reader["ALARM_TYPE_NAME"].ToString();
                ad.room.Text = reader["ROOM_NAME"].ToString();
                ad.Handle_User.Text = reader["USER_NAME"].ToString();
                ad.Handle_Time.Text = reader["PROCESSING_TIME"].ToString();
                ad.Alarm_Time.Text = reader["ALARM_TIME"].ToString();
                _Text.Text = reader["REMARK"].ToString();
                ad.title.Content = reader["NUMBER"] + "  历史报警信息：";
            }
            
            ad.Owner = Window.GetWindow(this);
            ad.ShowDialog();
        }
    }
}
