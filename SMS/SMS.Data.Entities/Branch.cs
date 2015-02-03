using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("BRANCH")]
    [PrimaryKey("ID")]
    public class Branch
    {
        public long ID { get; set; }
        public string VNName { get; set; }
        public string ENName { get; set; }
        public long CurrencyID { get; set; }
        public bool UseServiceFee { get; set; }
        public decimal ServiceFee { get; set; }
        public bool UseDiscountOnProduct { get; set; }
        public bool UseKitchenFunction { get; set; }
        public bool UseInventory { get; set; }
        public int DepotID { get; set; }
        public bool Enable { get; set; }
        public int SEQ { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
