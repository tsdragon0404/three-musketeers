using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class BranchTaxMap : BaseMap<BranchTax>
    {
        public BranchTaxMap()
        {
            Table("BranchTax");
            References(x => x.Branch).Column("BranchID");
            References(x => x.Tax).Column("TaxID");
        }
    }
}
