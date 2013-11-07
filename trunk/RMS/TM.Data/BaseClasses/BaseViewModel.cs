using Caliburn.Micro;

namespace TM.Data.BaseClasses
{
    public class BaseViewModel : Screen
    {
        private bool _isDirty;
        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                NotifyOfPropertyChange(() => IsDirty);
            }
        }

        // ReSharper disable ExplicitCallerInfoArgument
        public override void NotifyOfPropertyChange(string propertyName = "")
        {
            _isDirty = true;
            base.NotifyOfPropertyChange(propertyName);
        }
        // ReSharper restore ExplicitCallerInfoArgument

        public virtual void InitializeData()
        {
            
        }
    }
}