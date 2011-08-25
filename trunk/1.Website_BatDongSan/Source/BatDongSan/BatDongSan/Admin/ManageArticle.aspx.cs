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
    public partial class ManageArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
            ImageButton3.Visible = false;
            GridView1.Visible = false;
            DropDownList1.Visible = false;
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            e.Values["PostDate"] = DateTime.Now;
            e.Values["LatestModifiedDate"] = DateTime.Now;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("ManageArticle.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            ImageButton3.Visible = false;
            GridView1.Visible = false;
            DropDownList1.Visible = false;
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            e.NewValues["LatestModifiedDate"] = DateTime.Now;
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("ManageArticle.aspx");
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            if (e.CancelingEdit)
            {
                DetailsView1.Visible = false;
                ImageButton3.Visible = true;
                DropDownList1.Visible = true;
                GridView1.Visible = true;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");

        }
    }
}
