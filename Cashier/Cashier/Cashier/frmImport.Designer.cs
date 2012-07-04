namespace Cashier
{
    partial class frmImport
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
            this.btnGetdata = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cmbSheet = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblSheet = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblImport = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.ofdInput = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetdata
            // 
            this.btnGetdata.Enabled = false;
            this.btnGetdata.Location = new System.Drawing.Point(340, 59);
            this.btnGetdata.Name = "btnGetdata";
            this.btnGetdata.Size = new System.Drawing.Size(75, 23);
            this.btnGetdata.TabIndex = 6;
            this.btnGetdata.Text = "Get data";
            this.btnGetdata.UseVisualStyleBackColor = true;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(287, 61);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(47, 20);
            this.txtTo.TabIndex = 5;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(234, 61);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(47, 20);
            this.txtFrom.TabIndex = 4;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(19, 88);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(396, 340);
            this.dgvData.TabIndex = 7;
            // 
            // cmbSheet
            // 
            this.cmbSheet.FormattingEnabled = true;
            this.cmbSheet.Location = new System.Drawing.Point(74, 61);
            this.cmbSheet.Name = "cmbSheet";
            this.cmbSheet.Size = new System.Drawing.Size(121, 21);
            this.cmbSheet.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(340, 33);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(74, 35);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(260, 20);
            this.txtFilename.TabIndex = 1;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(16, 38);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(52, 13);
            this.lblFilename.TabIndex = 14;
            this.lblFilename.Text = "File name";
            // 
            // lblSheet
            // 
            this.lblSheet.AutoSize = true;
            this.lblSheet.Location = new System.Drawing.Point(16, 64);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(35, 13);
            this.lblSheet.TabIndex = 15;
            this.lblSheet.Text = "Sheet";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(120, 434);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 16;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(234, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(16, 11);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(36, 13);
            this.lblImport.TabIndex = 19;
            this.lblImport.Text = "Import";
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(74, 8);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(121, 21);
            this.cmbTable.TabIndex = 18;
            // 
            // ofdInput
            // 
            this.ofdInput.DefaultExt = "xlsx";
            this.ofdInput.Filter = "Excel files (*.xlsx, *.xls)|*.xlsx;*.xls";
            this.ofdInput.Title = "Select a file to import";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 469);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblSheet);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnGetdata);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.cmbSheet);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilename);
            this.Name = "frmImport";
            this.Text = "frmImport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetdata;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cmbSheet;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblSheet;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.OpenFileDialog ofdInput;
    }
}