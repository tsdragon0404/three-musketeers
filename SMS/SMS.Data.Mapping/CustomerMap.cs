using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class CustomerMap : BaseMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer");
            Map(x => x.BranchID);
            Map(x => x.CustomerCode);
            Map(x => x.CustomerName);
        }
    }
}