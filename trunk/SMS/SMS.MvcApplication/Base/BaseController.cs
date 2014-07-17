using System.Linq;
using System.Text;
using System.Web.Mvc;
using SMS.Common.CustomAttributes;
using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class BaseController : Controller
    {
        public virtual IPageLabelService PageLabelService { get; set; }
        public virtual IPageService PageService { get; set; }
        public virtual IPageMenuService PageMenuService { get; set; }

        protected override JsonResult Json(object data, string contentType,
            Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {

                var attribute = filterContext.ActionDescriptor.GetCustomAttributes(typeof (PageIDAttribute), false).FirstOrDefault();
                if (attribute != null && (attribute as PageIDAttribute) != null)
                {
                    var pageID = (attribute as PageIDAttribute).PageID;
                    var labelDictionary = PageLabelService.GetByPageID<LanguagePageLabelDto>(pageID, true).Data.ToDictionary(x => x.LabelID, x => x.Text);

                    viewResult.ViewData.Add(Common.Constant.ConstConfig.PageLabelKey, labelDictionary);
                    viewResult.ViewData.Add(Common.Constant.ConstConfig.PageIDKey, pageID);
                }

                var allowPages = PageService.GetAccessiblePagesForUser<LanguagePageDto>().Data.ToList();
                viewResult.ViewData.Add(Common.Constant.ConstConfig.AccessiblePagesForUserKey, allowPages);

                var pageMenus = PageMenuService.GetMenuByPageIds(allowPages.Select(x => x.ID).ToList()).Data;
                viewResult.ViewData.Add(Common.Constant.ConstConfig.PageMenuKey, pageMenus);
            }
            base.OnActionExecuted(filterContext);
        }

        [HttpPost]
        public JsonResult ChangeLanguage(Language language)
        {
            SmsSystem.Language = language;
            return Json(JsonModel.Create(true));
        }

        [HttpPost]
        public JsonResult MultiEditPageLabel(long pageID, PageLabelDto[] listLabels)
        {
            return Json(!SmsSystem.UserContext.IsSystemAdmin
                            ? JsonModel.Create(false)
                            : JsonModel.Create(PageLabelService.Save(pageID, listLabels.ToList())));
        }

        [HttpPost]
        public JsonResult GetAllPageLabel(long pageID)
        {
            return Json(!SmsSystem.UserContext.IsSystemAdmin
                            ? JsonModel.Create(false)
                            : JsonModel.Create(PageLabelService.GetByPageID<PageLabelDto>(pageID)));
        }

        [HttpPost]
        public JsonResult ChangeBranch(long branchID)
        {
            if (!SmsSystem.UserContext.AllowBranches.Select(x => x.ID).Contains(branchID))
                return Json(JsonModel.Create(false));

            SmsSystem.SelectedBranchID = branchID;
            return Json(JsonModel.Create(true));
        }
    }
}