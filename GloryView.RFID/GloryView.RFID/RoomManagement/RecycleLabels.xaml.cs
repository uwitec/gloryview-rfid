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

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// RecycleLabels.xaml 的交互逻辑
    /// </summary>
    public partial class RecycleLabels : UserControl
    {
        public RecycleLabels()
        {
            InitializeComponent();
        }

        private void AddRecycle(object sender, RoutedEventArgs e)
        {
           
            AddRecycleLabels recycle = RoomManagerBean.AddRecycleLabels;
            if (grid.Children.Contains(recycle))
            {
                recycle.Visibility = Visibility.Visible;
            }
            else
            {
                grid.Children.Add(recycle);
                recycle.Name = "recycle";
            }
        }
    }
}
