using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("PRODUCT")]
    [PrimaryKey("ID")]
    public class Product
    {
        public long ID { get; set; }
        public string ProductCode { get; set; }
        public string VNName { get; set; }
        public string ENName { get; set; }
        public string VNDescription { get; set; }
        public string ENDescription { get; set; }
        public long UnitID { get; set; }
        public long CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Enable { get; set; }
        public int SEQ { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}