using System;
using System.Globalization;

namespace Panuon.WPF.Internal.Converters
{
    class GetTypeConverter 
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.GetType();
        }
    }
}
