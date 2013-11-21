using System.Reflection;
using System.Windows.Forms;
using TM.Utilities;

namespace TM.UI.WindowsForms
{
    /// <summary>
    /// Base for all Form
    /// </summary>
    public class BaseForm : Form
    {
        #region UI part

        #region Constants variables

        private const bool IsMinimizeButtonEnable = false;
        private const bool IsMaximizeButtonEnable = true;

        private const FormWindowState DefaultWindowState = FormWindowState.Maximized;
        private const FormStartPosition DefaultStartPos = FormStartPosition.CenterParent;

        #endregion

        #region Override methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if(FunctionID != GlobalConstants.FunctionIds.FormLoginAdmin)
                WindowState = DefaultWindowState;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs" /> that contains the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Hide();
            e.Cancel = true;
        }

        protected override void OnActivated(System.EventArgs e)
        {
            base.OnActivated(e);
            ActivatedForm.FunctionID = FunctionID;
        }

        #endregion

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForm"/> class.
        /// </summary>
        public BaseForm()
        {
            MinimizeBox = IsMinimizeButtonEnable;
            MaximizeBox = IsMaximizeButtonEnable;
            StartPosition = DefaultStartPos;

            // Get FunctionID
            var att = GetType().GetCustomAttribute<FunctionIdAttribute>();
            if(att != null)
                FunctionID = att.FunctionID;
        } 

        #endregion

        protected int FunctionID { get; set; }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        public virtual void InitializeData()
        {

        }
    }
}
