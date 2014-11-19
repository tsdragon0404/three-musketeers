using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_Configuration)]
    [PageID(ConstPage.System_Configuration)]
    public class ConfigurationController : AdminBaseController<SystemInformationDto, ISystemInformationService>
    {
        #region Fields

        public virtual ISystemInformationService SystemInformationService { get; set; }

        #endregion

        [HttpGet]
        public override ActionResult Index(string textSearch, int page = 1)
        {
            var recordList = SystemInformationService.GetByType(SystemInformationType.Config);

            var model = new SystemInformationModel {SystemInformationDtos = recordList.Data};

            return View(model);
        }

        [HttpPost]
        public JsonResult ResetSystemData()
        {
            if (!SmsCache.UserContext.IsSystemAdmin)
                return Json(JsonModel.Create(false));

            SmsCache.ClearCache();
            return Json(JsonModel.Create(true));
        }

        [HttpPost]
        public JsonResult UpdateSystemConfig(SystemInformationDto[] systemInformations)
        {
            var result = SystemInformationService.UpdateSystemConfig(systemInformations);
            return Json(JsonModel.Create(result));
        }
    }
}
