using System.Collections.Generic;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Mail;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services.Inventory;

namespace SMS.MvcApplication.Controllers
{
    public class HomeController : BaseController
    {
        public virtual IReceiptNoteService ReceiptNoteService { get; set; }

        [SmsAuthorize(ConstPage.HomePage)]
        [PageID(ConstPage.HomePage)]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //var temp = ReceiptNoteService.ListAll();
            return View();
        }

        [HttpPost]
        public JsonResult TestSendMail()
        {
            var mail = new SmtpMail
                           {
                               From = "test@gmail.com",
                               To = new List<string>
                                        {
                                            "tsdragon0404@gmail.com"
                                        },
                               Body = "test email",
                               Subject = "test email from SMS"
                           };
            return Json(JsonModel.Create(mail.Send()));
        }
    }
}
