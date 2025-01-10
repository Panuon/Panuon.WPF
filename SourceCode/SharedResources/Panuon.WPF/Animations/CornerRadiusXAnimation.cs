using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Panuon.WPF
{
    public class CornerRadiusXAnimation
        : AnimationTimeline
    {
        #region Properties
        public override Type TargetPropertyType => typeof(CornerRadiusX);

        public CornerRadiusX? From
        {
            get => (CornerRadiusX?)GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }

        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register(nameof(From), typeof(CornerRadiusX?), typeof(CornerRadiusXAnimation));

        public CornerRadiusX? To
        {
            get => (CornerRadiusX?)GetValue(ToProperty);
            set => SetValue(ToProperty, value);
        }

        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register(nameof(To), typeof(CornerRadiusX?), typeof(CornerRadiusXAnimation));
        #endregion

        #region Methods
        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            if (animationClock.CurrentProgress == null)
                return From;

            double progress = animationClock.CurrentProgress.Value;

            var fromValue = From ?? (CornerRadiusX)defaultOriginValue;
            var toValue = To ?? (CornerRadiusX)defaultDestinationValue;

            return new CornerRadiusX(
                Interpolate(fromValue.TopLeft, toValue.TopLeft, progress),
                Interpolate(fromValue.TopRight, toValue.TopRight, progress),
                Interpolate(fromValue.BottomRight, toValue.BottomRight, progress),
                Interpolate(fromValue.BottomLeft, toValue.BottomLeft, progress)
            );
        }

        private DoubleX Interpolate(DoubleX from, DoubleX to, double progress)
        {
            double value = from.Value + (to.Value - from.Value) * progress;
            return new DoubleX(value, from.IsPercentage);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new CornerRadiusXAnimation();
        }
        #endregion
    }
}