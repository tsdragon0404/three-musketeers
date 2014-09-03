using System.Configuration;
using SMS.Common.Session;

namespace SMS.Common
{
    public class ConfigReader
    {
        public static string CurrentTheme
        {
            get { return SmsSystem.UserContext.Theme ?? ConfigurationManager.AppSettings["theme"]; }
        }
    }
}