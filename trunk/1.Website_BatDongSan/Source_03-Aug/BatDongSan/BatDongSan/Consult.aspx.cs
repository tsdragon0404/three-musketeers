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
    public partial class Consult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Question q = new Question();
            q.Name = txtName.Text;
            q.Email = txtEmail.Text;
            q.Phone = txtPhone.Text;
            q.QuestionText = txtQuestion.Text;
            q.PostDate = DateTime.Now;
            q.IsAnswered = false;
            
            BDSDataContext db = new BDSDataContext();
            db.Questions.InsertOnSubmit(q);
            db.SubmitChanges();
        }
    }
}
