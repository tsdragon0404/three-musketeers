using Core.Data;
using FluentNHibernate.Mapping;

namespace SMS.Data.Mapping
{
    public class BaseMap<T> : ClassMap<T>
    {
         protected BaseMap()
         {
             var type = typeof(T);

             if (type.IsSubclassOf(typeof(Entity)))
             {
                 Id(x => (x as Entity).Id).GeneratedBy.Identity();
             }
         }
    }
}