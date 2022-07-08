using System.Windows;

namespace Panuon.WPF
{
    public class PositionChangedRoutedEventArgs
        : RoutedEventArgs
    {
        #region Ctor
        public PositionChangedRoutedEventArgs(RoutedEvent routedEvent, Point position)
            : base(routedEvent)
        {
            Position = position;
        }
        #endregion

        #region Properties
        public Point Position { get; }
        #endregion
    }
}
