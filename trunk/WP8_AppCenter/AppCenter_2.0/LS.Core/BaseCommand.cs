using System;
using System.Windows.Input;

namespace LS.Core
{
    public class BaseCommand : ICommand
    {
        protected Action Action = null;
        protected Action<Object> ParameterizedAction = null;

        #region Constructors

        public BaseCommand(Action action, Boolean canExecute = true)
        {
            Action = action;
            _canExecute = canExecute;
        }

        public BaseCommand(Action<Object> parameterizedAction, Boolean canExecute = true)
        {
            ParameterizedAction = parameterizedAction;
            _canExecute = canExecute;
        } 

        #endregion

        private Boolean _canExecute;

        public Boolean CanExecute
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

        bool ICommand.CanExecute(Object parameter)
        {
            return _canExecute;
        }

        void ICommand.Execute(Object parameter)
        {
            if(Action != null)
                Action();
            if (ParameterizedAction != null)
                ParameterizedAction(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
