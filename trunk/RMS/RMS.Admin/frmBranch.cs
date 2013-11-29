using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.UI.WindowsForms;
using TM.UI.WindowsForms.Utilities;
using TM.Utilities;
using RMS.Resources;

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
            return HasError(result.Error) ? base.GetItemList() : result.Data;
        } 

        #endregion

        #region Event methods

        private void frmBranch_Load(object sender, EventArgs e)
        {
            lsbBranch.DataSource = Items;
            lsbBranch.DisplayMember = "BranchName";
            if (Items.Count != 0)
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
                MessageManager.ShowError(Resource.Common_Error_Caption, result.Error.Message);
                return;
            }
            var branchID = result.Data;

            Items = GetItemList();
            lsbBranch.DataSource = Items;

            SelectedItem = Items.FirstOrDefault(b => b.BranchID == branchID);

            lsbBranch.Enabled = true;
            lsbBranch.SelectedIndex = SelectedIndex;
            tmCRUD.IsAdding = false;
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
            //tmCRUD.IsAdding = true;
            txtVNName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBranchID.Text.Trim() != "")
            {
                if (MessageManager.ShowQuestion(Resource.Common_Question_Caption, Resource.Common_Delete_Message) == DialogResult.Yes)
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
                    if(Items.Count == 0)
                    {
                        txtBranchID.Clear();
                        txtVNName.Clear();
                        txtENName.Clear();
                        txtSEQ.Clear();
                        ckbEnable.Checked = true;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lsbBranch.Enabled = true;
            userBindingSource.ResumeBinding();
            tmCRUD.IsAdding = false;
            if(Items.Count != 0)
                lsbBranch.SelectedIndex = SelectedIndex;
        } 

        #endregion
    }

#if DEBUG
    public class frmBranch_Design : ListForm<Branch> { }
#endif
}
