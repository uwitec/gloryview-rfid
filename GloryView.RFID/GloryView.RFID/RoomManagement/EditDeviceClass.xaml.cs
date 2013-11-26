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
    /// EditDeviceClass.xaml 的交互逻辑
    /// </summary>
    public partial class EditDeviceClass : Window
    {
        public EditDeviceClass()
        {
            InitializeComponent();
        }
        private void Close_EditDeviceClass(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_DeviceClass(object sender, RoutedEventArgs e)
        {
            int id = (int)this.id.Content;
            string name = this.typeName.Text;
            if (name.Equals(""))
            {
                JXMessageBox.Show(this,"请输入类别名称!",MsgImage.Error);
                return;
            }
            RoomClass rc = new RoomClass();
            int state = rc.saveEditType(id, name);
            if (state == BaseRequest.SUCCESS)
            {
                JXMessageBox.Show(this,"编辑设备类别信息成功!",MsgImage.Success);
                RoomManagerBean.DeviceClass.page.ShowPages(RoomManagerBean.DeviceClass.deviceData, rc.queryType(), BaseRequest.PAGE_SIZE);
                this.Close();
            }
            else
            {
                JXMessageBox.Show(this, "未知错误，请联系管理员!", MsgImage.Error);
            }
        }
    }
}
