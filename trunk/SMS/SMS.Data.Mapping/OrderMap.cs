using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class OrderMap : BaseMap<Order>
    {
        public OrderMap()
        {
            Table("[Order]");
            Map(x => x.BranchID);
            Map(x => x.OrderNumber);
            Map(x => x.Comment);
            References(x => x.Customer).Column("CustomerID");
            Map(x => x.Tax);
            Map(x => x.UseServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            HasMany(x => x.OrderTables).KeyColumn("OrderID").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
