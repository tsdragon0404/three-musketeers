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

namespace BDSGiaKiem.ucUser
{
    public partial class _default : System.Web.UI.UserControl
    {
        private int PicLinkID = 1;
        private int PlanningLinkID = 2;
        private int AreaLinkID = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            HLPic.NavigateUrl = db.getHomeLink(PicLinkID);
            HLPlanning.NavigateUrl = db.getHomeLink(PlanningLinkID);
            HLArea.NavigateUrl = db.getHomeLink(AreaLinkID);
            System.Collections.Generic.List<New> lstNew = db.getLatestNews(5);
            Repeater2.DataSource = lstNew;
            Repeater2.DataBind();
        }

        protected string cutTitle(string title)
        {
            if (title.Length > 33)
                return title.Substring(0, 30) + "...";
            return title;
        }
    }
}