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
    public partial class ManageHousing : System.Web.UI.Page
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
            DropDownList2.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            DetailsView1.Visible = true;
            ImageButton3.Visible = false;
            GridView1.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            if (e.CancelingEdit)
            {
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                GridView1.Visible = true;
                ImageButton3.Visible = true;
                DetailsView1.Visible = false;
            }
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
                    String savefile = Server.MapPath(@"~/images/Housing/") + filename;
                    String savefile1 = Server.MapPath(@"~/images/Housing/Thumbnail/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                    src.Save(savefile);

                    Bitmap result = ResizeBitmap(src, 100, 100);
                    result.Save(savefile1);

                    e.Values["Thumbnail"] = "images/Housing/Thumbnail/" + filename;
                    e.Values["Picture"] = "images/Housing/" + filename;
                }
                else
                {
                }
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("ManageHousing.aspx");
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
                    String savefile = Server.MapPath(@"~/images/Housing/") + filename;
                    String savefile1 = Server.MapPath(@"~/images/Housing/Thumbnail/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                    src.Save(savefile);

                    Bitmap result = ResizeBitmap(src, 100, 100);
                    result.Save(savefile1);

                    e.NewValues["Thumbnail"] = "images/Housing/Thumbnail/" + filename;
                    e.NewValues["Picture"] = "images/Housing/" + filename;
                }
                else
                {
                }
            }
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("ManageHousing.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");

        }
    }
}
