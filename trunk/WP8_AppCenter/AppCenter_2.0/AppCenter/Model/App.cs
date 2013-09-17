using System.Data.Linq.Mapping;
using LS.Core;

namespace AppCenter.Model
{
    [Table(Name = "Application")]
    public class App : BaseModel
    {
        private string _appID;

        [Column]
        public string AppID
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

        private string _appName;

        [Column]
        public string AppName
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

        private string _appIcon;

        [Column]
        public string AppIcon
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

        private string _appVersion;

        [Column]
        public string AppVersion
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

        private string _category;

        [Column]
        public string Category
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

        #region not use yet
        //private string _lastUpdate;

        //[Column]
        //public string LastUpdate
        //{
        //    get { return _lastUpdate; }
        //    set
        //    {
        //        if (_lastUpdate == value) return;

        //        NotifyPropertyChanging("LastUpdate");
        //        _lastUpdate = value;
        //        NotifyPropertyChanged("LastUpdate");
        //    }
        //}

        //private string _isUpdate;

        //[Column]
        //public string IsUpdate
        //{
        //    get { return _isUpdate; }
        //    set
        //    {
        //        if (_isUpdate == value) return;

        //        NotifyPropertyChanging("IsUpdate");
        //        _isUpdate = value;
        //        NotifyPropertyChanged("IsUpdate");
        //    }
        //}

        //private string _isUserDefine;

        //[Column]
        //public string IsUserDefine
        //{
        //    get { return _isUserDefine; }
        //    set
        //    {
        //        if (_isUserDefine == value) return;

        //        NotifyPropertyChanging("IsUserDefine");
        //        _isUserDefine = value;
        //        NotifyPropertyChanged("IsUserDefine");
        //    }
        //} 
        #endregion
    }
}
