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
using GloryView.RFID.DeviceMigrations.DeviceClass;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// EditWriteAndReader.xaml 的交互逻辑
    /// </summary>
    public partial class EditWriteAndReader : Window
    {
        public EditWriteAndReader()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
             ComboBoxItem type = (ComboBoxItem)this.type.SelectedItem;
            if (this.Ename.Text.Equals(""))
            {
                JXMessageBox.Show(this, "设备名称不准为空!", MsgImage.Error);
                return;
            }
            if (this.ip.Text.Equals(""))
            {
                JXMessageBox.Show(this, "读写器IP不能为空!", MsgImage.Error);
                return;
            }
            if (this.port.Text.Equals(""))
            {
                JXMessageBox.Show(this, "读写器端口不能为空!", MsgImage.Error);
                return;
            }
            if ("".Equals(type.Tag.ToString()))
            {
                JXMessageBox.Show(this, "非法操作!", MsgImage.Error);
                return;
            }
            if (this.sweepTime.Text.Equals(""))
            {
                JXMessageBox.Show(this, "读写器扫描时间不为空!", MsgImage.Error);
                return;
            }
            RoomClass rc = new RoomClass();
           int state = rc.updateWriteAndReader(int.Parse(this.ID.Content.ToString()),this.Ename.Text,this.ip.Text,int.Parse(this.port.Text),
                int.Parse(type.Tag.ToString()),float.Parse(this.sweepTime.Text.ToString()));
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
