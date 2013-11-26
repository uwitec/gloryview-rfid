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
    /// TakeScrapping.xaml 的交互逻辑
    /// </summary>
    public partial class TakeScrapping : Window
    {
        public TakeScrapping()
        {
            InitializeComponent();
            
        }

        private void Scrapping_Click(object sender, RoutedEventArgs e)
        {
            EquipmentClass _Eclass = new EquipmentClass();
            var a = this.scrappingGrid.SelectedItem;
            var b = a as DataRowView;
            int _Eid = Convert.ToInt32(b.Row[0]);
            MsgResult r = JXMessageBox.Show(this, "您需要对此设备进修报修？", "提示", MsgButton.Yes_No_Cancel, MsgImage.Question);
            if (r == MsgResult.OK)
            {
                int state = _Eclass.scrapEquipment(_Eid);
                if (state == BaseRequest.SUCCESS)
                {
                    DataSet _Scrapping_Set = _Eclass.getWorkEquipment();
                    this.page.ShowPages(this.scrappingGrid, _Scrapping_Set, BaseRequest.PAGE_SIZE);

                    JXMessageBox.Show(this, "申请报废成功", MsgImage.Success);
                    EquipmentScrapping scrapping = DeviceMigrationsFactory.EquipmentScrapping;
                    DataSet scrappingSet = _Eclass.getScrappingEquipment();
                    scrapping.page.ShowPages(scrapping.scrapGrid, scrappingSet, BaseRequest.PAGE_SIZE);
                }
                else
                {
                    JXMessageBox.Show(this, "操作失败!系统异常，请联系管理员!", MsgImage.Error);
                }
            }
        }
    }
}
