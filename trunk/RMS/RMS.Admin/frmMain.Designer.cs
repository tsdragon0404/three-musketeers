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
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemProduct,
            this.mItemTable,
            this.systemToolStripMenuItem1});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.systemToolStripMenuItem.Text = "Setup";
            // 
            // mItemProduct
            // 
            this.mItemProduct.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemProductCategory});
            this.mItemProduct.Name = "mItemProduct";
            this.mItemProduct.Size = new System.Drawing.Size(116, 22);
            this.mItemProduct.Text = "Product";
            // 
            // mItemProductCategory
            // 
            this.mItemProductCategory.Name = "mItemProductCategory";
            this.mItemProductCategory.Size = new System.Drawing.Size(165, 22);
            this.mItemProductCategory.Text = "Product category";
            this.mItemProductCategory.Click += new System.EventHandler(this.mItemProductCategory_Click);
            // 
            // mItemTable
            // 
            this.mItemTable.Name = "mItemTable";
            this.mItemTable.Size = new System.Drawing.Size(116, 22);
            this.mItemTable.Text = "Table";
            // 
            // systemToolStripMenuItem1
            // 
            this.systemToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemUser,
            this.mItemBranch});
            this.systemToolStripMenuItem1.Name = "systemToolStripMenuItem1";
            this.systemToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.systemToolStripMenuItem1.Text = "System";
            // 
            // mItemUser
            // 
            this.mItemUser.Name = "mItemUser";
            this.mItemUser.Size = new System.Drawing.Size(111, 22);
            this.mItemUser.Text = "User";
            this.mItemUser.Click += new System.EventHandler(this.mItemUsers_Click);
            // 
            // mItemBranch
            // 
            this.mItemBranch.Name = "mItemBranch";
            this.mItemBranch.Size = new System.Drawing.Size(111, 22);
            this.mItemBranch.Text = "Branch";
            this.mItemBranch.Click += new System.EventHandler(this.mItemBranch_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // mItemLogout
            // 
            this.mItemLogout.Name = "mItemLogout";
            this.mItemLogout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.mItemLogout.Size = new System.Drawing.Size(57, 20);
            this.mItemLogout.Text = "&Logout";
            this.mItemLogout.Click += new System.EventHandler(this.mItemLogout_Click);
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.mItemExit.Size = new System.Drawing.Size(37, 20);
            this.mItemExit.Text = "E&xit";
            this.mItemExit.Click += new System.EventHandler(this.mItemExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "frmMain";
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



