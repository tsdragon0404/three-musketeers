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
    public partial class EditContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            OboutInc.Editor.Editor edi = DetailsView1.FindControl("editorNoidung") as OboutInc.Editor.Editor;
            edi.ClickSubmit += new OboutInc.Editor.ClickSubmitEventHandler(edi_ClickSubmit);
        }
        void edi_ClickSubmit(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            DetailsView1.UpdateItem(false);
        }
    }
}
