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
    /// <summary>
    /// TM class support display data in a customizable grid
    /// </summary>
    public partial class TMDataGridView : DataGridView
    {
        #region Enum
        public enum ColumnType
        {
            Textbox,
            Checkbox,
            Combobox
        }
        #endregion

        #region Properties
        [Category("TM Properties")]
        [DisplayName("AutoGenerateColumns")]
        [Description("Indicates whether the columns will be auto generated base on the datasource")]
        public Boolean AutoGenerateColumn{
            get { return AutoGenerateColumns; }
            set { AutoGenerateColumns= value; Invalidate(); }
        }

        private Boolean _allowColumnSorting = false;
        [Category("TM Properties")]
        [DisplayName("AllowColumnSorting")]
        [Description("Indicates whether the user can sort the display data by click on the column header")]
        public Boolean AllowColumnSorting
        {
            get { return _allowColumnSorting; }
            set 
            { 
                _allowColumnSorting = value; 
                Invalidate(); 
                if (_allowColumnSorting == false)
                    ColumnAdded += new DataGridViewColumnEventHandler(TMDataGridView_ColumnAdded);
                else
                    ColumnAdded -= new DataGridViewColumnEventHandler(TMDataGridView_ColumnAdded);
            }
        }
        #endregion

        /// <summary>
        /// Default constructor of TMDataGridView class
        /// </summary>
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
        }

        #region Events
        void TMDataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        #endregion

        #region Bind data to Datagrid
        /// <summary>
        /// Bind data to TMDataGridView
        /// </summary>
        /// <param name="dt">A datatable contains display data</param>
        public void BindData(DataTable dt)
        {
            BindData(dt, new String[] { });
        }

        public void BindData(DataTable dt, String[] headerText)
        {
            Boolean[] columnVisible = new Boolean[dt.Columns.Count];
            for (Int32 i = 0; i < columnVisible.Count(); i++)
                columnVisible[i] = true;
            BindData(dt, headerText, columnVisible);
        }

        /// <summary>
        /// Bind data to TMDataGridView
        /// </summary>
        /// <param name="dt">A datatable contains display data</param>
        /// <param name="columnVisible">Boolean array contains key for show/hide columns. This array length must be equal to the datasource column number</param>
        public void BindData(DataTable dt, String[] headerText, Boolean[] columnVisible)
        {
            ColumnType[] columnType = new ColumnType[dt.Columns.Count];
            for (Int32 i = 0; i < columnType.Count(); i++)
                columnType[i] = ColumnType.Textbox;
            BindData(dt, headerText, columnVisible, columnType);
        }

        /// <summary>
        /// Bind data to TMDataGridView
        /// </summary>
        /// <param name="dt">A datatable contains display data</param>
        /// <param name="columnVisible">Boolean array contains key for show/hide columns.\n This array length must be equal to the datasource column number</param>
        /// <param name="columnType">String array </param>
        public void BindData(DataTable dt, String[] headerText, Boolean[] columnVisible, ColumnType[] columnType)
        {
            ComboBoxData[] comboBoxData = new ComboBoxData[]{};
            BindData(dt, headerText, columnVisible, columnType, comboBoxData);
        }

        public void BindData(DataTable dt, String[] headerText, Boolean[] columnVisible, ColumnType[] columnType, ComboBoxData[] comboBoxData)
        {
            try
            {
                if (dt.Columns.Count != columnType.Length)
                    throw new TMDataGridViewException(Name, "Datasource column number & columnType array length does not match");
                if (dt.Columns.Count != columnVisible.Length)
                    throw new TMDataGridViewException(Name, "Datasource column number & columnVisible array length does not match");
                if (headerText.Length != 0 && dt.Columns.Count != headerText.Length)
                    throw new TMDataGridViewException(Name, "Datasource column number & headerText array length does not match");
                if (dt.Columns.Count != comboBoxData.Length)
                    throw new TMDataGridViewException(Name, "Datasource column number & comboBoxData array length does not match");
                
                for (Int32 i = 0; i < dt.Columns.Count; i++)
                {
                    try
                    {
                        DataGridViewColumn dgvc;
                        switch (columnType[i])
                        {
                            case ColumnType.Combobox:
                                dgvc = new DataGridViewComboBoxColumn();
                                (dgvc as DataGridViewComboBoxColumn).DataSource = comboBoxData[i].Datasource;
                                (dgvc as DataGridViewComboBoxColumn).DisplayMember = comboBoxData[i].DisplayMember;
                                (dgvc as DataGridViewComboBoxColumn).DataPropertyName = comboBoxData[i].DataMember;
                                break;
                            case ColumnType.Checkbox:
                                dgvc = new DataGridViewCheckBoxColumn();
                                if (!String.IsNullOrEmpty(dt.Rows[0][i].ToString()))
                                {
                                    switch (dt.Rows[0][i].ToString().Trim().ToLower())
                                    {
                                        case "true":
                                        case "false":
                                            (dgvc as DataGridViewCheckBoxColumn).TrueValue = "true";
                                            (dgvc as DataGridViewCheckBoxColumn).FalseValue = "false";
                                            break;
                                        case "1":
                                        case "0":
                                            (dgvc as DataGridViewCheckBoxColumn).TrueValue = "1";
                                            (dgvc as DataGridViewCheckBoxColumn).FalseValue = "0";
                                            break;
                                        default:
                                            throw new TMDataGridViewColumnException(Name, i, dt.Columns[i].ColumnName);
                                    }
                                }
                                else
                                    throw new TMDataGridViewColumnException(Name, i, dt.Columns[i].ColumnName);
                                break;
                            case ColumnType.Textbox:
                            default:
                                dgvc = new DataGridViewTextBoxColumn();
                                break;
                        }
                        dgvc.Name = dt.Columns[i].ColumnName;
                        dgvc.DataPropertyName = dt.Columns[i].ColumnName;
                        if (headerText.Length == 0)
                            dgvc.HeaderText = headerText[i];
                        else
                            dgvc.HeaderText = dt.Columns[i].ColumnName;
                        if (!columnVisible[i])
                            dgvc.Visible = false;

                        Columns.Add(dgvc);
                    }
                    catch
                    {
                        throw new TMDataGridViewColumnException(Name, i, dt.Columns[i].ColumnName);
                    }
                }
                DataSource = dt;
            }
            catch
            {
                throw new TMDataGridViewException(Name, "Error when binding data");
            }
        }

        /// <summary>
        /// Show or hide a column in TMDataGridView
        /// </summary>
        /// <param name="index">Column index</param>
        /// <param name="visible">Determines whether the column is visible or hidden</param>
        public void SetColumnVisible(Int32 index, Boolean visible)
        {
            Columns[index].Visible = visible;
        }
        #endregion
    }

    /// <summary>
    /// Class contains data for combobox in TMDataGridView
    /// </summary>
    public class ComboBoxData
    {
        #region Properties
        /// <summary>
        /// Gets or sets data property name
        /// </summary>
        public String DataMember { get; set; }

        /// <summary>
        /// Gets or sets display member
        /// </summary>
        public String DisplayMember { get; set; }

        private DataTable _datasource;
        /// <summary>
        /// Gets or set data source
        /// </summary>
        public DataTable Datasource { get { return _datasource; } set { _datasource = value; _length = _datasource.Rows.Count; } }

        private Int32 _length = -1;
        /// <summary>
        /// Gets the data source length
        /// </summary>
        public Int32 Length { get { return _length; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TMControl.ComboBoxData
        /// </summary>
        public ComboBoxData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TMControl.ComboBoxData
        /// </summary>
        /// <param name="dataMember">The data property name of ComboBox</param>
        /// <param name="displayMember">The display member of ComboBox</param>
        /// <param name="datasource">The data source of ComboBox</param>
        public ComboBoxData(String dataMember, String displayMember, DataTable datasource)
        {
            DataMember = dataMember;
            DisplayMember = displayMember;
            Datasource = datasource;
        }
        #endregion

        #region Methods
        public Boolean IsValid()
        {
            return !String.IsNullOrEmpty(DataMember) && !String.IsNullOrEmpty(DisplayMember) && Length > 0;
        }
        #endregion
    }

    /// <summary>
    /// Represents errors that occur with TMDataGridView during application execution
    /// </summary>
    public class TMDataGridViewException : Exception
    {
        #region Properties
        //private String _message = String.Empty;
        ///// <summary>
        ///// The message that describe the current exception
        ///// </summary>
        //public new String Message { get { return _message; } }

        private String _dataGridName = String.Empty;
        /// <summary>
        /// Gets the error TMDataGridView name
        /// </summary>
        public String DataGridName { get { return _dataGridName; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewException
        /// </summary>
        public TMDataGridViewException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewException
        /// </summary>
        /// <param name="gridName">The name of error TMDataGridView</param>
        public TMDataGridViewException(String gridName)
        {
            _dataGridName = gridName;
        }

        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewException
        /// </summary>
        /// <param name="gridName">The name of error TMDataGridView</param>
        /// <param name="message">The message that describe the error</param>
        public TMDataGridViewException(String gridName, String message)
            : base(message)
        {
            _dataGridName = gridName;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the message that describe the current exception
        /// </summary>
        /// <returns>String contain error message</returns>
        public virtual String GetMessage()
        {
            String gridname = String.Empty;
            if (!String.IsNullOrEmpty(_dataGridName))
                gridname = "[" + _dataGridName + "] - ";
            String msg = Message;
            if (!String.IsNullOrEmpty(msg))
                msg = "Error occur in TMDataGridView";
            return gridname + msg;
        }
        #endregion
    }

    /// <summary>
    /// Represents errors that occur with TMDataGridView Column during application execution
    /// </summary>
    public class TMDataGridViewColumnException : TMDataGridViewException
    {
        #region Properties
        private Int32 _columnIndex = -1;
        /// <summary>
        /// Gets the error column index of TMDataGridView
        /// </summary>
        public Int32 ColumnIndex { get { return _columnIndex; } }

        private String _columnName = String.Empty;
        /// <summary>
        /// Gets the error column name of TMDataGridView
        /// </summary>
        public String ColumnName { get { return _columnName; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewColumnException
        /// </summary>
        public TMDataGridViewColumnException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewColumnException
        /// </summary>
        /// <param name="gridName">The name of error TMDataGridView</param>
        public TMDataGridViewColumnException(String gridName)
            : base(gridName) { }

        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewColumnException
        /// </summary>
        /// <param name="gridName">The name of error TMDataGridView</param>
        /// <param name="columnIndex">The index of error column in TMDataGridView</param>
        public TMDataGridViewColumnException(String gridName, Int32 columnIndex)
            : base(gridName) 
        {
            _columnIndex = columnIndex;
        }

        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewColumnException
        /// </summary>
        /// <param name="gridName">The name of error TMDataGridView</param>
        /// <param name="columnName">The name of error column in TMDataGridView</param>
        public TMDataGridViewColumnException(String gridName, String columnName)
            : base(gridName)
        {
            _columnName = columnName;
        }

        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewColumnException
        /// </summary>
        /// <param name="gridName">The name of error TMDataGridView</param>
        /// <param name="columnIndex">The index of error column in TMDataGridView</param>
        /// <param name="columnName">The name of error column in TMDataGridView</param>
        public TMDataGridViewColumnException(String gridName, Int32 columnIndex, String columnName)
            : this(gridName, columnIndex)
        {
            _columnName = columnName;
        }

        /// <summary>
        /// Initializes a new instance of the TMControl.TMDataGridViewColumnException
        /// </summary>
        /// <param name="gridName">The name of error TMDataGridView</param>
        /// <param name="columnIndex">The index of error column in TMDataGridView</param>
        /// <param name="columnName">The name of error column in TMDataGridView</param>
        /// <param name="message">The message that describe the error</param>
        public TMDataGridViewColumnException(String gridName, Int32 columnIndex, String columnName, String message)
            : base(gridName, message)
        {
            _columnIndex = columnIndex;
            _columnName = columnName;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the message that describe the current exception
        /// </summary>
        /// <returns>String contain error message</returns>
        public override String GetMessage()
        {
            String baseMessage = base.GetMessage();
            if(String.IsNullOrEmpty(Message))
                baseMessage = baseMessage.Replace("Error occur in TMDataGridView", 
                    "Error occur when generate column in TMDataGridView");
            baseMessage += " column #{0}: [{1}]";
            return String.Format(baseMessage, _columnIndex == -1 ? "Undefined" : _columnIndex.ToString(), 
                String.IsNullOrEmpty(_columnName) ? "Undefined" : _columnName);
        }
        #endregion
    }
}
