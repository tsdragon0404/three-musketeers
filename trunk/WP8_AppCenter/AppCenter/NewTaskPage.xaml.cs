using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using AppCenter.Model;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Info;
using Microsoft.Xna.Framework.GamerServices;

namespace AppCenter
{
    public partial class NewTaskPage : PhoneApplicationPage
    {
        string Os = "";
        string dm = "";

        public NewTaskPage()
        {
            InitializeComponent();
            Os = System.Environment.OSVersion.Version.ToString();
            dm = DeviceStatus.DeviceName;

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            bool isNetwork = NetworkInterface.GetIsNetworkAvailable();
            if (isNetwork == true)
            {
                if (txtID.Text.Trim() != "Input your App ID..." && txtID.Text.Trim() != "")
                {
                    clsRequestHtml clsR = new clsRequestHtml();
                    clsR.Os = Os;
                    clsR.dm = dm;
                    clsR.Catagory = ((ComboBoxItem)categoriesListPicker.SelectedItem).Content.ToString();
                    clsR.appID = txtID.Text.Trim();
                    clsR.Start(2);

                    // Return to the main page.
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.GoBack();
                    }
                }
                else
                {
                    List<string> MBOPTIONS = new List<string>();
                    MBOPTIONS.Add("OK");
                    string msg = "Please input your App ID and try again.\nClick OK to continue...";
                    Guide.BeginShowMessageBox("App ID invalid", msg, MBOPTIONS, 0, MessageBoxIcon.Alert, null, null);
                }
            }
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void txtID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtID.Text.Equals("Input your App ID...", StringComparison.OrdinalIgnoreCase))
            {
                txtID.Text = string.Empty;
                txtID.FontSize = 22;
                txtID.FontStyle = FontStyles.Normal;
            }  
        }

        private void txtID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Text = "Input your App ID...";
                txtID.FontSize = 20;
                txtID.FontStyle = FontStyles.Italic;
            }
        }
    }
}