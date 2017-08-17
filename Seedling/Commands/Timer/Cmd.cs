using System;
using System.Windows.Input;

namespace Seedling.Commands.Timer
{
    public class Cmd : ICommand
    {
        private readonly Action _action;

        public Cmd(Action action)
        {
            _action = action;
        }

        public Action Action
        {
            get { return _action; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}