using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Storage;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Product)]
    [PageID(ConstPage.Data_Product)]
    public class ProductController : AdminBranchBaseController<ProductDto, IProductService>
    {
        #region Fields

        public virtual IProductCategoryService ProductCategoryService { get; set; }
        public virtual IUnitService UnitService { get; set; }

        #endregion

        public override ActionResult Index()
        {
            var categoryListResult = ProductCategoryService.ListAllByBranch<LanguageProductCategoryDto>(SmsCache.UserContext.CurrentBranchId);
            if (!categoryListResult.Success || categoryListResult.Data == null)
                return ErrorPage(categoryListResult.Errors);

            var unitListResult = UnitService.ListAllByBranch<LanguageUnitDto>(SmsCache.UserContext.CurrentBranchId);
            if (!unitListResult.Success || unitListResult.Data == null)
                return ErrorPage(unitListResult.Errors);

            ViewBag.ListCategory = categoryListResult.Data;
            ViewBag.ListUnit = unitListResult.Data;
            return base.Index();
        }
    }
}
