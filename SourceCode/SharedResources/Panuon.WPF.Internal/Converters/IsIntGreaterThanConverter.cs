﻿using System;
using System.Globalization;

namespace Panuon.WPF.Internal.Converters
{
    class IsIntGreaterThanConverter
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse(value?.ToString(), out int intValue))
            {
                if (int.TryParse(parameter?.ToString(), out int intParameter))
                {
                    return intValue > intParameter;
                }
            }
            return false;
        }
    }
}
