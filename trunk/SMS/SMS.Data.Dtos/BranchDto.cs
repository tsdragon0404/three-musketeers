using System;

namespace SMS.Data.Dtos
{
    public class BranchDto
    {
        public virtual long ID { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual long CurrencyID { get; set; }
        public virtual bool UseServiceFee { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual bool Enable { get; set; }
        public virtual int SEQ { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
