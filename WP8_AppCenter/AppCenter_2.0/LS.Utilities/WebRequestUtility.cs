using System;
using System.Globalization;
using System.Net.Http;
using System.Xml.Linq;

namespace LS.Utilities
{
    public static class RequestApplicationInfo
    {
        #region Public methods

        public static async void GetApplicationInfoAsync(String appID, Action<ApplicationInfo> callBack)
        {
            var os = Environment.OSVersion.Version.ToString();
            var requestUrl = String.Format(GlobalConstants.RequestAppInfo.Url, appID, os, DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture));
            
            var client = new HttpClient();
            var responseString = await client.GetStringAsync(requestUrl);

            var xmlData = XElement.Parse(responseString);
            var entry = xmlData.Element(GlobalConstants.RequestAppInfo.XNameEntry);
            if (entry == null)
                return;
            var version = entry.Element(GlobalConstants.RequestAppInfo.XNameVersion);
            if (version == null)
                return;
            var lastUpdate = entry.Element(GlobalConstants.RequestAppInfo.XNameLastUpdated);

            var appInfo = new ApplicationInfo
                          {
                              AppID = appID.ToGuid(),
                              Version = version.Value,
                              LastUpdated = lastUpdate == null ? null : lastUpdate.Value.ToDateTime()
                          };
            callBack(appInfo);
        }

        #endregion
    }

    public class ApplicationInfo
    {
        public Guid AppID { get; set; }
        public String Version { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
