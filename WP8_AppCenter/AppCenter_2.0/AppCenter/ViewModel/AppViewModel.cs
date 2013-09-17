using System.ComponentModel;
using AppCenter.Data;

namespace AppCenter.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private AppCenterDataContext _appCenterDatacontext = new AppCenterDataContext();

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
