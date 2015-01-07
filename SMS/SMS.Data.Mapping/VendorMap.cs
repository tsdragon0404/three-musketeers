using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class VendorMap : BaseMap<Vendor>
    {
        public VendorMap()
        {
            Table("Vendor");
            Map(x => x.VendorNumber);
            Map(x => x.VendorName);
            Map(x => x.Phone);
            Map(x => x.Fax);
            Map(x => x.Email);
            Map(x => x.TaxCode);
            Map(x => x.Address);
        }
    }
}