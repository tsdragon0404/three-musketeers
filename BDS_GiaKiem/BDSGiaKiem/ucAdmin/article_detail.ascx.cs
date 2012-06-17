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

namespace BDSGiaKiem.ucAdmin
{
    public partial class article_detail : System.Web.UI.UserControl
    {
        Boolean isAddNew = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                isAddNew = false;
            if (!isAddNew)
            {
                int id = Int32.Parse(Request.QueryString["id"]);
                BDSDataContext db = new BDSDataContext();
                Article ar = db.getArticle(id);

                if (ar.ID == 0)
                    Response.Redirect("Admin.aspx?section=article");
                txtTitle.Text = ar.Title;
                editorContent.Text = ar.ContentText;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = isAddNew == true ? 0 : Int32.Parse(Request.QueryString["id"]);
            BDSDataContext db = new BDSDataContext();
            db.UpdateArticle(id, txtTitle.Text, editorContent.Text);
            Response.Redirect("Admin.aspx?section=article");
        }
    }
}