using System;
using GalaSoft.MvvmLight.Messaging;
using LS.Utilities;
using Microsoft.Phone.Controls;

namespace LS.Core
{
    public class BaseView : PhoneApplicationPage
    {
        public BaseView()
        {
            Messenger.Default.Register<Uri>(this, GlobalConstants.Navigation.Request, uri => NavigationService.Navigate(uri));
            Messenger.Default.Register<Object>(this, GlobalConstants.Navigation.Back, param =>
                                                                     {
                                                                         if (!NavigationService.CanGoBack) return;

                                                                         GlobalConstants.Navigation.Param = param;
                                                                         NavigationService.GoBack();
                                                                     });
        }
    }
}
