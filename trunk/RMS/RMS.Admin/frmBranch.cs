using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.UI.WindowsForms;
using TM.Utilities;

namespace RMS.Admin
{
    [FunctionId(GlobalConstants.FunctionIds.FormBranch)]
    public partial class frmBranch

#if DEBUG
 : frmBranch_Design
#else
    : ListForm<Branch>
#endif

    {
        #region Public properties

        public IBranchCoreService BranchCoreService { get; set; } 

        #endregion

        #region Constructor(s)

        public frmBranch()
        {
            InitializeComponent();
        } 

        #endregion

        #region Override methods

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

        #region Event methods

        private void frmBranch_Load(object sender, EventArgs e)
        {
            lsbBranch.DataSource = Items;
            lsbBranch.DisplayMember = "BranchName";
            lsbBranch.ValueMember = "BranchID";
            lsbBranch.SelectedIndex = SelectedIndex;
        }

        private void lsbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = lsbBranch.SelectedIndex;
            if (userBindingSource.IsBindingSuspended)
                userBindingSource.ResumeBinding();
            userBindingSource.DataSource = SelectedItem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var branch = new Branch
                             {
                                 BranchID = txtBranchID.Text.Trim() == "" ? Guid.Empty : Guid.Parse(txtBranchID.Text),
                                 VNName = txtVNName.Text.Trim(),
                                 ENName = txtENName.Text.Trim(),
                                 SEQ = int.Parse(txtSEQ.Text.Trim()),
                                 Enable = ckbEnable.Checked
                             };
            var result = BranchCoreService.SaveBranch(branch);
            if (result.Error != null && result.Error.Number != 0)
            {
                MessageBox.Show(result.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var branchID = result.Data;

            Items = GetItemList();
            lsbBranch.DataSource = Items;

            SelectedItem = Items.FirstOrDefault(b => b.BranchID == branchID);

            lsbBranch.Enabled = true;
            lsbBranch.SelectedIndex = SelectedIndex;
            btnCreateNew.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            userBindingSource.SuspendBinding();
            lsbBranch.Enabled = false;
            txtBranchID.Clear();
            txtVNName.Clear();
            txtENName.Clear();
            txtSEQ.Clear();
            ckbEnable.Checked = true;
            btnCreateNew.Enabled = false;
            btnDelete.Enabled = false;
            txtVNName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idx = SelectedIndex;
                var result = BranchCoreService.DeleteBranch(Guid.Parse(txtBranchID.Text));
                if (result.Error != null && result.Error.Number != 0)
                {
                    MessageBox.Show(result.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Items = GetItemList();
                lsbBranch.DataSource = Items;
                try
                {
                    lsbBranch.SelectedIndex = idx;
                }
                catch
                {
                    lsbBranch.SelectedIndex = idx - 1;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lsbBranch.Enabled = true;
            userBindingSource.ResumeBinding();
            lsbBranch.SelectedIndex = SelectedIndex;
            btnCreateNew.Enabled = true;
            btnDelete.Enabled = true;
        } 

        #endregion
    }

#if DEBUG
    public class frmBranch_Design : ListForm<Branch> { }
#endif
}
