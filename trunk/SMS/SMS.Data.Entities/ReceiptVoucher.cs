using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("RECEIPTVOUCHER")]
    [PrimaryKey("ID")]
    public class ReceiptVoucher
    {
        public long ID { get; set; }
        public long DepotID { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public long? CustomerID { get; set; }
        public long? FromDepotID { get; set; }
        public string Payer { get; set; }
        public decimal TotalAmount { get; set; }
        public string InWords { get; set; }
        public string Description { get; set; }
        public long DocumentID { get; set; }
        public bool Enable { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}