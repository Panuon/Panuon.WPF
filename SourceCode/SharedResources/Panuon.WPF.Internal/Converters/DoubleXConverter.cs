﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace Panuon.WPF
{
    public class DoubleXConverter 
         : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType
        )
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value
        )
        {
            if (value is string stringValue)
            {
                return DoubleX.Parse(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
