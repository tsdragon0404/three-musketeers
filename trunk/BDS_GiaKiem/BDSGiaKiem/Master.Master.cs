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
            
        }
        private void formatSupporterTag(Supporter sup, HtmlGenericControl element)
        {
            element.InnerHtml = String.Format("<a href='ymsgr:sendIM?{0}'>{1} - {2}</a>", sup.Yahoo, sup.Name, sup.Phone);
            //try
            //{
            //    System.Net.WebRequest request =
            //        System.Net.WebRequest.Create(
            //        "http://www.microsoft.com//h/en-us/r/ms_masthead_ltr.gif");
            //    System.Net.WebResponse response = request.GetResponse();
            //    System.IO.Stream responseStream =
            //        response.GetResponseStream();
            //    Bitmap bitmap2 = new Bitmap(responseStream);
            //    PictureBox1.Image = bitmap2;

            //}
            //catch (System.Net.WebException)
            //{
            //    MessageBox.Show("There was an error opening the image file."
            //       + "Check the URL");
            //}
        }
    }
}
