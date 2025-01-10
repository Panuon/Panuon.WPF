using System;
using System.ComponentModel;
using System.Windows;

namespace Panuon.WPF
{
    [TypeConverter(typeof(CornerRadiusXConverter))]
    public struct CornerRadiusX
    {
        #region Ctor
        public CornerRadiusX(DoubleX uniformRadius)
        {
            TopLeft = TopRight = BottomRight = BottomLeft = uniformRadius;
        }

        public CornerRadiusX(
            DoubleX topLeft,
            DoubleX topRight,
            DoubleX bottomRight,
            DoubleX bottomLeft
        )
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomRight = bottomRight;
            BottomLeft = bottomLeft;
        }
        #endregion

        #region Properties
        public DoubleX TopLeft { get; set; }
        public DoubleX TopRight { get; set; }
        public DoubleX BottomRight { get; set; }
        public DoubleX BottomLeft { get; set; }
        #endregion

        #region Methods
        public static CornerRadiusX Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));
            }

            var parts = value.Split(',');

            var radii = new DoubleX[4];
            for (int i = 0; i < parts.Length && i < 4; i++)
            {
                radii[i] = DoubleX.Parse(parts[i].Trim());
            }

            if (parts.Length == 1)
            {
                return new CornerRadiusX(radii[0]);
            }
            else if (parts.Length == 4)
            {
                return new CornerRadiusX(radii[0], radii[1], radii[2], radii[3]);
            }
            else
            {
                throw new FormatException("Invalid CornerRadiusX format. Use 'uniform', 'topLeft, topRight, bottomRight, bottomLeft', or percentages.");
            }
        }

        public CornerRadius ToCornerRadius(double width, double height)
        {
            double baseValue = Math.Min(width, height);
            return new CornerRadius(
                TopLeft.GetActualValue(baseValue),
                TopRight.GetActualValue(baseValue),
                BottomRight.GetActualValue(baseValue),
                BottomLeft.GetActualValue(baseValue)
            );
        }

        public static implicit operator CornerRadiusX(CornerRadius cornerRadius)
        {
            return new CornerRadiusX(
                cornerRadius.TopLeft,
                cornerRadius.TopRight,
                cornerRadius.BottomRight,
                cornerRadius.BottomLeft
            );
        }

        public static implicit operator CornerRadius(CornerRadiusX cornerRadiusX)
        {
            return new CornerRadius(
                cornerRadiusX.TopLeft,
                cornerRadiusX.TopRight,
                cornerRadiusX.BottomRight,
                cornerRadiusX.BottomLeft
            );
        }

        public override string ToString()
        {
            return $"{TopLeft}, {TopRight}, {BottomRight}, {BottomLeft}";
        }
        #endregion
    }
}
