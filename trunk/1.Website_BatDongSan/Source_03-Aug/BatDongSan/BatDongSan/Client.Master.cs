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
                String[] lstGold = new String[] { "Vàng SBJ", "Vàng SJC" };

                String tbl = ToTableHtml(new String[] { "Loại", "Mua", "Bán" }, "start");
                String data = "";
                foreach (String goldtype in lstGold)
                {
                    try
                    {
                        HtmlNode node = nodes.Nodes().First(c => c.InnerText == goldtype);
                        String[] arr = new String[]{goldtype, node.NextSibling.InnerText,
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
                //lblGoldError.Visible = true;
                //tblGold.Visible = false;
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

                String[] lstCur = new String[] { "AUD", "EUR", "JPY", "USD"};

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
