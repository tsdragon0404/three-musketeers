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
        private string startcell = "";
        private string endcell = "";
        
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
            }
            else
            {
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
        private void getRowCount()
        {
            //int result = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet = new Excel.Worksheet();
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(cmbSheet.SelectedIndex);
            //Excel.Range range = xlWorkSheet.UsedRange;
            int basecol = 0;
            int baserow = 0;

            bool flag = true;
            for (int i = 1; i < 5; i++)
            {
                if (flag == false)
                    break;
                else
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Excel.Range range = (Excel.Range)xlWorkSheet.Cells[i, j];
                        string value_range = range.Value2 == null ? "" : range.Value2.ToString();
                        if (value_range != "")
                        {
                            baserow = i;
                            basecol = j;
                            flag = false;
                            break;
                        }
                    }
                }
            }
            int endrow=0;
            int startrow = baserow;
            int endcol=0; 
            int startcol = basecol;
            if (basecol != 0 && baserow != 0)
            {
                while (true)
                {
                    Excel.Range range2 = (Excel.Range)xlWorkSheet.Cells[baserow, startcol + 1];
                    string value = range2.Value2 == null ? "" : range2.Value2.ToString();
                    if (value == "")
                    {
                        endcol = startcol;
                        break;
                    }
                    startcol++;
                }
                while (true)
                {
                    Excel.Range range2 = (Excel.Range)xlWorkSheet.Cells[startrow + 1, basecol];
                    string value = range2.Value2 == null ? "" : range2.Value2.ToString();
                    if (value == "")
                    {
                        endrow = startrow;
                        break;
                    }
                    startrow++;
                }
            }
            startcell = ConvertToChar(basecol-1) + baserow;
            endcell = ConvertToChar(endcol - 1) + endrow;
            //result = range.Rows.Count;
        }

        private string ConvertToChar(int value)
        {
            string rs = "";
            if (value <= 25)
                rs = Convert.ToChar(value + 65).ToString();
            else
            {
                int i = value / 26;
                rs = Convert.ToChar(i + 64).ToString() + Convert.ToChar(value % 26 + 65);
            }
            return rs;
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
            getRowCount();

            string cnnstr = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + filename + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(cnnstr);
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(string.Format("select * from [{0}${1}:{2}]", cmbSheet.SelectedItem.ToString(), startcell, endcell), conn);
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

        CheckBox ckBox;
        private void bind()
        {


            dgvData.Rows.Clear();
            dgvData.Columns.Clear();

            DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn();
            //c1.Name = "selection";
            c1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c1.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns.Add(c1);

            ckBox = new CheckBox();
            //Get the column header cell bounds
            Rectangle rect = this.dgvData.GetCellDisplayRectangle(0, -1, false);
            ckBox.Size = new Size(18, 18);
            //Change the location of the CheckBox to make it stay on the header
            ckBox.Location = rect.Location;
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
            //Add the CheckBox into the DataGridView
            this.dgvData.Controls.Add(ckBox);

            //DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn();
            //chkcol.Name = "colStatus";
            //dgvData.Columns.Add(chkcol);
            foreach (DataColumn dc in dt.Columns)
            {
                DataGridViewTextBoxColumn txtcol = new DataGridViewTextBoxColumn();
                txtcol.Name = dc.ColumnName;
                txtcol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns.Add(txtcol);
            }
            DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
            dgvData.Columns.Add(imgcol);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                
            }

            for (int i = 1; i < dt.Rows.Count; i++)
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

        private void btnGetdata_Click(object sender, EventArgs e)
        {
            dt = readExcel();
            bind();
        }

        public void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.dgvData.RowCount; j++)
            {
                this.dgvData[0, j].Value = this.ckBox.Checked;
            }
            this.dgvData.EndEdit();
        }
    }
}
