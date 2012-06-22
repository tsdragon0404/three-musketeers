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
    public partial class news_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pj_id"] != null)
            {

            }
            else if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"];
                BDSDataContext db = new BDSDataContext();
                New news = db.getNew(int.Parse(id));
                lbtTitle.Text = news.Title;
                lrtContent.Text = news.ContentText;
            }
            else
                Response.Redirect("Default.aspx?section=news");
        }
    }
}