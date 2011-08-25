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
using BatDongSan;

namespace BatDongSan.Admin
{
    public partial class ManageQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void dtView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            e.NewValues["IsAnswered"] = true;
            e.NewValues["AnswerDate"] = DateTime.Now;
        }

        protected void dtView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            if (e.CancelingEdit)
            {
                dtView.Visible = false;
                ddlAnswer.Visible = true;
                gvQuestion.Visible = true;
            }
        }

        protected void gvQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            dtView.Visible = true;
            gvQuestion.Visible = false;
            ddlAnswer.Visible = false;
        }

        protected void dtView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("ManageQuestion.aspx");
        }

        protected void gvQuestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
        }
    }
}
