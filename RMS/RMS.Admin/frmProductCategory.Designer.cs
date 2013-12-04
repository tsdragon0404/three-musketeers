namespace RMS.Admin
{
    partial class frmProductCategory
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
            this.lsbProductCategory = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbEnable = new System.Windows.Forms.CheckBox();
            this.productCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSEQ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtENDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVNDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtENName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVNName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductCategoryID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tmCRUD = new TM.UI.WindowsForms.Controls.TMCRUD();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbProductCategory
            // 
            this.lsbProductCategory.FormattingEnabled = true;
            this.lsbProductCategory.Location = new System.Drawing.Point(6, 77);
            this.lsbProductCategory.Name = "lsbProductCategory";
            this.lsbProductCategory.Size = new System.Drawing.Size(237, 225);
            this.lsbProductCategory.TabIndex = 17;
            this.lsbProductCategory.SelectedIndexChanged += new System.EventHandler(this.lsbProductCategory_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbEnable);
            this.groupBox1.Controls.Add(this.txtSEQ);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtENDescription);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtVNDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtENName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVNName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductCategoryID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(249, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 231);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // ckbEnable
            // 
            this.ckbEnable.AutoSize = true;
            this.ckbEnable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.productCategoryBindingSource, "Enable", true));
            this.ckbEnable.Location = new System.Drawing.Point(106, 157);
            this.ckbEnable.Name = "ckbEnable";
            this.ckbEnable.Size = new System.Drawing.Size(15, 14);
            this.ckbEnable.TabIndex = 14;
            this.ckbEnable.UseVisualStyleBackColor = true;
            // 
            // productCategoryBindingSource
            // 
            this.productCategoryBindingSource.DataSource = typeof(RMS.Core.Entities.ProductCategory);
            // 
            // txtSEQ
            // 
            this.txtSEQ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productCategoryBindingSource, "SEQ", true));
            this.txtSEQ.Location = new System.Drawing.Point(106, 180);
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.Size = new System.Drawing.Size(59, 20);
            this.txtSEQ.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Sequence";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Enable";
            // 
            // txtENDescription
            // 
            this.txtENDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productCategoryBindingSource, "ENDescription", true));
            this.txtENDescription.Location = new System.Drawing.Point(106, 128);
            this.txtENDescription.Name = "txtENDescription";
            this.txtENDescription.Size = new System.Drawing.Size(258, 20);
            this.txtENDescription.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "EN description";
            // 
            // txtVNDescription
            // 
            this.txtVNDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productCategoryBindingSource, "VNDescription", true));
            this.txtVNDescription.Location = new System.Drawing.Point(106, 102);
            this.txtVNDescription.Name = "txtVNDescription";
            this.txtVNDescription.Size = new System.Drawing.Size(258, 20);
            this.txtVNDescription.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "VN description";
            // 
            // txtENName
            // 
            this.txtENName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productCategoryBindingSource, "ENName", true));
            this.txtENName.Location = new System.Drawing.Point(106, 76);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(258, 20);
            this.txtENName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "EN name";
            // 
            // txtVNName
            // 
            this.txtVNName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productCategoryBindingSource, "VNName", true));
            this.txtVNName.Location = new System.Drawing.Point(106, 50);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Size = new System.Drawing.Size(258, 20);
            this.txtVNName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "VN name";
            // 
            // txtProductCategoryID
            // 
            this.txtProductCategoryID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productCategoryBindingSource, "ProductCategoryID", true));
            this.txtProductCategoryID.Location = new System.Drawing.Point(106, 24);
            this.txtProductCategoryID.Name = "txtProductCategoryID";
            this.txtProductCategoryID.ReadOnly = true;
            this.txtProductCategoryID.Size = new System.Drawing.Size(59, 20);
            this.txtProductCategoryID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
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
            this.tmCRUD.Size = new System.Drawing.Size(643, 77);
            this.tmCRUD.TabIndex = 19;
            this.tmCRUD.ButtonCreateClick += new System.EventHandler(this.btnCreateNew_Click);
            this.tmCRUD.ButtonSaveClick += new System.EventHandler(this.btnSave_Click);
            this.tmCRUD.ButtonDeleteClick += new System.EventHandler(this.btnDelete_Click);
            this.tmCRUD.ButtonCancelClick += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmProductCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 342);
            this.Controls.Add(this.tmCRUD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsbProductCategory);
            this.Name = "frmProductCategory";
            this.Text = "frmProductCategory";
            this.Load += new System.EventHandler(this.frmProductCategory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbProductCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckbEnable;
        private System.Windows.Forms.TextBox txtSEQ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtENDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVNDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtENName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVNName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductCategoryID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource productCategoryBindingSource;
        private TM.UI.WindowsForms.Controls.TMCRUD tmCRUD;
    }
}