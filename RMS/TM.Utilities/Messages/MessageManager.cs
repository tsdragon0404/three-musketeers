using System.Windows.Forms;

namespace TM.Utilities.Messages
{
    public class MessageManager : IMessageManager
    {
        /// <summary>
        /// Shows the error.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        public DialogResult ShowError(string caption, string errorMessage, params object[] param)
        {
            var message = string.Format(errorMessage, param);
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows the question.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        public DialogResult ShowQuestion(string caption, string errorMessage, params object[] param)
        {
            var message = string.Format(errorMessage, param);
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Show the warning
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="errorMessage"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DialogResult ShowWarning(string caption, string errorMessage, params object[] param)
        {
            var message = string.Format(errorMessage, param);
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}