using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class InvoiceDetailDto
    {
        public virtual long ID { get; set; }
        public virtual InvoiceTableDto InvoiceTable { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string ProductVNName { get; set; }
        public virtual string ProductENName { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string UnitVNName { get; set; }
        public virtual string UnitENName { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
