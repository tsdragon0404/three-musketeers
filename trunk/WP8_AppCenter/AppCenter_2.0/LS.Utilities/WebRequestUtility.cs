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
            string responseString;
            try
            {
                responseString = await client.GetStringAsync(requestUrl);
            }
            catch(Exception ex)
            {
                return;
            }
            var xmlData = XElement.Parse(responseString);
            var entry = xmlData.Element(GlobalConstants.RequestAppInfo.XNameEntry);
            if (entry == null)
                return;
            var image = xmlData.Element(GlobalConstants.RequestAppInfo.XNameImage);
            if (image == null)
                return;
            var appName = xmlData.Element(GlobalConstants.RequestAppInfo.XNameAppName);
            if (appName == null)
                return;
            var imageUrl = image.Element(GlobalConstants.RequestAppInfo.XNameImageUrl);
            if (imageUrl == null)
                return;
            var version = entry.Element(GlobalConstants.RequestAppInfo.XNameVersion);
            if (version == null)
                return;
            var lastUpdate = entry.Element(GlobalConstants.RequestAppInfo.XNameLastUpdated);

            var appInfo = new ApplicationInfo
                          {
                              AppID = appID.ToGuid(),
                              Version = version.Value,
                              LastUpdated = lastUpdate == null ? null : lastUpdate.Value.ToDateTime(),
                              AppName = appName.Value,
                              ImageUrl = "http://cdn.marketplaceimages.windowsphone.com/v8/images/" + imageUrl.Value.Replace("urn:uuid:", "")
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
        public String AppName { get; set; }
        public String ImageUrl { get; set; }
    }
}
