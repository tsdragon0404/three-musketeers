﻿using System;
using System.Xml.Linq;

namespace LS.Utilities
{
    public static class GlobalConstants
    {
        public static Boolean ResetDatabase = true;

        public const String QrCodeSeparator = "?appid=";

        public static class ViewUri
        {
            public static Uri Home = new Uri("/Views/HomeView.xaml", UriKind.Relative);
            public static Uri About = new Uri("/Views/AboutView.xaml", UriKind.Relative);
            public static Uri NewApp = new Uri("/Views/NewAppView.xaml", UriKind.Relative);
            public static Uri ScanQRCode = new Uri("/Views/ScanQRCodeView.xaml", UriKind.Relative);
            public static Uri Setting = new Uri("/Views/SettingView.xaml", UriKind.Relative);
        }

        public static class Data
        {
            public static String ConnectionString = "Data Source=isostore:/AppCenter.sdf";
            public static Uri InitialDataUri = new Uri("/AppCenter;component/Data/InitialData.xml", UriKind.Relative);
        }

        public static class ApplicationBarIcon
        {
            public static Uri Add = new Uri("/Images/ApplicationBar/Add.png", UriKind.Relative);
            public static Uri Cancel = new Uri("/Images/ApplicationBar/Cancel.png", UriKind.Relative);
            public static Uri Check = new Uri("/Images/ApplicationBar/Check.png", UriKind.Relative);
            public static Uri Delete = new Uri("/Images/ApplicationBar/Delete.png", UriKind.Relative);
            public static Uri Info = new Uri("/Images/ApplicationBar/Info.png", UriKind.Relative);
            public static Uri Refresh = new Uri("/Images/ApplicationBar/Refresh.png", UriKind.Relative);
            public static Uri Select = new Uri("/Images/ApplicationBar/Select.png", UriKind.Relative);
            public static Uri Setting = new Uri("/Images/ApplicationBar/Setting.png", UriKind.Relative);
        }

        public static class CategoryName
        {
            public const String Nokia = "Nokia";
            public const String Samsung = "Samsung";
            public const String Microsoft = "Microsoft";
            public const String HTC = "HTC";
            public const String Applications = "Applications";
            public const String Games = "Games";
        }

        public static class RequestAppInfo
        {
            private const String AtomNamespace = "http://www.w3.org/2005/Atom";
            private const String ZuneNamespace = "http://schemas.zune.net/catalog/apps/2008/02";

            public const String Url = "http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps/{0}?os={1}&cc=us&lang=en-us&ignored={2}";
            public const String ImgUrl = "http://cdn.marketplaceimages.windowsphone.com/v8/images/{0}";
            public static XName XNameEntry = XName.Get("entry", AtomNamespace);
            public static XName XNameImage = XName.Get("image", ZuneNamespace);
            public static XName XNameAppName = XName.Get("sortTitle", ZuneNamespace);
            public static XName XNameVersion = XName.Get("version", ZuneNamespace);
            public static XName XNameLastUpdated = XName.Get("skuLastUpdated", ZuneNamespace);
            public static XName XNameImageID = XName.Get("id", ZuneNamespace);
        }

        public static class Navigation
        {
            public static Object Param = null;

            public const String Request = "NavigationRequest";
            public const String Back = "NavigationBack";
        }
    }
}