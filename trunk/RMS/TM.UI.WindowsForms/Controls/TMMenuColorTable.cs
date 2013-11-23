using System.Drawing;
using System.Windows.Forms;
using TM.UI.WindowsForms.Styles;

namespace TM.UI.WindowsForms.Controls
{
    public class TMMenuColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder 
        {
            get { return DefinedColors.Menu_Border; }
        }
        public override Color MenuItemBorder
        {
            get { return DefinedColors.Transparent; }
        }
    }
}