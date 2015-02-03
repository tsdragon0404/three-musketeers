using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("INVOICEDISCOUNT")]
    [PrimaryKey("ID")]
    public class InvoiceDiscount
    {
        public long ID { get; set; }
        public long InvoiceID { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountComment { get; set; }
    }
}
