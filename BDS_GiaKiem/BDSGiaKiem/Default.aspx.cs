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
            {
                if (section == "article")
                    Page.Title = "Gioi thieu";
                else if (section == "news" || section == "news_detail")
                    Page.Title = "Tin tuc";
                else if (section == "project" || section == "project_detail")
                    Page.Title = "Du an";
                else if (section == "area")
                    Page.Title = "Khu vuc";
                else
                    Page.Title = "Ke hoach dau tu";
;

                ctrl = Page.LoadControl("ucUser/" + section + ".ascx");
            }
            else
            {
                Page.Title = "Trang chu";
                ctrl = Page.LoadControl("ucUser/default.ascx");
            }

            Body.Controls.Add(ctrl);
        }
    }
}
