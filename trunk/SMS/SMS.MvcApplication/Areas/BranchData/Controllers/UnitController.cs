using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Unit)]
    [PageID(ConstPage.Data_Unit)]
    public class UnitController : AdminBranchBaseController<UnitDto, IUnitService>
    {
        #region Fields

        #endregion
    }
}
