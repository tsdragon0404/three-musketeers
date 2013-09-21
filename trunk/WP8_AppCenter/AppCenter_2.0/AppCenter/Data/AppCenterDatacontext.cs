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
    }
}
