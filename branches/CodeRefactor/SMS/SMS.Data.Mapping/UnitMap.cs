using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UnitMap : BaseMap<Unit>
    {
        public UnitMap()
        {
            Table("Unit");
            Map(x => x.VNName);
            Map(x => x.ENName);
            References(x => x.Branch).Column("BranchID")
                .Cascade.None();
        }
    }
}