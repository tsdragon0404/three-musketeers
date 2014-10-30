using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.SystemData.Controllers
{
    [SmsAuthorize(ConstPage.System_Currency)]
    [PageID(ConstPage.System_Currency)]
    public class CurrencyController : AdminBaseController<CurrencyDto, ICurrencyService>
    {
        #region Fields

        #endregion
    }
}
