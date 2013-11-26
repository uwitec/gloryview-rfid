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
using GloryView.RFID.RoomManagement.Rooms;
using GloryView.RFID.Utilities;
using GloryView.RFID.PageControl;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// AddDeviceClass.xaml 的交互逻辑
    /// </summary>
    public partial class AddDeviceClass : Window
    {
        public AddDeviceClass()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Type(object sender, RoutedEventArgs e)
        {
            string type = this.typeName.Text;
            RoomClass rc = new RoomClass();
            int state = rc.addType(type);
            if (state == BaseRequest.SUCCESS)
            {
                JXMessageBox.Show(this, "添加类别成功!",MsgImage.Success);
                RoomManagerBean.DeviceClass.page.ShowPages(RoomManagerBean.DeviceClass.deviceData, rc.queryType(), BaseRequest.PAGE_SIZE);
                this.Close();
            }
            else if (state == BaseRequest.HAS)
            {
                JXMessageBox.Show(this, "已有该类别!", MsgImage.Error);
            }
            else
            {
                JXMessageBox.Show(this, "未知错误，请联系管理员!", MsgImage.Error);
            }
        }
    }
}
