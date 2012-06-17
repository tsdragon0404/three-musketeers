﻿using System;
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
    public partial class area : System.Web.UI.UserControl
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
            var rs = from a in db.Areas
                     join p in db.Projects on new { ProjectID = Convert.ToInt64(a.ProjectID) } equals new { ProjectID = p.ID }
                     select new
                     {
                         a.ID,
                         p.Name,
                         a.ImageUrl,
                         a.Description
                     };
            e.Result = rs;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = false;
            GridView1.Visible = false;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
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

        private void saveJpeg(string path, System.Drawing.Bitmap img, long quality)
        {
            System.Drawing.Imaging.EncoderParameter qualityParam =
                new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            System.Drawing.Imaging.ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private System.Drawing.Imaging.ImageCodecInfo getEncoderInfo(string mimeType)
        {
            System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            FileUpload fup = DetailsView1.FindControl("FileUpload1B") as FileUpload;
            if (fup.HasFile)
            {
                string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + DateTime.Now.ToString("HH-mm-ss") + "_" + Path.GetFileName(fup.FileName);
                string extension = Path.GetExtension(fup.FileName).ToLower();
                if ((extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg")) && (fup.PostedFile.ContentLength < 4 * 1024 * 1024))
                {
                    String savefile = Server.MapPath(@"~/images/Area/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                    src.Save(savefile);

                    e.NewValues["ImageUrl"] = "images/Area/" + filename;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert(\"Tập tin không hợp lệ.\");</script>");
                }
            }
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            FileUpload fup = DetailsView1.FindControl("FileUpload1B") as FileUpload;
            if (fup.HasFile)
            {
                string filename = DateTime.Now.ToString("dd-MM-yy") + "_" + DateTime.Now.ToString("HH-mm-ss") + "_" + Path.GetFileName(fup.FileName);
                string extension = Path.GetExtension(fup.FileName).ToLower();
                if ((extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg")) && (fup.PostedFile.ContentLength < 4 * 1024 * 1024))
                {
                    String savefile = Server.MapPath(@"~/images/Area/") + filename;
                    if (File.Exists(savefile))
                        File.Delete(savefile);
                    Bitmap src = Bitmap.FromStream(fup.PostedFile.InputStream) as Bitmap;
                    src.Save(savefile);

                    e.Values["ImageUrl"] = "images/Area/" + filename;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert(\"Tập tin không hợp lệ.\");</script>");
                }
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=area");
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=area");
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
                from t in db.Areas
                where
                  t.ID == id
                select t;
            foreach (var del in queryAreas)
            {
                db.Areas.DeleteOnSubmit(del);
            }
            db.SubmitChanges();


            //Đoạn này chưa chạy được
            string file = Server.MapPath(GridView1.Rows[e.RowIndex].Cells[1].ToString());
            if (File.Exists(file))
                File.Delete(file);
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=area");
        }
    }
}