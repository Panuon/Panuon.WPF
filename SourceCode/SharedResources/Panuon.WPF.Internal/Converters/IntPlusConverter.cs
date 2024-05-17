﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Panuon.WPF.Internal.Converters
{
    class IntPlusConverter 
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intValue = value as int? ?? 0;
            if (parameter == null)
            {
                return intValue;
            }
            var para = int.Parse(parameter.ToString());
            return intValue + para;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            var intValue = value as int? ?? 0;
            if (parameter == null)
            {
                return intValue;
            }
            var para = int.Parse(parameter.ToString());
            return intValue - para;
        }
    }
}
