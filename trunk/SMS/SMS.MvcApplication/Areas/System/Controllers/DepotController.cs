using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_SetupDepot)]
    [PageID(ConstPage.System_SetupDepot)]
    public class DepotController : AdminBaseController<DepotDto, IDepotService>
    {
        #region Fields

        #endregion
    }
}
