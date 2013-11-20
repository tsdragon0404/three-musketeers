using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.UI.WindowsForms;
using TM.Utilities;

namespace RMS.Admin
{
    public partial class frmLoginAdmin

#if DEBUG
    : frmLoginAdmin_Design
#else
    : ListForm<Branch>
#endif

    {
        public IBranchCoreService BranchCoreService { get; set; }
        public IList<Branch> ListBranch { get; set; }

        public frmLoginAdmin()
        {
            InitializeComponent();
        }

        protected IList<Branch> GetAllBranch()
        {
            var result = BranchCoreService.GetAllBranch();
            if (result.Error != null && result.Error.Number != 0)
            {
                return base.GetItemList();
            }

            return result.Data;
        }

        private void frmLoginAdmin_Load(object sender, System.EventArgs e)
        {
            ListBranch = GetAllBranch();
            cmbBranch.DataSource = ListBranch;
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.ValueMember = "BranchID";
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string userName = txtUsername.Text.Trim();
            string passWord = Encryption.Encrypt(Encryption.Encrypt(txtPassword.Text));
            string branchID = cmbBranch.SelectedValue.ToString();
        }
    }

#if DEBUG
    public class frmLoginAdmin_Design : ListForm<Branch> {}
#endif
}
