using System.Collections.Generic;
using System.Windows.Forms;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.UI.WindowsForms;
using TM.UI.WindowsForms.Utilities;
using TM.Utilities;

namespace RMS.Admin
{
    [FunctionId(GlobalConstants.FunctionIds.FormLoginAdmin)]
    public partial class frmLoginAdmin

#if DEBUG
    : frmLoginAdmin_Design
#else
    : ListForm<Branch>
#endif

    {
        #region IOC properties

        public IBranchCoreService BranchCoreService { get; set; }

        public IUserCoreService UserCoreService { get; set; }

        public UserContext UserContext { get; set; }

        #endregion
        
        #region Public properties

        public IList<Branch> ListBranch { get; set; } 

        #endregion

        #region Constructor(s)

        public frmLoginAdmin()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
        } 

        #endregion

        #region Override methods

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        protected override IList<Branch> GetItemList()
        {
            var result = BranchCoreService.GetAllBranch();
            if (result.Error != null && result.Error.Number != 0)
            {
                return base.GetItemList();
            }

            return result.Data;
        }

        #endregion

        #region Private methods


        #endregion

        #region Event methods

        private void frmLoginAdmin_Load(object sender, System.EventArgs e)
        {
            cmbBranch.DataSource = Items;
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.ValueMember = "BranchID";
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            var userName = txtUsername.Text.Trim();
            var password = Encryption.Encrypt(txtPassword.Text);
            var branchID = cmbBranch.SelectedValue.ToString().ToGuid();

            UserContext.BranchID = branchID;

            if(userName == "system")
            {
                DialogResult = DialogResult.OK;
                Close();
            }

            //after have login sp, use below line of code
            //var result = UserCoreService.Login(userName, password, branchID);
            //if(result.Error == null || result.Error.Number != 0)
            //{
            //    // login fail
            //    MessageBox.Show("Login fail, please check your input data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DialogResult = DialogResult.OK;
            //    Close();
            //}
        } 

        #endregion
    }

#if DEBUG
    public class frmLoginAdmin_Design : ListForm<Branch> {}
#endif
}
