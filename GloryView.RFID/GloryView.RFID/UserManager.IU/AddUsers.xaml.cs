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
using GloryView.RFID.User;
using WpfApplication2.Utilities;
using System.Security.Cryptography;
using GloryView.RFID.Utilities;
using GloryView.RFID.PageControl;

namespace GloryView.RFID.UserManager.IU
{
    /// <summary>
    /// AddUsers.xaml 的交互逻辑
    /// </summary>
    public partial class AddUsers : UserControl
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            addUsers.Visibility = Visibility.Hidden;
        }

        private void Submit_AddUser(object sender, RoutedEventArgs e)
        {
            if (ValidateUtil.CheckFolderName(this.account.Text) == false)
            {
                JXMessageBox.Show(Window.GetWindow(this), "请填写帐号!", MsgImage.Error);
                return;
            }
            if (ValidateUtil.CheckFolderName(this.userName.Text) == false)
            {
                JXMessageBox.Show(Window.GetWindow(this), "请填写用户姓名!", MsgImage.Error);
                return;
            }
            if (ValidateUtil.CheckPasswordStrength(this.password.Password) == false)
            {
                JXMessageBox.Show(Window.GetWindow(this), "请输入6位以上的密码长度!", MsgImage.Error);
                return;
            }
           
            if (!this.password.Password.Equals(this.password2.Password))
            {
                JXMessageBox.Show(Window.GetWindow(this), "输入密码不一致，请重新输入!", MsgImage.Error);
                return;
            }
            Users u = new Users();
            UserBean bean = new UserBean();
            QueryUser query = new QueryUser();
            query.Account = UserManagerBean.AddUser.queryAccount.Text;
            query.UserName = UserManagerBean.AddUser.queryName.Text;
            bean.Account = this.account.Text;
            bean.UserName = this.userName.Text;
            bean.Password = this.password.Password;
            bean.Status = 0;
            bean.CreateId = Session.UserId;
            bean.CreateTime = Convert.ToDateTime(DateTime.Now);
            bean.Phone = this.phone.Text;
            ComboBoxItem type = (ComboBoxItem)this.userType.SelectedItem;
            bean.Type = int.Parse(type.Tag.ToString());
            int state=u.registUser(bean);
            Window targe = Window.GetWindow(this);
            if (state == BaseRequest.HAS)
            {
                JXMessageBox.Show(Window.GetWindow(this), "该账号已被使用!", MsgImage.Error);
            }
            else if (state == BaseRequest.SYSTEM_EXCEPTION)
            {
                JXMessageBox.Show(Window.GetWindow(this), "系统异常，请联系管理员!", MsgImage.Error);
            }
            else
            {
                JXMessageBox.Show(Window.GetWindow(this), "新增用户成功!", MsgImage.Error);
                this.addUsers.Visibility = Visibility.Hidden;
                UserManagerBean.AddUser.page.ShowPages(UserManagerBean.AddUser.userData, u.getUsersList(query), BaseRequest.PAGE_SIZE);
            }
        }
    }
}
