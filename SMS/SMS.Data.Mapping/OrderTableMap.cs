using SMS.Common.Constant;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class OrderTableMap : BaseMap<OrderTable>
    {
        public OrderTableMap()
        {
            Table("OrderTable");
            References(x => x.Order).Column("OrderID");
            References(x => x.Table).Column("TableID");
            Map(x => x.Discount);
            Map(x => x.DiscountType).CustomType<DiscountType>();
            Map(x => x.DiscountCode);
            Map(x => x.DiscountComment);
            Map(x => x.UseServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            HasMany(x => x.OrderDetails).KeyColumn("OrderTableID").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
