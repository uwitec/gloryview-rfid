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
    /// ApplyDevice.xaml 的交互逻辑
    /// </summary>
    public partial class ApplyDevice : UserControl
    {
        public ApplyDevice()
        {
            InitializeComponent();
        }

        private void Close_applyDevice(object sender, RoutedEventArgs e)
        {
            applyDevice.Visibility = Visibility.Hidden;
        }
    }
}
