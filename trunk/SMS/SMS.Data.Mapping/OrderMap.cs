using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class OrderMap : BaseMap<Order>
    {
        public OrderMap()
        {
            Table("[Order]");
            References(x => x.Branch).Column("BranchID");
            Map(x => x.OrderNumber);
            Map(x => x.Comment);
            References(x => x.Customer).Column("CustomerID");
            Map(x => x.CustomerName);
            Map(x => x.Address);
            Map(x => x.CellPhone);
            Map(x => x.DOB);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            HasMany(x => x.OrderDiscounts)
                .KeyColumn("OrderID")
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.OrderTables)
                .KeyColumn("OrderID")
                .Cascade.AllDeleteOrphan();
        }
    }
}
