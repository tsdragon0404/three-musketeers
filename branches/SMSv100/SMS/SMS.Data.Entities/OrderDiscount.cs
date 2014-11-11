using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class OrderDiscount : Entity
    {
        public virtual long OrderID { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }
    }
}
