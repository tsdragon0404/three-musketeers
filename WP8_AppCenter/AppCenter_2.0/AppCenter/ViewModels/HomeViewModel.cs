using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AppCenter.Data;
using AppCenter.Models;
using LS.Core;
using LS.Utilities;
using Microsoft.Phone.Tasks;

namespace AppCenter.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Private variables
        
        private readonly AppCenterDataContext _db; 

        #endregion

        #region Constructor(s)
        
        public HomeViewModel()
        {
            _db = new AppCenterDataContext();
        } 

        #endregion

        #region Public properties

        private ObservableCollection<PhoneApp> _nokiaAppList;
        public ObservableCollection<PhoneApp> NokiaAppList
        {
            get { return _nokiaAppList; }
            set
            {
                _nokiaAppList = value;
                RaisePropertyChanged("NokiaAppList");
            }
        }

        private ObservableCollection<PhoneApp> _samsungAppList;
        public ObservableCollection<PhoneApp> SamsungAppList
        {
            get { return _samsungAppList; }
            set
            {
                _samsungAppList = value;
                RaisePropertyChanged("SamsungAppList");
            }
        }

        private ObservableCollection<PhoneApp> _htcAppList;
        public ObservableCollection<PhoneApp> HTCAppList
        {
            get { return _htcAppList; }
            set
            {
                _htcAppList = value;
                RaisePropertyChanged("HTCAppList");
            }
        }

        private ObservableCollection<PhoneApp> _microsoftAppList;
        public ObservableCollection<PhoneApp> MicrosoftAppList
        {
            get { return _microsoftAppList; }
            set
            {
                _microsoftAppList = value;
                RaisePropertyChanged("MicrosoftAppList");
            }
        }

        private ObservableCollection<PhoneApp> _userAppList;
        public ObservableCollection<PhoneApp> UserAppList
        {
            get { return _userAppList; }
            set
            {
                _userAppList = value;
                RaisePropertyChanged("UserAppList");
            }
        }

        private ObservableCollection<PhoneApp> _gameList;
        public ObservableCollection<PhoneApp> GameList
        {
            get { return _gameList; }
            set
            {
                _gameList = value;
                RaisePropertyChanged("GameList");
            }
        }

        //private Int32 _selectedCategoryIndex;
        //public Int32 SelectedCategoryIndex
        //{
        //    get { return _selectedCategoryIndex; }
        //    set
        //    {
        //        _selectedCategoryIndex = value;
        //        RaisePropertyChanged("SelectedCategoryIndex");
        //    }
        //}

        //private PhoneApp _selectedNokiaApp;
        //public PhoneApp SelectedNokiaApp
        //{
        //    get { return _selectedNokiaApp; }
        //    set
        //    {
        //        _selectedNokiaApp = value;
        //        RaisePropertyChanged("SelectedNokiaApp");
        //    }
        //}

        #endregion

        #region Commands

        private ICommand _viewAppCommand;
        
        public ICommand ViewAppCommand
        {
            get
            {
                return _viewAppCommand ??
                     (_viewAppCommand = new BaseCommand(ViewApp));
            }
        }
        
        #endregion

        #region Command methods

        public void ViewApp(Object param)
        {
            if (param == null || param.ToString().ToGuid() == Guid.Empty)
                return;

            var detailapp = new MarketplaceDetailTask {ContentIdentifier = param.ToString()};
            detailapp.Show();
        }

        public void AppBarAboutCommand()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.About);
        }

        public void AppBarAddNewCommand()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.NewApp);            
        }

        #endregion

        #region Initialize

        public void InitializeData()
        {
            _nokiaAppList = GetData("Nokia");
            _samsungAppList = GetData("Samsung");
            _htcAppList = GetData("HTC");
            _microsoftAppList = GetData("Microsoft");
            _userAppList = GetData("Applications");
            _gameList = GetData("Games");
        }

        private ObservableCollection<PhoneApp> GetData(String categoryName)
        {
            return new ObservableCollection<PhoneApp>(_db.PhoneApps.Where(app => app.Category == categoryName).ToList());
        } 

        #endregion
    }
}
