﻿using System;
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

namespace BDSGiaKiem
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BDSDAO bds = new BDSDAO();
            FilterParameterCollection param = new FilterParameterCollection();
            param.Add(new FilterParameter("@Id", "1", DbType.Int32));
            //DataTable table = bds.GetReports("spa_GetSample", param);
            Gridview1.DataSource = bds.GetReports("spa_GetSample", param);
            Gridview1.DataBind();
        }
    }
}
