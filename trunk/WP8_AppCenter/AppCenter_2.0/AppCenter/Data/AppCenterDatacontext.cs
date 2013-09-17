using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace AppCenter.Data
{
    public class AppCenterDataContext : DataContext
    {
        public static String ConnectionString = "Data Source=isostore:/AppCenter.sdf";

        public AppCenterDataContext()
            : base(ConnectionString)
        { }

        public Table<Model.App> Apps;

        public void InitializeData()
        {
            var resourceInfo = Application.GetResourceStream(new Uri("/AppCenter;component/Data/InitialData.xml", UriKind.Relative));

            var appDataXml = XElement.Load(resourceInfo.Stream);

            var apps = new List<Model.App>();

            foreach (var category in appDataXml.Elements())
            {
                apps.AddRange(category.Elements().Select(app => new Model.App
                                                                    {
                                                                        AppID = app.Attribute("ID") == null ? String.Empty : app.Attribute("ID").Value,
                                                                        AppIcon = app.Attribute("Icon") == null ? String.Empty : app.Attribute("Icon").Value,
                                                                        AppName = app.Attribute("Name") == null ? String.Empty : app.Attribute("Name").Value,
                                                                        AppVersion = app.Attribute("Version") == null ? String.Empty : app.Attribute("Version").Value,
                                                                        Category = category.Attribute("Name") == null ? String.Empty : category.Attribute("Name").Value
                                                                    }));
            }

            Apps.InsertAllOnSubmit(apps);
            SubmitChanges();
        }
    }
}
