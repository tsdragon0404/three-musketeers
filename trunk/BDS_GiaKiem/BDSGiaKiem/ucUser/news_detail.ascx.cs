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
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    int id = Int32.Parse(Request.QueryString["id"]);
                    BDSDataContext db = new BDSDataContext();
                    New news = db.getNews(id);
                    lblTitle.Text = news.Title;
                    lblDate.Text = news.LastUpdatedTime.Value.ToString("( dd-MM-yyyy )");
                    lblContent.Text = news.ContentText;
                }
                catch
                {
                    Response.Redirect("/Default.aspx?section=news");
                }
            }
            else
                Response.Redirect("/Default.aspx?section=news");
        }
    }
}