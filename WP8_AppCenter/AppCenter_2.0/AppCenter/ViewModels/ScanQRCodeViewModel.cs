using System;
using System.Windows.Input;
using LS.Core;
using LS.Utilities;

namespace AppCenter.ViewModels
{
    public class ScanQRCodeViewModel : BaseViewModel
    {
        #region Public Properties

        private String _resultText = "";
        public String ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                RaisePropertyChanged("ResultText");
            }
        } 

        #endregion

        #region Commands

        public void SendIDToNewAppView()
        {
            _resultText = "aaa";
            if(ResultText != String.Empty)
                SendNavigationRequestMessage(GlobalConstants.ViewUri.NewAppWithID(ResultText));
        }

        public void ClearID()
        {
            if(ResultText == String.Empty)
                SendNavigationRequestMessage(GlobalConstants.ViewUri.NewApp);
            ResultText = String.Empty;
        }

        #endregion

        #region Initialize
        public void InitializeData()
        {
            _resultText = String.Empty;
        }
        #endregion
    }
}
