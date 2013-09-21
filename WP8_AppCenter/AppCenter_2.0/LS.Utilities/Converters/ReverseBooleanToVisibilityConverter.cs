using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LS.Utilities.Converters
{
    public class ReverseBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (Boolean)value ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (Visibility)value == Visibility.Collapsed;
            }
            return true;
        }
    }
}
