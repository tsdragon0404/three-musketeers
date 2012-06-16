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
    public partial class supporter : System.Web.UI.UserControl
    {
        private int HotlineID = 1;
        private int Supporter1ID = 2;
        private int Supporter2ID = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            string hotline = db.getSupporter(HotlineID).Phone;
            txtHotline.Text = hotline;

            Supporter sp1 = db.getSupporter(Supporter1ID);
            txtName1.Text = sp1.Name;
            txtPhone1.Text = sp1.Phone;
            txtYahoo1.Text = sp1.Yahoo;

            Supporter sp2 = db.getSupporter(Supporter2ID);
            txtName2.Text = sp2.Name;
            txtPhone2.Text = sp2.Phone;
            txtYahoo2.Text = sp2.Yahoo;
        }

        protected void btnSaveHotline_Click(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            db.UpdateSupporter(HotlineID, "", txtHotline.Text, "");
            HotlineMsg.Visible = true;
            HotlineMsg.Text = "<span class='success'>Cập nhật hotline thành công</span>";
        }
        protected void btnSaveSupporter_Click(object sender, EventArgs e)
        {
            BDSDataContext db = new BDSDataContext();
            db.UpdateSupporter(Supporter1ID, txtName1.Text, txtPhone1.Text, txtYahoo1.Text);
            db.UpdateSupporter(Supporter2ID, txtName2.Text, txtPhone2.Text, txtYahoo2.Text);
            SupporterMsg.Visible = true;
            SupporterMsg.Text = "<span class='success'>Cập nhật hỗ trợ thành công</span>";
        }
    }
}