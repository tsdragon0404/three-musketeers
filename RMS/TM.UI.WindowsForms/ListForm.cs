using System.Collections.Generic;

namespace TM.UI.WindowsForms
{
    /// <summary>
    /// Base class for forms that usually keep a list of items
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
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

        /// <summary>
        /// Initializes the data.
        /// </summary>
        public override void InitializeData()
        {
            base.InitializeData();
            Items = GetItemList();
            SelectedIndex = 0;
        }

        /// <summary>
        /// Gets the item list.
        /// </summary>
        /// <returns></returns>
        protected virtual IList<TEntity> GetItemList()
        {
            return new List<TEntity>();
        }
    }
}