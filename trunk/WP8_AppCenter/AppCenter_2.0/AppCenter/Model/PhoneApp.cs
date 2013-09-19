using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using LS.Core;

namespace AppCenter.Model
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

                NotifyPropertyChanging("ID");
                _id = value;
                NotifyPropertyChanged("ID");
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

                NotifyPropertyChanging("AppID");
                _appID = value;
                NotifyPropertyChanged("AppID");
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

                NotifyPropertyChanging("AppName");
                _appName = value;
                NotifyPropertyChanged("AppName");
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

                NotifyPropertyChanging("AppIcon");
                _appIcon = value;
                NotifyPropertyChanged("AppIcon");
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

                NotifyPropertyChanging("AppVersion");
                _appVersion = value;
                NotifyPropertyChanged("AppVersion");
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

                NotifyPropertyChanging("Category");
                _category = value;
                NotifyPropertyChanged("Category");
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

                NotifyPropertyChanging("LastUpdate");
                _lastUpdate = value;
                NotifyPropertyChanged("LastUpdate");
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

                NotifyPropertyChanging("IsUpdate");
                _isUpdate = value;
                NotifyPropertyChanged("IsUpdate");
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

                NotifyPropertyChanging("IsUserDefined");
                _isUserDefined = value;
                NotifyPropertyChanged("IsUserDefined");
            }
        } 
    }
}
