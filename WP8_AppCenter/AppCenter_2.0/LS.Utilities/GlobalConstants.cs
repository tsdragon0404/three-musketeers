using System;

namespace LS.Utilities
{
    public static class GlobalConstants
    {
        public static Boolean ResetDatabase = false;
        
        public static class ViewUri
        {
            public static Uri Home = new Uri("/Views/HomeView.xaml", UriKind.Relative);
            public static Uri About = new Uri("/Views/AboutView.xaml", UriKind.Relative);
            public static Uri NewApp = new Uri("/Views/NewAppView.xaml", UriKind.Relative);
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
        }
    }
}
