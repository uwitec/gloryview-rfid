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
    /// EquipmentScrapping.xaml 的交互逻辑
    /// </summary>
    public partial class EquipmentScrapping : UserControl
    {
        public EquipmentScrapping()
        {
            InitializeComponent();
        }

        private void Equipment_Information(object sender, RoutedEventArgs e)
        {
            EquipmentInformation equipmentInformation = new EquipmentInformation();
            if (scrapping.Children.Contains(equipmentInformation))
            {
                equipmentInformation.Visibility = Visibility.Visible;
            }
            else
            {
                scrapping.Children.Add(equipmentInformation);

                equipmentInformation.Name = "equipmentInformation";
            }
        }

        private void Scrap_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            DataSet _OutSet = _Eclass.getWorkEquipment();
            TakeScrapping ts = new TakeScrapping();
            ts.page.ShowPages(ts.scrappingGrid, _OutSet, BaseRequest.PAGE_SIZE);
            //this.apply_repair.Children.Add(tr);//.Add(_Repair);
            //JXMessageBox.Show(Window.GetWindow(this)
            ts.Owner = Window.GetWindow(this);
            ts.ShowDialog();
        }
    }
}
