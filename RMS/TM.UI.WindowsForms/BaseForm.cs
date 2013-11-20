using System.Windows.Forms;

namespace TM.UI.WindowsForms
{
    /// <summary>
    /// Base for all Form
    /// </summary>
    public class BaseForm : Form
    {
        #region Constants variables

        private const bool IsMinimizeButtonEnable = false;
        private const bool IsMaximizeButtonEnable = true;

        private const FormWindowState DefaultWindowState = FormWindowState.Maximized;
        private const FormStartPosition DefaultStartPos = FormStartPosition.CenterParent;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForm"/> class.
        /// </summary>
        public BaseForm()
        {
            MinimizeBox = IsMinimizeButtonEnable;
            MaximizeBox = IsMaximizeButtonEnable;
            StartPosition = DefaultStartPos;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        public virtual void InitializeData()
        {
            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
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
    }
}
