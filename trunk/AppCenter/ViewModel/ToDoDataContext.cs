using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using AppCenter.Model;
using System;
using Microsoft.Phone.Net.NetworkInformation;

namespace AppCenter.ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private ToDoDataContext toDoDB;

        // Class constructor, create the data context object.
        public ToDoViewModel(string toDoDBConnectionString)
        {
            toDoDB = new ToDoDataContext(toDoDBConnectionString);
        }

        // To-do items associated with the system item.
        private ObservableCollection<ToDoItem> _nokiaItems;
        public ObservableCollection<ToDoItem> NokiaItems
        {
            get { return _nokiaItems; }
            set
            {
                _nokiaItems = value;
                NotifyPropertyChanged("NokiaItems");
            }
        }

        // To-do items associated with the system item.
        private ObservableCollection<ToDoItem> _samsungItems;
        public ObservableCollection<ToDoItem> SamsungItems
        {
            get { return _samsungItems; }
            set
            {
                _samsungItems = value;
                NotifyPropertyChanged("SamsungItems");
            }
        }

        // To-do items associated with the system item.
        private ObservableCollection<ToDoItem> _htcItems;
        public ObservableCollection<ToDoItem> HTCItems
        {
            get { return _htcItems; }
            set
            {
                _htcItems = value;
                NotifyPropertyChanged("HTCItems");
            }
        }

        // To-do items associated with the system item.
        private ObservableCollection<ToDoItem> _microsoftItems;
        public ObservableCollection<ToDoItem> MicrosoftItems
        {
            get { return _microsoftItems; }
            set
            {
                _microsoftItems = value;
                NotifyPropertyChanged("MicrosoftItems");
            }
        }

        // To-do items associated with the user define apps item.
        private ObservableCollection<ToDoItem> _UserDefneAppItems;
        public ObservableCollection<ToDoItem> UserDefineAppItems
        {
            get { return _UserDefneAppItems; }
            set
            {
                _UserDefneAppItems = value;
                NotifyPropertyChanged("UserDefineAppItems");
            }
        }

        // To-do items associated with the user define games item.
        private ObservableCollection<ToDoItem> _UserDefneGameItems;
        public ObservableCollection<ToDoItem> UserDefineGameItems
        {
            get { return _UserDefneGameItems; }
            set
            {
                _UserDefneGameItems = value;
                NotifyPropertyChanged("UserDefineGameItems");
            }
        }


        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            toDoDB.SubmitChanges();
        }

        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {

            // Specify the query for Nokia items in the database.
            var nokiaItemInDB = from ToDoItem todo in toDoDB.Items
                                where todo.Catagory.Contains("Nokia")
                                select new                                 {
                                    ToDoItemId = todo.ToDoItemId,
                                    ItemImage = todo.ItemImage,
                                    ItemName = todo.ItemName,
                                    ItemNameAPPID = todo.ItemNameAPPID,
                                    Catagory = todo.Catagory,
                                    IsUserDefine = todo.IsUserDefine,
                                    Version = todo.Version == "" && todo.LastUpdate == "" ? "Unknown version" : "Version " + todo.Version + ", Last update " + todo.LastUpdate,
                                    LastUpdate = todo.LastUpdate,
                                    IsUpdate = todo.IsUpdate
                                };
            ObservableCollection<ToDoItem> Nokialist = new ObservableCollection<ToDoItem>();
            foreach (var item in nokiaItemInDB)
            { 
                ToDoItem t = new ToDoItem();
                t.ToDoItemId = item.ToDoItemId;
                t.Catagory = item.Catagory;
                t.IsUserDefine = item.IsUserDefine;
                t.ItemImage = item.ItemImage;
                t.ItemName = item.ItemName;
                t.ItemNameAPPID = item.ItemNameAPPID;
                t.LastUpdate = item.LastUpdate;
                t.Version = item.Version;
                t.IsUpdate = item.IsUpdate;
                Nokialist.Add(t);
            }
            
            // Query the database and load Nokia items.
            NokiaItems = Nokialist;

            // Specify the query for Samsung items in the database.
            var samsungItemInDB = from ToDoItem todo in toDoDB.Items
                                where todo.Catagory.Contains("Samsung")
                                  select new
                                  {
                                      ToDoItemId = todo.ToDoItemId,
                                      ItemImage = todo.ItemImage,
                                      ItemName = todo.ItemName,
                                      ItemNameAPPID = todo.ItemNameAPPID,
                                      Catagory = todo.Catagory,
                                      IsUserDefine = todo.IsUserDefine,
                                      Version = todo.Version == "" && todo.LastUpdate == "" ? "Unknown version" : "Version " + todo.Version + ", Last update " + todo.LastUpdate,
                                      LastUpdate = todo.LastUpdate,
                                      IsUpdate = todo.IsUpdate
                                  };
            ObservableCollection<ToDoItem> Samsunglist = new ObservableCollection<ToDoItem>();
            foreach (var item in samsungItemInDB)
            {
                ToDoItem t = new ToDoItem();
                t.ToDoItemId = item.ToDoItemId;
                t.Catagory = item.Catagory;
                t.IsUserDefine = item.IsUserDefine;
                t.ItemImage = item.ItemImage;
                t.ItemName = item.ItemName;
                t.ItemNameAPPID = item.ItemNameAPPID;
                t.LastUpdate = item.LastUpdate;
                t.Version = item.Version;
                t.IsUpdate = item.IsUpdate;
                Samsunglist.Add(t);
            };

            // Query the database and load Samsung items.
            SamsungItems = Samsunglist;

            // Specify the query for HTC items in the database.
            var htcItemInDB = from ToDoItem todo in toDoDB.Items
                                where todo.Catagory.Contains("HTC")
                              select new
                              {
                                  ToDoItemId = todo.ToDoItemId,
                                  ItemImage = todo.ItemImage,
                                  ItemName = todo.ItemName,
                                  ItemNameAPPID = todo.ItemNameAPPID,
                                  Catagory = todo.Catagory,
                                  IsUserDefine = todo.IsUserDefine,
                                  Version = todo.Version == "" && todo.LastUpdate == "" ? "Unknown version" : "Version " + todo.Version + ", Last update " + todo.LastUpdate,
                                  LastUpdate = todo.LastUpdate,
                                  IsUpdate = todo.IsUpdate
                              };
            ObservableCollection<ToDoItem> HTClist = new ObservableCollection<ToDoItem>();
            foreach (var item in htcItemInDB)
            {
                ToDoItem t = new ToDoItem();
                t.ToDoItemId = item.ToDoItemId;
                t.Catagory = item.Catagory;
                t.IsUserDefine = item.IsUserDefine;
                t.ItemImage = item.ItemImage;
                t.ItemName = item.ItemName;
                t.ItemNameAPPID = item.ItemNameAPPID;
                t.LastUpdate = item.LastUpdate;
                t.Version = item.Version;
                t.IsUpdate = item.IsUpdate;
                HTClist.Add(t);
            };

            // Query the database and load HTC items.
            HTCItems = HTClist;

            // Specify the query for Microsoft items in the database.
            var microsoftItemInDB = from ToDoItem todo in toDoDB.Items
                              where todo.Catagory.Contains("Microsoft")
                                    select new
                                    {
                                        ToDoItemId = todo.ToDoItemId,
                                        ItemImage = todo.ItemImage,
                                        ItemName = todo.ItemName,
                                        ItemNameAPPID = todo.ItemNameAPPID,
                                        Catagory = todo.Catagory,
                                        IsUserDefine = todo.IsUserDefine,
                                        Version = todo.Version == "" && todo.LastUpdate == "" ? "Unknown version" : "Version " + todo.Version + ", Last update " + todo.LastUpdate,
                                        LastUpdate = todo.LastUpdate,
                                        IsUpdate = todo.IsUpdate
                                    };
            ObservableCollection<ToDoItem> Microsoftlist = new ObservableCollection<ToDoItem>();
            foreach (var item in microsoftItemInDB)
            {
                ToDoItem t = new ToDoItem();
                t.ToDoItemId = item.ToDoItemId;
                t.Catagory = item.Catagory;
                t.IsUserDefine = item.IsUserDefine;
                t.ItemImage = item.ItemImage;
                t.ItemName = item.ItemName;
                t.ItemNameAPPID = item.ItemNameAPPID;
                t.LastUpdate = item.LastUpdate;
                t.Version = item.Version;
                t.IsUpdate = item.IsUpdate;
                Microsoftlist.Add(t);
            };

            // Query the database and load Microsoft items.
            MicrosoftItems = Microsoftlist;


            bool isNetwork = NetworkInterface.GetIsNetworkAvailable();

            // Specify the query for user define app items in the database.
            var userdefineAppItemInDB = from ToDoItem todo in toDoDB.Items
                                     where todo.Catagory.Contains("Application")
                                        select new
                                        {
                                            ToDoItemId = todo.ToDoItemId,
                                            ItemImage = isNetwork == true ? todo.ItemImage : "/Images/acr.png",
                                            ItemName = todo.ItemName,
                                            ItemNameAPPID = todo.ItemNameAPPID,
                                            Catagory = todo.Catagory,
                                            IsUserDefine = todo.IsUserDefine,
                                            Version = todo.Version == "" && todo.LastUpdate == "" ? "Unknown version" : "Version " + todo.Version + ", Last update " + todo.LastUpdate,
                                            LastUpdate = todo.LastUpdate,
                                            IsUpdate = todo.IsUpdate
                                        };
            ObservableCollection<ToDoItem> Applist = new ObservableCollection<ToDoItem>();
            foreach (var item in userdefineAppItemInDB)
            {
                ToDoItem t = new ToDoItem();
                t.ToDoItemId = item.ToDoItemId;
                t.Catagory = item.Catagory;
                t.IsUserDefine = item.IsUserDefine;
                t.ItemImage = item.ItemImage;
                t.ItemName = item.ItemName;
                t.ItemNameAPPID = item.ItemNameAPPID;
                t.LastUpdate = item.LastUpdate;
                t.Version = item.Version;
                t.IsUpdate = item.IsUpdate;
                Applist.Add(t);
            };

            // Query the database and load user define app items.
            UserDefineAppItems = Applist;

            // Specify the query for user define app items in the database.
            var userdefineGameItemInDB = from ToDoItem todo in toDoDB.Items
                                         where todo.IsUserDefine.Contains("Visible") && todo.Catagory.Contains("Game")
                                         select new
                                         {
                                             ToDoItemId = todo.ToDoItemId,
                                             ItemImage = isNetwork == true ? todo.ItemImage : "/Images/gmaes.png",
                                             ItemName = todo.ItemName,
                                             ItemNameAPPID = todo.ItemNameAPPID,
                                             Catagory = todo.Catagory,
                                             IsUserDefine = todo.IsUserDefine,
                                             Version = todo.Version == "" && todo.LastUpdate == "" ? "Unknown version" : "Version " + todo.Version + ", Last update " + todo.LastUpdate,
                                             LastUpdate = todo.LastUpdate,
                                             IsUpdate = todo.IsUpdate
                                         };
            ObservableCollection<ToDoItem> Gamelist = new ObservableCollection<ToDoItem>();
            foreach (var item in userdefineGameItemInDB)
            {
                ToDoItem t = new ToDoItem();
                t.ToDoItemId = item.ToDoItemId;
                t.Catagory = item.Catagory;
                t.IsUserDefine = item.IsUserDefine;
                t.ItemImage = item.ItemImage;
                t.ItemName = item.ItemName;
                t.ItemNameAPPID = item.ItemNameAPPID;
                t.LastUpdate = item.LastUpdate;
                t.Version = item.Version;
                t.IsUpdate = item.IsUpdate;
                Gamelist.Add(t);
            };

            // Query the database and load user define app items.
            UserDefineGameItems = Gamelist;
        }

        // Add a to-do item to the database and collections.
        public void AddToDoItem(ToDoItem newToDoItem)
        {
            // Add a to-do item to the data context.
            toDoDB.Items.InsertOnSubmit(newToDoItem);

            // Save changes to the database.
            toDoDB.SubmitChanges();

            ToDoItem item = new ToDoItem();
            item.Catagory = newToDoItem.Catagory;
            item.IsUpdate = newToDoItem.IsUpdate;
            item.IsUserDefine = newToDoItem.IsUserDefine;
            item.ItemImage = newToDoItem.ItemImage;
            item.ItemName = newToDoItem.ItemName;
            item.ItemNameAPPID = newToDoItem.ItemNameAPPID;
            item.LastUpdate = newToDoItem.LastUpdate;
            item.Version = "Version " + newToDoItem.Version + ", Last update " + newToDoItem.LastUpdate;

            switch (item.Catagory)
            { 
                case "Application":
                    UserDefineAppItems.Add(item);
                    break;
                case "Game":
                    UserDefineGameItems.Add(item);
                    break;
            }
        }

        // Update a to-do item to the database and collections.
        public void UpdateToDoItem(ToDoItem newToDoItem)
        {
            string AppID = newToDoItem.ItemNameAPPID;

            var item = from ToDoItem todo in toDoDB.Items
                            where todo.ItemNameAPPID.Contains(AppID)
                            select todo;

            string Catagory = "";
            string IsUpdate = "";

            foreach (ToDoItem i in item)
            {
                IsUpdate = i.IsUpdate;
                i.Version = newToDoItem.Version;

                if (i.LastUpdate != "" && (DateTime.Parse(newToDoItem.LastUpdate) > DateTime.Parse(i.LastUpdate)))
                    IsUpdate = "Lime";
                else if (i.LastUpdate != "" && i.LastUpdate == newToDoItem.LastUpdate && ((TimeSpan)(DateTime.Now - DateTime.Parse(newToDoItem.LastUpdate))).TotalDays > 2)
                    IsUpdate = "White";

                i.IsUpdate = IsUpdate;
                i.LastUpdate = newToDoItem.LastUpdate;

                Catagory = i.Catagory;
            }
            toDoDB.SubmitChanges();

            switch (Catagory)
            {
                case "Nokia":
                    foreach (ToDoItem iNokia in NokiaItems)
                    {
                        if (iNokia.ItemNameAPPID == newToDoItem.ItemNameAPPID)
                        {
                            iNokia.Version = "Version " + newToDoItem.Version + ", Last update " + newToDoItem.LastUpdate;
                            iNokia.LastUpdate = newToDoItem.LastUpdate;
                            iNokia.IsUpdate = IsUpdate;
                            break;
                        }
                    }
                    break;
                case "SamSung":
                    foreach (ToDoItem iSamsung in SamsungItems)
                    {
                        if (iSamsung.ItemNameAPPID == newToDoItem.ItemNameAPPID)
                        {
                            iSamsung.Version = "Version " + newToDoItem.Version + ", Last update " + newToDoItem.LastUpdate;
                            iSamsung.LastUpdate = newToDoItem.LastUpdate;
                            iSamsung.IsUpdate = IsUpdate;
                            break;
                        }
                    }
                    break;
                case "HTC":
                    foreach (ToDoItem iHTC in HTCItems)
                    {
                        if (iHTC.ItemNameAPPID == newToDoItem.ItemNameAPPID)
                        {
                            iHTC.Version = "Version " + newToDoItem.Version + ", Last update " + newToDoItem.LastUpdate;
                            iHTC.LastUpdate = newToDoItem.LastUpdate;
                            iHTC.IsUpdate = IsUpdate;
                            break;
                        }
                    }
                    break;
                case "Microsoft":
                    foreach (ToDoItem iMicrosoft in MicrosoftItems)
                    {
                        if (iMicrosoft.ItemNameAPPID == newToDoItem.ItemNameAPPID)
                        {
                            iMicrosoft.Version = "Version " + newToDoItem.Version + ", Last update " + newToDoItem.LastUpdate;
                            iMicrosoft.LastUpdate = newToDoItem.LastUpdate;
                            iMicrosoft.IsUpdate = IsUpdate;
                            break;
                        }
                    }
                    break;
                case "Application":
                    foreach (ToDoItem iApp in UserDefineAppItems)
                    {
                        if (iApp.ItemNameAPPID == newToDoItem.ItemNameAPPID)
                        {
                            iApp.Version = "Version " + newToDoItem.Version + ", Last update " + newToDoItem.LastUpdate;
                            iApp.LastUpdate = newToDoItem.LastUpdate;
                            iApp.IsUpdate = IsUpdate;
                            break;
                        }
                    }
                    break;
                case "Game":
                    foreach (ToDoItem iGame in UserDefineGameItems)
                    {
                        if (iGame.ItemNameAPPID == newToDoItem.ItemNameAPPID)
                        {
                            iGame.Version = "Version " + newToDoItem.Version + ", Last update " + newToDoItem.LastUpdate;
                            iGame.LastUpdate = newToDoItem.LastUpdate;
                            iGame.IsUpdate = IsUpdate;
                            break;
                        }
                    }
                    break;
            }
        }

        // Remove a to-do task item from the database and collections.
        public void DeleteToDoItem(ToDoItem toDoForDelete)
        {
            var item = from ToDoItem todo in toDoDB.Items
                       where todo.ToDoItemId.ToString().Contains(toDoForDelete.ToDoItemId.ToString())
                       select todo;

            foreach (ToDoItem i in item)
            {
                toDoDB.Items.DeleteOnSubmit(i);
            }
            // Save changes to the database.
            toDoDB.SubmitChanges();

            // Remove the to-do item from the data context.
            switch (toDoForDelete.Catagory)
            { 
                case "Game":
                    UserDefineGameItems.Remove(toDoForDelete);
                    break;
                case "Application":
                    UserDefineAppItems.Remove(toDoForDelete);
                    break;
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
