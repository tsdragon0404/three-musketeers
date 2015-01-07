using System;

namespace SMS.Data.Dtos
{
    public class DepotDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string DepotCode { get; set; }
        public virtual string DepotName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
