using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;
using SMS.Services;
using System;
using System.Web.Mvc;

namespace SMS.MvcApplication.Controllers
{
    [SmsAuthorize(ConstPage.Invoice)]
    [PageID(ConstPage.Invoice)]
    public class InvoiceController : BaseController
    {
        public virtual IInvoiceService InvoiceService { get; set; }

        public ActionResult Index(DateTime? fromDate, DateTime? toDate, int? minAmount, int? maxAmount, string customerName)
        {
            ViewBag.FromDate = fromDate.HasValue ? fromDate.Value.ToString("dd-MM-yyyy") : null;
            ViewBag.ToDate = toDate.HasValue ? toDate.Value.ToString("dd-MM-yyyy") : null;
            ViewBag.MinAmount = minAmount;
            ViewBag.MaxAmount = maxAmount;
            ViewBag.CustomerName = customerName;

            var list = InvoiceService.SearchInvoice(fromDate, toDate, minAmount, maxAmount, customerName);
            return View(list);
        }
    }
}