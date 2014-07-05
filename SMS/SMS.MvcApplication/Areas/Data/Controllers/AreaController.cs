using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Data.Controllers
{
    [SmsAuthorize(ConstPage.Data_Area)]
    [PageID(ConstPage.Data_Area)]
    public class AreaController : AdminBaseController<AreaDto, long, IAreaService>
    {
        #region Fields

        #endregion
    }
}
