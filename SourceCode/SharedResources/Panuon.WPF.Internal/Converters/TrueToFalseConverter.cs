﻿using System;
using System.Globalization;

namespace Panuon.WPF.Internal.Converters
{
    class TrueToFalseConverter 
        : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool boolean && boolean) ? false : true;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool boolean && boolean) ? false : true;
        }
    }
}
