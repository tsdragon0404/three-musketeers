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

namespace BDSGiaKiem
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private int HotlineID = 1;
        private int Supporter1ID = 2;
        private int Supporter2ID = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            hotline.InnerText = "Hotline: " + db.getSupporter(HotlineID).Phone;

            Supporter sup1 = db.getSupporter(Supporter1ID);
            formatSupporterTag(sup1, yahoo1);

            Supporter sup2 = db.getSupporter(Supporter2ID);
            formatSupporterTag(sup2, yahoo2);
        }
        private void formatSupporterTag(Supporter sup, HtmlGenericControl element)
        {
            element.InnerHtml = String.Format("<a href='ymsgr:sendIM?{0}'>{1} - {2}</a>", sup.Yahoo, sup.Name, sup.Phone);
            try
            {
                System.Net.WebRequest request =
                    System.Net.WebRequest.Create(
                    "http://opi.yahoo.com/online?u=" + sup.Yahoo +"&t=5");
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream =
                    response.GetResponseStream();
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(responseStream);
                System.Drawing.Color pixelcolor = bmp.GetPixel(5, 5);
                if (pixelcolor.R == 249 && pixelcolor.G == 249 && pixelcolor.B == 102)
                    element.Attributes.Add("class", "yahoo on");
                else
                    element.Attributes.Add("class", "yahoo off");

            }
            catch (System.Net.WebException)
            { element.Attributes.Add("class", "on"); }
        }
    }
}
