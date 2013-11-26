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
using GloryView.RFID.Utilities;
using GloryView.RFID.User;
using System.Data;
using System.Text.RegularExpressions;

namespace GloryView.RFID.PageControl
{

    /// <summary>
    ///wpf分页控件2013年9月7日16:38:06
    /// </summary>
    /// 
    public partial class Pager : UserControl
    {
    //分页依赖属性
        
        public static readonly DependencyProperty FilesPathProperty =
            DependencyProperty.Register("FilesPath", typeof(string), typeof(Pager), new UIPropertyMetadata(""));

        
        public double RowHeight
        {
            get { return (double)GetValue(RowHeightProperty); }
            set { SetValue(RowHeightProperty, value); }
        }
        public static readonly DependencyProperty RowHeightProperty =
            DependencyProperty.Register("RowHeight", typeof(double), typeof(Pager), new UIPropertyMetadata(0.0d));


        public double ColumnWidth
        {
            get { return (double)GetValue(ColumnWidthProperty); }
            set { SetValue(ColumnWidthProperty, value); }
        }
        public static readonly DependencyProperty ColumnWidthProperty =
            DependencyProperty.Register("ColumnWidth", typeof(double), typeof(Pager), new UIPropertyMetadata(0.0d));

        
        
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(int), typeof(Pager), new UIPropertyMetadata(0));

        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }
        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(int), typeof(Pager), new UIPropertyMetadata(0));
       
        
        //一共多少条数据
        public int AllCount
        {
            get { return (int)GetValue(FileCountProperty); }
            set { SetValue(FileCountProperty, value); }
        }

        public static readonly DependencyProperty FileCountProperty =
            DependencyProperty.Register("FileCount", typeof(int), typeof(Pager), new UIPropertyMetadata(0));

        //当前第几条数据
        public int CurrentCount
        {
            get { return (int)GetValue(CurrentCountProperty); }
            set { SetValue(CurrentCountProperty, value); }
        }
        public static readonly DependencyProperty CurrentCountProperty =
            DependencyProperty.Register("CurrentCount", typeof(int), typeof(Pager), new UIPropertyMetadata(0));

        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        public static readonly DependencyProperty CurrentPageProperty = 
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(Pager), new UIPropertyMetadata(0));


        //共几页
        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(Pager), new UIPropertyMetadata(0));
        //#endregion
        //private List<FileInfo> filesList;
        //public delegate void InitHandler();
        //public InitHandler initHandler;
        //private ObservableCollection<CustomFileInfo> CustomFileInfoList;
        public static int PicCountPagePer;
        
        //private Loading load = new Loading();
        public Pager()
        {
            InitializeComponent();
        }
        private DataTable _dt = new DataTable();
        //每页显示多少条
        private int pageNum = BaseRequest.PAGE_SIZE;
        //当前是第几页
        private int pIndex = 1;
        //对象
        private DataGrid grdList;
        //最大页数
        private int MaxIndex = 1;
        //一共多少条
        private int allNum = 0;
        
        public void ShowPages(DataGrid grd, DataSet ds, int Num)
        {
            if (ds == null || ds.Tables.Count == 0)
            {
                return;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                grd.ItemsSource = null;
                return;
            }
            DataTable dt = ds.Tables[0];
            this._dt = dt.Clone();
            this.grdList = grd;
            this.pageNum = Num;
            this.pIndex = 1;
            this.pgSize.Content = Num;
            foreach (DataRow r in dt.Rows)
                this._dt.ImportRow(r);
            SetMaxIndex();
            ReadDataTable();
            if (this.MaxIndex > 1)
            {
                this.PageIndex.IsReadOnly = false;
                this.jumpBnt.IsEnabled = true;
            }
        }

        private void ReadDataTable()
        {
            try
            {
                DataTable tmpTable = new DataTable();
                tmpTable = this._dt.Clone();
                int first = this.pageNum * (this.pIndex - 1);
                first = (first > 0) ? first : 0;
                //如何总数量大于每页显示数量
                if (this._dt.Rows.Count >= this.pageNum * this.pIndex)
                {
                    for (int i = first; i < pageNum * this.pIndex; i++)
                        tmpTable.ImportRow(this._dt.Rows[i]);
                }
                else
                {
                    for (int i = first; i <  this._dt.Rows.Count; i++)
                        tmpTable.ImportRow(this._dt.Rows[i]);
                }
                this.grdList.ItemsSource = tmpTable.DefaultView;
                tmpTable.Dispose();
            }
            catch
            {
                MessageBox.Show("错误");
            }
            finally
            {
                DisplayPagingInfo();
            }

        }
        private void DisplayPagingInfo()
        {
            if (this.pIndex == 1)
            {
                this.btnPrev.IsEnabled = false;
                this.btnFirst.IsEnabled = false;
            }
            else
            {
                this.btnPrev.IsEnabled = true;
                this.btnFirst.IsEnabled = true;
            }
            if (this.pIndex == this.MaxIndex)
            {
                this.btnNext.IsEnabled = false;
                this.btnLast.IsEnabled = false;
            }
            else
            {
                this.btnNext.IsEnabled = true;
                this.btnLast.IsEnabled = true;
            }
            if (this.pIndex == this.MaxIndex)
            {
                this.number.Content = this.allNum;
            }
            else
            {
                this.number.Content = (pIndex * pageNum).ToString();
            }
            this.currentPage.Text = this.pIndex.ToString();
            this.PageIndex.Text = this.pIndex.ToString();
        }
        /// <summary>
        /// 设置最多大页面
        /// </summary>
        private void SetMaxIndex()
        {
            //多少页
            int Pages = this._dt.Rows.Count / pageNum;
            if (this._dt.Rows.Count != (Pages * pageNum))
            {
                if (_dt.Rows.Count < (Pages * pageNum))
                    Pages--;
                else
                    Pages++;
            }
            this.MaxIndex = Pages;
            this.pages.Content = Pages;
            this.allNum = this._dt.Rows.Count;
            this.count.Content = this._dt.Rows.Count;
            this.PageIndex.Text = pIndex.ToString();
        }

        //上一页按钮
        private void BPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (this.pIndex <= 1)
                return;
            this.pIndex--;
            ReadDataTable();
        }
        //下一页按钮
        private void BNextPage_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("...................");
            if (this.pIndex >= this.MaxIndex)
                return;
            this.pIndex++;
            ReadDataTable();
        }
        //首页按钮
        private void BFirstPage_Click(object sender, RoutedEventArgs e)
        {
            this.pIndex = 1;
            ReadDataTable();
        }
        //最后一页按钮
        private void BLastPage_Click(object sender, RoutedEventArgs e)
        {
            this.pIndex = this.MaxIndex;
            ReadDataTable();
        }
        //跳转按钮
        private void BJump_Click(object sender, RoutedEventArgs e)
        {
            if (IsNumber(this.PageIndex.Text))
            {
                int pageNum = int.Parse(this.PageIndex.Text);
                if (pageNum > 0 && pageNum <= this.MaxIndex)
                {
                    this.pIndex = pageNum;
                    ReadDataTable();
                }
                else if (pageNum > this.MaxIndex)
                {
                    this.pIndex = this.MaxIndex;
                    ReadDataTable();
                }
            }
            this.PageIndex.Text = this.pIndex.ToString();
        }
        private static Regex RegNumber = new Regex("^[0-9]+$");


        #region 判断是否是数字
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="valString"></param>
        /// <returns></returns>
        public static bool IsNumber(string valString)
        {
            Match m = RegNumber.Match(valString);
            return m.Success;
        }
        #endregion
        #region 输入验证
        private void PageIndex_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal)
            {
                if (txt.Text.Contains(".") && e.Key == Key.Decimal)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Text.Contains(".") && e.Key == Key.OemPeriod)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void PageIndex_TextChanged(object sender, TextChangedEventArgs e)
        {
            //屏蔽中文输入和非法字符粘贴输入
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
        }
        #endregion
        

        private void UpdateListBoxView()
        {
            this.TransitionBox.Content = PageFirst;
        }

        private void PageFirst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PageFirst.SelectedIndex == -1)
            {
                return;
            }
            CurrentCount = (CurrentPage - 1)*PicCountPagePer + PageFirst.SelectedIndex + 1;
        }

    }
    

}


