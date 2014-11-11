using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Customer : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string CustomerCode { get; set; }

        public virtual string CustomerName { get; set; }

        public virtual string CellPhone { get; set; }

        public virtual string Address { get; set; }

        public virtual DateTime? DOB { get; set; }

        public virtual long BranchID { get; set; }

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
