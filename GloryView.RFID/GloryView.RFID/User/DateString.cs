using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GloryView.RFID.User
{
    [ValueConversion(typeof(String), typeof(String))]
    class DateString : IValueConverter
    {

        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || "".Equals(value.ToString())) return "";
            DateTime date = DateTime.Parse(value.ToString());
            return date.ToString("yyyy-MM-dd hh:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
