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
using GloryView.RFID.DeviceMigrations.DeviceClass;
using GloryView.RFID.Utilities;
using System.Data;
using GloryView.RFID.PageControl;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// AddEquipment.xaml 的交互逻辑
    /// </summary>
    public partial class AddEquipment : Window
    {
        public AddEquipment()
        {
            InitializeComponent();
        }
        private void Close_Add(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Submit_Add(object sender, RoutedEventArgs e)
        {
            DeviceBean bean = new DeviceBean();
            EquipmentClass equipClass = new EquipmentClass();
            bean.Id = int.Parse(this.ID.Content.ToString());
            ComboBoxItem typeItem = (ComboBoxItem)this.typeBox.SelectedItem;
            ComboBoxItem roomItem = (ComboBoxItem)this.roomBox.SelectedItem;
            if (typeItem.Tag.ToString().Equals(""))
            {
                MessageBox.Show("请选择设备类别!");
                return;
            }
            if (this.equipName.Text.Equals("") || this.equipName.Text == null)
            {
                MessageBox.Show("请输入设备名称!");
                return;
            }
            if (roomItem.Tag.ToString().Equals(""))
            {

                MessageBox.Show("请选择设备所属机房!");
                return;
            }
            int state = 0;
            this.add.IsEnabled = false;
            bean.Name = this.equipName.Text;
            bean.RoomId = (int)roomItem.Tag;
            bean.Type = (int)typeItem.Tag;
            bean.Id = int.Parse(this.ID.Content.ToString());
            bean.EPCCode = this.numberStr.Text;
            state = equipClass.addEquipment(bean, this);
            this.add.IsEnabled = true;
            if (state == BaseRequest.SUCCESS)
            {
                //EquipmentClass equitment = new EquipmentClass();
                //DataSet set = equitment.comingEquipment();
                //NewEquipment equipments = DeviceMigrationsFactory.NewEquipment;
                //DeviceMigrationsFactory.NewEquipment.page.ShowPages(DeviceMigrationsFactory.NewEquipment.comingGrild, set, BaseRequest.PAGE_SIZE);
                //JXMessageBox.Show(Window.GetWindow(this), "已成功录入设备信息!", MsgImage.Success);
                //Close_Add(DeviceMigrationsFactory.AddEquipment, new RoutedEventArgs());

            }
            else
            {
                JXMessageBox.Show(Window.GetWindow(this), "未知错误，请联系管理员!", MsgImage.Error);
            }
        }
    }
}
