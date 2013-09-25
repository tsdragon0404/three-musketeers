using System;
using System.Windows.Navigation;
using System.Windows.Threading;
using AppCenter.Resources;
using AppCenter.ViewModels;
using AppCenter.ZXing;
using LS.Utilities;
using Microsoft.Devices;
using Microsoft.Phone.Shell;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace AppCenter.Views
{
    public partial class ScanQRCodeView
    {
        #region Private variables

        private readonly DispatcherTimer _timer;
        private PhotoCameraLuminanceSource _luminance;
        private QRCodeReader _reader;
        private PhotoCamera _photoCamera; 

        #endregion

        protected ScanQRCodeViewModel ViewModel;

        #region Constructor

        public ScanQRCodeView()
        {
            InitializeComponent();

            BuildApplicationBar();

            ViewModel = new ScanQRCodeViewModel();
            DataContext = ViewModel;

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(250) };
            _timer.Tick += (o, arg) => ScanPreviewBuffer();
        } 

        #endregion

        public void BuildApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            var barbtnOk =
                new ApplicationBarIconButton
                {
                    Text = AppResources.ScanQR_Ok,
                    IconUri = GlobalConstants.ApplicationBarIcon.Check,
                };
            barbtnOk.Click += AppBarOk;

            ApplicationBar.Buttons.Add(barbtnOk);

            var barbtnCancel =
                new ApplicationBarIconButton
                {
                    Text = AppResources.ScanQR_Cancel,
                    IconUri = GlobalConstants.ApplicationBarIcon.Cancel,
                };
            barbtnCancel.Click += AppBarCancel;

            ApplicationBar.Buttons.Add(barbtnCancel);
        }

        private void AppBarOk(Object sender, EventArgs e)
        {
            ViewModel.SendIDToNewAppView();
        }

        private void AppBarCancel(Object sender, EventArgs e)
        {
            ViewModel.ClearID();
        }

        #region Camera methods

        private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
        {
            var width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
            var height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);

            _luminance = new PhotoCameraLuminanceSource(width, height);
            _reader = new QRCodeReader();

            Dispatcher.BeginInvoke(() =>
            {
                _previewTransform.Rotation = _photoCamera.Orientation;
                _timer.Start();
            });
        }

        private void ScanPreviewBuffer()
        {
            try
            {
                _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(_luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                var result = _reader.decode(binBitmap);
                if(result != null && result.Text != String.Empty)
                    Dispatcher.BeginInvoke(() => DisplayResult(result.Text));
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        private void DisplayResult(string text)
        {
            resultText.Text = text;
        } 

        #endregion

        #region Navigation

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.InitializeData();
            _photoCamera = new PhotoCamera();
            _photoCamera.Initialized += OnPhotoCameraInitialized;
            _previewVideo.SetSource(_photoCamera);

            CameraButtons.ShutterKeyHalfPressed += (o, arg) => _photoCamera.Focus();

            base.OnNavigatedTo(e);

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            _photoCamera.Dispose();
        }

        #endregion
    }
}