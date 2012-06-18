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
    public partial class homepic : System.Web.UI.UserControl
    {
        private int PicLinkID = 1;
        private int PlanningLinkID = 2;
        private int AreaLinkID = 3;
        private int NewsLinkID = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            string piclink = db.getHomeLink(PicLinkID);
            txtPicLink.Text = piclink;
            HLPic.NavigateUrl = piclink;

            string planninglink = db.getHomeLink(PlanningLinkID);
            txtPlanningLink.Text = planninglink;
            HLPlanning.NavigateUrl = planninglink;

            string arealink = db.getHomeLink(AreaLinkID);
            txtAreaLink.Text = arealink;
            HLArea.NavigateUrl = arealink;
        }

        public System.Drawing.Bitmap ResizeBitmap(System.Drawing.Bitmap src, int newWidth, int newHeight)
        {
            //int newHeight = (int)(1.0 * newWidth / src.Width * src.Height);
            System.Drawing.Bitmap result = new System.Drawing.Bitmap(newWidth, newHeight);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage((System.Drawing.Image)result))
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            PicUploadMsg.Text = "<img src='images/loading.gif' height='32px' /> Please wait ...";
            PicUploadMsg.Visible = true;
            if (PicUpload.HasFile)
            {
                if (PicUpload.PostedFile.ContentLength < 4 * 1024 * 1024)
                {
                    string extension = System.IO.Path.GetExtension(PicUpload.FileName).ToLower();
                    string filename = DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + extension;
                    if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".jpeg"))
                    {
                        String savefile = Server.MapPath(@"~/images/home_pic/") + filename;
                        String savefile1 = Server.MapPath(@"~/images/home_pic/thumbnail/") + filename;
                        System.Drawing.Bitmap src =
                            System.Drawing.Bitmap.FromStream(PicUpload.PostedFile.InputStream) as System.Drawing.Bitmap;
                        System.Drawing.Bitmap result = ResizeBitmap(src, 1000, 600);
                        saveJpeg(savefile, result, 80);

                        System.Drawing.Bitmap result2 = ResizeBitmap(src, 200, 120);
                        saveJpeg(savefile1, result2, 80);

                        BDSDataContext db = new BDSDataContext();
                        db.InsertHomePic("images/home_pic/" + filename);

                        PicUploadMsg.Text = "<span class='success'>Tải file hoàn tất</span>";
                        PicDataList.DataBind();
                    }
                    else
                        PicUploadMsg.Text = "<span class='error'>Chỉ được tải lên file dạng *.jpg, *.jpeg, *.png, *.gif</span>";
                }
                else
                    PicUploadMsg.Text = "<span class='error'>Chỉ được tải lên file có dung lượng < 4Mb</span>";
            }
            else
                PicUploadMsg.Text = "<span class='error'>Chưa chọn file</span>";
        }

        protected string getThumbnailURL(string imgurl)
        {
            return imgurl.Insert(imgurl.LastIndexOf("/"), "/thumbnail/");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = ((CheckBox)sender);
            PicMsg.Visible = true;
            if (chk.InputAttributes["id"] != null)
            {
                BDSDataContext db = new BDSDataContext();
                int rs = db.UpdateHomePic(Int32.Parse(chk.InputAttributes["id"]), chk.Checked);
                if (rs == 0)
                    PicMsg.Text = "<span class='error'>Có lỗi xảy ra. Vui lòng refresh lại trình duyệt</span>";
                else
                    PicMsg.Text = "<span class='success'>Cập nhật thành công.</span>";
            }
            else
                PicMsg.Text = "<span class='error'>Có lỗi xảy ra. Vui lòng refresh lại trình duyệt</span>";
            PicDataList.DataBind();
        }
        protected void PicDataList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = e.Item.DataItem as HomePic;
                if (item != null)
                {
                    var chk = e.Item.FindControl("chkUsed") as CheckBox;
                    if (chk != null)
                        chk.InputAttributes.Add("id", item.ID.ToString());
                }
            }
        }
        protected void PicDataList_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int id = Int32.Parse(PicDataList.DataKeys[e.Item.ItemIndex].ToString());
            BDSDataContext db = new BDSDataContext();
            string rs = db.DeleteHomePic(id);
            PicMsg.Visible = true;
            if (rs == "")
                PicMsg.Text = "<span class='error'>Có lỗi xảy ra. Vui lòng refresh lại trình duyệt</span>";
            else
            {
                string filepath = Server.MapPath(rs);
                if (System.IO.File.Exists(filepath))
                    System.IO.File.Delete(filepath);
                string filepath2 = Server.MapPath(getThumbnailURL(rs));
                if (System.IO.File.Exists(filepath2))
                    System.IO.File.Delete(filepath2);

                PicMsg.Text = "<span class='success'>Xóa hình ảnh hoàn tất.</span>";
            }
            PicDataList.DataBind();
        }

        protected void btnSavePicLink_Click(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            db.UpdateHomeLink(PicLinkID, txtPicLink.Text);
            HLPic.NavigateUrl = txtPicLink.Text;
            PicLinkMsg.Visible = true;
            PicLinkMsg.Text = "<span class='success'>Cập nhật liên kết thành công</span>";
        }
        protected void btnSavePlanningLink_Click(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            db.UpdateHomeLink(PlanningLinkID, txtPlanningLink.Text);
            HLPlanning.NavigateUrl = txtPlanningLink.Text;
            PlanningLinkMsg.Visible = true;
            PlanningLinkMsg.Text = "<span class='success'>Cập nhật liên kết thành công</span>";
        }
        protected void btnSaveAreaLink_Click(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            db.UpdateHomeLink(AreaLinkID, txtAreaLink.Text);
            HLArea.NavigateUrl = txtAreaLink.Text;
            AreaLinkMsg.Visible = true;
            AreaLinkMsg.Text = "<span class='success'>Cập nhật liên kết thành công</span>";
        }
    }
}