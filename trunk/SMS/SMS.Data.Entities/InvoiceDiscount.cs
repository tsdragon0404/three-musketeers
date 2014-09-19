using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class InvoiceDiscount : Entity
    {
        public virtual long InvoiceID { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }
    }
}
