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
using System.Collections.Generic;

namespace BatDongSan
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            List<Article> lst = db.Articles.OrderByDescending(c => c.ID).Take(5).ToList();
            foreach (Article ar in lst)
                if (ar.Title.Length > 60)
                    ar.Title = ar.Title.Remove(60) + "...";

            e.Result = lst;
        }

        protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            List<House> a = db.Houses.Where(c => c.IsValid == true && c.Agri == false).OrderByDescending(c => c.ID).Take(2).ToList();
            List<House> b = db.Houses.Where(c => c.IsValid == true && c.Agri == true).OrderByDescending(c => c.ID).Take(2).ToList();
            a.AddRange(b);
            e.Result = a;
        }
        protected void LinqDataSource3_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            var rs = db.Projects.OrderByDescending(p => p.PostDate).OrderBy(p => p.ID).First();

            if (rs.Summary.Length > 60)
                rs.Summary = rs.Summary.Remove(60) + "...";

            e.Result = rs;
        }
    }
}
