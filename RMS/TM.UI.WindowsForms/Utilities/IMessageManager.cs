using System.Windows.Forms;

namespace TM.UI.WindowsForms.Utilities
{
    public interface IMessageManager
    {
        DialogResult ShowError(string errorMessage, params object[] param);
    }
}