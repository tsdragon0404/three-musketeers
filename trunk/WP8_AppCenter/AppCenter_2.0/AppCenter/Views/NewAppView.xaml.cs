using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Navigation;
using AppCenter.Resources;
using AppCenter.ViewModels;
using LS.Utilities;
using Microsoft.Phone.Shell;

namespace AppCenter.Views
{
    public partial class NewAppView
    {
        protected NewAppViewModel ViewModel;

        public NewAppView()
        {
            InitializeComponent();
            BuildApplicationBar();

            ViewModel = new NewAppViewModel();
            DataContext = ViewModel;
        }

        #region Control events

        //private void AppIDLoaded(Object sender, EventArgs e)
        //{
        //    var textBox = sender as TextBox;
        //    if (textBox == null)
        //        return;
        //    if (textBox.Text == String.Empty)
        //        textBox.Text = AppResources.NewApp_AppID;
        //}

        //private void AppIDGotFocus(Object sender, RoutedEventArgs e)
        //{
        //    var textBox = sender as TextBox;
        //    if (textBox == null)
        //        return;

        //    if (textBox.Text == AppResources.NewApp_AppID)
        //        textBox.Text = String.Empty;

        //    ViewModel.AppIdChanged = true;
        //}

        //private void AppIDLostFocus(Object sender, RoutedEventArgs e)
        //{
        //    var textBox = sender as TextBox;
        //    if (textBox == null)
        //        return;

        //    if (string.IsNullOrEmpty(textBox.Text))
        //        textBox.Text = AppResources.NewApp_AppID;
        //}

        private void txtAppIDInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }

        #endregion

        #region ApplicationBar event methods

        public void BuildApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            var barbtnOk = new ApplicationBarIconButton
                                {
                                    Text = AppResources.AppBar_Ok,
                                    IconUri = GlobalConstants.ApplicationBarIcon.Check,
                                };
            barbtnOk.Click += AppBarOk;

            ApplicationBar.Buttons.Add(barbtnOk);

            var barbtnCancel = new ApplicationBarIconButton
                                        {
                                            Text = AppResources.AppBar_Cancel,
                                            IconUri = GlobalConstants.ApplicationBarIcon.Cancel,
                                        };
            barbtnCancel.Click += AppBarCancel;

            ApplicationBar.Buttons.Add(barbtnCancel);
        }

        public void AppBarOk(Object sender, EventArgs e)
        {
            ViewModel.AppBarOkCommand();
        }

        public void AppBarCancel(Object sender, EventArgs e)
        {
            ViewModel.AppBarCancelCommand();
        }

        #endregion

        #region Navigation

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var id = String.Empty;

            if (e.NavigationMode == NavigationMode.Back)
            {
                var param = GlobalConstants.Navigation.Param as String;
                if (param != null) 
                    id = param;
            }

            if (!StateUtility.IsLaunching && State.ContainsKey("NewAppViewModel") && String.IsNullOrEmpty(id))
                ViewModel = (NewAppViewModel)State["NewAppViewModel"];
            else
                ViewModel.InitializeData(id);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (State.ContainsKey("NewAppViewModel"))
                State["NewAppViewModel"] = ViewModel;
            else
                State.Add("NewAppViewModel", ViewModel);

            StateUtility.IsLaunching = false;
        }

        #endregion
    }
}