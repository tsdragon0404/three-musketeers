using System.Collections.Generic;

namespace TM.UI.WindowsForms
{
    public class ListForm<TEntity> : BaseForm
    {
        public IList<TEntity> Items { get; set; }

        public TEntity SelectedItem { get; set; }

        public int SelectedIndex { get; set; }
    }
}