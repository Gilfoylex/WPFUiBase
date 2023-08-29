using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace UIBase.Convert
{
    public class CompareToShow : IValueConverter
    {
        private static readonly Lazy<CompareToShow>
            Lazy = new (() => new CompareToShow());
        public static CompareToShow Instance => Lazy.Value;

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                return value.ToString() == parameter.ToString() ? Visibility.Visible : Visibility.Hidden;
            }

            return Visibility.Hidden;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
