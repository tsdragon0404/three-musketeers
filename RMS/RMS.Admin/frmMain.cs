﻿using System;
using System.Threading;
using System.Windows.Forms;
using TM.UI.WindowsForms.Utilities;
using TM.Utilities;
using TM.Utilities.Messages;

namespace RMS.Admin
{
    [FunctionId(GlobalConstants.FunctionIds.FormMain)]
    public partial class frmMain : Form
    {
        public IMessageManager MessageManager { get; set; }

        #region Forms

        public frmUser UserForm { get; set; }

        public frmBranch BranchForm { get; set; }

        public frmProductCategory ProductCategoryForm { get; set; } 

        #endregion

        #region Constructor(s)

        public frmMain()
        {
            Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;
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
                var ret = MessageManager.ShowQuestion(Resources.Resource.Common_Exit_Caption,
                                                      Resources.Resource.Common_Exit_Message);
                if (ret == DialogResult.No)
                    return;

                foreach (var mdiChild in MdiChildren)
                    mdiChild.Close();

                Application.Exit();
            }
            base.WndProc(ref m);
        }

        private void mItemProductCategory_Click(object sender, EventArgs e)
        {
            ProductCategoryForm.InitializeData();
            ShowForm(ProductCategoryForm);
        }

        #endregion
    }
}
