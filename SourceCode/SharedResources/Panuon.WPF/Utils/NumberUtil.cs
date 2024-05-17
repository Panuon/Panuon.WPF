using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Panuon.WPF.Internal.Utils
{
    internal static class NumberUtil
    {
        public static string Format(double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}