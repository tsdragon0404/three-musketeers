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
            Map(x => x.UseDiscountOnProduct);
            Map(x => x.UseKitchenFunction);

            HasOne(x => x.BranchInfo).Cascade.All();
            HasMany(x => x.Taxs).KeyColumn("BranchID").Inverse().Cascade.AllDeleteOrphan();

            HasManyToMany(x => x.Users)
                .Cascade.None()
                .Table("UserBranch")
                .ParentKeyColumn("BranchID")
                .ChildKeyColumn("UserID").ChildWhere("IsSystemAdmin = 0 AND UseSystemConfig = 0")
                .Not.LazyLoad();
        }
    }
}
