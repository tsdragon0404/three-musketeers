using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;
using System.Xml.XPath;
using SMS.Common.Constant;

namespace SMS.Common
{
    public class ConfigReader
    {
        public static string CurrentTheme
        {
            get { return GetValue(ConstConfig.ConfigKey_DefaultTheme); }
        }

        public static string ConnectionString
        {
            get { return GetValue(ConstConfig.ConfigKey_ConnectionString); }
        }

        #region Read data from XML methods

        private static string GetValue(string elementName)
        {
            var element = FindElement(elementName);
            if (element == null)
                throw new Exception(string.Format("Bad config file. Missing element [{0}].", elementName));

            var valueAtt = element.Attribute(XName.Get(ConstConfig.Config_ValueAttributeName));
            if (valueAtt == null)
                throw new Exception(string.Format("Bad config file. Element [{0}] doesn't have attribute [{1}].", elementName, ConstConfig.Config_ValueAttributeName));

            return valueAtt.Value;
        }

        private static XElement FindElement(string elementName)
        {
            return FindElements(elementName).FirstOrDefault();
        }

        private static IEnumerable<XElement> FindElements(string elementName)
        {
            var path = HostingEnvironment.MapPath(ConstConfig.Config_SmsConfigPath);
            if (path == null)
                throw new Exception("Unable to get data from web server.");

            var file = Path.Combine(path, ConstConfig.Config_SmsConfigFileName);
            var xpath = string.Format(ConstConfig.Config_XPathToGetElement, elementName);
            return XDocument.Load(file).XPathSelectElements(xpath);
        } 

        #endregion
    }
}