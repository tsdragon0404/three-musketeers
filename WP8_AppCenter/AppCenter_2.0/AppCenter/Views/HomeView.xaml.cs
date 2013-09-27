using System;
using System.Windows.Navigation;
using AppCenter.Resources;
using AppCenter.ViewModels;
using LS.Utilities;
using Microsoft.Phone.Shell;
using System.Threading;

namespace AppCenter.Views
{
    public partial class HomeView
    {
        protected HomeViewModel ViewModel;

        public HomeView()
        {
            InitializeComponent();

            BuildApplicationBar();

            ViewModel = new HomeViewModel();
            DataContext = ViewModel;
        }

        #region ApplicationBar event methods

        public void BuildApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            var barbtnAdd =
                new ApplicationBarIconButton
                    {
                        Text = AppResources.AppBar_Add,
                        IconUri = GlobalConstants.ApplicationBarIcon.Add,
                    };
            barbtnAdd.Click += AppBarAddNew;

            ApplicationBar.Buttons.Add(barbtnAdd);

            var barbtnCheckUpdate =
                new ApplicationBarIconButton
                {
                    Text = AppResources.AppBar_Check,
                    IconUri = GlobalConstants.ApplicationBarIcon.Refresh,
                };
            barbtnCheckUpdate.Click += AppBarCheckUpdate;

            ApplicationBar.Buttons.Add(barbtnCheckUpdate);

            var barbtnSetting =
                new ApplicationBarIconButton
                    {
                        Text = AppResources.AppBar_Settings,
                        IconUri = GlobalConstants.ApplicationBarIcon.Setting,
                    };
            barbtnSetting.Click += AppBarSetting;

            ApplicationBar.Buttons.Add(barbtnSetting);

            var barbtnAbout =
                new ApplicationBarIconButton
                {
                    Text = AppResources.AppBar_About,
                    IconUri = GlobalConstants.ApplicationBarIcon.Info,
                };
            barbtnAbout.Click += AppBarAbout;

            ApplicationBar.Buttons.Add(barbtnAbout);
        }

        public void AppBarAddNew(Object sender, EventArgs e)
        {
           ViewModel.AppBarAddNewCommand();
        }

        public void AppBarCheckUpdate(Object sender, EventArgs e)
        {
            ViewModel.AppBarCheckUpdate();
        }

        public void AppBarAbout(Object sender, EventArgs e)
        {
            ViewModel.AppBarAboutCommand();
        }

        public void AppBarSetting(Object sender, EventArgs e)
        {
            ViewModel.AppBarSettingCommand();
        }

        #endregion

        #region Navigation

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var category = String.Empty;

            if (e.NavigationMode == NavigationMode.Back)
            {
                var param = GlobalConstants.Navigation.Param as String;
                if (param != null)
                    category = param;
            }

            if (!StateUtility.IsLaunching && State.ContainsKey("HomeViewModel") && String.IsNullOrEmpty(category))
                ViewModel = (HomeViewModel)State["HomeViewModel"];
            else
                ViewModel.InitializeData(category);

            switch (category)
            {
                case GlobalConstants.CategoryName.Nokia:
                    pivot.SelectedIndex = 0;
                    break;
                case GlobalConstants.CategoryName.Samsung:
                    pivot.SelectedIndex = 1;
                    break;
                case GlobalConstants.CategoryName.HTC:
                    pivot.SelectedIndex = 2;
                    break;
                case GlobalConstants.CategoryName.Microsoft:
                    pivot.SelectedIndex = 3;
                    break;
                case GlobalConstants.CategoryName.Applications:
                    pivot.SelectedIndex = 4;
                    break;
                case GlobalConstants.CategoryName.Games:
                    pivot.SelectedIndex = 5;
                    break;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (State.ContainsKey("HomeViewModel"))
                State["HomeViewModel"] = ViewModel;
            else
                State.Add("HomeViewModel", ViewModel);

            StateUtility.IsLaunching = false;
        }

        #endregion
    }
}