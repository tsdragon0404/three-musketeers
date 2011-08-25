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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["act"] != null && Request.QueryString["act"] == "logout")
            {
                Session["admin"] = null;
                Session["super"] = null;
                Response.Redirect("Login.aspx");
            }
            if (Session["admin"] != null)
                Response.Redirect("Default.aspx");
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = false;
            BDSDataContext db = new BDSDataContext();
            
            var users = db.Administrators.Where(c=>c.UserName == Login1.UserName);
            if (users.Count() != 0)
            {
                Administrator user = users.First();
                if (user.Password == Login1.Password)
                {
                    e.Authenticated = true;
                    Session["admin"] = user.UserName;
                    Session["super"] = user.Super;
                }
            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {

        }
    }
}
