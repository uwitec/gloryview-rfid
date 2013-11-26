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
    /// EquipmentReview.xaml 的交互逻辑
    /// </summary>
    public partial class EquipmentReview : UserControl
    {
        public EquipmentReview()
        {
            InitializeComponent();
        }

        private void Do_Review(object sender, RoutedEventArgs e)
        {
            Review addReview = DeviceMigrationsFactory.Review;
            if (review_device.Children.Contains(addReview))
            {
                addReview.Visibility = Visibility.Visible;
            }
            else
            {
                review_device.Children.Add(addReview);

                addReview.Name = "addReview";
            }
        }
    }
}
