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
using BatDongSan;

namespace BatDongSan.Admin
{
    public partial class ManageQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dtView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            e.NewValues["IsAnswered"] = true;
            e.NewValues["AnswerDate"] = DateTime.Now;
        }

        protected void dtView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
                dtView.Visible = false;
        }

        protected void gvQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtView.Visible = true;
        }

        protected void dtView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            dtView.Visible = false;
        }
    }
}
