﻿using System.Web.Mvc;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
    }
}