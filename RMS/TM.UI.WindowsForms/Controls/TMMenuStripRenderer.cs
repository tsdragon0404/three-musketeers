using System;
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

        protected override void InitializeItem(ToolStripItem item)
        {
            base.InitializeItem(item);
            item.ForeColor = DefinedColors.Menu_Foreground;
            item.Font = new Font("Segoe UI", 9.5F);
        }

        protected override void Initialize(ToolStrip toolStrip)
        {
            base.Initialize(toolStrip);
            toolStrip.ForeColor = DefinedColors.Menu_Foreground;
            toolStrip.BackColor = DefinedColors.Menu_Background;
            
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);

            using (var brush = new SolidBrush(DefinedColors.SubMenu_Background))
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
        }

        //// Render checkmark
        //protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        //{
        //    base.OnRenderItemCheck(e);

        //    if (e.Item.Selected)
        //    {
        //        var rect = new Rectangle(3, 1, 20, 20);
        //        var rect2 = new Rectangle(4, 2, 18, 18);
        //        SolidBrush b = new SolidBrush(clsColor.clrToolstripBtn_Border);
        //        SolidBrush b2 = new SolidBrush(clsColor.clrCheckBG);

        //        e.Graphics.FillRectangle(b, rect);
        //        e.Graphics.FillRectangle(b2, rect2);
        //        e.Graphics.DrawImage(e.Image, new Point(5, 3));
        //    }
        //    else
        //    {
        //        var rect = new Rectangle(3, 1, 20, 20);
        //        var rect2 = new Rectangle(4, 2, 18, 18);
        //        SolidBrush b = new SolidBrush(clsColor.clrSelectedBG_Drop_Border);
        //        SolidBrush b2 = new SolidBrush(clsColor.clrCheckBG);

        //        e.Graphics.FillRectangle(b, rect);
        //        e.Graphics.FillRectangle(b2, rect2);
        //        e.Graphics.DrawImage(e.Image, new Point(5, 3));
        //    }
        //}

        //// Render separator
        //protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        //{
        //    base.OnRenderSeparator(e);

        //    var DarkLine = new SolidBrush(clsColor.clrImageMarginLine);
        //    var WhiteLine = new SolidBrush(Color.White);
        //    var rect = new Rectangle(32, 3, e.Item.Width - 32, 1);
        //    e.Graphics.FillRectangle(DarkLine, rect);
        //    e.Graphics.FillRectangle(WhiteLine, rect);
        //}

        //// Render arrow
        //protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        //{
        //    e.ArrowColor = Color.Black;
        //    base.OnRenderArrow(e);
        //}

        // Render  MenuItem background: lightblue if selected, darkblue if dropped down

        protected override void OnRenderMenuItemBackground
                (ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            if (!e.Item.Enabled)
                return;

            if ((e.Item.GetType().Name == GlobalConstants.SystemMenuButtonName.MenuIcon
                || e.Item.Text == GlobalConstants.SystemMenuButtonName.MenuMinimize
                || e.Item.Text == GlobalConstants.SystemMenuButtonName.MenuRestore) && e.Item.Visible)
            {
                e.Item.Visible = false;
                return;
            }

            if (e.Item.Text == GlobalConstants.SystemMenuButtonName.MenuClose && e.Item.Margin.Right != 5)
                e.Item.Margin = new Padding(0, 0, 5, 0);

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