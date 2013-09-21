using System;
using System.Windows.Navigation;
using AppCenter.Resources;
using AppCenter.ViewModels;
using LS.Utilities;
using Microsoft.Phone.Shell;

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

        }

        public void AppBarAbout(Object sender, EventArgs e)
        {
            ViewModel.AppBarAboutCommand();
        }
        #endregion

        #region Navigation

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!StateUtility.IsLaunching && State.ContainsKey("HomeViewModel"))
                ViewModel = (HomeViewModel)State["HomeViewModel"];
            else
                ViewModel.InitializeData();
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