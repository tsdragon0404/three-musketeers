using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cashier
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            showChildForm(frm);
        }

        #region show form
        private void showChildForm(Form f)
        {
            f.MdiParent = this;
            f.Resize += new EventHandler(childForm_Resize);
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void childForm_Resize(object sender, EventArgs e)
        {
            Form f = ((Form)sender);
            if (f.WindowState == FormWindowState.Maximized)
            {
                f.MaximizeBox = false;
                f.MinimizeBox = false;
            }
        }
        #endregion
    }
}
