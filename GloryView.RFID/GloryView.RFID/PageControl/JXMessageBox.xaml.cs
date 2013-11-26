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

namespace GloryView.RFID.PageControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class JXMessageBox : Window
    {
        public MsgResult msgResult { get; set; }
        private MsgButton button;
        public JXMessageBox()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Manual;
            this.SizeToContent = SizeToContent.Width;
            this.SizeToContent = SizeToContent.Height;
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.msgResult = MsgResult.Cancel;
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private BitmapImage imgSource(string url)
        {
            return new BitmapImage(new Uri(url, UriKind.Relative));
        }

        public static MsgResult Show(Window win, string DisplayMessage, MsgImage img)
        {
            JXMessageBox msgBox = new JXMessageBox();
            msgBox.txtDisplayMessage.Text = DisplayMessage;
            string imageUrl = "";
            switch (img)
            {
                case MsgImage.Error:
                    imageUrl = @"../Images/error.png";
                    break;
                case MsgImage.Success:
                    imageUrl = @"../Images/success.png";
                    break;

                case MsgImage.Question:
                    imageUrl = @"../Images/question.png";
                    break;
                case MsgImage.Exclamation:
                    imageUrl = @"../Images/wonder.png";
                    break;
            }
            if (img != MsgImage.None)
            {
                msgBox.imgInfo.Visibility = Visibility.Visible;
                msgBox.imgInfo.Source = msgBox.imgSource(imageUrl);
            }
            else
                msgBox.imgInfo.Visibility = Visibility.Collapsed;
            if (win != null)
            msgBox.Owner = win;
            msgBox.ShowDialog();
            return msgBox.msgResult;
        }

        public static MsgResult Show(Window win, string displayMessage, string caption)
        {
            JXMessageBox msgBox = new JXMessageBox();
            msgBox.txtDisplayMessage.Text = displayMessage;
            msgBox.lblMessageTitle.Content = caption;
            if (win != null)
                msgBox.Owner = win;
            msgBox.ShowDialog();
            return msgBox.msgResult;
        }

        public static MsgResult Show(Window win, string displayMessage, string caption, MsgButton button)
        {
            JXMessageBox msgBox = new JXMessageBox();
            msgBox.txtDisplayMessage.Text = displayMessage;
            msgBox.lblMessageTitle.Content = caption;
            ButtonShow(button, msgBox);
            if (win != null)
                msgBox.Owner = win;
            msgBox.ShowDialog();
            return msgBox.msgResult;
        }

        public static MsgResult Show(Window win, string displayMessage, string caption, MsgButton button, MsgImage img)
        {
            JXMessageBox msgBox = new JXMessageBox();
            msgBox.txtDisplayMessage.Text = displayMessage;
            msgBox.lblMessageTitle.Content = caption;
            ButtonShow(button, msgBox);

            string imageUrl = "";
            switch (img)
            {
                case MsgImage.Error:
                    imageUrl = @"../Images/error.png";
                    break;
                case MsgImage.Success:
                    imageUrl = @"../Images/success.png";
                    break;

                case MsgImage.Question:
                    imageUrl = @"../Images/question.png";
                    break;
                case MsgImage.Exclamation:
                    imageUrl = @"../Images/wonder.png";
                    break;
            }
            if (img != MsgImage.None)
            {
                msgBox.imgInfo.Visibility = Visibility.Visible;
                msgBox.imgInfo.Source = msgBox.imgSource(imageUrl);
            }
            else
                msgBox.imgInfo.Visibility = Visibility.Collapsed;
            if (win != null)
                msgBox.Owner = win;
            msgBox.ShowDialog();
            return msgBox.msgResult;
        }

        private static void ButtonShow(MsgButton button, JXMessageBox msgBox)
        {
            msgBox.button = button;
            switch (button)
            {
                case MsgButton.OK:
                    msgBox.btnConfirm.Content = "确定";
                    break;
                case MsgButton.Yes:
                    msgBox.btnConfirm.Content = "是";
                    break;
                case MsgButton.Yes_No:
                    msgBox.btnConfirm.Content = "是";
                    //msgBox.btnNo.Visibility = Visibility.Visible;
                    break;
                case MsgButton.OK_Cancel:
                    msgBox.btnConfirm.Content = "确定";
                    msgBox.btnCancel.Visibility = Visibility.Visible;
                    break;
                case MsgButton.Yes_No_Cancel:
                    msgBox.btnConfirm.Content = "是";
                    msgBox.btnCancel.Visibility = Visibility.Visible;
                   // msgBox.btnNo.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.msgResult = MsgResult.No;
            this.Close();
        }

    }

    public enum MsgResult
    {
        OK,
        Yes,
        No,
        Cancel
    }

    public enum MsgButton
    {
        OK,
        Yes,
        OK_Cancel,
        Yes_No,
        Yes_No_Cancel
    }

    public enum MsgImage
    {
        None,
        Question,
        Success,
        Error,
        Exclamation,
        Warning
    }
}
