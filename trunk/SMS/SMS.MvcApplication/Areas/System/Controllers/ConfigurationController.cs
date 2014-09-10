using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_Configuration)]
    [PageID(ConstPage.System_Configuration)]
    public class ConfigurationController : AdminBaseController<CurrencyDto, long, ICurrencyService>
    {
        #region Fields

        #endregion

        [HttpPost]
        public JsonResult ResetSystemData()
        {
            if (!SmsSystem.UserContext.IsSystemAdmin)
                return Json(JsonModel.Create(false));

            Utility.SetStorageData();
            return Json(JsonModel.Create(true));
        }
    }
}
