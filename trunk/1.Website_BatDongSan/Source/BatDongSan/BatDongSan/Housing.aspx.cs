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

namespace BatDongSan
{
    public partial class Housing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            e.Result = db.Houses.Where(c => c.IsValid == true && c.Agri == false).OrderByDescending(c => c.ID).Take(3);
        }

        protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            e.Result = db.Houses.Where(c => c.IsValid == true && c.Agri == true).OrderByDescending(c => c.ID).Take(3);
        }

        protected void LinqDataSource3_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            e.Result = db.Projects.Where(c=>c.IsValid == true).OrderByDescending(c => c.ID).Take(3);
        }
    }
}
