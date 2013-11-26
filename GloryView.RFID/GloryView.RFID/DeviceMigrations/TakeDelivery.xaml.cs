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
    /// TakeDelivery.xaml 的交互逻辑
    /// </summary>
    public partial class TakeDelivery : Window
    {
        public TakeDelivery()
        {
            InitializeComponent();
        }

        private void Delivery_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            var a = this.deliveryGrid.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            MsgResult r = JXMessageBox.Show(this, "您需要对此设备迁移？", "提示", MsgButton.Yes_No_Cancel, MsgImage.Exclamation);
            //MessageBox.Show(r.ToString());
            if (r == MsgResult.OK)
            {
                int state = _Eclass.outRoomEquipment(_Eid);
                if (state == BaseRequest.SUCCESS)
                {
                    DataSet _OutSet = _Eclass.getWorkEquipment();
                    this.page.ShowPages(this.deliveryGrid, _OutSet, BaseRequest.PAGE_SIZE);
                    JXMessageBox.Show(this, "申请出库成功", MsgImage.Success);
                    EquipmentDelivery delivery = DeviceMigrationsFactory.EquipmentDelivery;
                    DataSet deliverySet = _Eclass.getDeliverEquipment();
                    delivery.page.ShowPages(delivery.outGird, deliverySet, BaseRequest.PAGE_SIZE);
                }
                else
                {
                    JXMessageBox.Show(this, "操作失败!系统异常，请联系管理员!", MsgImage.Error);
                }
            }
        }
    }
}
