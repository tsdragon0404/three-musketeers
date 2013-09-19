using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using AppCenter.Model;
using LS.Utilities;

namespace AppCenter.Data
{
    public class AppCenterDataContext : DataContext
    {
        public static String ConnectionString = "Data Source=isostore:/AppCenter.sdf";

        public AppCenterDataContext()
            : base(ConnectionString)
        { }

        public Table<PhoneApp> PhoneApps;

        public void InitializeData()
        {
            var resourceInfo = Application.GetResourceStream(new Uri("/AppCenter;component/Data/InitialData.xml", UriKind.Relative));

            var appDataXml = XElement.Load(resourceInfo.Stream);

            var apps = new List<PhoneApp>();

            // ReSharper disable PossibleNullReferenceException
            foreach (var category in appDataXml.Elements())
            {
                apps.AddRange(category.Elements().Select(app => new PhoneApp
                                                                    {
                                                                        AppID = app.Attribute("ID") == null ? Guid.Empty : app.Attribute("ID").Value.ToGuid(),
                                                                        AppIcon = app.Attribute("Icon") == null ? String.Empty : app.Attribute("Icon").Value,
                                                                        AppName = app.Attribute("Name") == null ? String.Empty : app.Attribute("Name").Value,
                                                                        AppVersion = app.Attribute("Version") == null ? String.Empty : app.Attribute("Version").Value,
                                                                        Category = category.Attribute("Name") == null ? String.Empty : category.Attribute("Name").Value,
                                                                        LastUpdate = app.Attribute("LastUpdate") == null ? null : app.Attribute("LastUpdate").Value.ToDateTime(),
                                                                        IsUpdate = app.Attribute("IsUpdate") != null && app.Attribute("IsUpdate").Value.ToBoolean(),
                                                                        IsUserDefined = app.Attribute("IsUserDefine") != null && app.Attribute("IsUserDefine").Value.ToBoolean()
                                                                    }));
            }
            // ReSharper restore PossibleNullReferenceException

            PhoneApps.InsertAllOnSubmit(apps);
            SubmitChanges();
        }
    }
}
