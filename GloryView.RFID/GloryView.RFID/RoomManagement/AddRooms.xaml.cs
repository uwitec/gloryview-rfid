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
    /// AddRooms.xaml 的交互逻辑
    /// </summary>
    public partial class AddRooms : UserControl
    {
        public AddRooms()
        {
            InitializeComponent();
        }

        private void Hident_AddRoom(object sender, RoutedEventArgs e)
        {
            addRooms.Visibility = Visibility.Hidden;
        }

        private void Add_Rooms(object sender, RoutedEventArgs e)
        {
            RoomBean bean=new RoomBean();
            if (this.roomName.Text.Equals(""))
            {
                MessageBox.Show("请输入机房名!");
                return;
            }
            RoomClass rc = new RoomClass();
            bean.RoomName = this.roomName.Text;
            if (!this.belongs.Text.Equals("")) bean.Belongs = this.belongs.Text;
            if (!this.purpose.Text.Equals("")) bean.Purpose = this.purpose.Text;
            if (!this.floor.Text.Equals("")) bean.Floor = this.floor.Text;
            int state=rc.AddRoom(bean);
            if (state == BaseRequest.HAS) MessageBox.Show("已存在该机房名!");
            else if (state == BaseRequest.SUCCESS)
            {
                MessageBox.Show("操作成功!");
                this.addRooms.Visibility = Visibility.Hidden;
                RoomManagerBean.AddRoom.page.ShowPages(RoomManagerBean.AddRoom.roomDate, rc.queryRoomsList(), BaseRequest.PAGE_SIZE);
            }
            else MessageBox.Show("系统异常，请连管理员!");
        }
    }
}
