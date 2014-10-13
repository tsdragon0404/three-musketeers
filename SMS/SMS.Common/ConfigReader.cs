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
    public static class ConfigReader
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

    //public static class ConfigLoader
    //{
    //    public static bool islocal;
    //    private static string env;
    //    private static dynamic configData;

    //    private static void loadConfig()
    //    {
    //        if (configData == null)
    //        {
    //            configData = new CaseInsensitiveExpando();
    //            XDocument xDoc = XDocument.Load(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TestConfig.xml");

    //            foreach (var variablesElement in xDoc.Root.Elements())
    //            {
    //                var groupName = variablesElement.Attribute("name").Value;

    //                configData[groupName] = new CaseInsensitiveExpando();

    //                foreach (var variableElement in variablesElement.Descendants())
    //                    configData[groupName][variableElement.Attribute("name").Value] = variableElement.Attribute("value").Value;
    //            }

    //            string[] hostArray = ((string)configData.TestRunCI.host).Split();
    //            foreach (string host in hostArray)
    //                if (System.Net.Dns.GetHostName().ToUpper().Contains(host.ToUpper()))                        
    //                {
    //                    env = configData.TestRunCI.envvargroup;
    //                    Settings.ScreenshotLocation = configData.TestRunCI.screenshotlocation;
    //                    Settings.ScreenshotOnTestFail = Convert.ToBoolean(configData.TestRunCI.screenshotontestfail);
    //                    Settings.TestDebug = Convert.ToBoolean(configData.TestRunCI.debugmode);
    //                    islocal = false;
    //                }
    //            if (env == null)
    //            {
    //                env = configData.TestRunLOCAL.envvargroup;
    //                Settings.ScreenshotLocation = configData.TestRunLOCAL.screenshotlocation;
    //                Settings.ScreenshotOnTestFail = Convert.ToBoolean(configData.TestRunLOCAL.screenshotontestfail);
    //                Settings.TestDebug = Convert.ToBoolean(configData.TestRunLOCAL.debugmode);
    //                islocal = true;
    //            }
    //            //else throw new Exception("No Config found");
    //        }
    //    }

    //    public static dynamic TestRunConfig
    //    {
    //        get
    //        {
    //            if (configData == null)
    //                loadConfig();
    //            if (islocal)
    //                return configData.TestRunLOCAL;
    //            else return configData.TestRunCI;
    //        }
    //    }

    //    public static dynamic TestEnvConfig
    //    {
    //        get
    //        {
    //            if (configData == null)
    //                loadConfig();
    //            switch (env.ToLower())
    //            {
    //                case "local":
    //                    return configData.LOCAL;
    //                case "pacman":
    //                    return configData.PACMAN;
    //                case "mario":
    //                    return configData.MARIO;
    //                case "yoshi":
    //                    return configData.YOSHI;
    //                case "zelda":
    //                    return configData.ZELDA;                    
    //                case "sonic":
    //                    return configData.SONIC;
    //                case "duke":
    //                    return configData.DUKE;
    //                case "lara":
    //                    return configData.LARA;
    //                case "diablo":
    //                    return configData.DIABLO;
    //                case "mina":
    //                    return configData.MINA;
    //                case "golive_anon":
    //                    return configData.GOLIVE_ANON;
    //                case "golive_prod":
    //                    return configData.GOLIVE_PROD;
    //                case "golive_local":
    //                    return configData.GOLIVE_LOCAL;
    //                case "golive_global_launchpad":
    //                    return configData.GOLIVE_GLOBAL_LAUNCHPAD; 
    //                default:
    //                    return env;
    //            }              
    //        }
    //    }

    //    private class CaseInsensitiveExpando : DynamicObject, IDictionary<string, object>
    //    {
    //        private IDictionary<string, object> Dictionary = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

    //        public void Add(KeyValuePair<string, object> item)
    //        {
    //            Dictionary.Add(item);
    //        }
    //        public void Clear()
    //        {
    //            Dictionary.Clear();
    //        }
    //        public bool Contains(KeyValuePair<string, object> item)
    //        {
    //            return Dictionary.Contains(item);
    //        }
    //        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    //        {
    //            Dictionary.CopyTo(array, arrayIndex);
    //        }
    //        public bool Remove(KeyValuePair<string, object> item)
    //        {
    //            return Dictionary.Remove(item);
    //        }
    //        public int Count { get { return this.Dictionary.Keys.Count; } }
    //        public bool IsReadOnly { get { return Dictionary.IsReadOnly; } }
    //        public override bool TryGetMember(GetMemberBinder binder, out object result)
    //        {
    //            if (this.Dictionary.ContainsKey(binder.Name))
    //            {
    //                result = this.Dictionary[binder.Name];
    //                return true;
    //            }
    //            return base.TryGetMember(binder, out result);
    //        }
    //        public override bool TrySetMember(SetMemberBinder binder, object value)
    //        {
    //            if (!this.Dictionary.ContainsKey(binder.Name))
    //                this.Dictionary.Add(binder.Name, value);
    //            else
    //                this.Dictionary[binder.Name] = value;
    //            return true;
    //        }
    //        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    //        {
    //            if (this.Dictionary.ContainsKey(binder.Name) && this.Dictionary[binder.Name] is Delegate)
    //            {
    //                Delegate del = this.Dictionary[binder.Name] as Delegate;
    //                result = del.DynamicInvoke(args);
    //                return true;
    //            }
    //            return base.TryInvokeMember(binder, args, out result);
    //        }
    //        public override bool TryDeleteMember(DeleteMemberBinder binder)
    //        {
    //            if (this.Dictionary.ContainsKey(binder.Name))
    //            {
    //                this.Dictionary.Remove(binder.Name);
    //                return true;
    //            }
    //            return base.TryDeleteMember(binder);
    //        }
    //        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    //        {
    //            return Dictionary.GetEnumerator();
    //        }
    //        IEnumerator IEnumerable.GetEnumerator()
    //        {
    //            return GetEnumerator();
    //        }
    //        public bool ContainsKey(string key)
    //        {
    //            return Dictionary.ContainsKey(key);
    //        }
    //        public void Add(string key, object value)
    //        {
    //            Dictionary.Add(key, value);
    //        }
    //        public bool Remove(string key)
    //        {
    //            return Dictionary.Remove(key);
    //        }
    //        public bool TryGetValue(string key, out object value)
    //        {
    //            return Dictionary.TryGetValue(key, out value);
    //        }
    //        public object this[string key]
    //        {
    //            get { return Dictionary[key]; }
    //            set { Dictionary[key] = value; }
    //        }
    //        public ICollection<string> Keys
    //        {
    //            get { return Dictionary.Keys; }
    //        }
    //        public ICollection<object> Values
    //        {
    //            get { return Dictionary.Values; }
    //        }
    //    }
    //}
}