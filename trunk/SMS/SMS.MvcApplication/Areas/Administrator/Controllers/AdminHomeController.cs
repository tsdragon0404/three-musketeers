using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Administrator/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
