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
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Text;

namespace BatDongSan
{
    public partial class Client : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Gold-Price
            try
            {
                String date = DateTime.Now.ToString("yyyy-MM-dd");
                String Url = "http://www.sacombank-sbj.com/service/tygiatrongnuoc.ashx?d=" + date;
                HtmlDocument doc = getHtmlData(Url);

                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//tr");
                String[] lstGold = new String[] { "Vàng SBJ", "Vàng SJC", "Vàng 24 K", 
                    "Vàng 95 %", "Vàng 18 K (75%)" };

                String tbl = ToTableHtml(new String[] { "Loại", "Mua", "Bán" }, "start");
                String data = "";
                foreach (String goldtype in lstGold)
                {
                    try
                    {
                        HtmlNode node = nodes.Nodes().First(c => c.InnerText == goldtype);
                        String[] arr = new String[]{goldtype.Substring(4).Trim(), node.NextSibling.InnerText,
                        node.NextSibling.NextSibling.InnerText};
                        data += ToTableHtml(arr, "body");
                    }
                    catch { }
                }

                if (data == "")
                {
                    throw new Exception();
                }
                lblGoldError.Text = tbl + data + ToTableHtml(new String[0], "end");
            }
            catch
            {
                info1.Visible = false;
                info2.Visible = false;
            }
            #endregion

            #region Currency
            try
            {
                String Url = "http://www.vietcombank.com.vn/exchangerates/";
                HtmlDocument doc = getHtmlData(Url);
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_Content_ExrateView']/tr");

                String[] lstCur = new String[] { "USD", "AUD", "EUR", "JPY"};

                String tbl = ToTableHtml(new String[] { "Loại", "Mua", "Bán" }, "start");
                String data = "";
                foreach (String curname in lstCur)
                {
                    try
                    {
                        HtmlNode node = nodes.Nodes().First(c => c.InnerText == curname);
                        String[] arr = new String[]{curname, node.NextSibling.NextSibling.InnerText,
                        node.NextSibling.NextSibling.NextSibling.NextSibling.InnerText};
                        data += ToTableHtml(arr, "body");
                    }
                    catch { }
                }

                if (data == "")
                {
                    throw new Exception();
                }
                lblCur.Text = tbl + data + ToTableHtml(new String[0], "end");
            }
            catch
            {
                info3.Visible = false;
                info4.Visible = false;
            }
            #endregion

            #region Others
            try
            {
                String Url = "http://giacaphe.com/";
                HtmlDocument doc = getHtmlData(Url);
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='gianoidia']/tr");

                String[] lstCur = new String[] { "Lâm Đồng", "Hạt tiêu đen" };

                String tbl = ToTableHtml(new String[] { "Loại", "Giá" }, "start");
                String data = "";
                foreach (String curname in lstCur)
                {
                    try
                    {
                        HtmlNode node = nodes.Nodes().First(c => c.InnerText == curname);
                        String name = curname;
                        if (name == "Lâm Đồng")
                            name = "Cà phê";
                        String[] arr = new String[] { name, node.NextSibling.NextSibling.InnerText };
                        data += ToTableHtml(arr, "body");
                    }
                    catch { }
                }

                if (data == "")
                {
                    throw new Exception();
                }
                lblOthers.Text = tbl + data + ToTableHtml(new String[0], "end");
            }
            catch { }
            #endregion

            #region Generate js for header animation
            BDSDataContext db = new BDSDataContext();
            System.Collections.Generic.List<HeaderPic> lst = db.HeaderPics.Where(p => p.IsValid == true).ToList();
            String script = "<script type='text/javascript'> $(function() { $('#headerpic').crossSlide({ speed: 45, fade: 2 }, [ ";
            if (lst.Count == 1)
                script += "{ src: '../" + lst[0].Url + "', dir: 'up' }, { src: '../" + lst[0].Url + "', dir: 'down' }";
            else
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    script += "{ src: '" + lst[i].Url + "', dir: ";
                    if (i % 2 == 0)
                        script += "'up' }";
                    else
                        script += "'down' }";
                    if (i != lst.Count - 1)
                        script += ", ";
                }
            }
            script += "]) }); </script>";
                        
            Page.ClientScript.RegisterStartupScript(GetType(),"header", script);
            #endregion
        }

        private HtmlDocument getHtmlData(String url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            String result = "";
            using (Stream stream = request.GetResponse().GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            HtmlDocument doc = new HtmlDocument();
            doc.Load(new StringReader(result));
            return doc;
        }

        private String ToTableHtml(String[] arr, String mode)
        {
            if (mode == "start")
            {
                String rs = "<table><colgroup><col class='col1' /><col class='col2' /><col class='col3' /></colgroup><tr>";
                foreach (String s in arr)
                    rs += "<th>" + s + "</th>";
                rs += "</tr>";
                return rs;
            }
            else if (mode == "body")
            {
                String rs = "<tr>";
                Boolean f = true;
                foreach (String s in arr)
                    if (f)
                    {
                        rs += "<th>" + s + "</th>";
                        f = false;
                    }
                    else
                        rs += "<td>" + ShortenString(s) + "</td>";
                rs += "</tr>";
                return rs;
            }
            else if (mode == "end")
            {
                return "</table>";
            }
            else
            {
                return "";
            }
        }

        private String ShortenString(String s)
        {
            if (HttpUtility.HtmlDecode(s).Trim() == "")
                return s;
            String rs = "";
            try
            {
                rs = Math.Round(Double.Parse(s.Replace("\t", "").Replace("\n", "").Trim())).ToString("N0");
            }
            catch
            {
                rs = Math.Round(Double.Parse(s.Replace("\t", "").Replace("\n", "").Replace(".", "").Trim())).ToString("N0");
            }
            return rs;
        }
    }
}
