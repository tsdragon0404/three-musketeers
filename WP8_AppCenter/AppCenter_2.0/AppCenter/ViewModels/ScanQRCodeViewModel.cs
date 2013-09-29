using System;
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
            ResultText = "6cd31275-c5dd-df11-a844-00237de2db9d";
            if(ResultText != String.Empty)
                SendNavigationBack(ResultText);
        }

        public void ClearID()
        {
            if(ResultText == String.Empty)
                SendNavigationBack();
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
