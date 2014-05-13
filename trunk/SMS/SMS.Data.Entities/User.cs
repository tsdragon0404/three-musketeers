using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class User : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string UserCode { get; set; }

        public virtual string UserLogin { get; set; }

        public virtual string UserPassword { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string CellPhone { get; set; }

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
