using System.Threading;
using System.Windows.Forms;

namespace TM.UI.WindowsForms.Utilities
{
    public class ThreadExceptionHandler
    {
        /// <summary>
        /// Handle thread exception of an application.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ThreadExceptionEventArgs"/> instance containing the event data.</param>
        public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
