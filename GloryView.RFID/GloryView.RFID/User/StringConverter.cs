using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GloryView.RFID.User
{
    [ValueConversion(typeof(int), typeof(String))]
    class StringConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int count = int.Parse(value.ToString());
            if (count == 1) return "管理员";
            else return "用户";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
     
        #endregion
    }
}
