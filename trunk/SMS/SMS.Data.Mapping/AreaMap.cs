using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class AreaMap : BaseMap<Area>
    {
        public AreaMap()
        {
            Table("Area");
            Map(x => x.VNName);
            Map(x => x.ENName);
            References(x => x.Branch).Column("BranchID")
                .Cascade.None();
            HasMany(x => x.Tables)
                .KeyColumn("AreaID")
                .Inverse();
        }
    }
}