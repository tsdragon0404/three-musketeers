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

                var queryString = Request.QueryString.Cast<string>().ToDictionary(x => x, y => Request.QueryString[y]);
                var reportDatasources = reportService.LoadReportDatasources(reportName, queryString);

                if(!reportDatasources.Success)
                {
                    // handle errors
                    return;
                }

                SsrsViewer.Visible = true;
                SsrsViewer.LocalReport.ReportPath = string.Format(Common.Constant.ConstReport.ReportPathTemplate, reportName);
                SsrsViewer.LocalReport.DataSources.Clear();

                foreach (DataTable table in reportDatasources.Data.Tables)
                    SsrsViewer.LocalReport.DataSources.Add(new ReportDataSource(table.TableName, table));

                SsrsViewer.LocalReport.Refresh();
            }
        }
    }
}