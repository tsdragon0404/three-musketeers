using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Tax : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal Value { get; set; }

        #region Implementation of IEnableEntity

        public virtual bool Enable { get; set; }

        #endregion

        #region Implementation of ISortableEntity

        public virtual int SEQ { get; set; }

        #endregion

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}
