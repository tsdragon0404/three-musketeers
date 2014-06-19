using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using SMS.Common;
using SMS.Services;

namespace SMS.MvcApplication.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        public virtual IProductService ProductService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductService = ServiceLocator.Resolve<IProductService>();

                SsrsViewer.Visible = true;
                SsrsViewer.LocalReport.ReportPath = string.Format(@"Reports\{0}.rdlc", "rptProductList");

                //IAreaService areaService = new AreaService();
                //SqlCommand cmd = new SqlCommand();

                //cmd.Parameters.Add(new SqlParameter("@StartDate", startDate));
                //cmd.Parameters.Add(new SqlParameter("@EndDate", endDate));

                //thisConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                //SqlConnection thisConnection = new SqlConnection(thisConnectionString);

                //cmd.Connection = thisConnection;

                //cmd.CommandText = string.Format("GET_{0}", rptName);
                //cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataAdapter da = new SqlDataAdapter(cmd);

                //System.Data.DataSet thisDataSet = new System.Data.DataSet();

                ///* Put the stored procedure result into a dataset */
                //da.Fill(thisDataSet);

                /* Associate thisDataSet  (now loaded with the stored 
               procedure result) with the  ReportViewer datasource */
                var datasource = new ReportDataSource("ds_Product", ProductService.GetAll().Data);

                SsrsViewer.LocalReport.DataSources.Clear();
                SsrsViewer.LocalReport.DataSources.Add(datasource);
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