using System.Drawing;
using System.Windows.Forms;
using TM.UI.WindowsForms.Styles;
using TM.Utilities;

namespace TM.UI.WindowsForms.Controls
{
    public class TMMenuStripRenderer : ToolStripProfessionalRenderer
    {
        public TMMenuStripRenderer(ProfessionalColorTable colorTable)
            : base(colorTable)
        { }

        /// <summary>
        /// When overridden in a derived class, provides for custom initialization of the given <see cref="T:System.Windows.Forms.ToolStripItem" />.
        /// </summary>
        /// <param name="item">The <see cref="T:System.Windows.Forms.ToolStripItem" /> to be initialized.</param>
        protected override void InitializeItem(ToolStripItem item)
        {
            base.InitializeItem(item);
            item.ForeColor = DefinedColors.Menu_Foreground;
            item.Font = new Font("Segoe UI", 9.5F);
        }

        /// <summary>
        /// When overridden in a derived class, provides for custom initialization of the given <see cref="T:System.Windows.Forms.ToolStrip" />.
        /// </summary>
        /// <param name="toolStrip">The <see cref="T:System.Windows.Forms.ToolStrip" /> to be initialized.</param>
        protected override void Initialize(ToolStrip toolStrip)
        {
            base.Initialize(toolStrip);
            toolStrip.ForeColor = DefinedColors.Menu_Foreground;
            toolStrip.BackColor = DefinedColors.Menu_Background;
            
        }

        /// <summary>
        /// Raise the RenderImageMargin event
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);

            using (var brush = new SolidBrush(DefinedColors.SubMenu_Background))
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
        }

        /// <summary>
        /// Raise the RenderMenuItemBackground event
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderMenuItemBackground
                (ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            if (!e.Item.Enabled)
                return;

            var rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

            // If item is MenuHeader and menu is dropped down; 
            if ((e.Item as ToolStripMenuItem) != null && (e.Item as ToolStripMenuItem).DropDown.Visible &&
                !e.Item.IsOnDropDown)
            {
                rect.X += 1;
                rect.Y += 1;
                rect.Height -= 2;
                rect.Width -= 2;

                using (var b = new SolidBrush(DefinedColors.Menu_Background_Hover))
                    e.Graphics.FillRectangle(b, rect);
                e.Item.ForeColor = DefinedColors.Menu_Foreground_Hover;

                return;
            }

            // Mouse hover
            if (e.Item.Selected)
            {
                if (!e.Item.IsOnDropDown)
                {
                    // This item is MenuHeader and selected
                    using (var b = new SolidBrush(DefinedColors.Menu_Background_Hover))
                        e.Graphics.FillRectangle(b, rect);
                    e.Item.ForeColor = DefinedColors.Menu_Foreground_Hover;
                }
                else
                {
                    // This item is NOT menuheader (but subitem);
                    using (var b = new SolidBrush(DefinedColors.SubMenu_Background_Hover))
                        e.Graphics.FillRectangle(b, rect);
                    e.Item.ForeColor = DefinedColors.SubMenu_Foreground_Hover;
                }
            }
            else
                e.Item.ForeColor = e.Item.IsOnDropDown ? DefinedColors.SubMenu_Foreground : DefinedColors.Menu_Foreground;
        }
    }
}