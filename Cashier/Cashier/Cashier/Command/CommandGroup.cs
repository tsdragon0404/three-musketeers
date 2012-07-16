using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Cashier.Command
{
    public class CommandGroup : IDisposable
    {
        #region enum
        [Flags]
        public enum CommandGroupType
        {
            Menu = 0x00001
        }
        #endregion

        #region Properties
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Image Image { get; set; }
        public CommandList CommandList { get; set; }
        public List<CommandGroup> GroupList { get; set; }
        public List<Int32> ControlOrder { get; set; }
        public CommandGroupType Type { get; set; }
        #endregion

        #region Constructor
        public CommandGroup()
        {
            Name = String.Empty;
            Image = null;
            CommandList = new CommandList();
            GroupList = new List<CommandGroup>();
            ControlOrder = new List<Int32>();
            Type = CommandGroupType.Menu;
        }
        #endregion

        #region Methods
        public ToolStripMenuItem GenerateMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = this.Name;
            menuItem.Image = this.Image;

            Int32 cmdidx = 0, grpidx = 0;
            for (Int32 i = 0; i < ControlOrder.Count; i++)
            {
                if (ControlOrder[i] == 1)
                {
                    menuItem.DropDownItems.Add(GroupList[grpidx].GenerateMenuItem());
                    grpidx++;
                }
                else
                {
                    menuItem.DropDownItems.Add(CommandList[cmdidx].GenerateMenuSubItem());
                    cmdidx++;
                }
            }

            //foreach (AbstractCommand command in this.CommandList)
            //{
            //    ToolStripMenuItem menuSubItem = command.GenerateMenuSubItem();
            //    menuItem.DropDownItems.Add(menuSubItem);
            //}

            return menuItem;
        }
        #endregion

        #region IDisposable Members

        bool isDisposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDisposing)
        {
            if (this.isDisposed)
                return;

            if (this.Image != null)
                this.Image.Dispose();

            foreach (AbstractCommand cmd in this.CommandList)
                cmd.Dispose();

            this.isDisposed = true;
        }

        #endregion
    }
}
