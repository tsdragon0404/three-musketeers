using FluentNHibernate.Mapping;
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
            Map(x => x.Enable);
            Map(x => x.SEQ);
            Map(x => x.CreatedDate);
            Map(x => x.CreatedUser);
            Map(x => x.ModifiedDate);
            Map(x => x.ModifiedUser);
        }
    }
}