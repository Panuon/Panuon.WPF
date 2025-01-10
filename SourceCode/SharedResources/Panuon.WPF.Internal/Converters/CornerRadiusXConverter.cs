using System;
using System.ComponentModel;
using System.Globalization;

namespace Panuon.WPF
{
    public class CornerRadiusXConverter 
        : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType
        )
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

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
                return CornerRadiusX.Parse(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
