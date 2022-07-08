﻿using System;
using System.Windows.Input;

namespace Panuon.WPF
{
    public class RelayCommand<T> 
        : ICommand
    {
        #region Fields
        private readonly Action<T> _executed;
        private readonly Predicate<T> _canExecute;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of <see cref="RelayCommand{T}"/>.
        /// </summary>
        /// <param name="executed">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<T> executed)
            : this(executed, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="executed">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> executed,
            Predicate<T> canExecute)
        {
            if (executed == null)
            {
                throw new ArgumentNullException("execute");
            }

            _executed = executed;
            _canExecute = canExecute;
        }
        
        public RelayCommand(ExecutedRoutedEventHandler executed, 
            CanExecuteRoutedEventHandler canExecute)
        {
            
        }
        #endregion

        #region ICommand Members
        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state.
        ///</summary>
        ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        ///<returns>
        ///true if this command can be executed; otherwise, false.
        ///</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            _executed((T)parameter);
        }
        #endregion
    }
}
