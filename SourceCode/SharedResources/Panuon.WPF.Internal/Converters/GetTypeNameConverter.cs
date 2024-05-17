using System;
using System.Globalization;

namespace Panuon.WPF.Internal.Converters
{
    class GetTypeNameConverter
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.GetType()?.Name;
        }
    }
}
