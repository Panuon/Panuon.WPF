using System.Windows;

namespace Panuon.WPF
{
    public class ItemRemovingRoutedEventArgs 
        : CancelRoutedEventArgs
    {
        #region Ctor
        public ItemRemovingRoutedEventArgs(RoutedEvent routedEvent, object item)
            : base(routedEvent)
        {
            Item = item;
        }
        #endregion

        #region Properties
        public object Item { get; set; }
        #endregion
    }
}
