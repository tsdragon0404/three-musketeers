using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashier.Command
{
    class ExitProgramCommand : AbstractCommand
    {
        public ExitProgramCommand()
            : base()
        {
            Name = "E&xit";
            ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
        }
        public override void Execute()
        {
            Global.mainForm.Dispose();
        }
    }
}
