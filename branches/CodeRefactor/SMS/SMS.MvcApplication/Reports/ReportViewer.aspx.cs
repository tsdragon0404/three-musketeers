using System;
using System.Data;
using System.Linq;
using Microsoft.Reporting.WebForms;
using SMS.Common;
using SMS.Services;

namespace SMS.MvcApplication.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        private IReportService reportService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString[Common.Constant.ConstReport.ReportKey]))
                {
                    // handle errors
                    return;
                }

                var reportName = Request.QueryString[Common.Constant.ConstReport.ReportKey];

                reportService = ServiceLocator.Resolve<IReportService>();

                var queryString = Request.QueryString.Cast<string>()
                    .Where(x => x.Contains(Common.Constant.ConstReport.DatasourceParamPrefix))
                    .ToDictionary(x => x.Replace(Common.Constant.ConstReport.DatasourceParamPrefix, ""), y => Request.QueryString[y]);

                //var reportDatasources = reportService.LoadReportDatasources(reportName, queryString);

                //if(!reportDatasources.Success)
                //{
                //    // handle errors
                //    return;
                //}

                SsrsViewer.Visible = true;
                SsrsViewer.ProcessingMode = ProcessingMode.Local;
                SsrsViewer.LocalReport.ReportPath = string.Format(Common.Constant.ConstReport.ReportPathTemplate, reportName);

                foreach (var param in Request.QueryString.Cast<string>().Where(x => x.Contains(Common.Constant.ConstReport.ReportParamPrefix)))
                {
                    var reportParam = param.Replace(Common.Constant.ConstReport.ReportParamPrefix, "");
                    SsrsViewer.LocalReport.SetParameters(new ReportParameter(reportParam, Request.QueryString[param]));
                }

                SsrsViewer.LocalReport.DataSources.Clear();

                //foreach (DataTable table in reportDatasources.Data.Tables)
                //    SsrsViewer.LocalReport.DataSources.Add(new ReportDataSource(table.TableName, table));

                SsrsViewer.LocalReport.Refresh();
            }
        }
    }
}