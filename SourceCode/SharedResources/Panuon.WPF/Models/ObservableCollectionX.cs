﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Panuon.WPF
{
    public class ObservableCollectionX<T> 
        : ObservableCollection<T>
    {
        #region Fields
        private bool _isUpdating;
        private bool _isAnyUpdated;
        #endregion

        #region Ctor
        public ObservableCollectionX()
            : base()
        {

        }

        public ObservableCollectionX(IEnumerable<T> collection)
            : base(collection)
        {

        }
        #endregion

        #region Properties
        public bool HasItems => Items != null && Items.Any();
        #endregion

        #region Overrides
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (_isUpdating)
            {
                _isAnyUpdated = true;
                return;
            }
            base.OnCollectionChanged(e);
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(HasItems)));
        }
        #endregion

        #region Methods
        public void BeginUpdate()
        {
            _isAnyUpdated = false;
            _isUpdating = true;
        }

        public void EndUpdate()
        {
            _isUpdating = false;
            if (!_isAnyUpdated)
            {
                return;
            }
            try
            {
                base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
            finally
            {
                _isAnyUpdated = false;
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (!items.Any())
            {
                return;
            }

            try
            {
                BeginUpdate();

                foreach (var item in items)
                {
                    Add(item);
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        public new void Clear()
        {
            if (!Items.Any())
            {
                return;
            }
            try
            {
                BeginUpdate();
                base.Clear();
            }
            finally
            {
                EndUpdate();
            }
        }
        #endregion
    }
}
