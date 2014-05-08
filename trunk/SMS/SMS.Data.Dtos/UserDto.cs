using System;

namespace SMS.Data.Dtos
{
    public class UserDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string UserCode { get; set; }
        public virtual string UserLogin { get; set; }
        public virtual string UserPassword { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string CellPhone { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
