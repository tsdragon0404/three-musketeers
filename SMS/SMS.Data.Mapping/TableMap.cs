using FluentNHibernate.Mapping;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class TableMap : ClassMap<Table>
    {
        public TableMap()
         {
             Table("Tables");
             Id(x => x.Id).GeneratedBy.Identity();
             Map(x => x.Name);
         }
    }
}