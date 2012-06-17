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
    public partial class project : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            DetailsView1.Visible = false;
            btnAddNew.Visible = true;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = false;
            GridView1.Visible = false;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=project");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddNew.Visible = false;
            GridView1.Visible = false;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("admin.aspx?section=project");
        }
    }
}