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
using System.IO;
using System.Drawing;

namespace BatDongSan.Admin
{
    public partial class ManageAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            ImageButton3.Visible = false;
            GridView1.Visible = false;
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            if (e.CancelingEdit)
                Response.Redirect("ManageAdv.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
            ImageButton3.Visible = false;
            GridView1.Visible = false;
        }

        public Bitmap ResizeBitmap(Bitmap src, int newWidth)
        {
            int newHeight = (int)(1.0 * newWidth / src.Width * src.Height);
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
            FileUpload fup = DetailsView1.FindControl("FUpPic") as FileUpload;
            if (fup.HasFile)
            {
                string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + Path.GetFileName(fup.FileName);
                string extension = Path.GetExtension(fup.FileName).ToLower();
                if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg"))
                {
                    String savefile = Server.MapPath(@"~/images/Adv/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                    Bitmap result = ResizeBitmap(src, 235);
                    result.Save(savefile);

                    e.Values["Picture"] = "images/Adv/" + filename;
                    e.Values["IsValid"] = "True";
                }
                else
                {
                }
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("ManageAdv.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            System.Web.UI.WebControls.Image img = GridView1.Rows[e.RowIndex].FindControl("Image1") as System.Web.UI.WebControls.Image;
            String oldfile = img.ImageUrl;
            if (File.Exists(Server.MapPath(@"~/images/") + oldfile) && oldfile != "")
                File.Delete(Server.MapPath(@"~/images/") + oldfile);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            FileUpload fup = GridView1.Rows[e.RowIndex].FindControl("FUpPic") as FileUpload;
            if (fup.HasFile)
            {
                string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + Path.GetFileName(fup.FileName);
                string extension = Path.GetExtension(fup.FileName).ToLower();

                if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg"))
                {
                    System.Web.UI.WebControls.Image img = GridView1.Rows[e.RowIndex].FindControl("Image1") as System.Web.UI.WebControls.Image;
                    String oldfile = img.ImageUrl;
                    if (File.Exists(Server.MapPath(@"~/images/") + oldfile) && oldfile != "")
                        File.Delete(Server.MapPath(@"~/images/") + oldfile);

                    String savefile = Server.MapPath(@"~/images/Adv/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                    Bitmap result = ResizeBitmap(src, 235);
                    result.Save(savefile);

                    e.NewValues["Picture"] = "images/Adv/" + filename;
                }
                else
                {
                }
            }
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            Response.Redirect("ManageAdv.aspx");
        }
    }
}
