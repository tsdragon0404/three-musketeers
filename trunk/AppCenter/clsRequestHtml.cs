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
using System.Threading.Tasks;
using RestSharp;
using Microsoft.Xna.Framework.GamerServices;
using System.Windows.Navigation;


namespace AppCenter
{
    public class clsRequestHtml
    {
        //public static ManualResetEvent allDone = new ManualResetEvent(false);

        public string Os;
        public string dm;
        public string appID;
        public string Catagory;

        public clsRequestHtml()
        {
            Os = "";
            dm = "";
            appID = "";
            Catagory = "";
        }

        public void getVersion()
        {
            string url = "http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps/" + appID + "?os=" + Os + "&cc=US&oc=&lang=en-US&hw=520170499&dm=" + dm + "?ignored=" + DateTime.Now.Ticks.ToString();
            Uri uri = new Uri(url);

            WebClient webClient = new WebClient();
            webClient.AllowReadStreamBuffering = false;
            
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(uri);
        }

        public void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null) // No error
            {
                var data = e.Result; // Response data by server
                string stringContent;
                stringContent = data.ToString();

                string ver = "";
                string update = "";
                string id = "";

                using (XmlReader reader = XmlReader.Create(new StringReader(stringContent)))
                {
                    reader.ReadToFollowing("a:id");
                    id = reader.ReadElementContentAsString().Replace("urn:uuid:", "");

                    reader.ReadToFollowing("version");
                    ver = reader.ReadElementContentAsString();
                    
                    reader.ReadToFollowing("skuLastUpdated");
                    DateTime dt = Convert.ToDateTime(reader.ReadElementContentAsString());
                    update = string.Format("{0:MM/dd/yyyy}", dt);
                    
                    ToDoItem newToDoItem = new ToDoItem
                    {
                        ItemNameAPPID = id,
                        Version = ver,
                        LastUpdate = update
                    };
                    App.ViewModel.UpdateToDoItem(newToDoItem);
                } 
            }
        }

        public void checkAppID()
        {
            string url = "http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps/" + appID + "?os=" + Os + "&cc=US&oc=&lang=en-US&hw=520170499&dm=" + dm + "?ignored=" + DateTime.Now.Ticks.ToString();
            Uri uri = new Uri(url);

            WebClient webClient = new WebClient();
            webClient.AllowReadStreamBuffering = false;

            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClientCheckApp_DownloadStringCompleted);
            webClient.DownloadStringAsync(uri);
        }

        public void webClientCheckApp_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null) // No error
            {
                var data = e.Result; // Response data by server
                string stringContent;
                stringContent = data.ToString();

                string ver = "";
                string update = "";
                string id = "";
                string image = "";
                string title = "";

                using (XmlReader reader = XmlReader.Create(new StringReader(stringContent)))
                {
                    reader.ReadToFollowing("a:id");
                    id = reader.ReadElementContentAsString().Replace("urn:uuid:", "");

                    reader.ReadToFollowing("sortTitle");
                    title = reader.ReadElementContentAsString();

                    //reader.ReadToFollowing("image");
                    reader.ReadToFollowing("id");
                    image = reader.ReadElementContentAsString().Replace("urn:uuid:", "");

                    reader.ReadToFollowing("version");
                    ver = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("skuLastUpdated");
                    DateTime dt = Convert.ToDateTime(reader.ReadElementContentAsString());
                    update = string.Format("{0:MM/dd/yyyy}", dt);

                    // Create a new to-do item.
                    ToDoItem newToDoItem = new ToDoItem
                    {
                        ItemImage = "http://cdn.marketplaceimages.windowsphone.com/v8/images/" + image,
                        ItemName = title,
                        ItemNameAPPID = id,
                        Catagory = Catagory,
                        IsUserDefine = "Visible",
                        Version = ver,
                        LastUpdate = update,
                        IsUpdate = "White"
                    };

                    // Add the item to the ViewModel.
                    App.ViewModel.AddToDoItem(newToDoItem);
                }
            }
            else
            {
                List<string> MBOPTIONS = new List<string>();
                MBOPTIONS.Add("OK");
                string msg = "App ID not available.\nPlease check your App ID and try again.";
                Guide.BeginShowMessageBox("App ID invalid", msg, MBOPTIONS, 0, MessageBoxIcon.Alert, null, null);
            }
        }

        public void Start(int key)
        {
            if (key == 1)
                getVersion();
            else
                checkAppID();
        }
    }
}
