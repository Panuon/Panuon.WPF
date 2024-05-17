﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.WPF.Internal.Converters
{
    class DoublePowConverter 
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = value as double? ?? 0;
            if (parameter == null)
            {
                return doubleValue;
            }
            var para = double.Parse(parameter.ToString());
            return Math.Pow(doubleValue, para);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
