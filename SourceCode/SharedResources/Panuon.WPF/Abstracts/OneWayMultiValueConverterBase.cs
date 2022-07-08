using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF
{
    public abstract class OneWayMultiValueConverterBase 
        : IMultiValueConverter
    {
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var values = new object[targetTypes.Length];
            for (var i = 0; i < targetTypes.Length; i++)
            {
                values[i] = DependencyProperty.UnsetValue;
            }
            return values;

        }
    }
}
