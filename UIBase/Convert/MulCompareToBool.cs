using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UIBase.Convert
{
    public class MulCompareToBool : IMultiValueConverter
    {
        private static Lazy<MulCompareToBool> lazyInstance = new Lazy<MulCompareToBool>(() => new MulCompareToBool());
        public static MulCompareToBool Instance => lazyInstance.Value;


        public object Convert(object? [] values, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                if (values[0] != null && values[1] != null)
                {
                    if (parameter == null)
                    {
                        if (values[0]!.ToString() == values[1]!.ToString())
                            return true;
                    }
                    else if (parameter.ToString() == "-")
                    {
                        if (values[0]!.ToString() == values[1]!.ToString())
                            return false;
                        else
                            return true;
                    }
                }
            }
            catch { }
            return false;
        }

        public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
