using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_About)]
    [PageID(ConstPage.System_About)]
    public class AboutController : AdminBaseController<CurrencyDto, long, ICurrencyService>
    {
        #region Fields

        #endregion
    }
}
