using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TM.UI.WindowsForms.Controls
{
    public partial class TMCRUD : UserControl
    {
        public TMCRUD()
        {
            InitializeComponent();
        }

        #region Properties

        [Description("Icon for create button"), Category("TM Properties")]
        public Image Icon_Create
        {
            get { return btnCreateNew.Image; }
            set
            {
                btnCreateNew.Image = value;
                Invalidate();
            }
        }

        [Description("Icon for save button"), Category("TM Properties")]
        public Image Icon_Save
        {
            get { return btnSave.Image; }
            set
            {
                btnSave.Image = value;
                Invalidate();
            }
        }

        [Description("Icon for delete button"), Category("TM Properties")]
        public Image Icon_Delete
        {
            get { return btnDelete.Image; }
            set
            {
                btnDelete.Image = value;
                Invalidate();
            }
        }

        [Description("Icon for cancel button"), Category("TM Properties")]
        public Image Icon_Cancel
        {
            get { return btnCancel.Image; }
            set
            {
                btnCancel.Image = value;
                Invalidate();
            }
        }

        private bool _isAdding;
        [Description("Indicate that user is adding"), Category("TM Properties")]
        public bool IsAdding
        {
            get { return _isAdding; }
            set
            {
                _isAdding = value;

                btnCreateNew.Enabled = !_isAdding;
                btnDelete.Enabled = !_isAdding;
            }
        }

        #endregion

        #region Events

        [Description("Event click for cancel button"), Category("TM Events")]
        public event EventHandler ButtonCreateClick
        {
            add { btnCreateNew.Click += value; }
            remove { btnCreateNew.Click -= value; }
        }

        [Description("Event click for cancel button"), Category("TM Events")]
        public event EventHandler ButtonSaveClick
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        [Description("Event click for cancel button"), Category("TM Events")]
        public event EventHandler ButtonDeleteClick
        {
            add { btnDelete.Click += value; }
            remove { btnDelete.Click -= value; }
        }

        [Description("Event click for cancel button"), Category("TM Events")]
        public event EventHandler ButtonCancelClick
        {
            add { btnCancel.Click += value; }
            remove { btnCancel.Click -= value; }
        }

        #endregion
    }
}
