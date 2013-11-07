using System.Collections.Generic;
using TM.Data.BaseClasses;

namespace RMS.Admin.ViewModels
{
    public class AdminHomeViewModel : BaseViewModel
    {
        #region Properties

        public UserViewModel UserViewModel { get; set; }

        private int _tabSelectedIndex;

        public int TabSelectedIndex
        {
            get { return _tabSelectedIndex; }
            set
            {
                _tabSelectedIndex = value;
                HandleTabChange();
                NotifyOfPropertyChange(() => TabSelectedIndex);
            }
        }

        #endregion

        private IList<BaseViewModel> ChildViewModels;

        #region Commands
        
        public bool CanClick
        {
            get { return true; }
        }

        public void Click()
        {
            TabSelectedIndex = 2;
        } 

        #endregion 

        #region Override methods

        public override void InitializeData()
        {
            InitChildViewModel();
            TabSelectedIndex = 0;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            InitializeData();
        }

        #endregion

        #region Private methods
        
        private void InitChildViewModel()
        {
            ChildViewModels = new List<BaseViewModel>
                                  {
                                      UserViewModel
                                  };
        } 

        private void HandleTabChange()
        {
            if (ChildViewModels.Count > TabSelectedIndex && ChildViewModels[TabSelectedIndex] != null)
                ChildViewModels[TabSelectedIndex].InitializeData();
        }

        #endregion
    }
}