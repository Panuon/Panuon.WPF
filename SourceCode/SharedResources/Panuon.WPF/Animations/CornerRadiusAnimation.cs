using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Panuon.WPF
{
    public class CornerRadiusAnimation : AnimationTimeline
    {
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(CornerRadius?), typeof(CornerRadiusAnimation));

        public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(CornerRadius?), typeof(CornerRadiusAnimation));

        public CornerRadius? From
        {
            get
            {
                return (CornerRadius?)GetValue(FromProperty);
            }
            set
            {
                SetValue(FromProperty, value);
            }
        }

        public CornerRadius? To
        {
            get
            {
                return (CornerRadius?)GetValue(ToProperty);
            }
            set
            {
                SetValue(ToProperty, value);
            }
        }

        public override Type TargetPropertyType => typeof(CornerRadius);

        public override object GetCurrentValue(object from, object to, AnimationClock clock)
        {
            return GetCurrentValue((CornerRadius)from, (CornerRadius)to, clock);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new CornerRadiusAnimation();
        }

        public CornerRadius GetCurrentValue(CornerRadius from, CornerRadius to, AnimationClock clock)
        {
            if (!clock.CurrentProgress.HasValue)
            {
                return from;
            }
            from = From ?? from;
            to = To ?? to;
            return new CornerRadius(from.TopLeft + (to.TopLeft - from.TopLeft) * clock.CurrentProgress.Value, from.TopRight + (to.TopRight - from.TopRight) * clock.CurrentProgress.Value, from.BottomRight + (to.BottomRight - from.BottomRight) * clock.CurrentProgress.Value, from.BottomLeft + (to.BottomLeft - from.BottomLeft) * clock.CurrentProgress.Value);
        }
    }

}