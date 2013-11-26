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
using Microsoft.Win32;
using System.Windows.Forms;
using GloryView.RFID.PageControl;
using GloryView.RFID.RoomManagement.Rooms;
using System.Data;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.PrintDocument
{
    /// <summary>
    /// Export_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Export_Window : Window
    {
        public Export_Window()
        {
            InitializeComponent();
           // this.SizeChanged += none;
        }

        private Microsoft.Win32.SaveFileDialog sfd;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.reportWord.IsChecked==true)
            {
                sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Word文件(*.doc)|*.doc";
                sfd.ShowDialog();

                this.pathText.Text = sfd.FileName;
            }
            else if (this.reportExcel.IsChecked == true)
            {
                sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Excel文件(*.xls)|*.xls";
                sfd.ShowDialog();
                this.pathText.Text = sfd.FileName;
            }
            else if (this.reportPdf.IsChecked == true)
            {
                sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "PDF文件(*.pdf)|*.pdf";
                sfd.ShowDialog();
                this.pathText.Text = sfd.FileName;
            }
            else if (this.reportHtml.IsChecked == true)
            {
                sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Html文件(*.Html)|*.Html";
                sfd.ShowDialog();
                this.pathText.Text = sfd.FileName;
            }
            else
            {
                JXMessageBox.Show(this, "请选择导出文件格式!", MsgImage.Error);
            }
            
        }


        private void reportWord_Checked(object sender, RoutedEventArgs e)
        {
            this.wname1.Foreground = Brushes.Black;
            this.wname2.Foreground = Brushes.Black;
            this.wname3.Foreground = Brushes.Black;
            this.wname4.Foreground = Brushes.Black;
            this.wordfont.IsReadOnly = false;
            this.wordfont.Foreground = Brushes.Black;
            this.wordfont.Background = Brushes.White;
            this.wordColor.Background = Brushes.Black;
            this.wordHeight.IsReadOnly = false;
            this.wordHeight.Foreground = Brushes.Black;
            this.wordHeight.Background=Brushes.White;
            this.wordWidth.IsReadOnly = false;
            this.wordWidth.Foreground = Brushes.Black;
            this.wordWidth.Background = Brushes.White;
            //excel
            this.ename1.Foreground = Brushes.White;
            this.ename2.Foreground = Brushes.White;
            this.ename3.Foreground = Brushes.White;
            this.ename4.Foreground = Brushes.White;
            this.excelFont.IsReadOnly = true;
            this.excelFont.Foreground = Brushes.White;
            this.excelFont.Background = null; 
            this.ExcelColor.Background = null;
            this.excelHeight.IsReadOnly = true;
            this.excelHeight.Foreground = Brushes.White;
            this.excelHeight.Background = null;
            this.excelWidth.IsReadOnly = true;
            this.excelWidth.Foreground = Brushes.White;
            this.excelWidth.Background = null;
            //pdf
            this.pname1.Foreground = Brushes.White;
            this.pname2.Foreground = Brushes.White;
            this.pname3.Foreground = Brushes.White;
            this.pname4.Foreground = Brushes.White;
            this.pdfFont.IsReadOnly = true;
            this.pdfFont.Foreground = Brushes.White;
            this.pdfFont.Background = null;
            this.pdfColor.Background = null;
            this.pdfheight.IsReadOnly = true;
            this.pdfheight.Foreground = Brushes.White;
            this.pdfheight.Background = null;
            this.pdfWidh.IsReadOnly = true;
            this.pdfWidh.Foreground = Brushes.White;
            this.pdfWidh.Background = null;
            //html
            this.hname1.Foreground = Brushes.White;
            this.hname2.Foreground = Brushes.White;
            this.hname3.Foreground = Brushes.White;
            this.hname4.Foreground = Brushes.White;
            this.htmlFont.IsReadOnly = true;
            this.htmlFont.Foreground = Brushes.White;
            this.htmlFont.Background = null;
            this.htmlColor.Background = null;
            this.htmlHeight.IsReadOnly = true;
            this.htmlHeight.Foreground = Brushes.White;
            this.htmlHeight.Background = null;
            this.htmlWidth.IsReadOnly = true;
            this.htmlWidth.Foreground = Brushes.White;
            this.htmlWidth.Background = null;
            this.pathText.Text = null;
        //    this.wordBorder.Visibility = Visibility.Hidden;
        //    this.excleBorder.Visibility = Visibility.Visible;
        //    this.pdfBorder.Visibility = Visibility.Visible;
        //    this.htmlBorder.Visibility = Visibility.Visible;
        }

        private void reportExcel_Checked(object sender, RoutedEventArgs e)
        {
            this.ename1.Foreground = Brushes.Black;
            this.ename2.Foreground = Brushes.Black;
            this.ename3.Foreground = Brushes.Black;
            this.ename4.Foreground = Brushes.Black;
            this.excelFont.IsReadOnly = false;
            this.excelFont.Foreground = Brushes.Black;
            this.excelFont.Background = Brushes.White;
            this.ExcelColor.Background = Brushes.Black;
            this.excelHeight.IsReadOnly = false;
            this.excelHeight.Foreground = Brushes.Black;
            this.excelHeight.Background = Brushes.White;
            this.excelWidth.IsReadOnly = false;
            this.excelWidth.Foreground = Brushes.Black;
            this.excelWidth.Background = Brushes.White;
            //word
            this.wname1.Foreground = Brushes.White;
            this.wname2.Foreground = Brushes.White;
            this.wname3.Foreground = Brushes.White;
            this.wname4.Foreground = Brushes.White;
            this.wordfont.IsReadOnly = true;
            this.wordfont.Foreground = Brushes.White;
            this.wordfont.Background = null;
            this.wordColor.Background = null;
            this.wordHeight.IsReadOnly = true;
            this.wordHeight.Background = null;
            this.wordHeight.Foreground = Brushes.White;
            this.wordWidth.IsReadOnly = true;
            this.wordWidth.Foreground = Brushes.White;
            this.wordWidth.Background = null;
            //pdf
            this.pname1.Foreground = Brushes.White;
            this.pname2.Foreground = Brushes.White;
            this.pname3.Foreground = Brushes.White;
            this.pname4.Foreground = Brushes.White;
            this.pdfFont.IsReadOnly = true;
            this.pdfFont.Foreground = Brushes.White;
            this.pdfFont.Background = null;
            this.pdfColor.Background = null;
            this.pdfheight.IsReadOnly = true;
            this.pdfheight.Foreground = Brushes.White;
            this.pdfheight.Background = null;
            this.pdfWidh.IsReadOnly = true;
            this.pdfWidh.Foreground = Brushes.White;
            this.pdfWidh.Background = null;
            //html
            this.hname1.Foreground = Brushes.White;
            this.hname2.Foreground = Brushes.White;
            this.hname3.Foreground = Brushes.White;
            this.hname4.Foreground = Brushes.White;
            this.htmlFont.IsReadOnly = true;
            this.htmlFont.Foreground = Brushes.White;
            this.htmlFont.Background = null;
            this.htmlColor.Background = null;
            this.htmlHeight.IsReadOnly = true;
            this.htmlHeight.Foreground = Brushes.White;
            this.htmlHeight.Background = null;
            this.htmlWidth.IsReadOnly = true;
            this.htmlWidth.Foreground = Brushes.White;
            this.htmlWidth.Background = null;
            this.pathText.Text = null;
        //    this.wordBorder.Visibility = Visibility.Visible;
        //    this.excleBorder.Visibility = Visibility.Hidden;
        //    this.pdfBorder.Visibility = Visibility.Visible;
        //    this.htmlBorder.Visibility = Visibility.Visible;
        }

        private void reportPdf_Checked(object sender, RoutedEventArgs e)
        {
            this.pname1.Foreground = Brushes.Black;
            this.pname2.Foreground = Brushes.Black;
            this.pname3.Foreground = Brushes.Black;
            this.pname4.Foreground = Brushes.Black;
            this.pdfFont.IsReadOnly = false;
            this.pdfFont.Foreground = Brushes.Black;
            this.pdfFont.Background = Brushes.White;
            this.pdfColor.Background = Brushes.Black;
            this.pdfheight.IsReadOnly = false;
            this.pdfheight.Foreground = Brushes.Black;
            this.pdfheight.Background = Brushes.White;
            this.pdfWidh.IsReadOnly = false;
            this.pdfWidh.Foreground = Brushes.Black;
            this.pdfWidh.Background = Brushes.White;
            //word
            this.wname1.Foreground = Brushes.White;
            this.wname2.Foreground = Brushes.White;
            this.wname3.Foreground = Brushes.White;
            this.wname4.Foreground = Brushes.White;
            this.wordfont.IsReadOnly = true;
            this.wordfont.Foreground = Brushes.White;
            this.wordfont.Background = null;
            this.wordColor.Background = null;
            this.wordHeight.IsReadOnly = true;
            this.wordHeight.Background = null;
            this.wordHeight.Foreground = Brushes.White;
            this.wordWidth.IsReadOnly = true;
            this.wordWidth.Foreground = Brushes.White;
            this.wordWidth.Background = null;
            //excel
            this.ename1.Foreground = Brushes.White;
            this.ename2.Foreground = Brushes.White;
            this.ename3.Foreground = Brushes.White;
            this.ename4.Foreground = Brushes.White;
            this.excelFont.IsReadOnly = true;
            this.excelFont.Foreground = Brushes.White;
            this.excelFont.Background = null;
            this.ExcelColor.Background = null;
            this.excelHeight.IsReadOnly = true;
            this.excelHeight.Foreground = Brushes.White;
            this.excelHeight.Background = null;
            this.excelWidth.IsReadOnly = true;
            this.excelWidth.Foreground = Brushes.White;
            this.excelWidth.Background = null;
            //html
            this.hname1.Foreground = Brushes.White;
            this.hname2.Foreground = Brushes.White;
            this.hname3.Foreground = Brushes.White;
            this.hname4.Foreground = Brushes.White;
            this.htmlFont.IsReadOnly = true;
            this.htmlFont.Foreground = Brushes.White;
            this.htmlFont.Background = null;
            this.htmlColor.Background = null;
            this.htmlHeight.IsReadOnly = true;
            this.htmlHeight.Foreground = Brushes.White;
            this.htmlHeight.Background = null;
            this.htmlWidth.IsReadOnly = true;
            this.htmlWidth.Foreground = Brushes.White;
            this.htmlWidth.Background = null;
            this.pathText.Text = null;
        //    this.wordBorder.Visibility = Visibility.Visible;
        //    this.excleBorder.Visibility = Visibility.Visible;
        //    this.pdfBorder.Visibility = Visibility.Hidden;
        //    this.htmlBorder.Visibility = Visibility.Visible;
        }

        private void reportHtml_Checked(object sender, RoutedEventArgs e)
        {
            this.hname1.Foreground = Brushes.Black;
            this.hname2.Foreground = Brushes.Black;
            this.hname3.Foreground = Brushes.Black;
            this.hname4.Foreground = Brushes.Black;
            this.htmlFont.IsReadOnly = false;
            this.htmlFont.Foreground = Brushes.Black;
            this.htmlFont.Background = Brushes.White;
            this.htmlColor.Background = Brushes.Black;
            this.htmlHeight.IsReadOnly = false;
            this.htmlHeight.Foreground = Brushes.Black;
            this.htmlHeight.Background = Brushes.White;
            this.htmlWidth.IsReadOnly = false;
            this.htmlWidth.Foreground = Brushes.Black;
            this.htmlWidth.Background = Brushes.White;
            //word
            this.wname1.Foreground = Brushes.White;
            this.wname2.Foreground = Brushes.White;
            this.wname3.Foreground = Brushes.White;
            this.wname4.Foreground = Brushes.White;
            this.wordfont.IsReadOnly = true;
            this.wordfont.Foreground = Brushes.White;
            this.wordfont.Background = null;
            this.wordColor.Background = null;
            this.wordHeight.IsReadOnly = true;
            this.wordHeight.Background = null;
            this.wordHeight.Foreground = Brushes.White;
            this.wordWidth.IsReadOnly = true;
            this.wordWidth.Foreground = Brushes.White;
            this.wordWidth.Background = null;
            //excel
            this.ename1.Foreground = Brushes.White;
            this.ename2.Foreground = Brushes.White;
            this.ename3.Foreground = Brushes.White;
            this.ename4.Foreground = Brushes.White;
            this.excelFont.IsReadOnly = true;
            this.excelFont.Foreground = Brushes.White;
            this.excelFont.Background = null;
            this.ExcelColor.Background = null;
            this.excelHeight.IsReadOnly = true;
            this.excelHeight.Foreground = Brushes.White;
            this.excelHeight.Background = null;
            this.excelWidth.IsReadOnly = true;
            this.excelWidth.Foreground = Brushes.White;
            this.excelWidth.Background = null;
            //pdf
            this.pname1.Foreground = Brushes.White;
            this.pname2.Foreground = Brushes.White;
            this.pname3.Foreground = Brushes.White;
            this.pname4.Foreground = Brushes.White;
            this.pdfFont.IsReadOnly = true;
            this.pdfFont.Foreground = Brushes.White;
            this.pdfFont.Background = null;
            this.pdfColor.Background = null;
            this.pdfheight.IsReadOnly = true;
            this.pdfheight.Foreground = Brushes.White;
            this.pdfheight.Background = null;
            this.pdfWidh.IsReadOnly = true;
            this.pdfWidh.Foreground = Brushes.White;
            this.pdfWidh.Background = null;
            this.pathText.Text = null;
        //    this.wordBorder.Visibility = Visibility.Visible;
        //    this.excleBorder.Visibility = Visibility.Visible;
        //    this.pdfBorder.Visibility = Visibility.Visible;
        //    this.htmlBorder.Visibility = Visibility.Hidden;
        }
       

        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Label l= (sender as System.Windows.Controls.Label);//(System.Windows.Controls.Label)sender(this);
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.SolidBrush sb = new System.Drawing.SolidBrush(colorDialog.Color);
                SolidColorBrush solidColorBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(sb.Color.R, sb.Color.G, sb.Color.B));
                l.Background = solidColorBrush;
            }
        }
        public void changeIt()
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            
                if (this.pathText.Text.Equals(""))
                {
                    JXMessageBox.Show(this, "文件名与保存路径不能为空!", MsgImage.Error);
                    return;
                }
                bool b=false;
                FileBean bean = new FileBean();
                if (this.reportWord.IsChecked == true)
                {
                    bean.FontSize = int.Parse(this.wordfont.Text);
                    bean.Color = this.wordColor.Background;
                    bean.Width = int.Parse(this.wordWidth.Text);
                    bean.Height = int.Parse(this.wordHeight.Text);
                }
                else if (this.reportExcel.IsChecked == true)
                {
                    //bean.FontSize = int.Parse(this.excelFont.Text);
                    //bean.Color = this.ExcelColor.Background;
                    //bean.Width = int.Parse(this.excelWidth.Text);
                    //bean.Height = int.Parse(this.excelHeight.Text);
                    string path=@""+this.pathText.Text;
                    RoomClass rc = new RoomClass();
                    DataSet dataSet = rc.queryHistoryAlarmList();
                    b=ExportFile.DataSetToExcel(path);
                   
                }
                else if (this.reportPdf.IsChecked == true)
                {
                    //bean.FontSize = int.Parse(this.pdfFont.Text);
                    float fontSize = float.Parse(this.pdfFont.Text);
                    //bean.Color = this.pdfColor.Background;
                    Brush color = this.pdfColor.Background;
                    //bean.Width = int.Parse(this.pdfWidh.Text);
                    //bean.Height = int.Parse(this.pdfheight.Text);
                    string title = "历史报警表";
                    string path = @"" + this.pathText.Text;
                   
                       // RoomClass rc = new RoomClass();
                    DataSet dataSet = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, ExportFileSql.sql);
                    b= ExportFile.ConvertDataTableToPDF(dataSet.Tables[0], path, title,color, fontSize, null);
                }
                else if (this.reportHtml.IsChecked == true)
                {
                   //bean.FontSize = int.Parse(this.htmlFont.Text);
                   // bean.Color = this.htmlColor.Background;
                   // bean.Width = int.Parse(this.htmlWidth.Text);
                    //string fontColor = this.htmlColor.Background.ToString();
                    //System.Windows.MessageBox.Show(fontColor);
                    string path = @"" + this.pathText.Text;
                    //bean.Height = int.Parse(this.htmlHeight.Text);
                    //RoomClass rc = new RoomClass();
                    DataSet dataSet = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, ExportFileSql.sql);
                    string title = "历史报警数据";
                    b = ExportFile.MakeHtml(path, dataSet, title, this.htmlColor.Background, int.Parse(this.htmlFont.Text));

                }
                if (b == true)
                {
                    JXMessageBox.Show(this, "文件成功导出!", MsgImage.Success);
                }
                else
                {
                    JXMessageBox.Show(this, "文件导出失败!", MsgImage.Error);
                }
            }
            
        }
    }

