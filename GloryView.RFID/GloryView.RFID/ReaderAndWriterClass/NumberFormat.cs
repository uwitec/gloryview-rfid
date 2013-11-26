using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.ReaderAndWriterClass
{
    [ValueConversion(typeof(int), typeof(String))]
    class NumberFormat : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //ReaderAndWriterConnection _ReaderWriter = new ReaderAndWriterConnection();
            return ReaderAndWriterConnection.getEPCCode(int.Parse(value.ToString()));
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
