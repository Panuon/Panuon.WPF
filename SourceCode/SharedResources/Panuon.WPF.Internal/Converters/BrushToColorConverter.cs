using System;
using System.Globalization;
using System.Windows.Media;

namespace Panuon.WPF.Internal.Converters
{
    class BrushToColorConverter 
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                if (parameter != null)
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString(parameter as string));
                }
                return null;
            }
            return new SolidColorBrush((Color)value);
        }
    }
}
