using System;

namespace SMS.Data.Dtos
{
    public class ProductCategoryDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCategoryCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual long BranchID { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
