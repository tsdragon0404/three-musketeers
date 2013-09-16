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
using Microsoft.Phone.Tasks;
using System.IO;
using Microsoft.Phone.Info;
using AppCenter.ViewModel;
using System.Xml;
using System.Threading;
using System.Text;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Phone.Net.NetworkInformation;

namespace AppCenter
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string Os;
        private string dm;
        //private string Version;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
            Os = System.Environment.OSVersion.Version.ToString();
            dm = DeviceStatus.DeviceName;
        }

        private void newTaskAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewTaskPage.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.ViewModel.SaveChangesToDB();
        }

        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                // Get a handle for the to-do item bound to the button.
                ToDoItem toDoForDelete = button.DataContext as ToDoItem;

                App.ViewModel.DeleteToDoItem(toDoForDelete);
            }

            // Put the focus back to the main page.
            this.Focus();
        }

        private void hplItemName_Click(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var hpl = sender as HyperlinkButton;

            if (hpl != null)
            {
                // Get a handle for the to-do item bound to the button.
                ToDoItem toDoApp = hpl.DataContext as ToDoItem;
                MarketplaceDetailTask detailapp = new MarketplaceDetailTask();
                detailapp.ContentIdentifier = toDoApp.ItemNameAPPID;
                detailapp.Show();
            }
        }

        private void btnimgApp_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                // Get a handle for the to-do item bound to the button.
                ToDoItem toDoApp = btn.DataContext as ToDoItem;
                MarketplaceDetailTask detailapp = new MarketplaceDetailTask();
                detailapp.ContentIdentifier = toDoApp.ItemNameAPPID;
                detailapp.Show();
                
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/aboutpage.xaml", UriKind.Relative));
        }
        
        private void checkUpdateBarButton_Click(object sender, EventArgs e)
        {
            bool isNetwork = NetworkInterface.GetIsNetworkAvailable();
            if (isNetwork == true)
            {
                string DBConnectionString = "Data Source=isostore:/ToDo.sdf";

                using (ToDoDataContext db = new ToDoDataContext(DBConnectionString))
                {
                    var AllItemInDB = from ToDoItem todo in db.Items
                                      select new
                                      {
                                          todo.ItemNameAPPID,
                                          Version = todo.Version != "" && todo.LastUpdate != "" ? "Unknown version" : "Version " + todo.Version + ", Last update " + todo.LastUpdate
                                      };
                    clsRequestHtml clsR = new clsRequestHtml();
                    clsR.Os = Os;
                    clsR.dm = dm;

                    foreach (var item in AllItemInDB)
                    {
                        clsR.appID = item.ItemNameAPPID;
                        clsR.Start(1);
                    }
                }
            }
            else
            {
                List<string> MBOPTIONS = new List<string>();
                MBOPTIONS.Add("OK");
                string msg = "An internet connection not available.\nPlease check your connection and try again.";
                Guide.BeginShowMessageBox("No Connection", msg, MBOPTIONS, 0, MessageBoxIcon.Alert, null, null);
            }
        }
    }

    
}