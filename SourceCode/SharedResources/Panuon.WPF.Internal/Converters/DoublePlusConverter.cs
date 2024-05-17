﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Panuon.WPF.Internal.Converters
{
    class DoublePlusConverter 
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
            return doubleValue + para;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            var doubleValue = value as double? ?? 0;
            if (parameter == null)
            {
                return doubleValue;
            }
            var para = double.Parse(parameter.ToString());
            return doubleValue - para;
        }
    }
}
