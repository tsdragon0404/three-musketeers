using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class RoleDto
    {
        public virtual long ID { get; set; }
        public virtual BranchDto Branch { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Enable { get; set; }
        public virtual IList<UserDto> UsersInRole { get; set; }
        public virtual IList<PageDto> Pages { get; set; } 

        public RoleDto()
        {
            Enable = true;
            Pages = new List<PageDto>();
            UsersInRole = new List<UserDto>();
        }
    }
}
