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
using GloryView.RFID.RoomManagement.Rooms;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// EditRoom.xaml 的交互逻辑
    /// </summary>
    public partial class EditRoom : UserControl
    {
        public EditRoom()
        {
            InitializeComponent();
        }

        private void Close_EditRoom(object sender, RoutedEventArgs e)
        {
            edit_room.Visibility = Visibility.Hidden;
        }

        private void Sava_Edit(object sender, RoutedEventArgs e)
        {
            if (this.roomName.Text.Equals(""))
            {
                MessageBox.Show("请输入机房名称!");
                return;
            }
            RoomBean bean = new RoomBean();
            RoomClass rc=new RoomClass();
            bean.RoomName = this.roomName.Text;
            bean.Floor = this.floor.Text;
            bean.Purpose = this.purpose.Text;
            bean.Belongs = this.belongs.Text;
            bean.Id = (int)this.roomId.Content;
            int state=rc.saveEditRoom(bean);
            if (state == BaseRequest.SUCCESS)
            {
                MessageBox.Show("操作成功!");
                this.edit_room.Visibility = Visibility.Hidden;
                RoomManagerBean.AddRoom.page.ShowPages(RoomManagerBean.AddRoom.roomDate, rc.queryRoomsList(), BaseRequest.PAGE_SIZE);
            }
        }
    }
}
