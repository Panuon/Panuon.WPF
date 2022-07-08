using System.Windows;

namespace Panuon.WPF
{
    public class ItemRemovedRoutedEventArgs 
        : RoutedEventArgs
    {
        #region Ctor
        public ItemRemovedRoutedEventArgs(RoutedEvent routedEvent, object item)
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
