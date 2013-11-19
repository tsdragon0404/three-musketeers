using System.Collections.Generic;

namespace TM.UI.WindowsForms
{
    public class ListForm<TEntity> : BaseForm
    {
        #region Properties

        protected IList<TEntity> Items { get; set; }

        protected TEntity SelectedItem
        {
            get { return Items[SelectedIndex]; }
            set { SelectedIndex = Items.IndexOf(value); }
        }

        protected int SelectedIndex { get; set; } 

        #endregion

        public override void InitializeData()
        {
            base.InitializeData();
            Items = GetItemList();
            SelectedIndex = 0;
        }

        protected virtual IList<TEntity> GetItemList()
        {
            return new List<TEntity>();
        }
    }
}