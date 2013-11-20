﻿using System;
using System.Windows.Forms;

namespace RMS.Admin
{
    public partial class frmMain : Form
    {
        #region Public properties

        public frmUser UserForm { get; set; }

        public frmBranch BranchForm { get; set; } 

        #endregion

        #region Constructor(s)

        public frmMain()
        {
            InitializeComponent();
        } 

        #endregion

        #region Private methods

        private void ShowForm(Form childForm)
        {
            childForm.MdiParent = this;
            childForm.Show();
            childForm.Activate();
        } 

        #endregion

        #region Event methods

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

        }

        private void mItemBranch_Click(object sender, EventArgs e)
        {
            BranchForm.InitializeData();
            ShowForm(BranchForm);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10) // WM_CLOSE
            {
                var ret = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.No)
                    return;

                foreach (var mdiChild in MdiChildren)
                    mdiChild.Close();

                Application.Exit();
            }
            base.WndProc(ref m);
        }

        #endregion
    }
}
