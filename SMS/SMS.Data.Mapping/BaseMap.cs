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
                 Id(x => (x as Entity).Id).Column(string.Format("{0}ID", GetName())).GeneratedBy.Identity();
             }
         }

        protected string GetName()
        {
            return typeof (T).Name;
        }
    }
}