using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Castle.Core.Internal;
using SMS.Common;
using SMS.Common.CustomAttributes;
using SMS.Common.Enums;
using SMS.Common.Storage;
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

                var allowPages = new List<LanguagePageDto>();
                var pageMenus = new List<PageMenuDto>();

                if (SmsCache.UserContext == null || SmsCache.UserContext.UserID == 0)
                {
                    var allowPagesResult = PageService.GetPublicPages<LanguagePageDto>();
                    if (allowPagesResult.Success && allowPagesResult.Data != null)
                    {
                        allowPages = allowPagesResult.Data.ToList();

                        var pageMenusResult = PageMenuService.GetMenuByPageIds(allowPages.Select(x => x.ID).ToList());
                        if (pageMenusResult.Success && pageMenusResult.Data != null)
                            pageMenus = pageMenusResult.Data.ToList();
                    }
                }
                else
                {
                    var pageMenusResult = PageMenuService.GetMenuByPageIds(SmsCache.UserContext.AllowPageIDs);
                    if (pageMenusResult.Success && pageMenusResult.Data != null)
                    {
                        pageMenus = pageMenusResult.Data.ToList();

                        var allowPagesResult = PageService.GetPagesByIds<LanguagePageDto>(pageMenus.Select(x => x.PageID).ToList());
                        if (allowPagesResult.Success && allowPagesResult.Data != null)
                            allowPages = allowPagesResult.Data.ToList();
                    }
                }

                viewResult.ViewData.Add(Common.Constant.ConstKey.ViewData_AccessiblePagesForUser, allowPages);
                viewResult.ViewData.Add(Common.Constant.ConstKey.ViewData_PageMenu, pageMenus);

                if (attribute != null && allowPages.Any(x => x.ID == attribute.PageID))
                {
                    ViewBag.Title = allowPages.First(x => x.ID == attribute.PageID).Title;
                    ViewBag.Description = allowPages.First(x => x.ID == attribute.PageID).Description;
                }
            }
            if (SmsCache.UserContext != null)
                SmsCache.UserContext.LastAccess = DateTime.Now;

            base.OnActionExecuted(filterContext);
        }

        [HttpPost]
        public JsonResult ChangeLanguage(Language language)
        {
            CommonObjects.Language = language;
            return Json(JsonModel.Create(true));
        }

        [HttpPost]
        public JsonResult MultiEditPageLabel(PageLabelDto[] listLabels)
        {
            return Json(!SmsCache.UserContext.IsSystemAdmin
                            ? JsonModel.Create(false)
                            : JsonModel.Create(PageLabelService.Save(listLabels.ToList())));
        }

        [HttpPost]
        public JsonResult GetAllPageLabel(long pageID)
        {
            return Json(!SmsCache.UserContext.IsSystemAdmin
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
            return ErrorAjax(HttpStatusCode.InternalServerError, errorString);
        }

        protected JsonResult ErrorAjax(HttpStatusCode statusCode, string errorString)
        {
            return new SmsStatusCodeJsonResult(statusCode, errorString);
        }
    }
}