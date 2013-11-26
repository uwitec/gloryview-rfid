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
    /// DeviceMove.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceMove : UserControl
    {
        public DeviceMove()
        {
            InitializeComponent();
        }

        private void Migration_Details(object sender, RoutedEventArgs e)
        {
           // MigrationDetailsControl
            MigrationDetails migrationDetails = DeviceMigrationsFactory.MigrationDetails;
            if (moveDevice.Children.Contains(migrationDetails))
            {
                migrationDetails.Visibility = Visibility.Visible;
            }
            else
            {
                moveDevice.Children.Add(migrationDetails);

                migrationDetails.Name = "migrationDetails";
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            DataSet _OutSet = _Eclass.getWorkEquipment();
            TakeMove tm = new TakeMove();
            tm.page.ShowPages(tm.MoveGrid, _OutSet, BaseRequest.PAGE_SIZE);
            //this.apply_repair.Children.Add(tr);//.Add(_Repair);
            //JXMessageBox.Show(Window.GetWindow(this)
            tm.Owner = Window.GetWindow(this);
            tm.ShowDialog();
        }

       
    }
}
