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
    /// TakeMove.xaml 的交互逻辑
    /// </summary>
    public partial class TakeMove : Window
    {
        public TakeMove()
        {
            InitializeComponent();
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            var a = this.MoveGrid.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            MsgResult r = JXMessageBox.Show(this, "您需要对此设备迁移？", "提示", MsgButton.Yes_No_Cancel, MsgImage.Warning);
            //MessageBox.Show(r.ToString());
            if (r == MsgResult.OK)
            {
                int state = _Eclass.moveEquipment(_Eid);
                if (state == BaseRequest.SUCCESS)
                {
                    DataSet _Repair_Set = _Eclass.getWorkEquipment();
                    this.page.ShowPages(this.MoveGrid, _Repair_Set, BaseRequest.PAGE_SIZE);
                    JXMessageBox.Show(this, "申请迁移成功", MsgImage.Success);
                    DeviceMove move = DeviceMigrationsFactory.DeviceMove;
                    DataSet moveSet=_Eclass.getMoveEquipment();
                    move.page.ShowPages(move.removeGrid, moveSet, BaseRequest.PAGE_SIZE);

                }
                else
                {
                    JXMessageBox.Show(this, "操作失败!系统异常，请联系管理员!", MsgImage.Error);
                }
            }
        }
    }
}
