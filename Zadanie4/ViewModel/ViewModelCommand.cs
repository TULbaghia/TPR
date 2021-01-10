using System;
using System.Windows.Input;

namespace PresenterViewModel
{
    public class ViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action Action { get; set; }
        private Func<bool> CanExecuteX { get; set; }

        public ViewModelCommand(Action action) : this(action, null) { }
        public ViewModelCommand(Action action, Func<bool> canExecute)
        {
            Action = action;
            CanExecuteX = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteX == null)
            {
                return true;
            }
            return CanExecuteX();
        }

        public void Execute(object parameter)
        {
            Action();
        }
    }
}
