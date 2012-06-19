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

namespace BDSGiaKiem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] sections = new String[] { "area", "article", "news", "news_detail", "planning", "project", "project_detail" };

            Control ctrl;
            String section = "default";
            if (Request.QueryString["section"] != null && Request.QueryString["section"].ToString().Trim() != "")
                section = Request.QueryString["section"].ToString().Trim();
            if (sections.Contains(section))
                ctrl = Page.LoadControl("ucUser/" + section + ".ascx");
            else
                ctrl = Page.LoadControl("ucUser/default.ascx");

            Body.Controls.Add(ctrl);
        }
    }
}
