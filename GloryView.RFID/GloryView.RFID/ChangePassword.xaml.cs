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
using WpfApplication2.Utilities;
using GloryView.RFID.User;
using GloryView.RFID.Utilities;
using GloryView.RFID.PageControl;

namespace GloryView.RFID
{
    /// <summary>
    /// ChangePassword.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePassword : UserControl
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Change_Password(object sender, RoutedEventArgs e)
        {
            chang_password.Visibility = Visibility.Hidden;
        }

        private void submit_Change(object sender, RoutedEventArgs e)
        {
            string oldPaw = this.password.Password;
            string newPaw = this.newPassword.Password;
            string newPaw2 = this.newPassword2.Password;
            if(ValidateUtil.CheckFolderName(oldPaw)== false)
            {
                JXMessageBox.Show(Window.GetWindow(this), "请输入密码!", MsgImage.Error);
                return ;
            }
            if (ValidateUtil.CheckFolderName(newPaw) == false)
            {
                JXMessageBox.Show(Window.GetWindow(this), "请输入6位以上的密码!", MsgImage.Error);
                return;
            }
            if (!newPaw.Equals(newPaw2))
            {
                JXMessageBox.Show(Window.GetWindow(this), "输入新密码不一致!", MsgImage.Error);
                return;
            }
            Users user = new Users();
            int state=user.ChangeUserPassword(oldPaw, newPaw);
            if (state == BaseRequest.PASSWORD_ERROR)
            {
                JXMessageBox.Show(Window.GetWindow(this), "旧密码不正确!", MsgImage.Error);
            }
            else if (state == BaseRequest.SYSTEM_EXCEPTION)
            {
                JXMessageBox.Show(Window.GetWindow(this), "系统异常，请联系管理员!", MsgImage.Error);
            }
            else
            {
                JXMessageBox.Show(Window.GetWindow(this), "修改密码成功!", MsgImage.Success);
            }
        }
    }
}
