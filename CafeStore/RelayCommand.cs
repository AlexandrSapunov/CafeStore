using System;
using System.Windows.Input;

namespace CafeStore
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
        {
            this._execute = execute;
        }

        private bool _isExecutable;

        public bool IsExecutable
        {
            get { return _isExecutable; }
            set
            {
                _isExecutable = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsExecutable;
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}
