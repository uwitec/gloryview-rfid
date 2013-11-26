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
using WpfApplication2;
using GloryView.RFID.User;
using GloryView.RFID.Utilities;
using GloryView.RFID.PageControl;

namespace GloryView.RFID
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // this.grid3.Children.Add(Search.SearchControl);
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            //MysqlDataDao login = new MysqlDataDaoImpl();
            string account = this.account.Text;
            string password = this.password.Password;
            if (account == null || "".Equals(account))
            {
                MessageBox.Show("请输入用户帐号!");
                return;
            }
            if (password == null || "".Equals(password))
            {
                MessageBox.Show("请输入密码!");
                return;
            }
            Users user=new Users();
            int state = user.userLogin(account,password);
            if (state==BaseRequest.SUCCESS)
            {
                MainForm mf = new MainForm();
                mf.wellcome.Content = Session.UserAccount+"  欢迎您...";
                mf.loginTime.Content = Session.LoginTime;
                mf.Show();
                this.Close();
            }
            else if (state == BaseRequest.SYSTEM_EXCEPTION)
            {

                MessageBox.Show("系统异常，请联系管理员!");

            }
            else
            {
                MessageBox.Show("用户名或密码不正确,请确认!");
                this.account.Text = null;
                this.password.Password = null;
            }
        }
    }
}
