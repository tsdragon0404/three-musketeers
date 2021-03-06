﻿using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.Branch_Role)]
    [PageID(ConstPage.Branch_Role)]
    public class RoleController : AdminBranchBaseController<RoleDto, IRoleService>
    {
        #region Fields

        #endregion

        public override ActionResult Index()
        {
            var pageListResult = PageService.GetProtectedPages<LanguagePageDto>();
            if (!pageListResult.Success || pageListResult.Data == null)
                return ErrorPage(pageListResult.Errors);

            ViewBag.ListPage = pageListResult.Data;
            return base.Index();
        }
        
    }
}
