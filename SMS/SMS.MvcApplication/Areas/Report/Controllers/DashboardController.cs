using System;
using System.Data;
using System.Web.Mvc;
using System.Collections.Generic;
using Core.Common;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Report.Controllers
{
    public class DashboardController : BaseController
    {
        #region Fields

        public virtual IReportService ReportService { get; set; }

        #endregion

        [SmsAuthorize(ConstPage.Report_Dashboard)]
        [PageID(ConstPage.Report_Dashboard)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetReportData(string spName, DateTime fromDate, DateTime toDate)
        {
            var param = new List<SpParameter>
                             {
                                 new SpParameter {Name = "I_vFromDate", Value = fromDate},
                                 new SpParameter {Name = "I_vToDate", Value = toDate}
                             };
            DataTable result = ReportService.ExecuteStoredProcedure(spName, param);
            return Json(JsonModel.Create(result));
        }
    }
}
