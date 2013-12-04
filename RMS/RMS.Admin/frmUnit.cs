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
    [FunctionId(GlobalConstants.FunctionIds.FormUnit)]
    public partial class frmUnit

#if DEBUG
 : frmUnit_Design
#else
    : ListForm<Unit>
#endif

    {
        #region Public properties

        public IUnitCoreService UnitCoreService{ get; set; }

        #endregion

        #region Constructor(s)

        public frmUnit()
        {
            InitializeComponent();
        }

        #endregion

        #region Override methods

        protected override IList<Unit> GetItemList()
        {
            var result = UnitCoreService.GetAllUnitForSetup();
            return HasError(result.Error) ? base.GetItemList() : result.Data;
        }

        #endregion

        private void frmUnit_Load(object sender, EventArgs e)
        {
            lsbUnit.DataSource = Items;
            lsbUnit.DisplayMember = "UnitName";
            if (Items.Count != 0)
            {
                lsbUnit.SelectedIndex = SelectedIndex;
            }
        }

        private void lsbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = lsbUnit.SelectedIndex;
            if (unitBindingSource.IsBindingSuspended)
                unitBindingSource.ResumeBinding();
            unitBindingSource.DataSource = SelectedItem;
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            unitBindingSource.SuspendBinding();
            lsbUnit.Enabled = false;
            txtUnitID.Clear();
            txtVNName.Clear();
            txtENName.Clear();
            txtSEQ.Clear();
            ckbEnable.Checked = true;
            tmCRUD.IsAdding = true;
            txtVNName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var unit = new Unit
            {
                UnitID = (Byte) (txtUnitID.Text.Trim() == "" ? 0 : Byte.Parse(txtUnitID.Text)),
                VNName = txtVNName.Text.Trim(),
                ENName = txtENName.Text.Trim(),
                SEQ = txtSEQ.Text.Trim() == "" ? 0 : int.Parse(txtSEQ.Text.Trim()),
                Enable = ckbEnable.Checked
            };
            var result = UnitCoreService.SaveUnit(unit);
            if (result.Error != null && result.Error.Number != 0)
            {
                MessageManager.ShowError(Resource.Common_Error_Caption, result.Error.Message);
                return;
            }
            var unitID = result.Data;

            Items = GetItemList();
            lsbUnit.DataSource = Items;

            SelectedItem = Items.FirstOrDefault(b => b.UnitID == unitID);

            lsbUnit.Enabled = true;
            lsbUnit.SelectedIndex = SelectedIndex;
            tmCRUD.IsAdding = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lsbUnit.Enabled = true;
            unitBindingSource.ResumeBinding();
            tmCRUD.IsAdding = false;
            if (Items.Count != 0)
                lsbUnit.SelectedIndex = SelectedIndex;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUnitID.Text.Trim() != "")
            {
                if (MessageManager.ShowQuestion(Resource.Common_Question_Caption, Resource.Common_Delete_Message) == DialogResult.Yes)
                {
                    int idx = SelectedIndex;
                    var result = UnitCoreService.DeleteUnit(Byte.Parse(txtUnitID.Text));
                    if (result.Error != null && result.Error.Number != 0)
                    {
                        MessageManager.ShowError(Resource.Common_Error_Caption, result.Error.Message);
                        return;
                    }

                    Items = GetItemList();
                    lsbUnit.DataSource = Items;
                    try
                    {
                        lsbUnit.SelectedIndex = idx;
                    }
                    catch
                    {
                        lsbUnit.SelectedIndex = idx - 1;
                    }
                    if (Items.Count == 0)
                    {
                        txtUnitID.Clear();
                        txtVNName.Clear();
                        txtENName.Clear();
                        txtSEQ.Clear();
                        ckbEnable.Checked = true;
                    }
                }
            }
        }

    }

#if DEBUG
    public class frmUnit_Design : ListForm<Unit> { }
#endif

}
