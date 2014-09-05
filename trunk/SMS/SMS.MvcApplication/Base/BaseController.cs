using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Castle.Core.Internal;
using SMS.Common.CustomAttributes;
using SMS.Common.Session;
using SMS.Common.UserAccess;
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

                var attribute = filterContext.ActionDescriptor.GetAttribute<PageIDAttribute>() ??
                                filterContext.ActionDescriptor.ControllerDescriptor.GetAttribute<PageIDAttribute>();

                if (attribute != null)
                {
                    var pageLabelResult = PageLabelService.GetByPageID<LanguagePageLabelDto>(attribute.PageID, true);
                    if(pageLabelResult.Success && pageLabelResult.Data != null)
                    {
                        var labelDictionary = pageLabelResult.Data.ToDictionary(x => x.LabelID, x => x.Text);

                        viewResult.ViewData.Add(Common.Constant.ConstKey.ViewData_PageLabel, labelDictionary);
                        viewResult.ViewData.Add(Common.Constant.ConstKey.ViewData_PageID, attribute.PageID);
                    }
                }

                var allowPagesResult = PageService.GetAccessiblePagesForUser<LanguagePageDto>();
                if (allowPagesResult.Success && allowPagesResult.Data != null)
                {
                    viewResult.ViewData.Add(Common.Constant.ConstKey.ViewData_AccessiblePagesForUser, allowPagesResult.Data);

                    var pageMenusResult = PageMenuService.GetMenuByPageIds(allowPagesResult.Data.Select(x => x.ID).ToList());
                    if (pageMenusResult.Success && pageMenusResult.Data != null)
                        viewResult.ViewData.Add(Common.Constant.ConstKey.ViewData_PageMenu, pageMenusResult.Data);
                }
            }

            UserAccessManager.UpdateCurrentUserLastAccess();

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

        protected ActionResult ErrorPage(IList<Core.Common.Validation.Error> errors)
        {
            TempData["Error"] = errors;
            return RedirectToAction("Index", "Error", new {area = ""});
        }

        protected JsonResult ErrorAjax(string errorString)
        {
            return new SmsStatusCodeJsonResult(HttpStatusCode.InternalServerError, errorString);
        }

        protected JsonResult ErrorAjax(HttpStatusCode statusCode, string errorString)
        {
            return new SmsStatusCodeJsonResult(statusCode, errorString);
        }
    }
}