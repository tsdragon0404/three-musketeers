using System.Windows.Forms;
using TM.Utilities;

namespace TM.UI.WindowsForms.Controls
{
    public class TMMenuStrip : MenuStrip
    {
        public TMMenuStrip()
        {
            Renderer = new TMMenuStripRenderer(new TMMenuColorTable());
        }

        protected override void OnItemAdded(ToolStripItemEventArgs e)
        {
            if (e.Item.GetType().Name == GlobalConstants.SystemMenuButtonName.MenuIcon
                || e.Item.Text == GlobalConstants.SystemMenuButtonName.MenuMinimize
                || e.Item.Text == GlobalConstants.SystemMenuButtonName.MenuRestore)
                Items.Remove(e.Item);

            if (e.Item.Text == GlobalConstants.SystemMenuButtonName.MenuClose)
                e.Item.Margin = new Padding(0, 0, 5, 0);

            base.OnItemAdded(e);
        }
    }
}