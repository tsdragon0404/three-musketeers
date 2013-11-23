using System.Windows.Forms;

namespace TM.UI.WindowsForms.Controls
{
    public class TMMenuStrip : MenuStrip
    {
        public TMMenuStrip()
        {
            Renderer = new TMMenuStripRenderer(new TMMenuColorTable());
        }
    }
}