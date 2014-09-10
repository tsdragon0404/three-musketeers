using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.Branch_GlobalLabel)]
    [PageID(ConstPage.Branch_GlobalLabel)]
    public class GlobalLabelController : BaseController
    {
        public ActionResult Index()
        {
            var globalLabel = PageLabelService.GetByPageID<PageLabelDto>(ConstPage.Global);
            var result = new GlobalLabelModel { PageLabels = globalLabel.Data };
            return View(result);
        }

        [HttpPost]
        public JsonResult Save()
        {
            return new JsonResult();
        }
    }
}
