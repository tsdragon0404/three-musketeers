namespace RMS.Admin
{
    partial class frmProduct
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckbEnable = new System.Windows.Forms.CheckBox();
            this.lblEnable = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.Sequence = new System.Windows.Forms.Label();
            this.txtSEQ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtENDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVNDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtENName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVNName = new System.Windows.Forms.TextBox();
            this.cmbProductCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbProduct = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tmCRUD = new TM.UI.WindowsForms.Controls.TMCRUD();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.ckbEnable);
            this.groupBox1.Controls.Add(this.lblEnable);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.Sequence);
            this.groupBox1.Controls.Add(this.txtSEQ);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtENDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtVNDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtENName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtVNName);
            this.groupBox1.Controls.Add(this.cmbProductCategory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(249, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 348);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Product ID";
            // 
            // txtProductID
            // 
            this.txtProductID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ProductID", true));
            this.txtProductID.Location = new System.Drawing.Point(113, 31);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(82, 20);
            this.txtProductID.TabIndex = 16;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(RMS.Core.Entities.Product);
            // 
            // ckbEnable
            // 
            this.ckbEnable.AutoSize = true;
            this.ckbEnable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.productBindingSource, "Enable", true));
            this.ckbEnable.Location = new System.Drawing.Point(113, 218);
            this.ckbEnable.Name = "ckbEnable";
            this.ckbEnable.Size = new System.Drawing.Size(15, 14);
            this.ckbEnable.TabIndex = 15;
            this.ckbEnable.UseVisualStyleBackColor = true;
            // 
            // lblEnable
            // 
            this.lblEnable.AutoSize = true;
            this.lblEnable.Location = new System.Drawing.Point(19, 218);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(40, 13);
            this.lblEnable.TabIndex = 14;
            this.lblEnable.Text = "Enable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Unit";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.productBindingSource, "UnitID", true));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(113, 188);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(82, 21);
            this.cmbUnit.TabIndex = 12;
            // 
            // Sequence
            // 
            this.Sequence.AutoSize = true;
            this.Sequence.Location = new System.Drawing.Point(19, 241);
            this.Sequence.Name = "Sequence";
            this.Sequence.Size = new System.Drawing.Size(56, 13);
            this.Sequence.TabIndex = 11;
            this.Sequence.Text = "Sequence";
            // 
            // txtSEQ
            // 
            this.txtSEQ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "SEQ", true));
            this.txtSEQ.Location = new System.Drawing.Point(113, 238);
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.Size = new System.Drawing.Size(82, 20);
            this.txtSEQ.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "EN description";
            // 
            // txtENDescription
            // 
            this.txtENDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ENDescription", true));
            this.txtENDescription.Location = new System.Drawing.Point(113, 162);
            this.txtENDescription.Name = "txtENDescription";
            this.txtENDescription.Size = new System.Drawing.Size(264, 20);
            this.txtENDescription.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "VN description";
            // 
            // txtVNDescription
            // 
            this.txtVNDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "VNDescription", true));
            this.txtVNDescription.Location = new System.Drawing.Point(113, 136);
            this.txtVNDescription.Name = "txtVNDescription";
            this.txtVNDescription.Size = new System.Drawing.Size(264, 20);
            this.txtVNDescription.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "EN name";
            // 
            // txtENName
            // 
            this.txtENName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ENName", true));
            this.txtENName.Location = new System.Drawing.Point(113, 110);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(264, 20);
            this.txtENName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "VN name";
            // 
            // txtVNName
            // 
            this.txtVNName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "VNName", true));
            this.txtVNName.Location = new System.Drawing.Point(113, 84);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Size = new System.Drawing.Size(264, 20);
            this.txtVNName.TabIndex = 2;
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.productBindingSource, "ProductCategoryID", true));
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Location = new System.Drawing.Point(113, 57);
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(264, 21);
            this.cmbProductCategory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product category";
            // 
            // lsbProduct
            // 
            this.lsbProduct.FormattingEnabled = true;
            this.lsbProduct.Location = new System.Drawing.Point(6, 102);
            this.lsbProduct.Name = "lsbProduct";
            this.lsbProduct.Size = new System.Drawing.Size(237, 316);
            this.lsbProduct.TabIndex = 18;
            this.lsbProduct.SelectedIndexChanged += new System.EventHandler(this.lsbProduct_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 77);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(237, 20);
            this.txtSearch.TabIndex = 12;
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
            this.tmCRUD.Size = new System.Drawing.Size(658, 77);
            this.tmCRUD.TabIndex = 19;
            this.tmCRUD.ButtonCreateClick += new System.EventHandler(this.btnCreateNew_Click);
            this.tmCRUD.ButtonSaveClick += new System.EventHandler(this.btnSave_Click);
            this.tmCRUD.ButtonDeleteClick += new System.EventHandler(this.btnDelete_Click);
            this.tmCRUD.ButtonCancelClick += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 430);
            this.Controls.Add(this.tmCRUD);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lsbProduct);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProduct";
            this.Text = "frmProduct";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lsbProduct;
        private System.Windows.Forms.Label Sequence;
        private System.Windows.Forms.TextBox txtSEQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtENDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVNDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtENName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVNName;
        private System.Windows.Forms.ComboBox cmbProductCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.CheckBox ckbEnable;
        private System.Windows.Forms.Label lblEnable;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductID;
        private TM.UI.WindowsForms.Controls.TMCRUD tmCRUD;
    }
}