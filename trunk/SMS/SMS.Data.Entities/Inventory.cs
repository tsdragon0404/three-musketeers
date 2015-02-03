using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("INVENTORY")]
    [PrimaryKey("ID")]
    public class Inventory
    {
        public long ID { get; set; }
        public long DepotID { get; set; }
        public long ItemID { get; set; }
        public decimal Quantity { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}