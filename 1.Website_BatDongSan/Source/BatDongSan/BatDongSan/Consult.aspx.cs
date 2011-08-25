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
        Int32 itemperpage = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CaptchaControl1.ValidateCaptcha(txtCaptcha.Text.Trim());
            if (CaptchaControl1.UserValidated)
            {
                lblError.Visible = false;
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

                txtName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtQuestion.Text = "";
                txtCaptcha.Text = "";
                info.Visible = true;
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            Int32 start = 0;
            if (Request.QueryString["start"] != null)
                start = Int32.Parse(Request.QueryString["start"].ToString());
            BDSDataContext db = new BDSDataContext();
            var rs = db.Questions.Where(c => c.IsAnswered == true).OrderByDescending(c => c.AnswerDate)
                .Skip(start).Take(itemperpage);

            if (start == 0)
                HyperLink3.Visible = false;
            else
            {
                //HyperLink3.Visible = true;
                HyperLink3.NavigateUrl = "Consult.aspx?start=" + (start - itemperpage).ToString();
            }
            if (rs.Count() <= itemperpage)
            {
                HyperLink4.Visible = false;
                if (rs.Count() == itemperpage)
                {
                    var t = db.Questions.Where(c => c.IsAnswered == true).OrderByDescending(c => c.AnswerDate)
                    .Skip(itemperpage + start).Take(itemperpage);
                    if (t.Count() > 0)
                    {
                        HyperLink4.Visible = true;
                        HyperLink4.NavigateUrl = "Consult.aspx?start=" + (start + itemperpage).ToString();
                    }
                }
            }

            e.Result = rs;
            if (HyperLink3.Visible && HyperLink4.Visible)
                Label1.Visible = true;
            //else
                //Label1.Visible = false;
            if (HyperLink3.Visible || HyperLink4.Visible)
                line.Visible = true;
        }
    }
}
