using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class OrderDiscountDto
    {
        public virtual long ID { get; set; }
        public virtual long OrderID { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
    }
}
