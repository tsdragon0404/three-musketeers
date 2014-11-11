using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_ProductCategory)]
    [PageID(ConstPage.Data_ProductCategory)]
    public class ProductCategoryController : AdminBranchBaseController<ProductCategoryDto, long, IProductCategoryService>
    {
        #region Fields

        #endregion
    }
}
