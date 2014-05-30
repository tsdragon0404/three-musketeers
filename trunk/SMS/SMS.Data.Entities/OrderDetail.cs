using Core.Data;
using SMS.Common.Constant;

namespace SMS.Data.Entities
{
    public class OrderDetail : Entity
    {
        public virtual OrderTable OrderTable { get; set; }

        public virtual Product Product { get; set; }

        public virtual decimal Quantity { get; set; }

        public virtual string Comment { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
    }
}
