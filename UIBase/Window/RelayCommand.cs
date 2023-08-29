using System;
using System.Windows.Input;

namespace UIBase.Window
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T>? _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is not T typedParameter) return false;

            return _canExecute == null || _canExecute.Invoke(typedParameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter is not T typedParameter)
                throw new InvalidOperationException("Parameter type mismatch");

            _execute.Invoke(typedParameter);
        }
    }
}