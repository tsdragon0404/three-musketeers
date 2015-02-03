using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("RECEIPTITEM")]
    [PrimaryKey("ID")]
    public class ReceiptItem
    {
        public long ID { get; set; }
        public long ReceiptNoteID { get; set; }
        public long ItemID { get; set; }
        public decimal Quantity{ get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
