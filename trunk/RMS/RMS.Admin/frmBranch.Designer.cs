namespace RMS.Admin
{
    partial class frmBranch
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
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVNName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtENName = new System.Windows.Forms.TextBox();
            this.txtSEQ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbEnable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lsbBranch = new System.Windows.Forms.ListBox();
            this.tmCRUD = new TM.UI.WindowsForms.Controls.TMCRUD();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(RMS.Core.Entities.Branch);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBranchID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtVNName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtENName);
            this.groupBox1.Controls.Add(this.txtSEQ);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckbEnable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(228, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 193);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // txtBranchID
            // 
            this.txtBranchID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "BranchID", true));
            this.txtBranchID.Location = new System.Drawing.Point(83, 31);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.ReadOnly = true;
            this.txtBranchID.Size = new System.Drawing.Size(229, 20);
            this.txtBranchID.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Branch ID";
            // 
            // txtVNName
            // 
            this.txtVNName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "VNName", true));
            this.txtVNName.Location = new System.Drawing.Point(83, 57);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Size = new System.Drawing.Size(229, 20);
            this.txtVNName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sequence";
            // 
            // txtENName
            // 
            this.txtENName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "ENName", true));
            this.txtENName.Location = new System.Drawing.Point(83, 83);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(229, 20);
            this.txtENName.TabIndex = 2;
            // 
            // txtSEQ
            // 
            this.txtSEQ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "SEQ", true));
            this.txtSEQ.Location = new System.Drawing.Point(83, 109);
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.Size = new System.Drawing.Size(53, 20);
            this.txtSEQ.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "VN Name";
            // 
            // ckbEnable
            // 
            this.ckbEnable.AutoSize = true;
            this.ckbEnable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.userBindingSource, "Enable", true));
            this.ckbEnable.Location = new System.Drawing.Point(83, 137);
            this.ckbEnable.Name = "ckbEnable";
            this.ckbEnable.Size = new System.Drawing.Size(15, 14);
            this.ckbEnable.TabIndex = 9;
            this.ckbEnable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "EN Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Enable";
            // 
            // lsbBranch
            // 
            this.lsbBranch.FormattingEnabled = true;
            this.lsbBranch.Location = new System.Drawing.Point(6, 77);
            this.lsbBranch.Name = "lsbBranch";
            this.lsbBranch.Size = new System.Drawing.Size(216, 186);
            this.lsbBranch.TabIndex = 0;
            this.lsbBranch.SelectedIndexChanged += new System.EventHandler(this.lsbBranch_SelectedIndexChanged);
            // 
            // tmCRUD
            // 
            this.tmCRUD.BackColor = System.Drawing.Color.Transparent;
            this.tmCRUD.Dock = System.Windows.Forms.DockStyle.Top;
            this.tmCRUD.Icon_Cancel = global::RMS.Admin.Properties.Resources.Cancel_icon;
            this.tmCRUD.Icon_Create = global::RMS.Admin.Properties.Resources.create_icon;
            this.tmCRUD.Icon_Delete = global::RMS.Admin.Properties.Resources.delete_file_icon;
            this.tmCRUD.Icon_Save = global::RMS.Admin.Properties.Resources.Save_icon;
            this.tmCRUD.IsAdding = false;
            this.tmCRUD.Location = new System.Drawing.Point(0, 0);
            this.tmCRUD.Name = "tmCRUD";
            this.tmCRUD.Size = new System.Drawing.Size(558, 76);
            this.tmCRUD.TabIndex = 13;
            this.tmCRUD.ButtonCreateClick += new System.EventHandler(this.btnCreateNew_Click);
            this.tmCRUD.ButtonSaveClick += new System.EventHandler(this.btnSave_Click);
            this.tmCRUD.ButtonDeleteClick += new System.EventHandler(this.btnDelete_Click);
            this.tmCRUD.ButtonCancelClick += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 295);
            this.Controls.Add(this.tmCRUD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsbBranch);
            this.Name = "frmBranch";
            this.Text = "frmBranch";
            this.Load += new System.EventHandler(this.frmBranch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbBranch;
        private System.Windows.Forms.TextBox txtVNName;
        private System.Windows.Forms.TextBox txtENName;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbEnable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSEQ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.Label label5;
        private TM.UI.WindowsForms.Controls.TMCRUD tmCRUD;
    }
}