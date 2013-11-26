using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GloryView.RFID.SystemManagement.SystemClass
{
    [ValueConversion(typeof(int), typeof(String))]
    class OperateTypeStr : IValueConverter
    {
        #region IValueConverter 成员
        //操作类别状态转换
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (int.Parse(value.ToString()))
            {
                case 6: return "完成入库";
                case 10: return "完成出库";
                case 14: return "完成报废";
                case 18: return "完成报修";
                case 25: return "完成迁移";

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
        
    }
}
