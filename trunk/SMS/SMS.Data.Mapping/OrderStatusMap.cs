using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class OrderStatusMap : BaseMap<OrderStatus>
    {
        public OrderStatusMap()
        {
            Table("OrderStatus");
            Map(x => x.VNName);
            Map(x => x.ENName);
        }
    }
}
