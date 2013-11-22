using System.Windows.Forms;

namespace TM.UI.WindowsForms.Utilities
{
    public class MessageManager : IMessageManager
    {
        public DialogResult ShowError(string errorMessage, params object[] param)
        {
            var message = string.Format(errorMessage, param);
            return MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowQuestion(string errorMessage, params object[] param)
        {
            var message = string.Format(errorMessage, param);
            return MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}