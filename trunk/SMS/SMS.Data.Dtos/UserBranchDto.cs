using System;

namespace SMS.Data.Dtos
{
    class UserBranchDto
    {
        public virtual long ID { get; set; }
        public virtual long UserID { get; set; }
        public virtual long BranchID { get; set; }
        public virtual long AccessLevel { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
