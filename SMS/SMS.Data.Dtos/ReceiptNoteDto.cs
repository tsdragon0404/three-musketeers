using System;

namespace SMS.Data.Dtos
{
    public class ReceiptNoteDto
    {
        public long ReceiptNoteID { get; set; }
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
