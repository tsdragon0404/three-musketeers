using SMS.Common.Constant;

namespace SMS.Data.Entities
{
    public class OrderDiscount : Entity
    {
        public virtual Order Order { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }
    }
}
