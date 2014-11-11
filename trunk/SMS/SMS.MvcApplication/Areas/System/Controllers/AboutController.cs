using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Enums;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_About)]
    [PageID(ConstPage.System_About)]
    public class AboutController : AdminBaseController<SystemInformationDto, ISystemInformationService>
    {
        #region Fields

        public virtual ISystemInformationService SystemInformationService { get; set; }

        #endregion

        [HttpGet]
        public override ActionResult Index(string textSearch, int page = 1)
        {
            var recordList = SystemInformationService.GetByType(SystemInformationType.Information);

            var model = new SystemInformationModel { SystemInformationDtos = recordList.Data };

            return View(model);
        }
    }
}
