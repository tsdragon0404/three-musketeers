using FluentNHibernate;
using FluentNHibernate.Mapping;
using TM.Framework.Data.Models;

namespace TM.Infrastructure.Data.Mappings
{
    public class BaseMap<T> : ClassMap<T>
    {
        protected BaseMap()
        {
            var type = typeof (T);
            if(type.IsSubclassOf(typeof(Entity)))
            {
                Id(x => (x as Entity).Id).Column(string.Format("{0}Id", GetName())).GeneratedBy.Guid().Default("(newid())");
            }
        }

        protected virtual string GetName()
        {
            return typeof (T).Name;
        }
    }
}
