using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GloryView.RFID.DeviceMigrations.DeviceClass
{
    [ValueConversion(typeof(int), typeof(String))]
    class StatusConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = int.Parse(value.ToString());
            if (status == 1) return "新设备入库";
            else if (status == 15) return "维修设备入库";
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
