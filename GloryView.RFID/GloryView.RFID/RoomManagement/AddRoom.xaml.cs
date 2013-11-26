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
using System.Data;
using GloryView.RFID.RoomManagement.Rooms;
using MySql.Data.MySqlClient;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.RoomManagement
{
    /// <summary>
    /// AddRoom.xaml 的交互逻辑
    /// </summary>
    public partial class AddRoom : UserControl
    {
        public AddRoom()
        {
            InitializeComponent();
        }
        //新建机房
        private void addRoom(object sender, MouseButtonEventArgs e)
        {
            AddRooms room = RoomManagerBean.AddRooms;
            if (add_room.Children.Contains(room))
            {
                room.Visibility = Visibility.Visible;
            }
            else
            {
                add_room.Children.Add(room);

                room.Name = "category";
            }

        }

        private void Edit_Room(object sender, RoutedEventArgs e)
        {
            EditRoom editroom = RoomManagerBean.EditRoom;
            var a = this.roomDate.SelectedItem;
            var b = a as DataRowView;
            int roomId = Convert.ToInt32(b.Row[0]);
            RoomClass rc = new RoomClass();
            MySqlDataReader reader= rc.EditRooms(roomId);
            if(reader.Read())
            {
                editroom.roomName.Text = reader["ROOM_NAME"].ToString();
                editroom.floor.Text = reader["FLOOR"].ToString();
                editroom.belongs.Text = reader["BELONGS"].ToString();
                editroom.purpose.Text = reader["PURPOSE"].ToString();
                editroom.createUser.Content = reader["USER_NAME"];
                editroom.roomId.Content = roomId;
                editroom.createTime.Content = Convert.ToDateTime(reader["CREATION_DATE"]).ToString(BaseRequest.DATE_MS_FORMAT);
             }
            if (add_room.Children.Contains(editroom))
            {
                editroom.Visibility = Visibility.Visible;
            }
            else
            {
                add_room.Children.Add(editroom);

                editroom.Name = "editroom";
            }
        }

        private void Room_Details(object sender, RoutedEventArgs e)
        {
            RoomDetails roomDetails = RoomManagerBean.RoomDetails;
            if (add_room.Children.Contains(roomDetails))
            {
                roomDetails.Visibility = Visibility.Visible;
            }
            else
            {
                add_room.Children.Add(roomDetails);

                roomDetails.Name = "roomDetails";
            }
        }

       
    }
}
