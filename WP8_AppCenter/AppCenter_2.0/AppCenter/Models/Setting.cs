using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Xml.Linq;
using LS.Core;
using LS.Utilities;

namespace AppCenter.Models
{
    [Table(Name = "Setting")]
    public class Setting : BaseModel
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

        private String _vendorName;

        [Column]
        public String VendorName
        {
            get { return _vendorName; }
            set
            {
                if (_vendorName == value) return;

                RaisePropertyChanging("VendorName");
                _vendorName = value;
                RaisePropertyChanged("VendorName");
            }
        }

        private Boolean _value;

        [Column]
        public Boolean Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;

                RaisePropertyChanging("Value");
                _value = value;
                RaisePropertyChanged("Value");
            }
        }

        #region Constructors

        public Setting()
        {

        }

        public Setting(XElement categoryData)
        {
            VendorName = categoryData.Attribute("Name") == null ? String.Empty : categoryData.Attribute("Name").Value;
            Value = categoryData.Attribute("IsCheck") != null && categoryData.Attribute("IsCheck").Value.ToBoolean();
        }

        #endregion
    }
}
