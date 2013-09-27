using System.Windows.Navigation;
using AppCenter.ViewModels;
using LS.Utilities;

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
        }

        #region Navigation

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!StateUtility.IsLaunching && State.ContainsKey("SettingViewModel"))
                ViewModel = (SettingViewModel)State["SettingViewModel"];
            else
                ViewModel.InitializeData();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (State.ContainsKey("SettingViewModel"))
                State["SettingViewModel"] = ViewModel;
            else
                State.Add("SettingViewModel", ViewModel);

            StateUtility.IsLaunching = false;
        }

        #endregion
    }
}