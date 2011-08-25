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

namespace BatDongSan.Admin
{
    public partial class ManageAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["super"] == null || Boolean.Parse(Session["super"].ToString()) != true)
                Response.Redirect("Login.aspx");

        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["admin"] == null || Session["super"] == null || Boolean.Parse(Session["super"].ToString()) != true)
                Response.Redirect("Login.aspx");
                
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
            GridView1.Visible = false;
            btnAdd.Visible = false;
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (Session["admin"] == null || Session["super"] == null || Boolean.Parse(Session["super"].ToString()) != true) 
                Response.Redirect("Login.aspx");
            if (e.CancelingEdit)
            {
                GridView1.Visible = true;
                btnAdd.Visible = true;
                DetailsView1.Visible = false;
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("ManageAdmin.aspx");
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (Session["admin"] == null || Session["super"] != null || Boolean.Parse(Session["super"].ToString()) != true)
                Response.Redirect("Login.aspx");
            BDSDataContext db = new BDSDataContext();
            var ad = db.Administrators.Where(c => c.UserName == e.Values["UserName"].ToString());
            if (ad.Count() > 0)
                e.Cancel = true;
        }

        protected void DetailsView1_ModeChanging1(object sender, DetailsViewModeEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            if (e.CancelingEdit)
            {
                DetailsView1.Visible = false;
                btnAdd.Visible = true;
                GridView1.Visible = true;
            }
        }
    }
}
