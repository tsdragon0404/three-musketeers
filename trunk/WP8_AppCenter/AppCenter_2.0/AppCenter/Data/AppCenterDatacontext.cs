using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using AppCenter.Models;
using LS.Utilities;

namespace AppCenter.Data
{
    public class AppCenterDataContext : DataContext
    {
        public AppCenterDataContext()
            : base(GlobalConstants.Data.ConnectionString)
        { }

        public Table<PhoneApp> PhoneApps;

        public void InitializeData()
        {
            var resourceInfo = Application.GetResourceStream(GlobalConstants.Data.InitialDataUri);

            var appDataXml = XElement.Load(resourceInfo.Stream);

            var apps = new List<PhoneApp>();

            foreach (var category in appDataXml.Elements())
                apps.AddRange(category.Elements().Select(app => new PhoneApp(app, category)));

            PhoneApps.InsertAllOnSubmit(apps);
            SubmitChanges();
        }

        public List<PhoneApp> GetAppsByCategoryName(String categoryName)
        {
            return PhoneApps.Where(app => app.Category == categoryName).ToList();
        } 

        public void UpdateApplication(ApplicationInfo appInfo, out String categoryName)
        {
            var app = PhoneApps.FirstOrDefault(a => a.AppID == appInfo.AppID);
            if (app == null)
            {
                categoryName = String.Empty;
                return;
            }

            categoryName = app.Category;

            app.AppVersion = appInfo.Version;
            app.LastUpdated = appInfo.LastUpdated;
            SubmitChanges();
        }

        public void InsertApplication(ApplicationInfo appInfo, String Category)
        {
            PhoneApp A = new PhoneApp();
            A.AppID = appInfo.AppID;
            A.AppName = appInfo.AppName;
            A.AppVersion = appInfo.Version;
            A.AppIcon = appInfo.ImageUrl;
            A.Category = Category;
            A.IsUserDefined = true;
            PhoneApps.InsertOnSubmit(A);
            SubmitChanges();
        }
    }
}
