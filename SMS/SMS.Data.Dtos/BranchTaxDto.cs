using System;

namespace SMS.Data.Dtos
{
    public class BranchTaxDto
    {
        public virtual long ID { get; set; }
        public virtual long BranchID { get; set; }
        public virtual TaxDto Tax { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
