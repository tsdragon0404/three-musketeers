using System;
using System.Data;
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
                reportService = ServiceLocator.Resolve<IReportService>();
                var reportDatasources = reportService.LoadReportDatasources("test");

                if(!reportDatasources.Success)
                {
                    // handle errors
                    return;
                }

                SsrsViewer.Visible = true;
                SsrsViewer.LocalReport.ReportPath = string.Format(@"Reports\{0}.rdlc", "test");
                SsrsViewer.LocalReport.DataSources.Clear();

                foreach (DataTable table in reportDatasources.Data.Tables)
                {
                    var datasource = new ReportDataSource(table.TableName, table);
                    SsrsViewer.LocalReport.DataSources.Add(datasource);
                }

                //List lst = new List();
                //ReportParameter rptParam1 = new ReportParameter("StartDate", startDate.ToShortDateString());
                //ReportParameter rptParam2 = new ReportParameter("EndDate", endDate.ToShortDateString());

                //ReportParameter rptParam3 = new ReportParameter("LOBCode", lobCode);
                //lst.Add(rptParam3);
                //ReportViewer1.LocalReport.SetParameters(lst);


                SsrsViewer.LocalReport.Refresh();
            }
        }
    }
}