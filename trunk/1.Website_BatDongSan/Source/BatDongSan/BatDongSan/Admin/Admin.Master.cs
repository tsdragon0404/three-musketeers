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
using BatDongSan;

namespace BatDongSan.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                menuacc.Visible = true;
                if (Session["super"] != null && Boolean.Parse(Session["super"].ToString()) == true)
                    accmanager.Visible = true;
            }

            #region Generate js for header animation
            BDSDataContext db = new BDSDataContext();
            System.Collections.Generic.List<HeaderPic> lst = db.HeaderPics.Where(p => p.IsValid == true).ToList();
            String script = "<script type='text/javascript'> " +
                            "$(function() { " +
                            "$('#headerpic').crossSlide({ " +
                            "speed: 45, fade: 2 }, [ ";
            if (lst.Count == 1)
                script += "{ src: '../" + lst[0].Url + "', dir: 'up' }, { src: '../" + lst[0].Url + "', dir: 'down' }";
            else
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    script += "{ src: '../" + lst[i].Url + "', dir: ";
                    if (i % 2 == 0)
                        script += "'up' }";
                    else
                        script += "'down' }";
                    if (i != lst.Count - 1)
                        script += ", ";
                }
            }
            script += "]) }); </script>";

            Page.ClientScript.RegisterStartupScript(GetType(), "header", script);
            #endregion

        }
    }
}
