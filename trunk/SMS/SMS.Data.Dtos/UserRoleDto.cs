using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class UserRoleDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<UserDto> UsersInRole { get; set; } 
    }
}
