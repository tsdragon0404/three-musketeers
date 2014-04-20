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
            Map(x => x.BranchID);
            Map(x => x.Enable);
            HasMany(x => x.Tables)
                .KeyColumn("AreaId")
                .Inverse();
        }
    }
}