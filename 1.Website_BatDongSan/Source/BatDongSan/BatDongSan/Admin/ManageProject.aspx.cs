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
using System.Drawing;
using System.IO;

namespace BatDongSan.Admin
{
    public partial class ManageProject : System.Web.UI.Page
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

        public Bitmap ResizeBitmap(Bitmap src, int newWidth, int newHeight)
        {
            Bitmap result = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
            {
                g.DrawImage(src, 0, 0, newWidth, newHeight);
            }
            return result;
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            FileUpload fup = DetailsView1.FindControl("FileUpload1B") as FileUpload;
            if (fup.HasFile)
            {
                string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + Path.GetFileName(fup.FileName);
                string extension = Path.GetExtension(fup.FileName).ToLower();
                if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg"))
                {
                    String savefile = Server.MapPath(@"~/images/Project/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;

                    Bitmap result = ResizeBitmap(src, 435, 300);
                    result.Save(savefile);

                    e.Values["Picture"] = "images/Project/" + filename;
                }
                else
                {
                }
            }
            e.Values["PostDate"] = DateTime.Now;
            e.Values["LatestModifiedDate"] = DateTime.Now;
            e.Values["ViewCount"] = 1;

            //ko insert = detailview dc phai insert = code : ko hieu ly do
            BDSDataContext db = new BDSDataContext();
            Project p = new Project();
            p.Title = e.Values["Title"].ToString();
            p.Summary = e.Values["Summary"].ToString();
            p.Picture = e.Values["Picture"].ToString();
            p.Description = e.Values["Description"].ToString();
            p.PostDate = DateTime.Parse(e.Values["PostDate"].ToString());
            p.LatestModifiedDate = DateTime.Parse(e.Values["LatestModifiedDate"].ToString());
            p.ViewCount = Int32.Parse(e.Values["ViewCount"].ToString());
            p.IsValid = Boolean.Parse(e.Values["IsValid"].ToString());

            db.Projects.InsertOnSubmit(p);
            db.SubmitChanges();
            e.Cancel = true;

            Response.Redirect("ManageProject.aspx");
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            //Response.Redirect("ManageProject.aspx");
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
            FileUpload fup = DetailsView1.FindControl("FileUpload1B") as FileUpload;
            if (fup.HasFile)
            {
                string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + Path.GetFileName(fup.FileName);
                string extension = Path.GetExtension(fup.FileName).ToLower();
                if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg"))
                {
                    System.Web.UI.WebControls.Image img = DetailsView1.FindControl("Image1") as System.Web.UI.WebControls.Image;
                    String oldfile = img.ImageUrl;
                    //String oldfile = e.OldValues["Picture"].ToString();
                    if (File.Exists(Server.MapPath(@"~/images/") + oldfile) && oldfile != "")
                        File.Delete(Server.MapPath(@"~/images/") + oldfile);
                    String savefile = Server.MapPath(@"~/images/Project/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;

                    Bitmap result = ResizeBitmap(src, 75, 34);
                    result.Save(savefile);

                    e.NewValues["Picture"] = "images/Project/" + filename;
                }
                else
                {
                }
            }
            e.NewValues["LatestModifiedDate"] = DateTime.Now;
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("ManageProject.aspx");
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
