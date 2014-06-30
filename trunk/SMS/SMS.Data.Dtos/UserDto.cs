using System;
using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class UserDto
    {
        public virtual long ID { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Displayname { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual bool IsSystemAdmin { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual DateTime? LastLockedOutDate { get; set; }
        public virtual int FailedPasswordAttemptCount { get; set; }
        public virtual IList<RoleDto> Roles { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
