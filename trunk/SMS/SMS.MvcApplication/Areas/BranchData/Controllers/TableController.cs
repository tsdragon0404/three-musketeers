using System;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Storage;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Table)]
    [PageID(ConstPage.Data_Table)]
    public class TableController : AdminBranchBaseController<TableDto, ITableService>
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }

        #endregion

        public override ActionResult Index(string textSearch)
        {
            var areaListResult = AreaService.ListAllByBranch<LanguageAreaDto>(SmsCache.UserContext.CurrentBranchId);
            if(!areaListResult.Success || areaListResult.Data == null)
                return ErrorPage(areaListResult.Errors);

            ViewBag.ListArea = areaListResult.Data;
            return base.Index(textSearch);
        }
        
    }
}
