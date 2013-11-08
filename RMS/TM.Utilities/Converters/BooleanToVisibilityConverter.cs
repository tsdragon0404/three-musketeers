using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TM.Utilities.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (Boolean)value ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (Visibility)value == Visibility.Visible;
            }
            return false;
        }
    }
}
