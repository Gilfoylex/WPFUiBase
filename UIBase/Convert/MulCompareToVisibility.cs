using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UIBase.Convert
{
    public class MulCompareToVisibility : IMultiValueConverter
    {
        private static Lazy<MulCompareToVisibility> lazyInstance = new Lazy<MulCompareToVisibility>(() => new MulCompareToVisibility());
        public static MulCompareToVisibility Instance => lazyInstance.Value;


        public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                if (values[0] != null && values[1] != null)
                {
                    if (parameter == null)
                    {
                        if (values[0]!.ToString() == values[1]!.ToString())
                            return Visibility.Visible;
                    }
                    else if (parameter.ToString() == "-")
                    {
                        if (values[0]!.ToString() == values[1]!.ToString())
                            return Visibility.Collapsed;
                        else
                            return Visibility.Visible;
                    }
                }
            }
            catch
            {
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
