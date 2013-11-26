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
    /// EquipmentDelivery.xaml 的交互逻辑
    /// </summary>
    public partial class EquipmentDelivery : UserControl
    {
        public EquipmentDelivery()
        {
            InitializeComponent();
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            DataSet _OutSet = _Eclass.getWorkEquipment();
            TakeDelivery td = new TakeDelivery();
            td.page.ShowPages(td.deliveryGrid, _OutSet, BaseRequest.PAGE_SIZE);
            //this.apply_repair.Children.Add(tr);//.Add(_Repair);
            //JXMessageBox.Show(Window.GetWindow(this)
            td.Owner = Window.GetWindow(this);
            td.ShowDialog();
        }
    }
}
