using System;
using System.ComponentModel;
using System.Globalization;

namespace Panuon.WPF
{
    [TypeConverter(typeof(DoubleXConverter))]
    public struct DoubleX
    {
        #region Fields
        private readonly double _value;
        private readonly bool _isPercentage;
        #endregion

        #region Ctor
        public DoubleX(
            double value, 
            bool isPercentage = false
        )
        {
            _value = value;
            _isPercentage = isPercentage;
        }
        #endregion

        #region Properties
        public bool IsPercentage => _isPercentage;

        public double Value => _value;
        #endregion

        #region Methods
        public double GetActualValue(double baseValue)
        {
            if (_isPercentage)
            {
                return _value / 100.0 * baseValue;
            }
            return _value;
        }

        public static DoubleX Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));
            }

            value = value.Trim();
            if (value.EndsWith("%"))
            {
                var percentageValue = value.Substring(0, value.Length - 1);
                if (double.TryParse(percentageValue, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
                {
                    return new DoubleX(result, true);
                }
            }
            else
            {
                if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
                {
                    return new DoubleX(result, false);
                }
            }

            throw new FormatException($"Invalid DoubleX format: {value}");
        }

        public static implicit operator DoubleX(double value)
        {
            return new DoubleX(value, false);
        }

        public static implicit operator double(DoubleX doubleX)
        {
            return doubleX.GetActualValue(1);
        }

        public override string ToString()
        {
            return _isPercentage ? $"{_value}%" : _value.ToString(CultureInfo.InvariantCulture);
        }
        #endregion
    }
}
