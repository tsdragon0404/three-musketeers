using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using LS.Core;

namespace AppCenter.Models
{
    public class ManagedApp : BaseModel
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

        [Column]
        internal Guid _phoneAppId;

        private EntityRef<PhoneApp> _application;

        [Association(Storage = "_application", ThisKey = "_phoneAppId", OtherKey = "ID", IsForeignKey = true)]
        public PhoneApp Application
        {
            get { return _application.Entity; }
            set
            {
                RaisePropertyChanging("Application");
                _application.Entity = value;

                if (value != null)
                {
                    _phoneAppId = value.AppID;
                }

                RaisePropertyChanged("Application");
            }
        }
    }
}
