using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Product)]
    [PageID(ConstPage.Data_Product)]
    public class ProductController : AdminBaseController<ProductDto, long, IProductService>
    {
        #region Fields

        #endregion
    }
}
