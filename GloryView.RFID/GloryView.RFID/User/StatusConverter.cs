using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GloryView.RFID.User
{
    [ValueConversion(typeof(int), typeof(String))]
    class StatusConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = int.Parse(value.ToString());
            if (status == 0) return "未激活";
            else if (status == 1) return "已激活";
            else return "禁 用";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
