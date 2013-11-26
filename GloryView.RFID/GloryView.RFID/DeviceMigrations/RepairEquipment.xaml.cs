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
    /// RepairEquipment.xaml 的交互逻辑
    /// </summary>
    public partial class RepairEquipment : UserControl
    {
        public RepairEquipment()
        {
            InitializeComponent();
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
           // if (moveGrid.Children != null) moveGrid.Children.Clear();
            //RepairEquipment _RepairEquipment = DeviceMigrationsFactory.RepairEquipment;
            //EquipmentClass _Eclass = new EquipmentClass();

           // Equipments _Repair = DeviceMigrationsFactory.Equipments;
            EquipmentClass _Eclass = new EquipmentClass();
            DataSet _OutSet = _Eclass.getWorkEquipment();
            TakeRepair tr = new TakeRepair();
            tr.page.ShowPages(tr.repairGrid, _OutSet, BaseRequest.PAGE_SIZE);
            //this.apply_repair.Children.Add(tr);//.Add(_Repair);
            //JXMessageBox.Show(Window.GetWindow(this)
            tr.Owner = Window.GetWindow(this);
            tr.ShowDialog();
            
        }
    }
}
