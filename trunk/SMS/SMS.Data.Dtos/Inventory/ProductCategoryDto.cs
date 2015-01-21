using System;

namespace SMS.Data.Dtos.Inventory
{
    public class ProductCategoryDto : EnableSortableDto
    {
        public long ProductCategoryID { get; set; }
        public string ProductCategoryCode { get; set; }
        public string VNName { get; set; }
        public string ENName { get; set; }
        public string VNDescription { get; set; }
        public string ENDescription { get; set; }
        public long? BranchID { get; set; }
               
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}