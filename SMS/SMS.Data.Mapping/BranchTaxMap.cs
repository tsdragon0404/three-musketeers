using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class BranchTaxMap : BaseMap<BranchTax>
    {
        public BranchTaxMap()
        {
            Table("BranchTax");
            Map(x => x.BranchID);
            References(x => x.Tax).Column("TaxID");
        }
    }
}
