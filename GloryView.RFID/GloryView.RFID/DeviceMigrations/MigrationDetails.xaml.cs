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

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// MigrationDetails.xaml 的交互逻辑
    /// </summary>
    public partial class MigrationDetails : UserControl
    {
        public MigrationDetails()
        {
            InitializeComponent();
        }

        private void Close_MigrationDetails(object sender, RoutedEventArgs e)
        {
            MigrationDetailsControl.Visibility = Visibility.Hidden;
        }
    }
}
