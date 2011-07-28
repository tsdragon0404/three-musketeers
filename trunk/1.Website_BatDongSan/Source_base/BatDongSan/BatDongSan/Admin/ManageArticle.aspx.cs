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

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Article ar = new Article();
            ar.Title = txttieude.Text.Trim();
            ar.Summary = txttomtat.Text.Trim();
            ar.Text = ckeNoidung.Text.Trim();
        }
    }
}
