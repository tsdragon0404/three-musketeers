using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("RECEIPTNOTE")]
    [PrimaryKey("ID")]
    public class ReceiptNote
    {
        public long ID { get; set; }
        public long? BranchID { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public long? VendorID { get; set; }
        public long? DepotID { get; set; }
        public string Comment { get; set; }
        public long? DocumentID { get; set; }
        public decimal? TotalReceipt { get; set; }
        public string Currency { get; set; }
        public decimal? DebitAmount { get; set; }
        public DateTime? PaymentDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
