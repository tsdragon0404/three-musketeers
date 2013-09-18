using System;
using System.Windows.Input;

namespace LS.Core
{
    public class BaseCommand : ICommand
    {
        protected Action Action = null;
        protected Action<object> ParameterizedAction = null;

        #region Constructors

        public BaseCommand(Action action, bool canExecute = true)
        {
            Action = action;
            _canExecute = canExecute;
        }

        public BaseCommand(Action<object> parameterizedAction, bool canExecute = true)
        {
            ParameterizedAction = parameterizedAction;
            _canExecute = canExecute;
        } 

        #endregion

        private bool _canExecute;

        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    var canExecuteChanged = CanExecuteChanged;
                    if (canExecuteChanged != null)
                        canExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }

        void ICommand.Execute(object parameter)
        {
            if(Action != null)
                Action();
            if (ParameterizedAction != null)
                ParameterizedAction(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
