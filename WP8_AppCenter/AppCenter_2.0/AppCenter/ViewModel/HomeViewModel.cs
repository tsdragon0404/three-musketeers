using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AppCenter.Data;
using AppCenter.Model;
using LS.Core;

namespace AppCenter.ViewModel
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
                NotifyPropertyChanged("NokiaAppList");
            }
        }

        private ObservableCollection<PhoneApp> _samsungAppList;
        public ObservableCollection<PhoneApp> SamsungAppList
        {
            get { return _samsungAppList; }
            set
            {
                _samsungAppList = value;
                NotifyPropertyChanged("SamsungAppList");
            }
        }

        private ObservableCollection<PhoneApp> _htcAppList;
        public ObservableCollection<PhoneApp> HTCAppList
        {
            get { return _htcAppList; }
            set
            {
                _htcAppList = value;
                NotifyPropertyChanged("HTCAppList");
            }
        }

        private ObservableCollection<PhoneApp> _microsoftAppList;
        public ObservableCollection<PhoneApp> MicrosoftAppList
        {
            get { return _microsoftAppList; }
            set
            {
                _microsoftAppList = value;
                NotifyPropertyChanged("MicrosoftAppList");
            }
        }

        private ObservableCollection<PhoneApp> _userAppList;
        public ObservableCollection<PhoneApp> UserAppList
        {
            get { return _userAppList; }
            set
            {
                _userAppList = value;
                NotifyPropertyChanged("UserAppList");
            }
        } 

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

        public void ViewApp()
        {
            MessageBox.Show("done");
        }

        #endregion

        #region Get AppList from database

        public void GetAllData()
        {
            _nokiaAppList = GetData("Nokia");
            _samsungAppList = GetData("Samsung");
            _htcAppList = GetData("HTC");
            _microsoftAppList = GetData("Microsoft");
            _userAppList = GetData("Application");
        }

        private ObservableCollection<PhoneApp> GetData(string categoryName)
        {
            return new ObservableCollection<PhoneApp>(_db.PhoneApps.Where(app => app.Category == categoryName).ToList());
        } 

        #endregion
    }
}
