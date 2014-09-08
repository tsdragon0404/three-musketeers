using System.Configuration;

namespace SMS.Common
{
    public class ConfigReader
    {
        public static string CurrentTheme
        {
            get { return ConfigurationManager.AppSettings["theme"]; }
        }
    }
}