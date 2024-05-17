﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.Internal.Converters
{
    class StringNullOrEmptyToCollapseConverter 
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;
            return string.IsNullOrEmpty(text) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
