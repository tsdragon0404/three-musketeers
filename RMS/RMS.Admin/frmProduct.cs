using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using TM.UI.WindowsForms;
using TM.UI.WindowsForms.Utilities;
using TM.Utilities;
using System;
using RMS.Resources;

namespace RMS.Admin
{
    [FunctionId(GlobalConstants.FunctionIds.FormProduct)]
    public partial class frmProduct

#if DEBUG
 : frmProduct_Design
#else
    : ListForm<Product>
#endif

    {
        #region IOC properties

        public IProductCoreService ProductCoreService { get; set; }

        public IProductCategoryCoreService ProductCategoryCoreService { get; set; }

        public IUnitCoreService UnitCoreService { get; set; }

        public UserContext UserContext { get; set; }

        #endregion

        #region Public properties

        public IList<ProductCategory> ListProductCategory { get; set; }
        public IList<Unit> ListUnit { get; set; }

        #endregion

        #region Constructor(s)

        public frmProduct()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
        }

        #endregion

        #region Override methods

        protected override IList<Product> GetItemList()
        {
            var result = ProductCoreService.GetAllProduct();
            return HasError(result.Error) ? base.GetItemList() : result.Data;
        }

        #endregion

        #region Private methods

        private IList<Unit> GetAllUnit()
        {
            var result = UnitCoreService.GetAllUnit();
            return HasError(result.Error) ? ListUnit : result.Data;
        }

        private IList<ProductCategory> GetAllProductCategory()
        {
            var result = ProductCategoryCoreService.GetAllProductCategory();
            return HasError(result.Error) ? ListProductCategory : result.Data;
        }

        private bool ValidationForm()
        {
            if (!CommonValidation.ValidateEmptyTextBox(txtVNName))
            {
                MessageManager.ShowWarning(Resource.Common_Warning_Caption, Resource.Common_TextBoxEmpty_Message);
                txtVNName.Focus();
                return false;
            }
            if (!CommonValidation.ValidateEmptyTextBox(txtENName))
            {
                MessageManager.ShowWarning(Resource.Common_Warning_Caption, Resource.Common_TextBoxEmpty_Message);
                txtENName.Focus();
                return false;
            }

            return true;
        }

        #endregion

        private void frmProduct_Load(object sender, System.EventArgs e)
        {
            ListProductCategory = GetAllProductCategory();
            cmbProductCategory.DataSource = ListProductCategory;
            cmbProductCategory.DisplayMember = "Name";
            cmbProductCategory.ValueMember = "ProductCategoryID";

            ListUnit = GetAllUnit();
            cmbUnit.DataSource = ListUnit;
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitID";

            lsbProduct.DataSource = Items;
            lsbProduct.DisplayMember = "Name";
        }

        private void lsbProduct_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SelectedIndex = lsbProduct.SelectedIndex;
            if (productBindingSource.IsBindingSuspended)
                productBindingSource.ResumeBinding();
            productBindingSource.DataSource = SelectedItem;
        }

        private void btnCreateNew_Click(object sender, System.EventArgs e)
        {
            productBindingSource.SuspendBinding();
            lsbProduct.Enabled = false;
            btnCreateNew.Enabled = false;
            btnDelete.Enabled = false;
            txtProductID.Clear();
            txtVNName.Clear();
            txtENName.Clear();
            txtVNDescription.Clear();
            txtENDescription.Clear();
            txtSEQ.Clear();
            ckbEnable.Checked = true;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidationForm())
                return; ;

            var product = new Product()
                              {
                                  ProductID = txtProductID.Text.Trim() == "" ? 0 : int.Parse(txtProductID.Text.Trim()),
                                  VNName = txtVNName.Text.Trim(),
                                  ENName = txtENName.Text.Trim(),
                                  VNDescription = txtVNDescription.Text.Trim(),
                                  ENDescription = txtENDescription.Text.Trim(),
                                  UnitID = Byte.Parse(cmbUnit.SelectedValue.ToString()),
                                  ProductCategoryID = int.Parse(cmbProductCategory.SelectedValue.ToString()),
                                  Enable = ckbEnable.Checked,
                                  SEQ = txtSEQ.Text.Trim() == "" ? 0 : Int32.Parse(txtSEQ.Text.Trim())
                              };
            var result = ProductCoreService.SaveProduct(product);
            if (result.Error != null && result.Error.Number != 0)
            {
                MessageManager.ShowError("Error", result.Error.Message);
                return;
            }
            var productID = result.Data;

            Items = GetItemList();
            lsbProduct.DataSource = Items;

            SelectedItem = Items.FirstOrDefault(b => b.ProductID == productID);

            lsbProduct.Enabled = true;
            try
            {
                lsbProduct.SelectedIndex = SelectedIndex;
            }
            catch
            {
                lsbProduct.SelectedIndex = SelectedIndex - 1;
            }
            btnCreateNew.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            lsbProduct.Enabled = true;
            productBindingSource.ResumeBinding();
            btnCreateNew.Enabled = true;
            btnDelete.Enabled = true;

            if (Items.Count != 0)
            {
                lsbProduct.SelectedIndex = SelectedIndex;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (txtProductID.Text.Trim() != "")
            {
                if ( MessageManager.ShowQuestion(Resource.Common_Question_Caption, Resource.Common_Delete_Message) == DialogResult.Yes )
                {
                    int idx = SelectedIndex;
                    var result = ProductCoreService.DeleteProduct(int.Parse(txtProductID.Text));
                    if (result.Error != null && result.Error.Number != 0)
                    {
                        MessageManager.ShowError(Resource.Common_Error_Caption, result.Error.Message);
                        return;
                    }

                    Items = GetItemList();
                    lsbProduct.DataSource = Items;
                    try
                    {
                        lsbProduct.SelectedIndex = idx;
                    }
                    catch
                    {
                        lsbProduct.SelectedIndex = idx - 1;
                    }

                    if (Items.Count == 0)
                    {
                        txtProductID.Clear();
                        txtVNName.Clear();
                        txtENName.Clear();
                        txtVNDescription.Clear();
                        txtENDescription.Clear();
                        txtSEQ.Clear();
                        ckbEnable.Checked = true;
                    }
                }
            }
        }
    }

#if DEBUG
    public class frmProduct_Design : ListForm<Product> { }
#endif

}
