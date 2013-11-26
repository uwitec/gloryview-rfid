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
using GloryView.RFID.PageControl;
using GloryView.RFID.RoomManagement.Rooms;
using GloryView.RFID.Utilities;
using System.Data;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// TreatmentAlarm.xaml 的交互逻辑
    /// </summary>
    public partial class TreatmentAlarm : Window
    {
        public TreatmentAlarm()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Handle_Click(object sender, RoutedEventArgs e)
        {
            TextRange _Text = new TextRange(this.Information.Document.ContentStart, this.Information.Document.ContentEnd);
            if (_Text.Text.Length > 150)
            {
                JXMessageBox.Show(this, "处理说明只能输入150个字符，请检查!", MsgImage.Error);
                return;
            }
            if (_Text.Text.Length <3 || _Text.Text.Equals(""))
            {
                JXMessageBox.Show(this, "请输入警报处理说明!", MsgImage.Error);
                return;
            }
           
            int Aid = int.Parse(this.Aid.Text);
            MessageBox.Show("id>>" + Aid.ToString() + "   _Text.Text=" + _Text.Text);
            RoomClass rc=new RoomClass();
            int state = rc.doAlarmInformation(Aid,_Text.Text);
            if (state == BaseRequest.SUCCESS)
            {
                Alarm alarm = RoomManagerBean.Alarm;
                RoomClass _Rclass = new RoomClass();
                DataSet _Alarm_Set = _Rclass.queryAlarmList();
                alarm.page.ShowPages(alarm.alarmGrid, _Alarm_Set, BaseRequest.PAGE_SIZE);
                JXMessageBox.Show(this, "警报处理完成!", MsgImage.Success);
                this.Close();
            }
            else
            {
                JXMessageBox.Show(this, "系统异常，请联系管理员!", MsgImage.Error);
            }
        }
    }
}
