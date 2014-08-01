﻿using System.Web.Mvc;
using SMS.Common.Paging;
using SMS.Common.Session;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class AdminBranchBaseController<TDto, TPrimaryKey, TIService> : AdminBaseController<TDto, TPrimaryKey, TIService>
        where TIService : IBaseService<TDto, TPrimaryKey>
        where TDto : new()
    {
        [HttpGet]
        public override ActionResult Index(string textSearch, int page = 1)
        {
            var pagingInfo = new SortingPagingInfo
                             {
                                 CurrentPage = page, 
                                 TextSearch = textSearch,
                                 FormNameToSubmit = Url.Action("Index")
                             };
            var model = new AdminModel<TDto>
            {
                ListRecord = Service.SearchByBranch(textSearch, pagingInfo, SmsSystem.SelectedBranchID, true).Data,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        [HttpPost]
        public override JsonResult GetDataForEdit(TPrimaryKey recordID)
        {
            return Json(JsonModel.Create(Service.GetByIDForCurrentBranch(recordID)));
        }

        [HttpPost]
        public override JsonResult DeleteData(TPrimaryKey recordID)
        {
            return Json(JsonModel.Create(Service.DeleteInCurrentBranch(recordID)));
        }
    }
}