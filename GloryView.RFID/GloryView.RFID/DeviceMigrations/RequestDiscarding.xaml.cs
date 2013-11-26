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
    /// RequestDiscarding.xaml 的交互逻辑
    /// </summary>
    public partial class RequestDiscarding : UserControl
    {
        public RequestDiscarding()
        {
            InitializeComponent();
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            ApplyDevice applyDevice = DeviceMigrationsFactory.ApplyDevice;
            if (apply_device.Children.Contains(applyDevice))
            {
                applyDevice.Visibility = Visibility.Visible;
            }
            else
            {
                apply_device.Children.Add(applyDevice);

                applyDevice.Name = "applyDevice";
            }
        }
    }
}
