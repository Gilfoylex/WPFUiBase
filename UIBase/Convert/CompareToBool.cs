using System;
using System.Globalization;
using System.Windows.Data;

namespace UIBase.Convert
{
    public class CompareToBool : IValueConverter
    {
        private static readonly Lazy<CompareToBool>
            Lazy = new Lazy<CompareToBool>(() => new CompareToBool());
        public static CompareToBool Instance => Lazy.Value;

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                return value.ToString() == parameter.ToString();
            }

            return false;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
