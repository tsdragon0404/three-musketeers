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
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
            MinimizeBox = false;
        }

        private void frmImport_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                MaximizeBox = false;
        }
    }
}
