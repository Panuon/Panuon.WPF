using System;
using System.Globalization;

namespace Panuon.WPF.Internal.Converters
{
    internal class HasEnumFlagConverter
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = (Enum)value;
            var targetValue = (Enum)Enum.Parse(enumValue.GetType(), parameter.ToString());
            return enumValue.HasFlag(targetValue);
        }
    }
}