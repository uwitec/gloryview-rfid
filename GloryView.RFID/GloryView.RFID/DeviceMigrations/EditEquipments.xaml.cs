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
    /// EditEquipments.xaml 的交互逻辑
    /// </summary>
    public partial class EditEquipments : Window
    {
        public EditEquipments()
        {
            InitializeComponent();
        }
        private void Save_Edit(object sender, RoutedEventArgs e)
        {
            if (this.Ename.Equals(""))
            {
                JXMessageBox.Show(this,"设备名称不能为空!",MsgImage.Error);
                return;
            }
            int _Eid = int.Parse(this.ID.Content.ToString());
            string name = this.Ename.Text;
            ComboBoxItem roomItem = (ComboBoxItem)this.roomBox.SelectedItem;
            int roomId = (int)roomItem.Tag;
            EquipmentClass _Edit = new EquipmentClass();
            int state = _Edit.saveEditEquipment(_Eid, name, roomId);
            if (state == BaseRequest.SUCCESS)
            {
                EquipmentClass equitment = new EquipmentClass();
                DataSet set = equitment.comingEquipment();
                NewEquipment equipments = DeviceMigrationsFactory.NewEquipment;
                DeviceMigrationsFactory.NewEquipment.page.ShowPages(DeviceMigrationsFactory.NewEquipment.comingGrild, set, BaseRequest.PAGE_SIZE);

                JXMessageBox.Show(this, "编辑成功!", MsgImage.Success);

                this.Close();
            }
            else
            {
                JXMessageBox.Show(this, "错误，请检查您是否正确操作!", MsgImage.Error);
            }
        }

        private void Close_Edit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
