using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace UIBase.Convert
{
    public class CompareToVisibility : IValueConverter
    {
        private static readonly Lazy<CompareToVisibility>
            Lazy = new (() => new CompareToVisibility());
        public static CompareToVisibility Instance => Lazy.Value;

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                return value.ToString() == parameter.ToString() ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
