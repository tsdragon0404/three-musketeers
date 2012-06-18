using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BDSGiaKiem.ucAdmin
{
    public partial class news : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAddNew.Visible = true;
            GridView1.Visible = true;
            DetailsView1.Visible = false;
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            var rs = from a in db.News
                     join p in db.Projects on new { ProjectID = Convert.ToInt64(a.ProjectID) } equals new { ProjectID = p.ID }
                     orderby
                       a.LastUpdatedTime descending
                     select new
                     {
                         a.ID,
                         p.Name,
                         a.Title,
                         a.ContentText,
                         a.LastUpdatedTime
                     };
            e.Result = rs;
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["LastUpdatedTime"] = DateTime.Now;
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=news");
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            e.NewValues["LastUpdatedTime"] = DateTime.Now;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=news");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddNew.Visible = false;
            GridView1.Visible = false;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(e.Keys[0].ToString());

            BDSDataContext db = new BDSDataContext();
            var queryAreas =
                from t in db.News
                where
                  t.ID == id
                select t;
            foreach (var del in queryAreas)
            {
                db.News.DeleteOnSubmit(del);
            }
            db.SubmitChanges();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=news");
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = false;
            GridView1.Visible = false;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
        }
    }
}