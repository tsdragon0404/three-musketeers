using SMS.Common.Constant;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Table("OrderDetail");
            References(x => x.OrderTable).Column("OrderTableID");
            References(x => x.Product).Column("ProductID");
            Map(x => x.Quantity);
            Map(x => x.Comment);
            Map(x => x.Discount);
            Map(x => x.DiscountType).CustomType<DiscountType>();
            Map(x => x.DiscountCode);
            Map(x => x.DiscountComment);
            Map(x => x.KitchenComment);
            References(x => x.OrderStatus).Column("OrderStatusID");
        }
    }
}
