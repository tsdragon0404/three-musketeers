using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TM.Data.DataAccess;
using TM.UI.WindowsForms.Utilities;
using TM.Utilities;
using TM.Utilities.Messages;

namespace TM.UI.WindowsForms
{
    /// <summary>
    /// Base for all Form
    /// </summary>
    public class BaseForm : Form
    {
        public IMessageManager MessageManager { get; set; }

        protected int FunctionID { get; set; }

        #region UI part

        #region Constants variables

        private const FormWindowState DefaultWindowState = FormWindowState.Maximized;
        private const FormStartPosition DefaultStartPos = FormStartPosition.CenterParent;

        #endregion

        #region Override methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
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

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Activated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ActivatedForm.FunctionID = FunctionID;
            WindowState = DefaultWindowState;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            var point = Location;
            var size = Size;
            FormBorderStyle = FormBorderStyle.None;
            Location = point;
            Size = size;
        }

        #endregion

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForm"/> class.
        /// </summary>
        public BaseForm()
        {
            Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;
            StartPosition = DefaultStartPos;

            // Get FunctionID
            var att = GetType().GetCustomAttribute<FunctionIdAttribute>();
            if(att != null)
                FunctionID = att.FunctionID;
        } 

        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        public virtual void InitializeData()
        {

        }

        /// <summary>
        /// Determines whether the ServiceError has error and show message if needed.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="showMessage">if set to <c>true</c> [show message].</param>
        /// <returns></returns>
        protected virtual bool HasError(ServiceError error, bool showMessage = true)
        {
            if (error == null || error.Number == 0)
                return false;

            if (showMessage)
                MessageManager.ShowError(RMS.Resources.Resource.Common_Exit_Caption, error.Message);

            return true;
        }
    }
}
