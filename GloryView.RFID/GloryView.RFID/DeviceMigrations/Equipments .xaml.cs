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
using GloryView.RFID.DeviceMigrations.DeviceClass;
using System.Data;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// Equipments.xaml 的交互逻辑
    /// </summary>
    public partial class Equipments : UserControl
    {
        public Equipments()
        {
            InitializeComponent();
        }

        private void Information(object sender, RoutedEventArgs e)
        {
            EquipmentInformation equipmentInformation = DeviceMigrationsFactory.EquipmentInformation;
            if (equipment_information.Children.Contains(equipmentInformation))
            {
                equipmentInformation.Visibility = Visibility.Visible;
            }
            else
            {
                equipment_information.Children.Add(equipmentInformation);

                equipmentInformation.Name = "equipmentInformation";
            }
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            var a = this.repairGrid.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
           int state= _Eclass.repairEquipment(_Eid);
           if (state == BaseRequest.SUCCESS)
           {
               DataSet _Repair_Set = _Eclass.getWorkEquipment();
               this.page.ShowPages(this.repairGrid, _Repair_Set, BaseRequest.PAGE_SIZE);
               MessageBox.Show("申请报修成功!");
           }
           else
           {
               MessageBox.Show("操作失败!系统异常，请联系管理员!");
           }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            RepairEquipment repair=DeviceMigrationsFactory.RepairEquipment;
            if (repair.apply_repair.Children.Contains(this.repair_Control)) 
                repair.apply_repair.Children.Remove(this.repair_Control);
        }
        

    }
}
