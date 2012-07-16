using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Drawing;

namespace Cashier.Command
{
    public class MainCommandManager
    {
        #region Properties
        public List<CommandGroup> GroupList { get; set; }
        public CommandGroup GroupFile { get; set; }
        public AbstractCommand CmdExitProgram { get; set; }
        #endregion

        #region Constructor
        public MainCommandManager()
        {
            CmdExitProgram = AbstractCommand.CommandFactory(AbstractCommand.CommandType.ExitProgram);
            GroupFile = new CommandGroup();
            GroupFile.Name = "&File";
            GroupFile.Type = CommandGroup.CommandGroupType.Menu;
            GroupFile.CommandList.Add(CmdExitProgram);

            GroupList = new List<CommandGroup>();
            GroupList.Add(GroupFile);
        }

        public MainCommandManager(DataTable menuList)
        {
            GroupList = new List<CommandGroup>();

            for (int i = 0; i < menuList.Rows.Count; i++)
            {
                Image img = null;
                if (menuList.Rows[i]["Image"].ToString().Trim() != "")
                {
                    System.IO.Stream file = Assembly.GetExecutingAssembly().
                        GetManifestResourceStream(GetType().Namespace.ToString().Replace(".Command", "") + ".Resources." + menuList.Rows[i]["Image"].ToString());
                    if(file != null)
                        img = Image.FromStream(file);
                }

                if (Int32.Parse(menuList.Rows[i]["IsGroup"].ToString()) == 1)
                {
                    CommandGroup group = new CommandGroup();
                    group.ID = Int32.Parse(menuList.Rows[i]["ID"].ToString());
                    group.Name = menuList.Rows[i]["Name"].ToString();
                    group.Type |= (CommandGroup.CommandGroupType)Int32.Parse(menuList.Rows[i]["MenuGroupEnumValue"].ToString());
                    group.Image = img;

                    if (Int32.Parse(menuList.Rows[i]["Parent"].ToString()) == 0)
                        GroupList.Add(group);
                    else
                    {
                        var list = GroupList.Where(g => g.ID == Int32.Parse(menuList.Rows[i]["Parent"].ToString()));
                        if (list.Count() > 0)
                        {
                            var g = list.First();
                            g.ControlOrder.Add(1);
                            g.GroupList.Add(group);
                        }
                    }
                }
                else
                {
                    AbstractCommand command = AbstractCommand.CommandFactory((AbstractCommand.CommandType)Int32.Parse(menuList.Rows[i]["MenuCommandEnumValue"].ToString()),
                        menuList.Rows[i]["Name"].ToString(), img);

                    //var list = GroupList.Where(g => g.ID == Int32.Parse(menuList.Rows[i]["Parent"].ToString()));
                    //if (list.Count() > 0)
                    //{
                    //    var g = list.First();
                    //    g.ControlOrder.Add(0);
                    //    g.CommandList.Add(command);
                    //}
                    var p = FindCommandGroup(GroupList, Int32.Parse(menuList.Rows[i]["Parent"].ToString()));
                    if (p != null)
                    {
                        p.ControlOrder.Add(0);
                        p.CommandList.Add(command);
                    }
                }
            }
        }

        private CommandGroup FindCommandGroup(List<CommandGroup> list, Int32 id)
        {
            foreach (CommandGroup g in list)
            {
                if (g.ID == id)
                    return g;
                if (g.GroupList.Count > 0)
                {
                    var rs = FindCommandGroup(g.GroupList, id);
                    if (rs != null)
                        return rs;
                }
            }
            return null;
        }
        #endregion

        #region Methods
        public MenuStrip GenerateMenu()
        {
            MenuStrip menuStrip = new MenuStrip();

            foreach (CommandGroup cmdGroup in this.GroupList)
            {
                if ((cmdGroup.Type & CommandGroup.CommandGroupType.Menu) == 0)
                    continue;

                ToolStripMenuItem menuItem = cmdGroup.GenerateMenuItem();
                menuStrip.Items.Add(menuItem);

                if (menuItem.Text == "&Window")
                    menuStrip.MdiWindowListItem = menuItem;
            }
            return menuStrip;
        }
        #endregion
    }
}
