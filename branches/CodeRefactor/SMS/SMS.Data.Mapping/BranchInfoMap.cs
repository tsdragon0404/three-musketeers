using SMS.Data.Entities;
using FluentNHibernate.Mapping;

namespace SMS.Data.Mapping
{
    public class BranchInfoMap : ClassMap<BranchInfo>
    {
        public BranchInfoMap()
        {
            Table("BranchInfo");
            Id(x => x.ID).Column("BranchID").GeneratedBy.Foreign("Branch");
            HasOne(x => x.Branch).Constrained().ForeignKey();
            Map(x => x.CompanyCode);
            Map(x => x.CompanyName);
            Map(x => x.Phone);
            Map(x => x.Fax);
            Map(x => x.Email);
            Map(x => x.TaxCode);
            Map(x => x.Address);
            Map(x => x.Info1);
            Map(x => x.Info2);
            Map(x => x.Info3);
            Map(x => x.Info4);
            Map(x => x.Info5);
            Map(x => x.Info6);
            Map(x => x.Info7);
            Map(x => x.Info8);
            Map(x => x.Info9);
            Map(x => x.Info10);
        }
    }
}
