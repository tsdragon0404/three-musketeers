﻿using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Area)]
    [PageID(ConstPage.Data_Area)]
    public class AreaController : AdminBranchBaseController<AreaDto, IAreaService>
    {
        #region Fields

        #endregion
    }
}
