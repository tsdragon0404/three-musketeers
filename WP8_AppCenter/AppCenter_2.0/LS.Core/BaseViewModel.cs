using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;

namespace LS.Core
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected void SendNavigationRequestMessage(Uri uri)
        {
            Messenger.Default.Send(uri, "NavigationRequest");
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
