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
            Map(x => x.BranchID);
            Map(x => x.Enable);
        }
    }
}