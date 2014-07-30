using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Product)]
    [PageID(ConstPage.Data_Product)]
    public class ProductController : AdminBranchBaseController<ProductDto, long, IProductService>
    {
        #region Fields

        public virtual IProductCategoryService ProductCategoryService { get; set; }
        public virtual IUnitService UnitService { get; set; }

        #endregion

        public override ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListCategory = ProductCategoryService.GetAllByBranch<LanguageProductCategoryDto>(SmsSystem.SelectedBranchID).Data;
            ViewBag.ListUnit = UnitService.GetAllByBranch<LanguageUnitDto>(SmsSystem.SelectedBranchID).Data;
            return base.Index(textSearch, page);
        }
    }
}
