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
        public Table<Setting> Settings;

        public void InitializeData()
        {
            var resourceInfo = Application.GetResourceStream(GlobalConstants.Data.InitialDataUri);

            var appDataXml = XElement.Load(resourceInfo.Stream);

            var apps = new List<PhoneApp>();
            var settings = new List<Setting>();

            foreach (var category in appDataXml.Elements())
            {
                apps.AddRange(category.Elements().Select(app => new PhoneApp(app, category)));
                settings.Add(new Setting(category));
            }

            Settings.InsertAllOnSubmit(settings);
            PhoneApps.InsertAllOnSubmit(apps);
            SubmitChanges();
        }

        public List<PhoneApp> GetAppsByCategoryName(String categoryName)
        {
            return PhoneApps.Where(app => app.Category == categoryName).ToList();
        }

        public List<Setting> GetAllSettings()
        {
            return Settings.ToList();
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
            app.LastCheckVerison = DateTime.Now;
            SubmitChanges();
        }

        public void InsertApplication(ApplicationInfo appInfo, String Category)
        {
            var app = new PhoneApp
                        {
                            AppID = appInfo.AppID,
                            AppName = appInfo.AppName,
                            AppVersion = appInfo.Version,
                            AppIcon = appInfo.ImageUrl,
                            Category = Category,
                            IsUserDefined = true
                        };
            PhoneApps.InsertOnSubmit(app);
            SubmitChanges();
        }

        public void DeleteApplication(Guid appID, out String categoryName)
        {
            var app = PhoneApps.FirstOrDefault(a => a.AppID == appID);
            if (app == null)
            {
                categoryName = String.Empty;
                return;
            }
            categoryName = app.Category;

            PhoneApps.DeleteOnSubmit(app);
            SubmitChanges();
        }

        public void UpdateSetting(int id)
        {
            var setting = Settings.FirstOrDefault(a => a.ID == id);
            if (setting == null)
                return;

            SubmitChanges();
        }
    }
}
