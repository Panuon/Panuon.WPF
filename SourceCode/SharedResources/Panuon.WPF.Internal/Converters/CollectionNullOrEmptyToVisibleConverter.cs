using System;
using System.Globalization;
using System.Windows;

namespace Panuon.WPF.Internal.Converters
{
    class CollectionNullOrEmptyToVisibleConverter
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CollectionNullOrEmptyToCollapseConverter.IsNullOrEmpty(value)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
    }
}
