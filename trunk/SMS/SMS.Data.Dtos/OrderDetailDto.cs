using SMS.Common.Constant;

namespace SMS.Data.Dtos
{
    public class OrderDetailDto : OrderDetailBasicDto
    {
        public virtual OrderTableDto OrderTable { get; set; }
        public virtual ProductDto Product { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }

    public class LanguageOrderDetailDto : OrderDetailBasicDto
    {
        public virtual LanguageProductDto Product { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public virtual decimal Amount
        {
            get { return Quantity * Product.Price - Discount; }
        }
    }

    public class OrderDetailBasicDto
    {
        public virtual long ID { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string Comment { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
        public virtual string KitchenComment { get; set; }
    }
}
