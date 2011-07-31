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

namespace BatDongSan.Admin
{
    public partial class ManageArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "add")
            {
                GridView1.Visible = false;
                ucAddArticle1.Visible = true;
            }
            if (Request.QueryString["action"] == "edit")
            {
                GridView1.Visible = false;
                ucEditArticle1.Visible = true;
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageArticle.aspx?action=add");
            
        }
   
    }
}
