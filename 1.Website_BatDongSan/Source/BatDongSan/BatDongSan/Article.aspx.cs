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
    public partial class Article1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinqDataSource3_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            if (Request.QueryString["key"] != null)
            {
                BDSDataContext db = new BDSDataContext();
                var rs = db.Articles.Where(c => c.IsValid == true && c.ID > Int64.Parse(Request.QueryString["key"].ToString())).OrderByDescending(c => c.ID).Take(4);
                if (rs.Count() == 0)
                    DataList3.Visible = false;
                foreach (Article ar in rs)
                    if (ar.Title.Length > 60)
                        ar.Title = ar.Title.Remove(60) + "...";
                e.Result = rs;
            }
            else
            {
                e.Result = null;
                DataList3.Visible = false;
                line.Visible = false;
            }
        }

        protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            if (Request.QueryString["key"] != null)
            {
                BDSDataContext db = new BDSDataContext();
                var rs = db.Articles.Where(c => c.IsValid == true && c.ID < Int64.Parse(Request.QueryString["key"].ToString())).OrderByDescending(c => c.ID).Take(4);
                if (rs.Count() == 0)
                    DataList2.Visible = false;
                foreach (Article ar in rs)
                    if (ar.Title.Length > 60)
                        ar.Title = ar.Title.Remove(60) + "...";
                e.Result = rs;
            }
            else
            {
                DataList2.Visible = false;
                e.Result = null;
            }
        }
        protected void LinqDataSource4_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            var rs = db.Articles.Where(c => c.IsValid == true).OrderByDescending(c => c.ID).Take(10);
            foreach (Article ar in rs)
                if (ar.Title.Length > 60)
                    ar.Title = ar.Title.Remove(60) + "...";

            e.Result = rs;
            if (Request.QueryString["key"] != null)
                DataList4.Visible = false;
        }
    }
}
