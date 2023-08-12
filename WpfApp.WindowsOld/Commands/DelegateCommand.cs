using System;
using System.Windows.Input;

namespace WpfApp.WindowsOld.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseExecuteChangedEvent()=> CanExecuteChanged(this, EventArgs.Empty);

        public bool CanExecute(object parameter)
        => (_canExecute == null || (_canExecute(parameter))) ? true : false;

        public void Execute(object parameter) => _execute(parameter);
    }
}
