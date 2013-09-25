using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using LS.Utilities;

namespace LS.Core
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected void SendNavigationRequestMessage(Uri uri)
        {
            Messenger.Default.Send(uri, GlobalConstants.Navigation.Request);
        }

        protected void SendNavigationBack(Object param = null)
        {
            Messenger.Default.Send(param, GlobalConstants.Navigation.Back);
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
