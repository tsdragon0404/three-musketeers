using System;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Table)]
    [PageID(ConstPage.Data_Table)]
    public class TableController : AdminBranchBaseController<TableDto, long, ITableService>
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }

        #endregion

        public override ActionResult Index(string textSearch, int page = 1)
        {
            var serviceResult = AreaService.GetAllByBranch<LanguageAreaDto>(SmsSystem.SelectedBranchID);
            if(!serviceResult.Success || serviceResult.Data == null)
            {
                //TODO: handle service error
                throw new Exception("ko lay dc du lieu khu vuc");
            }

            ViewBag.ListArea = serviceResult.Data;
            return base.Index(textSearch, page);
        }
        
    }
}
