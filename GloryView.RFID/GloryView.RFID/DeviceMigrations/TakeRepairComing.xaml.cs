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
using GloryView.RFID.PageControl;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.DeviceMigrations
{
    /// <summary>
    /// TakeRepairComing.xaml 的交互逻辑
    /// </summary>
    public partial class TakeRepairComing : Window
    {
        public TakeRepairComing()
        {
            InitializeComponent();
        }

        private void RpairCom_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            var a = this.repair_Grid.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            MsgResult r = JXMessageBox.Show(this, "您需要对此设备申请入库？", "提示", MsgButton.Yes_No_Cancel, MsgImage.Exclamation);
            //MessageBox.Show(r.ToString());
            if (r == MsgResult.OK)
            {
                int state = _Eclass.repairEquipmentComing(_Eid);
                if (state == BaseRequest.SUCCESS)
                {
                    DataSet set = _Eclass.getRepairEquipmentList();
                    this.page.ShowPages(this.repair_Grid, set, BaseRequest.PAGE_SIZE);
                    JXMessageBox.Show(this, "申请出库成功", MsgImage.Success);
                    NewEquipment newEquipment = DeviceMigrationsFactory.NewEquipment;
                    DataSet deliverySet = _Eclass.comingEquipment();
                    newEquipment.page.ShowPages(newEquipment.comingGrild, deliverySet, BaseRequest.PAGE_SIZE);
                }
                else
                {
                    JXMessageBox.Show(this, "操作失败!系统异常，请联系管理员!", MsgImage.Error);
                }
            }
        }
    }
}
