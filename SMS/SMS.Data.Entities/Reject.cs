using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("REJECT")]
    [PrimaryKey("ID")]
    public class Reject
    {
        public long ID { get; set; }
        public long BranchID { get; set; }
        public long ProductID { get; set; }
        public decimal Quantity { get; set; }
        public string OrderComment { get; set; }
        public string KitchenComment { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
    }
}