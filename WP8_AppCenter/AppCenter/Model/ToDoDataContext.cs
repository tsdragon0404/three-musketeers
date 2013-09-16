using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AppCenter.Model
{
    public class ToDoDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public ToDoDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<ToDoItem> Items;
    }

    [Table]
    public class ToDoItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _toDoItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ToDoItemId
        {
            get { return _toDoItemId; }
            set
            {
                if (_toDoItemId != value)
                {
                    NotifyPropertyChanging("ToDoItemId");
                    _toDoItemId = value;
                    NotifyPropertyChanged("ToDoItemId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _itemImage;

        [Column]
        public string ItemImage
        {
            get { return _itemImage; }
            set
            {
                if (_itemImage != value)
                {
                    NotifyPropertyChanging("ItemImage");
                    _itemImage = value;
                    NotifyPropertyChanged("ItemImage");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _itemName;

        [Column]
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    NotifyPropertyChanging("ItemName");
                    _itemName = value;
                    NotifyPropertyChanged("ItemName");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _itemNameAPPID;

        [Column]
        public string ItemNameAPPID
        {
            get { return _itemNameAPPID; }
            set
            {
                if (_itemNameAPPID != value)
                {
                    NotifyPropertyChanging("ItemNameAPPID");
                    _itemNameAPPID = value;
                    NotifyPropertyChanged("ItemNameAPPID");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _Catagory;

        [Column]
        public string Catagory
        {
            get { return _Catagory; }
            set
            {
                if (_Catagory != value)
                {
                    NotifyPropertyChanging("Catagory");
                    _Catagory = value;
                    NotifyPropertyChanged("Catagory");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _isUserDefine;

        [Column]
        public string IsUserDefine
        {
            get { return _isUserDefine; }
            set
            {
                if (_isUserDefine != value)
                {
                    NotifyPropertyChanging("IsUserDefine");
                    _isUserDefine = value;
                    NotifyPropertyChanged("IsUserDefine");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _version;

        [Column]
        public string Version
        {
            get { return _version; }
            set
            {
                if (_version != value)
                {
                    NotifyPropertyChanging("Version");
                    _version = value;
                    NotifyPropertyChanged("Version");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _lastUpdate;

        [Column]
        public string LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                if (_lastUpdate != value)
                {
                    NotifyPropertyChanging("LastUpdate");
                    _lastUpdate = value;
                    NotifyPropertyChanged("LastUpdate");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _isUpdate;

        [Column]
        public string IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                if (_isUpdate != value)
                {
                    NotifyPropertyChanging("IsUpdate");
                    _isUpdate = value;
                    NotifyPropertyChanged("IsUpdate");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}
