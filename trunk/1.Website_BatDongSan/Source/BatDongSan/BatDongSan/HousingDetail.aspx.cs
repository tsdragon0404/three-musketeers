using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace BatDongSan
{
    public partial class HousingDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["key"] == null)
            {
                if (Request.QueryString["view"] == "house")
                {
                    datalisthouse.Visible = true;
                    datalistagri.Visible = false;
                    datalistproject.Visible = false;
                    DataList1.Visible = false;
                    DataList3.Visible = false;

                }
                else if (Request.QueryString["view"] == "agri")
                {
                    datalistagri.Visible = true;
                    datalistproject.Visible = false;
                    datalisthouse.Visible = false;
                    DataList1.Visible = false;
                    DataList3.Visible = false;
                }
                else if (Request.QueryString["view"] == "project")
                {
                    datalistproject.Visible = true;
                    datalisthouse.Visible = false;
                    datalistagri.Visible = false;
                    DataList1.Visible = false;
                    DataList3.Visible = false;
                }
                else
                    Response.Redirect("Housing.aspx");
            }
            else
            {
                if (Request.QueryString["view"] == "house")
                {
                    datalisthouse.Visible = true;
                    datalistagri.Visible = false;
                    datalistproject.Visible = false;
                    DataList1.Visible = true;
                    DataList3.Visible = false;

                }
                else if (Request.QueryString["view"] == "agri")
                {
                    datalistagri.Visible = true;
                    datalistproject.Visible = false;
                    datalisthouse.Visible = false;
                    DataList1.Visible = true;
                    DataList3.Visible = false;
                }
                else if (Request.QueryString["view"] == "project")
                {
                    datalistproject.Visible = true;
                    datalisthouse.Visible = false;
                    datalistagri.Visible = false;
                    DataList1.Visible = false;
                    DataList3.Visible = true;
                }
                else
                    Response.Redirect("Housing.aspx");
            }    
        }

        protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            if (Request.QueryString["key"] == null)
                e.Result = db.Houses.Where(c => c.IsValid == true && c.Agri == false).OrderByDescending(c => c.ID).Take(20);
            else
                e.Result = db.Houses.Where(c => c.IsValid == true && c.Agri == false && c.ID != Int64.Parse(Request.QueryString["key"].ToString())).OrderByDescending(c => c.ID).Take(5);
        }

        protected void LinqDataSource3_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            if (Request.QueryString["key"] == null)
                e.Result = db.Houses.Where(c => c.IsValid == true && c.Agri == true).OrderByDescending(c => c.ID).Take(20);
            else
                e.Result = db.Houses.Where(c => c.IsValid == true && c.Agri == true && c.ID != Int64.Parse(Request.QueryString["key"].ToString())).OrderByDescending(c => c.ID).Take(5);
        }

        protected void LinqDataSource4_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            if (Request.QueryString["key"] == null)
                e.Result = db.Projects.Where(c => c.IsValid == true).OrderByDescending(c => c.ID).Take(20);
            else
                e.Result = db.Projects.Where(c => c.IsValid == true && c.ID != Int64.Parse(Request.QueryString["key"].ToString())).OrderByDescending(c => c.ID).Take(5);
        }
    }
}
