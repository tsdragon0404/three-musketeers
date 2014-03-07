using FMS.Entities;
using FluentNHibernate.Mapping;

namespace FMS.Data.Mapping
{
    public class SectionMap : ClassMap<Section>
    {
         public SectionMap()
         {
             Id(x => x.Id).GeneratedBy.Increment();
             Map(x => x.Name);
             Map(x => x.IsDeleted);
             Version(x => x.Version);
         }
    }
}