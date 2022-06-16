using System;
using System.Globalization;
using System.Windows.Data;

namespace MedicationManager.UI.Common.Converters
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? "+" : "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string) value;

            return str.Equals("+");
        }
    }
}
