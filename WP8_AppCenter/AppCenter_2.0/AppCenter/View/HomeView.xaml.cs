using System;
using System.Windows;
using System.Windows.Navigation;
using AppCenter.ViewModel;
using LS.Utilities;

namespace AppCenter.View
{
    public partial class HomeView
    {
        public HomeViewModel ViewModel;

        public HomeView()
        {
            InitializeComponent();
            ViewModel = new HomeViewModel();
            DataContext = ViewModel;
        }

        #region ApplicationBar event methods

        public void AppBarDelete(Object sender, EventArgs e)
        {
           
        }

        public void AppBarCheckUpdate(Object sender, EventArgs e)
        {

        }

        public void AppBarAbout(Object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Navigation

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!StateUtility.IsLaunching && State.ContainsKey("HomeViewModel"))
                ViewModel = (HomeViewModel)State["HomeViewModel"];
            else
                ViewModel.GetAllData();
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