using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace LS.Core
{
    public class BaseView : PhoneApplicationPage
    {
        public BaseView()
        {
            Messenger.Default.Register<Uri>(this, "NavigationRequest", uri => NavigationService.Navigate(uri));
        }
    }
}
