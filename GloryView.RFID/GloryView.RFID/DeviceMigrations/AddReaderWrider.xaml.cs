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
using GloryView.RFID.DeviceMigrations.DeviceClass;
using GloryView.RFID.Utilities;
using System.Data;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// AddReaderWrider.xaml 的交互逻辑
    /// </summary>
    public partial class AddReaderWrider : Window
    {
        public AddReaderWrider()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
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

        private void Submit_Add_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem antennaNum = (ComboBoxItem)this.antennaNum.SelectedItem;
            ComboBoxItem typeItem = (ComboBoxItem)this.type.SelectedItem;
            ComboBoxItem room = (ComboBoxItem)this.roomBox.SelectedItem;
            if (this.number.Text.Equals(""))
            {
                JXMessageBox.Show(Window.GetWindow(this), "非法操作！", MsgImage.Error);
                return;
            }
            if (this.name.Text.Equals(""))
            {
                JXMessageBox.Show(Window.GetWindow(this), "请输入读写器名称！", MsgImage.Error);
                return;
            }
            if (this.ip.Text.Equals(""))
            {
                JXMessageBox.Show(Window.GetWindow(this), "请输入读写器IP！", MsgImage.Error);
                return;
            }
            if (this.port.Text.Equals(""))
            {
                JXMessageBox.Show(Window.GetWindow(this), "请输入读写器端口！", MsgImage.Error);
                return;
            }
            if ("".Equals(antennaNum.Tag.ToString()))
            {
                JXMessageBox.Show(Window.GetWindow(this), "请选择读写器支持天线数目！", MsgImage.Error);
                return;
            }
            if ("".Equals(typeItem.Tag.ToString()))
            {
                JXMessageBox.Show(Window.GetWindow(this), "请选择读写器的类别！", MsgImage.Error);
                return;
            }
            if (this.time.Text.Equals(""))
            {
                JXMessageBox.Show(Window.GetWindow(this), "请填写读写器扫描时间间隔！", MsgImage.Error);
                return;
            }
            if (room.Tag.ToString().Equals(""))
            {
                JXMessageBox.Show(Window.GetWindow(this), "请选择所在机房！", MsgImage.Error);
                return;
            }
            WriterReaderBean bean = new WriterReaderBean();
            bean.Id = int.Parse(this.number.Text.ToString());
            bean.Number = int.Parse(this.number.Text.ToString());
            bean.Name = this.name.Text;
            bean.Ip = this.ip.Text;
            bean.Port = int.Parse(this.port.Text);
            bean.AntennaSum = int.Parse(antennaNum.Tag.ToString());
            bean.Type = int.Parse(typeItem.Tag.ToString());
            bean.SweepTime = int.Parse(this.time.Text);
            bean.RoomId = int.Parse(room.Tag.ToString());
            bean.EpcCode = this.numberStr.Text;
            EquipmentClass ec = new EquipmentClass();
            int state = ec.insertWriterReader(bean,this);
            if (state == BaseRequest.SUCCESS)
            {
                EquipmentClass equitment = new EquipmentClass();
                DataSet set = equitment.comingEquipment();
                NewEquipment equipments = DeviceMigrationsFactory.NewEquipment;
                DeviceMigrationsFactory.NewEquipment.page.ShowPages(DeviceMigrationsFactory.NewEquipment.comingGrild, set, BaseRequest.PAGE_SIZE);
              
                JXMessageBox.Show(Window.GetWindow(this), "已成功录入读写器信息!", MsgImage.Success);
                this.Close();
            }
            else
            {
                JXMessageBox.Show(Window.GetWindow(this), "未知错误，请联系管理员!", MsgImage.Error);
            }
        }
    }
}
