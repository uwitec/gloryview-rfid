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
using GloryView.RFID.DeviceMigrations.DeviceClass;
using System.Data;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// EditEquipment.xaml 的交互逻辑
    /// </summary>
    public partial class EditEquipment : Window
    {
        public EditEquipment()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem type = (ComboBoxItem)this.Etype.SelectedItem;
            if (this.Ename.Text.Equals(""))
            {
                JXMessageBox.Show(this, "设备名称不准为空!", MsgImage.Error);
                return;
            }
            if (type.Tag.ToString().Equals(""))
            {
                JXMessageBox.Show(this, "非法操作!", MsgImage.Error);
                return;
            }
            RoomClass rc = new RoomClass();
            int state = rc.updateEquipmentInformation(int.Parse(this.ID.Content.ToString()), this.Ename.Text,
                 int.Parse(type.Tag.ToString()));
            if (state == BaseRequest.SUCCESS)
            {
                Room roomBean = RoomManagerBean.Room;
                EquipmentClass ec = new EquipmentClass();
                DataSet set = ec.getEquipmentInformationByRoom(int.Parse(roomBean.roomId.Text));
                roomBean.page.ShowPages(roomBean.roomEquipment, set, BaseRequest.PAGE_SIZE);
                JXMessageBox.Show(this, "编辑信息已保存.", MsgImage.Success);
                this.Close();
            }
            else
            {
                JXMessageBox.Show(this, "保存失败！", MsgImage.Error);
            }
        }
    }
}
