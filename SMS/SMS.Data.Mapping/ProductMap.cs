using FluentNHibernate.Mapping;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
         public ProductMap()
         {
             Table("Products");
             Id(x => x.Id).GeneratedBy.Identity();
             Map(x => x.Name);
         }
    }
}