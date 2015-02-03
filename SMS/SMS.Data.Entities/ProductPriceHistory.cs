using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("PRODUCTPRICEHISTORY")]
    [PrimaryKey("ID")]
    public class ProductPriceHistory
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public decimal OldUnitPrice { get; set; }
        public decimal NewUnitPrice { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
    }
}
