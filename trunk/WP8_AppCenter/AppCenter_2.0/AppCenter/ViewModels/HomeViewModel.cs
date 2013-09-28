using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Input;
using AppCenter.Data;
using AppCenter.Models;
using GalaSoft.MvvmLight.Command;
using LS.Core;
using LS.Utilities;
using Microsoft.Phone.Tasks;
using System.Windows;
using AppCenter.Resources;

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

        #endregion

        #region Commands

        private ICommand _viewAppCommand;

        public ICommand ViewAppCommand
        {
            get
            {
                return _viewAppCommand ??
                     (_viewAppCommand = new RelayCommand<Object>(ViewApp));
            }
        }

        private ICommand _checkUpdateCommand;

        public ICommand CheckUpdateCommand
        {
            get { return _checkUpdateCommand ?? (_checkUpdateCommand = new RelayCommand<Object>(CheckUpdate)); }
        }

        private ICommand _deleteAppCommand;

        public ICommand DeleteAppCommand
        {
            get { return _deleteAppCommand ?? (_deleteAppCommand = new RelayCommand<Object>(DeleteApp)); }
        }

        #endregion

        #region Command methods

        public void CheckUpdate(Object param)
        {
            if (param == null || param.ToString().ToGuid() == Guid.Empty || !NetworkInterface.GetIsNetworkAvailable())
                return;

            RequestApplicationInfo.GetApplicationInfoAsync(param.ToString(), appInfo =>
                                                                                 {
                                                                                     String categoryName;
                                                                                     _db.UpdateApplication(appInfo, out categoryName);
                                                                                     RefetchCategory(categoryName, appInfo);
                                                                                 });
        }

        public void DeleteApp(Object param)
        {
            if (param == null || param.ToString().ToGuid() == Guid.Empty)
                return;

            String categoryName;
            _db.DeleteApplication(param.ToString().ToGuid(), out categoryName);
            RefetchCategory(categoryName);
        }

        public void ViewApp(Object param)
        {
            if (param == null || param.ToString().ToGuid() == Guid.Empty)
                return;

            var detailapp = new MarketplaceDetailTask { ContentIdentifier = param.ToString() };
            detailapp.Show();
        }

        public void AppBarAboutCommand()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.About);
        }

        public void AppBarSettingCommand()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.Setting);
        }

        public void AppBarAddNewCommand()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.NewApp);
        }

        public void AppBarCheckUpdate()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                MessageBox.Show(AppResources.ErrorMessage_ConnectionNotAvailable, AppResources.ErrorMessage_ConnectionNotAvailable_Caption, MessageBoxButton.OK);
            else
            {
                var settingList = _db.GetAllSettings();
                _db.Refresh(RefreshMode.OverwriteCurrentValues, settingList);

                var appList = new List<PhoneApp>();
                foreach (var setting in settingList.Where(setting => setting.Value))
                {
                    switch (setting.VendorName)
                    {
                        case GlobalConstants.CategoryName.Nokia:
                            appList = appList.Concat(NokiaAppList).ToList();
                            break;
                        case GlobalConstants.CategoryName.Samsung:
                            appList = appList.Concat(SamsungAppList).ToList();
                            break;
                        case GlobalConstants.CategoryName.Microsoft:
                            appList = appList.Concat(MicrosoftAppList).ToList();
                            break;
                        case GlobalConstants.CategoryName.HTC:
                            appList = appList.Concat(HTCAppList).ToList();
                            break;
                        case GlobalConstants.CategoryName.Applications:
                            appList = appList.Concat(UserAppList).ToList();
                            break;
                        case GlobalConstants.CategoryName.Games:
                            appList = appList.Concat(GameList).ToList();
                            break;
                    }
                }

                foreach (var app in appList)
                    CheckUpdate(app.AppID);

                MessageBox.Show(AppResources.Message_CheckUpdateSuccess, AppResources.Message_CheckUpdateSuccess_Caption, MessageBoxButton.OK);
            }
        }

        #endregion

        #region Initialize

        public void InitializeData(String category)
        {
            RefetchCategory(category);
        }

        #endregion

        #region Refetch data

        public void RefetchCategory(String categoryName, ApplicationInfo appInfo = null)
        {
            switch (categoryName)
            {
                case GlobalConstants.CategoryName.Nokia:
                    NokiaAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Nokia).ToObservableCollection();
                    break;
                case GlobalConstants.CategoryName.Samsung:
                    SamsungAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Samsung).ToObservableCollection();
                    break;
                case GlobalConstants.CategoryName.HTC:
                    HTCAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.HTC).ToObservableCollection();
                    break;
                case GlobalConstants.CategoryName.Microsoft:
                    MicrosoftAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Microsoft).ToObservableCollection();
                    break;
                case GlobalConstants.CategoryName.Applications:
                    UserAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Applications).ToObservableCollection();
                    break;
                case GlobalConstants.CategoryName.Games:
                    GameList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Games).ToObservableCollection();
                    break;
                default:
                    NokiaAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Nokia).ToObservableCollection();
                    SamsungAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Samsung).ToObservableCollection();
                    HTCAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.HTC).ToObservableCollection();
                    MicrosoftAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Microsoft).ToObservableCollection();
                    UserAppList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Applications).ToObservableCollection();
                    GameList = _db.GetAppsByCategoryName(GlobalConstants.CategoryName.Games).ToObservableCollection();
                    break;
            }
        }

        #endregion
    }
}
