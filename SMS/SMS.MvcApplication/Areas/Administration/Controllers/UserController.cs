﻿using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    [SmsAuthorize]
    public class UserController : AdminBaseController<UserDto, long, IUserService>
    {
        #region Fields

        public virtual IRoleService RoleService { get; set; }

        #endregion

        public override System.Web.Mvc.ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListRole = RoleService.GetAll().Data;
            return base.Index(textSearch, page);
        }
        
    }
}
