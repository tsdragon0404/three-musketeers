using System;
using System.Collections.Generic;
using Core.Data;

namespace SMS.Data.Entities
{
    public class User : Entity, IAuditableEntity
    {
        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public virtual string Displayname { get; set; }

        public virtual DateTime? LastLoginDate { get; set; }

        public virtual bool IsLockedOut { get; set; }

        public virtual DateTime? LastLockedOutDate { get; set; }

        public virtual int FailedPasswordAttemptCount { get; set; }

        public virtual IList<UserRole> Roles { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}