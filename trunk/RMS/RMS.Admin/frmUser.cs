using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.UI.WindowsForms;
using TM.UI.WindowsForms.Utilities;
using TM.Utilities;

namespace RMS.Admin
{
    [FunctionId(GlobalConstants.FunctionIds.FormUser)]
    public partial class frmUser

#if DEBUG
    : frmUser_Design
#else
    : ListForm<User>
#endif

    {
        #region Public properties

        public IUserCoreService UserCoreService { get; set; }

        #endregion

        #region Constructor(s)

        public frmUser()
        {
            InitializeComponent();
        } 

        #endregion

        #region Override methods

        protected override IList<User> GetItemList()
        {
            var result = UserCoreService.GetAllUser();
            if (result.Error != null && result.Error.Number != 0)
            {
                return base.GetItemList();
            }

            return result.Data;
        } 

        #endregion

        #region Event methods

        private void frmUser_Load(object sender, System.EventArgs e)
        {
            lsbUser.DataSource = Items;
            lsbUser.DisplayMember = "Fullname";
        } 

        #endregion
    }

#if DEBUG
    public class frmUser_Design : ListForm<User> {}
#endif
}
