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

namespace BatDongSan.Admin.uc
{
    public partial class ucAddArticle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Article ar = new Article();
            ar.Title = txttieude.Text.Trim();
            ar.Summary = HttpUtility.HtmlDecode(txttomtat.Text.Trim());
            ar.Contents = HttpUtility.HtmlDecode(ckenoidung.Text.Trim());
            ar.PostDate = DateTime.Now;
            ar.LatestModifiedDate = DateTime.Now;
            ar.IsValid = true;

            BDSDataContext db = new BDSDataContext();
            db.Articles.InsertOnSubmit(ar);
            db.SubmitChanges();
        }
    }
}