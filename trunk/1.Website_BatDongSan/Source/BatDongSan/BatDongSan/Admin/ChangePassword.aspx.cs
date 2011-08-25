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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            BDSDataContext db = new BDSDataContext();
            Administrator admin = db.Administrators.First(a => a.UserName == Session["admin"].ToString());
            if (admin.Password == Oldpass.Text)
            {
                admin.Password = TextBox1.Text;
                db.SubmitChanges();
                TextBox1.Text = "";
                TextBox2.Text = "";
                Oldpass.Text = "";
                Label4.Visible = true;
            }
            else
            {
                Label3.Visible = true;
                TextBox1.Text = "";
                TextBox2.Text = "";
                Oldpass.Text = "";
            }
        }

        protected void Oldpass_TextChanged(object sender, EventArgs e)
        {
            Label3.Visible = false;
            Label4.Visible = false;
        }
    }
}
