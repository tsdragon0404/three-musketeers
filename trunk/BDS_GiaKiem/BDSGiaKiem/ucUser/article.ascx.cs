using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class article : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["name"] != null)
            {
                string name = Request.QueryString["name"];
                Dictionary<String, Int32> data = new Dictionary<String, Int32>();
                data.Add("about", 1);

                BDSDataContext db = new BDSDataContext();
                if (data.Select(d => d.Key).Contains(name))
                {
                    Article ar = db.getArticle(data[name]);
                    contenttext.Text = ar.ContentText;
                    title.Text = ar.Title;
                }
                else
                    Response.Redirect("Default.aspx");
            }
            else
                Response.Redirect("Default.aspx");
        }
    }
}