using System;
using System.Windows.Navigation;
using AppCenter.Resources;
using AppCenter.ViewModels;
using LS.Utilities;
using Microsoft.Phone.Shell;

namespace AppCenter.Views
{
    public partial class SettingView
    {
        protected SettingViewModel ViewModel;

        public SettingView()
        {
            InitializeComponent();

            ViewModel = new SettingViewModel();
            DataContext = ViewModel;
            ViewModel.InitializeData();
        }
    }
}