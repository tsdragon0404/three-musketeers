using System.Linq;
using System.Text;
using System.Web.Mvc;
using Core.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Filters;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class BaseController : Controller
    {
        public virtual IPageLabelService PageLabelService { get; set; }

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
            var attribute = filterContext.ActionDescriptor.GetFilterAttributes(false).FirstOrDefault();
            if(attribute != null && (attribute as GetLabelAttribute) != null)
            {
                var pageID = (attribute as GetLabelAttribute).PageID;
                var viewResult = filterContext.Result as ViewResult;
                if (viewResult != null)
                {
                    var labelDictionary = PageLabelService.GetByPageID<LanguagePageLabelDto>(pageID).ToDictionary(x => x.LabelID, x => x.Text);
                    viewResult.ViewData.Add(Common.Constant.ConstConfig.PageLabelKey, labelDictionary);
                    viewResult.ViewData.Add(Common.Constant.ConstConfig.PageIDKey, pageID);
                }
            }

            base.OnActionExecuted(filterContext);
        }

        [HttpPost]
        public JsonResult EditPageLabel(int pageID, string labelID, string text)
        {
            return Json(!UserContext.IsSuperAdmin 
                ? new JsonModel { Success = false } 
                : new JsonModel { Success = PageLabelService.Save(pageID, labelID, text) });
        }

        [HttpPost]
        public JsonResult ChangeLanguage(Language language)
        {
            UserContext.Language = language;
            return Json(new JsonModel());
        }

        [HttpPost]
        public JsonResult MultiEditPageLabel(int pageID, PageLabelDto[] listLabels)
        {
            return Json(!UserContext.IsSuperAdmin 
                ? new JsonModel { Success = false } 
                : new JsonModel { Success = PageLabelService.Save(pageID, listLabels.ToList()) });
        }

        [HttpPost]
        public JsonResult GetAllPageLabel(int pageID)
        {
            return Json(!UserContext.IsSuperAdmin 
                ? new JsonModel { Success = false } 
                : new JsonModel { Data = PageLabelService.GetByPageID<PageLabelDto>(pageID) });
        }
    }
}