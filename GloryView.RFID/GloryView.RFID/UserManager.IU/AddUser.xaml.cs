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
using GloryView.RFID.UserManager.IU;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using GloryView.RFID.User;
using System.Data;
using MySql.Data.MySqlClient;
using GloryView.RFID.Utilities;

namespace GloryView.RFID
{
    /// <summary>
    /// AddUser.xaml 的交互逻辑
    /// </summary>
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();
            
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            DoAddUser user =new DoAddUser();
            user.Owner = Window.GetWindow(this);
            user.ShowDialog();
            
        }
        //编辑用户信息
        private void Edit_User(object sender, RoutedEventArgs e)
        {
            EditUser editUser = new EditUser(); ;
            var a = this.userData.SelectedItem;
            var b = a as DataRowView;
            int userId = Convert.ToInt32(b.Row[0]);
            Users user = new Users();
            MySqlDataReader reader=user.queryUser(userId);
            if (reader.Read())
            {
                editUser.userId.Content = reader["ID"];
                editUser.account.Text = reader["ACCOUNT"].ToString();
                editUser.userName.Text = reader["USER_NAME"].ToString();
                if ((int)reader["TYPE"] == 1)
                {
                    editUser.userType.SelectedIndex = 1;
                }
                else
                {
                    editUser.userType.SelectedIndex = 0;
                }
                editUser.userPhone.Text = reader["PHONE"].ToString();
                editUser.createTime.Content = Convert.ToDateTime(reader["CREATE_TIME"]).ToString("yyyy-MM-dd hh:mm");
            }

            ComboBox hasStatus = editUser.status;
            if (hasStatus.HasItems)
            {
                hasStatus.Items.Clear();
            }

            if ((int)reader["STATUS"] == 0) 
            {
                ComboBox status = editUser.status;
                ComboBoxItem check = new ComboBoxItem();
                check.Tag = 0;
                check.Content = "未激活";
                check.IsSelected=true;
                status.Items.Add(check);
                check = new ComboBoxItem();
                check.Tag = 1;
                check.Content = "激  活";
                status.Items.Add(check);
            }
            else if ((int)reader["STATUS"] == 1)
            {
                ComboBox status = editUser.status;
                ComboBoxItem check = new ComboBoxItem();
                check.Tag = 1;
                check.Content = "已激活";
                check.IsSelected = true;
                status.Items.Add(check);
                check = new ComboBoxItem();
                check.Tag = 2;
                check.Content = "禁  用";
                status.Items.Add(check);
            }
            else
            {
                ComboBox status = editUser.status;
                ComboBoxItem check = new ComboBoxItem();
                check.Tag = 2;
                check.Content = "禁  用";
                check.IsSelected = true;
                status.Items.Add(check);
                check = new ComboBoxItem();
                check.Tag = 1;
                check.Content = "激 活";
                status.Items.Add(check);
            }
            editUser.createName.Content = reader["CREATE_USER"];
            editUser.Owner = Window.GetWindow(this);
            editUser.ShowDialog();
        }

       

        private void QueryUser(object sender, RoutedEventArgs e)
        {
            QueryUser query = new QueryUser();
            query.Account = this.queryAccount.Text;
            query.UserName = this.queryName.Text;
            Users user = new Users();
            DataSet set=user.getUsersList(query);
            this.page.ShowPages(this.userData,set, BaseRequest.PAGE_SIZE);
            
        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
     
    }
}
