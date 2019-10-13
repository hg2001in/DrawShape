using System;
using System.Windows.Input;

namespace DrawShapes.MVVM
{
    public class ViewModelCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
       
        public event EventHandler CanExecuteChanged;
      
        public ViewModelCommand(Action execute)
            : this(execute, null)
        {
        }

        public ViewModelCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}