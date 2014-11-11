using Core.Data;

namespace SMS.Data.Entities
{
    public class PageMenu : Entity, ISortableEntity
    {
        public virtual string GroupName { get; set; }

        public virtual long PageID { get; set; }

        public virtual long ParentID { get; set; }

        #region Implementation of ISortableEntity

        public virtual int SEQ { get; set; }

        #endregion
    }
}