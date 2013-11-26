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
using System.Windows.Shapes;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// HistoryEquipmentDetails.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryEquipmentDetails : Window
    {
        public HistoryEquipmentDetails()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
