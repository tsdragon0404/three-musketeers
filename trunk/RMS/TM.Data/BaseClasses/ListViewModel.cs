using System.Collections.Generic;

namespace TM.Data.BaseClasses
{
    public class ListViewModel<TEntity> : BaseViewModel
    {
        public IList<TEntity> ItemsSource { get; set; }
    }
}