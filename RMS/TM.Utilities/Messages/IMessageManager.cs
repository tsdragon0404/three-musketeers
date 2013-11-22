using System.Windows.Forms;

namespace TM.Utilities.Messages
{
    public interface IMessageManager
    {
        DialogResult ShowError(string caption, string errorMessage, params object[] param);
        DialogResult ShowQuestion(string caption, string errorMessage, params object[] param);
    }
}