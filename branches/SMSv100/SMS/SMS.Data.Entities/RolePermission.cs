using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class RolePermission : Entity, IAuditableEntity
    {
        public virtual long RoleID { get; set; }

        public virtual long PageID { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}