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
            References(x => x.Area).Column("AreaID");
            HasMany(x => x.InvoiceTables).KeyColumn("TableID");
        }
    }
}