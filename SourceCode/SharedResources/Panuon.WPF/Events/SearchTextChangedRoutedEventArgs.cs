using System.Windows;

namespace Panuon.WPF
{
    public class SearchTextChangedRoutedEventArgs 
        : RoutedEventArgs
    {
        #region Ctor
        public SearchTextChangedRoutedEventArgs(RoutedEvent routedEvent, string text)
            : base(routedEvent)
        {
            Text = text;
        }
        #endregion

        #region Properties
        public string Text { get; set; }
        #endregion
    }
}
