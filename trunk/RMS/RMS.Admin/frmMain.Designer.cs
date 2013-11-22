using TM.UI.WindowsForms.Controls;

namespace RMS.Admin
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new TM.UI.WindowsForms.Controls.TMMenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemProductCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemTable = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(160)))), ((int)(((byte)(218)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.mItemLogout,
            this.mItemExit});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemProduct,
            this.mItemTable,
            this.systemToolStripMenuItem1});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            resources.ApplyResources(this.systemToolStripMenuItem, "systemToolStripMenuItem");
            // 
            // mItemProduct
            // 
            this.mItemProduct.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemProductCategory});
            this.mItemProduct.Name = "mItemProduct";
            resources.ApplyResources(this.mItemProduct, "mItemProduct");
            // 
            // mItemProductCategory
            // 
            this.mItemProductCategory.Name = "mItemProductCategory";
            resources.ApplyResources(this.mItemProductCategory, "mItemProductCategory");
            this.mItemProductCategory.Click += new System.EventHandler(this.mItemProductCategory_Click);
            // 
            // mItemTable
            // 
            this.mItemTable.Name = "mItemTable";
            resources.ApplyResources(this.mItemTable, "mItemTable");
            // 
            // systemToolStripMenuItem1
            // 
            this.systemToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemUser,
            this.mItemBranch});
            this.systemToolStripMenuItem1.Name = "systemToolStripMenuItem1";
            resources.ApplyResources(this.systemToolStripMenuItem1, "systemToolStripMenuItem1");
            // 
            // mItemUser
            // 
            this.mItemUser.Name = "mItemUser";
            resources.ApplyResources(this.mItemUser, "mItemUser");
            this.mItemUser.Click += new System.EventHandler(this.mItemUsers_Click);
            // 
            // mItemBranch
            // 
            this.mItemBranch.Name = "mItemBranch";
            resources.ApplyResources(this.mItemBranch, "mItemBranch");
            this.mItemBranch.Click += new System.EventHandler(this.mItemBranch_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            resources.ApplyResources(this.configurationToolStripMenuItem, "configurationToolStripMenuItem");
            // 
            // mItemLogout
            // 
            this.mItemLogout.Name = "mItemLogout";
            resources.ApplyResources(this.mItemLogout, "mItemLogout");
            this.mItemLogout.Click += new System.EventHandler(this.mItemLogout_Click);
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            resources.ApplyResources(this.mItemExit, "mItemExit");
            this.mItemExit.Click += new System.EventHandler(this.mItemExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private TMMenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mItemLogout;
        private System.Windows.Forms.ToolStripMenuItem mItemExit;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemTable;
        private System.Windows.Forms.ToolStripMenuItem mItemProduct;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mItemUser;
        private System.Windows.Forms.ToolStripMenuItem mItemBranch;
        private System.Windows.Forms.ToolStripMenuItem mItemProductCategory;
    }
}



