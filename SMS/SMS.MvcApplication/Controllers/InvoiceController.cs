using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;
using SMS.Services;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace SMS.MvcApplication.Controllers
{
    [SmsAuthorize(ConstPage.Invoice)]
    [PageID(ConstPage.Invoice)]
    public class InvoiceController : BaseController
    {
        public virtual IInvoiceService InvoiceService { get; set; }

        public ActionResult Index([CustomFormatDateTime("dd-MM-yyyy")]DateTime? fromDate,
                                  [CustomFormatDateTime("dd-MM-yyyy")]DateTime? toDate, 
                                  int? minAmount, int? maxAmount, string customerName)
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

    public class CustomFormatDateTimeAttribute : CustomModelBinderAttribute
    {
        private IModelBinder _binder;

        public CustomFormatDateTimeAttribute(string format)
        {
            _binder = new CustomFormatDateTimeModelBinder(format);
        }

        public override IModelBinder GetBinder() { return _binder; }
    }

    public class CustomFormatDateTimeModelBinder : IModelBinder
    {
        public string CustomFormat { get; private set; }

        public CustomFormatDateTimeModelBinder(string customFormat)
        {
            CustomFormat = customFormat;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null || string.IsNullOrEmpty(value.AttemptedValue))
                return null;

            return DateTime.ParseExact(value.AttemptedValue, CustomFormat, CultureInfo.InvariantCulture);
        }
    }
}