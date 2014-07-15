using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class UserBranch : Entity, IAuditableEntity
    {
        public virtual long UserID { get; set; }

        public virtual long BranchID { get; set; }

        public virtual long DefaultAreaID { get; set; }

        public virtual int ListTableHeight { get; set; }

        public virtual bool IsSuspended { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}
