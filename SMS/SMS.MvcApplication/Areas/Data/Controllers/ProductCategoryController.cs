using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Data.Controllers
{
    [SmsAuthorize]
    public class ProductCategoryController : AdminBaseController<ProductCategoryDto, long, IProductCategoryService>
    {
        #region Fields

        #endregion
    }
}
