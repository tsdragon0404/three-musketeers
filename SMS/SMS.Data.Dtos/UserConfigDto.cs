using System;

namespace SMS.Data.Dtos
{
    public class UserConfigDto : UserProfileConfigDto
    {
        public virtual long ID { get; set; }
        public virtual long UserID { get; set; }
        public virtual long BranchID { get; set; }
        public virtual long DefaultAreaID { get; set; }
        public virtual decimal ListTableHeight { get; set; }
        public virtual int PageSize { get; set; }
        public virtual bool IsSuspended { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }

    public class UserProfileConfigDto
    {
        public virtual string Theme { get; set; }
    }
}
