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
    public partial class homelink : System.Web.UI.UserControl
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