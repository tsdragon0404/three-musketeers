using System;
using System.Windows.Forms;
using Autofac;

namespace RMS.Admin
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public frmUser UserForm { get; set; }

        private void ShowForm(Form childForm)
        {
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void mItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mItemLogout_Click(object sender, EventArgs e)
        {
            //TODO: logout code here
        }

        private void mItemUsers_Click(object sender, EventArgs e)
        {
            UserForm.InitializeData();
            ShowForm(UserForm);
        }
    }
}
