using System;

namespace SMS.Data.Dtos
{
    public class BranchDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual CurrencyDto Currency { get; set; }
        public virtual bool UseServiceFee { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual BranchInfoDto BranchInfo { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }

    public class LanguageBranchDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
    }
}
