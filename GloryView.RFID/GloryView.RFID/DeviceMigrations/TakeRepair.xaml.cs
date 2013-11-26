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
using GloryView.RFID.DeviceMigrations.DeviceClass;
using System.Data;
using GloryView.RFID.Utilities;
using GloryView.RFID.PageControl;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// TakeRepair.xaml 的交互逻辑
    /// </summary>
    public partial class TakeRepair : Window
    {
        public TakeRepair()
        {
            InitializeComponent();
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            var a = this.repairGrid.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
           MsgResult r =JXMessageBox.Show(this, "您需要对此设备进修报修？", "提示", MsgButton.Yes_No_Cancel, MsgImage.Question);
           if (r == MsgResult.OK)
           {
               int state = _Eclass.repairEquipment(_Eid);
               if (state == BaseRequest.SUCCESS)
               {
                   DataSet _Repair_Set = _Eclass.getWorkEquipment();
                   this.page.ShowPages(this.repairGrid, _Repair_Set, BaseRequest.PAGE_SIZE);

                   JXMessageBox.Show(this, "申请报修成功", MsgImage.Success);
                   RepairEquipment repair = DeviceMigrationsFactory.RepairEquipment;
                   DataSet repairSet = _Eclass.getRepairEquipment();
                   repair.page.ShowPages(repair.repair_Grid, repairSet, BaseRequest.PAGE_SIZE);
               }
               else
               {
                   JXMessageBox.Show(this, "操作失败!系统异常，请联系管理员!", MsgImage.Error);
               }
           }
        }
    }
}
