using System;
using System.Globalization;
using System.Windows;

namespace Panuon.WPF.UI.Internal.Converters
{
    internal class CornerRadiusXToCornerRadiusConverter
        : OneWayMultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null 
                || values.Length < 3)
            {
                throw new ArgumentException("Expected CornerRadiusX, ActualWidth, and ActualHeight as inputs.");
            }

            var cornerRadiusX = values[0] as CornerRadiusX?;
            if (cornerRadiusX == null)
            {
                throw new ArgumentException("First value must be of type CornerRadiusX.");
            }

            var actualWidth = values[1] as double?;
            var actualHeight = values[2] as double?;


            if (actualWidth == null || actualHeight == null)
            {
                throw new ArgumentException("Second and third values must be of type double (ActualWidth and ActualHeight).");
            }

            double baseValue = Math.Min((double)actualWidth, (double)actualHeight);
            return new CornerRadius(
                ((CornerRadiusX)cornerRadiusX).TopLeft.GetActualValue(baseValue),
                ((CornerRadiusX)cornerRadiusX).TopRight.GetActualValue(baseValue),
                ((CornerRadiusX)cornerRadiusX).BottomRight.GetActualValue(baseValue),
                ((CornerRadiusX)cornerRadiusX).BottomLeft.GetActualValue(baseValue)
            );
        }
    }
}
