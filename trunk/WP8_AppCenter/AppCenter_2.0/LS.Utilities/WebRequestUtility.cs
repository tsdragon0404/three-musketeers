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
            catch(Exception)
            {
                throw new HttpRequestException();
            }

            var appInfo = new ApplicationInfo(appID, XElement.Parse(responseString));
            if(appInfo.AppID == Guid.Empty)
                throw new Exception();

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
        public String Category { get; set; }

        public ApplicationInfo()
        {
            
        }
        public ApplicationInfo(String appID, XContainer xmlData)
        {
            var entry = xmlData.Element(GlobalConstants.RequestAppInfo.XNameEntry);
            if (entry == null)
                return;
            var image = xmlData.Element(GlobalConstants.RequestAppInfo.XNameImage);
            if (image == null)
                return;
            var categories = xmlData.Element(GlobalConstants.RequestAppInfo.XNameCategories);
            if (categories == null)
                return;
            var category = categories.Element(GlobalConstants.RequestAppInfo.XNameCategory);
            if (category == null)
                return;
            var categorytitle = category.Element(GlobalConstants.RequestAppInfo.XNameCategoryTitle);
            if (categorytitle == null)
                return;
            var appName = xmlData.Element(GlobalConstants.RequestAppInfo.XNameAppName);
            if (appName == null)
                return;
            var imageUrl = image.Element(GlobalConstants.RequestAppInfo.XNameImageID);
            if (imageUrl == null)
                return;
            var version = entry.Element(GlobalConstants.RequestAppInfo.XNameVersion);
            if (version == null)
                return;
            var lastUpdate = entry.Element(GlobalConstants.RequestAppInfo.XNameLastUpdated);

            AppID = appID.ToGuid();
            Version = version.Value;
            LastUpdated = lastUpdate == null ? null : lastUpdate.Value.ToDateTime();
            AppName = appName.Value;
            ImageUrl = String.Format(GlobalConstants.RequestAppInfo.ImgUrl, imageUrl.Value.Replace("urn:uuid:", ""));
            Category = categorytitle.Value;
        }
    }
}
