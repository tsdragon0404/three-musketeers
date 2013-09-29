using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LS.Utilities.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (Boolean)value ? "Lime" : "White";
            }

            return "White";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (string)value == "Lime";
            }
            return "White";
        }
    }
}
