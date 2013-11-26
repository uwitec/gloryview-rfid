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
using GloryView.RFID.SystemManagement.SystemClass;

namespace GloryView.RFID.SystemManagement
{
    /// <summary>
    /// BackupCycleSetting.xaml 的交互逻辑
    /// </summary>
    public partial class BackupCycleSetting : UserControl
    {
        public BackupCycleSetting()
        {
            InitializeComponent();
        }

        private void Backup_Click(object sender, RoutedEventArgs e)
        {
            DatabaseBackupAndRestore dataBackUp = new DatabaseBackupAndRestore();
            //dataBackUp.DataBackUp();
        }
    }
}
