using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.UI.WindowsForms;
using TM.Utilities;

namespace RMS.Admin
{
    public partial class frmUser

#if DEBUG
    : frmUser_Design
#else
    : ListForm<User>
#endif

    {
        public IUserCoreService UserCoreService { get; set; }

        public frmUser()
        {
            InitializeComponent();
        }

        protected override IList<User> GetItemList()
        {
            var result = UserCoreService.GetAllUser();
            if (result.Error != null && result.Error.Number != 0)
            {
                return base.GetItemList();
            }

            return result.Data;
        }

        private void frmUser_Load(object sender, System.EventArgs e)
        {
            listBox1.DataSource = Items;
            listBox1.DisplayMember = "Login";
        }
    }

#if DEBUG
    public class frmUser_Design : ListForm<User> {}
#endif
}
