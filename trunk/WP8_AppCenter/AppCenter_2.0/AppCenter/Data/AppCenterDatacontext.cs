﻿using System;
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

        public void UpdateAppVersion()
        {
            var resourceInfo = Application.GetResourceStream(GlobalConstants.Data.InitialDataUri);

            var appDataXml = XElement.Load(resourceInfo.Stream);

            var apps = new List<PhoneApp>();

            foreach (var category in appDataXml.Elements())
            {
                apps.AddRange(category.Elements().Select(app => new PhoneApp(app, category)));
            }

            foreach (PhoneApp pa in PhoneApps)
            {
                var App = apps.FirstOrDefault(a => a.AppID == pa.AppID && ((a.Category != GlobalConstants.CategoryName.Applications && a.Category != GlobalConstants.CategoryName.Games) ||
                                                                           (a.Category == GlobalConstants.CategoryName.Applications && a.IsUserDefined == false)));
                if (App == null)
                {
                    if(pa.AppID != Guid.Parse("8768a942-8f14-471b-85d7-9e67b16c11b4"))
                        apps.Add(pa);
                }
                else
                {
                    App.AppVersion = pa.AppVersion;
                    App.LastCheckVersion = pa.LastCheckVersion;
                    App.LastUpdated = pa.LastUpdated;
                    App.IsUpdate = pa.IsUpdate;
                }
            }
            PhoneApps.DeleteAllOnSubmit(PhoneApps);
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

            if (app.AppVersion != null && app.LastUpdated != null && (app.AppVersion != appInfo.Version || app.LastUpdated < appInfo.LastUpdated))
                app.IsUpdate = true;
            else
                app.IsUpdate = false;

            app.AppVersion = appInfo.Version;
            app.LastUpdated = appInfo.LastUpdated;
            app.LastCheckVersion = DateTime.Now;
            SubmitChanges();
        }

        public void InsertApplication(PhoneApp app)
        {
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
