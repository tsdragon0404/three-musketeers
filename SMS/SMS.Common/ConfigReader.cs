using System.Configuration;

namespace SMS.Common
{
    public class ConfigReader
    {
        public static string GetTheme()
        {
            return ConfigurationManager.AppSettings["theme"];
        } 
    }
}