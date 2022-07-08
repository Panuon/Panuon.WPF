﻿using System.Windows;

namespace Panuon.WPF
{
    public class CancelRoutedEventArgs 
        : RoutedEventArgs
    {
        #region Ctor
        public CancelRoutedEventArgs(RoutedEvent routedEvent)
            : base(routedEvent)
        {

        }
        #endregion

        #region Properties
        public bool Cancel { get; set; }
        #endregion
    }
}
