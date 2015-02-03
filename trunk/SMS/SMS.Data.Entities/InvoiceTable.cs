using System;
using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("INVOICETABLE")]
    [PrimaryKey("ID")]
    public class InvoiceTable
    {
        public long ID { get; set; }
        public long InvoiceID { get; set; }
        public long TableID { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountComment { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal OtherFee { get; set; }
        public string OtherFeeDescription { get; set; }
        public decimal DetailAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Amount { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}