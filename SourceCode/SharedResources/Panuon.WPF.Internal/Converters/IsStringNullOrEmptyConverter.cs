using System;
using System.Globalization;

namespace Panuon.WPF.Internal.Converters
{
    class IsStringNullOrEmptyConverter 
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;
            return string.IsNullOrEmpty(text);
        }
    }
}
