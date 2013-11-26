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
using GloryView.RFID.User;
using GloryView.RFID.Utilities;
using GloryView.RFID.PageControl;

namespace GloryView.RFID.UserManager.IU
{
    /// <summary>
    /// EditUser.xaml 的交互逻辑
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();
        }
        private void Close_EditUser(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Edit(object sender, RoutedEventArgs e)
        {
            ComboBoxItem status = (ComboBoxItem)this.status.SelectedItem;
            UserBean bean = new UserBean();
            QueryUser query = new QueryUser();
            query.Account = UserManagerBean.AddUser.queryAccount.Text;
            query.UserName = UserManagerBean.AddUser.queryName.Text;
            bean.Id = int.Parse(this.userId.Content.ToString());
            bean.UserName = this.userName.Text;
            bean.Phone = this.userPhone.Text;
            bean.Status = int.Parse(status.Tag.ToString());
            bean.Type = this.userType.SelectedIndex;
            Users user = new Users();
            int state = user.saveUserEdit(bean);
            if (state == BaseRequest.SUCCESS)
            {
                JXMessageBox.Show(Window.GetWindow(this), "编辑用信息保存成功!", MsgImage.Success);
                this.Close();
                UserManagerBean.AddUser.page.ShowPages(UserManagerBean.AddUser.userData, user.getUsersList(query), BaseRequest.PAGE_SIZE);
            }
            else if (state == BaseRequest.SYSTEM_EXCEPTION)
            {
                JXMessageBox.Show(Window.GetWindow(this), "系统异常，请联系管理员!", MsgImage.Error);
            }
            else
            {
                JXMessageBox.Show(Window.GetWindow(this), "未知错误", MsgImage.Error);
            }
        }
    }
}
