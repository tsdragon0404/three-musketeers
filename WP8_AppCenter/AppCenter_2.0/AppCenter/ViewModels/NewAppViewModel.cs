using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using AppCenter.Data;
using AppCenter.Models;
using AppCenter.Resources;
using GalaSoft.MvvmLight.Command;
using LS.Core;
using LS.Utilities;
using System.Net.NetworkInformation;

namespace AppCenter.ViewModels
{
    public class NewAppViewModel : BaseViewModel
    {
        #region Private variables
        
        private readonly AppCenterDataContext _db; 

        #endregion

        #region Constructor(s)

        public NewAppViewModel()
        {
            _db = new AppCenterDataContext();
        } 

        #endregion

        #region Public properties
        
        public PhoneApp App { get; private set; }

        public String _appID;
        public String AppID
        {
            get
            {
                return _appID;
            }
            set
            {
                if (!value.Equals(_appID))
                {
                    _appID = value;
                    App.AppID = Guid.Empty;
                }

                if (_appID.ToGuid() != App.AppID)
                    App.AppID = _appID.ToGuid();

                RaisePropertyChanged("AppID");
                RaisePropertyChanged("IsAppIDValid");
            }
        }

        private String _selectedCategory;
        public String SelectedCategory
        {
            get { return _selectedCategory; } 
            set
            {
                _selectedCategory = value;
                App.Category = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        private List<String> _categories; 
        public List<String> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        public Boolean AppIdChanged;

        public Boolean IsAppIDValid
        {
            get { return !AppIdChanged || App.AppID != Guid.Empty; }
        }

        #endregion

        #region Commands

        private ICommand _scanQRCodeCommand;

        public ICommand ScanQRCodeCommand
        {
            get
            {
                return _scanQRCodeCommand ??
                     (_scanQRCodeCommand = new RelayCommand(ScanQRCode));
            }
        }

        #endregion

        #region Command methods

        public void AppBarOkCommand()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                AppIdChanged = true;
                if (!IsAppIDValid)
                    RaisePropertyChanged("IsAppIDValid");
                else
                    RequestApplicationInfo.GetApplicationInfoAsync(AppID, HandleApplicationResult);
                    
            }
            else
                MessageBox.Show(AppResources.ErrorMessage_ConnectionNotAvailable, AppResources.ErrorMessage_ConnectionNotAvailable_Caption, MessageBoxButton.OK);
        }

        public void AppBarCancelCommand()
        {
            SendNavigationBack();
        }
        
        public void ScanQRCode()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.ScanQRCode);
        }

        private void HandleApplicationResult(ApplicationInfo appInfo)
        {
            if (appInfo == null)
            {
                MessageBox.Show(AppResources.ErrorMessage_NewApp_CannotGetAppInfo,
                                AppResources.ErrorMessage_NewApp_CannotGetAppInfo_Caption, MessageBoxButton.OK);
                return;
            }
            App.AppIcon = appInfo.ImageUrl;
            App.AppVersion = appInfo.Version;
            App.AppName = appInfo.AppName;
            App.LastUpdated = appInfo.LastUpdated;
            App.Category = appInfo.Category == "games" ? GlobalConstants.CategoryName.Games : GlobalConstants.CategoryName.Applications;
            _db.InsertApplication(App);
            SendNavigationBack(App.Category);
        }

        #endregion

        #region Initialize

        public void InitializeData(String id)
        {
            App = PhoneApp.NewUserDefinedApp();
            Categories = new List<String>
                             {
                                 GlobalConstants.CategoryName.Applications, 
                                 GlobalConstants.CategoryName.Games
                             };
            SelectedCategory = Categories[0];
            if (id != String.Empty)
                AppIdChanged = true;
            AppID = id;
        }

        #endregion
    }
}
