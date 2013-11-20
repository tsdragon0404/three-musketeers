using System.Collections.Generic;
using System.Windows.Forms;
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
            var userName = txtUsername.Text.Trim();
            var passWord = Encryption.Encrypt(Encryption.Encrypt(txtPassword.Text));
            var branchID = cmbBranch.SelectedValue.ToString();

            if(userName == "system")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }

#if DEBUG
    public class frmLoginAdmin_Design : ListForm<Branch> {}
#endif
}
