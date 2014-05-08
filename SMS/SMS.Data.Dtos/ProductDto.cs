using System;

namespace SMS.Data.Dtos
{
    public class ProductDto : EnableSortableDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual UnitDto Unit { get; set; }
        public virtual long ProductCategoryID { get; set; }
        public virtual decimal Price { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
