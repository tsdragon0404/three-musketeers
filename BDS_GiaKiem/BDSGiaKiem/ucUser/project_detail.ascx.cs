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
    public partial class project_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id;
                if (Int32.TryParse(Request.QueryString["id"], out id))
                {
                    BDSDataContext db = new BDSDataContext();
                    Project pj = db.getProject(id);
                    if (pj.ID == 0)
                        Response.Redirect("/default.aspx?section=project");
                    title.Text = pj.Name;
                    text.Text = pj.ContentText;
                    HLPlanning.NavigateUrl = "/default.aspx?section=planning&pid=" + id;
                    HLArea.NavigateUrl = "/default.aspx?section=area&pid=" + id;
                }
                else
                    Response.Redirect("/default.aspx?section=project");
            }
            else
                Response.Redirect("/default.aspx?section=project");
        }
    }
}