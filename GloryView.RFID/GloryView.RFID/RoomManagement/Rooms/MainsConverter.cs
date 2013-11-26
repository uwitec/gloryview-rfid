using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GloryView.RFID.RoomManagement.Rooms
{
    [ValueConversion(typeof(int), typeof(String))]
    class MainsConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = int.Parse(value.ToString());
            if (status == 0) return "断 电";
            else if (status == 1) return "通 电";
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
