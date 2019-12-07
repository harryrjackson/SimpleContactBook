using System;
using System.Windows.Input;

namespace SimpleContactBook.Utility
{
    public class RelayCommand<T> : ICommand
    {

        #region Variables

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) 
        {
            if (execute == null)
            {
                throw new NullReferenceException(nameof(execute));
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        #endregion

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #region Properties

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        #endregion

        #region Methods

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        #endregion
    }
}
