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
        public frmLoginAdmin LoginAdminForm { get; set; }
        //public frmBranch BranchForm { get; set; }

        private void ShowForm(Form childForm, bool isDialog = false)
        {
            childForm.MdiParent = this;
            if (isDialog)
                childForm.ShowDialog();
            else
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            //LoginAdminForm.InitializeData();
            //ShowForm(LoginAdminForm);
        }

        private void mItemBranch_Click(object sender, EventArgs e)
        {
            //BranchForm.InitializeData();
            //ShowForm(BranchForm);
        }
    }
}
