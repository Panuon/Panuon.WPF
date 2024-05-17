﻿using System;
using System.Globalization;
using System.Windows;

namespace Panuon.WPF.Internal.Converters
{
    class NullToHiddenConverter
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null) ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
