using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class DepotMap : BaseMap<Depot>
    {
        public DepotMap()
        {
            Table("Depot");
            Map(x => x.DepotCode);
            Map(x => x.DepotName);
            Map(x => x.Phone);
            Map(x => x.Fax);
            Map(x => x.Email);
            Map(x => x.Address);
        }
    }
}