using System;

namespace SMS.Data.Dtos
{
    public class CustomerDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string CustomerCode { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual long BranchID { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
