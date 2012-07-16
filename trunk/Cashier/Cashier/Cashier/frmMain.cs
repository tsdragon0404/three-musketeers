using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cashier.Command;

namespace Cashier
{
    public partial class frmMain : Form
    {
        MainCommandManager CmdManager;
        MenuStrip mainMenu;

        // Menu list load from Database
        DataTable lstMenu;

        public frmMain()
        {
            InitializeComponent();
            Global.mainForm = this;
            InitTable();
            CmdManager = new MainCommandManager(lstMenu);

            InitializeMenu();
        }
        private void InitializeMenu()
        {
            this.SuspendLayout();

            mainMenu = CmdManager.GenerateMenu();
            this.Controls.Add(mainMenu);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitTable()
        {
            lstMenu = new DataTable();
            lstMenu.Columns.AddRange(new DataColumn[] { 
                new DataColumn("ID"), new DataColumn("Name"), new DataColumn("MenuGroupEnumValue"), new DataColumn("MenuCommandEnumValue"), 
                new DataColumn("Parent"), new DataColumn("Order"), new DataColumn("Image"), new DataColumn("ModuleID"), new DataColumn("IsGroup") });

            // hỗ trợ menu và 1 cấp menu con, ko hỗ trợ command ở lv0
            // lv0 = group; lv1 = command
            // order by Order asc then by Parent (asc)
            DataRow dr = lstMenu.NewRow();
            dr["ID"] = 1;
            dr["Name"] = "&File";
            dr["MenuGroupEnumValue"] = 1;
            dr["MenuCommandEnumValue"] = 0;
            dr["Parent"] = 0;
            dr["Order"] = 1;
            dr["Image"] = "MenuTool.png";
            dr["ModuleID"] = "1";
            dr["IsGroup"] = "1";

            DataRow dr2 = lstMenu.NewRow();
            dr2["ID"] = 2;
            dr2["Name"] = "More";
            dr2["MenuGroupEnumValue"] = 1;
            dr2["MenuCommandEnumValue"] = 0;
            dr2["Parent"] = 0;
            dr2["Order"] = 3;
            dr2["Image"] = "";
            dr2["ModuleID"] = "2";
            dr2["IsGroup"] = "1";

            DataRow dr4 = lstMenu.NewRow();
            dr4["ID"] = 4;
            dr4["Name"] = "More";
            dr4["MenuGroupEnumValue"] = 1;
            dr4["MenuCommandEnumValue"] = 0;
            dr4["Parent"] = 2;
            dr4["Order"] = 4;
            dr4["Image"] = "MenuTool.png";
            dr4["ModuleID"] = "2";
            dr4["IsGroup"] = "1";

            DataRow dr3 = lstMenu.NewRow();
            dr3["ID"] = 3;
            dr3["Name"] = "E&xit";
            dr3["MenuGroupEnumValue"] = 1;
            dr3["MenuCommandEnumValue"] = 1;
            dr3["Parent"] = 4;
            dr3["Order"] = 5;
            dr3["Image"] = "CmdExit.png";
            dr3["ModuleID"] = "2";
            dr3["IsGroup"] = "0";

            DataRow dr5 = lstMenu.NewRow();
            dr5["ID"] = 5;
            dr5["Name"] = "E&xit";
            dr5["MenuGroupEnumValue"] = 1;
            dr5["MenuCommandEnumValue"] = 1;
            dr5["Parent"] = 1;
            dr5["Order"] = 5;
            dr5["Image"] = "CmdExit.png";
            dr5["ModuleID"] = "1";
            dr5["IsGroup"] = "0";

            lstMenu.Rows.Add(dr);
            lstMenu.Rows.Add(dr5);
            lstMenu.Rows.Add(dr2);
            lstMenu.Rows.Add(dr4);
            lstMenu.Rows.Add(dr3);
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
