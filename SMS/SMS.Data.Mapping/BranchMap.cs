using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class BranchMap : BaseMap<Branch>
    {
        public BranchMap()
        {
            Table("Branch");
            Map(x => x.VNName);
            Map(x => x.ENName);
            References(x => x.Currency).Column("CurrencyID");
            Map(x => x.UseServiceFee);
            Map(x => x.ServiceFee);
        }
    }
}
