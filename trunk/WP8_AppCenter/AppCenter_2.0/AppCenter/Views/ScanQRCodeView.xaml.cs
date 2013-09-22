using AppCenter.ViewModels;
using Microsoft.Devices;

namespace AppCenter.Views
{
    public partial class ScanQRCodeView
    {
        private PhotoCamera _camera;
        private bool _capturing = false;

        protected ScanQRCodeViewModel ViewModel;

        public ScanQRCodeView()
        {
            InitializeComponent();

            ViewModel = new ScanQRCodeViewModel();
            DataContext = ViewModel;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (_camera == null)
            {
                _camera = new PhotoCamera();

                // filred when the camera is initialised
                //_camera.Initialized += camera_Initialised;

                // fired when the button is fully pressed
                //CameraButtons.ShutterKeyPressed += camera_ButtonFullPress;

                // fired when an image is available.
                //_camera.CaptureImageAvailable += camera_CaptureImageAvailable;

                // set the VideoBrush source to the camera output
                videoRotateTransform.CenterX = videoRectangle.Width / 2;
                videoRotateTransform.CenterY = videoRectangle.Height / 2;
                videoRotateTransform.Angle = 90;

                viewfinderBrush.SetSource(_camera);
            }
            base.OnNavigatedTo(e);
        }
    }
}