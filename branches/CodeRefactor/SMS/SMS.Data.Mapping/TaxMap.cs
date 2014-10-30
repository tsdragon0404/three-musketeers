using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class TaxMap : BaseMap<Tax>
    {
        public TaxMap()
        {
            Table("Tax");
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Value);
        }
    }
}
