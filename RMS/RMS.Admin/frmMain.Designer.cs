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
            this.mItemSetup = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemProduct = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemProductCategory = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemTable = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemSystem = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemUser = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemBranch = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemConfiguration = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemLogout = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
            this.mItemExit = new TM.UI.WindowsForms.Controls.TMToolStripMenuItem();
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
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemSetup,
            this.mItemConfiguration,
            this.mItemLogout,
            this.mItemExit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mItemSetup
            // 
            this.mItemSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemProduct,
            this.mItemTable,
            this.mItemSystem});
            this.mItemSetup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mItemSetup.ForeColor = System.Drawing.Color.Black;
            this.mItemSetup.FunctionID = 0;
            this.mItemSetup.Name = "mItemSetup";
            this.mItemSetup.Size = new System.Drawing.Size(53, 21);
            this.mItemSetup.Text = "Setup";
            // 
            // mItemProduct
            // 
            this.mItemProduct.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemProductCategory});
            this.mItemProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mItemProduct.FunctionID = 0;
            this.mItemProduct.Name = "mItemProduct";
            this.mItemProduct.Size = new System.Drawing.Size(152, 22);
            this.mItemProduct.Text = "Product";
            // 
            // mItemProductCategory
            // 
            this.mItemProductCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mItemProductCategory.FunctionID = 1004;
            this.mItemProductCategory.Name = "mItemProductCategory";
            this.mItemProductCategory.Size = new System.Drawing.Size(176, 22);
            this.mItemProductCategory.Text = "Product category";
            this.mItemProductCategory.Click += new System.EventHandler(this.mItemForm_Click);
            // 
            // mItemTable
            // 
            this.mItemTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mItemTable.FunctionID = 0;
            this.mItemTable.Name = "mItemTable";
            this.mItemTable.Size = new System.Drawing.Size(152, 22);
            this.mItemTable.Text = "Table";
            // 
            // mItemSystem
            // 
            this.mItemSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemUser,
            this.mItemBranch});
            this.mItemSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mItemSystem.FunctionID = 0;
            this.mItemSystem.Name = "mItemSystem";
            this.mItemSystem.Size = new System.Drawing.Size(152, 22);
            this.mItemSystem.Text = "System";
            // 
            // mItemUser
            // 
            this.mItemUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mItemUser.FunctionID = 1001;
            this.mItemUser.Name = "mItemUser";
            this.mItemUser.Size = new System.Drawing.Size(152, 22);
            this.mItemUser.Text = "User";
            this.mItemUser.Click += new System.EventHandler(this.mItemForm_Click);
            // 
            // mItemBranch
            // 
            this.mItemBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mItemBranch.FunctionID = 1002;
            this.mItemBranch.Name = "mItemBranch";
            this.mItemBranch.Size = new System.Drawing.Size(152, 22);
            this.mItemBranch.Text = "Branch";
            this.mItemBranch.Click += new System.EventHandler(this.mItemForm_Click);
            // 
            // mItemConfiguration
            // 
            this.mItemConfiguration.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mItemConfiguration.ForeColor = System.Drawing.Color.White;
            this.mItemConfiguration.FunctionID = 0;
            this.mItemConfiguration.Name = "mItemConfiguration";
            this.mItemConfiguration.Size = new System.Drawing.Size(99, 21);
            this.mItemConfiguration.Text = "Configuration";
            // 
            // mItemLogout
            // 
            this.mItemLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mItemLogout.ForeColor = System.Drawing.Color.White;
            this.mItemLogout.FunctionID = 0;
            this.mItemLogout.Name = "mItemLogout";
            this.mItemLogout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.mItemLogout.Size = new System.Drawing.Size(61, 21);
            this.mItemLogout.Text = "&Logout";
            this.mItemLogout.Click += new System.EventHandler(this.mItemLogout_Click);
            // 
            // mItemExit
            // 
            this.mItemExit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mItemExit.ForeColor = System.Drawing.Color.White;
            this.mItemExit.FunctionID = 0;
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.mItemExit.Size = new System.Drawing.Size(40, 21);
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
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private TMToolStripMenuItem mItemLogout;
        private TMToolStripMenuItem mItemExit;
        private TMToolStripMenuItem mItemSetup;
        private TMToolStripMenuItem mItemTable;
        private TMToolStripMenuItem mItemProduct;
        private TMToolStripMenuItem mItemConfiguration;
        private TMToolStripMenuItem mItemSystem;
        private TMToolStripMenuItem mItemUser;
        private TMToolStripMenuItem mItemBranch;
        private TMToolStripMenuItem mItemProductCategory;
    }
}



