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
using System.Drawing;
using System.IO;

namespace BDSGiaKiem.ucAdmin
{
    public partial class planning : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAddNew.Visible = true;
            GridView1.Visible = true;
            DetailsView1.Visible = false;
            lblStatus.InnerHtml = "Danh sách quy hoạch";
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            var rs = from a in db.Plannings
                     join p in db.Projects on new { ProjectID = Convert.ToInt64(a.ProjectID) } equals new { ProjectID = p.ID }
                     orderby a.ProjectID
                     select new
                     {
                         a.ID,
                         p.Name,
                         a.ImageUrl,
                         a.Description
                     };
            e.Result = rs;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddNew.Visible = false;
            GridView1.Visible = false;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            lblStatus.InnerHtml = "Chi tiết quy hoạch";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(e.Keys[0].ToString());

            BDSDataContext db = new BDSDataContext();
            var plans = db.Plannings.Where(a => a.ID == id);
            if (plans.Count() == 0)
                return;

            Planning plan = plans.First();
            string file = Server.MapPath(plan.ImageUrl);

            db.Plannings.DeleteOnSubmit(plan);
            db.SubmitChanges();

            if (File.Exists(file))
                File.Delete(file);
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=planning");
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=planning");
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            FileUpload fup = DetailsView1.FindControl("FileUpload1B") as FileUpload;
            if (fup.HasFile)
            {
                if (fup.PostedFile.ContentLength < 4 * 1024 * 1024)
                {
                    string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + DateTime.Now.ToString("HH-mm-ss") + "_" + Path.GetFileName(fup.FileName);
                    string extension = Path.GetExtension(fup.FileName).ToLower();
                    if ((extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg")) && (fup.PostedFile.ContentLength < 4 * 1024 * 1024))
                    {
                        String savefile = Server.MapPath(@"~/images/Planning/") + filename;
                        Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                        src.Save(savefile);

                        e.Values["ImageUrl"] = "images/Planning/" + filename;
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert(\"Tập tin không hợp lệ.\");</script>");
                    }
                }
                else
                    Response.Write("<script language='javascript'>alert(\"Tập tin tải lên quá lớn.\");</script>");
            }
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=planning");
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            FileUpload fup = DetailsView1.FindControl("FileUpload1B") as FileUpload;
            if (fup.HasFile)
            {
                if (fup.PostedFile.ContentLength < 4 * 1024 * 1024)
                {
                    string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + DateTime.Now.ToString("HH-mm-ss") + "_" + Path.GetFileName(fup.FileName);
                    string extension = Path.GetExtension(fup.FileName).ToLower();
                    if ((extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg")) && (fup.PostedFile.ContentLength < 4 * 1024 * 1024))
                    {
                        String savefile = Server.MapPath(@"~/images/Planning/") + filename;
                        if (File.Exists(savefile))
                            File.Delete(savefile);
                        Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                        src.Save(savefile);

                        e.NewValues["ImageUrl"] = "images/Planning/" + filename;
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert(\"Tập tin không hợp lệ.\");</script>");
                    }
                }
                else
                    Response.Write("<script language='javascript'>alert(\"Tập tin tải lên quá lớn.\");</script>");
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = false;
            GridView1.Visible = false;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
            lblStatus.InnerHtml = "Thêm mới quy hoạch";
        }
    }
}