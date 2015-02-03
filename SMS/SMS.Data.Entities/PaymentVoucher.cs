using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("PAYMENTVOUCHER")]
    [PrimaryKey("ID")]
    public class PaymentVoucher
    {
        public long ID { get; set; }
        public long DepotID { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public long? VendorID { get; set; }
        public long? ToDepotID { get; set; }
        public string Receiver { get; set; }
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