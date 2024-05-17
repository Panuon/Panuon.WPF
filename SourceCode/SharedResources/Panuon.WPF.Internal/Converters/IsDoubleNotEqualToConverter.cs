﻿using System;
using System.Globalization;

namespace Panuon.WPF.Internal.Converters
{
    class IsDoubleNotEqualToConverter
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value?.ToString(), out double doubleValue))
            {
                if (double.TryParse(parameter?.ToString(), out double doubleParameter))
                {
                    return !doubleValue.Equals(doubleParameter);
                }
            }
            return false;
        }
    }
}
