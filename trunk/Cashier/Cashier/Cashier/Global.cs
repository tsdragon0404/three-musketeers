using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cashier
{
    public class Global
    {
        public static frmMain mainForm;
        public static ToolStripProgressBar StatusProgressBar;

        public static void ShowProgressBar(Boolean isShow)
        {
            //
        }

        public static void ShowChildForm(Form f)
        {
            f.MdiParent = mainForm;
            f.Resize += new EventHandler(childForm_Resize);
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }
        private static void childForm_Resize(object sender, EventArgs e)
        {
            Form f = ((Form)sender);
            if (f.WindowState == FormWindowState.Maximized)
            {
                f.MaximizeBox = false;
                f.MinimizeBox = false;
            }
        }
    }
}
