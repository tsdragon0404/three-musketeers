using SMS.Common.Constant;

namespace SMS.Data.Dtos
{
    public class LanguageOrderDetailDto
    {
        public virtual long ID { get; set; }
        public virtual LanguageProductDto Product { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string Comment { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
        public virtual string KitchenComment { get; set; }
        public virtual LanguageOrderStatusDto OrderStatus { get; set; }
    }
}
