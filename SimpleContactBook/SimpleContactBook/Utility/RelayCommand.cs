using System;
using System.Windows.Input;

namespace SimpleContactBook.Utility
{
    public class RelayCommand<T> : ICommand
    {

        #region Variables

        private readonly Action<T> _execute = null;
        private readonly Func<T, bool> _canExecute = null;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null) 
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (_ => true);
        }

        #endregion

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #region Properties

        public bool CanExecute(object parameter) => _canExecute((T)parameter);

        #endregion

        #region Methods

        public void Execute(object parameter) => _execute((T)parameter);

        #endregion
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute) : base(_ => execute()) { }
        public RelayCommand(Action execute, Func<bool> canExecute) : base(_ => execute(), _ => canExecute()) { }
    }
}
