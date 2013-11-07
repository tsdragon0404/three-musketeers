using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.Data.BaseClasses;

namespace RMS.Admin.ViewModels
{
    public class UserViewModel : ListViewModel<User>
    {
        #region Properties

        public IUserCoreService UserCoreService { get; set; }

        #endregion

        #region Commands


        #endregion

        #region Override methods

        public override void InitializeData()
        {
            GetAllUser();
        }

        #endregion

        #region Private methods

        private void GetAllUser()
        {
            var result = UserCoreService.GetAllUser();
            if (result.Error == null || result.Error.Number == 0)
                ItemsSource = result.Data;
        }

        #endregion
    }
}