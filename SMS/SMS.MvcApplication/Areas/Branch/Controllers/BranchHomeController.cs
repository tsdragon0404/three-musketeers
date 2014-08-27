﻿using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.Branch_Home)]
    [PageID(ConstPage.Branch_Home)]
    public class BranchHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}