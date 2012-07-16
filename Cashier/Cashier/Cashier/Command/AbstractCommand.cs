using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Cashier.Command
{
    public abstract class AbstractCommand : IDisposable
    {
        #region Enum
        public enum CommandType
        {
            NoCommand = 0,
            ExitProgram = 1
        }
        #endregion

        #region Properties
        public String Name { get; set; }
        public Image Image { get; set; }
        public CommandList CommandList { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Enable { get; set; }
        public String ToolTipText { get; set; }
        public Keys ShortcutKeys { get; set; }
        public Boolean ShowProgressBar { get; set; }
        bool isDisposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (this.isDisposed)
                return;

            if (this.CommandList != null)
                foreach (AbstractCommand cmd in this.CommandList)
                    cmd.Dispose();

            if (this.Image != null)
            {
                this.Image.Dispose();
                this.Image = null;
            }

            this.isDisposed = true;
        }
        #endregion

        #region Constructor
        public AbstractCommand()
        {
            Name = String.Empty;
            Image = null;
            Visible = true;
            Enable = true;
            CommandList = new CommandList();
            ToolTipText = String.Empty;
            ShowProgressBar = false;
        }
        #endregion

        #region Methods
        public static AbstractCommand CommandFactory(CommandType type)
        {
            switch (type)
            {
                case CommandType.NoCommand:
                    return new EmptyCommand();
                case CommandType.ExitProgram:
                    return new ExitProgramCommand();
            }
            throw new NotSupportedException("This command type [" + type.ToString() + "] is not supported.");
        }
        public static AbstractCommand CommandFactory(CommandType type, String name, Image image)
        {
            AbstractCommand cmd = AbstractCommand.CommandFactory(type);
            cmd.Name = name;
            cmd.Image = image;
            return cmd;
        }
        public abstract void Execute();
        public virtual void DoExecute()
        {
            if (this.ShowProgressBar)
            {
                Global.ShowProgressBar(ShowProgressBar);
                Global.StatusProgressBar.Value = 0;
            }
            this.Execute();
        }
        internal ToolStripMenuItem GenerateMenuSubItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = this.Name;
            menuItem.Image = this.Image;
            menuItem.AutoSize = true;
            menuItem.ShortcutKeys = this.ShortcutKeys;
            menuItem.ToolTipText = this.ToolTipText;
            menuItem.Click += new EventHandler(menuItem_Click);

            if (this.CommandList != null && this.CommandList.Count > 0)
                foreach (AbstractCommand command in this.CommandList)
                {
                    ToolStripMenuItem subMenuItem = command.GenerateMenuSubItem();
                    menuItem.DropDownItems.Add(subMenuItem as ToolStripItem);
                }

            return menuItem;
        }
        #endregion

        #region Events
        void menuItem_Click(object sender, EventArgs e)
        {
            this.DoExecute();
        }
        #endregion
    }

    public class CommandList : List<AbstractCommand>
    {

    }
}
