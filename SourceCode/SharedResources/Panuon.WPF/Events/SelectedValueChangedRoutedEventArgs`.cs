using System.Windows;

namespace Panuon.WPF
{
    public class SelectedValueChangedRoutedEventArgs<T> 
        : RoutedEventArgs
    {
        #region Ctor
        public SelectedValueChangedRoutedEventArgs(RoutedEvent routedEvent, T oldValue, T newValue)
            : base(routedEvent)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }
        #endregion

        #region Properties
        public T NewValue { get; }

        public T OldValue { get; }
        #endregion
    }
}
