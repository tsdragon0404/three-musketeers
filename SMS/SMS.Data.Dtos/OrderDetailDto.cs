using SMS.Common.Constant;

namespace SMS.Data.Dtos
{
    public class OrderDetailDto
    {
        public virtual long ID { get; set; }
        public virtual OrderTableDto OrderTable { get; set; }
        public virtual ProductDto Product { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string Comment { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
        public virtual string KitchenComment { get; set; }
        public virtual OrderStatusDto OrderStatus { get; set; }
    }
}
