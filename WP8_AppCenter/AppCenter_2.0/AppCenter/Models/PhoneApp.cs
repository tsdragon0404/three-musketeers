using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Xml.Linq;
using LS.Core;
using LS.Utilities;

namespace AppCenter.Models
{
    [Table(Name = "Application")]
    public class PhoneApp : BaseModel
    {
        #region Mandatory fields
        private Int32 _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public Int32 ID
        {
            get { return _id; }
            set
            {
                if (_id == value) return;

                RaisePropertyChanging("ID");
                _id = value;
                RaisePropertyChanged("ID");
            }
        }

        [Column(IsVersion = true)]
        private Binary _version; 
        #endregion

        private Guid _appID;

        [Column]
        public Guid AppID
        {
            get { return _appID; }
            set
            {
                if (_appID == value) return;

                RaisePropertyChanging("AppID");
                _appID = value;
                RaisePropertyChanged("AppID");
            }
        }

        private String _appName;

        [Column]
        public String AppName
        {
            get { return _appName; }
            set
            {
                if (_appName == value) return;

                RaisePropertyChanging("AppName");
                _appName = value;
                RaisePropertyChanged("AppName");
            }
        }

        private String _appIcon;

        [Column]
        public String AppIcon
        {
            get { return _appIcon; }
            set
            {
                if (_appIcon == value) return;

                RaisePropertyChanging("AppIcon");
                _appIcon = value;
                RaisePropertyChanged("AppIcon");
            }
        }

        private String _appVersion;

        [Column]
        public String AppVersion
        {
            get { return _appVersion; }
            set
            {
                if (_appVersion == value) return;

                RaisePropertyChanging("AppVersion");
                _appVersion = value;
                RaisePropertyChanged("AppVersion");
            }
        }

        private String _category;

        [Column]
        public String Category
        {
            get { return _category; }
            set
            {
                if (_category == value) return;

                RaisePropertyChanging("Category");
                _category = value;
                RaisePropertyChanged("Category");
            }
        }

        private DateTime? _lastUpdate;

        [Column]
        public DateTime? LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                if (_lastUpdate == value) return;

                RaisePropertyChanging("LastUpdate");
                _lastUpdate = value;
                RaisePropertyChanged("LastUpdate");
            }
        }

        private Boolean _isUpdate;

        [Column]
        public Boolean IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                if (_isUpdate == value) return;

                RaisePropertyChanging("IsUpdate");
                _isUpdate = value;
                RaisePropertyChanged("IsUpdate");
            }
        }

        private Boolean _isUserDefined;

        [Column]
        public Boolean IsUserDefined
        {
            get { return _isUserDefined; }
            set
            {
                if (_isUserDefined == value) return;

                RaisePropertyChanging("IsUserDefined");
                _isUserDefined = value;
                RaisePropertyChanged("IsUserDefined");
            }
        }

        #region Constructors

        public PhoneApp()
        {

        }

        public PhoneApp(XElement appData, XElement categoryData)
        {
            Category = categoryData.Attribute("Name") == null ? String.Empty : categoryData.Attribute("Name").Value;

            AppID = appData.Attribute("ID") == null ? Guid.Empty : appData.Attribute("ID").Value.ToGuid();
            AppIcon = appData.Attribute("Icon") == null ? String.Empty : appData.Attribute("Icon").Value;
            AppName = appData.Attribute("Name") == null ? String.Empty : appData.Attribute("Name").Value;
            AppVersion = appData.Attribute("Version") == null ? String.Empty : appData.Attribute("Version").Value;
            LastUpdate = appData.Attribute("LastUpdate") == null ? null : appData.Attribute("LastUpdate").Value.ToDateTime();
            IsUpdate = appData.Attribute("IsUpdate") != null && appData.Attribute("IsUpdate").Value.ToBoolean();
            IsUserDefined = appData.Attribute("IsUserDefine") != null && appData.Attribute("IsUserDefine").Value.ToBoolean();
        } 

        public static PhoneApp NewUserDefinedApp()
        {
            return new PhoneApp
                       {
                           IsUserDefined = true,
                           LastUpdate = DateTime.Now,
                       };
        }

        #endregion
    }
}
