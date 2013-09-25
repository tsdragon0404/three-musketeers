using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using AppCenter.Data;
using AppCenter.Models;
using AppCenter.Resources;
using LS.Core;
using LS.Utilities;

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

                    RaisePropertyChanged("AppID");
                    RaisePropertyChanged("IsAppIDValid");
                }

                if (_appID.ToGuid() != App.AppID)
                    App.AppID = _appID.ToGuid();
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
                     (_scanQRCodeCommand = new BaseCommand(ScanQRCode));
            }
        }

        #endregion

        #region Command methods

        public void AppBarOkCommand()
        {
            if (App.AppID == Guid.Empty)
                return;

            MessageBox.Show("Not implemented");
        }

        public void AppBarCancelCommand()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.Home);
        }
        
        public void ScanQRCode()
        {
            SendNavigationRequestMessage(GlobalConstants.ViewUri.ScanQRCode);
        }

        #endregion

        #region Initialize

        public void InitializeData(String id)
        {
            App = PhoneApp.NewUserDefinedApp();
            Categories = new List<String>
                             {
                                 AppResources.NewApp_Category_Applications, 
                                 AppResources.NewApp_Category_Games
                             };
            SelectedCategory = Categories[0];
            if (id != String.Empty)
                AppIdChanged = true;
            AppID = id;
        }

        #endregion
    }
}
