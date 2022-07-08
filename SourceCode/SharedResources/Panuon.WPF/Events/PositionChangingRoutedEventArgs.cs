using System.Windows;

namespace Panuon.WPF
{
    public class PositionChangingRoutedEventArgs 
        : CancelRoutedEventArgs
    {
        #region Ctor
        public PositionChangingRoutedEventArgs(RoutedEvent routedEvent, Point position)
            : base(routedEvent)
        {
            NewPosition = position;
        }
        #endregion

        #region Properties
        public Point NewPosition { get; set; }
        #endregion
    }
}
