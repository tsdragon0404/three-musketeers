using System;
using System.Windows.Forms;
using TM.Utilities.Messages;
using RMS.Resources;

namespace TM.Utilities
{
    public static class CommonValidation
    {
        private static IMessageManager MessageManager { get; set; }

        public static bool ValidateEmptyTextBox(TextBox txtValidation)
        {
            return txtValidation.Text.Trim() != "";
        }

        public static bool ValidateNumber(TextBox txtValidation)
        {
            return true;
        }
    }
}
