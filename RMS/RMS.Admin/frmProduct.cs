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

        #region Private methods

        private IList<Unit> GetAllUnit()
        {
            var result = UnitCoreService.GetAllUnit();
            if (result.Error != null && result.Error.Number != 0)
            {
                //return base.GetItemList();
            }

            return result.Data;
        }

        #endregion
    }

#if DEBUG
    public class frmProduct_Design : ListForm<Product> { }
#endif

}
