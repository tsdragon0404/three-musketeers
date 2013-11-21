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
    public partial class frmProductCategory

#if DEBUG
 : frmProductCategory_Design
#else
    : ListForm<ProductCategory>
#endif

    {
        #region Public properties

        public IProductCategoryCoreService ProductCategoryCoreService{ get; set; }

        #endregion

        #region Constructor(s)

        public frmProductCategory()
        {
            InitializeComponent();
        }

        #endregion

        #region Override methods

        protected override IList<ProductCategory> GetItemList()
        {
            var result = ProductCategoryCoreService.GetAllProductCategory();
            if (result.Error != null && result.Error.Number != 0)
            {
                return base.GetItemList();
            }

            return result.Data;
        }

        #endregion

        private void frmProductCategory_Load(object sender, EventArgs e)
        {
            lsbProductCategory.DataSource = Items;
            lsbProductCategory.DisplayMember = "Name";
            lsbProductCategory.ValueMember = "ProductCategoryID";
            //lsbProductCategory.SelectedIndex = SelectedIndex;
        }

        private void lsbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = lsbProductCategory.SelectedIndex;
            if (productCategoryBindingSource.IsBindingSuspended)
                productCategoryBindingSource.ResumeBinding();
            productCategoryBindingSource.DataSource = SelectedItem;
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            productCategoryBindingSource.SuspendBinding();
            lsbProductCategory.Enabled = false;
            btnCreateNew.Enabled = false;
            btnDelete.Enabled = false;
            txtVNName.Clear();
            txtENName.Clear();
            txtVNDescription.Clear();
            txtENDescription.Clear();
            txtSEQ.Clear();
            ckbEnable.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var productCategory = new ProductCategory()
            {
                ProductCategoryID = txtProductCategoryID.Text.Trim() == "" ? 0 : int.Parse(txtProductCategoryID.Text),
                VNName = txtVNName.Text.Trim(),
                ENName = txtENName.Text.Trim(),
                VNDescription = txtVNDescription.Text.Trim(),
                ENDescription = txtENDescription.Text.Trim(),
                SEQ = int.Parse(txtSEQ.Text.Trim()),
                Enable = ckbEnable.Checked
            };
            var result = ProductCategoryCoreService.SaveProductCategory(productCategory);
            if (result.Error != null && result.Error.Number != 0)
            {
                MessageBox.Show(result.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var productCategoryID = result.Data;

            Items = GetItemList();
            lsbProductCategory.DataSource = Items;

            SelectedItem = Items.FirstOrDefault(b => b.ProductCategoryID == productCategoryID);

            lsbProductCategory.Enabled = true;
            lsbProductCategory.SelectedIndex = SelectedIndex;
            btnCreateNew.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lsbProductCategory.Enabled = true;
            productCategoryBindingSource.ResumeBinding();
            lsbProductCategory.SelectedIndex = SelectedIndex;
            btnCreateNew.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idx = SelectedIndex;
                var result = ProductCategoryCoreService.DeleteProductCategory(int.Parse(txtProductCategoryID.Text));
                if (result.Error != null && result.Error.Number != 0)
                {
                    MessageBox.Show(result.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Items = GetItemList();
                lsbProductCategory.DataSource = Items;
                try
                {
                    lsbProductCategory.SelectedIndex = idx;
                }
                catch
                {
                    lsbProductCategory.SelectedIndex = idx - 1;
                }
            }
        }

        
    }

#if DEBUG
    public class frmProductCategory_Design : ListForm<ProductCategory> { }
#endif

}
