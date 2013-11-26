using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows;
using System.Windows.Media;
using GloryView.RFID.PageControl;
using GloryView.RFID.Utilities;
using System.Reflection;

namespace GloryView.RFID.PrintDocument
{
    class ExportFile
    {

        //导出PDF文件方法
        /// <summary>
        /// DataTable导出到PDF
        /// </summary>
        /// <param name="datatable">DataTable</param>
        /// <param name="PDFFilePath">导出的PDF存储路径</param>
        /// <param name="PdfSaveTitle">导出的文件名</param>
        /// <param name="FontPath">字体路径</param>
        /// <param name="FontSize">字体大小</param>
        /// <param name="widthmz">每一列宽度</param>
        /// <returns>布尔值</returns>
        public static bool ConvertDataTableToPDF(DataTable datatable, string PDFFilePath, string PdfSaveTitle, Brush brush, float FontSize, float[] widthmz)
        {

            if (widthmz == null || widthmz.Length == 0)//如果每一列宽度未指定
            {
                widthmz = new float[datatable.Columns.Count];
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    widthmz[i] = 30f;
                }
            }
            //初始化一个目标文档类
            Document document = new Document(PageSize.A4, 10, 10, 25, 25);
            //调用PDF的写入方法流
            //注意FileMode-Create表示如果目标文件不存在，则创建，如果已存在，则覆盖。
            PdfWriter writer = PdfWriter.getInstance(document, new FileStream(PDFFilePath, FileMode.Create));
            try
            {

                System.Windows.Media.Color color = (System.Windows.Media.Color)ColorConverter.ConvertFromString(brush.ToString());

                //打开目标文档对象
                document.Open();

                // 添加页眉
                HeaderFooter header = new HeaderFooter(new Phrase(PdfSaveTitle), false);
                document.Header = header;
                // 添加页脚
                HeaderFooter footer = new HeaderFooter(new Phrase(PdfSaveTitle), true);
                footer.Border = Rectangle.NO_BORDER;
                document.Footer = footer;

                //创建PDF文档中的字体
                BaseFont baseFont = BaseFont.createFont(@"C:\WINDOWS\Fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                //根据字体路径和字体大小属性创建字体
                Font font = new Font(baseFont, FontSize);
                font.setColor(color.R, color.G, color.B);

                Paragraph pTitle = new Paragraph(new Chunk(PdfSaveTitle, FontFactory.getFont(FontFactory.HELVETICA, 12)));
                document.Add(pTitle);

                //根据数据表内容创建一个PDF格式的表
                PdfPTable table = null;
                table = new PdfPTable(widthmz);

                //打印列名
                for (int j = 0; j < datatable.Columns.Count; j++)
                {
                    string ColumnName =datatable.Columns[j].ColumnName.ToString();
                    table.addCell(new Phrase(ColumnName, font));
                }

                //遍历原table的内容
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    for (int j = 0; j < datatable.Columns.Count; j++)
                    {
                        table.addCell(new Phrase(datatable.Rows[i][j].ToString(), font));
                    }
                }
                //在目标文档中添加转化后的表数据

                document.Add(table);
            }
            catch (Exception ec)
            {
                ec.GetBaseException();
                return false;
            }
            finally
            {
                //关闭目标文件
                document.Close();
                //关闭写入流
                writer.Close();
            }
            return true;
        }

        //HTML文件导出
        public static bool MakeHtml(string fileName, DataSet ds, string title, Brush fontColor, int fontSize)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            BufferedStream bs = new BufferedStream(fs);
            StreamWriter sw = new StreamWriter(bs);
            try
            {

                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'><title>" + title + "</title>" +
                              "<style type='text/css' <!--" +
                              ".normal {  font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: normal; color: #000000}" +
                              ".medium {  font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 15px; font-weight: bold; color: #000000; text-decoration: none}" +
                              "--></style>"
                             );
                sw.WriteLine("<title>");
                sw.WriteLine(title);
                sw.WriteLine("</title>");
                sw.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<center><font=宋体 size=6><b>" + title + "</b></font></center><br>");
                sw.WriteLine("<table border='1' font-size='" + fontSize + "' align='center' >");
                sw.WriteLine("<tr>");
                System.Windows.Media.Color color = (System.Windows.Media.Color)ColorConverter.ConvertFromString(fontColor.ToString());
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {

                    sw.WriteLine("<td bgcolor=silver class='medium'>");
                    string ColumnName = ds.Tables[0].Columns[j].ColumnName.ToString();
                    sw.WriteLine(ColumnName);
                    sw.WriteLine("</td>");
                }
                sw.WriteLine("</tr>");
                //遍历原table的内容
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sw.WriteLine("<tr>");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        sw.WriteLine("<td class='normal' valign='top' color=" + color + ">");
                        sw.WriteLine(ds.Tables[0].Rows[i][j].ToString());
                        sw.WriteLine("</td>");
                    }
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("<br>");
                sw.WriteLine("<div align='center'><font=宋体 size=4> <b>");
                sw.WriteLine("制表用户：" + Session.UserAccount + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "日期：" + DateTime.Now.ToLongDateString());
                sw.WriteLine("</b></font></div");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");

            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
            finally
            {
                sw.Close();
            }
            return true;
        }
        /// <summary>
        /// 将数据集中的数据导出到EXCEL文件
        /// </summary>
        /// <param name="dataSet">输入数据集</param>
        /// <param name="isShowExcle">是否显示该EXCEL文件</param>
        /// <returns></returns>
        public static bool DataSetToExcel(string path)
        {
            try
            {
                ExcelHelper _exportExcel = new ExcelHelper();
                DataSet set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, ExportFileSql.sql);
                _exportExcel.SaveToExcel(path, set.Tables[0]);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
            return true;
        }
    }
}

