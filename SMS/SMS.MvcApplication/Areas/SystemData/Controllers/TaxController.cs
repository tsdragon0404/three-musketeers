using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.SystemData.Controllers
{
    [SmsAuthorize(ConstPage.System_Tax)]
    [PageID(ConstPage.System_Tax)]
    public class TaxController : AdminBaseController<TaxDto, ITaxService>
    {
        #region Fields

        #endregion
    }
}
