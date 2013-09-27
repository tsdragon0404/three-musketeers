using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows.Input;
using AppCenter.Data;
using AppCenter.Models;
using GalaSoft.MvvmLight.Command;
using LS.Core;
using LS.Utilities;
using Microsoft.Phone.Tasks;
using System.Threading;

namespace AppCenter.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        #region Private variables
        
        private readonly AppCenterDataContext _db; 

        #endregion

        #region Constructor(s)

        public SettingViewModel()
        {
            _db = new AppCenterDataContext();
        } 

        #endregion

        #region Public properties

        private ObservableCollection<Setting> _settingList;
        public ObservableCollection<Setting> SettingList
        {
            get { return _settingList; }
            set
            {
                _settingList = value;
                RaisePropertyChanged("SettingList");
            }
        }

        #endregion

        #region Commands

        private ICommand _updateSettingCommand;

        public ICommand UpdateSettingCommand
        {
            get
            {
                return _updateSettingCommand ??
                     (_updateSettingCommand = new RelayCommand<Object>(UpdateSetting));
            }
        }

        #endregion

        #region Command methods

        public void UpdateSetting(Object param)
        {
            if (param == null || param.ToString() == String.Empty)
                return;
            _db.UpdateSetting(int.Parse(param.ToString()));
            LoadSettings();
        }

        #endregion

        #region Initialize

        public void InitializeData()
        {
            LoadSettings();
        }

        #endregion

        #region Load settings

        public void LoadSettings()
        {
            SettingList = _db.GetSetting().ToObservableCollection();
        }

        #endregion
    }
}
