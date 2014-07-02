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

            HasManyToMany(x => x.UsersInBranch)
                .Cascade.All()
                .Table("UserBranch")
                .ParentKeyColumn("BranchID")
                .ChildKeyColumn("UserID")
                .Not.LazyLoad();
        }
    }
}
