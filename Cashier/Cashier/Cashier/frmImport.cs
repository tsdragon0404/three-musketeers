using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Cashier
{
    public partial class frmImport : Form
    {
        private string table = "";
        private string filename = "";
        private List<int> rowcount;
        private List<string> sheetList;
        private DataTable dt;
        
        public frmImport()
        {
            InitializeComponent();
        }
        public frmImport(string table)
        {
            InitializeComponent();
            this.table = table;
            cmbTable.Enabled = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                if (dgvData.Rows[i].Cells["colStatus"].Value.ToString().ToLower() == "true")
                {
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    filename = ofdInput.FileName;
                    txtFilename.Text = filename;
                    sheetList = getSheetList(out rowcount);
                    cmbSheet.DataSource = sheetList;
                    cmbSheet.SelectedIndexChanged += new EventHandler(cmbSheet_SelectedIndexChanged);
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }
        void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSheet.SelectedIndex == 0 || cmbSheet.SelectedIndex == -1)
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                txtFrom.Text = "";
                txtTo.Text = "";
            }
            else
            {
                txtFrom.Text = "A1";
                txtTo.Text = "Z" + rowcount[cmbSheet.SelectedIndex];
                btnGetdata.Enabled = true;
                dt = readExcel();
                bind();
            }
        }
        private List<string> getSheetList(out List<int> rowcount)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet = new Excel.Worksheet();
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);


            List<string> result = new List<string>();
            result.Add("-------------");
            rowcount = new List<int>();
            rowcount.Add(0);
            for (int i = 0; i < xlWorkBook.Worksheets.Count; i++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(i + 1);
                result.Add(xlWorkSheet.Name);
                rowcount.Add(xlWorkSheet.UsedRange.Rows.Count);
            }

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            return result;
        }
        private int getRowCount()
        {
            int result = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet = new Excel.Worksheet();
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(cmbSheet.SelectedIndex);
            Excel.Range range = xlWorkSheet.UsedRange;
            result = range.Rows.Count;
            return result;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private DataTable readExcel()
        {
            string cnnstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(cnnstr);
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(string.Format("select * from [{0}${1}:{2}]", cmbSheet.SelectedItem.ToString(), txtFrom.Text, txtTo.Text), conn);
            conn.Open();
            System.Data.OleDb.OleDbDataAdapter adap = new System.Data.OleDb.OleDbDataAdapter(cmd);
            DataTable tb = new DataTable();
            adap.Fill(tb);
            return tb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = readExcel();
            bind();
        }
        private void bind()
        {
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();

            DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn();
            chkcol.Name = "colStatus";
            dgvData.Columns.Add(chkcol);
            foreach (DataColumn dc in dt.Columns)
            {
                DataGridViewTextBoxColumn txtcol = new DataGridViewTextBoxColumn();
                txtcol.Name = dc.ColumnName;
                dgvData.Columns.Add(txtcol);
            }
            DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
            dgvData.Columns.Add(imgcol);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(dgvData);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dgvr.Cells[0].Value = true;
                    dgvr.Cells[j + 1].Value = dt.Rows[i][j].ToString();
                }
                dgvData.Rows.Add(dgvr);
            }
        }
    }
}
