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
    public partial class planning : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pid"] != null)
            {
                int id;
                if (Int32.TryParse(Request.QueryString["pid"], out id))
                    HyperLink1.NavigateUrl = "/default.aspx?section=project_detail&id=" + id;
                else
                    Response.Redirect("/default.aspx?section=project");
            }
            else
                Response.Redirect("/default.aspx?section=project");
        }
    }
}