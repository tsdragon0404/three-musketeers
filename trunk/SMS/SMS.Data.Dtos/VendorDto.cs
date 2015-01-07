using System;

namespace SMS.Data.Dtos
{
    public class VendorDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string VendorNumber { get; set; }
        public virtual string VendorName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string TaxCode { get; set; }
        public virtual string Address { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
