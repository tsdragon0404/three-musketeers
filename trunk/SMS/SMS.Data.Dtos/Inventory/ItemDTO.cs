using System;

namespace SMS.Data.Dtos.Inventory
{
    public class ItemDto : EnableSortableDto
    {
        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public string VNName { get; set; }
        public string ENName { get; set; }
        public string VNDescription { get; set; }
        public string ENDescription { get; set; }
        public long UnitID { get; set; }
        public long ProductCategoryID { get; set; }
        public bool IsInventory { get; set; }
        public decimal MinQuantity { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}