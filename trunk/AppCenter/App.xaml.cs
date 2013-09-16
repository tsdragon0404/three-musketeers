using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppCenter.Resources;
using AppCenter.Model;
using AppCenter.ViewModel;

namespace AppCenter
{
    public partial class App : Application
    {
        private static ToDoViewModel viewModel;
        public static ToDoViewModel ViewModel
        {
            get { return viewModel; }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public static PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions.
            UnhandledException += Application_UnhandledException;

            // Standard XAML initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Language display initialization
            InitializeLanguage();

            // Show graphics profiling information while debugging.
            if (Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode,
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Prevent the screen from turning off while under the debugger by disabling
                // the application's idle detection.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

            // Specify the local database connection string.
            string DBConnectionString = "Data Source=isostore:/ToDo.sdf";

            // Create the database if it does not exist.
            using (ToDoDataContext db = new ToDoDataContext(DBConnectionString))
            {
                if (db.DatabaseExists() == false)
                {
                    // Create the local database.
                    db.CreateDatabase();
                    
                    //Nokia app
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/5.png", ItemName = "App Social", ItemNameAPPID = "51f96aba-9924-43d7-8d6c-76a24018d3e0", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "" , LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "Lumia storage check beta", ItemNameAPPID = "c2adc981-83c2-4f19-8161-67149e44214c", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/21.png", ItemName = "Nokia Chat beta", ItemNameAPPID = "386213a7-7cff-4e0a-b658-03646dcc6f50", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/22.png", ItemName = "Nokia Conference beta", ItemNameAPPID = "0264f9a0-689a-40d9-86ad-b20b70ebaad8", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/23.png", ItemName = "Place Tag beta", ItemNameAPPID = "547610c8-e367-49db-8a6d-d279489b753a", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/24.png", ItemName = "Play to", ItemNameAPPID = "8257b398-f4bf-4483-97c7-6fd6a1e60bbf", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/34.png", ItemName = "Nokia Reading", ItemNameAPPID = "ab0d89cb-73a4-4ff8-93dd-91bec9f855bd", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/1.png", ItemName = "Nokia Trailers", ItemNameAPPID = "b0731ce2-cdee-4cad-af01-a74a0433fcea", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/25.png", ItemName = "Nokia Music", ItemNameAPPID = "f5874252-1f04-4c3f-a335-4fa3b7b85329", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/33.png", ItemName = "Nokia TV", ItemNameAPPID = "8f592862-8bb5-4391-b6ca-c79730d3f34a", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });

                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/17.png", ItemName = "Ringtone Maker", ItemNameAPPID = "5a99cbd9-e82a-4892-8264-17a64f9142e5", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/12.png", ItemName = "My Nokia", ItemNameAPPID = "5e242463-ad9c-489b-b1db-cc94a26e513b", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/11.png", ItemName = "Nokia NFC Writer", ItemNameAPPID = "709e64e0-5849-4ce4-b252-b7b252aefacf", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/26.png", ItemName = "Nokia Xpress", ItemNameAPPID = "cbf5f827-aa0a-4670-8ba6-775676f275b0", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/18.png", ItemName = "Transfer my Data", ItemNameAPPID = "dc08943b-7b3d-4ee5-aa3c-30f1a826af02", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/64.png", ItemName = "Contacts Transfer", ItemNameAPPID = "47621875-70b8-4755-b60c-435c0418e899", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/27.png", ItemName = "YouSendt", ItemNameAPPID = "7cdfb28f-49a1-49af-92b9-16cff52bfd54", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });

                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/13.png", ItemName = "Creative Studio", ItemNameAPPID = "a8ddc8f6-c12c-44e6-b22e-52e2f0905f3e", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/2.png", ItemName = "Nokia Cinemagraph", ItemNameAPPID = "594477c0-e991-4ed4-8be4-466055670e69", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/4.png", ItemName = "Nokia Glam Me", ItemNameAPPID = "40b6a721-15d2-4843-a746-774bd7b9bda9", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/10.png", ItemName = "Nokia Pro Cam", ItemNameAPPID = "bfd2d954-12da-415c-ad99-69a20f101e04", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/6.png", ItemName = "Nokia Smart Cam", ItemNameAPPID = "73e1801b-916e-4db5-87ba-65fbc8dfd8fc", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/7.png", ItemName = "Nokia Video Trimmer", ItemNameAPPID = "50ece96d-bb5d-4669-a7e1-37246d904d5c", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/14.png", ItemName = "Nokia Video Upload", ItemNameAPPID = "0aeb1b49-f255-41ec-bf47-897b56b15584", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/19.png", ItemName = "Panorama", ItemNameAPPID = "8124bf8c-0db0-4688-8ec7-698a3c313f2b", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/3.png", ItemName = "PhotoBeamer", ItemNameAPPID = "971c41e5-3596-4a7a-ba2c-bcd7780d7db5", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/9.png", ItemName = "Smart Shoot", ItemNameAPPID = "bb534f9b-3f38-483b-a409-9285de9c62d4", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });

                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/28.png", ItemName = "HERE City Lens", ItemNameAPPID = "b0a0ac22-cf9e-45ba-8120-815450e2fd71", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/30.png", ItemName = "HERE Drive+", ItemNameAPPID = "31bbc68c-503e-4561-8d85-a294d54df06f", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/29.png", ItemName = "HERE Maps", ItemNameAPPID = "efa4b4a7-7499-46ce-aa95-3e4ab3b39313", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/31.png", ItemName = "HERE Transit", ItemNameAPPID = "adfdad16-b54a-4ec3-b11e-66bd691be4e6", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });

                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "access point", ItemNameAPPID = "ce3895c7-01d0-4daf-a4c3-25c10463942d", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "accessories", ItemNameAPPID = "2fa58039-a6ea-4421-b5c6-9ffac0c3ec3d", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "audio", ItemNameAPPID = "373cb76e-7f6c-45aa-8633-b00e85c73261", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "display+touch", ItemNameAPPID = "b08997ca-60ab-4dce-b088-f92e9c7994f3", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "extras+info", ItemNameAPPID = "2377fe1b-c10f-47da-92f3-fc517345a3c0", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "glance", ItemNameAPPID = "106e0a97-8b19-42cf-8879-a8ed2598fcbb", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "feedback to Nokia", ItemNameAPPID = "aec3bfad-e38c-4994-9c32-50bd030730ec", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "network+", ItemNameAPPID = "62f172d1-f552-4749-871c-2afd1c95c245", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/32.png", ItemName = "Nokia account", ItemNameAPPID = "5c2f810e-7445-4ecb-92d9-99514a5133f4", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/20.png", ItemName = "storage check", ItemNameAPPID = "b4cf45cc-a355-40d2-8b74-51517a042a18", IsUserDefine = "Collapsed", Catagory = "Nokia", Version = "", LastUpdate = "", IsUpdate = "White" });

                    //Samsung app
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/47.png", ItemName = "Video Trimmer", ItemNameAPPID = "e1104603-4b3c-4892-a2f1-dd4c569cc4fb", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/43.png", ItemName = "Now", ItemNameAPPID = "4bc2a02b-86b0-df11-8a2f-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/44.png", ItemName = "Collins Advanced Dictionary", ItemNameAPPID = "3a6b5578-9a92-e011-986b-78e7d1fa76f8", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/42.png", ItemName = "RSS Times", ItemNameAPPID = "e7fd6b61-a095-4b06-9fba-005cc9b09267", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/35.png", ItemName = "Artistic Effect", ItemNameAPPID = "c91eccb8-dbba-4ed8-b5e7-a67925c2a794", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/37.png", ItemName = "Color effects", ItemNameAPPID = "efca9009-bccd-4763-8e2c-7545d4357dd6", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/41.png", ItemName = "Beauty", ItemNameAPPID = "106245cc-94a2-4d89-b876-27d22aa7b168", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/36.png", ItemName = "Fun Shot", ItemNameAPPID = "e07d192c-27c7-40e1-b01c-b8bdbeb65925", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/48.png", ItemName = "MangaCamera", ItemNameAPPID = "a1634bc6-6be9-4f44-9299-5d7ef96a919e", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/51.png", ItemName = "Paper Artist", ItemNameAPPID = "a1d6b668-ceb2-430b-be62-26a515629d9f", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/40.png", ItemName = "Photo Editor", ItemNameAPPID = "c6cf28b1-f83b-42b9-b6fa-b84cbda80b5c", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/50.png", ItemName = "Photogram", ItemNameAPPID = "edcfb419-78ed-df11-9264-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/38.png", ItemName = "ChatON", ItemNameAPPID = "adb7b0f1-27c6-4ca7-8d76-82c88101cd2f", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/57.png", ItemName = "additional call settings", ItemNameAPPID = "7df63b5e-131b-459a-a99a-7cd5abcb8f40", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/58.png", ItemName = "advanced text messages", ItemNameAPPID = "66b14da3-2fa9-4f2f-a8fb-206437150e42", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/57.png", ItemName = "apn", ItemNameAPPID = "d6ed0f16-898c-4579-b140-9942869b9bc4", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/57.png", ItemName = "call blocking", ItemNameAPPID = "41b58943-f500-4c13-8b9c-81c96d10e342", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/57.png", ItemName = "extra settings", ItemNameAPPID = "522875f3-f379-4b81-ac6f-29ce06ff2daa", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/57.png", ItemName = "APNs", ItemNameAPPID = "5e5c37c0-fb9f-4587-8934-d35228de7622", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/46.png", ItemName = "App Folders", ItemNameAPPID = "1a248adb-1429-45ea-a507-f3d5f4cad58c", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/59.png", ItemName = "ATIV Beam", ItemNameAPPID = "0f38bc3b-f723-47b9-8444-6b7da64fe38b", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/49.png", ItemName = "Live Wallpaper", ItemNameAPPID = "227a4e87-e3eb-49b2-be02-526cf116631c", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/39.png", ItemName = "Mini Diary", ItemNameAPPID = "1af954eb-a84e-4968-9687-bd65e58cef37", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/60.png", ItemName = "Mobile Care", ItemNameAPPID = "5c4fede5-ce12-49ba-a27d-4ff7b631a809", IsUserDefine = "Collapsed", Catagory = "SamSung", Version = "", LastUpdate = "", IsUpdate = "White" });

                    //HTC app
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/45.png", ItemName = "HTC", ItemNameAPPID = "e462a4e4-0798-4e01-9ed7-fada88e38357", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/54.png", ItemName = "Photo Enhancer", ItemNameAPPID = "8e17bc66-2bb2-df11-8a2f-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/61.png", ItemName = "attentive phone", ItemNameAPPID = "59fba4ce-c8d6-df11-a844-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/62.png", ItemName = "Beats Audio", ItemNameAPPID = "54b4b23e-c2cd-4433-9c34-17a4105d1679", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/56.png", ItemName = "Connection Setup", ItemNameAPPID = "5edbdbbc-2ab2-df11-8a2f-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/63.png", ItemName = "CSDDiag", ItemNameAPPID = "f81239cf-2e0f-4fc1-9141-a66e080b83f9", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/53.png", ItemName = "Converter", ItemNameAPPID = "de54d3b1-47b1-df11-8a2f-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/55.png", ItemName = "Flashlight", ItemNameAPPID = "0be0455c-c8d5-df11-a844-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/52.png", ItemName = "Make More Space", ItemNameAPPID = "fc388ddb-433d-4c70-ac48-455175a2cbf5", IsUserDefine = "Collapsed", Catagory = "HTC", Version = "", LastUpdate = "", IsUpdate = "White" });

                    //Microsoft app
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/65.png", ItemName = "Authenticator", ItemNameAPPID = "e7994dbc-2336-4950-91ba-ca22d653759b", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/66.png", ItemName = "Bing Finance", ItemNameAPPID = "1e0440f1-7abf-4b9a-863d-177970eefb5e", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/67.png", ItemName = "Bing Sports", ItemNameAPPID = "0f4c8c7e-7114-4e1e-a84c-50664db13b17", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/68.png", ItemName = "Bing News", ItemNameAPPID = "9c3e8cad-6702-4842-8f61-b8b33cc9caf1", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/69.png", ItemName = "Bing Weather", ItemNameAPPID = "63c2a117-8604-44e7-8cef-df10be3a57c8", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/70.png", ItemName = "Cellular Data", ItemNameAPPID = "cb9ca504-e5dc-4055-9f09-488399e3b950", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/71.png", ItemName = "Photosynth", ItemNameAPPID = "ef860a79-5f68-4ed6-aa21-c038d1a55517", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/72.png", ItemName = "Windows Phone Insider", ItemNameAPPID = "6c6091e6-0128-e011-854c-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/73.png", ItemName = "Translator", ItemNameAPPID = "2cb7cda1-17d8-df11-a844-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/74.png", ItemName = "PDF Reader", ItemNameAPPID = "8f6154d6-1b70-431a-a579-b6a43477e837", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/75.png", ItemName = "Fresh Paint", ItemNameAPPID = "ab89f9f8-f78b-4fa0-a244-c87d53c14319", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/76.png", ItemName = "Switch to Windows Phone", ItemNameAPPID = "3286dd5d-3f98-435a-b80c-3fccba05a867", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/77.png", ItemName = "My Home Server", ItemNameAPPID = "b0dbd32b-908c-e011-986b-78e7d1fa76f8", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/78.png", ItemName = "Retail Advisor", ItemNameAPPID = "99a6bdaf-d631-4df6-9660-603bc64b7b0d", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/79.png", ItemName = "Unit Converter", ItemNameAPPID = "0f69cc30-1bd8-df11-a844-00237de2db9e", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });
                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/80.png", ItemName = "SkyDrive", ItemNameAPPID = "ad543082-80ec-45bb-aa02-ffe7f4182ba8", IsUserDefine = "Collapsed", Catagory = "Microsoft", Version = "", LastUpdate = "", IsUpdate = "White" });

                    db.Items.InsertOnSubmit(new ToDoItem { ItemImage = "/Images/myapp.png", ItemName = "My app pusher", ItemNameAPPID = "8768a942-8f14-471b-85d7-9e67b16c11b4", IsUserDefine = "Collapsed", Catagory = "Application", Version = "", LastUpdate = "", IsUpdate = "White" });

                    // Save categories to the database.
                    db.SubmitChanges();
                }
            }

            // Create the ViewModel object.
            viewModel = new ToDoViewModel(DBConnectionString);

            // Query the local database and load observable collections.
            viewModel.LoadCollectionsFromDatabase();

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Handle reset requests for clearing the backstack
            RootFrame.Navigated += CheckForResetNavigation;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            // If the app has received a 'reset' navigation, then we need to check
            // on the next navigation to see if the page stack should be reset
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            // Unregister the event so it doesn't get called again
            RootFrame.Navigated -= ClearBackStackAfterReset;

            // Only clear the stack for 'new' (forward) and 'refresh' navigations
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            // For UI consistency, clear the entire page stack
            while (RootFrame.RemoveBackEntry() != null)
            {
                ; // do nothing
            }
        }

        #endregion

        // Initialize the app's font and flow direction as defined in its localized resource strings.
        //
        // To ensure that the font of your application is aligned with its supported languages and that the
        // FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
        // and ResourceFlowDirection should be initialized in each resx file to match these values with that
        // file's culture. For example:
        //
        // AppResources.es-ES.resx
        //    ResourceLanguage's value should be "es-ES"
        //    ResourceFlowDirection's value should be "LeftToRight"
        //
        // AppResources.ar-SA.resx
        //     ResourceLanguage's value should be "ar-SA"
        //     ResourceFlowDirection's value should be "RightToLeft"
        //
        // For more info on localizing Windows Phone apps see http://go.microsoft.com/fwlink/?LinkId=262072.
        //
        private void InitializeLanguage()
        {
            try
            {
                // Set the font to match the display language defined by the
                // ResourceLanguage resource string for each supported language.
                //
                // Fall back to the font of the neutral language if the Display
                // language of the phone is not supported.
                //
                // If a compiler error is hit then ResourceLanguage is missing from
                // the resource file.
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Set the FlowDirection of all elements under the root frame based
                // on the ResourceFlowDirection resource string for each
                // supported language.
                //
                // If a compiler error is hit then ResourceFlowDirection is missing from
                // the resource file.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                // If an exception is caught here it is most likely due to either
                // ResourceLangauge not being correctly set to a supported language
                // code or ResourceFlowDirection is set to a value other than LeftToRight
                // or RightToLeft.

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}