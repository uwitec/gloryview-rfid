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
using GloryView.RFID.PageControl;
using GloryView.RFID.RoomManagement.Rooms;
using System.Data;
using GloryView.RFID.PrintDocument;
using GloryView.RFID.Utilities;
using MySql.Data.MySqlClient;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// Alarm.xaml 的交互逻辑
    /// </summary>
    public partial class Alarm : UserControl
    {
        public Alarm()
        {
            InitializeComponent();
        }

        private void Alarm_Details(object sender, RoutedEventArgs e)
        {
           
        }

        private void Ignore_Alarm(object sender, RoutedEventArgs e)
        {
            string msg = "您确定忽略该条报警？";
            MsgResult r = JXMessageBox.Show(Window.GetWindow(this), msg, "提示", MsgButton.Yes_No_Cancel, MsgImage.Exclamation);
            if (r == MsgResult.Yes)
            {
                JXMessageBox.Show(Window.GetWindow(this), "点击确定", MsgImage.Warning);

            }
            
        }

      
        //警报处理
        private void Treatment_Click(object sender, RoutedEventArgs e)
        {
            var a = this.alarmGrid.SelectedItem;
            var b = a as DataRowView;
            int _Aid = Convert.ToInt32(b.Row[0]);
            RoomClass rc = new RoomClass();
            MySqlDataReader reader = rc.getAlarmInformation(_Aid);
            TreatmentAlarm ta = new TreatmentAlarm();
            if(reader.Read())
            {
                ta.Aid.Text = reader["ALARM_ID"].ToString();
                ta.number.Text = reader["NUMBER"].ToString();
                ta.Etype.Text = reader["TYPE_NAME"].ToString();
                ta.Atype.Text = reader["ALARM_TYPE_NAME"].ToString();
                ta.Room.Text = reader["ROOM_NAME"].ToString();
                ta.Time.Text = reader["ALARM_TIME"].ToString();
            }
            ta.Owner = Window.GetWindow(this);
            ta.ShowDialog();
        }
    }
}
