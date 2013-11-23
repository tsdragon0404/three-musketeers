using System.Windows.Forms;

namespace TM.UI.WindowsForms.Controls
{
    public class TMMenuStrip : MenuStrip
    {
        public TMMenuStrip()
        {
            Renderer = new TMMenuStripRenderer(new TMMenuColorTable());
            //BackColor = DefinedColors.Title;
        }
        protected override void OnItemAdded(ToolStripItemEventArgs e)
        {
            base.OnItemAdded(e);
            //if(e.Item is Too)
        }
    }
}