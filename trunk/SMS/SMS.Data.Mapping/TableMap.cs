using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class TableMap : BaseMap<Table>
    {
        public TableMap()
        {
            Table("[Table]");
            Map(x => x.VNName);
            Map(x => x.ENName);
            Map(x => x.AreaID);
            References(x => x.Area).Column("AreaID");
            Map(x => x.Enable);
        }
    }
}