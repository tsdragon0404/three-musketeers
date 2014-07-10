using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class RejectMap : BaseMap<Reject>
    {
        public RejectMap()
        {
            Table("Reject");
            Map(x => x.BranchID);
            Map(x => x.ProductCode);
            Map(x => x.ProductVNName);
            Map(x => x.ProductENName);
            Map(x => x.Quantity);
            Map(x => x.UnitVNName);
            Map(x => x.UnitENName);
            Map(x => x.OrderComment);
            Map(x => x.KitchenComment);
            Map(x => x.CreatedDate);
            Map(x => x.CreatedUser);
        }
    }
}