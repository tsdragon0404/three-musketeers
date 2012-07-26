using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TMControl
{
    public partial class TMDataGridView : DataGridView
    {
        
        public TMDataGridView()
        {
            InitializeComponent();
            AlternatingRowsDefaultCellStyle.BackColor = Color.PapayaWhip;
            AlternatingRowsDefaultCellStyle.ForeColor = Color.DimGray;
            AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            RowsDefaultCellStyle.ForeColor = Color.DimGray;
            RowsDefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RowHeadersWidth = 25;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            MultiSelect = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle.Padding = new Padding(0);
            ColumnAdded += new DataGridViewColumnEventHandler(TMDataGridView_ColumnAdded);
        }

        void TMDataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }


        [Category("TM Properties")]
        [DisplayName("AutoGenerateColumns")]
        public Boolean AutoGenerateColumn{
            get { return AutoGenerateColumns; }
            set { AutoGenerateColumns= value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region Bind data to Datagrid
        public void BindData(DataTable dt)
        {
            Boolean[] columnVisible = new Boolean[dt.Columns.Count];
            for (Int32 i = 0; i < columnVisible.Count(); i++)
                columnVisible[i] = true;
            BindData(dt, columnVisible);
        }

        public void BindData(DataTable dt, Boolean[] columnVisible)
        {
            String[] columnType = new String[dt.Columns.Count];
            for (Int32 i = 0; i < columnType.Count(); i++)
                columnType[i] = "Textbox";
        }

        public void BindData(DataTable dt, Boolean[] columnVisible, String[] columnType)
        {
            try
            {
                for (Int32 i = 0; i < dt.Columns.Count; i++)
                {
                    DataGridViewColumn dgvc;
                    switch (columnType[i])
                    {
                        case "Checkbox":
                            dgvc = new DataGridViewCheckBoxColumn();
                            if (dt.Rows[0][i] != null && dt.Rows[0][i].ToString().Trim() != "")
                            {
                                switch (dt.Rows[0][i].ToString().Trim().ToLower())
                                {
                                    case "true":
                                    case "false":
                                        (dgvc as DataGridViewCheckBoxColumn).TrueValue = "true";
                                        (dgvc as DataGridViewCheckBoxColumn).FalseValue = "false";
                                        break;
                                    case "0":
                                    case "1":
                                        (dgvc as DataGridViewCheckBoxColumn).TrueValue = "1";
                                        (dgvc as DataGridViewCheckBoxColumn).FalseValue = "0";
                                        break;
                                    default:
                                        throw new TMDataGridViewException("Error when generate column [" + dt.Columns[i].ColumnName + "]: Bad input data");
                                }
                            }
                            else
                            {
                                throw new TMDataGridViewException("Error when generate column [" + dt.Columns[i].ColumnName + "]: Bad input data");
                            }
                            break;
                        case "Textbox":
                        default:
                            dgvc = new DataGridViewTextBoxColumn();
                            break;
                    }
                    dgvc.Name = dt.Columns[i].ColumnName;
                    dgvc.HeaderText = dt.Columns[i].ColumnName;
                    dgvc.DataPropertyName = dt.Columns[i].ColumnName;
                    if (!columnVisible[i])
                        dgvc.Visible = false;

                    Columns.Add(dgvc);
                }
                DataSource = dt;
            }
            catch
            {
                throw new TMDataGridViewException("Error when binding data to [" + Name + "]");
            }
        }
        #endregion
    }

    public class TMDataGridViewException : Exception
    {
        public String Message { get; set; }
        public TMDataGridViewException(String message)
        {
            Message = message;
        }
    }
}
