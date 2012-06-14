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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String section = "default";
                if (Request.QueryString["section"] != null && Request.QueryString["section"].ToString().Trim() != "")
                    section = Request.QueryString["section"].ToString().Trim();

                Control ctrl;
                if (section == "homepic")
                {
                    ctrl = Page.LoadControl("ucAdmin/homepic.ascx");
                }
                else // include section default
                    ctrl = Page.LoadControl("ucAdmin/default.ascx");

                Body.Controls.Add(ctrl);
            } 
        }
    }
}
